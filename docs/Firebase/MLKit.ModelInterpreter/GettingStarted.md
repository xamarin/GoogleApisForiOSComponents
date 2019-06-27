# Use a TensorFlow Lite model for inference with ML Kit on iOS

You can use ML Kit to perform on-device inference with a TensorFlow Lite model.

ML Kit can use TensorFlow Lite models only on devices running iOS 9 and newer.

## Table of Content

- [Use a TensorFlow Lite model for inference with ML Kit on iOS](#use-a-tensorflow-lite-model-for-inference-with-ml-kit-on-ios)
	- [Table of Content](#table-of-content)
	- [Add Firebase to your app](#add-firebase-to-your-app)
	- [Configure MLKit in your app](#configure-mlkit-in-your-app)
	- [Host or bundle your model](#host-or-bundle-your-model)
		- [Host models on Firebase](#host-models-on-firebase)
		- [Bundle models with an app](#bundle-models-with-an-app)
	- [Load the model](#load-the-model)
		- [Configure a Firebase-hosted model source](#configure-a-firebase-hosted-model-source)
		- [Configure a local model source](#configure-a-local-model-source)
		- [Create an interpreter from your model sources](#create-an-interpreter-from-your-model-sources)
	- [Specify the model's input and output](#specify-the-models-input-and-output)
	- [Perform inference on input data](#perform-inference-on-input-data)
	- [Appendix: Model security](#appendix-model-security)
- [Use a custom TensorFlow Lite build](#use-a-custom-tensorflow-lite-build)
	- [Prerequisites](#prerequisites)
	- [Building the Tensorflow Lite library](#building-the-tensorflow-lite-library)
	- [Add your custom TensorFlow Lite framework](#add-your-custom-tensorflow-lite-framework)

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

## Configure MLKit in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Visual Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` namespace):

```csharp
App.Configure ();
```

Convert the TensorFlow model you want to use to TensorFlow Lite format. See [TOCO: TensorFlow Lite Optimizing Converter][3].

## Host or bundle your model

Before you can use a TensorFlow Lite model for inference in your app, you must make the model available to ML Kit. ML Kit can use TensorFlow Lite models hosted remotely using Firebase, bundled with the app binary, or both.

By hosting a model on Firebase, you can update the model without releasing a new app version, and you can use Remote Config and A/B Testing to dynamically serve different models to different sets of users.

If you choose to only provide the model by hosting it with Firebase, and not bundle it with your app, you can reduce the initial download size of your app. Keep in mind, though, that if the model is not bundled with your app, any model-related functionality will not be available until your app downloads the model for the first time.

By bundling your model with your app, you can ensure your app's ML features still work when the Firebase-hosted model isn't available.

> ![note_icon] _Before you use a custom model in a publicly-available app, be aware of the [security implications][4]._

### Host models on Firebase

To host your TensorFlow Lite model on Firebase:

1. In the **ML Kit** section of the [Firebase console][1], click the **Custom** tab.
2. Click **Add custom model** (or **Add another model**).
3. Specify a name that will be used to identify your model in your Firebase project, then upload the TensorFlow Lite model file (usually ending in `.tflite` or `.lite`).

After you add a custom model to your Firebase project, you can reference the model in your apps using the name you specified. At any time, you can upload a new TensorFlow Lite model, and your app will download the new model and start using it when the app next restarts. You can define the device conditions required for your app to attempt to update the model (see below).

### Bundle models with an app

To bundle your TensorFlow Lite model with your app, add the model file (usually ending in `.tflite` or `.lite`) into the **Resources** folder in your Visual Studio project, or, add it anywhere on your project tree and change **build action** behaviour to `Bundle Resource` by Right clicking/Build Action. The model file will be included in the app bundle and available to ML Kit.

## Load the model

To use your TensorFlow Lite model in your app, first configure ML Kit with the locations where your model is available: on the cloud using Firebase, in local storage, or both. If you specify both a local and cloud model source, ML Kit will use the cloud source if it is available, and fall back to the locally-stored model if the cloud source isn't available.

### Configure a Firebase-hosted model source

If you hosted your model with Firebase, register a `CloudModelSource` object, specifying the name you assigned the model when you uploaded it, and the conditions under which ML Kit should download the model initially and when updates are available:

```csharp
var conditions = new ModelDownloadConditions (true, true);
var cloudModelSource = new CloudModelSource ("my_cloud_model", true, conditions, conditions);
var registrationSuccessful = ModelManager.SharedInstance.Register (cloudModelSource);
```

### Configure a local model source

If you bundled the model with your app, register a `LocalModelSource` object, specifying the filename of the TensorFlow Lite model and assigning the model a name you will use in the next step:

```csharp
var modelPath = NSBundle.MainBundle.PathForResource ("my_model", "tflite");

if (modelPath == null)
	return;

var localModelSource = new LocalModelSource ("my_local_model", modelPath);
var registrationSuccessful = ModelManager.SharedInstance.Register (localModelSource);
```

### Create an interpreter from your model sources

After you configure your model sources, create a `ModelOptions` object with the Cloud source, the local source, or both, and use it to get an instance of `ModelInterpreter`. If you only have one source, specify `null` for the source type you don't use:

```csharp
var options = new ModelOptions ("my_cloud_model", "my_local_model");
var interpreter = ModelInterpreter.Create (options);
```

## Specify the model's input and output

Next, configure the model interpreter's input and output formats.

A TensorFlow Lite model takes as input and produces as output one or more multidimensional arrays. These arrays contain either `byte`, `int`, `long`, or `float` values. You must configure ML Kit with the number and dimensions ("shape") of the arrays your model uses.

If you don't know the shape and data type of your model's input and output, you can use the TensorFlow Lite Python interpreter to inspect your model. For example:

```python
import tensorflow as tf

interpreter = tf.lite.Interpreter(model_path="my_model.tflite")
interpreter.allocate_tensors()

# Print input shape and type
print(interpreter.get_input_details()[0]['shape'])  # Example: [1 224 224 3]
print(interpreter.get_input_details()[0]['dtype'])  # Example: <class 'numpy.float32'>

# Print output shape and type
print(interpreter.get_output_details()[0]['shape'])  # Example: [1 1000]
print(interpreter.get_output_details()[0]['dtype'])  # Example: <class 'numpy.float32'>
```

After you determine the format of your model's input and output, configure your app's model interpreter by creating a `ModelInputOutputOptions` object.

For example, a floating-point image classification model might take as input an _**N**x224x224x3_ array of `float` values, representing a batch of **N** _224x224_ three-channel (RGB) images, and produce as output a list of 1000 `float` values, each representing the probability the image is a member of one of the 1000 categories the model predicts.

For such a model, you would configure the model interpreter's input and output as shown below:

```csharp
var ioOptions = new ModelInputOutputOptions ();

ioOptions.SetInputFormat (0, ModelElementType.Float32, new nuint[] { 1, 224, 224, 3 }, out NSError inputError);
if (inputError != null) { return; }

ioOptions.SetOutputFormat (0, ModelElementType.Float32, new nuint [] { 1, 1000 }, out NSError outputError);
if (outputError != null) { return; }
```

## Perform inference on input data

Finally, to perform inference using the model, get your input data, perform any transformations on the data that might be necessary for your model, and build a `NSData` object that contains the data:

```csharp
var inputData = new NSMutableData (0);

// Prepare your input data

var modelInputs = new ModelInputs ();
modelInputs.AddInput (inputData, out NSError error);

if (error != null) { return; }
```

After you prepare your model input, pass the input and input/output options to your `ModelInterpreter`'s `Run` method.

```csharp
interpreter.Run (modelInputs, ioOptions, HandleModelInterpreterRunCallback);

void HandleModelInterpreterRunCallback (ModelOutputs outputs, NSError error)
{
	if (error != null || outputs == null) {
		return;
	}

	// Process outputs
}

// or use async / await

try {
	ModelOutputs outputs = await interpreter.RunAsync (modelInputs, ioOptions);

	if (outputs == null) {
		return;
	}

	// Process outputs
} catch (NSErrorException ex) {

}
```

You can get the output by calling the `GetOutput` method of the object that is returned. For example:

```csharp
// Get first and only output of inference with a batch size of 1
var output = outputs.GetOutput (0, out NSError outputError) as NSArray;
var probabilities = output.GetItem<NSArray<NSNumber>> (0);
```

How you use the output depends on the model you are using.

## Appendix: Model security

Regardless of how you make your TensorFlow Lite models available to ML Kit, ML Kit stores them in the standard serialized protobuf format in local storage.

In theory, this means that anybody can copy your model. However, in practice, most models are so application-specific and obfuscated by optimizations that the risk is similar to that of competitors disassembling and reusing your code. Nevertheless, you should be aware of this risk before you use a custom model in your app.

# Use a custom TensorFlow Lite build

If you're an experienced ML developer and the pre-built TensorFlow Lite library doesn't meet your needs, you can use a custom [TensorFlow Lite][5] build with ML Kit. For example, you may want to add custom ops.

## Prerequisites

* A working [TensorFlow Lite][6] build environment
* A checkout of TensorFlow Lite 1.10.1

You can check out the correct version using Git:

```
$ git checkout -b work
$ git reset --hard tflite-v1.10.1
$ git cherry-pick 4dcfddc5d12018a5a0fdca652b9221ed95e9eb23
```

## Building the Tensorflow Lite library

1. Build Tensorflow Lite (with your modifications) following the [standard instructions][7]
2. Build the framework:

	```
	$ tensorflow/lite/lib_package/create_ios_frameworks.sh
	```

The generated framework can be found at `tensorflow/lite/gen/ios_frameworks/tensorflow_lite.framework.zip`

> ![note_icon] **_Note:_** _There have been [build issues reported][8] with Xcode 9.3_

## Add your custom TensorFlow Lite framework

To be able to use your TensorFlow Lite framework, the framework must be copied to TensorFlow Lite Xamarin Build Download cache folder, to do so, follow these steps:

1. Unzip the tensorflow_lite.framework.zip file generated above
2. Copy the unzipped tensorflow_lite.framework to the TensorFlow Lite Xamarin Build Download cache folder

	* Mac: `~/Library/Caches/XamarinBuildDownload/TnsrFlwLt-1.10.1/Frameworks`
	* Windows: `%LOCALAPPDATA%\XamarinBuildDownloadCache\TnsrFlwLt-1.10.1\Frameworks`

	> ![note_icon] _**Note:**_ _If you cannot find the folder, please, open Visual Studio and build your project so Xamarin Build Download can create the TensorFlow Lite cache folder. The `1.10.1` version can vary._

3. Erase your `bin` and `obj` folders of your project and build again on Visual Studio

If you want to use the default TensorFlow Lite framework again, just erase everything that start with `TnsrFlwLt-1.10.1` in the Xamarin Build Download cache folder, erase the `bin` and `obj` folders and build again your project on Visual Studio.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/ml-kit/ios/use-custom-models) to see original Firebase documentation._</sub>

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592
[3]: https://github.com/tensorflow/tensorflow/tree/master/tensorflow/lite/toco
[4]: https://firebase.google.com/docs/ml-kit/ios/use-custom-models#model_security
[5]: https://www.tensorflow.org/mobile/tflite/
[6]: https://github.com/tensorflow/tensorflow/blob/master/tensorflow/lite/README.md#building-tensorflow-lite-and-the-demo-app-from-source
[7]: https://github.com/tensorflow/tensorflow/blob/master/tensorflow/lite/g3doc/ios.md
[8]: https://github.com/tensorflow/tensorflow/issues/18356
[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
