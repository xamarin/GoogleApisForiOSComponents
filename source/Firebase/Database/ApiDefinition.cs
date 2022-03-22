using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreFoundation;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Firebase.Database
{
	// @interface FIRDatabase : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRDatabase")]
	interface Database
	{
		// +(FIRDatabase * _Nonnull)database;
		[Static]
		[Export ("database")]
		Database DefaultInstance { get; }

		// + (FIRDatabase *)databaseWithURL:(NSString *)url NS_SWIFT_NAME(database(url:));
		[Static]
		[Export ("databaseWithURL:")]
		Database From (string url);

		// + (FIRDatabase *)databaseForApp:(FIRApp *)app URL:(NSString*) url NS_SWIFT_NAME (database(app:url:));
		[Static]
		[Export ("databaseForApp:URL:")]
		Database From (Firebase.Core.App app, string url);

		// +(FIRDatabase * _Nonnull)databaseForApp:(FIRApp * _Nonnull)app;
		[Static]
		[Export ("databaseForApp:")]
		Database From (Firebase.Core.App app);

		// @property (readonly, nonatomic, weak) FIRApp * _Nullable app;
		[NullAllowed, Export ("app", ArgumentSemantic.Weak)]
		Firebase.Core.App App { get; }

		// -(FIRDatabaseReference * _Nonnull)reference;
		[Export ("reference")]
		DatabaseReference GetRootReference ();

		// -(FIRDatabaseReference * _Nonnull)referenceWithPath:(NSString * _Nonnull)path;
		[Export ("referenceWithPath:")]
		DatabaseReference GetReferenceFromPath (string path);

		// -(FIRDatabaseReference * _Nonnull)referenceFromURL:(NSString * _Nonnull)databaseUrl;
		[Export ("referenceFromURL:")]
		DatabaseReference GetReferenceFromUrl (string databaseUrl);

		// -(void)purgeOutstandingWrites;
		[Export ("purgeOutstandingWrites")]
		void PurgeOutstandingWrites ();

		// -(void)goOffline;
		[Export ("goOffline")]
		void GoOffline ();

		// -(void)goOnline;
		[Export ("goOnline")]
		void GoOnline ();

		// @property (nonatomic) BOOL persistenceEnabled;
		[Export ("persistenceEnabled")]
		bool PersistenceEnabled { get; set; }

		// @property (nonatomic) NSUInteger persistenceCacheSizeBytes;
		[Export ("persistenceCacheSizeBytes")]
		nuint PersistenceCacheSizeBytes { get; set; }

		// @property (nonatomic, strong) dispatch_queue_t _Nonnull callbackQueue;
		[Export ("callbackQueue", ArgumentSemantic.Strong)]
		DispatchQueue CallbackQueue { get; set; }

		// +(void)setLoggingEnabled:(BOOL)enabled;
		[Static]
		[Export ("setLoggingEnabled:")]
		void SetLoggingEnabled (bool enabled);

		// +(NSString * _Nonnull)sdkVersion;
		[Static]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		// - (void) useEmulatorWithHost:(NSString*) host port:(NSInteger) port;		
		[Export ("useEmulatorWithHost:port:")]
		void UseEmulatorWithHost (string host, uint port);
	}

	delegate void DatabaseQueryUpdateHandler (DataSnapshot snapshot);
	delegate void DatabaseQueryPreviousSiblingKeyUpdateHandler (DataSnapshot snapshot, [NullAllowed] string prevKey);
	delegate void DatabaseQueryCancelHandler (NSError error);

	// @interface FIRDatabaseQuery : NSObject
	[BaseType (typeof (NSObject), Name = "FIRDatabaseQuery")]
	interface DatabaseQuery
	{
		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block;
		[Export ("observeEventType:withBlock:")]
		nuint ObserveEvent (DataEventType eventType, DatabaseQueryUpdateHandler completionHandler);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block;
		[Export ("observeEventType:andPreviousSiblingKeyWithBlock:")]
		nuint ObserveEvent (DataEventType eventType, DatabaseQueryPreviousSiblingKeyUpdateHandler completionHandler);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeEventType:withBlock:withCancelBlock:")]
		nuint ObserveEvent (DataEventType eventType, DatabaseQueryUpdateHandler completionHandler, [NullAllowed] DatabaseQueryCancelHandler cancelHandler);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeEventType:andPreviousSiblingKeyWithBlock:withCancelBlock:")]
		nuint ObserveEvent (DataEventType eventType, DatabaseQueryPreviousSiblingKeyUpdateHandler completionHandler, [NullAllowed] DatabaseQueryCancelHandler cancelHandler);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block;
		[Export ("observeSingleEventOfType:withBlock:")]
		void ObserveSingleEvent (DataEventType eventType, DatabaseQueryUpdateHandler completionHandler);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block;
		[Export ("observeSingleEventOfType:andPreviousSiblingKeyWithBlock:")]
		void ObserveSingleEvent (DataEventType eventType, DatabaseQueryPreviousSiblingKeyUpdateHandler completionHandler);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeSingleEventOfType:withBlock:withCancelBlock:")]
		void ObserveSingleEvent (DataEventType eventType, DatabaseQueryUpdateHandler completionHandler, [NullAllowed] DatabaseQueryCancelHandler cancelHandler);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[Export ("observeSingleEventOfType:andPreviousSiblingKeyWithBlock:withCancelBlock:")]
		void ObserveSingleEvent (DataEventType eventType, DatabaseQueryPreviousSiblingKeyUpdateHandler completionHandler, [NullAllowed] DatabaseQueryCancelHandler cancelHandler);

		// -(void)removeObserverWithHandle:(FIRDatabaseHandle)handle;
		[Export ("removeObserverWithHandle:")]
		void RemoveObserver (nuint handle);

		// -(void)removeAllObservers;
		[Export ("removeAllObservers")]
		void RemoveAllObservers ();

		// -(void)keepSynced:(BOOL)keepSynced;
		[Export ("keepSynced:")]
		void KeepSynced (bool keepSynced);

		// -(FIRDatabaseQuery * _Nonnull)queryLimitedToFirst:(NSUInteger)limit;
		[Export ("queryLimitedToFirst:")]
		DatabaseQuery GetQueryLimitedToFirst (nuint limit);

		// -(FIRDatabaseQuery * _Nonnull)queryLimitedToLast:(NSUInteger)limit;
		[Export ("queryLimitedToLast:")]
		DatabaseQuery GetQueryLimitedToLast (nuint limit);

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByChild:(NSString * _Nonnull)key;
		[Export ("queryOrderedByChild:")]
		DatabaseQuery GetQueryOrderedByChild (string key);

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByKey;
		[Export ("queryOrderedByKey")]
		DatabaseQuery GetQueryOrderedByKey ();

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByValue;
		[Export ("queryOrderedByValue")]
		DatabaseQuery GetQueryOrderedByValue ();

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByPriority;
		[Export ("queryOrderedByPriority")]
		DatabaseQuery GetQueryOrderedByPriority ();

		// -(FIRDatabaseQuery * _Nonnull)queryStartingAtValue:(id _Nullable)startValue;
		[Export ("queryStartingAtValue:")]
		DatabaseQuery GetQueryStartingAtValue ([NullAllowed] NSObject startValue);

		// -(FIRDatabaseQuery * _Nonnull)queryStartingAtValue:(id _Nullable)startValue childKey:(NSString * _Nullable)childKey;
		[Export ("queryStartingAtValue:childKey:")]
		DatabaseQuery GetQueryStartingAtValue ([NullAllowed] NSObject startValue, [NullAllowed] string childKey);

		// - (FIRDatabaseQuery *)queryStartingAfterValue:(nullable id)startAfterValue;
		[New]
		[Export ("queryStartingAfterValue:")]
		DatabaseQuery GetQueryStartingAfterValue ([NullAllowed] NSObject startAfterValue);

		// - (FIRDatabaseQuery *)queryStartingAfterValue:(nullable id)startAfterValue childKey:(nullable NSString *)childKey;
		[New]
		[Export ("queryStartingAfterValue:childKey:")]
		DatabaseQuery GetQueryStartingAfterValue ([NullAllowed] NSObject startAfterValue, [NullAllowed] string childKey);

		// -(FIRDatabaseQuery * _Nonnull)queryEndingAtValue:(id _Nullable)endValue;
		[Export ("queryEndingAtValue:")]
		DatabaseQuery GetQueryEndingAtValue ([NullAllowed] NSObject endValue);

		// -(FIRDatabaseQuery * _Nonnull)queryEndingAtValue:(id _Nullable)endValue childKey:(NSString * _Nullable)childKey;
		[Export ("queryEndingAtValue:childKey:")]
		DatabaseQuery GetQueryEndingAtValue ([NullAllowed] NSObject endValue, [NullAllowed] string childKey);

		// - (FIRDatabaseQuery *)queryEndingBeforeValue:(nullable id)endValue;
		[New]
		[Export ("queryEndingBeforeValue:")]
		DatabaseQuery GetQueryEndingBeforeValue ([NullAllowed] NSObject endValue);

		// - (FIRDatabaseQuery *)queryEndingBeforeValue:(nullable id)endValue childKey:(nullable NSString *)childKey;
		[New]
		[Export ("queryEndingBeforeValue:childKey:")]
		DatabaseQuery GetQueryEndingBeforeValue ([NullAllowed] NSObject endValue, [NullAllowed] string childKey);

		// -(FIRDatabaseQuery * _Nonnull)queryEqualToValue:(id _Nullable)value;
		[Export ("queryEqualToValue:")]
		DatabaseQuery GetQueryEqualToValue ([NullAllowed] NSObject value);

		// -(FIRDatabaseQuery * _Nonnull)queryEqualToValue:(id _Nullable)value childKey:(NSString * _Nullable)childKey;
		[Export ("queryEqualToValue:childKey:")]
		DatabaseQuery GetQueryEqualToValue ([NullAllowed] NSObject value, [NullAllowed] string childKey);

		// @property (readonly, nonatomic, strong) FIRDatabaseReference * _Nonnull ref;
		[Export ("ref", ArgumentSemantic.Strong)]
		DatabaseReference Reference { get; }
	}

	delegate void DatabaseReferenceCompletionHandler ([NullAllowed] NSError error, DatabaseReference reference);
	delegate TransactionResult DatabaseReferenceTransactionHandler (MutableData currentData);
	delegate void DatabaseReferenceTransactionCompletionHandler ([NullAllowed] NSError error, bool commited, [NullAllowed] DataSnapshot snapshot);
	delegate void DataSnapshotCompletionHandler ([NullAllowed] NSError error, [NullAllowed] DataSnapshot snapshot);

	// @interface FIRDatabaseReference : FIRDatabaseQuery
	[BaseType (typeof (DatabaseQuery), Name = "FIRDatabaseReference")]
	interface DatabaseReference
	{
		// -(FIRDatabaseReference * _Nonnull)child:(NSString * _Nonnull)pathString;
		[Export ("child:")]
		DatabaseReference GetChild (string pathString);

		// -(FIRDatabaseReference * _Nonnull)childByAutoId;
		[Export ("childByAutoId")]
		DatabaseReference GetChildByAutoId ();

		// -(void)setValue:(id _Nullable)value;
		[Internal]
		[Export ("setValue:")]
		void _SetValue ([NullAllowed] NSObject value);

		// -(void)setValue:(id _Nullable)value withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Internal]
		[Export ("setValue:withCompletionBlock:")]
		void _SetValue ([NullAllowed] NSObject value, DatabaseReferenceCompletionHandler completionHandler);

		// -(void)setValue:(id _Nullable)value andPriority:(id _Nullable)priority;
		[Internal]
		[Export ("setValue:andPriority:")]
		void _SetValue ([NullAllowed] NSObject value, [NullAllowed] NSObject priority);

		// -(void)setValue:(id _Nullable)value andPriority:(id _Nullable)priority withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Internal]
		[Export ("setValue:andPriority:withCompletionBlock:")]
		void _SetValue ([NullAllowed] NSObject value, [NullAllowed] NSObject priority, DatabaseReferenceCompletionHandler completionHandler);

		// -(void)removeValue;
		[Export ("removeValue")]
		void RemoveValue ();

		// -(void)removeValueWithCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("removeValueWithCompletionBlock:")]
		void RemoveValue (DatabaseReferenceCompletionHandler completionHandler);

		// -(void)setPriority:(id _Nullable)priority;
		[Export ("setPriority:")]
		void SetPriority ([NullAllowed] NSObject priority);

		// -(void)setPriority:(id _Nullable)priority withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("setPriority:withCompletionBlock:")]
		void SetPriority ([NullAllowed] NSObject priority, DatabaseReferenceCompletionHandler completionHandler);

		// -(void)updateChildValues:(NSDictionary * _Nonnull)values;
		[Export ("updateChildValues:")]
		void UpdateChildValues (NSDictionary values);

		// -(void)updateChildValues:(NSDictionary * _Nonnull)values withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("updateChildValues:withCompletionBlock:")]
		void UpdateChildValues (NSDictionary values, DatabaseReferenceCompletionHandler completionHandler);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block;
		[New]
		[Export ("observeEventType:withBlock:")]
		nuint ObserveEvent (DataEventType eventType, DatabaseQueryUpdateHandler completionHandler);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block;
		[New]
		[Export ("observeEventType:andPreviousSiblingKeyWithBlock:")]
		nuint ObserveEvent (DataEventType eventType, DatabaseQueryPreviousSiblingKeyUpdateHandler completionHandler);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[New]
		[Export ("observeEventType:withBlock:withCancelBlock:")]
		nuint ObserveEvent (DataEventType eventType, DatabaseQueryUpdateHandler completionHandler, [NullAllowed] DatabaseQueryCancelHandler cancelHandler);

		// -(FIRDatabaseHandle)observeEventType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[New]
		[Export ("observeEventType:andPreviousSiblingKeyWithBlock:withCancelBlock:")]
		nuint ObserveEvent (DataEventType eventType, DatabaseQueryPreviousSiblingKeyUpdateHandler completionHandler, [NullAllowed] DatabaseQueryCancelHandler cancelHandler);

		// - (void)getDataWithCompletionBlock: (void (^_Nonnull)(NSError* __nullable error, FIRDataSnapshot *snapshot))block;		
		[New]
		[Export ("getDataWithCompletionBlock:")]
		void GetData (DataSnapshotCompletionHandler completionHandler);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block;
		[New]
		[Export ("observeSingleEventOfType:withBlock:")]
		void ObserveSingleEvent (DataEventType eventType, DatabaseQueryUpdateHandler completionHandler);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block;
		[New]
		[Export ("observeSingleEventOfType:andPreviousSiblingKeyWithBlock:")]
		void ObserveSingleEvent (DataEventType eventType, DatabaseQueryPreviousSiblingKeyUpdateHandler completionHandler);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType withBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[New]
		[Export ("observeSingleEventOfType:withBlock:withCancelBlock:")]
		void ObserveSingleEvent (DataEventType eventType, DatabaseQueryUpdateHandler completionHandler, [NullAllowed] DatabaseQueryCancelHandler cancelHandler);

		// -(void)observeSingleEventOfType:(FIRDataEventType)eventType andPreviousSiblingKeyWithBlock:(void (^ _Nonnull)(FIRDataSnapshot * _Nonnull, NSString * _Nullable))block withCancelBlock:(void (^ _Nullable)(NSError * _Nonnull))cancelBlock;
		[New]
		[Export ("observeSingleEventOfType:andPreviousSiblingKeyWithBlock:withCancelBlock:")]
		void ObserveSingleEvent (DataEventType eventType, DatabaseQueryPreviousSiblingKeyUpdateHandler completionHandler, [NullAllowed] DatabaseQueryCancelHandler cancelHandler);

		// -(void)removeObserverWithHandle:(FIRDatabaseHandle)handle;
		[New]
		[Export ("removeObserverWithHandle:")]
		void RemoveObserver (nuint handle);

		// -(void)keepSynced:(BOOL)keepSynced;
		[New]
		[Export ("keepSynced:")]
		void KeepSynced (bool keepSynced);

		// -(void)removeAllObservers;
		[New]
		[Export ("removeAllObservers")]
		void RemoveAllObservers ();

		// -(FIRDatabaseQuery * _Nonnull)queryLimitedToFirst:(NSUInteger)limit;
		[New]
		[Export ("queryLimitedToFirst:")]
		DatabaseQuery GetQueryLimitedToFirst (nuint limit);

		// -(FIRDatabaseQuery * _Nonnull)queryLimitedToLast:(NSUInteger)limit;
		[New]
		[Export ("queryLimitedToLast:")]
		DatabaseQuery GetQueryLimitedToLast (nuint limit);

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByChild:(NSString * _Nonnull)key;
		[New]
		[Export ("queryOrderedByChild:")]
		DatabaseQuery GetQueryOrderedByChild (string key);

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByKey;
		[New]
		[Export ("queryOrderedByKey")]
		DatabaseQuery GetQueryOrderedByKey ();

		// -(FIRDatabaseQuery * _Nonnull)queryOrderedByPriority;
		[New]
		[Export ("queryOrderedByPriority")]
		DatabaseQuery GetQueryOrderedByPriority ();

		// -(FIRDatabaseQuery * _Nonnull)queryStartingAtValue:(id _Nullable)startValue;
		[New]
		[Export ("queryStartingAtValue:")]
		DatabaseQuery GetQueryStartingAtValue ([NullAllowed] NSObject startValue);

		// -(FIRDatabaseQuery * _Nonnull)queryStartingAtValue:(id _Nullable)startValue childKey:(NSString * _Nullable)childKey;
		[New]
		[Export ("queryStartingAtValue:childKey:")]
		DatabaseQuery GetQueryStartingAtValue ([NullAllowed] NSObject startValue, [NullAllowed] string childKey);

		// - (FIRDatabaseQuery *)queryStartingAfterValue:(nullable id)startAfterValue;
		[New]
		[Export ("queryStartingAfterValue:")]
		DatabaseQuery GetQueryStartingAfterValue ([NullAllowed] NSObject startAfterValue);

		// - (FIRDatabaseQuery *)queryStartingAfterValue:(nullable id)startAfterValue childKey:(nullable NSString *)childKey;
		[New]
		[Export ("queryStartingAfterValue:childKey:")]
		DatabaseQuery GetQueryStartingAfterValue ([NullAllowed] NSObject startAfterValue, [NullAllowed] string childKey);

		// -(FIRDatabaseQuery * _Nonnull)queryEndingAtValue:(id _Nullable)endValue;
		[New]
		[Export ("queryEndingAtValue:")]
		DatabaseQuery GetQueryEndingAtValue ([NullAllowed] NSObject endValue);

		// -(FIRDatabaseQuery * _Nonnull)queryEndingAtValue:(id _Nullable)endValue childKey:(NSString * _Nullable)childKey;
		[New]
		[Export ("queryEndingAtValue:childKey:")]
		DatabaseQuery GetQueryEndingAtValue ([NullAllowed] NSObject endValue, [NullAllowed] string childKey);

		// -(FIRDatabaseQuery * _Nonnull)queryEqualToValue:(id _Nullable)value;
		[New]
		[Export ("queryEqualToValue:")]
		DatabaseQuery GetQueryEqualToValue ([NullAllowed] NSObject value);

		// -(FIRDatabaseQuery * _Nonnull)queryEqualToValue:(id _Nullable)value childKey:(NSString * _Nullable)childKey;
		[New]
		[Export ("queryEqualToValue:childKey:")]
		DatabaseQuery GetQueryEqualToValue ([NullAllowed] NSObject value, [NullAllowed] string childKey);

		// -(void)onDisconnectSetValue:(id _Nullable)value;
		[Internal]
		[Export ("onDisconnectSetValue:")]
		void _SetValueOnDisconnect ([NullAllowed] NSObject value);

		// -(void)onDisconnectSetValue:(id _Nullable)value withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Internal]
		[Export ("onDisconnectSetValue:withCompletionBlock:")]
		void _SetValueOnDisconnect ([NullAllowed] NSObject value, DatabaseReferenceCompletionHandler completionHandler);

		// -(void)onDisconnectSetValue:(id _Nullable)value andPriority:(id _Nonnull)priority;
		[Internal]
		[Export ("onDisconnectSetValue:andPriority:")]
		void _SetValueOnDisconnect ([NullAllowed] NSObject value, NSObject priority);

		// -(void)onDisconnectSetValue:(id _Nullable)value andPriority:(id _Nullable)priority withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Internal]
		[Export ("onDisconnectSetValue:andPriority:withCompletionBlock:")]
		void _SetValueOnDisconnect ([NullAllowed] NSObject value, [NullAllowed] NSObject priority, DatabaseReferenceCompletionHandler completionHandler);

		// -(void)onDisconnectRemoveValue;
		[Export ("onDisconnectRemoveValue")]
		void RemoveValueOnDisconnect ();

		// -(void)onDisconnectRemoveValueWithCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("onDisconnectRemoveValueWithCompletionBlock:")]
		void RemoveValueOnDisconnect (DatabaseReferenceCompletionHandler completionHandler);

		// -(void)onDisconnectUpdateChildValues:(NSDictionary * _Nonnull)values;
		[Export ("onDisconnectUpdateChildValues:")]
		void UpdateChildValuesOnDisconnect (NSDictionary values);

		// -(void)onDisconnectUpdateChildValues:(NSDictionary * _Nonnull)values withCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("onDisconnectUpdateChildValues:withCompletionBlock:")]
		void UpdateChildValuesOnDisconnect (NSDictionary values, DatabaseReferenceCompletionHandler completionHandler);

		// -(void)cancelDisconnectOperations;
		[Export ("cancelDisconnectOperations")]
		void CancelDisconnectOperations ();

		// -(void)cancelDisconnectOperationsWithCompletionBlock:(void (^ _Nullable)(NSError * _Nullable, FIRDatabaseReference * _Nonnull))block;
		[Export ("cancelDisconnectOperationsWithCompletionBlock:")]
		void CancelDisconnectOperations ([NullAllowed] DatabaseReferenceCompletionHandler completionHandler);

		// +(void)goOffline;
		[Static]
		[Export ("goOffline")]
		void GoOffline ();

		// +(void)goOnline;
		[Static]
		[Export ("goOnline")]
		void GoOnline ();

		// -(void)runTransactionBlock:(FIRTransactionResult * _Nonnull (^ _Nonnull)(FIRMutableData * _Nonnull))block;
		[Export ("runTransactionBlock:")]
		void RunTransaction (DatabaseReferenceTransactionHandler transactionHandler);

		// -(void)runTransactionBlock:(FIRTransactionResult * _Nonnull (^ _Nonnull)(FIRMutableData * _Nonnull))block andCompletionBlock:(void (^ _Nonnull)(NSError * _Nullable, BOOL, FIRDataSnapshot * _Nullable))completionBlock;
		[Export ("runTransactionBlock:andCompletionBlock:")]
		void RunTransaction (DatabaseReferenceTransactionHandler transactionHandler, DatabaseReferenceTransactionCompletionHandler completionBlock);

		// -(void)runTransactionBlock:(FIRTransactionResult * _Nonnull (^ _Nonnull)(FIRMutableData * _Nonnull))block andCompletionBlock:(void (^ _Nullable)(NSError * _Nullable, BOOL, FIRDataSnapshot * _Nullable))completionBlock withLocalEvents:(BOOL)localEvents;
		[Export ("runTransactionBlock:andCompletionBlock:withLocalEvents:")]
		void RunTransaction (DatabaseReferenceTransactionHandler transactionHandler, DatabaseReferenceTransactionCompletionHandler completionBlock, bool localEvents);

		// -(NSString * _Nonnull)description;
		[New]
		[Export ("description")]
		string Description { get; }

		// @property (readonly, nonatomic, strong) FIRDatabaseReference * _Nullable parent;
		[NullAllowed]
		[Export ("parent", ArgumentSemantic.Strong)]
		DatabaseReference Parent { get; }

		// @property (readonly, nonatomic, strong) FIRDatabaseReference * _Nonnull root;
		[Export ("root", ArgumentSemantic.Strong)]
		DatabaseReference Root { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull key;
		[Export ("key", ArgumentSemantic.Strong)]
		string Key { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull URL;
		[Export ("URL", ArgumentSemantic.Strong)]
		string Url { get; }

		// @property (readonly, nonatomic, strong) FIRDatabase * _Nonnull database;
		[Export ("database", ArgumentSemantic.Strong)]
		Database Database { get; }
	}

	// @interface FIRDataSnapshot : NSObject
	[BaseType (typeof (NSObject), Name = "FIRDataSnapshot")]
	interface DataSnapshot
	{
		// -(FIRDataSnapshot * _Nonnull)childSnapshotForPath:(NSString * _Nonnull)childPathString;
		[Export ("childSnapshotForPath:")]
		DataSnapshot GetChildSnapshot (string childPathString);

		// -(BOOL)hasChild:(NSString * _Nonnull)childPathString;
		[Export ("hasChild:")]
		bool HasChild (string childPathString);

		// -(BOOL)hasChildren;
		[Export ("hasChildren")]
		bool HasChildren { get; }

		// -(BOOL)exists;
		[Export ("exists")]
		bool Exists { get; }

		// -(id _Nullable)valueInExportFormat;
		[NullAllowed]
		[Export ("valueInExportFormat")]
		NSObject ValueInExportFormat { get; }

		// @property (readonly, nonatomic, strong) id _Nullable value;
		[Internal]
		[NullAllowed]
		[Export ("value")]
		IntPtr _Value { get; }

		// @property (readonly, nonatomic) NSUInteger childrenCount;
		[Export ("childrenCount")]
		nuint ChildrenCount { get; }

		// @property (readonly, nonatomic, strong) FIRDatabaseReference * _Nonnull ref;
		[Export ("ref", ArgumentSemantic.Strong)]
		DatabaseReference Reference { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull key;
		[Export ("key", ArgumentSemantic.Strong)]
		string Key { get; }

		// @property (readonly, nonatomic, strong) NSEnumerator * _Nonnull children;
		[Export ("children", ArgumentSemantic.Strong)]
		NSEnumerator Children { get; }

		// @property (readonly, nonatomic, strong) id _Nullable priority;
		[NullAllowed]
		[Export ("priority", ArgumentSemantic.Strong)]
		NSObject Priority { get; }
	}

	// @interface FIRMutableData : NSObject
	[BaseType (typeof (NSObject), Name = "FIRMutableData")]
	interface MutableData
	{
		// -(BOOL)hasChildren;
		[Export ("hasChildren")]
		bool HasChildren { get; }

		// -(BOOL)hasChildAtPath:(NSString * _Nonnull)path;
		[Export ("hasChildAtPath:")]
		bool HasChildAtPath (string path);

		// -(FIRMutableData * _Nonnull)childDataByAppendingPath:(NSString * _Nonnull)path;
		[Export ("childDataByAppendingPath:")]
		MutableData GetChildData (string path);

		// @property (nonatomic, strong) id _Nullable value;
		[Internal]
		[NullAllowed]
		[Export ("value", ArgumentSemantic.Strong)]
		IntPtr _Value { get; set; }

		// @property (nonatomic, strong) id _Nullable priority;
		[NullAllowed]
		[Export ("priority", ArgumentSemantic.Strong)]
		NSObject Priority { get; set; }

		// @property (readonly, nonatomic) NSUInteger childrenCount;
		[Export ("childrenCount")]
		nuint ChildrenCount { get; }

		// @property (readonly, nonatomic, strong) NSEnumerator * _Nonnull children;
		[Export ("children", ArgumentSemantic.Strong)]
		NSEnumerator Children { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable key;
		[NullAllowed, Export ("key", ArgumentSemantic.Strong)]
		string Key { get; }
	}

	// @interface FIRServerValue : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRServerValue")]
	interface ServerValue
	{
		// +(NSDictionary * _Nonnull)timestamp;
		[Static]
		[Export ("timestamp")]
		NSDictionary Timestamp { get; }
	}

	// @interface FIRTransactionResult : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRTransactionResult")]
	interface TransactionResult
	{
		// +(FIRTransactionResult * _Nonnull)successWithValue:(FIRMutableData * _Nonnull)value;
		[Static]
		[Export ("successWithValue:")]
		TransactionResult Success (MutableData value);

		// +(FIRTransactionResult * _Nonnull)abort;
		[Static]
		[Export ("abort")]
		TransactionResult Abort ();
	}
}
