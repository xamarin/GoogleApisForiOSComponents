// Firebase artifacts available to be built. These artifacts generate NuGets.
Artifact FIREBASE_AB_TESTING_ARTIFACT              = new Artifact ("Firebase.ABTesting",              "2.0.0.2",  "8.0", ComponentGroup.Firebase, csprojName: "ABTesting");
Artifact FIREBASE_AD_MOB_ARTIFACT                  = new Artifact ("Firebase.AdMob",                  "7.47.0",   "8.0", ComponentGroup.Firebase, csprojName: "AdMob");
Artifact FIREBASE_ANALYTICS_ARTIFACT               = new Artifact ("Firebase.Analytics",              "6.0.4",    "8.0", ComponentGroup.Firebase, csprojName: "Analytics");
Artifact FIREBASE_AUTH_ARTIFACT                    = new Artifact ("Firebase.Auth",                   "5.0.4.1",  "8.0", ComponentGroup.Firebase, csprojName: "Auth");
Artifact FIREBASE_CLOUD_FIRESTORE_ARTIFACT         = new Artifact ("Firebase.CloudFirestore",         "0.13.3",   "8.0", ComponentGroup.Firebase, csprojName: "CloudFirestore");
Artifact FIREBASE_CLOUD_MESSAGING_ARTIFACT         = new Artifact ("Firebase.CloudMessaging",         "3.1.2",    "8.0", ComponentGroup.Firebase, csprojName: "CloudMessaging");
Artifact FIREBASE_CORE_ARTIFACT                    = new Artifact ("Firebase.Core",                   "6.1.0",    "8.0", ComponentGroup.Firebase, csprojName: "Core");
Artifact FIREBASE_CRASHLYTICS_ARTIFACT             = new Artifact ("Firebase.Crashlytics",            "3.10.9",   "8.0", ComponentGroup.Firebase, csprojName: "Crashlytics");
Artifact FIREBASE_DATABASE_ARTIFACT                = new Artifact ("Firebase.Database",               "5.0.3",    "8.0", ComponentGroup.Firebase, csprojName: "Database");
Artifact FIREBASE_DYNAMIC_LINKS_ARTIFACT           = new Artifact ("Firebase.DynamicLinks",           "3.0.2.1",  "8.0", ComponentGroup.Firebase, csprojName: "DynamicLinks");
Artifact FIREBASE_INSTANCE_ID_ARTIFACT             = new Artifact ("Firebase.InstanceID",             "4.2.1",    "8.0", ComponentGroup.Firebase, csprojName: "InstanceID");
Artifact FIREBASE_INVITES_ARTIFACT                 = new Artifact ("Firebase.Invites",                "3.0.1.2",  "8.0", ComponentGroup.Firebase, csprojName: "Invites");
Artifact FIREBASE_MLKIT_ARTIFACT                   = new Artifact ("Firebase.MLKit",                  "0.13.0.1", "9.0", ComponentGroup.Firebase, csprojName: "MLKit");
Artifact FIREBASE_MLKIT_COMMON_ARTIFACT            = new Artifact ("Firebase.MLKit.Common",           "0.13.0",   "9.0", ComponentGroup.Firebase, csprojName: "MLKit.Common");
Artifact FIREBASE_MLKIT_MODEL_INTERPRETER_ARTIFACT = new Artifact ("Firebase.MLKit.ModelInterpreter", "0.13.0",   "9.0", ComponentGroup.Firebase, csprojName: "MLKit.ModelInterpreter");
Artifact FIREBASE_PERFORMANCE_MONITORING_ARTIFACT  = new Artifact ("Firebase.PerformanceMonitoring",  "2.2.2",    "8.0", ComponentGroup.Firebase, csprojName: "PerformanceMonitoring");
Artifact FIREBASE_REMOTE_CONFIG_ARTIFACT           = new Artifact ("Firebase.RemoteConfig",           "3.1.0",    "8.0", ComponentGroup.Firebase, csprojName: "RemoteConfig");
Artifact FIREBASE_STORAGE_ARTIFACT                 = new Artifact ("Firebase.Storage",                "3.0.2",    "8.0", ComponentGroup.Firebase, csprojName: "Storage");

// Google artifacts available to be built. These artifacts generate NuGets.
Artifact GOOGLE_ANALYTICS_ARTIFACT    = new Artifact ("Google.Analytics",   "3.17.0.3", "5.0", ComponentGroup.Google, csprojName: "Analytics");
Artifact GOOGLE_APP_INDEXING_ARTIFACT = new Artifact ("Google.AppIndexing", "2.0.3.5",  "7.0", ComponentGroup.Google, csprojName: "AppIndexing");
Artifact GOOGLE_CAST_ARTIFACT         = new Artifact ("Google.Cast",        "4.4.2",    "8.0", ComponentGroup.Google, csprojName: "Cast");
Artifact GOOGLE_CORE_ARTIFACT         = new Artifact ("Google.Core",        "3.1.0.1",  "7.0", ComponentGroup.Google, csprojName: "Core");
Artifact GOOGLE_INSTANCE_ID_ARTIFACT  = new Artifact ("Google.InstanceID",  "1.2.1.15", "7.0", ComponentGroup.Google, csprojName: "InstanceID");
Artifact GOOGLE_MAPS_ARTIFACT         = new Artifact ("Google.Maps",        "3.1.0",    "9.0", ComponentGroup.Google, csprojName: "Maps");
Artifact GOOGLE_MOBILE_ADS_ARTIFACT   = new Artifact ("Google.MobileAds",   "7.47.0",   "8.0", ComponentGroup.Google, csprojName: "MobileAds");
Artifact GOOGLE_PLACES_ARTIFACT       = new Artifact ("Google.Places",      "3.1.0",    "9.0", ComponentGroup.Google, csprojName: "Places");
Artifact GOOGLE_SIGN_IN_ARTIFACT      = new Artifact ("Google.SignIn",      "4.4.0",    "8.0", ComponentGroup.Google, csprojName: "SignIn");
Artifact GOOGLE_TAG_MANAGER_ARTIFACT  = new Artifact ("Google.TagManager",  "7.1.1.2",  "8.0", ComponentGroup.Google, csprojName: "TagManager");

var ARTIFACTS = new Dictionary<string, Artifact> {
	{ "Firebase.ABTesting",              FIREBASE_AB_TESTING_ARTIFACT },
	{ "Firebase.AdMob",                  FIREBASE_AD_MOB_ARTIFACT },
	{ "Firebase.Analytics",              FIREBASE_ANALYTICS_ARTIFACT },
	{ "Firebase.Auth",                   FIREBASE_AUTH_ARTIFACT },
	{ "Firebase.CloudFirestore",         FIREBASE_CLOUD_FIRESTORE_ARTIFACT },
	{ "Firebase.CloudMessaging",         FIREBASE_CLOUD_MESSAGING_ARTIFACT },
	{ "Firebase.Core",                   FIREBASE_CORE_ARTIFACT },
	{ "Firebase.Crashlytics",            FIREBASE_CRASHLYTICS_ARTIFACT },
	{ "Firebase.Database",               FIREBASE_DATABASE_ARTIFACT },
	{ "Firebase.DynamicLinks",           FIREBASE_DYNAMIC_LINKS_ARTIFACT },
	{ "Firebase.InstanceID",             FIREBASE_INSTANCE_ID_ARTIFACT },
	{ "Firebase.Invites",                FIREBASE_INVITES_ARTIFACT },
	{ "Firebase.MLKit",                  FIREBASE_MLKIT_ARTIFACT },
	{ "Firebase.MLKit.Common",           FIREBASE_MLKIT_COMMON_ARTIFACT },
	{ "Firebase.MLKit.ModelInterpreter", FIREBASE_MLKIT_MODEL_INTERPRETER_ARTIFACT },
	{ "Firebase.PerformanceMonitoring",  FIREBASE_PERFORMANCE_MONITORING_ARTIFACT },
	{ "Firebase.RemoteConfig",           FIREBASE_REMOTE_CONFIG_ARTIFACT },
	{ "Firebase.Storage",                FIREBASE_STORAGE_ARTIFACT },

	{ "Google.Analytics",   GOOGLE_ANALYTICS_ARTIFACT },
	{ "Google.Appindexing", GOOGLE_APP_INDEXING_ARTIFACT },
	{ "Google.Cast",        GOOGLE_CAST_ARTIFACT },
	{ "Google.Core",        GOOGLE_CORE_ARTIFACT },
	{ "Google.InstanceID",  GOOGLE_INSTANCE_ID_ARTIFACT },
	{ "Google.Maps",        GOOGLE_MAPS_ARTIFACT },
	{ "Google.MobileAds",   GOOGLE_MOBILE_ADS_ARTIFACT },
	{ "Google.Places",      GOOGLE_PLACES_ARTIFACT },
	{ "Google.SignIn",      GOOGLE_SIGN_IN_ARTIFACT },
	{ "Google.TagManager",  GOOGLE_TAG_MANAGER_ARTIFACT },
};

void SetArtifactsDependencies ()
{
	FIREBASE_AB_TESTING_ARTIFACT.Dependencies              = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT };
	FIREBASE_AD_MOB_ARTIFACT.Dependencies                  = new [] { FIREBASE_CORE_ARTIFACT, GOOGLE_MOBILE_ADS_ARTIFACT };
	FIREBASE_ANALYTICS_ARTIFACT.Dependencies               = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT };
	FIREBASE_AUTH_ARTIFACT.Dependencies                    = new [] { FIREBASE_CORE_ARTIFACT };
	FIREBASE_CLOUD_FIRESTORE_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT };
	FIREBASE_CLOUD_MESSAGING_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT };
	FIREBASE_CORE_ARTIFACT.Dependencies                    = null;
	FIREBASE_CRASHLYTICS_ARTIFACT.Dependencies             = null;
	FIREBASE_DATABASE_ARTIFACT.Dependencies                = new [] { FIREBASE_CORE_ARTIFACT };
	FIREBASE_DYNAMIC_LINKS_ARTIFACT.Dependencies           = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT };
	FIREBASE_INSTANCE_ID_ARTIFACT.Dependencies             = new [] { FIREBASE_CORE_ARTIFACT };
	FIREBASE_INVITES_ARTIFACT.Dependencies                 = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT, FIREBASE_DYNAMIC_LINKS_ARTIFACT, GOOGLE_SIGN_IN_ARTIFACT };
	FIREBASE_MLKIT_ARTIFACT.Dependencies                   = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_MLKIT_COMMON_ARTIFACT };
	FIREBASE_MLKIT_COMMON_ARTIFACT.Dependencies            = new [] { FIREBASE_CORE_ARTIFACT };
	FIREBASE_MLKIT_MODEL_INTERPRETER_ARTIFACT.Dependencies = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_MLKIT_COMMON_ARTIFACT };
	FIREBASE_PERFORMANCE_MONITORING_ARTIFACT.Dependencies  = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT };
	FIREBASE_REMOTE_CONFIG_ARTIFACT.Dependencies           = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT, FIREBASE_AB_TESTING_ARTIFACT };
	FIREBASE_STORAGE_ARTIFACT.Dependencies                 = new [] { FIREBASE_CORE_ARTIFACT };

	GOOGLE_ANALYTICS_ARTIFACT.Dependencies    = null;
	GOOGLE_APP_INDEXING_ARTIFACT.Dependencies = null;
	GOOGLE_CAST_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT };
	GOOGLE_CORE_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT };
	GOOGLE_INSTANCE_ID_ARTIFACT.Dependencies  = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT, GOOGLE_CORE_ARTIFACT };
	GOOGLE_MAPS_ARTIFACT.Dependencies         = null;
	GOOGLE_MOBILE_ADS_ARTIFACT.Dependencies   = new [] { FIREBASE_CORE_ARTIFACT };
	GOOGLE_PLACES_ARTIFACT.Dependencies       = new [] { GOOGLE_MAPS_ARTIFACT };
	GOOGLE_SIGN_IN_ARTIFACT.Dependencies      = new [] { FIREBASE_CORE_ARTIFACT };
	GOOGLE_TAG_MANAGER_ARTIFACT.Dependencies  = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT, GOOGLE_ANALYTICS_ARTIFACT };
}

void SetArtifactsPodSpecs ()
{
	// Firebase components
	FIREBASE_AB_TESTING_ARTIFACT.PodSpecs = new [] { 
		new PodSpec ("Firebase", "5.8.1", subSpecs: new [] { "ABTesting" })
	};
	FIREBASE_AD_MOB_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase", "6.5.0", subSpecs: new [] { "AdMob" })
	};
	FIREBASE_ANALYTICS_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase",             "6.5.0", subSpecs: new [] { "Analytics" })
	};
	FIREBASE_AUTH_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase", "5.8.1", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseAuth", targetName: "FirebaseAuth", subSpecs: new [] { "Auth" })
	};
	FIREBASE_CLOUD_FIRESTORE_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase",       "5.8.1",  frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseFirestore", targetName: "FirebaseFirestore", subSpecs: new [] { "Firestore" }),
		new PodSpec ("BoringSSL",      "10.0.6", frameworkSource: FrameworkSource.Pods, frameworkName: "openssl"),
		new PodSpec ("gRPC-ProtoRPC",  "1.14.0", frameworkSource: FrameworkSource.Pods, frameworkName: "ProtoRPC"),
		new PodSpec ("gRPC",           "1.14.0", frameworkSource: FrameworkSource.Pods, frameworkName: "GRPCClient"),
		new PodSpec ("gRPC-Core",      "1.14.0", frameworkSource: FrameworkSource.Pods, frameworkName: "grpc"),
		new PodSpec ("gRPC-RxLibrary", "1.14.0", frameworkSource: FrameworkSource.Pods, frameworkName: "RxLibrary"),
		new PodSpec ("gRPC-C++",       "0.0.3",  frameworkSource: FrameworkSource.Pods, frameworkName: "grpcpp"),
	};
	FIREBASE_CLOUD_MESSAGING_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase", "5.8.1", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseMessaging", targetName: "FirebaseMessaging", subSpecs: new [] { "Messaging" })
	};
	FIREBASE_CORE_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase",               "6.5.0",   frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseCore", targetName: "FirebaseCore", subSpecs: new [] { "CoreOnly" }),
		new PodSpec ("FirebaseAuthInterop",    "1.0.0",   frameworkSource: FrameworkSource.Pods, canBeBuild: false),
		new PodSpec ("GoogleUtilities",        "6.2.3",   frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "AppDelegateSwizzler", "Environment", "ISASwizzler", "Logger", "MethodSwizzler", "Network", "NSData+zlib", "Reachability", "UserDefaults" }),
		new PodSpec ("GoogleToolboxForMac",    "2.1.4",   frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "NSData+zlib", "NSDictionary+URLArguments", "Logger", "StringEncoding", "URLBuilder" }),
		new PodSpec ("GoogleAPIClientForREST", "1.3.7",   frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "Vision" }, useDefaultSubspecs: true),
		new PodSpec ("GTMSessionFetcher",      "1.2.1",   frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "Full" }),
		new PodSpec ("leveldb-library",        "1.20.0",  frameworkSource: FrameworkSource.Pods, frameworkName: "leveldb"),
		new PodSpec ("nanopb",                 "0.3.901", frameworkSource: FrameworkSource.Pods),
		new PodSpec ("Protobuf",               "3.6.1",   frameworkSource: FrameworkSource.Pods),
		new PodSpec ("GoogleAppMeasurement",   "6.0.4")
	};
	FIREBASE_CRASHLYTICS_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Crashlytics", "3.10.9"),
		new PodSpec ("Fabric",      "1.7.13")
	};
	FIREBASE_DATABASE_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase", "5.8.1", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseDatabase", targetName: "FirebaseDatabase", subSpecs: new [] { "Database" })
	};
	FIREBASE_DYNAMIC_LINKS_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase", "5.8.1", subSpecs: new [] { "DynamicLinks" })
	};
	FIREBASE_INSTANCE_ID_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("FirebaseInstanceID", "4.2.1", frameworkSource: FrameworkSource.Pods)
	};
	FIREBASE_INVITES_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase", "5.8.1", subSpecs: new [] { "Invites" })
	};
	FIREBASE_MLKIT_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase",           "5.13.0", subSpecs: new [] { "MLVision", "MLVisionBarcodeModel", "MLVisionFaceModel", "MLVisionLabelModel", "MLVisionTextModel" }),
		new PodSpec ("GoogleMobileVision", "1.5.0")
	};
	FIREBASE_MLKIT_COMMON_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase", "5.13.0", subSpecs: new [] { "MLCommon" })
	};
	FIREBASE_MLKIT_MODEL_INTERPRETER_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase",       "5.13.0", subSpecs: new [] { "MLModelInterpreter" }),
		new PodSpec ("TensorFlowLite", "1.10.1")
	};
	FIREBASE_PERFORMANCE_MONITORING_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase", "5.16.0", subSpecs: new [] { "Performance" })
	};
	FIREBASE_REMOTE_CONFIG_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase", "5.16.0", subSpecs: new [] { "RemoteConfig" })
	};
	FIREBASE_STORAGE_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Firebase", "5.8.1", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseStorage", targetName: "FirebaseStorage", subSpecs: new [] { "Storage" })
	};

	// Google components
	GOOGLE_ANALYTICS_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("GoogleAnalytics", "3.17.0")
	};
	GOOGLE_APP_INDEXING_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("GoogleAppIndexing", "2.0.3")
	};
	GOOGLE_CAST_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("google-cast-sdk", "4.3.2")
	};
	GOOGLE_CORE_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Google", "3.1.0", subSpecs: new [] { "Core" })
	};
	GOOGLE_INSTANCE_ID_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("GGLInstanceID", "1.2.1"),
		new PodSpec ("GoogleIPhoneUtilities", "1.2.0")
	};
	GOOGLE_MAPS_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("GoogleMaps", "3.1.0")
	};
	GOOGLE_MOBILE_ADS_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("Google-Mobile-Ads-SDK", "7.47.0"),
		new PodSpec ("PersonalizedAdConsent", "1.0.3", frameworkSource: FrameworkSource.Pods)
	};
	GOOGLE_PLACES_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("GooglePlaces", "3.1.0")
	};
	GOOGLE_SIGN_IN_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("GoogleSignIn", "4.4.0")
	};
	GOOGLE_TAG_MANAGER_ARTIFACT.PodSpecs = new [] {
		new PodSpec ("GoogleTagManager", "7.1.1")
	};
}

void SetArtifactsExtraPodfileLines ()
{
	var staticFrameworkLines = new [] {	
		"=begin",
		"This override the static_framework flag to false,",
		"in order to be able to build dynamic frameworks.",
		"=end",
		"pre_install do |installer|",
		"\tinstaller.pod_targets.each do |pod|",
		"\t\tdef pod.static_framework?;",
		"\t\t\tfalse",
		"\t\tend",
		"\tend",
		"end",
	};

	FIREBASE_CORE_ARTIFACT.ExtraPodfileLines = staticFrameworkLines;
	FIREBASE_INSTANCE_ID_ARTIFACT.ExtraPodfileLines = staticFrameworkLines;
}

void SetArtifactsSamples ()
{
	// Firebase components
	FIREBASE_AB_TESTING_ARTIFACT.Samples              = null;
	FIREBASE_AD_MOB_ARTIFACT.Samples                  = new [] { "AdMobSample" };
	FIREBASE_ANALYTICS_ARTIFACT.Samples               = new [] { "AnalyticsSample" };
	FIREBASE_AUTH_ARTIFACT.Samples                    = new [] { "AuthSample" };
	FIREBASE_CLOUD_FIRESTORE_ARTIFACT.Samples         = new [] { "CloudFirestoreSample" };
	FIREBASE_CLOUD_MESSAGING_ARTIFACT.Samples         = new [] { "CloudMessagingSample" };
	FIREBASE_CORE_ARTIFACT.Samples                    = null;
	FIREBASE_CRASHLYTICS_ARTIFACT.Samples             = new [] { "CrashlyticsSample" };
	FIREBASE_DATABASE_ARTIFACT.Samples                = new [] { "DatabaseSample" };
	FIREBASE_DYNAMIC_LINKS_ARTIFACT.Samples           = new [] { "DynamicLinksSample" };
	FIREBASE_INSTANCE_ID_ARTIFACT.Samples             = null;
	FIREBASE_INVITES_ARTIFACT.Samples                 = new [] { "InvitesSample" };
	FIREBASE_MLKIT_ARTIFACT.Samples                   = new [] { "MLKitSample" };
	FIREBASE_MLKIT_COMMON_ARTIFACT.Samples            = null;
	FIREBASE_MLKIT_MODEL_INTERPRETER_ARTIFACT.Samples = new [] { "ModelInterpreterSample" };
	FIREBASE_PERFORMANCE_MONITORING_ARTIFACT.Samples  = new [] { "PerformanceMonitoringSample" };
	FIREBASE_REMOTE_CONFIG_ARTIFACT.Samples           = new [] { "RemoteConfigSample" };
	FIREBASE_STORAGE_ARTIFACT.Samples                 = new [] { "StorageSample" };

	// Google components
	GOOGLE_ANALYTICS_ARTIFACT.Samples                 = new [] { "CuteAnimalsiOS" };
	GOOGLE_APP_INDEXING_ARTIFACT.Samples              = new [] { "AppIndexingSample" };
	GOOGLE_CAST_ARTIFACT.Samples                      = new [] { "CastSample" };
	GOOGLE_CORE_ARTIFACT.Samples                      = null;
	GOOGLE_INSTANCE_ID_ARTIFACT.Samples               = new [] { "InstanceIDSample" };
	GOOGLE_MAPS_ARTIFACT.Samples                      = new [] { "GoogleMapsAdvSample", "GoogleMapsSample" };
	GOOGLE_MOBILE_ADS_ARTIFACT.Samples                = new [] { "MobileAdsExample" };
	GOOGLE_PLACES_ARTIFACT.Samples                    = new [] { "GooglePlacesSample" };
	GOOGLE_SIGN_IN_ARTIFACT.Samples                   = new [] { "SignInExample" };
	GOOGLE_TAG_MANAGER_ARTIFACT.Samples               = new [] { "TagManagerSample" };
}

