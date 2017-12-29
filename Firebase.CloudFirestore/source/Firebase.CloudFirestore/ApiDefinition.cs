using System;
using System.Collections.Generic;

using Foundation;
using ObjCRuntime;
using CoreFoundation;

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
		DocumentReference AddDocument (NSDictionary<NSString, NSObject> data);

		[Wrap ("AddDocument (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count))", true)]
		DocumentReference AddDocument (Dictionary<object, object> data);

		// -(FIRDocumentReference * _Nonnull)addDocumentWithData:(NSDictionary<NSString *,id> * _Nonnull)data completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Export ("addDocumentWithData:completion:")]
		DocumentReference AddDocument (NSDictionary<NSString, NSObject> data, AddDocumentCompletionHandler completion);

		[Wrap ("AddDocument (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), completion)", true)]
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
		DocumentSnapshot Document { get; }

		// @property (readonly, nonatomic) NSUInteger oldIndex;
		[Export ("oldIndex")]
		nuint OldIndex { get; }

		// @property (readonly, nonatomic) NSUInteger newIndex;
		[Export ("newIndex")]
		nuint NewIndex { get; }
	}

	// @interface FIRDocumentListenOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRDocumentListenOptions")]
	interface DocumentListenOptions
	{
		// +(instancetype _Nonnull)options;
		[Static]
		[Export ("options")]
		DocumentListenOptions Create ();

		// @property (readonly, assign, nonatomic) BOOL includeMetadataChanges;
		[Export ("includeMetadataChanges")]
		bool IncludeMetadataChanges { get; }

		// -(instancetype _Nonnull)includeMetadataChanges:(BOOL)includeMetadataChanges;
		[Export ("includeMetadataChanges:")]
		DocumentListenOptions SetIncludeMetadataChanges (bool includeMetadataChanges);
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
		void SetData (NSDictionary<NSString, NSObject> documentData);

		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count))", true)]
		void SetData (Dictionary<object, object> documentData);

		// -(void)setData:(NSDictionary<NSString *,id> * _Nonnull)documentData options:(FIRSetOptions * _Nonnull)options;
		[Export ("setData:options:")]
		void SetData (NSDictionary<NSString, NSObject> documentData, SetOptions options);

		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), options)", true)]
		void SetData (Dictionary<object, object> documentData, SetOptions options);

		// -(void)setData:(NSDictionary<NSString *,id> * _Nonnull)documentData completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Async]
		[Export ("setData:completion:")]
		void SetData (NSDictionary<NSString, NSObject> documentData, [NullAllowed] DocumentActionCompletionHandler completion);

		[Async]
		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), completion)", true)]
		void SetData (Dictionary<object, object> documentData, [NullAllowed] DocumentActionCompletionHandler completion);

		// -(void)setData:(NSDictionary<NSString *,id> * _Nonnull)documentData options:(FIRSetOptions * _Nonnull)options completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Async]
		[Export ("setData:options:completion:")]
		void SetData (NSDictionary<NSString, NSObject> documentData, SetOptions options, [NullAllowed] DocumentActionCompletionHandler completion);

		[Async]
		[Wrap ("SetData (documentData == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (documentData.Values), System.Linq.Enumerable.ToArray (documentData.Keys), documentData.Keys.Count), options, completion)")]
		void SetData (Dictionary<object, object> documentData, SetOptions options, [NullAllowed] DocumentActionCompletionHandler completion);

		// -(void)updateData:(NSDictionary<id,id> * _Nonnull)fields;
		[Export ("updateData:")]
		void UpdateData (NSDictionary<NSObject, NSObject> fields);

		[Wrap ("UpdateData (fields == null ? null : NSDictionary<NSObject, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (fields.Values), System.Linq.Enumerable.ToArray (fields.Keys), fields.Keys.Count))", true)]
		void UpdateData (Dictionary<object, object> fields);

		// -(void)updateData:(NSDictionary<id,id> * _Nonnull)fields completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Async]
		[Export ("updateData:completion:")]
		void UpdateData (NSDictionary<NSObject, NSObject> fields, [NullAllowed] DocumentActionCompletionHandler completion);

		[Async]
		[Wrap ("UpdateData (fields == null ? null : NSDictionary<NSObject, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (fields.Values), System.Linq.Enumerable.ToArray (fields.Keys), fields.Keys.Count), completion)", true)]
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

		// -(id<FIRListenerRegistration> _Nonnull)addSnapshotListener:(FIRDocumentSnapshotBlock _Nonnull)listener;
		[Export ("addSnapshotListener:")]
		IListenerRegistration AddSnapshotListener (DocumentSnapshotHandler listener);

		// -(id<FIRListenerRegistration> _Nonnull)addSnapshotListenerWithOptions:(FIRDocumentListenOptions * _Nullable)options listener:(FIRDocumentSnapshotBlock _Nonnull)listener;
		[Export ("addSnapshotListenerWithOptions:listener:")]
		IListenerRegistration AddSnapshotListener ([NullAllowed] DocumentListenOptions options, DocumentSnapshotHandler listener);
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

		// -(id _Nullable)objectForKeyedSubscript:(id _Nonnull)key;
		[return: NullAllowed]
		[Export ("objectForKeyedSubscript:")]
		NSObject GetObject (NSObject key);
	}

	// @interface FIRFieldPath : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRFieldPath")]
	interface FieldPath : INSCopying
	{
		// -(instancetype _Nonnull)initWithFields:(NSArray<NSString *> * _Nonnull)fieldNames;
		[Export ("initWithFields:")]
		IntPtr Constructor (string [] fieldNames);

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
	}

	// id _Nullable (^)(FIRTransaction *, NSError **)
	//delegate NSObject UpdateHandler (Transaction transaction, out NSError error);

	// id  _Nullable (^ _Nonnull)(FIRTransaction * _Nonnull, NSError * _Nullable * _Nullable)
	delegate NSObject TransactionUpdateHandler (Transaction transaction, IntPtr error);

	// void (^)(id _Nullable result, NSError *_Nullable error)
	delegate void TransactionCompletionHandler ([NullAllowed] NSObject result, [NullAllowed] NSError error);

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

		// -(void)runTransactionWithBlock:(id  _Nullable (^ _Nonnull)(FIRTransaction * _Nonnull, NSError * _Nullable * _Nullable))updateBlock completion:(void (^ _Nonnull)(id _Nullable, NSError * _Nullable))completion;
		[Internal]
		[Export ("runTransactionWithBlock:completion:")]
		void _RunTransaction (TransactionUpdateHandler updateHandler, TransactionCompletionHandler completion);

		// -(FIRWriteBatch * _Nonnull)batch;
		[Export ("batch")]
		WriteBatch CreateBatch ();

		// +(void)enableLogging:(BOOL)logging __attribute__((deprecated("Use FIRSetLoggerLevel(FIRLoggerLevelDebug) to enable logging")));
		[Obsolete ("Use -FIRDebugEnabled and -FIRDebugDisabled flags or use Firebase.Core.Configure.SetLoggerLevel method.")]
		[Static]
		[Export ("enableLogging:")]
		void EnableLogging (bool logging);
	}

	// @interface FIRFirestoreSettings : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "FIRFirestoreSettings")]
	interface FirestoreSettings : INSCopying
	{
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
	}

	// @interface FIRGeoPoint : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRGeoPoint")]
	interface GeoPoint : INSCopying
	{
		// -(instancetype _Nonnull)initWithLatitude:(double)latitude longitude:(double)longitude __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithLatitude:longitude:")]
		IntPtr Constructor (double latitude, double longitude);

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

	// @interface FIRQueryListenOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRQueryListenOptions")]
	interface QueryListenOptions
	{
		// +(instancetype _Nonnull)options;
		[Static]
		[Export ("options")]
		QueryListenOptions Create ();

		// @property (readonly, assign, nonatomic) BOOL includeQueryMetadataChanges;
		[Export ("includeQueryMetadataChanges")]
		bool IncludeQueryMetadataChanges { get; }

		// -(instancetype _Nonnull)includeQueryMetadataChanges:(BOOL)includeQueryMetadataChanges;
		[Export ("includeQueryMetadataChanges:")]
		QueryListenOptions SetIncludeQueryMetadataChanges (bool includeQueryMetadataChanges);

		// @property (readonly, assign, nonatomic) BOOL includeDocumentMetadataChanges;
		[Export ("includeDocumentMetadataChanges")]
		bool IncludeDocumentMetadataChanges { get; }

		// -(instancetype _Nonnull)includeDocumentMetadataChanges:(BOOL)includeDocumentMetadataChanges;
		[Export ("includeDocumentMetadataChanges:")]
		QueryListenOptions SetIncludeDocumentMetadataChanges (bool includeDocumentMetadataChanges);
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

		// -(id<FIRListenerRegistration> _Nonnull)addSnapshotListener:(FIRQuerySnapshotBlock _Nonnull)listener;
		[Export ("addSnapshotListener:")]
		IListenerRegistration AddSnapshotListener (QuerySnapshotHandler listener);

		// -(id<FIRListenerRegistration> _Nonnull)addSnapshotListenerWithOptions:(FIRQueryListenOptions * _Nullable)options listener:(FIRQuerySnapshotBlock _Nonnull)listener;
		[Export ("addSnapshotListenerWithOptions:listener:")]
		IListenerRegistration AddSnapshotListener ([NullAllowed] QueryListenOptions options, QuerySnapshotHandler listener);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field isEqualTo:(id _Nonnull)value;
		[Export ("queryWhereField:isEqualTo:")]
		Query WhereEqualsTo (string field, NSObject value);

		[Wrap ("WhereEqualsTo (field, FromObject (value))", true)]
		Query WhereEqualsTo (string field, object value);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path isEqualTo:(id _Nonnull)value;
		[Export ("queryWhereFieldPath:isEqualTo:")]
		Query WhereEqualsTo (FieldPath path, NSObject value);

		[Wrap ("WhereEqualsTo (path, FromObject (value))", true)]
		Query WhereEqualsTo (FieldPath path, object value);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field isLessThan:(id _Nonnull)value;
		[Export ("queryWhereField:isLessThan:")]
		Query WhereLessThan (string field, NSObject value);

		[Wrap ("WhereLessThan (field, FromObject (value))", true)]
		Query WhereLessThan (string field, object value);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path isLessThan:(id _Nonnull)value;
		[Export ("queryWhereFieldPath:isLessThan:")]
		Query WhereLessThan (FieldPath path, NSObject value);

		[Wrap ("WhereLessThan (path, FromObject (value))", true)]
		Query WhereLessThan (FieldPath path, object value);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field isLessThanOrEqualTo:(id _Nonnull)value;
		[Export ("queryWhereField:isLessThanOrEqualTo:")]
		Query WhereLessThanOrEqualsTo (string field, NSObject value);

		[Wrap ("WhereLessThanOrEqualsTo (field, FromObject (value))", true)]
		Query WhereLessThanOrEqualsTo (string field, object value);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path isLessThanOrEqualTo:(id _Nonnull)value;
		[Export ("queryWhereFieldPath:isLessThanOrEqualTo:")]
		Query WhereLessThanOrEqualsTo (FieldPath path, NSObject value);

		[Wrap ("WhereLessThanOrEqualsTo (path, FromObject (value))", true)]
		Query WhereLessThanOrEqualsTo (FieldPath path, object value);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field isGreaterThan:(id _Nonnull)value;
		[Export ("queryWhereField:isGreaterThan:")]
		Query WhereGreaterThan (string field, NSObject value);

		[Wrap ("WhereGreaterThan (field, FromObject (value))", true)]
		Query WhereGreaterThan (string field, object value);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path isGreaterThan:(id _Nonnull)value;
		[Export ("queryWhereFieldPath:isGreaterThan:")]
		Query WhereGreaterThan (FieldPath path, NSObject value);

		[Wrap ("WhereGreaterThan (path, FromObject (value))", true)]
		Query WhereGreaterThan (FieldPath path, object value);

		// -(FIRQuery * _Nonnull)queryWhereField:(NSString * _Nonnull)field isGreaterThanOrEqualTo:(id _Nonnull)value;
		[Export ("queryWhereField:isGreaterThanOrEqualTo:")]
		Query WhereGreaterThanOrEqualsTo (string field, NSObject value);

		[Wrap ("WhereGreaterThanOrEqualsTo (field, FromObject (value))", true)]
		Query WhereGreaterThanOrEqualsTo (string field, object value);

		// -(FIRQuery * _Nonnull)queryWhereFieldPath:(FIRFieldPath * _Nonnull)path isGreaterThanOrEqualTo:(id _Nonnull)value;
		[Export ("queryWhereFieldPath:isGreaterThanOrEqualTo:")]
		Query WhereGreaterThanOrEqualsTo (FieldPath path, NSObject value);

		[Wrap ("WhereGreaterThanOrEqualsTo (path, FromObject (value))", true)]
		Query WhereGreaterThanOrEqualsTo (FieldPath path, object value);

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

		// -(FIRQuery * _Nonnull)queryStartingAtDocument:(FIRDocumentSnapshot * _Nonnull)document;
		[Export ("queryStartingAtDocument:")]
		Query StartingAt (DocumentSnapshot document);

		// -(FIRQuery * _Nonnull)queryStartingAtValues:(NSArray * _Nonnull)fieldValues;
		[Export ("queryStartingAtValues:")]
		Query StartingAt (NSObject [] fieldValues);

		[Wrap ("StartingAt (CloudFirestoreHelper.GetNSObjects (fieldValues))")]
		Query StartingAt (object [] fieldValues);

		// -(FIRQuery * _Nonnull)queryStartingAfterDocument:(FIRDocumentSnapshot * _Nonnull)document;
		[Export ("queryStartingAfterDocument:")]
		Query StartingAfter (DocumentSnapshot document);

		// -(FIRQuery * _Nonnull)queryStartingAfterValues:(NSArray * _Nonnull)fieldValues;
		[Export ("queryStartingAfterValues:")]
		Query StartingAfter (NSObject [] fieldValues);

		[Wrap ("StartingAfter (CloudFirestoreHelper.GetNSObjects (fieldValues))")]
		Query StartingAfter (object [] fieldValues);

		// -(FIRQuery * _Nonnull)queryEndingBeforeDocument:(FIRDocumentSnapshot * _Nonnull)document;
		[Export ("queryEndingBeforeDocument:")]
		Query EndingBefore (DocumentSnapshot document);

		// -(FIRQuery * _Nonnull)queryEndingBeforeValues:(NSArray * _Nonnull)fieldValues;
		[Export ("queryEndingBeforeValues:")]
		Query EndingBefore (NSObject [] fieldValues);

		[Wrap ("EndingBefore (CloudFirestoreHelper.GetNSObjects (fieldValues))")]
		Query EndingBefore (object [] fieldValues);

		// -(FIRQuery * _Nonnull)queryEndingAtDocument:(FIRDocumentSnapshot * _Nonnull)document;
		[Export ("queryEndingAtDocument:")]
		Query EndingAt (DocumentSnapshot document);

		// -(FIRQuery * _Nonnull)queryEndingAtValues:(NSArray * _Nonnull)fieldValues;
		[Export ("queryEndingAtValues:")]
		Query EndingAt (NSObject [] fieldValues);

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
		DocumentSnapshot [] Documents { get; }

		// @property (readonly, nonatomic, strong) NSArray<FIRDocumentChange *> * _Nonnull documentChanges;
		[Export ("documentChanges", ArgumentSemantic.Strong)]
		DocumentChange [] DocumentChanges { get; }
	}

	// @interface FIRSetOptions : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRSetOptions")]
	interface SetOptions
	{
		// +(instancetype _Nonnull)merge;
		[Static]
		[Export ("merge")]
		SetOptions Merge { get; }

		// @property (readonly, getter = isMerge, nonatomic) BOOL merge;
		[Export ("isMerge")]
		bool IsMerge { get; }
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

	// @interface FIRTransaction : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRTransaction")]
	interface Transaction
	{
		// -(FIRTransaction * _Nonnull)setData:(NSDictionary<NSString *,id> * _Nonnull)data forDocument:(FIRDocumentReference * _Nonnull)document;
		[Export ("setData:forDocument:")]
		Transaction SetData (NSDictionary<NSString, NSObject> data, DocumentReference document);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document)", true)]
		Transaction SetData (Dictionary<object, object> data, DocumentReference document);

		// -(FIRTransaction * _Nonnull)setData:(NSDictionary<NSString *,id> * _Nonnull)data forDocument:(FIRDocumentReference * _Nonnull)document options:(FIRSetOptions * _Nonnull)options;
		[Export ("setData:forDocument:options:")]
		Transaction SetData (NSDictionary<NSString, NSObject> data, DocumentReference document, SetOptions options);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document, options)", true)]
		Transaction SetData (Dictionary<object, object> data, DocumentReference document, SetOptions options);

		// -(FIRTransaction * _Nonnull)updateData:(NSDictionary<id,id> * _Nonnull)fields forDocument:(FIRDocumentReference * _Nonnull)document;
		[Export ("updateData:forDocument:")]
		Transaction UpdateData (NSDictionary<NSObject, NSObject> fields, DocumentReference document);

		[Wrap ("UpdateData (fields == null ? null : NSDictionary<NSObject, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (fields.Values), System.Linq.Enumerable.ToArray (fields.Keys), fields.Keys.Count), document)", true)]
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
		WriteBatch SetData (NSDictionary<NSString, NSObject> data, DocumentReference document);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document)", true)]
		WriteBatch SetData (Dictionary<object, object> data, DocumentReference document);

		// -(FIRWriteBatch * _Nonnull)setData:(NSDictionary<NSString *,id> * _Nonnull)data forDocument:(FIRDocumentReference * _Nonnull)document options:(FIRSetOptions * _Nonnull)options;
		[Export ("setData:forDocument:options:")]
		WriteBatch SetData (NSDictionary<NSString, NSObject> data, DocumentReference document, SetOptions options);

		[Wrap ("SetData (data == null ? null : NSDictionary<NSString, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (data.Values), System.Linq.Enumerable.ToArray (data.Keys), data.Keys.Count), document, options)", true)]
		WriteBatch SetData (Dictionary<object, object> data, DocumentReference document, SetOptions options);

		// -(FIRWriteBatch * _Nonnull)updateData:(NSDictionary<id,id> * _Nonnull)fields forDocument:(FIRDocumentReference * _Nonnull)document;
		[Export ("updateData:forDocument:")]
		WriteBatch UpdateData (NSDictionary<NSObject, NSObject> fields, DocumentReference document);

		[Wrap ("UpdateData (fields == null ? null : NSDictionary<NSObject, NSObject>.FromObjectsAndKeys (System.Linq.Enumerable.ToArray (fields.Values), System.Linq.Enumerable.ToArray (fields.Keys), fields.Keys.Count), document)", true)]
		WriteBatch UpdateData (Dictionary<object, object> fields, DocumentReference document);

		// -(FIRWriteBatch * _Nonnull)deleteDocument:(FIRDocumentReference * _Nonnull)document;
		[Export ("deleteDocument:")]
		WriteBatch DeleteDocument (DocumentReference document);

		// -(void)commitWithCompletion:(void (^ _Nonnull)(NSError * _Nullable))completion;
		[Async]
		[Export ("commitWithCompletion:")]
		void Commit (CommitCompletionHandler completion);
	}
}
