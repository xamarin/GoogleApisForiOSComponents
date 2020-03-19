# Language Identification

With ML Kit's on-device language identification API, you can determine the language of a string of text.

Language identification can be useful when working with user-provided text, which often doesn't come with any language information.

## Key capabilities

|  | |
|-:|-|
| **Broad language support** | Identifies over a hundred different languages. See the [complete list][Language-1]. |
| **Romanized text support** | Identifies Arabic, Bulgarian, Greek, Hindi, Japanese, Russian, and Chinese text in both native and romanized script. |

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/ml-kit/identify-languages) to see original Firebase documentation._</sub>

[Language-1]: https://firebase.google.com/docs/ml-kit/langid-support
[available_icon]: https://cdn3.iconfinder.com/data/icons/flat-actions-icons-9/512/Tick_Mark-24.png

---

# Translation

With ML Kit's on-device translation API, you can dynamically translate text between 59 languages.

## Key capabilities

|  | |
|-:|-|
| **Broad language support** | Translate between 59 different languages. See the [complete list][Translation-1]. |
| **Proven translation models** | Powered by the same models used by the Google Translate app's offline mode. |
| **Dynamic model management** | Keep on-device storage requirements low by dynamically downloading and managing language packs. |
| **Runs on the device** | Translations are performed quickly, and don't require you to send users' text to a remote server. |

## Limitations

On-device translation is intended for casual and simple translations, and the quality of translations depends on the specific languages being translated from and to. As such, you should evaluate the quality of the translations for your specific use case. If you require higher fidelity, try the [Cloud Translation API][Translation-2].

Also, ML Kit's translation models are trained to translate to and from English. When you translate between non-English languages, English is used as an intermediate translation, which can affect quality.

## Usage guidelines

Refer to [Usage Guidelines for ML Kit On-device Translation][Translation-3] for important guidelines and restrictions on usage of this API. This document covers requirements around doing attribution in your app when translating text.

## Providing feedback

Due to the complexity of natural language processing, the translations provided might not be appropriate for all contexts or audiences. If you encounter inappropriate translations, reach out to [Firebase support][Translation-4]. Your feedback helps to continue to improve the models, and also allows us to disable inappropriate translations.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/ml-kit/translation) to see original Firebase documentation._</sub>

[Translation-1]: https://firebase.google.com/docs/ml-kit/translation-language-support
[Translation-2]: https://cloud.google.com/translate/
[Translation-3]: https://firebase.google.com/docs/ml-kit/translation-terms
[Translation-4]: https://firebase.google.com/support

---

# Smart Reply

With ML Kit's Smart Reply API, you can automatically generate relevant replies to messages. Smart Reply helps your users respond to messages quickly, and makes it easier to reply to messages on devices with limited input capabilities.

## Key capabilities

|  | |
|-:|-|
| **Generates contextually-relevant suggestions** | The Smart Reply model generates reply suggestions based on the full context of a conversation, and not just a single message, resulting in suggestions that are more helpful to your users. |
| **Runs on the device** | The on-device model generates replies quickly, and doesn't require you to send users' messages to a remote server. |

## Limitations

* Smart Reply is intended for casual conversations in consumer apps. Reply suggestions might not be appropriate for other contexts or audiences.
* Currently, only English is supported. The model automatically detects if a different language is used and if so, will not provide suggestions.

## How the model works

* The model uses up to 10 of the most recent messages from a conversation history to generate reply suggestions.
* It detects the language of the conversation and only attempts to provide responses when the language is determined to be English.
* Next, the model compares the messages against a list of sensitive topics and won’t provide suggestions when it detects a sensitive topic.
* If the language is determined to be English and no sensitive topics are detected, the model provides up to three suggested responses. The number of responses depends on how many meet a sufficient level of confidence based on the input to the model.

## Providing feedback

Due to the complexity of natural language processing, the suggestions provided by the model might not be appropriate for all contexts or audiences. If you encounter inappropriate reply suggestions, reach out to [Firebase support][Smart-Reply-1]. Your feedback helps to continue to improve the model and sensitive topic filter.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/ml-kit/generate-smart-replies) to see original Firebase documentation._</sub>

[Smart-Reply-1]: https://firebase.google.com/support
