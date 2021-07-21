// Firebase artifacts available to be built. These artifacts generate NuGets.
Artifact FIREBASE_AB_TESTING_ARTIFACT              = new Artifact ("Firebase.ABTesting",              "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "ABTesting");
Artifact FIREBASE_AD_MOB_ARTIFACT                  = new Artifact ("Firebase.AdMob",                  "8.8.0",   "10.0", ComponentGroup.Firebase, csprojName: "AdMob");
Artifact FIREBASE_ANALYTICS_ARTIFACT               = new Artifact ("Firebase.Analytics",              "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "Analytics");
Artifact FIREBASE_AUTH_ARTIFACT                    = new Artifact ("Firebase.Auth",                   "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "Auth");
Artifact FIREBASE_CLOUD_FIRESTORE_ARTIFACT         = new Artifact ("Firebase.CloudFirestore",         "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "CloudFirestore");
Artifact FIREBASE_CLOUD_FUNCTIONS_ARTIFACT         = new Artifact ("Firebase.CloudFunctions",         "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "CloudFunctions");
Artifact FIREBASE_CLOUD_MESSAGING_ARTIFACT         = new Artifact ("Firebase.CloudMessaging",         "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "CloudMessaging");
Artifact FIREBASE_CORE_ARTIFACT                    = new Artifact ("Firebase.Core",                   "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "Core");
Artifact FIREBASE_CRASHLYTICS_ARTIFACT             = new Artifact ("Firebase.Crashlytics",            "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "Crashlytics");
Artifact FIREBASE_DATABASE_ARTIFACT                = new Artifact ("Firebase.Database",               "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "Database");
Artifact FIREBASE_DYNAMIC_LINKS_ARTIFACT           = new Artifact ("Firebase.DynamicLinks",           "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "DynamicLinks");
Artifact FIREBASE_IN_APP_MESSAGING_ARTIFACT        = new Artifact ("Firebase.InAppMessaging",         "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "InAppMessaging");
Artifact FIREBASE_INSTALLATIONS_ARTIFACT           = new Artifact ("Firebase.Installations",          "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "Installations");
Artifact FIREBASE_PERFORMANCE_MONITORING_ARTIFACT  = new Artifact ("Firebase.PerformanceMonitoring",  "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "PerformanceMonitoring");
Artifact FIREBASE_REMOTE_CONFIG_ARTIFACT           = new Artifact ("Firebase.RemoteConfig",           "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "RemoteConfig");
Artifact FIREBASE_STORAGE_ARTIFACT                 = new Artifact ("Firebase.Storage",                "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "Storage");
// Artifact FIREBASE_APP_DISTRIBUTION_ARTIFACT        = new Artifact ("Firebase.AppDistribution",        "8.4.0",   "10.0", ComponentGroup.Firebase, csprojName: "AppDistribution");
// Artifact FIREBASE_APP_CHECK_ARTIFACT               = new Artifact ("Firebase.AppCheck",               "8.4.0",   "11.0", ComponentGroup.Firebase, csprojName: "AppCheck");

// Google artifacts available to be built. These artifacts generate NuGets.
Artifact GOOGLE_ANALYTICS_ARTIFACT    = new Artifact ("Google.Analytics",             "3.17.0.7", "5.0",  ComponentGroup.Google, csprojName: "Analytics");
Artifact GOOGLE_CAST_ARTIFACT         = new Artifact ("Google.Cast",                  "4.6.1.0",  "10.0", ComponentGroup.Google, csprojName: "Cast");
Artifact GOOGLE_MAPS_ARTIFACT         = new Artifact ("Google.Maps",                  "5.1.0.0",  "10.0", ComponentGroup.Google, csprojName: "Maps");
Artifact GOOGLE_MOBILE_ADS_ARTIFACT   = new Artifact ("Google.MobileAds",             "8.8.0.0",  "10.0", ComponentGroup.Google, csprojName: "MobileAds");
Artifact GOOGLE_UMP_ARTIFACT          = new Artifact ("Google.UserMessagingPlatform", "1.1.0.0",  "10.0", ComponentGroup.Google, csprojName: "UserMessagingPlatform");
Artifact GOOGLE_PLACES_ARTIFACT       = new Artifact ("Google.Places",                "5.0.0.0",  "10.0", ComponentGroup.Google, csprojName: "Places");
Artifact GOOGLE_SIGN_IN_ARTIFACT      = new Artifact ("Google.SignIn",                "5.0.2.2",  "10.0", ComponentGroup.Google, csprojName: "SignIn");
Artifact GOOGLE_TAG_MANAGER_ARTIFACT  = new Artifact ("Google.TagManager",            "7.3.1.0",  "10.0", ComponentGroup.Google, csprojName: "TagManager");

var ARTIFACTS = new Dictionary<string, Artifact> {
	{ "Firebase.ABTesting",              FIREBASE_AB_TESTING_ARTIFACT },
	{ "Firebase.AdMob",                  FIREBASE_AD_MOB_ARTIFACT },
	{ "Firebase.Analytics",              FIREBASE_ANALYTICS_ARTIFACT },
	{ "Firebase.Auth",                   FIREBASE_AUTH_ARTIFACT },
	{ "Firebase.CloudFirestore",         FIREBASE_CLOUD_FIRESTORE_ARTIFACT },
	{ "Firebase.CloudFunctions",         FIREBASE_CLOUD_FUNCTIONS_ARTIFACT },
	{ "Firebase.CloudMessaging",         FIREBASE_CLOUD_MESSAGING_ARTIFACT },
	{ "Firebase.Core",                   FIREBASE_CORE_ARTIFACT },
	{ "Firebase.Crashlytics",            FIREBASE_CRASHLYTICS_ARTIFACT },
	{ "Firebase.Database",               FIREBASE_DATABASE_ARTIFACT },
	{ "Firebase.DynamicLinks",           FIREBASE_DYNAMIC_LINKS_ARTIFACT },
	{ "Firebase.InAppMessaging",         FIREBASE_IN_APP_MESSAGING_ARTIFACT },
	{ "Firebase.Installations",          FIREBASE_INSTALLATIONS_ARTIFACT },
	{ "Firebase.PerformanceMonitoring",  FIREBASE_PERFORMANCE_MONITORING_ARTIFACT },
	{ "Firebase.RemoteConfig",           FIREBASE_REMOTE_CONFIG_ARTIFACT },
	{ "Firebase.Storage",                FIREBASE_STORAGE_ARTIFACT },
	// { "Firebase.AppDistribution",        FIREBASE_APP_DISTRIBUTION_ARTIFACT },
	// { "Firebase.AppCheck",               FIREBASE_APP_CHECK_ARTIFACT },

	{ "Google.Analytics",             GOOGLE_ANALYTICS_ARTIFACT },
	{ "Google.Cast",                  GOOGLE_CAST_ARTIFACT },	
	{ "Google.Maps",                  GOOGLE_MAPS_ARTIFACT },
	{ "Google.MobileAds",             GOOGLE_MOBILE_ADS_ARTIFACT },
	{ "Google.UserMessagingPlatform", GOOGLE_UMP_ARTIFACT },
	{ "Google.Places",                GOOGLE_PLACES_ARTIFACT },
	{ "Google.SignIn",                GOOGLE_SIGN_IN_ARTIFACT },
	{ "Google.TagManager",            GOOGLE_TAG_MANAGER_ARTIFACT },
};

void SetArtifactsDependencies ()
{
	FIREBASE_AB_TESTING_ARTIFACT.Dependencies              = new [] { FIREBASE_CORE_ARTIFACT };
	FIREBASE_AD_MOB_ARTIFACT.Dependencies                  = new [] { FIREBASE_CORE_ARTIFACT, GOOGLE_MOBILE_ADS_ARTIFACT };
	FIREBASE_ANALYTICS_ARTIFACT.Dependencies               = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT };
	FIREBASE_AUTH_ARTIFACT.Dependencies                    = new [] { FIREBASE_CORE_ARTIFACT, /* Needed for sample */ GOOGLE_SIGN_IN_ARTIFACT };
	FIREBASE_CLOUD_FIRESTORE_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT, /* Needed for sample */ FIREBASE_AUTH_ARTIFACT };
	FIREBASE_CLOUD_FUNCTIONS_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT};
	FIREBASE_CLOUD_MESSAGING_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT };
	FIREBASE_CORE_ARTIFACT.Dependencies                    = null;
	FIREBASE_CRASHLYTICS_ARTIFACT.Dependencies             = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT };
	FIREBASE_DATABASE_ARTIFACT.Dependencies                = new [] { FIREBASE_CORE_ARTIFACT, /* Needed for sample */ FIREBASE_AUTH_ARTIFACT };
	FIREBASE_DYNAMIC_LINKS_ARTIFACT.Dependencies           = new [] { FIREBASE_CORE_ARTIFACT };
	FIREBASE_IN_APP_MESSAGING_ARTIFACT.Dependencies        = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_AB_TESTING_ARTIFACT };
	FIREBASE_INSTALLATIONS_ARTIFACT.Dependencies           = new [] { FIREBASE_CORE_ARTIFACT };
	FIREBASE_PERFORMANCE_MONITORING_ARTIFACT.Dependencies  = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_AB_TESTING_ARTIFACT, FIREBASE_REMOTE_CONFIG_ARTIFACT };
	FIREBASE_REMOTE_CONFIG_ARTIFACT.Dependencies           = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_AB_TESTING_ARTIFACT };
	FIREBASE_STORAGE_ARTIFACT.Dependencies                 = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_DATABASE_ARTIFACT, /* Needed for sample */ FIREBASE_AUTH_ARTIFACT };
	// FIREBASE_APP_DISTRIBUTION_ARTIFACT.Dependencies        = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT };
	// FIREBASE_APP_CHECK_ARTIFACT.Dependencies               = new [] { FIREBASE_CORE_ARTIFACT };

	GOOGLE_ANALYTICS_ARTIFACT.Dependencies    = null;
	GOOGLE_CAST_ARTIFACT.Dependencies         = new [] { FIREBASE_CORE_ARTIFACT };
	GOOGLE_MAPS_ARTIFACT.Dependencies         = null;
	GOOGLE_MOBILE_ADS_ARTIFACT.Dependencies   = new [] { FIREBASE_CORE_ARTIFACT };
	GOOGLE_UMP_ARTIFACT.Dependencies          = null;
	GOOGLE_PLACES_ARTIFACT.Dependencies       = new [] { GOOGLE_MAPS_ARTIFACT };
	GOOGLE_SIGN_IN_ARTIFACT.Dependencies      = new [] { FIREBASE_CORE_ARTIFACT };
	GOOGLE_TAG_MANAGER_ARTIFACT.Dependencies  = new [] { FIREBASE_CORE_ARTIFACT, FIREBASE_INSTALLATIONS_ARTIFACT, FIREBASE_ANALYTICS_ARTIFACT };
}

void SetArtifactsPodSpecs ()
{
	// Firebase components
	FIREBASE_AB_TESTING_ARTIFACT.PodSpecs = new [] { 
		PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseABTesting", targetName: "FirebaseABTesting", subSpecs: new [] { "ABTesting" })
	};
	FIREBASE_AD_MOB_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", subSpecs: new [] { "AdMob" })
	};
	FIREBASE_ANALYTICS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", subSpecs: new [] { "Analytics" })
	};
	FIREBASE_AUTH_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseAuth", targetName: "FirebaseAuth", subSpecs: new [] { "Auth" })
	};
	FIREBASE_CLOUD_FIRESTORE_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase",        "8.4.0",       frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseFirestore", targetName: "FirebaseFirestore", subSpecs: new [] { "Firestore" }),
		PodSpec.Create ("BoringSSL-GRPC",  "0.0.7",        frameworkSource: FrameworkSource.Pods, frameworkName: "openssl_grpc"),
		PodSpec.Create ("gRPC-Core",       "1.28.2",       frameworkSource: FrameworkSource.Pods, frameworkName: "grpc"),
		PodSpec.Create ("gRPC-C++",        "1.28.2",       frameworkSource: FrameworkSource.Pods, frameworkName: "grpcpp"),
		PodSpec.Create ("abseil",          "0.20200225.0", frameworkSource: FrameworkSource.Pods, frameworkName: "absl", subSpecs: new [] { "algorithm", "base", "memory", "meta", "strings", "time", "types" })
	};
	FIREBASE_CLOUD_FUNCTIONS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseFunctions", targetName: "FirebaseFunctions", subSpecs: new [] { "Functions" })		
	};
	FIREBASE_CLOUD_MESSAGING_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseMessaging", targetName: "FirebaseMessaging", subSpecs: new [] { "Messaging" })		
	};
	FIREBASE_CORE_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase",                "8.4.0",     frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseCore", targetName: "FirebaseCore", subSpecs: new [] { "CoreOnly" }),		
		PodSpec.Create ("FirebaseCoreDiagnostics", "8.4.0",     frameworkSource: FrameworkSource.Pods),
		PodSpec.Create ("GTMSessionFetcher",       "1.5.0",     frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "Full" }),
		PodSpec.Create ("GoogleAPIClientForREST",  "1.5.2",     frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "Vision" }, useDefaultSubspecs: true),
		PodSpec.Create ("GoogleAppMeasurement",    "8.4.0"),
		PodSpec.Create ("GoogleDataTransport",     "9.1.0",     frameworkSource: FrameworkSource.Pods),
		PodSpec.Create ("PromisesObjC",            "2.0.0",     frameworkSource: FrameworkSource.Pods, frameworkName: "FBLPromises", targetName: "PromisesObjC"),
		PodSpec.Create ("GoogleToolboxForMac",     "2.3.1",     frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "NSData+zlib", "NSDictionary+URLArguments", "Logger", "StringEncoding", "URLBuilder" }),
		PodSpec.Create ("GoogleUtilities",         "7.5.0",     frameworkSource: FrameworkSource.Pods, subSpecs: new [] { "AppDelegateSwizzler", "Environment", "Logger", "ISASwizzler", "MethodSwizzler", "Network", "NSData+zlib", "Reachability", "UserDefaults", }),
		PodSpec.Create ("nanopb",                  "2.30908.0", frameworkSource: FrameworkSource.Pods),
		PodSpec.Create ("leveldb-library",         "1.22.1",    frameworkSource: FrameworkSource.Pods, frameworkName: "leveldb"),
		PodSpec.Create ("Protobuf",                "3.15.8",    frameworkSource: FrameworkSource.Pods, frameworkName: "Protobuf")
	};
	FIREBASE_CRASHLYTICS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseCrashlytics", targetName: "FirebaseCrashlytics", subSpecs: new [] { "Crashlytics" })
	};
	FIREBASE_DATABASE_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseDatabase", targetName: "FirebaseDatabase", subSpecs: new [] { "Database" })		
	};
	FIREBASE_DYNAMIC_LINKS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseDynamicLinks", targetName: "FirebaseDynamicLinks", subSpecs: new [] { "DynamicLinks" })
	};
	FIREBASE_IN_APP_MESSAGING_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseInAppMessaging", targetName: "FirebaseInAppMessaging", subSpecs: new [] { "InAppMessaging" })
	};
	FIREBASE_INSTALLATIONS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("FirebaseInstallations", "8.4.0", frameworkSource: FrameworkSource.Pods)
	};
	FIREBASE_PERFORMANCE_MONITORING_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebasePerformance", targetName: "FirebasePerformance",  subSpecs: new [] { "Performance" })
	};
	FIREBASE_REMOTE_CONFIG_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseRemoteConfig", targetName: "FirebaseRemoteConfig", subSpecs: new [] { "RemoteConfig" })
	};
	FIREBASE_STORAGE_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseStorage", targetName: "FirebaseStorage", subSpecs: new [] { "Storage" })		
	};
	// FIREBASE_APP_DISTRIBUTION_ARTIFACT.PodSpecs = new [] {
	// 	PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseAppDistribution", targetName: "FirebaseAppDistribution", subSpecs: new [] { "AppDistribution" })		
	// };
	// FIREBASE_APP_CHECK_ARTIFACT.PodSpecs = new [] {
	// 	PodSpec.Create ("Firebase", "8.4.0", frameworkSource: FrameworkSource.Pods, frameworkName: "FirebaseAppCheck", targetName: "FirebaseAppCheck", subSpecs: new [] { "AppCheck" })		
	// };

	// Google components
	GOOGLE_ANALYTICS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GoogleAnalytics", "3.17.0")
	};
	GOOGLE_CAST_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("google-cast-sdk", "4.6.1")
	};
	GOOGLE_MAPS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GoogleMaps", "5.0.0")
	};
	GOOGLE_MOBILE_ADS_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("Google-Mobile-Ads-SDK", "8.7.0")
	};
	GOOGLE_UMP_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GoogleUserMessagingPlatform", "1.1.0")
	};
	GOOGLE_PLACES_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GooglePlaces", "5.0.0")
	};
	GOOGLE_SIGN_IN_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GoogleSignIn", "5.0.2"),
		PodSpec.Create ("AppAuth",      "1.4.0", frameworkSource: FrameworkSource.Pods),
		PodSpec.Create ("GTMAppAuth",   "1.2.1", frameworkSource: FrameworkSource.Pods),
	};
	GOOGLE_TAG_MANAGER_ARTIFACT.PodSpecs = new [] {
		PodSpec.Create ("GoogleTagManager", "7.3.1")
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
	FIREBASE_CLOUD_FUNCTIONS_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_CLOUD_MESSAGING_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_CRASHLYTICS_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_CORE_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_DATABASE_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_DYNAMIC_LINKS_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_INSTALLATIONS_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_PERFORMANCE_MONITORING_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_REMOTE_CONFIG_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	FIREBASE_STORAGE_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	// FIREBASE_APP_DISTRIBUTION_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	// FIREBASE_APP_CHECK_ARTIFACT.ExtraPodfileLines = dynamicFrameworkLines;
	
	var inAppMessagingWorkaround = new [] {
		"post_install do |installer|",
		"\tinstaller.pods_project.targets.each do |pod|",
		"\t\tif pod.name == \"FirebaseInAppMessaging\"",
		"\t\t\tpod.build_configurations.each do |config|",
		"\t\t\t\tif config.name == 'Release'",
		"\t\t\t\t\tputs \"Linking missing 'GoogleUtilities' framework to #{pod.name}\"",
		"\t\t\t\t\tconfig.build_settings['OTHER_LDFLAGS'] ||= ['$(inherited)','-framework \"GoogleUtilities\"']",
		"\t\t\t\tend",
		"\t\t\tend",
		"\t\tend",
		"\tend",
		"end",
	};

	var inAppMessagingLines = new List<string> ();
	inAppMessagingLines.AddRange (dynamicFrameworkLines);
	inAppMessagingLines.AddRange (inAppMessagingWorkaround);

	FIREBASE_IN_APP_MESSAGING_ARTIFACT.ExtraPodfileLines = inAppMessagingLines.ToArray ();
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
	FIREBASE_IN_APP_MESSAGING_ARTIFACT.Samples        = new [] { "InAppMessagingSample" };
	FIREBASE_INSTALLATIONS_ARTIFACT.Samples           = null;
	FIREBASE_PERFORMANCE_MONITORING_ARTIFACT.Samples  = new [] { "PerformanceMonitoringSample" };
	FIREBASE_REMOTE_CONFIG_ARTIFACT.Samples           = new [] { "RemoteConfigSample" };
	FIREBASE_STORAGE_ARTIFACT.Samples                 = new [] { "StorageSample" };
	//FIREBASE_APP_DISTRIBUTION_ARTIFACT.Samples        = new [] { "AppDistributionSample" };
	//FIREBASE_APP_CHECK_ARTIFACT.Samples               = new [] { "AppCheckSample" };

	// Google components
	GOOGLE_ANALYTICS_ARTIFACT.Samples                 = new [] { "CuteAnimalsiOS" };
	GOOGLE_CAST_ARTIFACT.Samples                      = new [] { "CastSample" };
	GOOGLE_MAPS_ARTIFACT.Samples                      = new [] { "GoogleMapsAdvSample", "GoogleMapsSample" };
	GOOGLE_MOBILE_ADS_ARTIFACT.Samples                = new [] { "MobileAdsExample" };
	GOOGLE_PLACES_ARTIFACT.Samples                    = new [] { "GooglePlacesSample" };
	GOOGLE_SIGN_IN_ARTIFACT.Samples                   = new [] { "SignInExample" };
	GOOGLE_TAG_MANAGER_ARTIFACT.Samples               = new [] { "TagManagerSample" };
}
