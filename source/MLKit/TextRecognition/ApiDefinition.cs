using System;

using UIKit;
using Foundation;
using CoreGraphics;
using ObjCRuntime;

using MLKit.Core;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace MLKit.TextRecognition {
	// @interface MLKCommonTextRecognizerOptions : NSObject
	[BaseType (typeof (NSObject), Name = "MLKCommonTextRecognizerOptions")]
	[DisableDefaultCtor]
	interface CommonTextRecognizerOptions {
	}

	// @interface MLKText : NSObject
	[BaseType (typeof (NSObject), Name = "MLKText")]
	[DisableDefaultCtor]
	interface VisionText {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSArray<MLKTextBlock *> * _Nonnull blocks;
		[Export ("blocks")]
		VisionTextBlock [] Blocks { get; }
	}

	// @interface MLKTextBlock : NSObject
	[BaseType (typeof (NSObject), Name = "MLKTextBlock")]
	[DisableDefaultCtor]
	interface VisionTextBlock {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSArray<MLKTextLine *> * _Nonnull lines;
		[Export ("lines")]
		VisionTextLine [] Lines { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSArray<MLKTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		TextRecognizedLanguage [] RecognizedLanguages { get; }

		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nonnull cornerPoints;
		[Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }
	}

	// @interface MLKTextElement : NSObject
	[BaseType (typeof (NSObject), Name = "MLKTextElement")]
	[DisableDefaultCtor]
	interface VisionTextElement {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSArray<MLKTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		TextRecognizedLanguage [] RecognizedLanguages { get; }

		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nonnull cornerPoints;
		[Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }
	}

	// @interface MLKTextLine : NSObject
	[BaseType (typeof (NSObject), Name = "MLKTextLine")]
	[DisableDefaultCtor]
	interface VisionTextLine {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSArray<MLKTextElement *> * _Nonnull elements;
		[Export ("elements")]
		VisionTextElement [] Elements { get; }

		// @property (readonly, nonatomic) CGRect frame;
		[Export ("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSArray<MLKTextRecognizedLanguage *> * _Nonnull recognizedLanguages;
		[Export ("recognizedLanguages")]
		TextRecognizedLanguage [] RecognizedLanguages { get; }

		// @property (readonly, nonatomic) NSArray<NSValue *> * _Nonnull cornerPoints;
		[Export ("cornerPoints")]
		NSValue [] CornerPoints { get; }
	}

	// @interface MLKTextRecognizedLanguage : NSObject
	[BaseType (typeof (NSObject), Name = "MLKTextRecognizedLanguage")]
	[DisableDefaultCtor]
	interface TextRecognizedLanguage {
		// @property (readonly, nonatomic) NSString * _Nullable languageCode;
		[NullAllowed, Export ("languageCode")]
		string LanguageCode { get; }
	}

	// typedef void (^MLKTextRecognitionCallback)(MLKText * _Nullable, NSError * _Nullable);
	delegate void TextRecognitionCallback ([NullAllowed] VisionText text, [NullAllowed] NSError error);

	// @interface MLKTextRecognizer : NSObject
	[BaseType (typeof (NSObject), Name = "MLKTextRecognizer")]
	interface TextRecognizer {
		// +(instancetype _Nonnull)textRecognizerWithOptions:(MLKCommonTextRecognizerOptions * _Nonnull)options __attribute__((swift_name("textRecognizer(options:)")));
		[Static]
		[Export ("textRecognizerWithOptions:")]
		TextRecognizer TextRecognizerWithOptions (CommonTextRecognizerOptions options);

		// -(void)processImage:(id<MLKCompatibleImage> _Nonnull)image completion:(MLKTextRecognitionCallback _Nonnull)completion __attribute__((swift_name("process(_:completion:)")));
		[Export ("processImage:completion:")]
		void ProcessImage (ICompatibleImage image, TextRecognitionCallback completion);

		// -(MLKText * _Nullable)resultsInImage:(id<MLKCompatibleImage> _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
		[Export ("resultsInImage:error:")]
		[return: NullAllowed]
		VisionText ResultsInImage (ICompatibleImage image, [NullAllowed] out NSError error);
	}
}
