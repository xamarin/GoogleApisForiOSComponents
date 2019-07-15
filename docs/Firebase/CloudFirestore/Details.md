Use Firebase flexible, scalable NoSQL cloud database to store and sync data for client- and server-side development.

Firebase Cloud Firestore is a flexible, scalable database for mobile, web, and server development from Firebase and Google Cloud Platform. Like Firebase Database, it keeps your data in sync across client apps through realtime listeners and offers offline support for mobile and web so you can build responsive apps that work regardless of network latency or Internet connectivity. Firebase Cloud Firestore also offers seamless integration with other Firebase and Google Cloud Platform products, including Cloud Functions.

_**Note:**_ _Firebase Cloud Firestore is currently in beta release. Feature availability and support for product integrations and platforms will continue to improve as the product matures. For more information on existing limitations in Cloud Firestore, see the [limits and quotas documentation](https://firebase.google.com/docs/firestore/quotas)._

## Key capabilities

|   |   |
|--:|---|
| Flexibility | The Firebase Cloud Firestore data model supports flexible, hierarchical data structures. Store your data in documents, organized into collections. Documents can contain complex nested objects in addition to subcollections. |
| Expressive querying | In Firebase Cloud Firestore, you can use queries to retrieve individual, specific documents or to retrieve all the documents in a collection that match your query parameters. Your queries can include multiple, chained filters and combine filtering and sorting. They're also indexed by default, so query performance is proportional to the size of your result set, not your data set. |
| Realtime updates | Like Firebase Database, Firebase Cloud Firestore uses data synchronization to update data on any connected device. However, it's also designed to make simple, one-time fetch queries efficiently. |
| Offline support | Firebase Cloud Firestore caches data that your app is actively using, so the app can write, read, listen to, and query data even if the device is offline. When the device comes back online, Firebase Cloud Firestore synchronizes any local changes back to Firebase Cloud Firestore. |
| Designed to scale | Firebase Cloud Firestore brings you the best of Google Cloud Platform's powerful infrastructure: automatic multi-region data replication, strong consistency guarantees, atomic batch operations, and real transaction support. We've designed Firebase Cloud Firestore to handle the toughest database workloads from the world's biggest apps. |

## How does it work?

Firebase Cloud Firestore is a cloud-hosted, NoSQL database that your iOS, Android, and web apps can access directly via native SDKs.

Following Firebase Cloud Firestore's NoSQL data model, you store data in documents that contain fields mapping to values. These documents are stored in collections, which are containers for your documents that you can use to organize your data and build queries. Documents support many different [data types](https://firebase.google.com/docs/firestore/manage-data/data-types), from simple strings and numbers, to complex, nested objects. You can also create subcollections within documents and build hierarchical data structures that scale as your database grows. The Firebase Cloud Firestore data model supports whatever data structure works best for your app.

Additionally, querying in Firebase Cloud Firestore is expressive, efficient, and flexible. Create shallow queries to retrieve data at the document level without needing to retrieve the entire collection, or any nested subcollections. Add sorting, filtering, and limits to your queries or cursors to paginate your results. To keep data in your apps current, without retrieving your entire database each time an update happens, add realtime listeners. Adding realtime listeners to your app notifies you with a data snapshot whenever the data your client apps are listening to changes, retrieving only the new changes.

Protect access to your data in Firebase Cloud Firestore with Firebase Authentication and Firebase Cloud Firestore Security Rules for Android, iOS, and JavaScript, or Identity and Access Management (IAM) for server-side languages.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/firestore/) to see original Firebase documentation._</sub>