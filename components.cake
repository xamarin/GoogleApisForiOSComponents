// Firebase artifacts available to be built. These artifacts generate NuGets.
Artifact FIREBASE_AB_TESTING_ARTIFACT              = new Artifact ("Firebase.ABTesting",              "3.2.0",        "8.0", ComponentGroup.Firebase, csprojName: "ABTesting");
Artifact FIREBASE_AD_MOB_ARTIFACT                  = new Artifact ("Firebase.AdMob",                  "7.56.0",       "8.0", ComponentGroup.Firebase, csprojName: "AdMob");
Artifact FIREBASE_ANALYTICS_ARTIFACT               = new Artifact ("Firebase.Analytics",              "6.4.0",        "8.0", ComponentGroup.Firebase, csprojName: "Analytics");
Artifact FIREBASE_AUTH_ARTIFACT                    = new Artifact ("Firebase.Auth",                   "6.5.0",        "8.0", ComponentGroup.Firebase, csprojName: "Auth");
Artifact FIREBASE_CLOUD_FIRESTORE_ARTIFACT         = new Artifact ("Firebase.CloudFirestore",         "1.11.2",       "8.0", ComponentGroup.Firebase, csprojName: "CloudFirestore");
Artifact FIREBASE_CLOUD_MESSAGING_ARTIFACT         = new Artifact ("Firebase.CloudMessaging",         "4.3.0",        "8.0", ComponentGroup.Firebase, csprojName: "CloudMessaging");
Artifact FIREBASE_CORE_ARTIFACT                    = new Artifact ("Firebase.Core",                   "6.6.5",        "8.0", ComponentGroup.Firebase, csprojName: "Core");
Artifact FIREBASE_CRASHLYTICS_ARTIFACT             = new Artifact ("Firebase.Crashlytics",            "4.0.0-beta.5", "8.0", ComponentGroup.Firebase, csprojName: "Crashlytics");
Artifact FIREBASE_DATABASE_ARTIFACT                = new Artifact ("Firebase.Database",               "6.1.4",        "8.0", ComponentGroup.Firebase, csprojName: "Database");
Artifact FIREBASE_DYNAMIC_LINKS_ARTIFACT           = new Artifact ("Firebase.DynamicLinks",           "4.0.7",        "8.0", ComponentGroup.Firebase, csprojName: "DynamicLinks");
Artifact FIREBASE_INSTALLATIONS_ARTIFACT           = new Artifact ("Firebase.Installations",          "1.1.1",        "8.0", ComponentGroup.Firebase, csprojName: "Installations");
Artifact FIREBASE_INSTANCE_ID_ARTIFACT             = new Artifact ("Firebase.InstanceID",             "4.3.2",        "8.0", ComponentGroup.Firebase, csprojName: "InstanceID");
Artifact FIREBASE_MLKIT_ARTIFACT                   = new Artifact ("Firebase.MLKit",                  "0.19.0",       "9.0", ComponentGroup.Firebase, csprojName: "MLKit");
Artifact FIREBASE_MLKIT_COMMON_ARTIFACT            = new Artifact ("Firebase.MLKit.Common",           "0.19.0",       "9.0", ComponentGroup.Firebase, csprojName: "MLKit.Common");
Artifact FIREBASE_MLKIT_MODEL_INTERPRETER_ARTIFACT = new Artifact ("Firebase.MLKit.ModelInterpreter", "0.19.0",       "9.0", ComponentGroup.Firebase, csprojName: "MLKit.ModelInterpreter");
Artifact FIREBASE_MLKIT_NATURAL_LANGUAGE_ARTIFACT  = new Artifact ("Firebase.MLKit.NaturalLanguage",  "0.17.0",       "9.0", ComponentGroup.Firebase, csprojName: "MLKit.NaturalLanguage");
Artifact FIREBASE_MLKIT_VISION_ARTIFACT            = new Artifact ("Firebase.MLKit.Vision",           "0.19.0",       "9.0", ComponentGroup.Firebase, csprojName: "MLKit.Vision");
Artifact FIREBASE_PERFORMANCE_MONITORING_ARTIFACT  = new Artifact ("Firebase.PerformanceMonitoring",  "3.1.10",       "8.0", ComponentGroup.Firebase, csprojName: "PerformanceMonitoring");
Artifact FIREBASE_REMOTE_CONFIG_ARTIFACT           = new Artifact ("Firebase.RemoteConfig",           "4.4.9",        "8.0", ComponentGroup.Firebase, csprojName: "RemoteConfig");
Artifact FIREBASE_STORAGE_ARTIFACT                 = new Artifact ("Firebase.Storage",                "3.6.0",        "8.0", ComponentGroup.Firebase, csprojName: "Storage");

// Google artifacts available to be built. These artifacts generate NuGets.
Artifact GOOGLE_ANALYTICS_ARTIFACT    = new Artifact ("Google.Analytics",   "3.17.0.6", "5.0", ComponentGroup.Google, csprojName: "Analytics");
Artifact GOOGLE_APP_INDEXING_ARTIFACT = new Artifact ("Google.AppIndexing", "2.0.3.8",  "7.0", ComponentGroup.Google, csprojName: "AppIndexing");
Artifact GOOGLE_CAST_ARTIFACT         = new Artifact ("Google.Cast",        "4.4.6.1",  "9.0", ComponentGroup.Google, csprojName: "Cast");
Artifact GOOGLE_CORE_ARTIFACT         = new Artifact ("Google.Core",        "3.1.0.4",  "7.0", ComponentGroup.Google, csprojName: "Core");
Artifact GOOGLE_INSTANCE_ID_ARTIFACT  = new Artifact ("Google.InstanceID",  "1.2.1.18", "7.0", ComponentGroup.Google, csprojName: "InstanceID");
Artifact GOOGLE_MAPS_ARTIFACT         = new Artifact ("Google.Maps",        "3.7.0.1",  "9.0", ComponentGroup.Google, csprojName: "Maps");
Artifact GOOGLE_MOBILE_ADS_ARTIFACT   = new Artifact ("Google.MobileAds",   "7.56.0",   "8.0", ComponentGroup.Google, csprojName: "MobileAds");
Artifact GOOGLE_PLACES_ARTIFACT       = new Artifact ("Google.Places",      "3.7.0.1",  "9.0", ComponentGroup.Google, csprojName: "Places");
Artifact GOOGLE_SIGN_IN_ARTIFACT      = new Artifact ("Google.SignIn",      "5.0.2.1",  "8.0", ComponentGroup.Google, csprojName: "SignIn");
Artifact GOOGLE_TAG_MANAGER_ARTIFACT  = new Artifact ("Google.TagManager",  "7.1.2.3",  "8.0", ComponentGroup.Google, csprojName: "TagManager");

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
	{ "Firebase.Installations",          FIREBASE_INSTALLATIONS_ARTIFACT },
	{ "Firebase.InstanceID",             FIREBASE_INSTANCE_ID_ARTIFACT },
	{ "Firebase.MLKit",                  FIREBASE_MLKIT_ARTIFACT },
	{ "Firebase.MLKit.Common",           FIREBASE_MLKIT_COMMON_ARTIFACT },
	{ "Firebase.MLKit.ModelInterpreter", FIREBASE_MLKIT_MODEL_INTERPRETER_ARTIFACT },
	{ "Firebase.MLKit.NaturalLanguage",  FIREBASE_MLKIT_NATURAL_LANGUAGE_ARTIFACT },
	{ "Firebase.MLKit.Vision",           FIREBASE_MLKIT_VISION_ARTIFACT },
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
	FIREBASE_AB_TESTING_ARTIFACT.Dependencies              = new [] { FIREBASE_CORE_ARTIFACT };
	FIREBASE_AD_MOB_ARTIFACT.Dependencies                  = new [] { FIREBASE_CORE_ARTIFACT, GOOGLE_MOBILE_ADS_ARTIFACT };
	FIREBASE_ANALYTICS_ARTIFACT.Dependencies               = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT };
	FIREBASE_AUTH_ARTIFACT.Dependencies                    = new [] { FIREBASE_CORE_ARTIFACT, /* Needed for sample */ GOOGLE_SIGN_IN_ARTIFACT };
	FIREBASE_CLOUD_FIRESTORE_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT, /* Needed for sample */ FIREBASE_AUTH_ARTIFACT };
	FIREBASE_CLOUD_MESSAGING_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT };
	FIREBASE_CORE_ARTIFACT.Dependencies                    = null;
	FIREBASE_CRASHLYTICS_ARTIFACT.Dependencies             = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT };
	FIREBASE_DATABASE_ARTIFACT.Dependencies                = new [] { FIREBASE_CORE_ARTIFACT, /* Needed for sample */ FIREBASE_AUTH_ARTIFACT };
	FIREBASE_DYNAMIC_LINKS_ARTIFACT.Dependencies           = new [] { FIREBASE_CORE_ARTIFACT };
	FIREBASE_INSTALLATIONS_ARTIFACT.Dependencies           = new [] { FIREBASE_CORE_ARTIFACT };
	FIREBASE_INSTANCE_ID_ARTIFACT.Dependencies             = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT };
	FIREBASE_MLKIT_ARTIFACT.Dependencies                   = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_AB_TESTING_ARTIFACT, FIREBASE_REMOTE_CONFIG_ARTIFACT, FIREBASE_MLKIT_COMMON_ARTIFACT, FIREBASE_MLKIT_MODEL_INTERPRETER_ARTIFACT, FIREBASE_MLKIT_NATURAL_LANGUAGE_ARTIFACT, FIREBASE_MLKIT_VISION_ARTIFACT };
	FIREBASE_MLKIT_COMMON_ARTIFACT.Dependencies            = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT };
	FIREBASE_MLKIT_MODEL_INTERPRETER_ARTIFACT.Dependencies = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_MLKIT_COMMON_ARTIFACT };
	FIREBASE_MLKIT_NATURAL_LANGUAGE_ARTIFACT.Dependencies  = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_MLKIT_COMMON_ARTIFACT, FIREBASE_AB_TESTING_ARTIFACT, FIREBASE_REMOTE_CONFIG_ARTIFACT };
	FIREBASE_MLKIT_VISION_ARTIFACT.Dependencies            = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_MLKIT_COMMON_ARTIFACT };
	FIREBASE_PERFORMANCE_MONITORING_ARTIFACT.Dependencies  = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_AB_TESTING_ARTIFACT, FIREBASE_REMOTE_CONFIG_ARTIFACT };
	FIREBASE_REMOTE_CONFIG_ARTIFACT.Dependencies           = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_AB_TESTING_ARTIFACT };
	FIREBASE_STORAGE_ARTIFACT.Dependencies                 = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_DATABASE_ARTIFACT, /* Needed for sample */ FIREBASE_AUTH_ARTIFACT };

	GOOGLE_ANALYTICS_ARTIFACT.Dependencies    = null;
	GOOGLE_APP_INDEXING_ARTIFACT.Dependencies = null;
	GOOGLE_CAST_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT };
	GOOGLE_CORE_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT };
	GOOGLE_INSTANCE_ID_ARTIFACT.Dependencies  = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT, GOOGLE_CORE_ARTIFACT };
	GOOGLE_MAPS_ARTIFACT.Dependencies         = null;
	GOOGLE_MOBILE_ADS_ARTIFACT.Dependencies   = new [] { FIREBASE_CORE_ARTIFACT };
	GOOGLE_PLACES_ARTIFACT.Dependencies       = new [] { GOOGLE_MAPS_ARTIFACT };
	GOOGLE_SIGN_IN_ARTIFACT.Dependencies      = new [] { FIREBASE_CORE_ARTIFACT };
	GOOGLE_TAG_MANAGER_ARTIFACT.Dependencies  = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_INSTANCE_ID_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT, GOOGLE_ANALYTICS_ARTIFACT };
}

void SetArtifactsPodSpecs ()
{
	// Firebase components
	FIREBASE_AB_TESTING_ARTIFACT.PodSpecs = new [] { 
		PodSpec.Create ("Firebase", "6.20.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseABTesting", targetName: "FirebaseABTesting", subSpecs: new [] { "ABTesting" })
	};
	FIREBASE_AD_MOB_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", subSpecs: new [] { "AdMob" })
	};
	FIREBASE_ANALYTICS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.21.0", subSpecs: new [] { "Analytics" })
	};
	FIREBASE_AUTH_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseAuth", targetName: "FirebaseAuth", subSpecs: new [] { "Auth" })
	};
	FIREBASE_CLOUD_FIRESTORE_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase",       "6.20.0",      frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseFirestore", targetName: "FirebaseFirestore", subSpecs: new [] { "Firestore" }),
		PodSpec.Create ("BoringSSL-GRPC", "0.0.3",       frameworkSource: FrameworkSource.Pods, frameworkName: "openssl_grpc"),
		PodSpec.Create ("gRPC-Core",      "1.21.0",      frameworkSource: FrameworkSource.Pods, frameworkName: "grpc"),
		PodSpec.Create ("gRPC-C++",       "0.0.9",       frameworkSource: FrameworkSource.Pods, frameworkName: "grpcpp"),
		PodSpec.Create ("abseil",         "0.20190808",  frameworkSource: FrameworkSource.Pods, frameworkName: "absl", subSpecs: new [] { "algorithm", "base", "memory", "meta", "strings", "time", "types" })
	};
	FIREBASE_CLOUD_MESSAGING_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseMessaging", targetName: "FirebaseMessaging", subSpecs: new [] { "Messaging" })
	};
	FIREBASE_CORE_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase",                       "6.21.0",   frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseCore", targetName: "FirebaseCore", subSpecs: new [] { "CoreOnly" }),
		PodSpec.Create ("FirebaseAuthInterop",            "1.1.0",    frameworkSource: FrameworkSource.Pods, canBeBuild: false),
		PodSpec.Create ("FirebaseAnalyticsInterop",       "1.5.0",    frameworkSource: FrameworkSource.Pods, canBeBuild: false),
		PodSpec.Create ("FirebaseCoreDiagnostics",        "1.2.2",    frameworkSource: FrameworkSource.Pods),
		PodSpec.Create ("FirebaseCoreDiagnosticsInterop", "1.2.0",    frameworkSource: FrameworkSource.Pods, canBeBuild: false),
		PodSpec.Create ("GoogleAPIClientForREST",         "1.3.7",    frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "Vision" }, useDefaultSubspecs: true),
		PodSpec.Create ("GoogleAppMeasurement",           "6.4.0"),
		PodSpec.Create ("GoogleDataTransport",            "5.1.0",    frameworkSource: FrameworkSource.Pods),
		PodSpec.Create ("GoogleDataTransportCCTSupport",  "2.0.1",    frameworkSource: FrameworkSource.Pods),
		PodSpec.Create ("GoogleToolboxForMac",            "2.2.2",    frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "NSData+zlib", "NSDictionary+URLArguments", "Logger", "StringEncoding", "URLBuilder" }),
		PodSpec.Create ("GoogleUtilities",                "6.5.2",    frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "AppDelegateSwizzler", "Environment", "ISASwizzler", "Logger", "MethodSwizzler", "Network", "NSData+zlib", "Reachability", "UserDefaults" }),
		PodSpec.Create ("GTMSessionFetcher",              "1.3.1",    frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "Full" }),
		PodSpec.Create ("leveldb-library",                "1.22.0",   frameworkSource: FrameworkSource.Pods, frameworkName: "leveldb"),
		PodSpec.Create ("nanopb",                         "0.3.9011", frameworkSource: FrameworkSource.Pods),
		PodSpec.Create ("Protobuf",                       "3.11.4",   frameworkSource: FrameworkSource.Pods, frameworkName: "protobuf")
	};
	FIREBASE_CRASHLYTICS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseCrashlytics", targetName: "FirebaseCrashlytics", subSpecs: new [] { "Crashlytics" })
	};
	FIREBASE_DATABASE_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseDatabase", targetName: "FirebaseDatabase", subSpecs: new [] { "Database" })
	};
	FIREBASE_DYNAMIC_LINKS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseDynamicLinks", targetName: "FirebaseDynamicLinks", subSpecs: new [] { "DynamicLinks" })
	};
	FIREBASE_INSTALLATIONS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("FirebaseInstallations", "1.1.1", frameworkSource: FrameworkSource.Pods),
		PodSpec.Create ("PromisesObjC",          "1.2.8", frameworkSource: FrameworkSource.Pods, frameworkName: "FBLPromises", targetName: "PromisesObjC")
	};
	FIREBASE_INSTANCE_ID_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("FirebaseInstanceID",    "4.3.2", frameworkSource: FrameworkSource.Pods)
	};
	FIREBASE_MLKIT_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", subSpecs: new [] { "MLCommon", "MLModelInterpreter", "MLNaturalLanguage", "MLVision" })
	};
	FIREBASE_MLKIT_COMMON_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", subSpecs: new [] { "MLCommon" }),
		PodSpec.Create ("TensorFlowLiteObjC", "1.14.0", frameworkSource: FrameworkSource.Pods, frameworkName: "TFLTensorFlowLite", targetName: "TensorFlowLiteObjC"),
		PodSpec.Create ("TensorFlowLiteC",    "1.14.0")
	};
	FIREBASE_MLKIT_MODEL_INTERPRETER_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", subSpecs: new [] { "MLModelInterpreter" })
	};
	FIREBASE_MLKIT_NATURAL_LANGUAGE_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", subSpecs: new [] { "MLNaturalLanguage", "MLNLLanguageID", "MLNLSmartReply", "MLNLTranslate" })
	};
	FIREBASE_MLKIT_VISION_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", subSpecs: new [] { "MLVision", "MLVisionAutoML", "MLVisionBarcodeModel", "MLVisionFaceModel", "MLVisionLabelModel", "MLVisionTextModel", "MLVisionObjectDetection" })
	};
	FIREBASE_PERFORMANCE_MONITORING_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", subSpecs: new [] { "Performance" })
	};
	FIREBASE_REMOTE_CONFIG_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseRemoteConfig", targetName: "FirebaseRemoteConfig", subSpecs: new [] { "RemoteConfig" })
	};
	FIREBASE_STORAGE_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "6.20.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseStorage", targetName: "FirebaseStorage", subSpecs: new [] { "Storage" })
	};

	// Google components
	GOOGLE_ANALYTICS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GoogleAnalytics", "3.17.0")
	};
	GOOGLE_APP_INDEXING_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GoogleAppIndexing", "2.0.3")
	};
	GOOGLE_CAST_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("google-cast-sdk", "4.4.5")
	};
	GOOGLE_CORE_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Google", "3.1.0", subSpecs: new [] { "Core" })
	};
	GOOGLE_INSTANCE_ID_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GGLInstanceID", "1.2.1"),
		PodSpec.Create ("GoogleIPhoneUtilities", "1.2.0")
	};
	GOOGLE_MAPS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GoogleMaps", "3.7.0")
	};
	GOOGLE_MOBILE_ADS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Google-Mobile-Ads-SDK", "7.56.0"),
		PodSpec.Create ("PersonalizedAdConsent", "1.0.5", frameworkSource: FrameworkSource.Pods)
	};
	GOOGLE_PLACES_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GooglePlaces", "3.7.0")
	};
	GOOGLE_SIGN_IN_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GoogleSignIn", "5.0.2"),
		PodSpec.Create ("AppAuth",      "1.3.0", frameworkSource: FrameworkSource.Pods),
		PodSpec.Create ("GTMAppAuth",   "1.0.0", frameworkSource: FrameworkSource.Pods),
	};
	GOOGLE_TAG_MANAGER_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GoogleTagManager", "7.1.2")
	};
}

void SetArtifactsExtraPodfileLines ()
{
	var dynamicFrameworkLines = new [] {	
		"=begin",
		"This override the static_framework flag to false,",
		"in order to be able to build dynamic frameworks.",
		"=end",
		"pre_install do |installer|",
		"\tinstaller.pod_targets.each do |pod|",
		"\tputs \"Forcing a static_framework to false for #{pod.name}\"",
		"\t\tif Pod::VERSION >= \"1.7.0\"",
		"\t\t\tif pod.build_as_static?",
		"\t\t\t\tdef pod.build_as_static?; false end",
		"\t\t\t\tdef pod.build_as_static_framework?; false end",
		"\t\t\t\tdef pod.build_as_dynamic?; true end",
		"\t\t\t\tdef pod.build_as_dynamic_framework?; true end",
		"\t\t\tend",
		"\t\telse",
		"\t\t\tdef pod.static_framework?; false end",
		"\t\tend",
		"\tend",
		"end",
	};

	FIREBASE_AB_TESTING_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_AUTH_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_CLOUD_FIRESTORE_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_CLOUD_MESSAGING_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_CORE_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_DATABASE_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_DYNAMIC_LINKS_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_INSTANCE_ID_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_REMOTE_CONFIG_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_STORAGE_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
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
	FIREBASE_INSTALLATIONS_ARTIFACT.Samples           = null;
	FIREBASE_INSTANCE_ID_ARTIFACT.Samples             = null;
	FIREBASE_MLKIT_ARTIFACT.Samples                   = new [] { "MLKitSample" };
	FIREBASE_MLKIT_COMMON_ARTIFACT.Samples            = null;
	FIREBASE_MLKIT_MODEL_INTERPRETER_ARTIFACT.Samples = new [] { "ModelInterpreterSample" };
	FIREBASE_MLKIT_NATURAL_LANGUAGE_ARTIFACT.Samples  = new [] { "NaturalLanguageSample" };
	FIREBASE_MLKIT_VISION_ARTIFACT.Samples            = new [] { "MLKitVisionSample" };
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
