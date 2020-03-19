# Get Started with Firebase MLKit for iOS

Use machine learning in your apps to solve real-world problems.

ML Kit is a mobile SDK that brings Google's machine learning expertise to Android and iOS apps in a powerful yet easy-to-use package. Whether you're new or experienced in machine learning, you can implement the functionality you need in just a few lines of code. There's no need to have deep knowledge of neural networks or model optimization to get started. On the other hand, if you are an experienced ML developer, ML Kit provides convenient APIs that help you use your custom TensorFlow Lite models in your mobile apps.

## Table of Content

- [Get Started with Firebase MLKit for iOS](#get-started-with-firebase-mlkit-for-ios)
	- [Table of Content](#table-of-content)
	- [Add Firebase to your app](#add-firebase-to-your-app)
	- [Configure MLKit Natural Language in your app](#configure-mlkit-natural-language-in-your-app)
- [Identify the language of text with ML Kit on iOS](#identify-the-language-of-text-with-ml-kit-on-ios)
	- [Identify the language of a string](#identify-the-language-of-a-string)
	- [Get the possible languages of a string](#get-the-possible-languages-of-a-string)
- [Translate text with ML Kit on iOS](#translate-text-with-ml-kit-on-ios)
	- [Translate a string of text](#translate-a-string-of-text)
	- [Explicitly manage translation models](#explicitly-manage-translation-models)

## Add Firebase to your app

1. Create a Firebase project in the [Firebase console][1], if you don't already have one. If you already have an existing Google project associated with your mobile app, click **Import Google Project**. Otherwise, click **Create New Project**.
2. Click **Add Firebase to your iOS app** and follow the setup steps. If you're importing an existing Google project, this may happen automatically and you can just [download the config file][2].
3. When prompted, enter your app's bundle ID. It's important to enter the bundle ID your app is using; this can only be set when you add an app to your Firebase project.
4. At the end, you'll download a `GoogleService-Info.plist` file. You can [download this file][2] again at any time.

## Configure MLKit Natural Language in your app

Once you have your `GoogleService-Info.plist` file downloaded in your computer, do the following steps in Visual Studio:

1. Add `GoogleService-Info.plist` file to your app project.
2. Set `GoogleService-Info.plist` **build action** behaviour to `Bundle Resource` by Right clicking/Build Action.
3. Add the following line of code somewhere in your app, typically in your AppDelegate's `FinishedLaunching` method (don't forget to import `Firebase.Core` namespace):

```csharp
App.Configure ();
```

[1]: https://firebase.google.com/console/
[2]: http://support.google.com/firebase/answer/7015592

---

# Identify the language of text with ML Kit on iOS

You can use ML Kit to identify the language of a string of text. You can get the string's most likely language or get confidence scores for all of the string's possible languages.

ML Kit recognizes text in 103 different languages in their native scripts. In addition, romanized text can be recognized for Arabic, Bulgarian, Chinese, Greek, Hindi, Japanese, and Russian.

## Identify the language of a string

To identify the language of a string, get an instance of `LanguageIdentification`, and then pass the string to the `IdentifyLanguage` method:

```csharp
var languageId = NaturalLanguageApi.DefaultInstance.GetLanguageIdentification ();

languageId.IdentifyLanguage (text, IdentifyLanguageCallbackHandler);

void IdentifyLanguageCallbackHandler (string languageCode, NSError error)
{
	if (error != null) {
		Console.WriteLine ($"Failed with error: {error.LocalizedDescription}");
		return;
	}

	if (languageCode == "und") {
		Console.WriteLine ("No language was identified");
		return;
	}

	Console.WriteLine ($"Identified Language: {languageCode}");
}

// async / await version

try {
	var languageCode = await languageId.IdentifyLanguageAsync (text);

	if (languageCode == "und") {
		Console.WriteLine ("No language was identified");
		return;
	}

	Console.WriteLine ($"Identified Language: {languageCode}");
} catch (NSErrorException ex) {
	Console.WriteLine ($"Failed with error: {ex.Error.LocalizedDescription}");
}
```

If the call succeeds, a [BCP-47 language][Language-1] code is passed to the completion handler, indicating the language of the text. See the [complete list of supported languages][Language-2]. If no language could be confidently detected, the code `und` (undetermined) is passed.

By default, ML Kit returns a non-`und` value only when it identifies the language with a confidence value of at least 0.5. You can change this threshold by passing a `LanguageIdentificationOptions` object to `GetLanguageIdentification (LanguageIdentificationOptions)`:

```csharp
var options = new LanguageIdentificationOptions (.4f);
var languageId = NaturalLanguageApi.DefaultInstance.GetLanguageIdentification (options);
```

## Get the possible languages of a string

To get the confidence values of a string's most likely languages, get an instance of `LanguageIdentification`, and then pass the string to the `IdentifyPossibleLanguages` method:

```csharp
var languageId = NaturalLanguageApi.DefaultInstance.GetLanguageIdentification ();

languageId.IdentifyPossibleLanguages (text, IdentifyPossibleLanguagesCallbackHandler);

void IdentifyPossibleLanguagesCallbackHandler (IdentifiedLanguage [] identifiedLanguages, NSError error)
{
	if (error != null) {
		Console.WriteLine ($"Failed with error: {error.LocalizedDescription}");
		return;
	}

	if (identifiedLanguages.Length > 0 && identifiedLanguages [0].LanguageCode == "und") {
		Console.WriteLine ("No language was identified");
		return;
	}

	foreach (var identifiedLanguage in identifiedLanguages)
		Console.WriteLine ($"({identifiedLanguage.LanguageCode}, {identifiedLanguage.Confidence:.##})");
}

// async / await version

try {
	var identifiedLanguages = await languageId.IdentifyPossibleLanguagesAsync (text);

	if (identifiedLanguages.Length > 0 && identifiedLanguages [0].LanguageCode == "und") {
		Console.WriteLine ("No language was identified");
		return;
	}

	foreach (var identifiedLanguage in identifiedLanguages)
		Console.WriteLine ($"({identifiedLanguage.LanguageCode}, {identifiedLanguage.Confidence:.##})");
} catch (NSErrorException ex) {
	Console.WriteLine ($"Failed with error: {ex.Error.LocalizedDescription}");
}
```

If the call succeeds, a list of `IdentifiedLanguage` objects is passed to the continuation handler. From each object, you can get the language's BCP-47 code and the confidence that the string is in that language. See the [complete list of supported languages][Language-2]. Note that these values indicate the confidence that the entire string is in the given language; ML Kit doesn't identify multiple languages in a single string.

By default, ML Kit returns only languages with confidence values of at least 0.01. You can change this threshold by passing a `LanguageIdentificationOptions` object to `GetLanguageIdentification (LanguageIdentificationOptions)`:

```csharp
var options = new LanguageIdentificationOptions (.4f);
var languageId = NaturalLanguageApi.DefaultInstance.GetLanguageIdentification (options);
```

If no language meets this threshold, the list will have one item, with the value `und`.

[Language-1]: https://en.wikipedia.org/wiki/IETF_language_tag
[Language-2]: https://firebase.google.com/docs/ml-kit/langid-support

---

# Translate text with ML Kit on iOS

You can use ML Kit to translate text between languages. ML Kit currently supports translation between [59 languages][Translate-1].

## Translate a string of text

To translate a string between two languages:

1. Create a `Translator` object, configuring it with the source and target languages:

	```csharp
	// Create an English-German translator:
	var options = new TranslatorOptions (TranslateLanguage.En, TranslateLanguage.De);
	var englishGermanTranslator = NaturalLanguageApi.DefaultInstance.GetTranslator (options);
	```

	If you don't know the language of the input text, you can use the [language identification API][Translate-2] first. (But be sure you don't keep too many language models on the device at once.)

2. Make sure the required translation model has been downloaded to the device. Don't call `TranslateText` until you know the model is available:

	```csharp
	var conditions = new ModelDownloadConditions (false, true);
	englishGermanTranslator.DownloadModelIfNeeded (conditions, TranslatorDownloadModelIfNeededCallbackHandler);

	void TranslatorDownloadModelIfNeededCallbackHandler (NSError error)
	{
		if (error != null)
			return;

		// Model downloaded successfully. Okay to start translating.

	}

	// async / await version

	try {
		await englishGermanTranslator.DownloadModelIfNeededAsync (conditions);

		// Model downloaded successfully. Okay to start translating.
	} catch (NSErrorException ex) {
		// Handle error
	}
	```

	Language models are around 30MB, so don't download them unnecessarily, and only download them using WiFi, unless the user has specified otherwise. You should also delete unneeded models. See [Explicitly manage translation models][Translate-3].

3. After you confirm the model has been downloaded, pass a string of text in the source language to `TranslateText`:

	```csharp
	englishGermanTranslator.TranslateText (text, TranslatorCallbackHandler);

	void TranslatorCallbackHandler (string result, NSError error)
	{
		if (error != null)
			return;

		// Translation succeeded.
	}

	// async / await version

	try {
		var result = await englishGermanTranslator.TranslateTextAsync (text);

		// Translation succeeded.
	} catch (NSErrorException ex) {
		// Handle error
	}
	```

	ML Kit translates the text to the target language you configured and passes the translated text to the completion handler.

## Explicitly manage translation models

When you use the translation API as described above, ML Kit automatically downloads language-specific translation models to the device as required. You can also explicitly manage the translation models you want available on the device by using ML Kit's translation model management API. This can be useful if you want to download models ahead of time, or delete unneeded models from the device.

To get the translation models stored on the device:

```csharp
var 
```

[Translate-1]: https://firebase.google.com/docs/ml-kit/translation-language-support
[Translate-2]: #identify-the-language-of-text-with-ml-kit-on-ios
[Translate-3]: #explicitly-manage-translation-models

[note_icon]: https://cdn3.iconfinder.com/data/icons/UltimateGnome/22x22/apps/gnome-app-install-star.png
[warning_icon]: https://cdn2.iconfinder.com/data/icons/freecns-cumulus/32/519791-101_Warning-20.png
[available_icon]: https://cdn3.iconfinder.com/data/icons/flat-actions-icons-9/512/Tick_Mark-24.png
