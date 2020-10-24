using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.MLKit.Common {
	delegate void FilePathHandler([NullAllowed] string filePath, [NullAllowed] NSError error);
	
	// @interface FIRLocalModel : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRLocalModel")]
	interface LocalModel
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull path;
		[Export ("path")]
		string Path { get; }
	}

	// @interface FIRModelDownloadConditions : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRModelDownloadConditions")]
	interface ModelDownloadConditions : INSCopying
	{
		// @property (readonly, nonatomic) BOOL allowsCellularAccess;
		[Export ("allowsCellularAccess")]
		bool AllowsCellularAccess { get; }

		// @property (readonly, nonatomic) BOOL allowsBackgroundDownloading;
		[Export ("allowsBackgroundDownloading")]
		bool AllowsBackgroundDownloading { get; }

		// -(instancetype _Nonnull)initWithAllowsCellularAccess:(BOOL)allowsCellularAccess allowsBackgroundDownloading:(BOOL)allowsBackgroundDownloading __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithAllowsCellularAccess:allowsBackgroundDownloading:")]
		IntPtr Constructor (bool allowsCellularAccess, bool allowsBackgroundDownloading);
	}

	interface ModelDownloadSucceedEventArgs
	{
		[Export ("FIRModelDownloadUserInfoKeyRemoteModel")]
		RemoteModel RemoteModel { get; }
	}

	interface ModelDownloadFailedEventArgs
	{
		[Export ("FIRModelDownloadUserInfoKeyRemoteModel")]
		RemoteModel RemoteModel { get; }

		[Export ("FIRModelDownloadUserInfoKeyError")]
		NSError Error { get; }
	}

	// @interface FIRModelManager : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRModelManager")]
	interface ModelManager
	{
		// extern const NSNotificationName _Nonnull FIRModelDownloadDidSucceedNotification __attribute__((swift_name("firebaseMLModelDownloadDidSucceed")));
		[Notification (typeof (ModelDownloadSucceedEventArgs))]
		[Field ("FIRModelDownloadDidSucceedNotification", "__Internal")]
		NSString ModelDownloadDidSucceedNotification { get; }

		// extern const NSNotificationName _Nonnull FIRModelDownloadDidFailNotification __attribute__((swift_name("firebaseMLModelDownloadDidFail")));
		[Notification (typeof (ModelDownloadFailedEventArgs))]
		[Field ("FIRModelDownloadDidFailNotification", "__Internal")]
		NSString ModelDownloadDidFailNotification { get; }

		// extern const FIRModelDownloadUserInfoKey _Nonnull FIRModelDownloadUserInfoKeyRemoteModel;
		[Field ("FIRModelDownloadUserInfoKeyRemoteModel", "__Internal")]
		NSString ModelDownloadUserInfoKeyRemoteModel { get; }

		// extern const FIRModelDownloadUserInfoKey _Nonnull FIRModelDownloadUserInfoKeyError;
		[Field ("FIRModelDownloadUserInfoKeyError", "__Internal")]
		NSString ModelDownloadUserInfoKeyError { get; }

		// +(instancetype _Nonnull)modelManager __attribute__((swift_name("modelManager()")));
		[Static]
		[Export ("modelManager")]
		ModelManager DefaultInstance { get; }

		// +(instancetype _Nonnull)modelManagerForApp:(FIRApp * _Nonnull)app __attribute__((swift_name("modelManager(app:)")));
		[Static]
		[Export ("modelManagerForApp:")]
		ModelManager From (Core.App app);

		// -(BOOL)isModelDownloaded:(FIRRemoteModel * _Nonnull)remoteModel;
		[Export ("isModelDownloaded:")]
		bool IsModelDownloaded (RemoteModel remoteModel);

		// -(NSProgress * _Nonnull)downloadModel:(FIRRemoteModel * _Nonnull)remoteModel conditions:(FIRModelDownloadConditions * _Nonnull)conditions __attribute__((swift_name("download(_:conditions:)")));
		[Export ("downloadModel:conditions:")]
		NSProgress DownloadModel (RemoteModel remoteModel, ModelDownloadConditions conditions);

		// -(void)deleteDownloadedModel:(FIRRemoteModel * _Nonnull)remoteModel completion:(void (^ _Nonnull)(NSError * _Nullable))completion;
		[Export ("deleteDownloadedModel:completion:")]
		void DeleteDownloadedModel (RemoteModel remoteModel, Action<NSError> completion);

		// - (void)getLatestModelFilePath:(FIRRemoteModel *)remoteModel completion:(void (^)(NSString *_Nullable filePath, NSError *_Nullable error))completion;
        [Export("getLatestModelFilePath:completion:")]
        void GetLatestModelFilePath(RemoteModel remoteModel, FilePathHandler completion);
	}

	// @interface FIRRemoteModel : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRRemoteModel")]
	interface RemoteModel
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }
	}
}
