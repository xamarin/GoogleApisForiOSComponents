# Get Started

Firebase Storage lets you upload and share user generated content, such as images and video, which allows you to build rich media content into your apps. Firebase Storage stores this data in a [Google Cloud Storage][1] bucket, an exabyte scale object storage solution with high availability and global redundancy. Firebase Storage lets you securely upload these files directly from mobile devices and web browsers, handling spotty networks with ease.

## Table of content

- [Get Started](#get-started)
	- [Table of content](#table-of-content)
	- [Add Firebase to your app](#add-firebase-to-your-app)
	- [Configure Storage in your app](#configure-storage-in-your-app)
	- [Recommended documentation to get a better understanding of the Security & Rules of Firebase Storage](#recommended-documentation-to-get-a-better-understanding-of-the-security-rules-of-firebase-storage)
	- [Set up public access](#set-up-public-access)
	- [Advanced setup](#advanced-setup)
		- [Use multiple storage buckets](#use-multiple-storage-buckets)
		- [Working with imported buckets](#working-with-imported-buckets)
		- [Use a custom Firebase App](#use-a-custom-firebase-app)
- [Create a Storage Reference](#create-a-storage-reference)
	- [Create a Reference](#create-a-reference)
	- [Navigate with References](#navigate-with-references)
	- [Reference Properties](#reference-properties)
	- [Limitations on References](#limitations-on-references)
- [Upload Files on iOS](#upload-files-on-ios)
	- [Create a Reference](#create-a-reference)
	- [Upload Files](#upload-files)
		- [Upload from data in memory](#upload-from-data-in-memory)
		- [Upload from a local file](#upload-from-a-local-file)
	- [Add File Metadata](#add-file-metadata)
- [Download Files on iOS](#download-files-on-ios)
	- [Create a Reference](#create-a-reference)
	- [Download Files](#download-files)
		- [Download in memory](#download-in-memory)
		- [Download to a local file](#download-to-a-local-file)
		- [Generate a download Url](#generate-a-download-url)
- [Manage Uploads and Downloads](#manage-uploads-and-downloads)
	- [Monitor Upload and Download Progress](#monitor-upload-and-download-progress)
	- [Error Handling](#error-handling)
- [Use File Metadata on iOS](#use-file-metadata-on-ios)
	- [Get File Metadata](#get-file-metadata)
	- [Update File Metadata](#update-file-metadata)
	- [Error Handling](#error-handling)
	- [Custom Metadata](#custom-metadata)
		- [File Metadata Properties](#file-metadata-properties)
- [Delete Files on iOS](#delete-files-on-ios)
	- [Delete a File](#delete-a-file)
- [Handle Errors](#handle-errors)
		- [Handle Error Messages](#handle-error-messages)
- [Extend Cloud Storage with Cloud Functions](#extend-cloud-storage-with-cloud-functions)
- [Integrate with Google Cloud Platform](#integrate-with-google-cloud-platform)
- [Known issues](#known-issues)

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][2], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][3].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][3] again at any time.

## Configure Storage in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Xamarin Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action. 
3. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` namespace):

```csharp
App.Configure ();
```

## Recommended documentation to get a better understanding of the Security & Rules of Firebase Storage

Before you continue, I invite you to read the following docs to make your coding easier:

* [Understand Security][4]
* [Get Started][5]
* [Secure Files][6]
* [User Based Security][7]

## Set up public access

Cloud Storage for Firebase provides a declarative rules language that allows you to define how your data should be structured, how it should be indexed, and when your data can be read from and written to. By default, read and write access to Storage is restricted so only authenticated users can read or write data. To get started without setting up [Authentication][8], you can [configure your rules for public access][9].

This does make Storage open to anyone, even people not using your app, so be sure to restrict your Storage again when you set up authentication.

## Advanced setup

There are a few use cases that require additional setup:

Using storage buckets in [multiple geographic regions][10]
Using storage buckets in [different storage classes][11]
Using storage buckets with multiple authenticated users in the same app

The first use case is perfect if you have users across the world, and want to store their data near them. For instance, you can create buckets in the US, Europe, and Asia to store data for users in those regions to reduce latency.

The second use case is helpful if you have data with different access patterns. For instance: you can set up a multi-regional or regional bucket that stores pictures or other frequently accessed content, and a nearline or coldline bucket that stores user backups or other infrequently accessed content.

In either of these use cases, you'll want to [use multiple storage buckets](#use-multiple-storage-buckets).

The third use case is useful if you're building an app, like Google Drive, which lets users have multiple logged in accounts (for instance, a personal account and a work account). You can [use a custom Firebase App](#use-a-custom-firebase-app) instance to authenticate each additional account.

### Use multiple storage buckets

If you want to use a storage bucket other than the default provided above, or use multiple storage buckets in a single app, you can create an instance of `Storage` that references your custom bucket:

```csharp
// Get a non-default Storage bucket
var storage = Storage.From ("gs://my-custom-bucket");
```

### Working with imported buckets

When importing an existing Cloud Storage bucket into Firebase, you'll have to grant Firebase the ability to access these files using the `gsutil` tool, included in the [Google Cloud SDK][12]:

```
gsutil -m acl ch -r -u firebase-storage@system.gserviceaccount.com:O gs://<your-cloud-storage-bucket>
```

This does not affect newly created buckets, as those have the default access control set to allow Firebase. This is a temporary measure, and will be performed automatically in the future.

### Use a custom Firebase App

If you're building a more complicated app using a custom `FirebaseApp`, you can create an instance of Storage initialized with that app:

```csharp
// Get the default bucket from a custom FirebaseApp
storage = Storage.From (customApp);

// Get a non-default bucket from a custom FirebaseApp
storage = Storage.From (customApp, "gs://my-custom-bucket");
```

---

# Create a Storage Reference

Your files are stored in a [Google Cloud Storage][1] bucket. The files in this bucket are presented in a hierarchical structure, just like the file system on your local hard disk, or the data in the Firebase Database. By creating a reference to a file, your app gains access to it. These references can then be used to upload or download data, get or update metadata or delete the file. A reference can either point to a specific file or to a higher level in the hierarchy.

## Create a Reference

Create a reference to upload, download, or delete a file, or to get or update its metadata. A reference can be thought of as a pointer to a file in the cloud. References are lightweight, so you can create as many as you need. They are also reusable for multiple operations.

References are created from the storage service on your Firebase app by calling the `GetReferenceFromUrl` method and passing in a URL of the form **gs://\<your-firebase-storage-bucket\>**. You can find this URL in the Storage section of the [Firebase console][2].

```csharp
// Get a reference to the storage service, using the default Firebase App
var storage = Storage.DefaultInstance;

// Create a storage reference from our storage service
StorageReference rootRef = storage.GetReferenceFromUrl ("gs://<your-firebase-storage-bucket>")

// This is the same result as above
StorageReference rootRef = storage.GetRootReference ();
```

You can create a reference to a location lower in the tree, say **images/space.jpg**, by using the `GetChild` method on an existing reference:

```csharp
// Create a child reference
// imagesRef now points to "images" ("gs://<your-firebase-storage-bucket>/images")
StorageReference imagesRef = rootRef.GetChild ("images");

// Child references can also take paths delimited by '/'
// spaceRef now points to "images/space.jpg" ("gs://<your-firebase-storage-bucket>/images/space.jpg")
// imagesRef still points to "images"
StorageReference spaceRef = rootRef.GetChild ("images/space.jpg");

// This is equivalent to creating the full reference
StorageReference spaceRef = storage.GetReferenceFromUrl ("gs://<your-firebase-storage-bucket>/images/space.jpg");
```

## Navigate with References

You can also use the `Parent` and `Root` properties to navigate up in our file hierarchy. `Parent` navigates up one level, while `Root` navigates all the way to the top.

```csharp
// Parent allows us to move to the parent of a reference
// imagesRef now points to 'images'
StorageReference imagesRef = spaceRef.Parent;

// Root allows us to move all the way back to the top of our bucket
// rootRef now points to the root
StorageReference *rootRef = spaceRef.Parent;
```

`GetChild` method, `Parent` and `Root` properties can be chained together multiple times, as each returns a reference. The exception is the `Parent` of `rootRef`, which is `null`:

```csharp
// References can be chained together multiple times
// earthRef points to "images/earth.jpg"
StorageReference earthRef = spaceRef.Parent.GetChild ("earth");

// nullRef is null, since the Parent of Root is null
StorageReference nullRef = spaceRef.Root.Parent;
```

## Reference Properties

You can inspect references to better understand the files they point to using the `FullPath`, `Name`, and `Bucket` properties. These properties get the file's full path, name, and bucket:

```csharp
// Reference's path is: "images/space.jpg"
// This is analogous to a file path on disk
spaceRef.FullPath;

// Reference's name is the last segment of the full path: "space.jpg"
// This is analogous to the file name
spaceRef.Name;

// Reference's bucket is the name of the storage bucket where files are stored
spaceRef.Bucket;
```

## Limitations on References

Reference paths and names can contain any sequence of valid Unicode characters, but certain restrictions are imposed including:

1. Total length of reference.FullPath must be between 1 and 1024 bytes when UTF-8 encoded.
2. No Carriage Return or Line Feed characters.
3. Avoid using **#**, **[**, **]**, **\***, or **?**, as these do not work well with other tools such as the Firebase Database or [gsutil][13].

---

# Upload Files on iOS

Firebase Storage allows developers to quickly and easily upload files to a [Google Cloud Storage][1] bucket provided and managed by Firebase.

> ![note_icon] **_Note_**: _By default, Firebase Storage buckets require Firebase Authentication to upload files. You can [change your Firebase Storage Security Rules][9] to allow unauthenticated access. Since the default Google App Engine app and Firebase share this bucket, configuring public access may make newly uploaded App Engine files publicly accessible as well. Be sure to restrict access to your Storage bucket again when you set up authentication._

## Create a Reference

To upload a file, first create a Firebase Storage reference to the location in Firebase Storage you want to upload the file to.

You can create a reference by appending child paths to the storage root:

```csharp
// Create a root reference
StorageReference rootRef = storage.GetRootReference ();

// Create a reference to "mountains.jpg"
StorageReference mountainsRef = root.GetChild ("mountains.jpg");

// Create a reference to 'images/mountains.jpg'
StorageReference mountainImagesRef = root.GetChild ("images/mountains.jpg");

// While the file names are the same, the references point to different files
mountainsRef.Name == mountainImagesRef.Name; // true
mountainsRef.FullPath == mountainImagesRef.FullPath; // false
```

You **cannot upload data** with a reference to the root of your Google Cloud Storage bucket. Your reference must point to a child URL.

## Upload Files

Once you have a reference, you can upload files to Firebase Storage in two ways:

1. Upload from `NSData` in memory.
2. Upload from an `NSUrl` representing a file on device.

### Upload from data in memory

The `PutData` method is the simplest way to upload a file to Firebase Storage. `PutData` takes an `NSData` object and returns a `StorageUploadTask`, which you can use to manage your upload and monitor its status:

```csharp
// Data in memory
NSData data = ...

// Create a reference to the file you want to upload
StorageReference riversRef = rootRef.GetChild ("images/rivers.jpg");

// Upload the file to the path "images/rivers.jpg"
StorageUploadTask uploadTask = riversRef.PutData (data, null, HandleStorageGetPutUpdateCompletion);

void HandleStorageGetPutUpdateCompletion (StorageMetadata metadata, NSError error)
{
	if (error != null) {
		// Uh-oh, an error occurred!
		return;
	}

	// Metadata contains file metadata such as size, content-type, and download URL.
	var downloadUrl = metadata.DownloadUrl;
}
```

### Upload from a local file

You can upload local files on the devices, such as photos and videos from the camera, with the `PutFile` method. `PutFile` takes an `NSUrl` and returns a `StorageUploadTask`, which you can use to manage your upload and monitor its status:

```csharp
// Data in memory
NSUrl localFile = ...

// Create a reference to the file you want to upload
StorageReference riversRef = rootRef.GetChild ("images/rivers.jpg");

// Upload the file to the path "images/rivers.jpg"
StorageUploadTask uploadTask = riversRef.PutFile (localFile, null, HandleStorageGetPutUpdateCompletion);

void HandleStorageGetPutUpdateCompletion (StorageMetadata metadata, NSError error)
{
	if (error != null) {
		// Uh-oh, an error occurred!
		return;
	}

	// Metadata contains file metadata such as size, content-type, and download URL.
	var downloadUrl = metadata.DownloadUrl;
}
```

If you want to actively manage your upload, you can use the `PutData` or `PutFile` methods and observe the upload task, rather than using the completion handler. See [Manage Uploads and Downloads](#manage-uploads-and-downloads) section below for more information.

## Add File Metadata

You can also include metadata when you upload files. This metadata contains typical file metadata properties such as `Name`, `Size`, and `ContentType` (commonly referred to as MIME type). The `PutFile` method automatically infers the content type from the `NSUrl` filename extension, but you can override the auto-detected type by specifying `ContentType` in the metadata. If you do not provide a `ContentType` and Cloud Storage cannot infer a default from the file extension, Firebase Storage uses **application/octet-stream**. See the [Use File Metadata](#use-file-metadata) section below for more information about file metadata.

```csharp
// Create storage reference
StorageReference mountainsRef = rootRef.GetChild ("images/mountains.jpg");

// Create file metadata including the content type
var imageMetadata = new StorageMetadata { ContentType = "image/jpeg" };

// Upload data and metadata
StorageUploadTask uploadTask = mountainsRef.PutData (data, metadata);

// Upload file and metadata
StorageUploadTask uploadTask = mountainsRef.PutFile (localFile, metadata);
```

---

# Download Files on iOS

Firebase Storage allows developers to quickly and easily download files from a [Google Cloud Storage][1] bucket provided and managed by Firebase.

> ![note_icon] **_Note_**: _By default, Cloud Storage buckets require Firebase Authentication to download files. You can change your [Firebase Storage Security Rules][9] to allow unauthenticated access. Since the default Google App Engine app and Firebase share this bucket, configuring public access may make newly uploaded App Engine files publicly accessible as well. Be sure to restrict access to your Storage bucket again when you set up authentication._

## Create a Reference

To download a file, first create a Firebase Storage reference to the file you want to download.

You can create a reference by appending child paths to the storage root, or you can create a reference from an existing **gs://** or **https://** URL referencing an object in Cloud Storage:

```csharp
// Create a reference with an initial file path and name
var pathRef = storage.GetReferenceFromPath ("images/stars.jpg");

// Create a reference from a Google Cloud Storage URI
var gsRef = storage.GetReferenceFromUrl ("gs://<your-firebase-storage-bucket>/images/stars.jpg");

// Create a reference from an HTTPS URL
// Note that in the URL, characters are URL escaped!
var httpRef = storage.GetReferenceFromUrl ("https://firebasestorage.googleapis.com/b/bucket/o/images%20stars.jpg");
```

## Download Files

Once you have a reference, you can download files from Firebase Storage in three ways:

1. Download to `NSData` in memory.
2. Download to an `NSUrl` representing a file on device.
3. Generate an `NSUrl` representing the file online.

### Download in memory

Download the file to an `NSData` object in memory using the `GetData` method. This is the easiest way to quickly download a file, but it must load entire contents of your file into memory. If you request a file larger than your app's available memory, your app will crash. To protect against memory issues, make sure to set the max size to something you know your app can handle, or use another download method:

```csharp
// Create a reference to the file you want to download
StorageReference islandRef = rootRef.GetChild ("images/island.jpg");

// Download in memory with a maximum allowed size of 1MB (1 * 1024 * 1024 bytes)
islandRef.GetData (1 * 1024 * 1024, HandleStorageGetDataCompletion);

void HandleStorageGetDataCompletion (NSData data, NSError error)
{
	if (error != nil) {
		// Uh-oh, an error occurred!
		return;
	} 

	// Data for "images/island.jpg" is returned
	var islandImage = UIImage.LoadFromData (data);
}
```

### Download to a local file

The `WriteToFile` method downloads a file directly to a local device. Use this if your users want to have access to the file while offline or to share in a different app. `WriteToFile` returns an `StorageDownloadTask` which you can use to manage your download and monitor the status of the upload:

```csharp
// Create a reference to the file you want to download
StorageReference islandRef = rootRef.GetChild ("images/island.jpg");

// Create local filesystem Url
var localUrl = NSUrl.FromString ("path/to/images/island.jpg");

// Download to the local filesystem
StorageDownloadTask downloadTask = islandRef.WriteToFile (localUrl, HandleStorageWriteToFileCompletion);

void HandleStorageWriteToFileCompletion (NSUrl url, NSError error)
{
	if (error != null) {
		// Uh-oh, an error occurred!
		return;
	}

	// Local file Url for "images/island.jpg" is returned
}
```

If you want to actively manage your download, you can use the `WriteToFile` method and observe the download task, rather than use the completion handler. See [Manage Uploads and Downloads](#manage-uploads-and-downloads) section below for more information.

### Generate a download Url

If you already have download infrastructure based around Urls, or just want a Url to share, you can get the download Url for a file by calling the `GetDownloadUrl` method on a storage reference:

```csharp
// Create a reference to the file you want to download
StorageReference starsRef = rootRef.GetChild ("images/stars.jpg");

// Fetch the download Url
starsRef.GetDownloadUrl (HandleStorageDownloadUrlCompletion);

void HandleStorageDownloadUrlCompletion (NSUrl url, NSError error)
{
	if (error != null) {
		// Handle any errors
		return;
	}

	// Get the download URL for 'images/stars.jpg'
}
```

An `async`/`await` version of this:

```csharp
// Create a reference to the file you want to download
StorageReference starsRef = rootRef.GetChild ("images/stars.jpg");

try {
	NSUrl url = await starsRef.GetDownloadUrlAsync ();

	// Get the download URL for 'images/stars.jpg'
} catch (NSErrorException ex) {
	// Handle any errors
}
```

---

# Manage Uploads and Downloads

In addition to starting uploads and downloads, you can pause, resume, and cancel uploads and downloads, using the `Pause`, `Resume`, and `Cancel` methods. These methods raise pause, resume, and cancel events that you can observe. Canceling an upload causes the upload to fail with an error indicating that the upload was canceled:

```csharp
// Start uploading/downloading a file
StorageUploadTask uploadTask = mountainsRef.PutFile (localFile, metadata);
StorageDownloadTask downloadTask = islandRef.WriteToFile (localUrl);

// Pause the upload/download
uploadTask.Pause ();
downloadTask.Pause ();

// Resume the upload/download
uploadTask.Resume ();
downloadTask.Resume ();

// Cancel the upload/download
uploadTask.Cancel ();
downloadTask.Cancel ();
```

## Monitor Upload and Download Progress

You can attach observers to `StorageUploadTask` in order to monitor the progress of the upload. Adding an observer returns a `string` that can be used to remove the observer:

```csharp
// Add a progress observer to an upload task
string observer = uploadTask.ObserveStatus (StorageTaskStatus.Progress, (snapshot) => {
      // A progress event occurred
});

// Add a progress observer to a download task
string observer = downloadTask.ObserveStatus (StorageTaskStatus.Progress, (snapshot) => {
	// A progress event occurred
});
```

These observers can be added to an `StorageTaskStatus` event:

| StorageTaskStatus Event        | Typical Usage |
|:------------------------------:|---------------|
| **StorageTaskStatus.Resume**   | This event fires when the task starts or resumes uploading/downloading, and is often used in conjunction with the `StorageTaskStatus.Pause` event. |
| **StorageTaskStatus.Progress** | This event fires any time data is uploading/downloading to Firebase Storage, and can be used to populate an upload progress indicator. |
| **StorageTaskStatus.Pause**    | This event fires any time the upload/download is paused, and is often used in conjunction with the `StorageTaskStatus.Resume` event. |
| **StorageTaskStatus.Success**  | This event fires when a upload/download has completed sucessfully. |
| **StorageTaskStatus.Failure**  | This event fires when a upload/download has failed. Inspect the error to determine the failure reason. |

When an event occurs, an `StorageTaskSnapshot` object is passed back. This snapshot is an immutable view of the task, at the time the event occurred. This object contains the following properties/methods:

| Name             | Kind         | Type                                           | Description |
|:----------------:|:------------:|:----------------------------------------------:|-------------|
| **Progress**     | **Property** | **NSProgress**                                 | An `NSProgress` object containing the progress of the upload/download. |
| **Error**        | **Property** | **NSError**                                    | An error that occurred during upload/download, if any. |
| **Metadata**     | **Property** | **StorageMetadata**                            | During upload contains metadata being uploaded. After an `StorageTaskStatus.Success` event, contains the uploaded file's metadata. `null` on downloads. |
| **GetTask\<T\>** | **Method**   | **StorageUploadTask/</br>StorageDownloadTask** | The task this is a snapshot of, which can be used to manage (pause, resume, cancel) the task. |
| **Reference**    | **Property** | **StorageReference**                           | The reference this task came from. |

You can also remove observers, either individually, by status, or by removing all of them:

```csharp
// Create a task listener handle
string observer = ...

// Remove an individual observer
uploadTask.RemoveObserver (observer);
downloadTask.RemoveObserver (observer);

// Remove all observers of a particular status
uploadTask.RemoveAllObservers (StorageTaskStatus.Progress);
downloadTask.RemoveAllObservers (StorageTaskStatus.Progress);

// Remove all observers
uploadTask.RemoveAllObservers ();
downloadTask.RemoveAllObservers ();
```

To prevent memory leaks, all observers are removed after an `StorageTaskStatus.Success` or `StorageTaskStatus.Failure` occurs.

## Error Handling

There are a number of reasons why errors may occur on upload, including the local file not existing, or the user not having permission to upload the desired file. You can find more information about errors in the [Handle Errors](#handle-errors) section below of the docs.

---

# Use File Metadata on iOS

After uploading a file to Firebase Storage reference, you can also get and update the file metadata, for example to update the content type. Files can also store custom key/value pairs with additional file metadata.

> ![note_icon] **_Note_**: _By default, Cloud Storage buckets require Firebase Authentication to get and update metadata. You can change your [Firebase Storage Security Rules][9] to allow unauthenticated access. Since the default Google App Engine app and Firebase share this bucket, configuring public access may make newly uploaded App Engine files publicly accessible as well. Be sure to restrict access to your Storage bucket again when you set up authentication._

## Get File Metadata

File metadata contains common properties such as `Name`, `Size`, and `ContentType` (often referred to as MIME type) in addition to some less common ones like `ContentDisposition` and `TimeCreated`. This metadata can be retrieved from a Firebase Storage reference using the `GetMetadata` method:

```csharp
// Create reference to the file whose metadata we want to retrieve
StorageReference forestRef = rootRef.GetChild ("images/forest.jpg");

// Get metadata properties
forestRef.GetMetadata (HandleStorageGetPutUpdateCompletion);

void HandleStorageGetPutUpdateCompletion (StorageMetadata metadata, NSError error)
{
	if (error != null) {
		// Uh-oh, an error occurred!
		return;
	}

	// Metadata now contains the metadata for 'images/forest.jpg'
}
```

An `async`/`await` version of this:

```csharp
// Create reference to the file whose metadata we want to retrieve
StorageReference forestRef = rootRef.GetChild ("images/forest.jpg");

try {
	StorageMetadata metadata = await starsRef.GetMetadataAsync ();

	// Metadata now contains the metadata for 'images/forest.jpg'
} catch (NSErrorException ex) {
	// Uh-oh, an error occurred!
}
```

## Update File Metadata

You can update file metadata at any time after the file upload completes by using the `UpdateMetadata` method. Refer to the [full list](#ile-metadata-properties) for more information on what properties can be updated. Only the properties specified in the metadata are updated, all others are left unmodified.

```csharp
// Create reference to the file whose metadata we want to change
StorageReference forestRef = rootRef.GetChild ("images/forest.jpg");

// Create file metadata to update
var newMetadata = new StorageMetadata {
	CacheControl = "public,max-age=300",
	ContentType = "image/jpeg"
};

// Update metadata properties
forestRef.UpdateMetadata (newMetadata, HandleStorageGetPutUpdateCompletion);

void HandleStorageGetPutUpdateCompletion (StorageMetadata metadata, NSError error)
{
	if (error != null) {
		// Uh-oh, an error occurred!
		return;
	}

	// Updated metadata for 'images/forest.jpg' is returned
}
```

An `async`/`await` version of this:

```csharp
// Create reference to the file whose metadata we want to change
StorageReference forestRef = rootRef.GetChild ("images/forest.jpg");

// Create file metadata to update
var newMetadata = new StorageMetadata {
	CacheControl = "public,max-age=300",
	ContentType = "image/jpeg"
};

try {
	StorageMetadata metadata = await forestRef.UpdateMetadataAsync (newMetadata);

	// Updated metadata for 'images/forest.jpg' is returned
} catch (NSErrorException ex) {
	// Uh-oh, an error occurred!
}
```

You can delete writable metadata properties by passing the empty string:

```csharp
var newMetadata = new StorageMetadata {
	ContentType = ""
};

// Delete the metadata property
forestRef.UpdateMetadata (newMetadata, HandleStorageGetPutUpdateCompletion);

void HandleStorageGetPutUpdateCompletion (StorageMetadata metadata, NSError error)
{
	if (error != null) {
		// Uh-oh, an error occurred!
		return;
	}

	// Updated metadata for 'images/forest.jpg' is returned
}
```

## Error Handling

There are a number of reasons why errors may occur on getting or updating metadata, including the local file not existing, or the user not having permission to upload the desired file. You can find more information about errors in the [Handle Errors](#handle-errors) section below of the docs.

## Custom Metadata

You can specify custom metadata as an `NSDictionary` containing `NSString` properties:

```csharp
object [] keys = { "location", "activity" };
object [] values = { "Yosemite, CA, USA", "Hiking" };
var customMetadata = NSDictionary.FromObjectsAndKeys (values, keys, keys.Length);

var metadata = NSDictionary.FromObjectAndKey (customMetadata, new NSString ("customMetadata"));
```

You can store app-specific data for each file in custom metadata, but Firebase highly recommend using a database (such as the [Firebase Database][14]) to store and synchronize this type of data.

### File Metadata Properties

A full list of metadata properties on a file is available below:

| Property               | Type                             | Writable |
|:----------------------:|:--------------------------------:|:--------:|
| **Bucket**             | string                           | NO       |
| **Generation**         | long                             | NO       |
| **Metageneration**     | long                             | NO       |
| **Path**               | string                           | NO       |
| **Name**               | string                           | NO       |
| **Size**               | long                             | NO       |
| **TimeCreated**        | NSDate                           | NO       |
| **Updated**            | NSDate                           | NO       |
| **Md5Hash**            | string                           | YES      |
| **CacheControl**       | string                           | YES      |
| **ContentDisposition** | string                           | YES      |
| **ContentEncoding**    | string                           | YES      |
| **ContentLanguage**    | string                           | YES      |
| **ContentType**        | string                           | YES      |
| **DownloadUrls**       | NSUrl []                         | NO       |
| **CustomMetadata**     | NSDictionary<NSString, NSString> | YES      |

> ![note_icon] _**Note:**_ _at present, setting the md5Hash property on upload doesn't affect the upload, as hash verification is not yet implemented._

---

# Delete Files on iOS

> ![note_icon] **_Note_**: _By default, Cloud Storage buckets require Firebase Authentication to delete files. You can change your [Firebase Storage Security Rules][9] to allow unauthenticated access. Since the default Google App Engine app and Firebase share this bucket, configuring public access may make newly uploaded App Engine files publicly accessible as well. Be sure to restrict access to your Storage bucket again when you set up authentication._

## Delete a File

To delete a file, first create a reference to that file. Then call the `Delete` method on that reference:

```csharp
// Create a reference to the file to delete
StorageReference desertRef = rootRef.GetChild ("images/desert.jpg");

// Delete the file
desertRef.Delete (HandleStorageDeleteCompletion);

void HandleStorageDeleteCompletion (NSError error)
{
	if (error != null) {
		// Uh-oh, an error occurred!
		return;
	} 

	// File deleted successfully
}
```

An `async`/`await` version of this:

```csharp
// Create a reference to the file to delete
StorageReference desertRef = rootRef.GetChild ("images/desert.jpg");

// Delete the file
desertRef.Delete (HandleStorageDeleteCompletion);

try {
	await desertRef.DeleteAsync ();

	// File deleted successfully
} catch (NSErrorException ex) {
	// Uh-oh, an error occurred!
}
```

> ![note_icon] **_Note:_** _Deleting a file is a permenant action! If you care about restoring deleted files, make sure to back up your files, or [enable object versioning][15] on your Google Cloud Storage bucket._

---

# Handle Errors 

Sometimes when you're building an app, things don't go as planned and an error occurs.

When in doubt, check the error returned, and see what the error message says.

> ![note_icon] **_Note_**: _By default, Cloud Storage buckets require Firebase Authentication to perform any action. You can change your [Firebase Storage Security Rules][9] to allow unauthenticated access. Since the default Google App Engine app and Firebase share this bucket, configuring public access may make newly uploaded App Engine files publicly accessible as well. Be sure to restrict access to your Storage bucket again when you set up authentication._

If you've checked the error message and have Storage Security Rules that allow your action, but are still struggling to fix the error, visit [Firebase Support page][16] and let them know how they can help.

### Handle Error Messages

There are a number of reasons why errors may occur, including the file not existing, the user not having permission to access the desired file, or the user cancelling the file upload.

To properly diagnose the issue and handle the error, here is a full list of all the errors our client will raise, and how they can occur.

| Name                                      | Reason |
|:-----------------------------------------:|--------|
| **StorageErrorCode.Unknown**              | An unknown error occurred. |
| **StorageErrorCode.ObjectNotFound**       | No object exists at the desired reference. |
| **StorageErrorCode.BucketNotFound**       | No bucket is configured for Firebase Storage. |
| **StorageErrorCode.ProjectNotFound**      | No project is configured for Firebase Storage. |
| **StorageErrorCode.QuotaExceeded**        | Quota on your Firebase Storage bucket has been exceeded. If you're on the free tier, upgrade to a paid plan. If you're on a paid plan, reach out to Firebase support.
| **StorageErrorCode.Unauthenticated**      | User is unauthenticated. Authenticate and try again. |
| **StorageErrorCode.Unauthorized**         | User is not authorized to perform the desired action. Check your rules to ensure they are correct. |
| **StorageErrorCode.RetryLimitExceeded**   | The maximum time limit on an operation (upload, download, delete, etc.) has been exceeded. Try uploading again. |
| **StorageErrorCode.NonMatchingChecksum**  | File on the client does not match the checksum of the file recieved by the server. Try uploading again. |
| **StorageErrorCode.Cancelled**            | User cancelled the operation.
| **StorageErrorCode.DownloadSizeExceeded** | Size of the downloaded file exceeds the amount of memory allocated for the download. Increase memory cap and try downloading again. |

---

# Extend Cloud Storage with Cloud Functions

You can trigger a function in response to the uploading, updating, or deleting of files and folders in Cloud Storage. For more information, read the following [documentation][17].

---

# Integrate with Google Cloud Platform

Firebase Storage is tightly integrated with [Google Cloud Platform][1]. The Firebase SDKs for Storage store files directly in [Google Cloud Storage buckets][18], and as your app grows, you can easily integrate other Cloud services, such as managed compute like App Engine or Cloud Functions, or machine learning APIs like Cloud Vision or Google Translate.

For more information, visit the following [documentation][19].

---

# Known issues

* App doesn't compile when `Incremental builds` is enabled. (Bug [#43689][20])

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/storage/ios/start) to see original Firebase documentation._</sub>

[1]: https://cloud.google.com/storage
[2]: https://firebase.google.com/console/
[3]: http://support.google.com/firebase/answer/7015592
[4]: https://firebase.google.com/docs/storage/security
[5]: https://firebase.google.com/docs/storage/security/start
[6]: https://firebase.google.com/docs/storage/security/secure-files
[7]: https://firebase.google.com/docs/storage/security/user-security
[8]: https://components.xamarin.com/view/firebaseiosauth
[9]: https://firebase.google.com/docs/storage/security/start#sample-rules
[10]: https://cloud.google.com/storage/docs/bucket-locations
[11]: https://cloud.google.com/storage/docs/storage-classes
[12]: https://cloud.google.com/sdk/docs/
[13]: https://cloud.google.com/storage/docs/gsutil
[14]: https://components.xamarin.com/view/firebaseiosdatabase
[15]: https://cloud.google.com/storage/docs/object-versioning#_Enabling
[16]: https://firebase.google.com/support
[17]: https://firebase.google.com/docs/storage/extend-with-functions
[18]: https://cloud.google.com/storage/docs/key-terms#buckets
[19]: https://firebase.google.com/docs/storage/gcp-integration
[20]: https://bugzilla.xamarin.com/show_bug.cgi?id=43689
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
