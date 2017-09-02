Firebase Storage is built for app developers who need to store and serve user-generated content, such as photos or videos.

Firebase Storage adds Google security to file uploads and downloads for your Firebase apps, regardless of network quality. You can use it to store images, audio, video, or other user-generated content. Firebase Storage is backed by Google Cloud Storage, a powerful, simple, and cost-effective object storage service.

## Key capabilities

|  |  |
|-:|--|
**Robust operations** | Firebase Storage performs uploads and downloads regardless of network quality. Uploads and downloads are robust, meaning they restart where they stopped, saving your users time and bandwidth.
**Strong security** | Firebase Storage integrates with Firebase Authentication to provide simple and intuitive authentication for developers. You can use our declarative security model to allow access based on filename, size, content type, and other metadata.
**High scalability** | Firebase Storage is built for exabyte scale when your app goes viral. Effortlessly grow from prototype to production using the same infrastructure that powers Spotify and Google Photos.

## How does it work?

Developers use the Firebase Storage SDK to upload and download files directly from clients. If the network connection is poor, the client is able to retry the operation right where it left off, saving your users time and bandwidth.

Firebase Storage stores your files in a [Google Cloud Storage][1] bucket, making them accessible through both Firebase and Google Cloud APIs. This allows you the flexibility to upload and download files from mobile clients via Firebase and do server-side processing such as image filtering or video transcoding using [Google Cloud Platform][2]. Firebase Storage scales automatically, meaning that there's no need to migrate from Firebase Storage to Google Cloud Storage or any other provider. Learn more about all the benefits of our [integration with Google Cloud Platform][3].

Firebase Storage integrates seamlessly with [Firebase Authentication][4] to identify users, and provides a [declarative security language][5] that lets you set access controls on individual files or groups of files, so you can make files as public or private as you want.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/storage/) to see original Firebase documentation._</sub>

[1]: https://cloud.google.com/storage
[2]: https://cloud.google.com/
[3]: https://firebase.google.com/docs/storage/gcp-integration
[4]: https://components.xamarin.com/view/firebaseiosauth
[5]: https://firebase.google.com/docs/storage/security/start
