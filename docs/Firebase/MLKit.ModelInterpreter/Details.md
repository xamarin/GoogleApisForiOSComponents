# Custom Models

If you're an experienced ML developer and ML Kit's pre-built models don't meet your needs, you can use a custom [TensorFlow Lite][1] model with ML Kit.

Host your TensorFlow Lite models using Firebase or package them with your app. Then, use the ML Kit SDK to perform inference using the best-available version of your custom model. If you host your model with Firebase, ML Kit automatically updates your users with the latest version.

## Key capabilities

|  |  |
|--|--|
| **TensorFlow Lite model hosting** | Host your models using Firebase to reduce your app's binary size and to make sure your app is always using the most recent version available of your model. |
| **On-device ML inference** | Perform inference in an iOS or Android app by using the ML Kit SDK to run your custom TensorFlow Lite model. The model can be bundled with the app, hosted in the Cloud, or both. |
| **Automatic model fallback** | Specify multiple model sources; use a locally-stored model when the Cloud-hosted model is unavailable. |
| **Automatic model updates** | Configure the conditions under which your app automatically downloads new versions of your model: when the user's device is idle, is charging, or has a Wi-Fi connection. |

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/ml-kit/use-custom-models) to see original Firebase documentation._</sub>

[1]: https://www.tensorflow.org/mobile/tflite/

