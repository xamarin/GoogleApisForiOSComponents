using System;

using Foundation;
using ObjCRuntime;

namespace Firebase.MLKit.ModelInterpreter {
	// @interface FIRModelInputOutputOptions : NSObject
	[BaseType (typeof (NSObject), Name = "FIRModelInputOutputOptions")]
	interface ModelInputOutputOptions {
		// -(BOOL)setInputFormatForIndex:(NSUInteger)index type:(FIRModelElementType)type dimensions:(NSArray<NSNumber *> * _Nonnull)dimensions error:(NSError * _Nullable * _Nullable)error;
		[Export ("setInputFormatForIndex:type:dimensions:error:")]
		bool SetInputFormat (nuint index, ModelElementType type, [BindAs (typeof (nuint []))] NSNumber [] dimensions, [NullAllowed] out NSError error);

		// -(BOOL)setOutputFormatForIndex:(NSUInteger)index type:(FIRModelElementType)type dimensions:(NSArray<NSNumber *> * _Nonnull)dimensions error:(NSError * _Nullable * _Nullable)error;
		[Export ("setOutputFormatForIndex:type:dimensions:error:")]
		bool SetOutputFormat (nuint index, ModelElementType type, [BindAs (typeof (nuint []))] NSNumber [] dimensions, [NullAllowed] out NSError error);
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

	// @interface FIRModelOptions : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FIRModelOptions")]
	interface ModelOptions {
		// @property (readonly, copy, nonatomic) NSString * _Nullable remoteModelName;
		[NullAllowed]
		[Export ("remoteModelName")]
		string RemoteModelName { get; }

		[Obsolete ("Use the RemoteModelName property instead. This will be removed in future versions.")]
		[NullAllowed]
		[Wrap ("RemoteModelName")]
		string CloudModelName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable localModelName;
		[NullAllowed]
		[Export ("localModelName")]
		string LocalModelName { get; }

		// -(instancetype _Nonnull)initWithRemoteModelName:(NSString * _Nullable)remoteModelName localModelName:(NSString * _Nullable)localModelName __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export("initWithRemoteModelName:localModelName:")]
		IntPtr Constructor ([NullAllowed] string remoteModelName, [NullAllowed] string localModelName);
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
