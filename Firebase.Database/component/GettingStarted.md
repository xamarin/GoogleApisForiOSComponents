# Firebase Database on iOS

The Firebase Database is a cloud-hosted database. Data is stored as JSON and synchronized in realtime to every connected client. When you build cross-platform apps with our Android, iOS, and JavaScript SDKs, all of your clients share one Realtime Database instance and automatically receive updates with the newest data.

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

## Configure Database in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Analytics` namespace):

```csharp
App.Configure ();
```

## Structure Your Database

Before you continue, please, read this [documentation][10] to know how Database is structured and best practices for data structure. 

## Recommended documentation to get a better understanding of the Security & Rules of Firebase Database

Before you continue, I invite you to read these following docs to make your coding easier:

* [Understand Rules][13]
* [Get Started][14]
* [Secure Data][15]
* [Secure User Data][16]
* [Index Data][17]
* [Manage Rules via REST][18]

## Configure Firebase Database Rules

The Realtime Database provides a declarative rules language that allows you to define how your data should be structured, how it should be indexed, and when your data can be read from and written to. By default, read and write access to your database is restricted so only authenticated users can read or write data. To get started without setting up [Authentication][3], you can [configure your rules for public access][4]. This does make your database open to anyone, even people not using your app, so be sure to restrict your database again when you set up authentication.

## Read and Write Data on iOS

This document covers the basics of reading and writing Firebase data.

Firebase data is written to a `Database` reference and retrieved by attaching an asynchronous listener to the reference. The listener is triggered once for the initial state of the data and again anytime the data changes.

To read or write data from the database, you need an instance of `DatabaseReference`:

```csharp
DatabaseReference rootNode = Database.DefaultInstance.GetRootReference ();
```

Doing this, you will have a variable called `rootNode` that points to **https://yourFirebaseDatabase/**

### Basic write operations

For basic write operations, you can use `SetValue<T> (T value)`, `SetValues<T> (T [] values)` or `SetValues (NSObject [] values)` to save data to a specified reference, replacing any existing data at that path. You can use this method to pass types that correspond to the available JSON types as follows:

* NSString
* NSNumber
* NSDictionary
* NSArray

***Note:*** *If you pass an object different from these 4 types, an exception will be thrown. Types inherited from these 4 types will be accepted.*

For instance, you can add a user with `SetValue<T> (T value)`. First create a reference that points to the user reference:

```csharp
DatabaseReference userNode = rootNode.GetChild ("users").GetChild (user.Uid);
```

Doing this, now you have a variable that points to **https://yourFirebaseDatabase/users/$userUid** where **$userUid** is the key of the reference. The reference is created even if it doesn't exist but only will be saved into Firebase Database until you assign some value to the reference:

```csharp
object [] keys = { "username" };
object [] values = { username };
var data = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);

userNode.SetValue<NSDictionary> (data);
```

You can avoid creating variables for each reference and assign the value directly:

```csharp
rootNode.GetChild ("users").GetChild (user.Uid).SetValue<NSDictionary> (data);
```

Using `SetValue` in these ways overwrites data at the specified location, including any child nodes. However, you can still update a child without rewriting the entire object. If you want to allow users to update their profiles you could update the username as follows:

```csharp
rootNode.GetChild ("users").GetChild (user.Uid).GetChild ("username").SetValue<NSString> (username);
```

### Listen for value events

To read data at a path and listen for changes, use the `ObserveEvent` or `ObserveSingleEvent` methods of `DatabaseReference` to observe `DataEventType.Value` events.

| Event type              | Typical usage                                                 |
|:-----------------------:|---------------------------------------------------------------|
| **DataEventType.Value** | Read and listen for changes to the entire contents of a path. |

You can use the `DataEventType.Value` event to read the data at a given path, as it exists at the time of the event. This method is triggered once when the listener is attached and again every time the data, including any children, changes. The event callback is passed a `snapshot` containing all data at that location, including child data. If there is no data, the `value` of the `snapshot` returned is `null`.

***Important:*** *The `DataEventType.Value` event is fired every time data is changed at the specified database reference, including changes to children. To limit the size of your snapshots, attach only at the highest level needed for watching changes. For example, attaching a listener to the root of your database is not recommended.*

The following example demonstrates a notes application retrieving the user's folders from the database:

```csharp
DatabaseReference foldersNode = rootNode.GetChild ("folders").GetChild (user.Uid);
nuint handleReference = foldersNode.ObserveEvent (DataEventType.Value, (snapshot) => {
	var folderData = snapshot.GetValue<NSDictionary> ();
	// Do magic with the folder data
});
```

The listener receives a `DataSnapshot` that contains the data at the specified location in the database at the time of the event in its `GetValue`, `GetValue<T>`, `GetValues` or `GetValues<T>` methods. You can assign the values to the appropriate native type, such as `NSDictionary`. If no data exists at the location, the value is `null`.

### Read data once

In some cases you may want a callback to be called once and then immediately removed, such as when initializing a UI element that you don't expect to change. You can use the `ObserveSingleEvent` method to simplify this scenario: the event callback added triggers once and then does not trigger again.

This is useful for data that only needs to be loaded once and isn't expected to change frequently or require active listening. For instance, we can use this method to know the total of notes that a folder has:

```csharp
nuint notesCount;
DatabaseReference notesCountNode = rootNode.GetChild ("folders").GetChild (user.Uid).GetChild (folderUid).GetChild ("notesCount");
notesCountNode.ObserveSingleEvent (DataEventType.Value, (snapshot) => {
	notesCount = snapshot.GetValue<NSNumber> ().NUIntValue;
}, (error) => {
	Console.WriteLine (error.LocalizedDescription);
});
```

### Update specific fields

To simultaneously write to specific children of a node without overwriting other child nodes, use the `UpdateChildValues` method.

When calling updateChildValues, you can update lower-level child values by specifying a path for the key. If data is stored in multiple locations to scale better, you can update all instances of that data using [data fan-out][5]. For example, in notes app, the user wants to save a new note and simultaneously update the total of notes that the folder has. To do this, the code could be like this:

```csharp
var noteUid = rootNode.GetChild ("notes").GetChild (user.Uid).GetChild (folderUid).GetChildByAutoId ().Key;

object [] noteKeys = { "content", "created", "lastModified", "title" };
object [] noteValues = { content, created, lastModified, title };
var noteData = NSDictionary.FromObjectsAndKeys (noteValues, noteKeys, noteKeys.Length);

object [] nodes = { $"notes/{user.Uid}/{folderUid}/{noteUid}", $"folders/{user.Uid}/{folderUid}/notesCount" };
object [] nodesValues = { noteData, NSNumber.FromNUInt (++notesCount) };
var childUpdates = NSDictionary.FromObjectsAndKeys (nodesValues, nodes, nodes.Length);

rootNode.UpdateChildValues (childUpdates);
```

Using these paths, you can perform simultaneous updates to multiple locations in the JSON tree with a single call to `UpdateChildValues` method. Simultaneous updates made this way are atomic: either all updates succeed or all updates fail.

### Delete data

The simplest way to delete data is to call `RemoveValue` method on a reference to the location of that data.

You can also delete by specifying `null` as the value for another write operation such as `SetValue<T>` or `UpdateChildValues`. You can use this technique with `UpdateChildValues` to delete multiple children in a single API call:

```csharp
DatabaseReference noteNode = rootNode.GetChild ("notes").GetChild (user.Uid).GetChild (folderUid).GetChild (noteUid);

// Same functionality
noteNode.RemoveValue ();
noteNode.SetValue<NSObject> (null);

object [] nodes = { $"notes/{user.Uid}/{folderUid}/{noteUid}" };
object [] nodesValues = { null };
var childUpdates = NSDictionary.FromObjectsAndKeys (nodesValues, nodes, nodes.Length);
rootNode.UpdateChildValues (childUpdates);
```

## Detach listeners

Observers don't automatically stop syncing data when you leave a ViewController. If an observer isn't properly removed, it continues to sync data to local memory. When an observer is no longer needed, remove it by passing the associated **DatabaseHandle** to the `RemoveObserver` method:

```csharp
DatabaseReference foldersNode = rootNode.GetChild ("folders").GetChild (user.Uid);
nuint handleReference = foldersNode.ObserveEvent (DataEventType.Value, (snapshot) => {
	var folderData = snapshot.GetValue<NSDictionary> ();
	// Do magic with the folder data
});

// Some other code

// When you don't want to keep listening for changes in that node, do the following at some point of your app
foldersNode.RemoveObserver (handleReference);
```

When you add a callback block to a reference, a `nuint` is returned. These handles can be used to remove the callback block.

If multiple listeners have been added to a database reference, each listener is called when an event is raised. In order to stop syncing data at that location, you must remove all observers at a location by calling the `RemoveAllObservers` method.

Calling `RemoveObserver` or `RemoveAllObservers` on a listener does not automatically remove listeners registered on its child nodes; you must also be keep track of those references or handles to remove them.

## Save data as transactions

When working with data that could be corrupted by concurrent modifications, such as incremental counters, you can use a [transaction operation][6]. You give this operation two arguments: an update function and an optional completion callback. The update function takes the current state of the data as an argument and returns the new desired state you would like to write.

For instance, imagine that you have a collaborative notes app, and some users are working in the same note, you could allow users to update the note as follows:

```csharp
noteNode.RunTransaction ((currentData) => {
	var noteData = currentData.GetValue<NSDictionary> ();

	if (noteData == null)
		return TransactionResult.Success (currentData);

	var mutableNoteData = noteData.MutableCopy () as NSMutableDictionary;
	mutableNoteData ["content"] = content;
	mutableNoteData ["title"] = title;

	currentData.SetValue<NSMutableDictionary> (mutableNoteData);

	return TransactionResult.Success (currentData);
}, (error, commited, snapshot) => {
	if (error != null) {
		Console.WriteLine (error.LocalizedDescription);
	}
});
```

Using a transaction prevents note content from being incorrect if multiple users edit the same note at the same time or the client had stale data. The value contained in the `MutableData` class is initially the client's last known value for the path, or `null` if there is none. The server compares the initial value against it's current value and accepts the transaction if the values match, or rejects it. If the transaction is rejected, the server returns the current value to the client, which runs the transaction again with the updated value. This repeats until the transaction is accepted or too many attempts have been made.

***Note:*** *Because `RunTransaction` method is called multiple times, it must be able to handle `null` data. Even if there is existing data in your remote database, it may not be locally cached when the transaction function is run, resulting in `null` for the initial value.*

## Write data offline

If a client loses its network connection, your app will continue functioning correctly.

Every client connected to a Firebase database maintains its own internal version of any active data. When data is written, it's written to this local version first. The Firebase client then synchronizes that data with the remote database servers and with other clients on a "best-effort" basis.

As a result, all writes to the database trigger local events immediately, before any data is written to the server. This means your app remains responsive regardless of network latency or connectivity.

Once connectivity is reestablished, your app receives the appropriate set of events so that the client syncs with the current server state, without having to write any custom code.

## Work with Lists of Data on iOS

### Append to a list of data

Use the `GetChildByAutoId` method to append data to a list in multiuser applications. The `GetChildByAutoId` method generates a unique key every time a new child is added to the specified Firebase reference. By using these auto-generated keys for each new element in the list, several clients can add children to the same location at the same time without write conflicts. The unique key generated by `GetChildByAutoId` is based on a timestamp, so list items are automatically ordered chronologically.

You can use the reference to the new data returned by the `GetChildByAutoId` method to get the value of the child's auto-generated key or set data for the child. Calling `Key` property on a `GetChildByAutoId` reference returns the auto-generated key.

You can use these auto-generated keys to simplify flattening your data structure. For more information, see the data fan-out [example][5].

### Listen for child events

Child events are triggered in response to specific operations that happen to the children of a node from an operation such as a new child added through the `GetChildByAutoId` method or a child being updated through the `UpdateChildValues` method.

| Event type                     | Typical usage |
|:------------------------------:|---------------|
| **DataEventType.ChildAdded**   | Retrieve lists of items or listen for additions to a list of items. This event is triggered once for each existing child and then again every time a new child is added to the specified path. The listener is passed a snapshot containing the new child's data. Also, It is used with data that is ordered by `GetQueryOrderedByChild` or `GetQueryOrderedByValue` methods. |
| **DataEventType.ChildChanged** | Listen for changes to the items in a list. This event is triggered any time a child node is modified. This includes any modifications to descendants of the child node. The snapshot passed to the event listener contains the updated data for the child. |
| **DataEventType.ChildRemoved** | Listen for items being removed from a list. This event is triggered when an immediate child is removed.The snapshot passed to the callback block contains the data for the removed child. |
| **DataEventType.ChildMoved**   | Listen for changes to the order of items in an ordered list. This event is triggered whenever an update causes reordering of the child. |

Each of these together can be useful for listening to changes to a specific node in a database. For example, the notes app could use these methods together to monitor activity when a folder is created or deleted, as shown below:

```csharp
// Listen for new folders in the Firebase database
foldersNode.ObserveEvent (DataEventType.ChildAdded, (snapshot, prevKey) => {
	var data = snapshot.GetValue<NSDictionary> ();
	var created = data ["created"].ToString ();
	var lastModified = data ["lastModified"].ToString ();
	var name = data ["name"].ToString ();
	var notesCount = (data ["notesCount"] as NSNumber).UInt32Value;
	
	var folder = new Folder {
		Name = name,
		Created = created,
		LastModified = AppDelegate.ConvertUnformattedUtcDateToCurrentDate (lastModified),
		NotesCount = notesCount
	};
	
	folders.Add (folder);

	TableView.ReloadData ();
});

// Listen for deleted comments in the Firebase database
foldersNode.ObserveEvent (DataEventType.ChildRemoved, (snapshot, prevKey) => {
	var data = snapshot.GetValue<NSDictionary> ();
	var created = data ["created"].ToString ();
	var lastModified = data ["lastModified"].ToString ();
	var name = data ["name"].ToString ();
	var notesCount = (data ["notesCount"] as NSNumber).UInt32Value;
	
	var folder = new Folder {
		Name = name,
		Created = created,
		LastModified = AppDelegate.ConvertUnformattedUtcDateToCurrentDate (lastModified),
		NotesCount = notesCount
	};
	
	folders.Remove (folder);

	TableView.ReloadData ();
});
```

### Listen for value events

While listening for child events is the recommended way to read lists of data, there are situations listening for value events on a list reference is useful.

Attaching a `DataEventType.Value` observer to a list of data will return the entire list of data as a single DataSnapshot, which you can then loop over to access individual children.

Even when there is only a single match for the query, the snapshot is still a list; it just contains a single item. To access the item, you need to loop over the result:

```csharp
foldersNode.ObserveEvent (DataEventType.Value, (snapshot) => {
	// Loop over the children
	NSEnumerator children = snapshot.Children;
	var child = children.NextObject () as DataSnapshot;

	while (child != null) {
		// Work with data...

		child = children.NextObject () as DataSnapshot;
	}
});
```

This pattern can be useful when you want to fetch all children of a list in a single operation, rather than listening for additional child added events.

## Sorting and filtering data

You can use the Realtime Database `DatabaseQuery` class to retrieve data sorted by key, by value, or by the value of a child. You can also filter the sorted result to a specific number of results or a range of keys or values.

***Note:*** *Filtering and sorting can be expensive, especially when done on the client. If your app uses queries, define the .indexOn rule to index those keys on the server and improve query performance as described in [Indexing Your Data][7].*

### Sort data

To retrieve sorted data, start by specifying one of the order-by methods to determine how results are ordered:

| Method                     | Usage                                                |
|:--------------------------:|------------------------------------------------------|
| **GetQueryOrderedByKey**   | Order results by child keys.                         |
| **GetQueryOrderedByValue** | Order results by child values.                       |
| **GetQueryOrderedByChild** | Order results by the value of a specified child key. |

You can only use **one** order-by method at a time. Calling an order-by method multiple times in the same query **throws an error**.

The following example demonstrates how you could retrieve a list of a notes sorted by their last time modified:

```csharp
DatabaseReference notesNode = rootNode.GetChild ("notes").GetChild (user.Uid).GetChild (folderUid);

// Get all notes sorted by their last time modified in ascending order
DatabaseQuery notesByDate = notesNode.GetQueryOrderedByChild ("lastModified");
notesByDate.ObserveEvent (DataEventType.ChildAdded, (snapshot) => {
	var data = snapshot.GetValue<NSDictionary> ();
	var content = data ["content"].ToString ();
	var created = data ["created"].ToString ();
	var lastModified = data ["lastModified"].ToString ();
	var title = data ["title"].ToString ();
	
	var note = new Note {
		Content = content,
		Created = created,
		LastModified = lastModified,
		Title = title
	}
	
	notes.Add (note);

	TableView.ReloadData ();
});
```

This query retrieves the user's notes from the path in the database based on their user Id and the folder Id, ordered by the last time modified. This technique of using IDs as index keys is called data fan out, you can read more about it in [Structure Your Database][5].

The call to the `GetQueryOrderedByChild` method specifies the child key to order the results by. In this case, notes are sorted by the value of the **lastModified** child in each post. For more information on how other data types are ordered, see [How query data is ordered][8].

### Filtering data

To filter data, you can combine any of the limit or range methods with an order-by method when constructing a query.

| Method                      | Usage                                                                                                      |
|:---------------------------:|------------------------------------------------------------------------------------------------------------|
| **GetQueryLimitedToFirst**  | Sets the maximum number of items to return from the beginning of the ordered list of results.              |
| **GetQueryLimitedToLast**   | Sets the maximum number of items to return from the end of the ordered list of results.                    |
| **GetQueryStartingAtValue** | Return items greater than or equal to the specified key or value, depending on the order-by method chosen. |
| **GetQueryEndingAtValue**   | Return items less than or equal to the specified key or value, depending on the order-by method chosen.    |
| **GetQueryEqualToValue**    | Return items equal to the specified key or value, depending on the order-by method chosen.                 |

Unlike the order-by methods, you can combine multiple limit or range functions. For example, you can combine the `GetQueryStartingAtValue` and `GetQueryEndingAtValue` methods to limit the results to a specified range of values.

### Limit the number of results

You can use the `GetQueryLimitedToFirst` and `GetQueryLimitedToLast` methods to set a maximum number of children to be synced for a given callback. For example, if you use `GetQueryLimitedToFirst` to set a limit of 100, you initially only receive up to 100 `DataEventType.ChildAdded` callbacks. If you have fewer than 100 items stored in your Firebase database, an `DataEventType.ChildAdded` callback fires for each item.

As items change, you receive `DataEventType.ChildAdded` callbacks for items that enter the query and `DataEventType.ChildRemoved` callbacks for items that drop out of it so that the total number stays at 100.

The following example demonstrates how example notes app retrieves a list of the 100 most recent modified notes by user:

```csharp
DatabaseReference notesNode = rootNode.GetChild ("notes").GetChild (user.Uid).GetChild (folderUid);

// First 100 notes sorted by their last time modified in ascending order
DatabaseQuery notesByDate = notesNode.GetQueryOrderedByChild ("lastModified").GetQueryLimitedToFirst (100);
notesByDate.ObserveEvent (DataEventType.ChildAdded, (snapshot) => {
	var data = snapshot.GetValue<NSDictionary> ();
	var content = data ["content"].ToString ();
	var created = data ["created"].ToString ();
	var lastModified = data ["lastModified"].ToString ();
	var title = data ["title"].ToString ();
	
	var note = new Note {
		Content = content,
		Created = created,
		LastModified = lastModified,
		Title = title
	}
	
	notes.Add (note);

	TableView.ReloadData ();
});
```

### Filter by key or value

You can use `GetQueryStartingAtValue`, `GetQueryEndingAtValue`, and `GetQueryEqualToValue` to choose arbitrary starting, ending, and equivalence points for queries. This can be useful for paginating data or finding items with children that have a specific value.

## How query data is ordered

This section explains how data is sorted by each of the order-by methods in the `DatabaseQuery` class.

### GetQueryOrderedByKey method

When using `GetQueryOrderedByKey` to sort your data, data is returned in ascending order by key.

1. Children with a key that can be parsed as a 32-bit integer come first, sorted in ascending order.
2. Children with a string value as their key come next, sorted [lexicographically][9] in ascending order.

### GetQueryOrderedByValue method

When using `GetQueryOrderedByValue`, children are ordered by their value. The ordering criteria are the same as in `GetQueryOrderedByChild`, except the value of the node is used instead of the value of a specified child key.

### GetQueryOrderedByChild method

When using `GetQueryOrderedByChild`, data that contains the specified child key is ordered as follows:

1. Children with a `null` value for the specified child key come first.
2. Children with a value of `false` for the specified child key come next. If multiple children have a value of false, they are sorted [lexicographically][9] by key.
3. Children with a value of `true` for the specified child key come next. If multiple children have a value of true, they are sorted lexicographically by key.
4. Children with a numeric value come next, sorted in ascending order. If multiple children have the same numerical value for the specified child node, they are sorted by key.
5. Strings come after numbers and are sorted lexicographically in ascending order. If multiple children have the same value for the specified child node, they are ordered lexicographically by key.
6. Objects come last and are sorted lexicographically by key in ascending order.

## Offline Capabilities on iOS

Firebase apps work great offline and we have several features to make the experience even better. Enabling disk persistence allows your app to keep all of its state even after an app restart. We provide several tools for monitoring presence and connectivity state.

### Disk Persistence

Firebase apps automatically handle temporary network interruptions for you. Cached data will still be available while offline and your writes will be resent when network connectivity is recovered. Enabling disk persistence allows our app to also keep all of its state even after an app restart. We can enable disk persistence with just one line of code:

```csharp
Database.DefaultInstance.PersistenceEnabled = true;
```

With disk persistence enabled, our synced data and writes will be persisted to disk across app restarts and our app should work seamlessly in offline situations.

### Persistence Behavior

By enabling persistence, any data that we sync while online will be persisted to disk and available offline, even when we restart the app. This means our app will work as it would online using the local data stored in the cache. Listener callbacks will continue to fire for local updates.

The Firebase Database client automatically keeps a queue of all write operations that are performed while our application is offline. When persistence is enabled, this queue will also be persisted to disk so all of our writes will be available when we restart the app. When the app regains connectivity, all of the operations will be sent to the server.

If our app uses [Firebase Authentication][3], the client will persist the user's authentication token across restarts. If the auth token expires while our app is offline, the client will pause our write operations until we re-authenticate, else our writes might fail due to security rules.

### Keeping Data Fresh

The Firebase Database synchronizes and stores a local copy of the data for active listeners. In addition, you can keep specific locations in sync:

```csharp
DatabaseReference foldersNode = rootNode.GetChild ("folders").GetChild (AppDelegate.UserUid);
foldersNode.KeepSynced (true);
```

The client will automatically download the data at these locations and keep it in sync even if the reference has no active listeners. You can turn synchronization back off with the following line of code:

```csharp
foldersNode.KeepSynced (false);
```

By default, 10MB of previously synced data will be cached. This should be enough for most applications. If the cache outgrows its configured size, the Firebase Database will purge data that has been used least recently. Data that is kept in sync, will not be purged from the cache.

### Querying Data Offline

The Firebase Database stores data returned from a query for use when offline. For queries constructed while offline, the Firebase Database continues to work for previously loaded data. If the requested data hasn't loaded, the Firebase Database loads data from the local cache. When we come back online our data will load and reflect the query.

For example, here we have a piece of code that queries for the last four items in our Firebase Database of notes:

```csharp
DatabaseReference notesNode = rootNode.GetChild ("notes").GetChild (user.Uid).GetChild (folderUid);

// Last 4 notes sorted by their last time modified
DatabaseQuery notesByDate = notesNode.GetQueryOrderedByChild ("lastModified").GetQueryLimitedToLast (4);
notesByDate.ObserveEvent (DataEventType.ChildAdded, (snapshot) => {
	var data = snapshot.GetValue<NSDictionary> ();
	var content = data ["content"].ToString ();
	var created = data ["created"].ToString ();
	var lastModified = data ["lastModified"].ToString ();
	var title = data ["title"].ToString ();
	
	var note = new Note {
		Content = content,
		Created = created,
		LastModified = lastModified,
		Title = title
	}
	
	notes.Add (note);

	TableView.ReloadData ();
});
```

Now let's assume that the user loses connection, goes offline, and restarts the app. While still offline, we query for the last two items from the same location. This query will successfully return the last two items because we had loaded all four in the query above:

```csharp
DatabaseReference notesNode = rootNode.GetChild ("notes").GetChild (user.Uid).GetChild (folderUid);

// Last 2 notes sorted by their last time modified
DatabaseQuery notesByDate = notesNode.GetQueryOrderedByChild ("lastModified").GetQueryLimitedToLast (2);
notesByDate.ObserveEvent (DataEventType.ChildAdded, (snapshot) => {
	var data = snapshot.GetValue<NSDictionary> ();
	var content = data ["content"].ToString ();
	var created = data ["created"].ToString ();
	var lastModified = data ["lastModified"].ToString ();
	var title = data ["title"].ToString ();
	
	var note = new Note {
		Content = content,
		Created = created,
		LastModified = lastModified,
		Title = title
	}
	
	notes.Add (note);

	TableView.ReloadData ();
});
```

In the above example, the Firebase Database client raises `DataEventType.ChildAdded` events for the latest modified notes, via our persisted cache. But it will not raise a `DataEventType.Value` event, since we've never done that query while online.

If we were to request the last six items while offline, we'd get `DataEventType.ChildAdded` events for the four cached items straight away. When we come back online, the Firebase Realtime Database client will synchronize with the server and we'll get the final two `DataEventType.ChildAdded` and the `DataEventType.Value` events.

### Handling Transactions Offline

Any transactions that are performed while our app is offline, will be queued. Once the app regains network connectivity, the transactions will be sent to the server.

It's important to know that **Transactions are not persisted across app restarts**. Even with persistence enabled, transactions are not persisted across app restarts. So you cannot rely on transactions done offline being committed to your Firebase Database. To provide the best user experience, your app should show that a transaction has not been saved into your Firebase Database yet, or make sure your app remembers them manually and executes them again after an app restart.

## Managing Presence

In realtime applications it is often useful to detect when clients connect and disconnect. For example, we may want to mark a user as 'offline' when their client disconnects.

Firebase Database clients provide simple primitives that allow data to be written to the database when a client disconnects from the Firebase Database servers. These updates will occur whether the client disconnects cleanly or not, so we can rely on them to clean up data even if a connection is dropped or a client crashes. All write operations, including setting, updating, and removing, can be performed upon a disconnection.

Here is a simple example of writing data upon disconnection by using the **OnDisconnect** primitive:

```csharp
DatabaseReference disconnectedNode = rootNode.GetChild ("disconnected");
// Write a string when this client loses connection
disconnectedNode.SetValueOnDisconnect<NSString> (new NSString ("I disconnected!"));
```

### How OnDisconnect methods works

When an **OnDisconnect** operation is established, it lives on the Firebase Database server. The server checks security to make sure the user can perform the write event requested, and informs the client if it is invalid. The server then monitors the connection. If at any point it times out, or is actively closed by the client, the server checks security a second time (to make sure the operation is still valid) and then invokes the event.

The client can use the callback on the write operation to ensure the **OnDisconnect** was correctly attached:

```csharp
rootNode.RemoveValueOnDisconnect ((error, reference) => {
	if (error != null) {
		Console.WriteLine ($"Could not establish onDisconnect event: {error.LocalizedDescription}");
	}
});
```

An **OnDisconnect** event can also be canceled by calling `CancelDisconnectOperations` method:

```csharp
rootNode.CancelDisconnectOperations ();
```

## Detecting Connection State

For many presence-related features, it is useful for a client to know when it is online or offline. Firebase Database clients provide a special location at **/.info/connected** which is updated every time the client's connection state changes. Here is an example:

```csharp
DatabaseReference connectedNode = Database.DefaultInstance.GetReferenceFromPath (".info/connected");
connectedNode.ObserveEvent (DataEventType.Value, (snapshot) => {
	var connected = snapshot.GetValue<NSNumber> ().BoolValue;

	if (connected)
		Console.WriteLine ("Connected");
	else 
		Console.WriteLine ("Not connected");
});
```

**/.info/connected** is a boolean value which is not synchronized between clients because the value is dependent on the state of the client. In other words, if one client reads **/.info/connected** as `false`, this is no guarantee that a separate client will also read `false`.

## Handling Latency

### Server Timestamps

The Firebase Database servers provide a mechanism to insert timestamps generated on the server as data. This feature, combined with **OnDisconnect**, provides an easy way to reliably make note of the time at which a client disconnected:

```csharp
DatabaseReference userLastOnlineNode = Database.DefaultInstance.GetReferenceFromPath ($"users/{user.Uid}/lastOnline");
userLastOnlineNode.SetValueOnDisconnect<NSDictionary> (ServerValue.Timestamp);
```

### Clock Skew

While `ServerValue.Timestamp` is much more accurate, and preferable for most read/write ops, it can occasionally be useful to estimate the clients clock skew with respect to the Firebase Database's servers. We can attach a callback to the location **/.info/serverTimeOffset** to obtain the value, in milliseconds, that Firebase Database clients will add to the local reported time (epoch time in milliseconds) to estimate the server time. Note that this offset's accuracy can be affected by networking latency, and so is useful primarily for discovering large (> 1 second) discrepancies in clock time:

```csharp
DatabaseReference offsetNode = Database.DefaultInstance.GetReferenceFromPath (".info/serverTimeOffset");
offsetNode.ObserveSingleEvent (DataEventType.Value, (snapshot) => {
	var offset = snapshot.GetValue<NSNumber> ().DoubleValue;

	var ticksFrom1970 = new System.DateTime (1970, 1, 1, 0, 0, 0, 0).Ticks;
	var ticksUtc = System.DateTime.UtcNow.Ticks;
	var epoch = (ticksUtc - ticksFrom1970) / System.TimeSpan.TicksPerMillisecond;

	var estimatedServerTimeMs = epoch + offset;
});
```

## Best practices

To learn about Firebase Database best practices, please visit this [Firebase post][11].

### Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][12])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/database/ios/start) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://components.xamarin.com/view/firebaseiosanalytics
[4]: https://firebase.google.com/docs/database/security/quickstart#sample-rules
[5]: https://firebase.google.com/docs/database/ios/structure-data#fanout
[6]: https://firebase.google.com/docs/reference/ios/firebasedatabase/interface_f_i_r_database_reference.html#a796bff455159479a44b225eeaa2ba9d6
[7]: https://firebase.google.com/docs/database/security/indexing-data
[8]: https://firebase.google.com/docs/database/ios/lists-of-data#data_order
[9]: http://en.wikipedia.org/wiki/Lexicographical_order
[10]: https://firebase.google.com/docs/database/ios/structure-data
[11]: https://firebase.googleblog.com/2015/10/best-practices-for-ios-uiviewcontroller_6.html
[12]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689
[13]: https://firebase.google.com/docs/database/security/
[14]: https://firebase.google.com/docs/database/security/quickstart
[15]: https://firebase.google.com/docs/database/security/securing-data
[16]: https://firebase.google.com/docs/database/security/user-security
[17]: https://firebase.google.com/docs/database/security/indexing-data
[18]: https://firebase.google.com/docs/database/rest/app-management
