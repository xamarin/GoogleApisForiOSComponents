using System;

using Foundation;
using ObjCRuntime;

namespace Firebase.MLKit.NaturalLanguage
{
	/// 
	/// FirebaseMLNaturalLanguage.framework
	/// 

	// @interface FIRNaturalLanguage : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRNaturalLanguage")]
	interface NaturalLanguage
	{
		// @property (getter = isStatsCollectionEnabled, nonatomic) BOOL statsCollectionEnabled;
		[Export ("statsCollectionEnabled")]
		bool StatsCollectionEnabled { [Bind ("isStatsCollectionEnabled")] get; set; }

		// +(instancetype _Nonnull)naturalLanguage __attribute__((swift_name("naturalLanguage()")));
		[Static]
		[Export("naturalLanguage")]
		NaturalLanguage DefaultInstance { get; }

		// +(instancetype _Nonnull)naturalLanguageForApp:(FIRApp * _Nonnull)app __attribute__((swift_name("naturalLanguage(app:)")));
		[Static]
		[Export ("naturalLanguageForApp:")]
		NaturalLanguage From (Core.App app);

		/// 
		/// From FIRNaturalLanguage (LanguageID) category
		///

		// -(FIRLanguageIdentification * _Nonnull)languageIdentification;
		[Export ("languageIdentification")]
		LanguageIdentification GetLanguageIdentification ();

		// -(FIRLanguageIdentification * _Nonnull)languageIdentificationWithOptions:(FIRLanguageIdentificationOptions * _Nonnull)options __attribute__((swift_name("languageIdentification(options:)")));
		[Export ("languageIdentificationWithOptions:")]
		LanguageIdentification GetLanguageIdentification (LanguageIdentificationOptions options);

		/// 
		/// From FIRNaturalLanguage (SmartReply) category
		///

		// -(FIRSmartReply * _Nonnull)smartReply;
		[Export ("smartReply")]
		SmartReply GetSmartReply ();

		/// 
		/// From FIRNaturalLanguage (SmartReply) category
		///

		// -(FIRTranslator * _Nonnull)translatorWithOptions:(FIRTranslatorOptions * _Nonnull)options __attribute__((swift_name("translator(options:)")));
		[Export ("translatorWithOptions:")]
		Translator GetTranslator (TranslatorOptions options);
	}

	/// 
	/// end - FirebaseMLNaturalLanguage.framework
	///


	/// 
	/// FirebaseMLNLLanguageID.framework
	/// 

	// @interface FIRIdentifiedLanguage : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRIdentifiedLanguage")]
	interface IdentifiedLanguage
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull languageCode;
		[Export ("languageCode")]
		string LanguageCode { get; }

		// @property (readonly, nonatomic) float confidence;
		[Export ("confidence")]
		float Confidence { get; }
	}

	// typedef void (^FIRIdentifyLanguageCallback)(NSString * _Nullable, NSError * _Nullable);
	delegate void IdentifyLanguageCallbackHandler ([NullAllowed] string languageCode, [NullAllowed] NSError error);

	// typedef void (^FIRIdentifyPossibleLanguagesCallback)(NSArray<FIRIdentifiedLanguage *> * _Nullable, NSError * _Nullable);
	delegate void IdentifyPossibleLanguagesCallbackHandler ([NullAllowed] IdentifiedLanguage [] identifiedLanguages, [NullAllowed] NSError error);

	// @interface FIRLanguageIdentification : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRLanguageIdentification")]
	interface LanguageIdentification
	{
		// extern NSString *const _Nonnull FIRMLKitUndeterminedLanguageCode __attribute__((swift_name("MLKitUndeterminedLanguageCode")));
		[Field ("FIRMLKitUndeterminedLanguageCode", "__Internal")]
		NSString UndeterminedLanguageCode { get; }

		// -(void)identifyLanguageForText:(NSString * _Nonnull)text completion:(FIRIdentifyLanguageCallback _Nonnull)completion __attribute__((swift_name("identifyLanguage(for:completion:)")));
		[Async]
		[Export ("identifyLanguageForText:completion:")]
		void IdentifyLanguage (string text, IdentifyLanguageCallbackHandler completion);

		// -(void)identifyPossibleLanguagesForText:(NSString * _Nonnull)text completion:(FIRIdentifyPossibleLanguagesCallback _Nonnull)completion __attribute__((swift_name("identifyPossibleLanguages(for:completion:)")));
		[Async]
		[Export ("identifyPossibleLanguagesForText:completion:")]
		void IdentifyPossibleLanguages (string text, IdentifyPossibleLanguagesCallbackHandler completion);
	}

	// @interface FIRLanguageIdentificationOptions : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRLanguageIdentificationOptions")]
	interface LanguageIdentificationOptions
	{
		// extern const float FIRDefaultIdentifyLanguageConfidenceThreshold __attribute__((swift_name("DefaultIdentifyLanguageConfidenceThreshold")));
		[Field ("FIRDefaultIdentifyLanguageConfidenceThreshold", "__Internal")]
		float DefaultIdentifyLanguageConfidenceThreshold { get; }

		// extern const float FIRDefaultIdentifyPossibleLanguagesConfidenceThreshold __attribute__((swift_name("DefaultIdentifyPossibleLanguagesConfidenceThreshold")));
		[Field ("FIRDefaultIdentifyPossibleLanguagesConfidenceThreshold", "__Internal")]
		float DefaultIdentifyPossibleLanguagesConfidenceThreshold { get; }

		// @property (readonly, nonatomic) float confidenceThreshold;
		[Export ("confidenceThreshold")]
		float ConfidenceThreshold { get; }

		// -(instancetype _Nonnull)initWithConfidenceThreshold:(float)confidenceThreshold __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithConfidenceThreshold:")]
		IntPtr Constructor (float confidenceThreshold);
	}

	/// 
	/// end - FirebaseMLNLLanguageID.framework
	///


	/// 
	/// FirebaseMLNLSmartReply.framework
	///

	// typedef void (^FIRSmartReplyCallback)(FIRSmartReplySuggestionResult * _Nullable, NSError * _Nullable);
	delegate void SmartReplyCallbackHandler ([NullAllowed] SmartReplySuggestionResult result, [NullAllowed] NSError error);

	// @interface FIRSmartReply : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRSmartReply")]
	interface SmartReply
	{
		// -(void)suggestRepliesForMessages:(NSArray<FIRTextMessage *> * _Nonnull)messages completion:(FIRSmartReplyCallback _Nonnull)completion __attribute__((swift_name("suggestReplies(for:completion:)")));
		[Async]
		[Export ("suggestRepliesForMessages:completion:")]
		void SuggestReplies (TextMessage [] messages, SmartReplyCallbackHandler completion);
	}

	// @interface FIRSmartReplySuggestion : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRSmartReplySuggestion")]
	interface SmartReplySuggestion
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }
	}

	// @interface FIRSmartReplySuggestionResult : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRSmartReplySuggestionResult")]
	interface SmartReplySuggestionResult
	{
		// @property (readonly, copy, nonatomic) NSArray<FIRSmartReplySuggestion *> * _Nonnull suggestions;
		[Export ("suggestions", ArgumentSemantic.Copy)]
		SmartReplySuggestion [] Suggestions { get; }

		// @property (readonly, nonatomic) FIRSmartReplyResultStatus status;
		[Export ("status")]
		SmartReplyResultStatus Status { get; }
	}

	// @interface FIRTextMessage : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRTextMessage")]
	interface TextMessage
	{
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull userID;
		[Export ("userID")]
		string UserId { get; }

		// @property (readonly, nonatomic) BOOL isLocalUser;
		[Export ("isLocalUser")]
		bool IsLocalUser { get; }

		// -(instancetype _Nonnull)initWithText:(NSString * _Nonnull)text timestamp:(NSTimeInterval)timestamp userID:(NSString * _Nonnull)userID isLocalUser:(BOOL)isLocalUser __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithText:timestamp:userID:isLocalUser:")]
		IntPtr Constructor (string text, double timestamp, string userId, bool isLocalUser);
	}

	/// 
	/// end - FirebaseMLNLSmartReply.framework
	///


	/// 
	/// FirebaseMLNLTranslate.framework
	///

	// @interface Translate (FIRModelManager)
	[Category]
	[BaseType (typeof(Common.ModelManager))]
	interface FIRModelManager_Translate
	{
		// -(void)deleteDownloadedTranslateModel:(FIRTranslateRemoteModel * _Nonnull)remoteModel completion:(void (^ _Nonnull)(NSError * _Nullable))completion __attribute__((swift_name("deleteDownloadedTranslateModel(_:completion:)")));
		[Async]
		[Export ("deleteDownloadedTranslateModel:completion:")]
		void DeleteDownloadedTranslateModel (TranslateRemoteModel remoteModel, Action<NSError> completion);

		// -(NSSet<FIRTranslateRemoteModel *> * _Nonnull)availableTranslateModelsWithApp:(FIRApp * _Nonnull)app __attribute__((swift_name("availableTranslateModels(app:)")));
		[Export ("availableTranslateModelsWithApp:")]
		NSSet GetAvailableTranslateModels (Core.App app);
	}

	// @interface FIRTranslateRemoteModel : FIRRemoteModel
	[DisableDefaultCtor]
	[BaseType (typeof(Common.RemoteModel), Name = "FIRTranslateRemoteModel")]
	interface TranslateRemoteModel
	{
		// @property (readonly, nonatomic) FIRTranslateLanguage language;
		[Export ("language")]
		TranslateLanguage Language { get; }

		// +(FIRTranslateRemoteModel * _Nonnull)translateRemoteModelWithLanguage:(FIRTranslateLanguage)language __attribute__((swift_name("translateRemoteModel(language:)")));
		[Static]
		[Export ("translateRemoteModelWithLanguage:")]
		TranslateRemoteModel Create (TranslateLanguage language);

		// +(FIRTranslateRemoteModel * _Nonnull)translateRemoteModelForApp:(FIRApp * _Nonnull)app language:(FIRTranslateLanguage)language conditions:(FIRModelDownloadConditions * _Nonnull)conditions __attribute__((swift_name("translateRemoteModel(app:language:conditions:)")));
		[Static]
		[Export ("translateRemoteModelForApp:language:conditions:")]
		TranslateRemoteModel Create (Core.App app, TranslateLanguage language, Common.ModelDownloadConditions conditions);
	}

	// typedef void (^FIRTranslatorDownloadModelIfNeededCallback)(NSError * _Nullable);
	delegate void TranslatorDownloadModelIfNeededCallbackHandler ([NullAllowed] NSError error);

	// typedef void (^FIRTranslatorCallback)(NSString * _Nullable, NSError * _Nullable);
	delegate void TranslatorCallbackHandler ([NullAllowed] string result, [NullAllowed] NSError error);

	// @interface FIRTranslator : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRTranslator")]
	interface Translator
	{
		// -(void)translateText:(NSString * _Nonnull)text completion:(FIRTranslatorCallback _Nonnull)completion __attribute__((swift_name("translate(_:completion:)")));
		[Async]
		[Export ("translateText:completion:")]
		void TranslateText (string text, TranslatorCallbackHandler completion);

		// -(void)downloadModelIfNeededWithCompletion:(FIRTranslatorDownloadModelIfNeededCallback _Nonnull)completion;
		[Async]
		[Export ("downloadModelIfNeededWithCompletion:")]
		void DownloadModelIfNeeded (TranslatorDownloadModelIfNeededCallbackHandler completion);

		// -(void)downloadModelIfNeededWithConditions:(FIRModelDownloadConditions * _Nonnull)conditions completion:(FIRTranslatorDownloadModelIfNeededCallback _Nonnull)completion;
		[Async]
		[Export ("downloadModelIfNeededWithConditions:completion:")]
		void DownloadModelIfNeeded (Common.ModelDownloadConditions conditions, TranslatorDownloadModelIfNeededCallbackHandler completion);
	}

	// @interface FIRTranslatorOptions : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRTranslatorOptions")]
	interface TranslatorOptions
	{
		// @property (readonly, nonatomic) FIRTranslateLanguage sourceLanguage;
		[Export ("sourceLanguage")]
		TranslateLanguage SourceLanguage { get; }

		// @property (readonly, nonatomic) FIRTranslateLanguage targetLanguage;
		[Export ("targetLanguage")]
		TranslateLanguage TargetLanguage { get; }

		// -(instancetype _Nonnull)initWithSourceLanguage:(FIRTranslateLanguage)sourceLanguage targetLanguage:(FIRTranslateLanguage)targetLanguage __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithSourceLanguage:targetLanguage:")]
		IntPtr Constructor (TranslateLanguage sourceLanguage, TranslateLanguage targetLanguage);
	}

	/// 
	/// end - FirebaseMLNLTranslate.framework
	///
}
