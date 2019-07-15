using System;

using Foundation;

namespace Firebase.MLKit.ModelInterpreter {
	// @interface FIRCloudModelSource : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRCloudModelSource")]
	interface CloudModelSource {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull modelName;
		[Export ("modelName")]
		string ModelName { get; }

		// @property (readonly, nonatomic) BOOL enableModelUpdates;
		[Export ("enableModelUpdates")]
		bool EnableModelUpdates { get; }

		// @property (readonly, nonatomic) FIRModelDownloadConditions * _Nonnull initialConditions;
		[Export ("initialConditions")]
		ModelDownloadConditions InitialConditions { get; }

		// @property (readonly, nonatomic) FIRModelDownloadConditions * _Nonnull updateConditions;
		[Export ("updateConditions")]
		ModelDownloadConditions UpdateConditions { get; }

		// -(instancetype _Nonnull)initWithModelName:(NSString * _Nonnull)modelName enableModelUpdates:(BOOL)enableModelUpdates initialConditions:(FIRModelDownloadConditions * _Nonnull)initialConditions updateConditions:(FIRModelDownloadConditions * _Nullable)updateConditions __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithModelName:enableModelUpdates:initialConditions:updateConditions:")]
		IntPtr Constructor (string modelName, bool enableModelUpdates, ModelDownloadConditions initialConditions, [NullAllowed] ModelDownloadConditions updateConditions);
	}

	// @interface FIRLocalModelSource : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRLocalModelSource")]
	interface LocalModelSource {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull modelName;
		[Export ("modelName")]
		string ModelName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull path;
		[Export ("path")]
		string Path { get; }

		// -(instancetype _Nonnull)initWithModelName:(NSString * _Nonnull)modelName path:(NSString * _Nonnull)path __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithModelName:path:")]
		IntPtr Constructor (string modelName, string path);
	}

	// @interface FIRModelDownloadConditions : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRModelDownloadConditions")]
	interface ModelDownloadConditions : INSCopying {
		// @property (readonly, nonatomic) BOOL isWiFiRequired;
		[Export ("isWiFiRequired")]
		bool IsWiFiRequired { get; }

		// @property (readonly, nonatomic) BOOL canDownloadInBackground;
		[Export ("canDownloadInBackground")]
		bool CanDownloadInBackground { get; }

		// -(instancetype _Nonnull)initWithIsWiFiRequired:(BOOL)isWiFiRequired canDownloadInBackground:(BOOL)canDownloadInBackground __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithIsWiFiRequired:canDownloadInBackground:")]
		IntPtr Constructor (bool isWiFiRequired, bool canDownloadInBackground);
	}

	// @interface FIRModelInputOutputOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRModelInputOutputOptions")]
	interface ModelInputOutputOptions {
		// -(BOOL)setInputFormatForIndex:(NSUInteger)index type:(FIRModelElementType)type dimensions:(NSArray<NSNumber *> * _Nonnull)dimensions error:(NSError * _Nullable * _Nullable)error;
		[Internal]
		[Export ("setInputFormatForIndex:type:dimensions:error:")]
		bool _SetInputFormat (nuint index, ModelElementType type, NSArray dimensions, [NullAllowed] out NSError error);

		// -(BOOL)setOutputFormatForIndex:(NSUInteger)index type:(FIRModelElementType)type dimensions:(NSArray<NSNumber *> * _Nonnull)dimensions error:(NSError * _Nullable * _Nullable)error;
		[Internal]
		[Export ("setOutputFormatForIndex:type:dimensions:error:")]
		bool _SetOutputFormat (nuint index, ModelElementType type, NSArray dimensions, [NullAllowed] out NSError error);
	}

	// @interface FIRModelInputs : NSObject
	[BaseType (typeof (NSObject), Name = "FIRModelInputs")]
	interface ModelInputs {
		// -(BOOL)addInput:(id _Nonnull)input error:(NSError * _Nullable * _Nullable)error;
		[Internal]
		[Export ("addInput:error:")]
		bool _AddInput (NSObject input, [NullAllowed] out NSError error);
	}

	// typedef void (^FIRModelInterpreterRunCallback)(FIRModelOutputs * _Nullable, NSError * _Nullable);
	delegate void ModelInterpreterRunCallbackHandler ([NullAllowed] ModelOutputs outputs, [NullAllowed] NSError error);

	// typedef void (^FIRModelInterpreterInputOutputOpIndexCallback)(NSNumber * _Nullable, NSError * _Nullable);
	delegate void ModelInterpreterInputOutputOpIndexCallbackHandler ([NullAllowed] NSNumber index, [NullAllowed] NSError error);

	// @interface FIRModelInterpreter : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRModelInterpreter")]
	interface ModelInterpreter {
		// @property (getter = isStatsCollectionEnabled, nonatomic) BOOL statsCollectionEnabled;
		[Export ("statsCollectionEnabled")]
		bool StatsCollectionEnabled { [Bind ("isStatsCollectionEnabled")] get; set; }

		// +(instancetype _Nonnull)modelInterpreterWithOptions:(FIRModelOptions * _Nonnull)options;
		[Static]
		[Export ("modelInterpreterWithOptions:")]
		ModelInterpreter Create (ModelOptions options);

		// -(void)runWithInputs:(FIRModelInputs * _Nonnull)inputs options:(FIRModelInputOutputOptions * _Nonnull)options completion:(FIRModelInterpreterRunCallback _Nonnull)completion;
		[Async]
		[Export ("runWithInputs:options:completion:")]
		void Run (ModelInputs inputs, ModelInputOutputOptions options, ModelInterpreterRunCallbackHandler completion);

		// -(void)inputIndexForOp:(NSString * _Nonnull)opName completion:(FIRModelInterpreterInputOutputOpIndexCallback _Nonnull)completion;
		[Async]
		[Export ("inputIndexForOp:completion:")]
		void InputIndex (string opName, ModelInterpreterInputOutputOpIndexCallbackHandler completion);

		// -(void)outputIndexForOp:(NSString * _Nonnull)opName completion:(FIRModelInterpreterInputOutputOpIndexCallback _Nonnull)completion;
		[Async]
		[Export ("outputIndexForOp:completion:")]
		void OutputIndex (string opName, ModelInterpreterInputOutputOpIndexCallbackHandler completion);
	}

	// @interface FIRModelManager : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRModelManager")]
	interface ModelManager {
		// +(instancetype _Nonnull)modelManager;
		[Static]
		[Export ("modelManager")]
		ModelManager SharedInstance { get; }

		// -(BOOL)registerCloudModelSource:(FIRCloudModelSource * _Nonnull)cloudModelSource;
		[Export ("registerCloudModelSource:")]
		bool Register (CloudModelSource cloudModelSource);

		// -(BOOL)registerLocalModelSource:(FIRLocalModelSource * _Nonnull)localModelSource;
		[Export ("registerLocalModelSource:")]
		bool Register (LocalModelSource localModelSource);

		// -(FIRCloudModelSource * _Nullable)cloudModelSourceForModelName:(NSString * _Nonnull)modelName;
		[return: NullAllowed]
		[Export ("cloudModelSourceForModelName:")]
		CloudModelSource GetCloudModelSource (string modelName);

		// -(FIRLocalModelSource * _Nullable)localModelSourceForModelName:(NSString * _Nonnull)modelName;
		[return: NullAllowed]
		[Export ("localModelSourceForModelName:")]
		LocalModelSource GetLocalModelSource (string modelName);
	}

	// @interface FIRModelOptions : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRModelOptions")]
	interface ModelOptions {
		// @property (readonly, copy, nonatomic) NSString * _Nullable cloudModelName;
		[NullAllowed]
		[Export ("cloudModelName")]
		string CloudModelName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable localModelName;
		[NullAllowed]
		[Export ("localModelName")]
		string LocalModelName { get; }

		// -(instancetype _Nonnull)initWithCloudModelName:(NSString * _Nullable)cloudModelName localModelName:(NSString * _Nullable)localModelName __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithCloudModelName:localModelName:")]
		IntPtr Constructor ([NullAllowed] string cloudModelName, [NullAllowed] string localModelName);
	}

	// @interface FIRModelOutputs : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRModelOutputs")]
	interface ModelOutputs {
		// -(id _Nullable)outputAtIndex:(NSUInteger)index error:(NSError * _Nullable * _Nullable)error;
		[return: NullAllowed]
		[Export ("outputAtIndex:error:")]
		NSObject GetOutput (nuint index, [NullAllowed] out NSError error);
	}
}
