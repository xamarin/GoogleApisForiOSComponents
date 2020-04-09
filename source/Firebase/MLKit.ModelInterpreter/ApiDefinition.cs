using System;

using Foundation;
using ObjCRuntime;

namespace Firebase.MLKit.ModelInterpreter {
	// @interface FIRCustomLocalModel : FIRLocalModel
	[DisableDefaultCtor]
	[BaseType (typeof(Common.LocalModel), Name = "FIRCustomLocalModel")]
	interface CustomLocalModel
	{
		// -(instancetype _Nonnull)initWithModelPath:(NSString * _Nonnull)modelPath __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithModelPath:")]
		IntPtr Constructor (string modelPath);
	}

	// @interface FIRCustomRemoteModel : FIRRemoteModel
	[DisableDefaultCtor]
	[BaseType (typeof(Common.RemoteModel), Name = "FIRCustomRemoteModel")]
	interface CustomRemoteModel
	{
		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithName:")]
		IntPtr Constructor (string name);
	}
	
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

		// +(instancetype _Nonnull)modelInterpreterForLocalModel:(FIRCustomLocalModel * _Nonnull)localModel __attribute__((swift_name("modelInterpreter(localModel:)")));
		[Static]
		[Export ("modelInterpreterForLocalModel:")]
		ModelInterpreter Create (CustomLocalModel localModel);

		// +(instancetype _Nonnull)modelInterpreterForRemoteModel:(FIRCustomRemoteModel * _Nonnull)remoteModel __attribute__((swift_name("modelInterpreter(remoteModel:)")));
		[Static]
		[Export ("modelInterpreterForRemoteModel:")]
		ModelInterpreter Create (CustomRemoteModel remoteModel);

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
