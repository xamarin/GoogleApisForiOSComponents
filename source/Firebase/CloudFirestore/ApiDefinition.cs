﻿using System;
using System.Collections.Generic;

using Foundation;
using ObjCRuntime;
using CoreFoundation;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Firebase.CloudFirestore
{
	// void (^ _Nullable)(NSError * _Nullable)
	delegate void AddDocumentCompletionHandler ([NullAllowed] NSError error);

	// @interface FIRCollectionReference : FIRQuery
	[DisableDefaultCtor]
	[BaseType (typeof (Query), Name = "FIRCollectionReference")]
	interface CollectionReference
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull collectionID;
		[Export ("collectionID", ArgumentSemantic.Strong)]
		string Id { get; }
		
		// @property (readonly, nonatomic, strong) FIRDocumentReference * _Nullable parent;
		[NullAllowed]
		[Export ("parent", ArgumentSemantic.Strong)]
		DocumentReference Parent { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull path;
		[Export ("path", ArgumentSemantic.Strong)]
		string Path { get; }

		// -(FIRDocumentReference * _Nonnull)documentWithAutoID;
		[Export ("documentWithAutoID")]
		DocumentReference CreateDocument ();

		// -(FIRDocumentReference * _Nonnull)documentWithPath:(NSString * _Nonnull)documentPath;
		[Export ("documentWithPath:")]
		DocumentReference GetDocument (string documentPath);

		// -(FIRDocumentReference * _Nonnull)addDocumentWithData:(NSDictionary<NSString *,id> * _Nonnull)data;
		[Export ("addDocumentWithData:")]
		DocumentReference AddDocument (NSDictionary<NSString, NSObject> nsData);

		[Wrap ("AddDocument (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count))")]
		DocumentReference AddDocument (Dictionary<object, object> data);

		// -(FIRDocumentReference * _Nonnull)addDocumentWithData:(NSDictionary<NSString *,id> * _Nonnull)data completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Export ("addDocumentWithData:completion:")]
		DocumentReference AddDocument (NSDictionary<NSString, NSObject> nsData, AddDocumentCompletionHandler completion);

		[Wrap ("AddDocument (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), completion)")]
		DocumentReference AddDocument (Dictionary<object, object> data, AddDocumentCompletionHandler completion);
	}

	// @interface FIRDocumentChange : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRDocumentChange")]
	interface DocumentChange
	{
		// @property (readonly, nonatomic) FIRDocumentChangeType type;
		[Export ("type")]
		DocumentChangeType Type { get; }

		// @property (readonly, nonatomic, strong) FIRDocumentSnapshot * _Nonnull document;
		[Export ("document", ArgumentSemantic.Strong)]
		QueryDocumentSnapshot Document { get; }

		// @property (readonly, nonatomic) NSUInteger oldIndex;
		[Export ("oldIndex")]
		nuint OldIndex { get; }

		// @property (readonly, nonatomic) NSUInteger newIndex;
		[Export ("newIndex")]
		nuint NewIndex { get; }
	}

	// typedef void (^FIRDocumentSnapshotBlock)(FIRDocumentSnapshot * _Nullable, NSError * _Nullable);
	delegate void DocumentSnapshotHandler ([NullAllowed] DocumentSnapshot snapshot, [NullAllowed] NSError error);

	// void (^)(NSError * _Nullable)
	delegate void DocumentActionCompletionHandler ([NullAllowed] NSError error);

	// @interface FIRDocumentReference : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRDocumentReference")]
	interface DocumentReference
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull documentID;
		[Export ("documentID", ArgumentSemantic.Strong)]
		string Id { get; }

		// @property (readonly, nonatomic, strong) FIRCollectionReference * _Nonnull parent;
		[Export ("parent", ArgumentSemantic.Strong)]
		CollectionReference Parent { get; }

		// @property (readonly, nonatomic, strong) FIRFirestore * _Nonnull firestore;
		[Export ("firestore", ArgumentSemantic.Strong)]
		Firestore Firestore { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull path;
		[Export ("path", ArgumentSemantic.Strong)]
		string Path { get; }

		// -(FIRCollectionReference * _Nonnull)collectionWithPath:(NSString * _Nonnull)collectionPath;
		[Export ("collectionWithPath:")]
		CollectionReference GetCollection (string collectionPath);

		// -(void)setData:(NSDictionary<NSString *,id> * _Nonnull)documentData;
		[Export ("setData:")]
		void SetData (NSDictionary<NSString, NSObject> nsDocumentData);

		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count))")]
		void SetData (Dictionary<object, object> documentData);

		// -(void)setData:(NSDictionary<NSString *,id> * _Nonnull)documentData merge:(BOOL)merge;
		[Export ("setData:merge:")]
		void SetData (NSDictionary<NSString, NSObject> nsDocumentData, bool merge);

		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), merge)")]
		void SetData (Dictionary<object, object> documentData, bool merge);

		// - (void) setData:(NSDictionary<NSString*, id>*) documentData mergeFields:(NSArray<id>*) mergeFields;
		[Advice ("The mergeFields argument can contain NSString and FieldPath.")]
		[Export ("setData:mergeFields:")]
		void SetData (NSDictionary<NSString, NSObject> nsDocumentData, NSArray mergeFields);

		[Wrap ("SetData (nsDocumentData, NSArray.FromStrings (mergeFields))")]
		void SetData (NSDictionary<NSString, NSObject> nsDocumentData, string [] mergeFields);

		[Wrap ("SetData (nsDocumentData, NSArray.FromNSObjects (mergeFields))")]
		void SetData (NSDictionary<NSString, NSObject> nsDocumentData, FieldPath [] mergeFields);

		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), mergeFields)")]
		void SetData (Dictionary<object, object> documentData, NSArray mergeFields);

		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), NSArray.FromStrings (mergeFields))")]
		void SetData (Dictionary<object, object> documentData, string [] mergeFields);

		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), NSArray.FromNSObjects (mergeFields))")]
		void SetData (Dictionary<object, object> documentData, FieldPath [] mergeFields);

		// -(void)setData:(NSDictionary<NSString *,id> * _Nonnull)documentData completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Async]
		[Export ("setData:completion:")]
		void SetData (NSDictionary<NSString, NSObject> nsDocumentData, [NullAllowed] DocumentActionCompletionHandler completion);

		[Async]
		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), completion)")]
		void SetData (Dictionary<object, object> documentData, [NullAllowed] DocumentActionCompletionHandler completion);

		// -(void)setData:(NSDictionary<NSString *,id> * _Nonnull)documentData merge:(BOOL)merge completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Async]
		[Export ("setData:merge:completion:")]
		void SetData (NSDictionary<NSString, NSObject> nsDocumentData, bool merge, [NullAllowed] DocumentActionCompletionHandler completion);

		[Async]
		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), merge, completion)")]
		void SetData (Dictionary<object, object> documentData, bool merge, [NullAllowed] DocumentActionCompletionHandler completion);

		// - (void)setData:(NSDictionary<NSString *, id> *)documentData mergeFields:(NSArray<id>*)mergeFields completion:(nullable void (^)(NSError* _Nullable error))completion;
		[Advice ("The mergeFields argument can contain NSString and FieldPath.")]
		[Async]
		[Export ("setData:mergeFields:completion:")]
		void SetData (NSDictionary<NSString, NSObject> nsDocumentData, NSArray mergeFields, [NullAllowed] DocumentActionCompletionHandler completion);

		[Async]
		[Wrap ("SetData (nsDocumentData, NSArray.FromStrings (mergeFields), completion)")]
		void SetData (NSDictionary<NSString, NSObject> nsDocumentData, string [] mergeFields, [NullAllowed] DocumentActionCompletionHandler completion);

		[Async]
		[Wrap ("SetData (nsDocumentData, NSArray.FromNSObjects (mergeFields), completion)")]
		void SetData (NSDictionary<NSString, NSObject> nsDocumentData, FieldPath [] mergeFields, [NullAllowed] DocumentActionCompletionHandler completion);

		[Async]
		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), mergeFields, completion)")]
		void SetData (Dictionary<object, object> documentData, NSArray mergeFields, [NullAllowed] DocumentActionCompletionHandler completion);

		[Async]
		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), NSArray.FromStrings (mergeFields), completion)")]
		void SetData (Dictionary<object, object> documentData, string [] mergeFields, [NullAllowed] DocumentActionCompletionHandler completion);

		[Async]
		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), NSArray.FromNSObjects (mergeFields), completion)")]
		void SetData (Dictionary<object, object> documentData, FieldPath [] mergeFields, [NullAllowed] DocumentActionCompletionHandler completion);

		// -(void)updateData:(NSDictionary<id,id> * _Nonnull)fields;
		[Export ("updateData:")]
		void UpdateData (NSDictionary<NSObject, NSObject> nsFields);

		[Wrap ("UpdateData (fields == null ? null : NSDictionary<NSObject, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (fields.Values), System.Linq.Enumerable.ToArray (fields.Keys), fields.Keys.Count))")]
		void UpdateData (Dictionary<object, object> fields);

		// -(void)updateData:(NSDictionary<id,id> * _Nonnull)fields completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Async]
		[Export ("updateData:completion:")]
		void UpdateData (NSDictionary<NSObject, NSObject> nsFields, [NullAllowed] DocumentActionCompletionHandler completion);

		[Async]
		[Wrap ("UpdateData (fields == null ? null : NSDictionary<NSObject, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (fields.Values), System.Linq.Enumerable.ToArray (fields.Keys), fields.Keys.Count), completion)")]
		void UpdateData (Dictionary<object, object> fields, [NullAllowed] DocumentActionCompletionHandler completion);

		// -(void)deleteDocument;
		[Export ("deleteDocument")]
		void DeleteDocument ();

		// -(void)deleteDocumentWithCompletion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Async]
		[Export ("deleteDocumentWithCompletion:")]
		void DeleteDocument ([NullAllowed] DocumentActionCompletionHandler completion);

		// -(void)getDocumentWithCompletion:(FIRDocumentSnapshotBlock _Nonnull)completion;
		[Async]
		[Export ("getDocumentWithCompletion:")]
		void GetDocument (DocumentSnapshotHandler completion);

		// -(void)getDocumentWithSource:(FIRFirestoreSource)source completion:(FIRDocumentSnapshotBlock _Nonnull)completion;
		[Export ("getDocumentWithSource:completion:")]
		void GetDocument (FirestoreSource source, DocumentSnapshotHandler completion);

		// -(id<FIRListenerRegistration> _Nonnull)addSnapshotListener:(FIRDocumentSnapshotBlock _Nonnull)listener;
		[Export ("addSnapshotListener:")]
		IListenerRegistration AddSnapshotListener (DocumentSnapshotHandler listener);

		// -(id<FIRListenerRegistration> _Nonnull)addSnapshotListenerWithIncludeMetadataChanges:(BOOL)includeMetadataChanges listener:(FIRDocumentSnapshotBlock _Nonnull)listener;
		[Export ("addSnapshotListenerWithIncludeMetadataChanges:listener:")]
		IListenerRegistration AddSnapshotListener (bool includeMetadataChanges, DocumentSnapshotHandler listener);
	}

	// @interface FIRDocumentSnapshot : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRDocumentSnapshot")]
	interface DocumentSnapshot
	{
		// @property (readonly, assign, nonatomic) BOOL exists;
		[Export ("exists")]
		bool Exists { get; }

		// @property (readonly, nonatomic, strong) FIRDocumentReference * _Nonnull reference;
		[Export ("reference", ArgumentSemantic.Strong)]
		DocumentReference Reference { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull documentID;
		[Export ("documentID")]
		string Id { get; }

		// @property (readonly, nonatomic, strong) FIRSnapshotMetadata * _Nonnull metadata;
		[Export ("metadata", ArgumentSemantic.Strong)]
		SnapshotMetadata Metadata { get; }

		// -(NSDictionary<NSString *,id> * _Nonnull)data;
		[Export ("data")]
		NSDictionary<NSString, NSObject> Data { get; }

		// -(NSDictionary<NSString *,id> * _Nullable)dataWithServerTimestampBehavior:(FIRServerTimestampBehavior)serverTimestampBehavior;
		[return: NullAllowed]
		[Export ("dataWithServerTimestampBehavior:")]
		NSDictionary<NSString, NSObject> GetData (ServerTimestampBehavior serverTimestampBehavior);

		// -(id _Nullable)valueForField:(id _Nonnull)field;
		[return: NullAllowed]
		[Export ("valueForField:")]
		NSObject GetValue (NSObject field);

		// -(id _Nullable)valueForField:(id _Nonnull)field serverTimestampBehavior:(FIRServerTimestampBehavior)serverTimestampBehavior;
		[return: NullAllowed]
		[Export ("valueForField:serverTimestampBehavior:")]
		NSObject GetValue (NSObject field, ServerTimestampBehavior serverTimestampBehavior);

		// -(id _Nullable)objectForKeyedSubscript:(id _Nonnull)key;
		[return: NullAllowed]
		[Export ("objectForKeyedSubscript:")]
		NSObject GetObject (NSObject key);
	}

	// @interface FIRQueryDocumentSnapshot : FIRDocumentSnapshot
	[DisableDefaultCtor]
	[BaseType (typeof (DocumentSnapshot), Name = "FIRQueryDocumentSnapshot")]
	interface QueryDocumentSnapshot {
		// -(NSDictionary<NSString *,id> * _Nonnull)data;
		[New]
		[Export ("data")]
		NSDictionary<NSString, NSObject> Data { get; }

		// -(NSDictionary<NSString *,id> * _Nonnull)dataWithServerTimestampBehavior:(FIRServerTimestampBehavior)serverTimestampBehavior;
		[New]
		[Export ("dataWithServerTimestampBehavior:")]
		NSDictionary<NSString, NSObject> GetData (ServerTimestampBehavior serverTimestampBehavior);
	}

	// @interface FIRFieldPath : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRFieldPath")]
	interface FieldPath : INSCopying
	{
		// -(instancetype _Nonnull)initWithFields:(NSArray<NSString *> * _Nonnull)fieldNames;
		[Export ("initWithFields:")]
		NativeHandle Constructor (string [] fieldNames);

		// +(instancetype _Nonnull)documentID;
		[Static]
		[Export ("documentID")]
		FieldPath GetDocumentId ();
	}

	// @interface FIRFieldValue : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRFieldValue")]
	interface FieldValue
	{
		// +(instancetype _Nonnull)fieldValueForDelete;
		[Static]
		[Export ("fieldValueForDelete")]
		FieldValue Delete { get; }

		// +(instancetype _Nonnull)fieldValueForServerTimestamp;
		[Static]
		[Export ("fieldValueForServerTimestamp")]
		FieldValue ServerTimestamp { get; }

		// +(instancetype)fieldValueForArrayUnion:(NSArray<id> *)elements;
		[Static]
		[Export ("fieldValueForArrayUnion:")]
		FieldValue FromArrayUnion (NSObject [] elements);

		// +(instancetype)fieldValueForArrayRemove:(NSArray<id> *)elements NS_SWIFT_NAME(arrayRemove(_:));
		[Static]
		[Export ("fieldValueForArrayRemove:")]
		FieldValue FromArrayRemove (NSObject [] elements);

		// +(instancetype _Nonnull)fieldValueForDoubleIncrement:(double)d __attribute__((swift_name("increment(_:)")));
		[Static]
		[Export ("fieldValueForDoubleIncrement:")]
		FieldValue FromDoubleIncrement (double d);

		// +(instancetype _Nonnull)fieldValueForIntegerIncrement:(int64_t)l __attribute__((swift_name("increment(_:)")));
		[Static]
		[Export ("fieldValueForIntegerIncrement:")]
		FieldValue FromIntegerIncrement (long l);

	}

	// void (^)(id _Nullable result, NSError *_Nullable error)
	delegate void TransactionCompletionHandler ([NullAllowed] NSObject result, [NullAllowed] NSError error);
	// (nullable void (^)(FIRLoadBundleTaskProgress *_Nullable progress, NSError *_Nullable error)
	delegate void LoadBundleCompletionHandler ([NullAllowed] LoadBundleTaskProgress progress, [NullAllowed] NSError error);

	// @interface FIRFirestore : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRFirestore")]
	interface Firestore
	{
		// extern NSString *const _Nonnull FIRFirestoreErrorDomain;
		[Field ("FIRFirestoreErrorDomain", "__Internal")]
		NSString ErrorDomain { get; }

		// +(instancetype _Nonnull)firestore;
		[Static]
		[Export ("firestore")]
		Firestore SharedInstance { get; }
		 
		// +(instancetype _Nonnull)firestoreForApp:(FIRApp * _Nonnull)app;
		[Static]
		[Export ("firestoreForApp:")]
		Firestore Create (Firebase.Core.App app);

		// @property (copy, nonatomic) FIRFirestoreSettings * _Nonnull settings;
		[Export ("settings", ArgumentSemantic.Copy)]
		FirestoreSettings Settings { get; set; }

		// @property (readonly, nonatomic, strong) FIRApp * _Nonnull app;
		[Export ("app", ArgumentSemantic.Strong)]
		Firebase.Core.App App { get; }

		// -(FIRCollectionReference * _Nonnull)collectionWithPath:(NSString * _Nonnull)collectionPath;
		[Export ("collectionWithPath:")]
		CollectionReference GetCollection (string collectionPath);

		// -(FIRDocumentReference * _Nonnull)documentWithPath:(NSString * _Nonnull)documentPath;
		[Export ("documentWithPath:")]
		DocumentReference GetDocument (string documentPath);

		// -(FIRQuery * _Nonnull)collectionGroupWithID:(NSString * _Nonnull)collectionID __attribute__((swift_name("collectionGroup(_:)")));
		[Export ("collectionGroupWithID:")]
		Query GetCollectionGroup (string collectionId);

		// -(void)runTransactionWithBlock:(id  _Nullable (^ _Nonnull)(FIRTransaction * _Nonnull, NSError * _Nullable * _Nullable))updateBlock completion:(void (^ _Nonnull)(id _Nullable, NSError * _Nullable))completion;
		[Internal]
		[Export ("runTransactionWithBlock:completion:")]
		void _RunTransaction (Func<Transaction, IntPtr, NSObject> updateHandler, TransactionCompletionHandler completion);

		// -(FIRWriteBatch * _Nonnull)batch;
		[Export ("batch")]
		WriteBatch CreateBatch ();

		[Static]
		[Export ("enableLogging:")]
		void EnableLogging (bool logging);

		// - (void) useEmulatorWithHost:(NSString*) host port:(NSInteger) port;		
		[Export ("useEmulatorWithHost:port:")]
		void UseEmulatorWithHost (string host, uint port);

		// -(void)enableNetworkWithCompletion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Async]
		[Export ("enableNetworkWithCompletion:")]
		void EnableNetwork ([NullAllowed] Action<NSError> completion);

		// -(void)disableNetworkWithCompletion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Async]
		[Export ("disableNetworkWithCompletion:")]
		void DisableNetwork ([NullAllowed] Action<NSError> completion);

		// -(void)clearPersistenceWithCompletion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Async]
		[Export ("clearPersistenceWithCompletion:")]
		void ClearPersistence ([NullAllowed] Action<NSError> completion);

		// -(void)waitForPendingWritesWithCompletion:(void (^ _Nonnull)(NSError * _Nullable))completion;
		[Async]
		[Export ("waitForPendingWritesWithCompletion:")]
		void WaitForPendingWrites (Action<NSError> completion);

		// -(id<FIRListenerRegistration> _Nonnull)addSnapshotsInSyncListener:(void (^ _Nonnull)(void))listener __attribute__((swift_name("addSnapshotsInSyncListener(_:)")));
		[Async]
		[Export ("addSnapshotsInSyncListener:")]
		IListenerRegistration AddSnapshotsInSyncListener (Action listener);

		// -(void)terminateWithCompletion:(void (^ _Nullable)(NSError * _Nullable))completion __attribute__((swift_name("terminate(completion:)")));
		[Async]
		[Export ("terminateWithCompletion:")]
		void Terminate ([NullAllowed] Action<NSError> completion);

		// - (FIRLoadBundleTask *)loadBundle:(NSData *)bundleData;
		[Export ("loadBundle:")]
		LoadBundleTask LoadBundle (NSData bundleData);

		// - (FIRLoadBundleTask *)loadBundle:(NSData *)bundleData completion:(nullable void (^)(FIRLoadBundleTaskProgress *_Nullable progress, NSError *_Nullable error))completion;
		[Export ("loadBundle:completion:")]
		LoadBundleTask LoadBundle (NSData bundleData, [NullAllowed] LoadBundleCompletionHandler completion);

		// - (FIRLoadBundleTask *)loadBundleStream:(NSInputStream *)bundleStream;
		[Export ("loadBundleStream:")]
		LoadBundleTask LoadBundleStream (NSInputStream bundleStream);

		// - (FIRLoadBundleTask *)loadBundleStream:(NSInputStream *)bundleStream completion: (nullable void (^)(FIRLoadBundleTaskProgress *_Nullable progress, NSError *_Nullable error))completion
		[Export ("loadBundleStream:completion:")]
		LoadBundleTask LoadBundleStream (NSInputStream bundleStream, [NullAllowed] LoadBundleCompletionHandler completion);

		// - (void)getQueryNamed:(NSString *)name completion:(void (^)(FIRQuery *_Nullable query))completion
		[Export ("getQueryNamed:completion:")]
		void GetQueryNamed (NSInputStream bundleStream, Action<Query> completion);
	}

	// @interface FIRTimestamp : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRLoadBundleTaskProgress")]
	interface LoadBundleTaskProgress {
		// @property(readonly, nonatomic) NSInteger documentsLoaded;
		[Export ("documentsLoaded")]
		nint DocumentsLoaded { get; }

		// @property(readonly, nonatomic) NSInteger totalDocuments;
		[Export ("totalDocuments")]
		nint TotalDocuments { get; }

		// @property(readonly, nonatomic) NSInteger bytesLoaded;
		[Export ("bytesLoaded")]
		nint BytesLoaded { get; }

		// @property(readonly, nonatomic) NSInteger totalBytes;
		[Export ("totalBytes")]
		nint TotalBytes { get; }

		//@property(readonly, nonatomic) FIRLoadBundleTaskState state;
		[Export ("state")]
		LoadBundleTaskState State { get; }
	}

	// @interface FIRTimestamp : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRLoadBundleTask")]
	interface LoadBundleTask {
		// - (FIRLoadBundleObserverHandle):(void (^)(FIRLoadBundleTaskProgress *progress))observer
		[Export ("addObserver:")]
		nint AddObserver (Action<LoadBundleTaskProgress> observer);

		// - (void)removeObserverWithHandle:(FIRLoadBundleObserverHandle)handle
		[Export ("removeObserverWithHandle:")]
		void RemoveObserver (nint handle);

		// - (void)removeAllObservers;
		[Export ("removeAllObservers")]
		void RemoveAllObservers ();
	}

	// @interface FIRFirestoreSettings : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "FIRFirestoreSettings")]
	interface FirestoreSettings : INSCopying
	{
		// extern const int64_t kFIRFirestoreCacheSizeUnlimited __attribute__((swift_name("FirestoreCacheSizeUnlimited")));
		[Field ("kFIRFirestoreCacheSizeUnlimited", "__Internal")]
		long CacheSizeUnlimited { get; }

		// @property (copy, nonatomic) NSString * _Nonnull host;
		[Export ("host")]
		string Host { get; set; }

		// @property (getter = isSSLEnabled, nonatomic) BOOL sslEnabled;
		[Export ("sslEnabled")]
		bool SslEnabled { [Bind ("isSSLEnabled")] get; set; }

		// @property (nonatomic, strong) dispatch_queue_t _Nonnull dispatchQueue;
		[Export ("dispatchQueue", ArgumentSemantic.Strong)]
		DispatchQueue DispatchQueue { get; set; }

		// @property (getter = isPersistenceEnabled, nonatomic) BOOL persistenceEnabled;
		[Export ("persistenceEnabled")]
		bool PersistenceEnabled { [Bind ("isPersistenceEnabled")] get; set; }

		// @property (assign, nonatomic) int64_t cacheSizeBytes;
		[Export ("cacheSizeBytes")]
		long CacheSizeBytes { get; set; }
	}

	// @interface FIRGeoPoint : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRGeoPoint")]
	interface GeoPoint : INSCopying
	{
		// -(instancetype _Nonnull)initWithLatitude:(double)latitude longitude:(double)longitude __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithLatitude:longitude:")]
		NativeHandle Constructor (double latitude, double longitude);

		// @property (readonly, nonatomic) double latitude;
		[Export ("latitude")]
		double Latitude { get; }

		// @property (readonly, nonatomic) double longitude;
		[Export ("longitude")]
		double Longitude { get; }
	}

	interface IListenerRegistration { }

	// @protocol FIRListenerRegistration <NSObject>
	[Protocol (Name = "FIRListenerRegistration")]
	interface ListenerRegistration
	{
		// @required -(void)remove;
		[Abstract]
		[Export ("remove")]
		void Remove ();
	}

	// typedef void (^FIRQuerySnapshotBlock)(FIRQuerySnapshot * _Nullable, NSError * _Nullable);
	delegate void QuerySnapshotHandler ([NullAllowed] QuerySnapshot snapshot, [NullAllowed] NSError error);

	// @interface FIRQuery : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRQuery")]
	interface Query
	{
		// @property (readonly, nonatomic, strong) FIRFirestore * _Nonnull firestore;
		[Export ("firestore", ArgumentSemantic.Strong)]
		Firestore Firestore { get; }

		// -(void)getDocumentsWithCompletion:(FIRQuerySnapshotBlock _Nonnull)completion;
		[Async]
		[Export ("getDocumentsWithCompletion:")]
		void GetDocuments (QuerySnapshotHandler completion);

		// -(void)getDocumentsWithSource:(FIRFirestoreSource)source completion:(FIRQuerySnapshotBlock _Nonnull)completion;
		[Export ("getDocumentsWithSource:completion:")]
		void GetDocuments (FirestoreSource source, QuerySnapshotHandler completion);

		// -(id<FIRListenerRegistration> _Nonnull)addSnapshotListener:(FIRQuerySnapshotBlock _Nonnull)listener;
		[Export ("addSnapshotListener:")]
		IListenerRegistration AddSnapshotListener (QuerySnapshotHandler listener);

		// -(id<FIRListenerRegistration> _Nonnull)addSnapshotListenerWithIncludeMetadataChanges:(BOOL)includeMetadataChanges listener:(FIRQuerySnapshotBlock _Nonnull)listener;
		[Export ("addSnapshotListenerWithIncludeMetadataChanges:listener:")]
		IListenerRegistration AddSnapshotListener (bool includeMetadataChanges, QuerySnapshotHandler listener);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field isEqualTo:(id _Nonnull)value;
		[Export ("queryWhereField:isEqualTo:")]
		Query WhereEqualsTo (string field, NSObject nsValue);

		[Wrap ("WhereEqualsTo (field, FromObject (value))")]
		Query WhereEqualsTo (string field, object value);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path isEqualTo:(id _Nonnull)value;
		[Export ("queryWhereFieldPath:isEqualTo:")]
		Query WhereEqualsTo (FieldPath path, NSObject nsValue);

		[Wrap ("WhereEqualsTo (path, FromObject (value))")]
		Query WhereEqualsTo (FieldPath path, object value);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field isLessThan:(id _Nonnull)value;
		[Export ("queryWhereField:isLessThan:")]
		Query WhereLessThan (string field, NSObject nsValue);

		[Wrap ("WhereLessThan (field, FromObject (value))")]
		Query WhereLessThan (string field, object value);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path isLessThan:(id _Nonnull)value;
		[Export ("queryWhereFieldPath:isLessThan:")]
		Query WhereLessThan (FieldPath path, NSObject nsValue);

		[Wrap ("WhereLessThan (path, FromObject (value))")]
		Query WhereLessThan (FieldPath path, object value);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field isLessThanOrEqualTo:(id _Nonnull)value;
		[Export ("queryWhereField:isLessThanOrEqualTo:")]
		Query WhereLessThanOrEqualsTo (string field, NSObject nsValue);

		[Wrap ("WhereLessThanOrEqualsTo (field, FromObject (value))")]
		Query WhereLessThanOrEqualsTo (string field, object value);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path isLessThanOrEqualTo:(id _Nonnull)value;
		[Export ("queryWhereFieldPath:isLessThanOrEqualTo:")]
		Query WhereLessThanOrEqualsTo (FieldPath path, NSObject nsValue);

		[Wrap ("WhereLessThanOrEqualsTo (path, FromObject (value))")]
		Query WhereLessThanOrEqualsTo (FieldPath path, object value);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field isGreaterThan:(id _Nonnull)value;
		[Export ("queryWhereField:isGreaterThan:")]
		Query WhereGreaterThan (string field, NSObject nsValue);

		[Wrap ("WhereGreaterThan (field, FromObject (value))")]
		Query WhereGreaterThan (string field, object value);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path isGreaterThan:(id _Nonnull)value;
		[Export ("queryWhereFieldPath:isGreaterThan:")]
		Query WhereGreaterThan (FieldPath path, NSObject nsValue);

		[Wrap ("WhereGreaterThan (path, FromObject (value))")]
		Query WhereGreaterThan (FieldPath path, object value);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field isGreaterThanOrEqualTo:(id _Nonnull)value;
		[Export ("queryWhereField:isGreaterThanOrEqualTo:")]
		Query WhereGreaterThanOrEqualsTo (string field, NSObject nsValue);

		[Wrap ("WhereGreaterThanOrEqualsTo (field, FromObject (value))")]
		Query WhereGreaterThanOrEqualsTo (string field, object value);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path isGreaterThanOrEqualTo:(id _Nonnull)value;
		[Export ("queryWhereFieldPath:isGreaterThanOrEqualTo:")]
		Query WhereGreaterThanOrEqualsTo (FieldPath path, NSObject nsValue);

		[Wrap ("WhereGreaterThanOrEqualsTo (path, FromObject (value))")]
		Query WhereGreaterThanOrEqualsTo (FieldPath path, object value);

		// - (FIRQuery *)queryWhereField:(NSString *)field arrayContains:(id) value;
		[Export ("queryWhereField:arrayContains:")]
		Query WhereArrayContains (string path, NSObject nsValue);

		[Wrap ("WhereArrayContains (path, FromObject (value))")]
		Query WhereArrayContains (string path, object value);

		// - (FIRQuery *)queryWhereFieldPath:(FIRFieldPath *)path arrayContains:(id) value;
		[Export ("queryWhereFieldPath:arrayContains:")]
		Query WhereArrayContains (FieldPath path, NSObject nsValue);

		[Wrap ("WhereArrayContains (path, FromObject (value))")]
		Query WhereArrayContains (FieldPath path, object value);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field arrayContainsAny:(NSArray<id> * _Nonnull)values __attribute__((swift_name("whereField(_:arrayContainsAny:)")));
		[Export ("queryWhereField:arrayContainsAny:")]
		Query WhereArrayContainsAny (string field, NSObject [] values);

		[Wrap ("WhereArrayContainsAny (field, CloudFirestoreHelper.GetNSObjects (values))")]
		Query WhereArrayContainsAny(string field, object [] values);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path arrayContainsAny:(NSArray<id> * _Nonnull)values __attribute__((swift_name("whereField(_:arrayContainsAny:)")));
		[Export ("queryWhereFieldPath:arrayContainsAny:")]
		Query WhereArrayContainsAny(FieldPath path, NSObject [] values);

		[Wrap ("WhereArrayContainsAny (path, CloudFirestoreHelper.GetNSObjects (values))")]
		Query WhereArrayContainsAny(FieldPath path, object [] values);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field in:(NSArray<id> * _Nonnull)values __attribute__((swift_name("whereField(_:in:)")));
		[Export ("queryWhereField:in:")]
		Query WhereFieldIn (string field, NSObject [] values);

		[Wrap ("WhereFieldIn (field, CloudFirestoreHelper.GetNSObjects (values))")]
		Query WhereFieldIn (string field, object [] values);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path in:(NSArray<id> * _Nonnull)values __attribute__((swift_name("whereField(_:in:)")));
		[Export ("queryWhereFieldPath:in:")]
		Query WhereFieldIn (FieldPath path, NSObject [] values);

		[Wrap ("WhereFieldIn (path, CloudFirestoreHelper.GetNSObjects (values))")]
		Query WhereFieldIn (FieldPath path, object [] values);

		// -(FIRQuery * _Nonnull)queryFilteredUsingPredicate:(NSPredicate * _Nonnull)predicate;
		[Export ("queryFilteredUsingPredicate:")]
		Query FilteredBy (NSPredicate predicate);

		// -(FIRQuery * _Nonnull)queryOrderedByField:(NSString * _Nonnull)field;
		[Export ("queryOrderedByField:")]
		Query OrderedBy (string field);

		// -(FIRQuery * _Nonnull)queryOrderedByFieldPath:(FIRFieldPath * _Nonnull)path;
		[Export ("queryOrderedByFieldPath:")]
		Query OrderedBy (FieldPath path);

		// -(FIRQuery * _Nonnull)queryOrderedByField:(NSString * _Nonnull)field descending:(BOOL)descending;
		[Export ("queryOrderedByField:descending:")]
		Query OrderedBy (string field, bool descending);

		// -(FIRQuery * _Nonnull)queryOrderedByFieldPath:(FIRFieldPath * _Nonnull)path descending:(BOOL)descending;
		[Export ("queryOrderedByFieldPath:descending:")]
		Query OrderedBy (FieldPath path, bool descending);

		// -(FIRQuery * _Nonnull)queryLimitedTo:(NSInteger)limit;
		[Export ("queryLimitedTo:")]
		Query LimitedTo (nint limit);

		// -(FIRQuery * _Nonnull)queryLimitedToLast:(NSInteger)limit __attribute__((swift_name("limit(toLast:)")));
		[Export ("queryLimitedToLast:")]
		Query LimitedToLast (nint limit);

		// -(FIRQuery * _Nonnull)queryStartingAtDocument:(FIRDocumentSnapshot * _Nonnull)document;
		[Export ("queryStartingAtDocument:")]
		Query StartingAt (DocumentSnapshot document);

		// -(FIRQuery * _Nonnull)queryStartingAtValues:(NSArray * _Nonnull)fieldValues;
		[Export ("queryStartingAtValues:")]
		Query StartingAt (NSObject [] nsFieldValues);

		[Wrap ("StartingAt (CloudFirestoreHelper.GetNSObjects (fieldValues))")]
		Query StartingAt (object [] fieldValues);

		// -(FIRQuery * _Nonnull)queryStartingAfterDocument:(FIRDocumentSnapshot * _Nonnull)document;
		[Export ("queryStartingAfterDocument:")]
		Query StartingAfter (DocumentSnapshot document);

		// -(FIRQuery * _Nonnull)queryStartingAfterValues:(NSArray * _Nonnull)fieldValues;
		[Export ("queryStartingAfterValues:")]
		Query StartingAfter (NSObject [] nsFieldValues);

		[Wrap ("StartingAfter (CloudFirestoreHelper.GetNSObjects (fieldValues))")]
		Query StartingAfter (object [] fieldValues);

		// -(FIRQuery * _Nonnull)queryEndingBeforeDocument:(FIRDocumentSnapshot * _Nonnull)document;
		[Export ("queryEndingBeforeDocument:")]
		Query EndingBefore (DocumentSnapshot document);

		// -(FIRQuery * _Nonnull)queryEndingBeforeValues:(NSArray * _Nonnull)fieldValues;
		[Export ("queryEndingBeforeValues:")]
		Query EndingBefore (NSObject [] nsFieldValues);

		[Wrap ("EndingBefore (CloudFirestoreHelper.GetNSObjects (fieldValues))")]
		Query EndingBefore (object [] fieldValues);

		// -(FIRQuery * _Nonnull)queryEndingAtDocument:(FIRDocumentSnapshot * _Nonnull)document;
		[Export ("queryEndingAtDocument:")]
		Query EndingAt (DocumentSnapshot document);

		// -(FIRQuery * _Nonnull)queryEndingAtValues:(NSArray * _Nonnull)fieldValues;
		[Export ("queryEndingAtValues:")]
		Query EndingAt (NSObject [] nsFieldValues);

		[Wrap ("EndingAt (CloudFirestoreHelper.GetNSObjects (fieldValues))")]
		Query EndingAt (object [] fieldValues);
	}

	// @interface FIRQuerySnapshot : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRQuerySnapshot")]
	interface QuerySnapshot
	{
		// @property (readonly, nonatomic, strong) FIRQuery * _Nonnull query;
		[Export ("query", ArgumentSemantic.Strong)]
		Query Query { get; }

		// @property (readonly, nonatomic, strong) FIRSnapshotMetadata * _Nonnull metadata;
		[Export ("metadata", ArgumentSemantic.Strong)]
		SnapshotMetadata Metadata { get; }

		// @property (readonly, getter = isEmpty, nonatomic) BOOL empty;
		[Export ("isEmpty")]
		bool IsEmpty { get; }

		// @property (readonly, nonatomic) NSInteger count;
		[Export ("count")]
		nint Count { get; }

		// @property (readonly, nonatomic, strong) NSArray<FIRDocumentSnapshot *> * _Nonnull documents;
		[Export ("documents", ArgumentSemantic.Strong)]
		QueryDocumentSnapshot [] Documents { get; }

		// @property (readonly, nonatomic, strong) NSArray<FIRDocumentChange *> * _Nonnull documentChanges;
		[Export ("documentChanges", ArgumentSemantic.Strong)]
		DocumentChange [] DocumentChanges { get; }

		// -(NSArray<FIRDocumentChange *> * _Nonnull)documentChangesWithIncludeMetadataChanges:(BOOL)includeMetadataChanges;
		[Export ("documentChangesWithIncludeMetadataChanges:")]
		DocumentChange [] GetDocumentChanges (bool includeMetadataChanges);
	}

	// @interface FIRSnapshotMetadata : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRSnapshotMetadata")]
	interface SnapshotMetadata
	{
		// @property (readonly, getter = hasPendingWrites, assign, nonatomic) BOOL pendingWrites;
		[Export ("hasPendingWrites")]
		bool HasPendingWrites { get; }

		// @property (readonly, getter = isFromCache, assign, nonatomic) BOOL fromCache;
		[Export ("isFromCache")]
		bool IsFromCache { get; }
	}

	// @interface FIRTimestamp : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRTimestamp")]
	interface Timestamp : INSCopying {
		// -(instancetype _Nonnull)initWithSeconds:(int64_t)seconds nanoseconds:(int32_t)nanoseconds __attribute__((objc_designated_initializer));
		[Export ("initWithSeconds:nanoseconds:")]
		[DesignatedInitializer]
		NativeHandle Constructor (long seconds, int nanoseconds);

		// +(instancetype _Nonnull)timestampWithSeconds:(int64_t)seconds nanoseconds:(int32_t)nanoseconds;
		[Static]
		[Export ("timestampWithSeconds:nanoseconds:")]
		Timestamp Create (long seconds, int nanoseconds);

		// +(instancetype _Nonnull)timestampWithDate:(NSDate * _Nonnull)date;
		[Static]
		[Export ("timestampWithDate:")]
		Timestamp Create (NSDate date);

		// +(instancetype _Nonnull)timestamp;
		[Static]
		[Export ("timestamp")]
		Timestamp Create ();

		// -(NSDate * _Nonnull)dateValue;
		[Export ("dateValue")]
		NSDate DateValue { get; }

		// -(NSComparisonResult)compare:(FIRTimestamp * _Nonnull)other;
		[Export ("compare:")]
		NSComparisonResult Compare (Timestamp other);

		// @property (readonly, assign, nonatomic) int64_t seconds;
		[Export ("seconds")]
		long Seconds { get; }

		// @property (readonly, assign, nonatomic) int32_t nanoseconds;
		[Export ("nanoseconds")]
		int Nanoseconds { get; }
	}

	// @interface FIRTransaction : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRTransaction")]
	interface Transaction
	{
		// -(FIRTransaction * _Nonnull)setData:(NSDictionary<NSString *,id> * _Nonnull)data forDocument:(FIRDocumentReference * _Nonnull)document;
		[Export ("setData:forDocument:")]
		Transaction SetData (NSDictionary<NSString, NSObject> nsData, DocumentReference document);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document)")]
		Transaction SetData (Dictionary<object, object> data, DocumentReference document);

		// -(FIRTransaction * _Nonnull)setData:(NSDictionary<NSString *,id> * _Nonnull)data forDocument:(FIRDocumentReference * _Nonnull)document merge:(BOOL)merge;
		[Export ("setData:forDocument:merge:")]
		Transaction SetData (NSDictionary<NSString, NSObject> nsData, DocumentReference document, bool merge);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document, merge)")]
		Transaction SetData (Dictionary<object, object> data, DocumentReference document, bool merge);

		// - (FIRTransaction*) setData:(NSDictionary<NSString*, id>*)data forDocument:(FIRDocumentReference*)document mergeFields:(NSArray<id>*)mergeFields
		[Advice ("The mergeFields argument can contain NSString and FieldPath.")]
		[Export ("setData:forDocument:mergeFields:")]
		Transaction SetData (NSDictionary<NSString, NSObject> nsData, DocumentReference document, NSArray mergeFields);

		[Wrap ("SetData (nsData, document, NSArray.FromStrings (mergeFields))")]
		Transaction SetData (NSDictionary<NSString, NSObject> nsData, DocumentReference document, string [] mergeFields);

		[Wrap ("SetData (nsData, document, NSArray.FromNSObjects (mergeFields))")]
		Transaction SetData (NSDictionary<NSString, NSObject> nsData, DocumentReference document, FieldPath [] mergeFields);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document, mergeFields)")]
		Transaction SetData (Dictionary<object, object> data, DocumentReference document, NSArray mergeFields);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document, NSArray.FromStrings (mergeFields))")]
		Transaction SetData (Dictionary<object, object> data, DocumentReference document, string [] mergeFields);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document, NSArray.FromNSObjects (mergeFields))")]
		Transaction SetData (Dictionary<object, object> data, DocumentReference document, FieldPath [] mergeFields);

		// -(FIRTransaction * _Nonnull)updateData:(NSDictionary<id,id> * _Nonnull)fields forDocument:(FIRDocumentReference * _Nonnull)document;
		[Export ("updateData:forDocument:")]
		Transaction UpdateData (NSDictionary<NSObject, NSObject> nsFields, DocumentReference document);

		[Wrap ("UpdateData (fields == null ? null : NSDictionary<NSObject, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (fields.Values), System.Linq.Enumerable.ToArray (fields.Keys), fields.Keys.Count), document)")]
		Transaction UpdateData (Dictionary<object, object> fields, DocumentReference document);

		// -(FIRTransaction * _Nonnull)deleteDocument:(FIRDocumentReference * _Nonnull)document;
		[Export ("deleteDocument:")]
		Transaction DeleteDocument (DocumentReference document);

		// -(FIRDocumentSnapshot * _Nullable)getDocument:(FIRDocumentReference * _Nonnull)document error:(NSError * _Nullable * _Nullable)error;
		[return: NullAllowed]
		[Export ("getDocument:error:")]
		DocumentSnapshot GetDocument (DocumentReference document, [NullAllowed] out NSError error);
	}

	// void (^)(NSError *_Nullable error)
	delegate void CommitCompletionHandler ([NullAllowed] NSError error);

	// @interface FIRWriteBatch : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRWriteBatch")]
	interface WriteBatch
	{
		// -(FIRWriteBatch * _Nonnull)setData:(NSDictionary<NSString *,id> * _Nonnull)data forDocument:(FIRDocumentReference * _Nonnull)document;
		[Export ("setData:forDocument:")]
		WriteBatch SetData (NSDictionary<NSString, NSObject> nsData, DocumentReference document);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document)")]
		WriteBatch SetData (Dictionary<object, object> data, DocumentReference document);

		// -(FIRWriteBatch * _Nonnull)setData:(NSDictionary<NSString *,id> * _Nonnull)data forDocument:(FIRDocumentReference * _Nonnull)document merge:(BOOL)merge;
		[Export ("setData:forDocument:merge:")]
		WriteBatch SetData (NSDictionary<NSString, NSObject> nsData, DocumentReference document, bool merge);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document, merge)")]
		WriteBatch SetData (Dictionary<object, object> data, DocumentReference document, bool merge);

		// - (FIRWriteBatch *)setData:(NSDictionary<NSString *, id> *)data forDocument:(FIRDocumentReference*)document mergeFields:(NSArray<id>*)mergeFields
		[Advice ("The mergeFields argument can contain NSString and FieldPath.")]
		[Export ("setData:forDocument:mergeFields:")]
		WriteBatch SetData (NSDictionary<NSString, NSObject> nsData, DocumentReference document, NSArray mergeFields);

		[Wrap ("SetData (nsData, document, NSArray.FromStrings (mergeFields))")]
		WriteBatch SetData (NSDictionary<NSString, NSObject> nsData, DocumentReference document, string [] mergeFields);

		[Wrap ("SetData (nsData, document, NSArray.FromNSObjects (mergeFields))")]
		WriteBatch SetData (NSDictionary<NSString, NSObject> nsData, DocumentReference document, FieldPath [] mergeFields);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document, mergeFields)")]
		WriteBatch SetData (Dictionary<object, object> data, DocumentReference document, NSArray mergeFields);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document, NSArray.FromStrings (mergeFields))")]
		WriteBatch SetData (Dictionary<object, object> data, DocumentReference document, string [] mergeFields);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document, NSArray.FromNSObjects (mergeFields))")]
		WriteBatch SetData (Dictionary<object, object> data, DocumentReference document, FieldPath [] mergeFields);

		// -(FIRWriteBatch * _Nonnull)updateData:(NSDictionary<id,id> * _Nonnull)fields forDocument:(FIRDocumentReference * _Nonnull)document;
		[Export ("updateData:forDocument:")]
		WriteBatch UpdateData (NSDictionary<NSObject, NSObject> nsFields, DocumentReference document);

		[Wrap ("UpdateData (fields == null ? null : NSDictionary<NSObject, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (fields.Values), System.Linq.Enumerable.ToArray (fields.Keys), fields.Keys.Count), document)")]
		WriteBatch UpdateData (Dictionary<object, object> fields, DocumentReference document);

		// -(FIRWriteBatch * _Nonnull)deleteDocument:(FIRDocumentReference * _Nonnull)document;
		[Export ("deleteDocument:")]
		WriteBatch DeleteDocument (DocumentReference document);

		// -(void)commit;
		[Export ("commit")]
		void Commit ();

		// -(void)commitWithCompletion:(void (^ _Nonnull)(NSError * _Nullable))completion;
		[Async]
		[Export ("commitWithCompletion:")]
		void Commit ([NullAllowed] CommitCompletionHandler completion);
	}
}
