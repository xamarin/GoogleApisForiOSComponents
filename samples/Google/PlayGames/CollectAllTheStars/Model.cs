using System;
using Google.Play.GameServices;
using Foundation;
using UIKit;

namespace CollectAllTheStars
{
    public class Model
    {
        const string DEFAULT_SAVE_NAME = "snapshotTemp";

        public Model ()
        {            
            StarSaveSlot = NSNumber.FromInt32 (0);
            Inventory = new StarInventory ();
        }

        SnapshotMetadata CurrentSnapshotMetadata { get;set; }

        NSNumber StarSaveSlot { get; set; }
        SnapshotOpenHandler UpdatedHandler { get;set; }
        StarInventory Inventory { get;set; }
        public ScreenViewController ScreenViewController { get;set; }

        public void LoadSnapshot (SnapshotMetadata snapshotMetadata)
        {
            if (snapshotMetadata != null)
                CurrentSnapshotMetadata = snapshotMetadata;

            var filename = CurrentSnapshotMetadata != null ? CurrentSnapshotMetadata.FileName : DEFAULT_SAVE_NAME;

            Console.WriteLine ("Opening our snapshot...");

            SnapshotMetadata.Open (filename, SnapshotConflictPolicy.Manual, async delegate(SnapshotMetadata snapshot, string conflictId, SnapshotMetadata conflictingBase, SnapshotMetadata conflictingRemote, NSError error) {
                if (error != null) {
                    Console.WriteLine ("Error: {0}", error);
                    return;
                }

                if (!string.IsNullOrEmpty (conflictId)) {
                    Console.WriteLine ("Received a conflict! Let's resolve it.");
                    resolveSnapshot (conflictingBase, conflictingRemote, conflictId);
                } else {
                    // If the conflict ID is not present, the snapshot has successfully been opened.
                    Console.WriteLine ("Snapshot: {0}, {1}, {2}, {3}", snapshot.SnapshotDescription, snapshot.DebugDescription, snapshot.FileName, snapshot.PlayedTime);
                    CurrentSnapshotMetadata = snapshot;
                    readCurrentSnapshot ();
                }
            });
        }





//        - (void)readCurrentSnapshot {
//            [self.currentSnapshotMetadata readWithCompletionHandler:^(NSData *data, NSError *error) {
//                if (!error) {
//                    NSLog(@"Successfully read %d blocks", (int) data.length);
//                    self.inventory = [GCATStarInventory starInventoryFromCloudData:data];
//                    [self.screenViewController allDoneWithCloud];
//
//                } else {
//                    NSLog(@"Error while loading snapshot data: %@", error);
//                    NSLog(@"Error description: %@", [error description]);
//                }
//            }];
//        }

        void readCurrentSnapshot ()
        {
            CurrentSnapshotMetadata.Read (async delegate(NSData data, NSError error) {
                if (error == null) {
                    Console.WriteLine ("Successfully read {0} blocks", data.Length);
                    Inventory = StarInventory.FromCloudData (data);
                    ScreenViewController.AllDoneWithCloud ();
                } else {
                    Console.WriteLine ("Error while loading snapshot data: {0}", error);
                    Console.WriteLine ("Error description: {0}", error.Description);
                }
            });
        }

        public void SaveSnapshot (UIImage snapshotImage)
        {
            Console.WriteLine ("Saving snapshot");

            if (CurrentSnapshotMetadata.IsOpen)
                commitCurrentSnapshot (snapshotImage);
            else
                Console.WriteLine ("Error: You really should load before you can save");
        }

        /**
        * If you want to attempt a manual merge, this would be the way to do it.
        * Note that in general, manual merges work best if you have "union" type of merges where taking
        * the highest value is the best resolution (i.e. high scores on a level, stars per level, 
        * unlocked levels, etc.)
        */
        void resolveSnapshot (SnapshotMetadata conflictingSnapshotBase, SnapshotMetadata conflictingSnapshotRemote, string conflictId)
        {
            Console.WriteLine ("Resolving snapshot conflicts: {0} >> {1}", conflictingSnapshotBase, conflictingSnapshotRemote);

            conflictingSnapshotBase.Read (async delegate(NSData baseData, NSError baseError) {
                if (baseError == null) {
                    conflictingSnapshotRemote.Read (async delegate(NSData remoteData, NSError remoteError) {
                        if (remoteError == null) {
                            var baseInv = StarInventory.FromCloudData (baseData);
                            var remoteInv = StarInventory.FromCloudData (remoteData);
                            var merged = new StarInventory ();

                            for (int world = 1; world <= 20; world++) {
                                for (int level = 1; level <= 12; level++) {
                                    var baseStars = baseInv.GetStars (world, level);
                                    var remoteStars = remoteInv.GetStars (world, level);
                                    var maxStars = Math.Max (baseStars, remoteStars);
                                    if (maxStars > 0) {
                                        Console.WriteLine ("Level {0}-{1} had {2} stars on base, {3} stars on remote. Merging to {4}",
                                            world, level, baseStars, remoteStars, maxStars);
                                        merged.SetStars (maxStars, world, level);
                                    }
                                }
                            }

                            // We have a merged data set, we need to create a merged metadata change
                            var change = new SnapshotMetadataChange ();
                            change.SnapshotDescription = "Merged save data";
                            change.PlayedTime = Math.Max (conflictingSnapshotBase.PlayedTime, conflictingSnapshotRemote.PlayedTime);

                            var mergedData = merged.GetCloudData ();


                            //                            [base resolveWithMetadataChange:change conflictId:conflictId data:mergedData completionHandler:^(GPGSnapshotMetadata *snapshotMetadata, NSError *error) {
                            //                                if (!error) {
                            //                                    // Once we're done, we need to re-read the returned snapshot in case there are further
                            //                                    // conflicts waiting to be merged
                            //                                    [self loadSnapshot:snapshotMetadata];
                            //                                }
                            //                            }];
                        }
                    });
                }
            });
        }

        void commitCurrentSnapshot (UIImage snapshotImage, string description, NSData gameData)
        {
            if (!CurrentSnapshotMetadata.IsOpen) {
                // Perhaps we could be harsher here and make this an assertion
                Console.WriteLine ("Error trying to commit a snapshot. You must always open it first");
                return;
            }

            var dataChange = new SnapshotMetadataChange ();
            dataChange.SnapshotDescription = description;

            // Done for simplicity, but this should really record the time since you last
            // opened a snapshot
            int millsSinceaPreviousSnapshotWasOpened = 10000;

            dataChange.PlayedTime = CurrentSnapshotMetadata.PlayedTime + millsSinceaPreviousSnapshotWasOpened;
            dataChange.CoverImage = new SnapshotMetadataChangeCoverImage (snapshotImage);

            CurrentSnapshotMetadata.Commit (dataChange, gameData, async delegate(SnapshotMetadata snapshotMetadata, NSError error) {
                if (error == null) {
                    Console.WriteLine ("Successfully saved {0}", snapshotMetadata);
                    // Once our game has been saved, we should re-open it, so it's ready for saving again.
                    LoadSnapshot (snapshotMetadata);
                } else {
                    Console.WriteLine ("Error while saving: {0}", error);
                } 
            });
        }

        void commitCurrentSnapshot (UIImage snapshotImage)
        {
            commitCurrentSnapshot (snapshotImage, "Saved via iOS Sample app", Inventory.GetCloudData ());
        }

        public int GetStars (int world, int level) 
        {
            return Inventory.GetStars (world, level);
        }

        public void SetStars (int world, int level, int stars)
        {
            Inventory.SetStars (world, level, stars);
        }
    }
}

