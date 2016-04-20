using System;
using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;

namespace Google.TagManager
{
	interface IFunctionCallTagHandler
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "TAGFunctionCallTagHandler")]
	interface FunctionCallTagHandler
	{
		[Abstract]
		[Export ("execute:parameters:")]
		void Execute (string tagName, [NullAllowed] NSDictionary parameters);
	}

	interface IFunctionCallMacroHandler
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "TAGFunctionCallMacroHandler")]
	interface FunctionCallMacroHandler
	{
		[Abstract]
		[Export ("valueForMacro:parameters:")]
		NSObject ValueForMacro (string macroName, [NullAllowed] NSDictionary parameters);
	}

	interface IContainerCallback
	{

	}

	[Protocol]
	[Model]
	[BaseType (typeof(NSObject), Name = "TAGContainerCallback")]
	interface ContainerCallback
	{
		[Abstract]
		[Export ("containerRefreshBegin:refreshType:")]
		void RefreshBegin (Container container, ContainerCallbackRefreshType refreshType);

		[Abstract]
		[Export ("containerRefreshSuccess:refreshType:")]
		void RefreshSuccess (Container container, ContainerCallbackRefreshType refreshType);

		[Abstract]
		[Export ("containerRefreshFailure:failure:refreshType:")]
		void RefreshFailure (Container container, ContainerCallbackRefreshFailure failure, ContainerCallbackRefreshType refreshType);
	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "TAGContainer")]
	interface Container
	{
		[Export ("containerId", ArgumentSemantic.Copy)]
		string ContainerId { get; }

		[Export ("lastRefreshTime", ArgumentSemantic.Assign)]
		double LastRefreshTime { get; }

		[Export ("booleanForKey:")]
		bool BooleanForKey (string key);

		[Export ("doubleForKey:")]
		double DoubleForKey (string key);

		[Export ("int64ForKey:")]
		long Int64ForKey (string key);

		[Export ("stringForKey:")]
		string StringForKey (string key);

		[Export ("refresh")]
		void Refresh ();

		[Export ("close")]
		void Close ();

		[Export ("isDefault")]
		bool IsDefault { get; }

		[Export ("registerFunctionCallMacroHandler:forMacro:")]
		void RegisterFunctionCallMacroHandler ([NullAllowed] IFunctionCallMacroHandler handler, string macroName);

		[Export ("functionCallMacroHandlerForMacro:")]
		IFunctionCallMacroHandler FunctionCallMacroHandlerForMacro (string functionCallMacroName);

		[Export ("registerFunctionCallTagHandler:forTag:")]
		void RegisterFunctionCallTagHandler ([NullAllowed] IFunctionCallTagHandler handler, string tagName);

		[Export ("functionCallTagHandlerForTag:")]
		IFunctionCallTagHandler FunctionCallTagHandlerForTag (string functionCallTagName);
	}

	interface IContainerFuture
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "TAGContainerFuture")]
	interface ContainerFuture
	{
		[Abstract]
		[Export ("get")]
		Container Get ();

		[Abstract]
		[Export ("isDone")]
		bool IsDone ();
	}

	interface IContainerOpenerNotifier
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "TAGContainerOpenerNotifier")]
	interface ContainerOpenerNotifier
	{
		[Abstract]
		[Export ("containerAvailable:")]
		void ContainerAvailable (Container container);
	}

	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "TAGContainerOpener")]
	interface ContainerOpener
	{
		[Internal]
		[Static]
		[Export ("openContainerWithId:tagManager:openType:timeout:")]
		IContainerFuture _OpenContainer (string containerId, Manager tagManager, OpenType openType, IntPtr timeout);

		[Internal]
		[Static]
		[Export ("openContainerWithId:tagManager:openType:timeout:notifier:")]
		void _OpenContainer (string containerId, Manager tagManager, OpenType openType, IntPtr timeout, [NullAllowed] IContainerOpenerNotifier notifier);

		[Static]
		[Export ("defaultTimeout")]
		double DefaultTimeout { get; }
	}

	[BaseType (typeof(NSObject), Name = "TAGDataLayer")]
	interface DataLayer
	{
		[Export ("dataLayer", ArgumentSemantic.Copy)]
		NSDictionary GetDataLayer { get; }

		[Export ("pushValue:forKey:")]
		void PushValue (NSObject val, string key);

		[Export ("push:")]
		void Push (NSDictionary update);

		[Export ("get:")]
		NSObject Get (string key);
	}

	interface ILogger
	{

	}

	[Model]
	[Protocol]
	[BaseType (typeof(NSObject), Name = "TAGLogger")]
	interface Logger
	{
		[Abstract]
		[Export ("error:")]
		void Error (string message);

		[Abstract]
		[Export ("warning:")]
		void Warning (string message);

		[Abstract]
		[Export ("info:")]
		void Info (string message);

		[Abstract]
		[Export ("debug:")]
		void Debug (string message);

		[Abstract]
		[Export ("verbose:")]
		void Verbose (string message);

		[Abstract]
		[Export ("setLogLevel:")]
		void SetLogLevel (LoggerLogLevelType logLevel);

		[Abstract]
		[Export ("logLevel")]
		LoggerLogLevelType LogLevel ();
	}

	delegate void ManagerCompletionHandler (DispatchResult result);

	[BaseType (typeof(NSObject), Name = "TAGManager")]
	interface Manager
	{
		[Export ("logger", ArgumentSemantic.Retain)] [NullAllowed]
		ILogger Logger { get; set; }

		[Export ("refreshMode", ArgumentSemantic.Assign)]
		RefreshMode RefreshMode { get; set; }

		[Export ("dataLayer", ArgumentSemantic.Retain)]
		DataLayer DataLayer { get; }

		[Export ("openContainerById:callback:")]
		Container OpenContainer (string containerId, IContainerCallback callback);

		[Export ("getContainerById:")]
		Container GetContainer (string containerId);

		[Export ("previewWithUrl:")]
		bool Preview (NSUrl url);

		[Static]
		[Export ("instance")]
		Manager GetInstance { get; }

		[Export ("dispatchInterval", ArgumentSemantic.Assign)]
		double DispatchInterval { get; set; }

		[Export ("dispatch")]
		void Dispatch ();

		[Export ("dispatchWithCompletionHandler:")]
		void Dispatch (ManagerCompletionHandler completionHandler);
	}
}
