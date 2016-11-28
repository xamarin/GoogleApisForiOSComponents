using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreFoundation;

namespace Firebase.Storage
{
	// @interface FIRStorage : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRStorage")]
	interface Storage
	{
		// extern const unsigned char *const FirebaseStorageVersionString;
		[Internal]
		[Field ("FirebaseStorageVersionString", "__Internal")]
		IntPtr _CurrentVersion { get; }

		// extern NSString *const _Nonnull FIRStorageErrorDomain;
		[Field ("FIRStorageErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// +(instancetype _Nonnull)storage;
		[Static]
		[Export ("storage")]
		Storage DefaultInstance { get; }

		// +(instancetype _Nonnull)storageForApp:(FIRApp * _Nonnull)app;
		[Static]
		[Export ("storageForApp:")]
		Storage From (Firebase.Analytics.App app);

		// @property (readonly, nonatomic, strong) FIRApp * _Nonnull app;
		[Export ("app", ArgumentSemantic.Strong)]
		Firebase.Analytics.App App { get; }

		// @property NSTimeInterval maxUploadRetryTime;
		[Export ("maxUploadRetryTime")]
		double MaxUploadRetryTime { get; set; }

		// @property NSTimeInterval maxDownloadRetryTime;
		[Export ("maxDownloadRetryTime")]
		double MaxDownloadRetryTime { get; set; }

		// @property NSTimeInterval maxOperationRetryTime;
		[Export ("maxOperationRetryTime")]
		double MaxOperationRetryTime { get; set; }

		// @property (nonatomic, strong) dispatch_queue_t _Nonnull callbackQueue;
		[Export ("callbackQueue", ArgumentSemantic.Strong)]
		DispatchQueue CallbackQueue { get; set; }

		// -(FIRStorageReference * _Nonnull)reference;
		[Export ("reference")]
		StorageReference GetRootReference ();

		// -(FIRStorageReference * _Nonnull)referenceForURL:(NSString * _Nonnull)string;
		[Export ("referenceForURL:")]
		StorageReference GetReferenceFromUrl (string url);

		// -(FIRStorageReference * _Nonnull)referenceWithPath:(NSString * _Nonnull)string;
		[Export ("referenceWithPath:")]
		StorageReference GetReferenceFromPath (string path);
	}

	// @interface FIRStorageDownloadTask : FIRStorageObservableTask <FIRStorageTaskManagement>
	[BaseType (typeof (StorageObservableTask), Name = "FIRStorageDownloadTask")]
	interface StorageDownloadTask : StorageTaskManagement
	{
	}

	// @interface FIRStorageMetadata : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "FIRStorageMetadata")]
	interface StorageMetadata : INSCopying
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull bucket;
		[Export ("bucket")]
		string Bucket { get; }

		// @property (copy, nonatomic) NSString * _Nullable cacheControl;
		[NullAllowed]
		[Export ("cacheControl")]
		string CacheControl { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable contentDisposition;
		[NullAllowed]
		[Export ("contentDisposition")]
		string ContentDisposition { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable contentEncoding;
		[NullAllowed]
		[Export ("contentEncoding")]
		string ContentEncoding { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable contentLanguage;
		[NullAllowed]
		[Export ("contentLanguage")]
		string ContentLanguage { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable contentType;
		[NullAllowed]
		[Export ("contentType")]
		string ContentType { get; set; }

		// @property (readonly) int64_t generation;
		[Export ("generation")]
		long Generation { get; }

		// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable customMetadata;
		[NullAllowed]
		[Export ("customMetadata", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSString> CustomMetadata { get; set; }

		// @property (readonly) int64_t metageneration;
		[Export ("metageneration")]
		long Metageneration { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed]
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable path;
		[NullAllowed]
		[Export ("path")]
		string Path { get; }

		// @property (readonly) int64_t size;
		[Export ("size")]
		long Size { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nullable timeCreated;
		[NullAllowed]
		[Export ("timeCreated", ArgumentSemantic.Copy)]
		NSDate TimeCreated { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nullable updated;
		[NullAllowed]
		[Export ("updated", ArgumentSemantic.Copy)]
		NSDate Updated { get; }

		// @property (readonly, nonatomic, strong) FIRStorageReference * _Nullable storageReference;
		[NullAllowed]
		[Export ("storageReference", ArgumentSemantic.Strong)]
		StorageReference StorageReference { get; }

		// @property (readonly, nonatomic, strong) NSArray<NSURL *> * _Nullable downloadURLs;
		[NullAllowed]
		[Export ("downloadURLs", ArgumentSemantic.Strong)]
		NSUrl [] DownloadUrls { get; }

		// -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)dictionary __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// -(NSDictionary * _Nonnull)dictionaryRepresentation;
		[Export ("dictionaryRepresentation")]
		NSDictionary DictionaryRepresentation { get; }

		// @property (readonly, getter = isFile) BOOL file;
		[Export ("isFile")]
		bool IsFile { get; }

		// @property (readonly, getter = isFolder) BOOL folder;
		[Export ("isFolder")]
		bool IsFolder { get; }

		// -(NSURL * _Nullable)downloadURL;
		[NullAllowed]
		[Export ("downloadURL")]
		NSUrl DownloadUrl { get; }
	}

	delegate void StorageObservableTaskEventObserverHandler (StorageTaskSnapshot snapshot);

	// @interface FIRStorageObservableTask : FIRStorageTask
	[BaseType (typeof (StorageTask), Name = "FIRStorageObservableTask")]
	interface StorageObservableTask
	{
		// -(FIRStorageHandle _Nonnull)observeStatus:(FIRStorageTaskStatus)status handler:(void (^ _Nonnull)(FIRStorageTaskSnapshot * _Nonnull))handler;
		[Export ("observeStatus:handler:")]
		string ObserveStatus (StorageTaskStatus status, StorageObservableTaskEventObserverHandler handler);

		// -(void)removeObserverWithHandle:(FIRStorageHandle _Nonnull)handle;
		[Export ("removeObserverWithHandle:")]
		void RemoveObserver (string handle);

		// -(void)removeAllObserversForStatus:(FIRStorageTaskStatus)status;
		[Export ("removeAllObserversForStatus:")]
		void RemoveAllObservers (StorageTaskStatus status);

		// -(void)removeAllObservers;
		[Export ("removeAllObservers")]
		void RemoveAllObservers ();
	}

	delegate void StorageGetPutUpdateCompletionHandler ([NullAllowed] StorageMetadata metadata, [NullAllowed] NSError error);
	delegate void StorageGetDataCompletionHandler ([NullAllowed] NSData data, [NullAllowed] NSError error);
	delegate void StorageDownloadUrlCompletionHandler ([NullAllowed] NSUrl url, [NullAllowed] NSError error);
	delegate void StorageWriteToFileCompletionHandler ([NullAllowed] NSUrl url, [NullAllowed] NSError error);
	delegate void StorageDeleteCompletionHandler ([NullAllowed] NSError error);

	// @interface FIRStorageReference : NSObject
	[BaseType (typeof (NSObject), Name = "FIRStorageReference")]
	interface StorageReference
	{
		// @property (readonly, nonatomic) FIRStorage * _Nonnull storage;
		[Export ("storage")]
		Storage Storage { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull bucket;
		[Export ("bucket")]
		string Bucket { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull fullPath;
		[Export ("fullPath")]
		string FullPath { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// -(FIRStorageReference * _Nonnull)root;
		[Export ("root")]
		StorageReference Root { get; }

		// -(FIRStorageReference * _Nullable)parent;
		[NullAllowed]
		[Export ("parent")]
		StorageReference Parent { get; }

		// -(FIRStorageReference * _Nonnull)child:(NSString * _Nonnull)path;
		[Export ("child:")]
		StorageReference GetChild (string path);

		// -(FIRStorageUploadTask * _Nonnull)putData:(NSData * _Nonnull)uploadData;
		[Export ("putData:")]
		StorageUploadTask PutData (NSData uploadData);

		// -(FIRStorageUploadTask * _Nonnull)putData:(NSData * _Nonnull)uploadData metadata:(FIRStorageMetadata * _Nullable)metadata;
		[Export ("putData:metadata:")]
		StorageUploadTask PutData (NSData uploadData, [NullAllowed] StorageMetadata metadata);

		// -(FIRStorageUploadTask * _Nonnull)putData:(NSData * _Nonnull)uploadData metadata:(FIRStorageMetadata * _Nullable)metadata completion:(void (^ _Nullable)(FIRStorageMetadata * _Nullable, NSError * _Nullable))completion;
		[Export ("putData:metadata:completion:")]
		StorageUploadTask PutData (NSData uploadData, [NullAllowed] StorageMetadata metadata, [NullAllowed] StorageGetPutUpdateCompletionHandler completion);

		// -(FIRStorageUploadTask * _Nonnull)putFile:(NSURL * _Nonnull)fileURL;
		[Export ("putFile:")]
		StorageUploadTask PutFile (NSUrl fileUrl);

		// -(FIRStorageUploadTask * _Nonnull)putFile:(NSURL * _Nonnull)fileURL metadata:(FIRStorageMetadata * _Nullable)metadata;
		[Export ("putFile:metadata:")]
		StorageUploadTask PutFile (NSUrl fileUrl, [NullAllowed] StorageMetadata metadata);

		// -(FIRStorageUploadTask * _Nonnull)putFile:(NSURL * _Nonnull)fileURL metadata:(FIRStorageMetadata * _Nullable)metadata completion:(void (^ _Nullable)(FIRStorageMetadata * _Nullable, NSError * _Nullable))completion;
		[Export ("putFile:metadata:completion:")]
		StorageUploadTask PutFile (NSUrl fileUrl, [NullAllowed] StorageMetadata metadata, [NullAllowed] StorageGetPutUpdateCompletionHandler completion);

		// -(FIRStorageDownloadTask * _Nonnull)dataWithMaxSize:(int64_t)size completion:(void (^ _Nonnull)(NSData * _Nullable, NSError * _Nullable))completion;
		[Export ("dataWithMaxSize:completion:")]
		StorageDownloadTask GetData (long maxSize, StorageGetDataCompletionHandler completion);

		// -(void)downloadURLWithCompletion:(void (^ _Nonnull)(NSURL * _Nullable, NSError * _Nullable))completion;
		[Export ("downloadURLWithCompletion:")]
		void GetDownloadUrl (StorageDownloadUrlCompletionHandler completion);

		// -(FIRStorageDownloadTask * _Nonnull)writeToFile:(NSURL * _Nonnull)fileURL;
		[Export ("writeToFile:")]
		StorageDownloadTask WriteToFile (NSUrl fileUrl);

		// -(FIRStorageDownloadTask * _Nonnull)writeToFile:(NSURL * _Nonnull)fileURL completion:(void (^ _Nullable)(NSURL * _Nullable, NSError * _Nullable))completion;
		[Export ("writeToFile:completion:")]
		StorageDownloadTask WriteToFile (NSUrl fileURL, [NullAllowed] StorageWriteToFileCompletionHandler completion);

		// -(void)metadataWithCompletion:(void (^ _Nonnull)(FIRStorageMetadata * _Nullable, NSError * _Nullable))completion;
		[Export ("metadataWithCompletion:")]
		void GetMetadata (StorageGetPutUpdateCompletionHandler completion);

		// -(void)updateMetadata:(FIRStorageMetadata * _Nonnull)metadata completion:(void (^ _Nullable)(FIRStorageMetadata * _Nullable, NSError * _Nullable))completion;
		[Export ("updateMetadata:completion:")]
		void UpdateMetadata (StorageMetadata metadata, [NullAllowed] StorageGetPutUpdateCompletionHandler completion);

		// -(void)deleteWithCompletion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Export ("deleteWithCompletion:")]
		void Delete ([NullAllowed] StorageDeleteCompletionHandler completion);
	}

	// @interface FIRStorageTask : NSObject
	[BaseType (typeof (NSObject), Name = "FIRStorageTask")]
	interface StorageTask
	{
		// @property (readonly, nonatomic, strong) FIRStorageTaskSnapshot * _Nonnull snapshot;
		[Export ("snapshot", ArgumentSemantic.Strong)]
		StorageTaskSnapshot Snapshot { get; }
	}

	interface IStorageTaskManagement
	{
	}

	// @protocol FIRStorageTaskManagement <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FIRStorageTaskManagement")]
	interface StorageTaskManagement
	{
		// @required -(void)enqueue;
		[Abstract]
		[Export ("enqueue")]
		void Enqueue ();

		// @optional -(void)pause;
		[Export ("pause")]
		void Pause ();

		// @optional -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// @optional -(void)resume;
		[Export ("resume")]
		void Resume ();
	}

	// @interface FIRStorageTaskSnapshot : NSObject
	[BaseType (typeof (NSObject), Name = "FIRStorageTaskSnapshot")]
	interface StorageTaskSnapshot
	{
		// @property (readonly, copy, nonatomic) __kindof FIRStorageTask * _Nonnull task;
		[Internal]
		[Export ("task", ArgumentSemantic.Copy)]
		IntPtr _Task { get; }

		// @property (readonly, copy, nonatomic) FIRStorageMetadata * _Nullable metadata;
		[NullAllowed]
		[Export ("metadata", ArgumentSemantic.Copy)]
		StorageMetadata Metadata { get; }

		// @property (readonly, copy, nonatomic) FIRStorageReference * _Nonnull reference;
		[Export ("reference", ArgumentSemantic.Copy)]
		StorageReference Reference { get; }

		// @property (readonly, nonatomic, strong) NSProgress * _Nullable progress;
		[NullAllowed]
		[Export ("progress", ArgumentSemantic.Strong)]
		NSProgress Progress { get; }

		// @property (readonly, copy, nonatomic) NSError * _Nullable error;
		[NullAllowed]
		[Export ("error", ArgumentSemantic.Copy)]
		NSError Error { get; }

		// @property (readonly, nonatomic) FIRStorageTaskStatus status;
		[Export ("status")]
		StorageTaskStatus Status { get; }
	}

	// @interface FIRStorageUploadTask : FIRStorageObservableTask <FIRStorageTaskManagement>
	[BaseType (typeof (StorageObservableTask), Name = "FIRStorageUploadTask")]
	interface StorageUploadTask : StorageTaskManagement
	{
	}
}
