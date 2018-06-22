# Firebase Cloud Firestore on iOS

## Table of content

- [Firebase Cloud Firestore on iOS](#firebase-cloud-firestore-on-ios)
	- [Table of content](#table-of-content)
	- [Create a Cloud Firestore project](#create-a-cloud-firestore-project)
	- [Add Firebase to your app](#add-firebase-to-your-app)
	- [Configure Remote Config in your app](#configure-remote-config-in-your-app)
- [Add and Manage Data](#add-and-manage-data)
	- [Cloud Firestore Data Model](#cloud-firestore-data-model)
		- [Documents](#documents)
		- [Collections](#collections)
		- [References](#references)
		- [Hierarchical Data](#hierarchical-data)
			- [Subcollections](#subcollections)
	- [Choose a Data Structure](#choose-a-data-structure)
	- [Supported Data Types](#supported-data-types)
	- [Add Data to Cloud Firestore](#add-data-to-cloud-firestore)
		- [Set a document](#set-a-document)
			- [Data types](#data-types)
		- [Add a document](#add-a-document)
		- [Update a document](#update-a-document)
			- [Update fields in nested objects](#update-fields-in-nested-objects)
	- [Transactions and Batched Writes](#transactions-and-batched-writes)
		- [Updating data with transactions](#updating-data-with-transactions)
			- [Passing information out of transactions](#passing-information-out-of-transactions)
			- [Transaction failure](#transaction-failure)
		- [Batched writes](#batched-writes)
	- [Delete Data from Cloud Firestore](#delete-data-from-cloud-firestore)
		- [Delete fields](#delete-fields)
		- [Delete collections](#delete-collections)
		- [Delete data with the Firebase CLI](#delete-data-with-the-firebase-cli)
	- [Manage Cloud Firestore with the Firebase Console](#manage-cloud-firestore-with-the-firebase-console)
- [Query Data](#query-data)
	- [Get Data with Cloud Firestore](#get-data-with-cloud-firestore)
		- [Example data](#example-data)
		- [Get a document](#get-a-document)
		- [Get multiple documents from a collection](#get-multiple-documents-from-a-collection)
			- [Get all documents in a collection](#get-all-documents-in-a-collection)
	- [Get Realtime Updates with Cloud Firestore](#get-realtime-updates-with-cloud-firestore)
			- [Events for local changes](#events-for-local-changes)
		- [Listen to multiple documents in a collection](#listen-to-multiple-documents-in-a-collection)
			- [View changes between snapshots](#view-changes-between-snapshots)
			- [Detach a listener](#detach-a-listener)
			- [Handle listen errors](#handle-listen-errors)
	- [Perform Simple and Compound Queries in Cloud Firestore](#perform-simple-and-compound-queries-in-cloud-firestore)
		- [Example data](#example-data)
		- [Simple queries](#simple-queries)
		- [Compound queries](#compound-queries)
	- [Order and Limit Data with Cloud Firestore](#order-and-limit-data-with-cloud-firestore)
		- [Order and limit data](#order-and-limit-data)
	- [Paginate Data with Query Cursors](#paginate-data-with-query-cursors)
		- [Add a simple cursor to a query](#add-a-simple-cursor-to-a-query)
		- [Use a document snapshot to define the query cursor](#use-a-document-snapshot-to-define-the-query-cursor)
		- [Paginate a query](#paginate-a-query)
		- [Set multiple cursor conditions](#set-multiple-cursor-conditions)
				- [Cities](#cities)
	- [Manage Indexes in Cloud Firestore](#manage-indexes-in-cloud-firestore)
- [Secure Data](#secure-data)
	- [Secure Data in Cloud Firestore](#secure-data-in-cloud-firestore)
- [Enable Offline Data](#enable-offline-data)
		- [Configure offline persistence](#configure-offline-persistence)
		- [Listen to offline data](#listen-to-offline-data)
		- [Get offline data](#get-offline-data)
		- [Query offline data](#query-offline-data)
	- [Known issues](#known-issues)

## Create a Cloud Firestore project

* Open the [Firebase Console][1] and create a new project.
* In the *Database* section, click on **Realtime Database** combobox and then **Try Firestore Beta**.
* Click Enable.

> ![note_icon] _**Note:**_ _Cloud Firestore and App Engine: You can't use both Cloud Firestore and Cloud Datastore in the same project, which might affect apps using App Engine. Try using Cloud Firestore with a different project._

When you create a Cloud Firestore project, it also enables the API in the [Cloud API Manager][].

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

## Configure Remote Config in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` namespace):

```csharp
App.Configure ();
```

---

# Add and Manage Data

## Cloud Firestore Data Model

Cloud Firestore is a NoSQL, document-oriented database. Unlike a SQL database, there are no tables or rows. Instead, you store data in documents, which are organized into collections.

Each document contains a set of key-value pairs. Cloud Firestore is optimized for storing large collections of small documents.

All documents must be stored in collections. Documents can contain subcollections and nested objects, both of which can include primitive fields like strings or complex objects like lists.

Collections and documents are created implicitly in Cloud Firestore. Simply assign data to a document within a collection. If either the collection or document does not exist, Cloud Firestore creates it.

### Documents

In Cloud Firestore, the unit of storage is the document. A document is a lightweight record that contains fields, which map to values. Each document is identified by a name.

A document representing a user `alovelace` might look like this:

![document_icon] **alovelace**
* **first** : "Ada"
* **last** : Lovelace
* **born** : 1815

> ![note_icon] _**Note:**_ _Cloud Firestore supports a variety of data types for values: boolean, number, string, geo point, binary blob, and timestamp. You can also use arrays or nested objects, called maps, to structure data within a document._

Complex, nested objects in a document are called maps. For example, you could structure the user's name from the example above with a map, like this:

![document_icon] **alovelace**
* **name**:
	* **first** : "Ada"
	* **last** : Lovelace
* **born** : 1815

You may notice that documents look a lot like JSON. In fact, they basically are. There are some differences (for example, documents support extra data types and are limited in size to 1 MB), but in general, you can treat documents as lightweight JSON records.

### Collections

Documents live in collections, which are simply containers for documents. For example, you could have a users collection to contain your various users, each represented by a document:

![collections_icon] **users**
* ![document_icon] **alovelace**
	* **first** : "Ada"
	* **last** : "Lovelace"
	* **born** : 1815
* ![document_icon] **aturing**
	* **first** : "Alan"
	* **last** : "Turing"
	* **born** : 1912

Cloud Firestore is schemaless, so you have complete freedom over what fields you put in each document and what data types you store in those fields. Documents within the same collection can all contain different fields or store different types of data in those fields. However, it's a good idea to use the same fields and data types across multiple documents, so that you can query the documents more easily.

A collection contains documents and nothing else. It can't directly contain raw fields with values, and it can't contain other collections. (See [Hierarchical Data](#hierarchical-data) for an explanation of how to structure more complex data in Cloud Firestore.)

The names of documents within a collection are unique. You can provide your own keys, such as user IDs, or you can let Cloud Firestore create random IDs for you automatically (for example, by calling `Add` method).

You do not need to "create" or "delete" collections. After you create the first document in a collection, the collection exists. If you delete all of the documents in a collection, it no longer exists.

### References

Every document in Cloud Firestore is uniquely identified by its location within the database. The previous example showed a document `alovelace` within the collection `users`. To refer to this location in your code, you can create a _reference_ to it:

```csharp
var alovelaceDocument = db.GetCollection ("users").GetDocument ("alovelace");
```

A reference is a lightweight object that just points to a location in your database. You can create a reference whether or not data exists there, and creating a reference does not perform any network operations.

You can also create references to collections:

```csharp
var userCollection = db.GetCollection ("users");
```

> ![note_icon] _**Note:**_ _Collection references and document references are two distinct types of references and let you perform different operations. For example, you could use a collection reference for querying the documents in the collection, and you could use a document reference to read or write an individual document._

For convenience, you can also create references by specifying the path to a document or collection as a string, with path components separated by a forward slash (/). For example, to create a reference to the `alovelace` document:

```csharp
var alovelaceDocument = db.GetDocument ("users/alovelace");
```

### Hierarchical Data

To understand how hierarchical data structures work in Cloud Firestore, consider an example chat app with messages and chat rooms.

You can create a collection called `rooms` to store different chat rooms:

![collections_icon] **rooms**
* ![document_icon] **roomA**
	* **name** : "my chat room"
* ![document_icon] **roomB**
	* ...

Now that you have chat rooms, decide how to store your messages. You might not want to store them in the chat room's document. Documents in Cloud Firestore should be lightweight, and a chat room could contain a large number of messages. However, you can create additional collections within your chat room's document, as subcollections.

#### Subcollections

The best way to store messages in this scenario is by using subcollections. A subcollection is a collection associated with a specific document.

> ![note_icon] _**Note:**_ _Querying across subcollections is not currently supported in Cloud Firestore. If you need to query data across collections, use root-level collections._

You can create a subcollection called `messages` for every room document in your `rooms` collection:

![collections_icon] **rooms**
* ![document_icon] **roomA**
	* **name** : "my chat room"
	* ![collections_icon] **messages**
		* ![document_icon] **message1**
			* **from** : "alex"
			* **msg** : "Hello World!"
		* ![document_icon] **message2**
			* ...
* ![document_icon] **roomB**
	* ...

In this example, you would create a reference to a message in the subcollection with the following code:

```csharp
var message = db.GetCollection ("rooms").GetDocument ("roomA")
		.GetCollection ("messages").GetDocument ("message1");
```

Notice the alternating pattern of collections and documents. Your collections and documents must always follow this pattern. You cannot reference a collection in a collection or a document in a document.

Subcollections allow you to structure data hierarchically, making data easier to access. To get all messages in `roomA`, you can simply access the `db.GetCollection ("rooms").GetDocument ("roomA").GetCollection ("messages");` collection.

Documents in subcollections can contain subcollections as well, allowing you to further nest data. You can nest data up to 100 levels deep.

> ![warning_icon] _**Warning:**_ _Deleting a document does not delete its subcollections!_
>
> _When you delete a document that has associated subcollections, the subcollections are not deleted. They are still accessible by reference. For example, there may be a document referenced by `db.GetCollection ("coll").GetDocument ("doc").GetCollection ("subcoll").GetDocument ("subdoc")` even though the document referenced by `db.GetCollection ("coll").GetDocument ("doc")` no longer exists. If you want to delete documents in subcollections when deleting a document, you must do so manually, as shown in [Delete Collections](#delete_collections)._

## Choose a Data Structure

Remember, when you structure your data in Cloud Firestore, you have a few different options: documents, multiple collections, and subcollections within documents. Read this [documentation][3] to learn more about this. Consider the advantages of each option as they relate to your use case.

## Supported Data Types

This [page][4] describes the data types that Cloud Firestore supports.

## Add Data to Cloud Firestore

There are several ways to write data to Cloud Firestore:

* Set the data of a document within a collection, explicitly specifying a document identifier.
* Add a new document to a collection. In this case, Cloud Firestore automatically generates the document identifier.
* Create an empty document with an automatically generated identifier, and assign data to it later.

This guide explains how to use the set, add, or update individual documents in Cloud Firestore. If you want to write data in bulk, see [Transactions and Batched Writes](#transactions-and-batched-writes).

### Set a document

To create or overwrite a single document, use the `SetData` method:

```csharp
var docData = new Dictionary<object, object> {
	{ "name", "Los Angeles" },
	{ "state", "CA" },
	{ "country", "USA" }
};

// Add a new document in collection "cities"
db.GetCollection ("cities").GetDocument ("LA").SetData (docData, HandleDocumentActionCompletion);

void HandleDocumentActionCompletion (NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error writing document: {error.LocalizedDescription}");
		return;
	}

	System.Console.WriteLine ("Document successfully written!");
}
```

Also, you can use `SetDataAsync` method for `await/async` lovers:

```csharp
var docData = new Dictionary<object, object> {
	{ "name", "Los Angeles" },
	{ "state", "CA" },
	{ "country", "USA" }
};

// Add a new document in collection "cities"
try {
	await db.GetCollection ("cities").GetDocument ("LA").SetDataAsync (docData);
	System.Console.WriteLine ("Document successfully written!");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error writing document: {ex.Error.LocalizedDescription}");
}
```

If the document does not exist, it will be created. If the document does exist, its contents will be overwritten with the newly provided data, unless you specify that the data should be merged into the existing document, as follows:

```csharp
var docData = new Dictionary<object, object> {
	{ "name", "Los Angeles" },
	{ "state", "CA" },
	{ "country", "USA" }
};

// Add a new document in collection "cities"
db.GetCollection ("cities").GetDocument ("LA").SetData (docData, SetOptions.CreateMerge ());
```

If you're not sure whether the document exists, pass the option to merge the new data with any existing document to avoid overwriting entire documents.

#### Data types

Cloud Firestore lets you write a variety of data types inside a document, including strings, booleans, numbers, dates, null, and nested arrays and objects. Cloud Firestore always stores numbers as doubles, regardless of what type of number you use in your code:

```csharp
var docData = new Dictionary<object, object> {
	{ "stringExample", "Hello world!" },
	{ "booleanExample", true },
	{ "numberExample", 3.14 },
	{ "dateExample", new NSDate () },
	{ "arrayExample", NSArray.FromObjects (true, 3, "hello") },
	{ "nullExample", null },
	{ "objectExample", NSDictionary.FromObjectsAndKeys (
		keys: new object [] { "a", "b" },
		objects: new object [] { 5, NSDictionary.FromObjectsAndKeys (
			keys: new object [] { "nested" },
			objects: new object [] { "foo" }
		) }
	) }
};

db.GetCollection ("data").GetDocument ("one").SetData (docData, HandleDocumentActionCompletion);

void HandleDocumentActionCompletion (NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error writing document: {error.LocalizedDescription}");
		return;
	}

	System.Console.WriteLine ("Document successfully written!");
}

// Async/await way
try {
	await db.GetCollection ("data").GetDocument ("one").SetDataAsync (docData);
	System.Console.WriteLine ("Document successfully written!");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error writing document: {ex.Error.LocalizedDescription}");
}
```

> ![note_icon] _**Important:**_ _To create nested objects, you cannot use nested Dictionaries, doing so will throw an exception. To create nested object, you need to use NSDictionaries as shown above._

### Add a document

When you use `SetData` method to create a document, you must specify an ID for the document to create. For example:

```csharp
db.GetCollection ("cities").GetDocument ("new_city_id").SetData (data);
```

But sometimes there isn't a meaningful ID for the document, and it's more convenient to let Cloud Firestore auto-generate an ID for you. You can do this by calling `AddDocument` method:

```csharp
var docData = new Dictionary<object, object> {
	{ "name", "Tokyo" },
	{ "country", "Japan" }
};

DocumentReference newDocument = null;
newDocument = db.GetCollection ("cities").AddDocument (docData, HandleAddDocumentCompletion);

void HandleAddDocumentCompletion (NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error adding document: {error.LocalizedDescription}");
		return;
	}

	System.Console.WriteLine ($"Document added with ID: {newDocument.Id}");
}
```

> ![note_icon] **_Important:_** _Unlike "push IDs" in the Firebase Realtime Database, Cloud Firestore auto-generated IDs do not provide any automatic ordering. If you want to be able to order your documents by creation date, you should store a timestamp as a field in the documents._

In some cases, it can be useful to create a document reference with an auto-generated ID, then use the reference later. For this use case, you can call `CreateDocument` method:

```csharp
var newCityDocument = db.GetCollection ("cities").CreateDocument ();
// later
newCityDocument.SetData ...
```

Behind the scenes, `AddDocument (...)` and `.CreateDocument ().SetData (...)` are completely equivalent, so you can use whichever is more convenient.

### Update a document

To update some fields of a document without overwriting the entire document, use the `UpdateData` method:

```csharp
var docData = new Dictionary<object, object> { { "capital", true } };
var washingtonDocument = db.GetCollection ("cities").GetDocument ("DC");

// Set the "capital" field of the city 'DC'
washingtonDocument.UpdateData (docData, HandleDocumentActionCompletion);

void HandleDocumentActionCompletion (NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error updating document: {error.LocalizedDescription}");
		return;
	}

	System.Console.WriteLine ("Document successfully updated");
}
```

An `async/await` version of this:

```csharp
var docData = new Dictionary<object, object> { { "capital", true } };
var washingtonDocument = db.GetCollection ("cities").GetDocument ("DC");

// Set the "capital" field of the city 'DC'
try {
	await washingtonDocument.UpdateDataAsync (docData);
	System.Console.WriteLine ("Document successfully updated");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error updating document: {ex.Error.LocalizedDescription}");
}
```

#### Update fields in nested objects

If your document contains nested objects, you can use "dot notation" to reference nested fields within the document when you call `UpdateData` method:

```csharp
var frankData = new Dictionary<object, object> {
	{ "name", "Frank" },
	{ "favorites", NSDictionary.FromObjectsAndKeys (
		keys: new object [] { "food", "color", "subject" },
		objects: new object [] { "Pizza", "Blue", "recess" }
	) },
	{ "age", 12 }
};
var frankDocument = db.GetCollection ("users").GetDocument ("frank");
frankDocument.SetData (frankData);

// To update age and favorite color:
var updateData = new Dictionary<object, object> {
	{ "age", 13 },
	{ "favorites.color", "Red" }
};
db.GetCollection ("users").GetDocument ("frank").UpdateData (updateData, HandleDocumentActionCompletion);

void HandleDocumentActionCompletion (NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error updating document: {error.LocalizedDescription}");
		return;
	}

	System.Console.WriteLine ("Document successfully updated");
}

// Async/await way
try {
	await db.GetCollection ("users").GetDocument ("frank").UpdateDataAsync (updateData);
	System.Console.WriteLine ("Document successfully updated");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error updating document: {ex.Error.LocalizedDescription}");
}
```

You can also add server timestamps to specific fields in your documents, to track when an update was received by the server:

```csharp
var updateData = new Dictionary<object, object> { { "lastUpdated", FieldValue.ServerTimestamp } };
db.GetCollection ("objects").GetDocument ("some-id").UpdateData (updateData, HandleDocumentActionCompletion);

void HandleDocumentActionCompletion (NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error updating document: {error.LocalizedDescription}");
		return;
	}

	System.Console.WriteLine ("Document successfully updated");
}

// Async/await way
try {
	await db.GetCollection ("objects").GetDocument ("some-id").UpdateDataAsync (updateData);
	System.Console.WriteLine ("Document successfully updated");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error updating document: {ex.Error.LocalizedDescription}");
}
```

## Transactions and Batched Writes

Firebase Cloud Firestore supports atomic operations for reading and writing data. In a set of atomic operations, either all of the operations succeed, or none of them are applied. There are two types of atomic operations in Firebase Cloud Firestore:

* **Transactions:** a transaction is a set of read and write operations on one or more documents.
* **Batched Writes:** a batched write is a set of up to 500 write operations on one or more documents.

### Updating data with transactions

Using the Firebase Cloud Firestore client libraries, you can group multiple operations into a single transaction. Transactions are useful when you want to update a field's value based on its current value, or the value of some other field. You could increment a counter by creating a transaction that reads the current value of the counter, increments it, and writes the new value to Cloud Firestore.

A transaction consists of any number of `GetDocument` operations followed by any number of write operations such as `SetData`, `UpdateData`, or `DeleteData`. In the case of a concurrent edit, Firebase Cloud Firestore runs the entire transaction again. For example, if a transaction reads documents and another client modifies any of those documents, Cloud Firestore retries the transaction. This feature ensures that the transaction runs on up-to-date and consistent data.

Transactions never partially apply writes. All writes execute at the end of a successful transaction.

When using transactions, note that:

* Read operations must come before write operations.
* A function calling a transaction (transaction function) might run more than once if a concurrent edit affects a document that the transaction reads.
* Transaction functions should not directly modify application state.
* Transactions will fail when the client is offline.

The following example shows how to create and run a transaction:

```csharp
var sf = db.GetCollection ("cities").GetDocument ("SF");
db.RunTransaction (HandleTransactionUpdate, HandleTransactionCompletion);

NSObject HandleTransactionUpdate (Transaction transaction, out NSError error)
{
	DocumentSnapshot sfDocument = transaction.GetDocument (sf, out error);

	if (error != null)
		return null;

	if (!(sfDocument.Data? ["population"] is NSNumber)) {
		error = new NSError (new NSString ("AppErrorDomain"),
					-1,
					NSDictionary.FromObjectAndKey (new NSString ("Unable to retrieve population from snapshot"), NSError.LocalizedDescriptionKey));
		return null;
	}

	var oldPopulation = (sfDocument.Data ["population"] as NSNumber).Int32Value;

	var updateData = new Dictionary<object, object> { { "population", oldPopulation + 1 } };
	transaction.UpdateData (updateData, sf);

	return null;
}

void HandleTransactionCompletion (NSObject result, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Transaction failed: {error.LocalizedDescription}");
		return;
	}

	System.Console.WriteLine ("Transaction successfully committed!");
}
```

An `async/await` version:

```csharp
var sf = db.GetCollection ("cities").GetDocument ("SF");

try {
	await db.RunTransactionAsync (HandleTransactionUpdate);
	System.Console.WriteLine ("Transaction successfully committed!");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error updating document: {ex.Error.LocalizedDescription}");
}

NSObject HandleTransactionUpdate (Transaction transaction, out NSError error)
{
	DocumentSnapshot sfDocument = transaction.GetDocument (sf, out error);

	if (error != null)
		return null;

	if (!(sfDocument.Data? ["population"] is NSNumber)) {
		error = new NSError (new NSString ("AppErrorDomain"),
					-1,
					NSDictionary.FromObjectAndKey (new NSString ("Unable to retrieve population from snapshot"), NSError.LocalizedDescriptionKey));
		return null;
	}

	var oldPopulation = (sfDocument.Data ["population"] as NSNumber).Int32Value;

	var updateData = new Dictionary<object, object> { { "population", oldPopulation + 1 } };
	transaction.UpdateData (updateData, sf);

	return null;
}
```

#### Passing information out of transactions

Do not modify application state inside of your transaction functions. Doing so will introduce concurrency issues, because transaction functions can run multiple times and are not guaranteed to run on the UI thread. Instead, pass information you need out of your transaction functions. The following example builds on the previous example to show how to pass information out of a transaction:

```csharp
var sf = db.GetCollection ("cities").GetDocument ("SF");
db.RunTransaction (HandleTransactionUpdate, HandleTransactionCompletion);

NSObject HandleTransactionUpdate (Transaction transaction, out NSError error)
{
	DocumentSnapshot sfDocument = transaction.GetDocument (sf, out error);

	if (error != null)
		return null;

	if (!(sfDocument.Data? ["population"] is NSNumber)) {
		error = new NSError (new NSString ("AppErrorDomain"),
					-1,
					NSDictionary.FromObjectAndKey (new NSString ("Unable to retrieve population from snapshot"), NSError.LocalizedDescriptionKey));
		return null;
	}

	var oldPopulation = (sfDocument.Data ["population"] as NSNumber).Int32Value;
	var newPopulation = oldPopulation + 1;

	if (newPopulation > 1000000) {
		error = new NSError (new NSString ("AppErrorDomain"),
					-2,
					NSDictionary.FromObjectAndKey (new NSString ("Population too big"), NSError.LocalizedDescriptionKey));
		return null;
	}

	var updateData = new Dictionary<object, object> { { "population", newPopulation } };
	transaction.UpdateData (updateData, sf);

	return NSNumber.FromInt32 (newPopulation);
}

void HandleTransactionCompletion (NSObject result, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error updating population: {error.LocalizedDescription}");
		return;
	}

	var population = (result as NSNumber).Int32Value;
	System.Console.WriteLine ($"Population increased to {population}");
}
```

An `async/await` version:

```csharp
var sf = db.GetCollection ("cities").GetDocument ("SF");

try {
	var result = await db.RunTransactionAsync (HandleTransactionUpdate);
	var population = (result as NSNumber).Int32Value;
	System.Console.WriteLine ($"Population increased to {population}");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error updating population: {error.LocalizedDescription}");
}

NSObject HandleTransactionUpdate (Transaction transaction, out NSError error)
{
	DocumentSnapshot sfDocument = transaction.GetDocument (sf, out error);

	if (error != null)
		return null;

	if (!(sfDocument.Data? ["population"] is NSNumber)) {
		error = new NSError (new NSString ("AppErrorDomain"),
					-1,
					NSDictionary.FromObjectAndKey (new NSString ("Unable to retrieve population from snapshot"), NSError.LocalizedDescriptionKey));
		return null;
	}

	var oldPopulation = (sfDocument.Data ["population"] as NSNumber).Int32Value;
	var newPopulation = oldPopulation + 1;

	if (newPopulation > 1000000) {
		error = new NSError (new NSString ("AppErrorDomain"),
					-2,
					NSDictionary.FromObjectAndKey (new NSString ("Population too big"), NSError.LocalizedDescriptionKey));
		return null;
	}

	var updateData = new Dictionary<object, object> { { "population", newPopulation } };
	transaction.UpdateData (updateData, sf);

	return NSNumber.FromInt32 (newPopulation);
}
```

#### Transaction failure

A transaction can fail for the following reasons:

* The transaction contains read operations after write operations. Read operations must always come before any write operations.
* The transaction read a document that was modified outside of the transaction. In this case, the transaction automatically runs again. The transaction is retried a finite number of times.

A failed transaction returns an error and does not write anything to the database. You do not need to roll back the transaction; Cloud Firestore does this automatically.

### Batched writes

If you do not need to read any documents in your operation set, you can execute multiple write operations as a single batch that contains any combination of `SetData`, `UpdateData`, or `DeleteData` operations. A batch of writes completes atomically and can write to multiple documents.

Batched writes are also useful for migrating large data sets to Cloud Firestore. A batched write can contain up to 500 operations and batching operations togethezr reduces connection overhead resulting in faster data migration.

Batched writes have fewer failure cases than transactions and use simpler code. They are not affected by contention issues, because they don't depend on consistently reading any documents. Batched writes execute even when the user's device is offline. The following example shows how to build and commit a batch of writes:

```csharp
// Get new write batch
var batch = db.CreateBatch ();

// Set the value of 'NYC'
var nyc = db.GetCollection ("cities").GetDocument ("NYC");
batch.SetData (new NSDictionary<NSString, NSObject> (), nyc);

// Update the population of 'SF'
var sf = db.GetCollection ("cities").GetDocument ("SF");
batch.UpdateData (new Dictionary<object, object> { { "population", 1000000 } }, sf);

// Delete the city 'LA'
var la = db.GetCollection ("cities").GetDocument ("LA");
batch.DeleteDocument (la);

// Commit the batch
batch.Commit (HandleCommitCompletion);

void HandleCommitCompletion (NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error writing batch: {error.LocalizedDescription}");
		return;
	}

	System.Console.WriteLine ("Batch write succeeded.");
}

// Async/await way:
try {
	// Commit the batch
	await batch.CommitAsync ();
	System.Console.WriteLine ("Batch write succeeded.");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error writing batch: {error.LocalizedDescription}");
}
```

## Delete Data from Cloud Firestore

To delete a document, use the `DeleteData` method:

```csharp
db.GetCollection ("cities").GetDocument ("DC").DeleteDocument (HandleDocumentActionCompletionHandler);

void HandleDocumentActionCompletionHandler (NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error removing document: {error.LocalizedDescription}");
		return;
	}

	System.Console.WriteLine ("Document successfully removed!");
}

// Async/await way:
try {
	await db.GetCollection ("cities").GetDocument ("DC").DeleteDocumentAsync ();
	System.Console.WriteLine ("Document successfully removed!");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error removing document: {ex.Error.LocalizedDescription}");
}
```

### Delete fields

To delete specific fields from a document, use the `FieldValue.Delete` property when you update a document:

```csharp
var deleteData = new Dictionary<object, object> { { "capital", FieldValue.Delete } };
db.GetCollection ("cities").GetDocument ("BJ").UpdateData (deleteData, HandleDocumentActionCompletionHandler);

void HandleDocumentActionCompletionHandler (NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error updating document: {error.LocalizedDescription}");
		return;
	}

	System.Console.WriteLine ("Document successfully updated!");
}

// Async/await way:
try {
	await db.GetCollection ("cities").GetDocument ("BJ").UpdateDataAsync (deleteData);
	System.Console.WriteLine ("Document successfully updated!");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error updating document: {error.LocalizedDescription}");
}
```

### Delete collections

To delete an entire collection or subcollection in Cloud Firestore, retrieve all the documents within the collection or subcollection and delete them. If you have larger collections, you may want to delete the documents in smaller batches to avoid out-of-memory errors. Repeat the process until you've deleted the entire collection or subcollection:

```csharp
void DeleteCollection (CollectionReference collection, int batchSize, Action<NSError> completion)
{
	// Limit query to avoid out-of-memory errors on large collections.
	// When deleting a collection guaranteed to fit in memory, batching can be avoided entirely.
	collection.LimitedTo (batchSize).GetDocuments (HandleQuerySnapshot);

	void HandleQuerySnapshot (QuerySnapshot snapshot, NSError error)
	{
		// An error occurred.
		if (error != null) {
			completion (error);
			return;
		}

		// There's nothing to delete.
		if (snapshot.Count == 0) {
			completion (null);
			return;
		}

		var batch = collection.Firestore.CreateBatch ();

		foreach (var document in snapshot.Documents)
			batch.DeleteDocument (document.Reference);

		batch.Commit (HandleCommitCompletion);
	}

	void HandleCommitCompletion (NSError error)
	{
		// Stop the deletion process and handle the error. Some elements
		// may have been deleted.
		if (error != null) {
			completion (error);
			return;
		}

		DeleteCollection (collection, batchSize, completion);
	}
}
```

An `async/await` version:

```csharp
async Task DeleteCollectionAsync (CollectionReference collection, int batchSize)
{
	// Limit query to avoid out-of-memory errors on large collections.
	// When deleting a collection guaranteed to fit in memory, batching can be avoided entirely.
	try {
		var snapshot = await collection.LimitedTo (batchSize).GetDocumentsAsync ();

		// There's nothing to delete.
		if (snapshot.Count == 0)
			return;

		var batch = collection.Firestore.CreateBatch ();

		foreach (var document in snapshot.Documents)
			batch.DeleteDocument (document.Reference);

		await batch.CommitAsync ();
	} catch (NSErrorException ex) {
		// Stop the deletion process and handle the error. Some elements
		// may have been deleted.
	}

	await DeleteCollectionAsync (collection, batchSize);
}
```

### Delete data with the Firebase CLI

You can also use the [Firebase CLI][5] to delete documents and collections. Use the following command to delete data:

```
firebase firestore:delete [options] <<path>>
```

## Manage Cloud Firestore with the Firebase Console

You can manage Cloud Firestore through the following actions in the [Firebase console][6]:

* Add, edit, and delete data.
* Create and update Cloud Firestore Security Rules.
* Manage indexes.

> ![note_icon] _**Note:**_ _During the Beta period, you can only manage Cloud Firestore from the Firebase console, not the Cloud Platform Console._

To learn more about this, please, read the following [documentation][7].

---

# Query Data

## Get Data with Cloud Firestore

There are two ways to retrieve data stored in Cloud Firestore. Either of these methods can be used with documents, collections of documents, or the results of queries:

* Call a method to get the data.
* Set a listener to receive data-change events.

When you set a listener, Cloud Firestore sends your listener an initial snapshot of the data, and then another snapshot each time the document changes.

### Example data

To get started, write some data about cities so we can look at different ways to read it back:

```csharp
var cities = db.GetCollection ("cities");

cities.GetDocument ("SF").SetData (new Dictionary<object, object> {
	{ "name", "San Francisco" },
	{ "state", "CA" },
	{ "country", "USA" },
	{ "capital", false },
	{ "population", 860000 }
});
cities.GetDocument ("LA").SetData (new Dictionary<object, object> {
	{ "name", "Los Angeles" },
	{ "state", "CA" },
	{ "country", "USA" },
	{ "capital", false },
	{ "population", 3900000 }
});
cities.GetDocument ("DC").SetData (new Dictionary<object, object> {
	{ "name", "Washington D.C." },
	{ "country", "USA" },
	{ "capital", true },
	{ "population", 680000 }
});
cities.GetDocument ("TOK").SetData (new Dictionary<object, object> {
	{ "name", "Tokyo" },
	{ "country", "Japan" },
	{ "capital", true },
	{ "population", 9000000 }
});
cities.GetDocument ("BJ").SetData (new Dictionary<object, object> {
	{ "name", "Beijing" },
	{ "country", "China" },
	{ "capital", true },
	{ "population", 21500000 }
});
```

### Get a document

The following example shows how to retrieve the contents of a single document using `GetDocument`:

```csharp
var document = db.GetCollection ("cities").GetDocument ("SF");
document.GetDocument (HandleDocumentSnapshot);

void HandleDocumentSnapshot (DocumentSnapshot snapshot, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error getting the document: {error.LocalizedDescription}");
		return;
	}

	if (snapshot != null) {
		System.Console.WriteLine ($"Document data: {snapshot.Data}");
	} else {
		System.Console.WriteLine ("Document does not exist.");
	}
}
```

An `async/await` version:

```csharp
var document = db.GetCollection ("cities").GetDocument ("SF");

try {
	var snapshot = await document.GetDocumentAsync ();

	if (snapshot != null)
		System.Console.WriteLine ($"Document data: {snapshot.Data}");
	else
		System.Console.WriteLine ("Document does not exist.");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error getting the document: {ex.Error.LocalizedDescription}");
}
```
 
> ![note_icon] _**Note:**_ _If there is no document at the location referenced by *document*, the resulting document will be `null`._

### Get multiple documents from a collection

You can also retrieve multiple documents with one request by querying documents in a collection. For example, you can use `WhereEqualsTo` methods to query for all of the documents that meet a certain condition, then use `GetDocuments` method to retrieve the results:

```csharp
db.GetCollection ("cities").WhereEqualsTo ("capital", true).GetDocuments (HandleQuerySnapshot);

void HandleQuerySnapshot (QuerySnapshot snapshot, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error getting documents: {error.LocalizedDescription}");
		return;
	}

	foreach (var document in snapshot?.Documents)
		System.Console.WriteLine ($"{document.Id} => {document.Data}");
}
```

An `async/await` version:

```csharp
try {
	var snapshot = await db.GetCollection ("cities").WhereEqualsTo ("capital", true).GetDocumentsAsync ();

	foreach (var document in snapshot?.Documents)
		System.Console.WriteLine ($"{document.Id} => {document.Data}");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error getting documents: {ex.Error.LocalizedDescription}");
}
```

#### Get all documents in a collection

In addition, you can retrieve all documents in a collection by omitting the `WhereEqualsTo` method filter entirely:

```csharp
db.GetCollection ("cities").GetDocuments (HandleQuerySnapshot);

void HandleQuerySnapshot (QuerySnapshot snapshot, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error getting documents: {error.LocalizedDescription}");
		return;
	}

	foreach (var document in snapshot?.Documents)
		System.Console.WriteLine ($"{document.Id} => {document.Data}");
}
```

An `async/await` version:

```csharp
try {
	var snapshot = await db.GetCollection ("cities").GetDocumentsAsync ();

	foreach (var document in snapshot?.Documents)
		System.Console.WriteLine ($"{document.Id} => {document.Data}");
} catch (NSErrorException ex) {
	System.Console.WriteLine ($"Error getting documents: {ex.Error.LocalizedDescription}");
}
```

## Get Realtime Updates with Cloud Firestore

You can listen to a document with the `AddSnapshotListener` method. An initial call using the callback you provide creates a document snapshot immediately with the current contents of the single document. Then, each time the contents change, another call updates the document snapshot:

```csharp
db.GetCollection ("cities").GetDocument ("SF").AddSnapshotListener (HandleDocumentSnapshot);

void HandleDocumentSnapshot (DocumentSnapshot snapshot, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error fetching document: {error.LocalizedDescription}");
		return;
	}

	System.Console.WriteLine ($"Current data: {snapshot.Data}");
}
```

#### Events for local changes

In the previous example, the callback was called twice after setting San Francisco's population to 999999. This is because of an important feature called "latency compensation." When you perform a write, your listeners will be notified with the new data immediately, before the data is even sent to the backend database.

As shown above, your listener will then be notified again once the data is actually written to the backend. This could take any amount of time from a few milliseconds to a few hours, depending on the state of your network connection.

Retrieved documents have a `metadata.HasPendingWrites` property that indicates whether the document has local changes that haven't been written to the backend yet. You can use this property to repeat the previous example but show the difference between the two events:

```csharp
db.GetCollection ("cities").GetDocument ("SF").AddSnapshotListener (HandleDocumentSnapshot);

void HandleDocumentSnapshot (DocumentSnapshot snapshot, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error fetching document: {error.LocalizedDescription}");
		return;
	}

	var source = snapshot.Metadata.HasPendingWrites ? "Local" : "Server";
	System.Console.WriteLine ($"{source} data: {snapshot.Data}");
}
```

> ![note_icon] _**Note:**_ _If you just want to know when your write has completed, you can listen to the completion callback of your write function rather than using `HasPendingWrites` property.

### Listen to multiple documents in a collection

As with documents, you can use `AddSnapshotListener` method instead of `GetDocument` method to listen to the results of a query. This creates a query snapshot. For example, to listen to the documents with state CA:

```csharp
db.GetCollection ("cities").WhereEqualsTo ("state", "CA").AddSnapshotListener (HandleQuerySnapshot);

void HandleQuerySnapshot (QuerySnapshot snapshot, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error getting documents: {error.LocalizedDescription}");
		return;
	}

	var cities = new string [snapshot?.Documents.Length ?? 0];

	for (int i = 0; i < cities.Length; i++)
		cities [i] = snapshot.Documents [i].Data ["name"].ToString ();

	var citiesString = string.Join (", ", cities);

	System.Console.WriteLine ($"Current cities in CA: {citiesString}");
}
```

The snapshot handler will receive a new query snapshot every time the query results change (that is, when a document is added, removed, or modified).

> ![note_icon] _**Important:**_ _As explained above under [Events for local changes](#events-for-local-changes), you will receive events immediately for your local writes. Your listener can use the `metadata.HasPendingWrites` field on each document to determine whether the document has local changes that have not yet been written to the backend._

#### View changes between snapshots

It is often useful to see the actual changes to query results between query snapshots, instead of simply using the entire query snapshot. For example, you may want to maintain a cache as individual documents are added, removed, and modified:

```csharp
db.GetCollection ("cities").WhereEqualsTo ("state", "CA").AddSnapshotListener (HandleQuerySnapshot);

void HandleQuerySnapshot (QuerySnapshot snapshot, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error getting documents: {error.LocalizedDescription}");
		return;
	}

	foreach (var documentChange in snapshot?.DocumentChanges) {
		switch (documentChange.Type) {
		case DocumentChangeType.Added:
			System.Console.WriteLine ($"New city: {documentChange.Document.Data}");
			break;
		case DocumentChangeType.Modified:
			System.Console.WriteLine ($"Modified city: {documentChange.Document.Data}");
			break;
		case DocumentChangeType.Removed:
			System.Console.WriteLine ($"Removed city: {documentChange.Document.Data}");
			break;
		}
	}
}
```

> ![note_icon] _**Important:**_ _The first query snapshot contains **added** events for all existing documents that match the query. This is because you're getting a set of changes that bring your query snapshot current with the initial state of the query. This allows you, for instance, to directly populate your UI from the changes you receive in the first query snapshot, without needing to add special logic for handling the initial state._

The initial state can come from the server directly, or from a local cache. If there is state available in a local cache, the query snapshot will be initially populated with the cached data, then updated with the server's data when the client has caught up with the server's state.

#### Detach a listener

When you are no longer interested in listening to your data, you must detach your listener so that your event callbacks stop getting called. This allows the client to stop using bandwidth to receive updates. You can use the unsubscribe function on `AddSnapshotListener` method to stop listening to updates:

```csharp
var listener = db.GetCollection ("cities").AddSnapshotListener (HandleQuerySnapshot);

// ...

// Stop listening to changes
listener.Remove ();

void HandleQuerySnapshot (QuerySnapshot snapshot, NSError error)
{
	// ...
}
```

#### Handle listen errors

A listen may occasionally fail — for example, due to security permissions, or if you tried to listen on an invalid query. (Learn more about [valid and invalid queries](#compound_queries).) To handle these failures, you can provide an error callback when you attach your snapshot listener. After an error, the listener will not receive any more events, and there is no need to detach your listener.

```csharp
db.GetCollection ("cities").AddSnapshotListener (HandleQuerySnapshot);

void HandleQuerySnapshot (QuerySnapshot snapshot, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error retreiving collection: {error.LocalizedDescription}");
		return;
	}
}
```

## Perform Simple and Compound Queries in Cloud Firestore

Cloud Firestore provides powerful query functionality for specifying which documents you want to retrieve from a collection. These queries can also be used with either `GetDocument` or `AddSnapshotListener` methods, as described in [Get Data](#get-data-with-cloud-firestore) and [Get Realtime Updates](#get-realtime-updates-with-cloud-firestore).

### Example data

To get started, write some data about cities so we can look at different ways to read it back:

```csharp
var cities = db.GetCollection ("cities");

cities.GetDocument ("SF").SetData (new Dictionary<object, object> {
	{ "name", "San Francisco" },
	{ "state", "CA" },
	{ "country", "USA" },
	{ "capital", false },
	{ "population", 860000 }
});
cities.GetDocument ("LA").SetData (new Dictionary<object, object> {
	{ "name", "Los Angeles" },
	{ "state", "CA" },
	{ "country", "USA" },
	{ "capital", false },
	{ "population", 3900000 }
});
cities.GetDocument ("DC").SetData (new Dictionary<object, object> {
	{ "name", "Washington D.C." },
	{ "country", "USA" },
	{ "capital", true },
	{ "population", 680000 }
});
cities.GetDocument ("TOK").SetData (new Dictionary<object, object> {
	{ "name", "Tokyo" },
	{ "country", "Japan" },
	{ "capital", true },
	{ "population", 9000000 }
});
cities.GetDocument ("BJ").SetData (new Dictionary<object, object> {
	{ "name", "Beijing" },
	{ "country", "China" },
	{ "capital", true },
	{ "population", 21500000 }
});
```

### Simple queries

The following query returns all cities with state **CA**:

```csharp
// Create a reference to the cities collection
var cities = db.GetCollection ("cities");

// Create a query against the collection.
var query = cities.WhereEqualsTo ("state", "CA").
```

The following query returns all the capital cities:

```csharp
var capitalCities = db.GetCollection ("cities").WhereEqualsTo ("state", true);
```

There are some `WhereFoo` methods to help in different comparison scenarios:

```csharp
cities.WhereEqualsTo ("state", "CA");
cities.WhereLessThan ("population", 100000);
cities.WhereGreaterThanOrEqualsTo ("name", "San Francisco");
```

### Compound queries

You can also chain multiple `WhereFoo` methods to create more specific queries (logical `AND`). However, to combine the equality operator (`==`) with a range comparison (`<`, `<=`, `>`, or `>=`), make sure to create a [custom index][8].

```csharp
cities.WhereEqualsTo ("state", "CO").WhereEqualsTo ("name", "Denver");
cities.WhereEqualsTo ("state", "CA").WhereLessThan ("population", 1000000);
```

Additionally, you can only perform range comparisons (`<`, `<=`, `>`, `>=`) on a single field:

![correct_icon] **Valid:** Range filters on only one field:

```csharp
cities.WhereGreaterThanOrEqualsTo ("state", "CA")
      .WhereLessThanOrEqualsTo ("state", "IN");

cities.WhereEqualsTo ("state", "CA")
      .WhereGreaterThan ("population", 1000000);
```

![wrong_icon] **Invalid:** Range filters on different fields:

```csharp
cities.WhereGreaterThanOrEqualsTo ("state", "CA")
      .WhereGreaterThan ("population", 1000000);
```

## Order and Limit Data with Cloud Firestore

Cloud Firestore provides powerful query functionality for specifying which documents you want to retrieve from a collection. These queries can also be used with either `GetDocuments` or `AddSnapshotListener` methods, as described in [Get Data](#get-data-with-cloud-firestore).

### Order and limit data

Cloud Firestore also lets you specify the sort order for your data and specify a limit to how many documents you want to retrieve using `OrderedBy` and `LimitedTo` methods. For example, you could query for the first 3 cities alphabetically with:

```csharp
cities.OrderedBy ("name").LimitedTo (3);
```

You could also sort in descending order to get the last 3 cities:

```csharp
cities.OrderedBy ("name", true).LimitedTo (3);
```

You can also order by multiple fields. For example, if you wanted to order by state, and within each state order by population in descending order:

```csharp
cities.OrderedBy ("state")
      .OrderedBy ("population", true);
```

You can combine `WhereFoo` filters with `OrderedBy` and `LimitedTo` methods. In the following example, the queries define a population threshold, sort by population in ascending order, and return only the first few results that exceed the threshold:

```csharp
cities.WhereGreaterThan ("population", 100000)
      .OrderedBy ("population")
      .LimitedTo (2);
```

However, if you have a filter with a range comparison (<, <=, >, >=), your first ordering must be on the same field:

![correct_icon] **Valid:** Range filter and `OrderedBy` on the same field:

```csharp
cities.WhereGreaterThan ("population", 100000)
      .OrderedBy ("population");
```

![wrong_icon] **Invalid:** Range filter and first `OrderedBy` on different fields:

```csharp
cities.WhereGreaterThan ("population", 100000)
      .OrderedBy ("population");
```

## Paginate Data with Query Cursors

With query cursors in Cloud Firestore, you can split data returned by a query into batches according to the parameters you define in your query.

Query cursors define the start and end points for a query, allowing you to:

* Return a subset of the data.
* Paginate query results.

However, to define a specific range for a query, you should use the `WhereFoo` methods described in [Simple Queries](#simple_queries).

### Add a simple cursor to a query

Use the `StartingAt` or `StartingAfter` methods to define the start point for a query. The `StartingAt` method includes the start point, while the `StartingAfter` method excludes it.

For example, if you use `StartingAt (A)` in a query, it returns the entire alphabet. If you use `StartingAfter (A)` instead, it returns B-Z:

```csharp
// Get all cities with population over one million, ordered by population.
cities.OrderedBy ("population")
      .StartingAt (new object [] { 1000000 });
```

Similarly, use the `EndingAt` or `EndingBefore` methods to define an end point for your query results:

```csharp
// Get all cities with population less than one million, ordered by population.
cities.OrderedBy ("population")
      .EndingAt (new object [] { 1000000 });
```

### Use a document snapshot to define the query cursor

You can also pass a document snapshot to the cursor clause as the start or end point of the query cursor. The values in the document snapshot serve as the values in the query cursor.

For example, take a snapshot of a "San Francisco" document in your data set of cities and populations. Then, use that document snapshot as the start point for your population query cursor. Your query will return all the cities with a population larger than or equal to San Francisco's, as defined in the document snapshot:

```csharp
db.GetCollection ("cities").GetDocument ("SF").AddSnapshotListener (HandleDocumentSnapshot);

void HandleDocumentSnapshot (DocumentSnapshot snapshot, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error fetching document: {error.LocalizedDescription}");
		return;
	}

	// Get all cities with a population greater than or equal to San Francisco.
	var sfSizeOrBigger = db.GetCollection ("cities")
			       .OrderedBy ("population")
			       .StartingAt (snapshot);
}
```

### Paginate a query

Paginate queries by combining query cursors with the `LimitedTo` method. For example, use the last document in a batch as the start of a cursor for the next batch:

```csharp
// Construct query for first 25 cities, ordered by population
var first = db.GetCollection ("cities")
	      .OrderedBy ("population")
	      .LimitedTo (25);

first.AddSnapshotListener (HandleQuerySnapshot);

void HandleQuerySnapshot (QuerySnapshot snapshot, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error retreving cities: {error.LocalizedDescription}");
		return;
	}

	if (snapshot.Documents.Length == 0) {
		// The collection is empty.
		return;
	}

	// Construct a new query starting after this document,
	// retrieving the next 25 cities.
	var lastSnapshot = snapshot.Documents.Last ();
	var next = db.GetCollection ("cities")
		     .OrderedBy ("population")
		     .StartingAfter (lastSnapshot);

	// Use the query for pagination.
	// ...
}
```

### Set multiple cursor conditions

To add more granularity to your cursor's start or end point, you can specify multiple conditions in the cursor clause. This is particularly useful if your data set includes fields where the first condition in a cursor clause would return multiple results. Use multiple conditions to further specify the start or end point and reduce ambiguity.

For example, in a data set containing all the cities named "Springfield" in the United States, there would be multiple start points for a query set to start at "Springfield":

##### Cities

| Name        | State         |
|-------------|---------------|
| Springfield | Massachusetts |
| Springfield | Missouri      |
| Springfield | Wisconsin     |

To start at a specific Springfield, you could add the state as a secondary condition in your cursor clause:

```csharp
// Will return all Springfields
db.GetCollection ("cities")
  .OrderedBy ("name")
  .OrderedBy ("state")
  .StartingAt (new object [] { "Springfield" });

// Will return "Springfield, Missouri" and "Springfield, Wisconsin"
db.GetCollection ("cities")
  .OrderedBy ("name")
  .OrderedBy ("state")
  .StartingAt (new object [] { "Springfield", "Missouri" });
```

## Manage Indexes in Cloud Firestore

Cloud Firestore requires an index for every query, to ensure the best performance. All document fields are automatically indexed, so queries that only use equality clauses don't need additional indexes. If you attempt a compound query with a range clause that doesn't map to an existing index, you receive an error. The error message includes a direct link to create the missing index in the Firebase console.

Follow the generated link to the Firebase console, review the automatically populated info, and click Create.

To learn more about this, please, read the following [documentation][8].

---

# Secure Data

## Secure Data in Cloud Firestore

Cloud Firestore offers robust access management and authentication through two different methods, depending on the client libraries you use.

* For mobile and web client libraries, use Firebase Authentication and Cloud Firestore Security Rules to handle serverless authentication, authorization, and data validation. Learn how to secure your data for the Android, iOS, and Web client libraries with [Cloud Firestore Security Rules][9].
* For server client libraries, use Cloud Identity and Access Management (IAM) to manage access to your database. Learn how to secure your data for the Java, Python, Node.js, and Go client libraries with [IAM][10].

---

# Enable Offline Data

Cloud Firestore supports offline data persistence. This feature caches a copy of the Cloud Firestore data that your app is actively using, so your app can access the data when the device is offline. You can write, read, listen to, and query the cached data. When the device comes back online, Cloud Firestore synchronizes any local changes made by your app to the data stored remotely in Cloud Firestore.

To use offline persistence, you don't need to make any changes to the code that you use to access Cloud Firestore data. With offline persistence enabled, the Cloud Firestore client library automatically manages online and offline data access and synchronizes local data when the device is back online.

### Configure offline persistence

When you initialize Cloud Firestore, you can enable or disable offline persistence. For Android and iOS, offline persistence is enabled by default. To disable persistence, set the `PersistenceEnabled` option to `false`:

```csharp
var settings = new FirestoreSettings { PersistenceEnabled = false };

// Any additional options
// ...

// Disable offline data persistence
var db = Firestore.SharedInstance;
db.Settings = settings;
```

### Listen to offline data

While the device is offline, if you have enabled offline persistence, your listeners will receive listen events when the locally cached data changes. You can listen to documents, collections, and queries.

To check whether you're receiving data from the server or the cache, use the fromCache property on the SnapshotMetadata in your snapshot event. If fromCache is true, the data came from the cache and might be stale or incomplete. If fromCache is false, the data is complete and current with the latest updates on the server.

By default, no event is raised if only the SnapshotMetadata changed. If you rely on the fromCache values, specify the includeMetadataChanges listen option when you attach your listen handler:

```csharp
// Listen to metadata updates to receive a server snapshot even if
// the data is the same as the cached data.
var options = new QueryListenOptions ();
options.SetIncludeQueryMetadataChanges (true);

db.GetCollection ("cities").WhereEqualsTo ("state", "CA").AddSnapshotListener (options, HandleQuerySnapshot);

void HandleQuerySnapshot (QuerySnapshot snapshot, NSError error)
{
	if (error != null) {
		System.Console.WriteLine ($"Error retreving snapshot: {error.LocalizedDescription}");
		return;
	}

	foreach (var documentChange in snapshot?.DocumentChanges)
		if (documentChange.Type == DocumentChangeType.Added)
			System.Console.WriteLine ($"New city: {documentChange.Document.Data}");

	var source = snapshot.Metadata.IsFromCache ? "local cache" : "server";
	System.Console.WriteLine ($"Metadata: Data fetched from {source}");
}
```

### Get offline data

If you get a document while the device is offline, Cloud Firestore returns data from the cache. If the cache does not contain data for that document, or the document does not exist, the get call returns an error.

### Query offline data

Querying works with offline persistence. You can retrieve the results of queries with either a direct get or by listening, as described in the preceding sections. You can also create new queries on locally persisted data while the device is offline, but the queries will initially run only against the cached documents.

---

## Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][11])
* Error `Native linking failed, duplicate symbol '_main'` appears when you try to build for **iPhoneSimulator**. A workaround for this is to change the behavior of the **Registrar**:
	1. Open your project settings
	2. Go to **Build** tab
	3. Select **iOS Build** option
	4. Type `--registrar:static` in **Additional mtouch arguments** textbox
	5. Click on **Ok**

	Don't forget to add this in **Release** and **Debug** configuration of **iPhoneSimulator** platform.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/firestore/) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: https://console.cloud.google.com/projectselector/apis/api/firestore.googleapis.com/overview?pli=1
[3]: https://firebase.google.com/docs/firestore/manage-data/structure-data
[4]: https://firebase.google.com/docs/firestore/manage-data/data-types
[5]: https://firebase.google.com/docs/cli
[6]: https://console.firebase.google.com/project/_/database/firestore/data
[7]: https://firebase.google.com/docs/firestore/using-console
[8]: https://firebase.google.com/docs/firestore/query-data/indexing
[9]: https://firebase.google.com/docs/firestore/security/get-started
[10]: https://firebase.google.com/docs/firestore/security/iam
[11]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689
[document_icon]: https://cdn1.iconfinder.com/data/icons/hawcons/32/698661-icon-54-document-20.png
[collections_icon]: https://cdn1.iconfinder.com/data/icons/hawcons/32/698680-icon-72-documents-20.png
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
[correct_icon]: https://cdn4.iconfinder.com/data/icons/icocentre-free-icons/137/f-check_256-20.png
[wrong_icon]: https://cdn4.iconfinder.com/data/icons/icocentre-free-icons/114/f-cross_256-20.png
