using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Firebase.MLKit.Common {
	// @interface FIRLocalModel : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRLocalModel")]
	interface LocalModel
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull path;
		[Export ("path")]
		string Path { get; }

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name path:(NSString * _Nonnull)path __attribute__((objc_designated_initializer)) __attribute__((swift_name("init(name:path:)")));
		[DesignatedInitializer]
		[Export ("initWithName:path:")]
		IntPtr Constructor (string name, string path);
	}

	// @interface FIRModelDownloadConditions : NSObject <NSCopying>
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

		// -(BOOL)registerRemoteModel:(FIRRemoteModel * _Nonnull)remoteModel;
		[Export ("registerRemoteModel:")]
		bool RegisterRemoteModel (RemoteModel remoteModel);

		// -(BOOL)registerLocalModel:(FIRLocalModel * _Nonnull)localModel;
		[Export ("registerLocalModel:")]
		bool RegisterLocalModel (LocalModel localModel);

		// -(FIRRemoteModel * _Nullable)remoteModelWithName:(NSString * _Nonnull)name;
		[return: NullAllowed]
		[Export ("remoteModelWithName:")]
		RemoteModel GetRemoteModel (string name);

		// -(FIRLocalModel * _Nullable)localModelWithName:(NSString * _Nonnull)name;
		[return: NullAllowed]
		[Export ("localModelWithName:")]
		LocalModel GetLocalModel (string name);

		// -(BOOL)isRemoteModelDownloaded:(FIRRemoteModel * _Nonnull)remoteModel;
		[Export ("isRemoteModelDownloaded:")]
		bool IsRemoteModelDownloaded (RemoteModel remoteModel);

		// -(NSProgress * _Nonnull)downloadRemoteModel:(FIRRemoteModel * _Nonnull)remoteModel __attribute__((swift_name("download(_:)")));
		[Export ("downloadRemoteModel:")]
		NSProgress DownloadRemoteModel (RemoteModel remoteModel);
	}

	// @interface FIRRemoteModel : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FIRRemoteModel")]
	interface RemoteModel
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) BOOL allowsModelUpdates;
		[Export ("allowsModelUpdates")]
		bool AllowsModelUpdates { get; }

		// @property (readonly, nonatomic) FIRModelDownloadConditions * _Nonnull initialConditions;
		[Export ("initialConditions")]
		ModelDownloadConditions InitialConditions { get; }

		// @property (readonly, nonatomic) FIRModelDownloadConditions * _Nonnull updateConditions;
		[Export ("updateConditions")]
		ModelDownloadConditions UpdateConditions { get; }

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name allowsModelUpdates:(BOOL)allowsModelUpdates initialConditions:(FIRModelDownloadConditions * _Nonnull)initialConditions updateConditions:(FIRModelDownloadConditions * _Nullable)updateConditions __attribute__((swift_name("init(name:allowsModelUpdates:initialConditions:updateConditions:)")));
		[Export ("initWithName:allowsModelUpdates:initialConditions:updateConditions:")]
		IntPtr Constructor (string name, bool allowsModelUpdates, ModelDownloadConditions initialConditions, [NullAllowed] ModelDownloadConditions updateConditions);
	}
}
