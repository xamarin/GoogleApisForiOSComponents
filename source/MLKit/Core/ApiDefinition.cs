using System;

using UIKit;
using Foundation;
using CoreMedia;
using CoreVideo;
using ObjCRuntime;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace MLKit.Core {
	delegate void ErrorCallback ([NullAllowed] NSError error);

	[Static]
	partial interface Constants {
		// extern NS_SWIFT_NAME(mlkitModelDownloadDidSucceed) const NSNotificationName MLKModelDownloadDidSucceedNotification __attribute__((swift_name("mlkitModelDownloadDidSucceed")));
		[Field ("MLKModelDownloadDidSucceedNotification", "__Internal")]
		NSString ModelDownloadDidSucceedNotification { get; }

		// extern NS_SWIFT_NAME(mlkitModelDownloadDidFail) const NSNotificationName MLKModelDownloadDidFailNotification __attribute__((swift_name("mlkitModelDownloadDidFail")));
		[Field ("MLKModelDownloadDidFailNotification", "__Internal")]
		NSString ModelDownloadDidFailNotification { get; }

		// extern const MLKModelDownloadUserInfoKey _Nonnull MLKModelDownloadUserInfoKeyRemoteModel;
		[Field ("MLKModelDownloadUserInfoKeyRemoteModel", "__Internal")]
		NSString ModelDownloadUserInfoKeyRemoteModel { get; }

		// extern const MLKModelDownloadUserInfoKey _Nonnull MLKModelDownloadUserInfoKeyError;
		[Field ("MLKModelDownloadUserInfoKeyError", "__Internal")]
		NSString ModelDownloadUserInfoKeyError { get; }
	}

	// @interface MLKRemoteModel : NSObject
	[BaseType (typeof (NSObject), Name = "MLKRemoteModel")]
	[DisableDefaultCtor]
	interface RemoteModel {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }
	}

	// @interface MLKCustomRemoteModel : MLKRemoteModel
	[BaseType (typeof (RemoteModel), Name = "MLKCustomRemoteModel")]
	[DisableDefaultCtor]
	interface CustomRemoteModel {
		// -(instancetype _Nonnull)initWithRemoteModelSource:(MLKRemoteModelSource * _Nonnull)remoteModelSource;
		[Export ("initWithRemoteModelSource:")]
		NativeHandle Constructor (RemoteModelSource remoteModelSource);
	}

	interface ILocalModelPath : INativeObject, IDisposable { }
	interface ILocalModelManifestPath : INativeObject, IDisposable { }

	// @interface MLKLocalModel : NSObject
	[BaseType (typeof (NSObject), Name = "MLKLocalModel")]
	[DisableDefaultCtor]
	interface LocalModel {
		// @property (readonly, copy, nonatomic) NSString * _Nonnull path;
		[Export ("path")]
		string Path { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable manifestPath;
		[NullAllowed, Export ("manifestPath")]
		string ManifestPath { get; }

		// -(instancetype _Nonnull)initWithPath:(NSString * _Nonnull)path;
		[Export ("initWithPath:")]
		NativeHandle Constructor (ILocalModelPath path);

		// -(instancetype _Nullable)initWithManifestPath:(NSString * _Nonnull)manifestPath;
		[Export ("initWithManifestPath:")]
		NativeHandle Constructor (ILocalModelManifestPath manifestPath);
	}

	// @interface MLKModelDownloadConditions : NSObject <NSCopying>
	[BaseType (typeof (NSObject), Name = "MLKModelDownloadConditions")]
	interface ModelDownloadConditions : INSCopying {
		// @property (readonly, nonatomic) BOOL allowsCellularAccess;
		[Export ("allowsCellularAccess")]
		bool AllowsCellularAccess { get; }

		// @property (readonly, nonatomic) BOOL allowsBackgroundDownloading;
		[Export ("allowsBackgroundDownloading")]
		bool AllowsBackgroundDownloading { get; }

		// -(instancetype _Nonnull)initWithAllowsCellularAccess:(BOOL)allowsCellularAccess allowsBackgroundDownloading:(BOOL)allowsBackgroundDownloading __attribute__((objc_designated_initializer));
		[Export ("initWithAllowsCellularAccess:allowsBackgroundDownloading:")]
		[DesignatedInitializer]
		NativeHandle Constructor (bool allowsCellularAccess, bool allowsBackgroundDownloading);
	}

	// @interface MLKModelManager : NSObject
	[BaseType (typeof (NSObject), Name = "MLKModelManager")]
	[DisableDefaultCtor]
	interface ModelManager {
		// +(instancetype _Nonnull)modelManager __attribute__((swift_name("modelManager()")));
		[Static]
		[Export ("modelManager")]
		ModelManager DefaultInstance { get; set; }

		// -(BOOL)isModelDownloaded:(MLKRemoteModel * _Nonnull)remoteModel;
		[Export ("isModelDownloaded:")]
		bool IsModelDownloaded (RemoteModel remoteModel);

		// -(NSProgress * _Nonnull)downloadModel:(MLKRemoteModel * _Nonnull)remoteModel conditions:(MLKModelDownloadConditions * _Nonnull)conditions __attribute__((swift_name("download(_:conditions:)")));
		[Export ("downloadModel:conditions:")]
		NSProgress DownloadModel (RemoteModel remoteModel, ModelDownloadConditions conditions);

		// -(void)deleteDownloadedModel:(MLKRemoteModel * _Nonnull)remoteModel completion:(void (^ _Nonnull)(NSError * _Nullable))completion;
		[Export ("deleteDownloadedModel:completion:")]
		void DeleteDownloadedModel (RemoteModel remoteModel, ErrorCallback completion);
	}

	// @interface MLKRemoteModelSource : NSObject
	[BaseType (typeof (NSObject), Name = "MLKRemoteModelSource")]
	[DisableDefaultCtor]
	interface RemoteModelSource {
	}

	// @interface GMLImage : NSObject
	[BaseType (typeof (CompatibleImage), Name = "GMLImage")]
	[DisableDefaultCtor]
	interface MLImage {
		// @property (readonly, nonatomic) CGFloat width;
		[Export ("width")]
		nfloat Width { get; }

		// @property (readonly, nonatomic) CGFloat height;
		[Export ("height")]
		nfloat Height { get; }

		// @property (nonatomic) UIImageOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		UIImageOrientation Orientation { get; set; }

		// @property (readonly, nonatomic) GMLImageSourceType imageSourceType;
		[Export ("imageSourceType")]
		ImageSourceType ImageSourceType { get; }

		// @property (readonly, nonatomic) UIImage * _Nullable image;
		[NullAllowed, Export ("image")]
		UIImage Image { get; }

		// @property (readonly, nonatomic) CVPixelBufferRef _Nullable pixelBuffer;
		[NullAllowed, Export ("pixelBuffer")]
		CVPixelBuffer PixelBuffer { get; }

		// @property (readonly, nonatomic) CMSampleBufferRef _Nullable sampleBuffer;
		[NullAllowed, Export ("sampleBuffer")]
		CMSampleBuffer SampleBuffer { get; }

		// -(instancetype _Nullable)initWithImage:(UIImage * _Nonnull)image __attribute__((objc_designated_initializer));
		[Export ("initWithImage:")]
		[DesignatedInitializer]
		NativeHandle Constructor (UIImage image);

		// -(instancetype _Nullable)initWithPixelBuffer:(CVPixelBufferRef _Nonnull)pixelBuffer __attribute__((objc_designated_initializer));
		[Export ("initWithPixelBuffer:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CVPixelBuffer pixelBuffer);

		// -(instancetype _Nullable)initWithSampleBuffer:(CMSampleBufferRef _Nonnull)sampleBuffer __attribute__((objc_designated_initializer));
		[Export ("initWithSampleBuffer:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CMSampleBuffer sampleBuffer);
	}

	// @interface MLKVision3DPoint
	[BaseType (typeof (VisionPoint), Name = "MLKVision3DPoint")]
	[DisableDefaultCtor]
	interface Vision3DPoint {
		// @property (readonly, nonatomic) CGFloat z;
		[Export ("z")]
		nfloat Z { get; }
	}

	interface ICompatibleImage { }

	[Protocol]
	[BaseType (typeof (NSObject), Name = "MLKCompatibleImage")]
	interface CompatibleImage {
	}

	// @interface MLKVisionImage : NSObject <MLKCompatibleImage>
	[BaseType (typeof (CompatibleImage), Name = "MLKVisionImage")]
	[DisableDefaultCtor]
	interface VisionImage {
		// @property (nonatomic) UIImageOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		UIImageOrientation Orientation { get; set; }

		// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image __attribute__((objc_designated_initializer));
		[Export ("initWithImage:")]
		[DesignatedInitializer]
		NativeHandle Constructor (UIImage image);

		// -(instancetype _Nonnull)initWithBuffer:(CMSampleBufferRef _Nonnull)sampleBuffer __attribute__((objc_designated_initializer));
		[Export ("initWithBuffer:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CMSampleBuffer sampleBuffer);
	}

	// @interface MLKVisionPoint : NSObject
	[BaseType (typeof (NSObject), Name = "MLKVisionPoint")]
	[DisableDefaultCtor]
	interface VisionPoint {
		// @property (readonly, nonatomic) CGFloat x;
		[Export ("x")]
		nfloat X { get; }

		// @property (readonly, nonatomic) CGFloat y;
		[Export ("y")]
		nfloat Y { get; }
	}
}
