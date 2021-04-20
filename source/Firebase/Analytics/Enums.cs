using System;
using System.Collections.Generic;

using Foundation;
using ObjCRuntime;

namespace Firebase.Analytics
{
    public enum ConsentType {
		// extern FIRConsentType const FIRConsentTypeAdStorage;
		[Field ("FIRConsentTypeAdStorage", "__Internal")]
		AdStorage,

        // extern FIRConsentType const FIRConsentTypeAnalyticsStorage;
		[Field ("FIRConsentTypeAnalyticsStorage", "__Internal")]
		AnalyticsStorage,
    }

    public enum ConsentStatus {
		// extern FIRConsentStatus const FIRConsentStatusDenied;
		[Field ("FIRConsentStatusDenied", "__Internal")]
		Denied,

        // extern FIRConsentStatus const FIRConsentStatusGranted;
		[Field ("FIRConsentStatusGranted", "__Internal")]
		Granted,
    }
}
