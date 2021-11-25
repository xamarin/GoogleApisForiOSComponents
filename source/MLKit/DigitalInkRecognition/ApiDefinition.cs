using System;

using UIKit;
using Foundation;
using CoreGraphics;
using ObjCRuntime;

using MLKit.Core;

namespace MLKit.DigitalInkRecognition {
	#region ModelIdentifiers
	[Static]
	interface ModelIdentifiers {
		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.autodraw) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAutodraw __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.autodraw")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierAutodraw", "__Internal")]
		IntPtr _Autodraw { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.emoji) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEmoji __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.emoji")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEmoji", "__Internal")]
		IntPtr _Emoji { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.shapes) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierShapes __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.shapes")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierShapes", "__Internal")]
		IntPtr _Shapes { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.aaLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAaLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.aaLatn")));		
		[Field ("MLKDigitalInkRecognitionModelIdentifierAaLatn", "__Internal")]
		IntPtr _AaLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.absLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAbsLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.absLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierAbsLatnId", "__Internal")]
		IntPtr _AbsLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.aceLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAceLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.aceLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierAceLatnId", "__Internal")]
		IntPtr _AceLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.actLatnNl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierActLatnNl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.actLatnNl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierActLatnNl", "__Internal")]
		IntPtr _ActLatnNl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.af) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAf __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.af")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierAf", "__Internal")]
		IntPtr _Af { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.am) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAm __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.am")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierAm", "__Internal")]
		IntPtr _Am { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.anLatnEs) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAnLatnEs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.anLatnEs")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierAnLatnEs", "__Internal")]
		IntPtr _AnLatnEs { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.anwLatnNg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAnwLatnNg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.anwLatnNg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierAnwLatnNg", "__Internal")]
		IntPtr _AnwLatnNg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ar) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ar")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierAr", "__Internal")]
		IntPtr _Ar { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.as) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.as")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierAs", "__Internal")]
		IntPtr _As { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.awaDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAwaDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.awaDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierAwaDevaIn", "__Internal")]
		IntPtr _AwaDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.azLatnAz) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierAzLatnAz __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.azLatnAz")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierAzLatnAz", "__Internal")]
		IntPtr _AzLatnAz { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bahLatnBs) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBahLatnBs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bahLatnBs")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBahLatnBs", "__Internal")]
		IntPtr _BahLatnBs { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.barLatnAt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBarLatnAt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.barLatnAt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBarLatnAt", "__Internal")]
		IntPtr _BarLatnAt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bcqLatnEt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBcqLatnEt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bcqLatnEt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBcqLatnEt", "__Internal")]
		IntPtr _BcqLatnEt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.be) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.be")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBe", "__Internal")]
		IntPtr _Be { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.berLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBerLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.berLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBerLatn", "__Internal")]
		IntPtr _BerLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bewLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBewLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bewLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBewLatnId", "__Internal")]
		IntPtr _BewLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bfyDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBfyDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bfyDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBfyDevaIn", "__Internal")]
		IntPtr _BfyDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bfzDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBfzDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bfzDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBfzDevaIn", "__Internal")]
		IntPtr _BfzDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBg", "__Internal")]
		IntPtr _Bg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bgcDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBgcDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bgcDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBgcDevaIn", "__Internal")]
		IntPtr _BgcDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bgqDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBgqDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bgqDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBgqDevaIn", "__Internal")]
		IntPtr _BgqDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bgqDevaPk) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBgqDevaPk __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bgqDevaPk")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBgqDevaPk", "__Internal")]
		IntPtr _BgqDevaPk { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bgxLatnTr) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBgxLatnTr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bgxLatnTr")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBgxLatnTr", "__Internal")]
		IntPtr _BgxLatnTr { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bgzLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBgzLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bgzLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBgzLatnId", "__Internal")]
		IntPtr _BgzLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bhbDeva) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBhbDeva __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bhbDeva")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBhbDeva", "__Internal")]
		IntPtr _BhbDeva { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bhoDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBhoDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bhoDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBhoDevaIn", "__Internal")]
		IntPtr _BhoDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.biLatnVu) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBiLatnVu __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.biLatnVu")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBiLatnVu", "__Internal")]
		IntPtr _BiLatnVu { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bikLatnPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBikLatnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bikLatnPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBikLatnPh", "__Internal")]
		IntPtr _BikLatnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bjjDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBjjDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bjjDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBjjDevaIn", "__Internal")]
		IntPtr _BjjDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bjnLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBjnLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bjnLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBjnLatnId", "__Internal")]
		IntPtr _BjnLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBn", "__Internal")]
		IntPtr _Bn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bnLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBnLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bnLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBnLatn", "__Internal")]
		IntPtr _BnLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.boTibt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBoTibt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.boTibt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBoTibt", "__Internal")]
		IntPtr _BoTibt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bomLatnNg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBomLatnNg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bomLatnNg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBomLatnNg", "__Internal")]
		IntPtr _BomLatnNg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.brxDeva) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBrxDeva __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.brxDeva")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBrxDeva", "__Internal")]
		IntPtr _BrxDeva { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.brxLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBrxLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.brxLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBrxLatn", "__Internal")]
		IntPtr _BrxLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bs) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bs")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBs", "__Internal")]
		IntPtr _Bs { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.btoLatnPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBtoLatnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.btoLatnPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBtoLatnPh", "__Internal")]
		IntPtr _BtoLatnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.btzLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBtzLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.btzLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBtzLatnId", "__Internal")]
		IntPtr _BtzLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.bzcLatnMg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierBzcLatnMg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.bzcLatnMg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierBzcLatnMg", "__Internal")]
		IntPtr _BzcLatnMg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ca) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierCa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ca")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierCa", "__Internal")]
		IntPtr _Ca { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.cebLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierCebLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.cebLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierCebLatn", "__Internal")]
		IntPtr _CebLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.cggLatnUg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierCggLatnUg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.cggLatnUg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierCggLatnUg", "__Internal")]
		IntPtr _CggLatnUg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.chGu) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierChGu __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.chGu")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierChGu", "__Internal")]
		IntPtr _ChGu { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.cjkLatnCd) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierCjkLatnCd __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.cjkLatnCd")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierCjkLatnCd", "__Internal")]
		IntPtr _CjkLatnCd { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.coLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierCoLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.coLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierCoLatn", "__Internal")]
		IntPtr _CoLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.cpsLatnPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierCpsLatnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.cpsLatnPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierCpsLatnPh", "__Internal")]
		IntPtr _CpsLatnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.crsLatnSc) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierCrsLatnSc __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.crsLatnSc")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierCrsLatnSc", "__Internal")]
		IntPtr _CrsLatnSc { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.cs) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierCs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.cs")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierCs", "__Internal")]
		IntPtr _Cs { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.cy) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierCy __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.cy")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierCy", "__Internal")]
		IntPtr _Cy { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.cyoLatnPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierCyoLatnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.cyoLatnPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierCyoLatnPh", "__Internal")]
		IntPtr _CyoLatnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.da) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.da")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDa", "__Internal")]
		IntPtr _Da { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.de) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.de")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDe", "__Internal")]
		IntPtr _De { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.deAt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDeAt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.deAt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDeAt", "__Internal")]
		IntPtr _DeAt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.deBe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDeBe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.deBe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDeBe", "__Internal")]
		IntPtr _DeBe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.deCh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDeCh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.deCh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDeCh", "__Internal")]
		IntPtr _DeCh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.deDe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDeDe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.deDe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDeDe", "__Internal")]
		IntPtr _DeDe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.deLu) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDeLu __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.deLu")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDeLu", "__Internal")]
		IntPtr _DeLu { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.dnjLatnCi) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDnjLatnCi __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.dnjLatnCi")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDnjLatnCi", "__Internal")]
		IntPtr _DnjLatnCi { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.doiDeva) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDoiDeva __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.doiDeva")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDoiDeva", "__Internal")]
		IntPtr _DoiDeva { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.doiLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDoiLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.doiLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDoiLatn", "__Internal")]
		IntPtr _DoiLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.drsLatnEt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDrsLatnEt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.drsLatnEt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDrsLatnEt", "__Internal")]
		IntPtr _DrsLatnEt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.drtLatnNl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDrtLatnNl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.drtLatnNl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDrtLatnNl", "__Internal")]
		IntPtr _DrtLatnNl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.dsbDe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierDsbDe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.dsbDe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierDsbDe", "__Internal")]
		IntPtr _DsbDe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.el) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.el")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEl", "__Internal")]
		IntPtr _El { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.en) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.en")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEn", "__Internal")]
		IntPtr _En { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.enAu) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEnAu __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.enAu")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEnAu", "__Internal")]
		IntPtr _EnAu { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.enCa) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEnCa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.enCa")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEnCa", "__Internal")]
		IntPtr _EnCa { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.enGb) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEnGb __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.enGb")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEnGb", "__Internal")]
		IntPtr _EnGb { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.enIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEnIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.enIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEnIn", "__Internal")]
		IntPtr _EnIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.enKe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEnKe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.enKe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEnKe", "__Internal")]
		IntPtr _EnKe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.enNg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEnNg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.enNg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEnNg", "__Internal")]
		IntPtr _EnNg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.enPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.enPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEnPh", "__Internal")]
		IntPtr _EnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.enUs) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEnUs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.enUs")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEnUs", "__Internal")]
		IntPtr _EnUs { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.enZa) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEnZa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.enZa")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEnZa", "__Internal")]
		IntPtr _EnZa { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.eo) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEo __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.eo")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEo", "__Internal")]
		IntPtr _Eo { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.es) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.es")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEs", "__Internal")]
		IntPtr _Es { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.esAr) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEsAr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.esAr")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEsAr", "__Internal")]
		IntPtr _EsAr { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.esEs) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEsEs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.esEs")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEsEs", "__Internal")]
		IntPtr _EsEs { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.esMx) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEsMx __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.esMx")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEsMx", "__Internal")]
		IntPtr _EsMx { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.esUs) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEsUs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.esUs")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEsUs", "__Internal")]
		IntPtr _EsUs { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.et) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.et")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEt", "__Internal")]
		IntPtr _Et { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.etEe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEtEe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.etEe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEtEe", "__Internal")]
		IntPtr _EtEe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.eu) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEu __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.eu")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEu", "__Internal")]
		IntPtr _Eu { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.euEs) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierEuEs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.euEs")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierEuEs", "__Internal")]
		IntPtr _EuEs { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.extLatnEs) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierExtLatnEs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.extLatnEs")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierExtLatnEs", "__Internal")]
		IntPtr _ExtLatnEs { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.fa) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.fa")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFa", "__Internal")]
		IntPtr _Fa { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.fanLatnGq) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFanLatnGq __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.fanLatnGq")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFanLatnGq", "__Internal")]
		IntPtr _FanLatnGq { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.fi) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFi __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.fi")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFi", "__Internal")]
		IntPtr _Fi { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.filLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFilLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.filLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFilLatn", "__Internal")]
		IntPtr _FilLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.fjFj) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFjFj __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.fjFj")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFjFj", "__Internal")]
		IntPtr _FjFj { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.foFo) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFoFo __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.foFo")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFoFo", "__Internal")]
		IntPtr _FoFo { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.fr) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.fr")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFr", "__Internal")]
		IntPtr _Fr { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.fr002) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFr002 __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.fr002")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFr002", "__Internal")]
		IntPtr _Fr002 { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.frBe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFrBe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.frBe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFrBe", "__Internal")]
		IntPtr _FrBe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.frCa) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFrCa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.frCa")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFrCa", "__Internal")]
		IntPtr _FrCa { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.frCh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFrCh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.frCh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFrCh", "__Internal")]
		IntPtr _FrCh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.frFr) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFrFr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.frFr")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFrFr", "__Internal")]
		IntPtr _FrFr { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.fy) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierFy __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.fy")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierFy", "__Internal")]
		IntPtr _Fy { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ga) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ga")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGa", "__Internal")]
		IntPtr _Ga { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gaxLatnEt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGaxLatnEt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gaxLatnEt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGaxLatnEt", "__Internal")]
		IntPtr _GaxLatnEt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gayLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGayLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gayLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGayLatnId", "__Internal")]
		IntPtr _GayLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gbmDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGbmDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gbmDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGbmDevaIn", "__Internal")]
		IntPtr _GbmDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gcrLatnGf) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGcrLatnGf __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gcrLatnGf")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGcrLatnGf", "__Internal")]
		IntPtr _GcrLatnGf { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gdLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGdLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gdLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGdLatn", "__Internal")]
		IntPtr _GdLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gdLatnGb) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGdLatnGb __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gdLatnGb")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGdLatnGb", "__Internal")]
		IntPtr _GdLatnGb { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gdxDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGdxDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gdxDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGdxDevaIn", "__Internal")]
		IntPtr _GdxDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gjuDeva) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGjuDeva __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gjuDeva")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGjuDeva", "__Internal")]
		IntPtr _GjuDeva { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGl", "__Internal")]
		IntPtr _Gl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.glEs) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGlEs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.glEs")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGlEs", "__Internal")]
		IntPtr _GlEs { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gosLatnNl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGosLatnNl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gosLatnNl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGosLatnNl", "__Internal")]
		IntPtr _GosLatnNl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gpeLatnGh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGpeLatnGh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gpeLatnGh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGpeLatnGh", "__Internal")]
		IntPtr _GpeLatnGh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gswCh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGswCh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gswCh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGswCh", "__Internal")]
		IntPtr _GswCh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gu) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGu __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gu")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGu", "__Internal")]
		IntPtr _Gu { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.guLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGuLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.guLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGuLatn", "__Internal")]
		IntPtr _GuLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gv) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGv __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gv")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGv", "__Internal")]
		IntPtr _Gv { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.gynLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierGynLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.gynLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierGynLatn", "__Internal")]
		IntPtr _GynLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.haqLatnTz) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHaqLatnTz __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.haqLatnTz")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHaqLatnTz", "__Internal")]
		IntPtr _HaqLatnTz { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hawLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHawLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hawLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHawLatn", "__Internal")]
		IntPtr _HawLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hdyLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHdyLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hdyLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHdyLatn", "__Internal")]
		IntPtr _HdyLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.he) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.he")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHe", "__Internal")]
		IntPtr _He { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hi) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHi __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hi")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHi", "__Internal")]
		IntPtr _Hi { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hiLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHiLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hiLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHiLatn", "__Internal")]
		IntPtr _HiLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hifDeva) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHifDeva __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hifDeva")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHifDeva", "__Internal")]
		IntPtr _HifDeva { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hilLatnPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHilLatnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hilLatnPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHilLatnPh", "__Internal")]
		IntPtr _HilLatnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hmnLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHmnLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hmnLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHmnLatn", "__Internal")]
		IntPtr _HmnLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hneDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHneDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hneDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHneDevaIn", "__Internal")]
		IntPtr _HneDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hniLatnCn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHniLatnCn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hniLatnCn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHniLatnCn", "__Internal")]
		IntPtr _HniLatnCn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hoLatnPg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHoLatnPg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hoLatnPg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHoLatnPg", "__Internal")]
		IntPtr _HoLatnPg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hojDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHojDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hojDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHojDevaIn", "__Internal")]
		IntPtr _HojDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hr) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hr")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHr", "__Internal")]
		IntPtr _Hr { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hrxLatnBr) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHrxLatnBr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hrxLatnBr")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHrxLatnBr", "__Internal")]
		IntPtr _HrxLatnBr { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ht) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ht")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHt", "__Internal")]
		IntPtr _Ht { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hu) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHu __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hu")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHu", "__Internal")]
		IntPtr _Hu { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.hy) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierHy __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.hy")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierHy", "__Internal")]
		IntPtr _Hy { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.id) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.id")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierId", "__Internal")]
		IntPtr _Id { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.igbLatnNg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierIgbLatnNg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.igbLatnNg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierIgbLatnNg", "__Internal")]
		IntPtr _IgbLatnNg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.iiLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierIiLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.iiLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierIiLatn", "__Internal")]
		IntPtr _IiLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.iloLatnPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierIloLatnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.iloLatnPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierIloLatnPh", "__Internal")]
		IntPtr _IloLatnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.is) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierIs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.is")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierIs", "__Internal")]
		IntPtr _Is { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.it) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierIt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.it")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierIt", "__Internal")]
		IntPtr _It { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.itCh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierItCh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.itCh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierItCh", "__Internal")]
		IntPtr _ItCh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.itIt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierItIt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.itIt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierItIt", "__Internal")]
		IntPtr _ItIt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.iumLatnCn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierIumLatnCn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.iumLatnCn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierIumLatnCn", "__Internal")]
		IntPtr _IumLatnCn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ja) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierJa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ja")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierJa", "__Internal")]
		IntPtr _Ja { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.jamLatnJm) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierJamLatnJm __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.jamLatnJm")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierJamLatnJm", "__Internal")]
		IntPtr _JamLatnJm { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.jaxLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierJaxLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.jaxLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierJaxLatnId", "__Internal")]
		IntPtr _JaxLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.jboLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierJboLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.jboLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierJboLatn", "__Internal")]
		IntPtr _JboLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.jvLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierJvLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.jvLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierJvLatn", "__Internal")]
		IntPtr _JvLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ka) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ka")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKa", "__Internal")]
		IntPtr _Ka { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kdeLatnTz) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKdeLatnTz __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kdeLatnTz")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKdeLatnTz", "__Internal")]
		IntPtr _KdeLatnTz { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kfrDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKfrDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kfrDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKfrDevaIn", "__Internal")]
		IntPtr _KfrDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kfyDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKfyDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kfyDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKfyDevaIn", "__Internal")]
		IntPtr _KfyDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kgeLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKgeLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kgeLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKgeLatnId", "__Internal")]
		IntPtr _KgeLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.khaLatnIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKhaLatnIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.khaLatnIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKhaLatnIn", "__Internal")]
		IntPtr _KhaLatnIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kjLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKjLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kjLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKjLatn", "__Internal")]
		IntPtr _KjLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kk) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKk __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kk")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKk", "__Internal")]
		IntPtr _Kk { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKl", "__Internal")]
		IntPtr _Kl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.km) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKm __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.km")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKm", "__Internal")]
		IntPtr _Km { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kmbLatnAo) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKmbLatnAo __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kmbLatnAo")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKmbLatnAo", "__Internal")]
		IntPtr _KmbLatnAo { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kmzLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKmzLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kmzLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKmzLatn", "__Internal")]
		IntPtr _KmzLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKn", "__Internal")]
		IntPtr _Kn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.knLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKnLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.knLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKnLatn", "__Internal")]
		IntPtr _KnLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ko) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKo __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ko")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKo", "__Internal")]
		IntPtr _Ko { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kok) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKok __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kok")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKok", "__Internal")]
		IntPtr _Kok { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kokIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKokIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kokIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKokIn", "__Internal")]
		IntPtr _KokIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kokLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKokLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kokLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKokLatn", "__Internal")]
		IntPtr _KokLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kruDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKruDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kruDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKruDevaIn", "__Internal")]
		IntPtr _KruDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ksDeva) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKsDeva __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ksDeva")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKsDeva", "__Internal")]
		IntPtr _KsDeva { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ksLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKsLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ksLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKsLatn", "__Internal")]
		IntPtr _KsLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kshLatnDe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKshLatnDe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kshLatnDe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKshLatnDe", "__Internal")]
		IntPtr _KshLatnDe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ktbLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKtbLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ktbLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKtbLatn", "__Internal")]
		IntPtr _KtbLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ktuLatnCd) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKtuLatnCd __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ktuLatnCd")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKtuLatnCd", "__Internal")]
		IntPtr _KtuLatnCd { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kuLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKuLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kuLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKuLatn", "__Internal")]
		IntPtr _KuLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kwLatnGb) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKwLatnGb __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kwLatnGb")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKwLatnGb", "__Internal")]
		IntPtr _KwLatnGb { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.kyCyrl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierKyCyrl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.kyCyrl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierKyCyrl", "__Internal")]
		IntPtr _KyCyrl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.la) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.la")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLa", "__Internal")]
		IntPtr _La { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ladLatnBa) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLadLatnBa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ladLatnBa")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLadLatnBa", "__Internal")]
		IntPtr _LadLatnBa { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.lajLatnUg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLajLatnUg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.lajLatnUg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLajLatnUg", "__Internal")]
		IntPtr _LajLatnUg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.lb) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLb __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.lb")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLb", "__Internal")]
		IntPtr _Lb { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ledLatnCd) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLedLatnCd __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ledLatnCd")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLedLatnCd", "__Internal")]
		IntPtr _LedLatnCd { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.lldLatnIt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLldLatnIt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.lldLatnIt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLldLatnIt", "__Internal")]
		IntPtr _LldLatnIt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.lmnDeva) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLmnDeva __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.lmnDeva")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLmnDeva", "__Internal")]
		IntPtr _LmnDeva { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.lo) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLo __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.lo")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLo", "__Internal")]
		IntPtr _Lo { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.lonLatnMw) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLonLatnMw __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.lonLatnMw")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLonLatnMw", "__Internal")]
		IntPtr _LonLatnMw { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.lt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.lt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLt", "__Internal")]
		IntPtr _Lt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.luyLatnKe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLuyLatnKe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.luyLatnKe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLuyLatnKe", "__Internal")]
		IntPtr _LuyLatnKe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.lv) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierLv __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.lv")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierLv", "__Internal")]
		IntPtr _Lv { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.madLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMadLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.madLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMadLatnId", "__Internal")]
		IntPtr _MadLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.magDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMagDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.magDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMagDevaIn", "__Internal")]
		IntPtr _MagDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.maiIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMaiIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.maiIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMaiIn", "__Internal")]
		IntPtr _MaiIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.maiLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMaiLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.maiLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMaiLatn", "__Internal")]
		IntPtr _MaiLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.masLatnKe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMasLatnKe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.masLatnKe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMasLatnKe", "__Internal")]
		IntPtr _MasLatnKe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.maxLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMaxLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.maxLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMaxLatnId", "__Internal")]
		IntPtr _MaxLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mdhLatnPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMdhLatnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mdhLatnPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMdhLatnPh", "__Internal")]
		IntPtr _MdhLatnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.melLatnMy) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMelLatnMy __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.melLatnMy")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMelLatnMy", "__Internal")]
		IntPtr _MelLatnMy { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.meoLatnMy) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMeoLatnMy __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.meoLatnMy")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMeoLatnMy", "__Internal")]
		IntPtr _MeoLatnMy { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mfbLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMfbLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mfbLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMfbLatnId", "__Internal")]
		IntPtr _MfbLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mfpLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMfpLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mfpLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMfpLatnId", "__Internal")]
		IntPtr _MfpLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMg", "__Internal")]
		IntPtr _Mg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.miLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMiLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.miLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMiLatn", "__Internal")]
		IntPtr _MiLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.minLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMinLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.minLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMinLatnId", "__Internal")]
		IntPtr _MinLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mk) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMk __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mk")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMk", "__Internal")]
		IntPtr _Mk { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ml) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ml")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMl", "__Internal")]
		IntPtr _Ml { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mlLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMlLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mlLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMlLatn", "__Internal")]
		IntPtr _MlLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mnCyrl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMnCyrl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mnCyrl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMnCyrl", "__Internal")]
		IntPtr _MnCyrl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mniLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMniLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mniLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMniLatn", "__Internal")]
		IntPtr _MniLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mqyLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMqyLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mqyLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMqyLatnId", "__Internal")]
		IntPtr _MqyLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mr) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mr")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMr", "__Internal")]
		IntPtr _Mr { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mrIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMrIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mrIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMrIn", "__Internal")]
		IntPtr _MrIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mrLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMrLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mrLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMrLatn", "__Internal")]
		IntPtr _MrLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mrwLatnPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMrwLatnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mrwLatnPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMrwLatnPh", "__Internal")]
		IntPtr _MrwLatnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ms) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ms")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMs", "__Internal")]
		IntPtr _Ms { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.msBn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMsBn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.msBn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMsBn", "__Internal")]
		IntPtr _MsBn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.msMy) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMsMy __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.msMy")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMsMy", "__Internal")]
		IntPtr _MsMy { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.msiLatnMy) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMsiLatnMy __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.msiLatnMy")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMsiLatnMy", "__Internal")]
		IntPtr _MsiLatnMy { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMt", "__Internal")]
		IntPtr _Mt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mtrDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMtrDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mtrDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMtrDevaIn", "__Internal")]
		IntPtr _MtrDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.muiLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMuiLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.muiLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMuiLatnId", "__Internal")]
		IntPtr _MuiLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mupDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMupDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mupDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMupDevaIn", "__Internal")]
		IntPtr _MupDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mveDevaPk) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMveDevaPk __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mveDevaPk")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMveDevaPk", "__Internal")]
		IntPtr _MveDevaPk { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mwrDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMwrDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mwrDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMwrDevaIn", "__Internal")]
		IntPtr _MwrDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.mwwLatnCn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMwwLatnCn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.mwwLatnCn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMwwLatnCn", "__Internal")]
		IntPtr _MwwLatnCn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.my) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMy __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.my")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMy", "__Internal")]
		IntPtr _My { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.myxLatnUg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierMyxLatnUg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.myxLatnUg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierMyxLatnUg", "__Internal")]
		IntPtr _MyxLatnUg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.nahLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNahLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.nahLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNahLatn", "__Internal")]
		IntPtr _NahLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.napLatnIt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNapLatnIt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.napLatnIt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNapLatnIt", "__Internal")]
		IntPtr _NapLatnIt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ndcLatnZw) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNdcLatnZw __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ndcLatnZw")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNdcLatnZw", "__Internal")]
		IntPtr _NdcLatnZw { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ne) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ne")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNe", "__Internal")]
		IntPtr _Ne { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.neIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNeIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.neIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNeIn", "__Internal")]
		IntPtr _NeIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.neLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNeLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.neLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNeLatn", "__Internal")]
		IntPtr _NeLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.neNp) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNeNp __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.neNp")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNeNp", "__Internal")]
		IntPtr _NeNp { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.newDevaNp) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNewDevaNp __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.newDevaNp")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNewDevaNp", "__Internal")]
		IntPtr _NewDevaNp { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ngLatnNa) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNgLatnNa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ngLatnNa")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNgLatnNa", "__Internal")]
		IntPtr _NgLatnNa { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ngaLatnCd) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNgaLatnCd __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ngaLatnCd")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNgaLatnCd", "__Internal")]
		IntPtr _NgaLatnCd { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.niqLatnKe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNiqLatnKe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.niqLatnKe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNiqLatnKe", "__Internal")]
		IntPtr _NiqLatnKe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.nlBe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNlBe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.nlBe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNlBe", "__Internal")]
		IntPtr _NlBe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.nlNl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNlNl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.nlNl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNlNl", "__Internal")]
		IntPtr _NlNl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.nnNo) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNnNo __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.nnNo")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNnNo", "__Internal")]
		IntPtr _NnNo { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.no) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNo __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.no")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNo", "__Internal")]
		IntPtr _No { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.noeDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNoeDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.noeDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNoeDevaIn", "__Internal")]
		IntPtr _NoeDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.nrZa) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNrZa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.nrZa")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNrZa", "__Internal")]
		IntPtr _NrZa { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.nso) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNso __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.nso")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNso", "__Internal")]
		IntPtr _Nso { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ny) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNy __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ny")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNy", "__Internal")]
		IntPtr _Ny { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.nymLatnTz) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNymLatnTz __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.nymLatnTz")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNymLatnTz", "__Internal")]
		IntPtr _NymLatnTz { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.nyoLatnUg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierNyoLatnUg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.nyoLatnUg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierNyoLatnUg", "__Internal")]
		IntPtr _NyoLatnUg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ocLatnFr) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierOcLatnFr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ocLatnFr")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierOcLatnFr", "__Internal")]
		IntPtr _OcLatnFr { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ojLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierOjLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ojLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierOjLatn", "__Internal")]
		IntPtr _OjLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.oloLatnRu) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierOloLatnRu __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.oloLatnRu")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierOloLatnRu", "__Internal")]
		IntPtr _OloLatnRu { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.om) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierOm __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.om")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierOm", "__Internal")]
		IntPtr _Om { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.or) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierOr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.or")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierOr", "__Internal")]
		IntPtr _Or { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.orLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierOrLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.orLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierOrLatn", "__Internal")]
		IntPtr _OrLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pa) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pa")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPa", "__Internal")]
		IntPtr _Pa { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.paLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPaLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.paLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPaLatn", "__Internal")]
		IntPtr _PaLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pagLatnPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPagLatnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pagLatnPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPagLatnPh", "__Internal")]
		IntPtr _PagLatnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pamLatnPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPamLatnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pamLatnPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPamLatnPh", "__Internal")]
		IntPtr _PamLatnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.papLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPapLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.papLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPapLatn", "__Internal")]
		IntPtr _PapLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pccLatnCn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPccLatnCn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pccLatnCn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPccLatnCn", "__Internal")]
		IntPtr _PccLatnCn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pcdLatnBe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPcdLatnBe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pcdLatnBe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPcdLatnBe", "__Internal")]
		IntPtr _PcdLatnBe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pcmLatnNg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPcmLatnNg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pcmLatnNg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPcmLatnNg", "__Internal")]
		IntPtr _PcmLatnNg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pkoLatnKe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPkoLatnKe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pkoLatnKe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPkoLatnKe", "__Internal")]
		IntPtr _PkoLatnKe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPl", "__Internal")]
		IntPtr _Pl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pmsLatnIt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPmsLatnIt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pmsLatnIt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPmsLatnIt", "__Internal")]
		IntPtr _PmsLatnIt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pmyLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPmyLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pmyLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPmyLatnId", "__Internal")]
		IntPtr _PmyLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.povLatnGw) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPovLatnGw __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.povLatnGw")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPovLatnGw", "__Internal")]
		IntPtr _PovLatnGw { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.prkLatnMm) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPrkLatnMm __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.prkLatnMm")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPrkLatnMm", "__Internal")]
		IntPtr _PrkLatnMm { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pseLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPseLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pseLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPseLatnId", "__Internal")]
		IntPtr _PseLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPt", "__Internal")]
		IntPtr _Pt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.pt002) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPt002 __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.pt002")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPt002", "__Internal")]
		IntPtr _Pt002 { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ptBr) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPtBr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ptBr")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPtBr", "__Internal")]
		IntPtr _PtBr { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ptPt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierPtPt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ptPt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierPtPt", "__Internal")]
		IntPtr _PtPt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.quPe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierQuPe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.quPe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierQuPe", "__Internal")]
		IntPtr _QuPe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.qucLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierQucLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.qucLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierQucLatn", "__Internal")]
		IntPtr _QucLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.rcfLatnRe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierRcfLatnRe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.rcfLatnRe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierRcfLatnRe", "__Internal")]
		IntPtr _RcfLatnRe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.rktDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierRktDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.rktDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierRktDevaIn", "__Internal")]
		IntPtr _RktDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.rmCh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierRmCh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.rmCh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierRmCh", "__Internal")]
		IntPtr _RmCh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.rnBi) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierRnBi __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.rnBi")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierRnBi", "__Internal")]
		IntPtr _RnBi { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.roRo) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierRoRo __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.roRo")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierRoRo", "__Internal")]
		IntPtr _RoRo { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ru) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierRu __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ru")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierRu", "__Internal")]
		IntPtr _Ru { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.rwrDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierRwrDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.rwrDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierRwrDevaIn", "__Internal")]
		IntPtr _RwrDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.saDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSaDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.saDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSaDevaIn", "__Internal")]
		IntPtr _SaDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.saLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSaLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.saLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSaLatn", "__Internal")]
		IntPtr _SaLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.satDeva) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSatDeva __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.satDeva")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSatDeva", "__Internal")]
		IntPtr _SatDeva { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.satLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSatLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.satLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSatLatn", "__Internal")]
		IntPtr _SatLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.scLatnIt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierScLatnIt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.scLatnIt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierScLatnIt", "__Internal")]
		IntPtr _ScLatnIt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sckDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSckDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sckDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSckDevaIn", "__Internal")]
		IntPtr _SckDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.scoLatnGb) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierScoLatnGb __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.scoLatnGb")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierScoLatnGb", "__Internal")]
		IntPtr _ScoLatnGb { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sdDeva) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSdDeva __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sdDeva")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSdDeva", "__Internal")]
		IntPtr _SdDeva { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sdLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSdLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sdLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSdLatn", "__Internal")]
		IntPtr _SdLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sdcLatnIt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSdcLatnIt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sdcLatnIt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSdcLatnIt", "__Internal")]
		IntPtr _SdcLatnIt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sgCf) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSgCf __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sgCf")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSgCf", "__Internal")]
		IntPtr _SgCf { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sgcLatnKe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSgcLatnKe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sgcLatnKe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSgcLatnKe", "__Internal")]
		IntPtr _SgcLatnKe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sgjDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSgjDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sgjDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSgjDevaIn", "__Internal")]
		IntPtr _SgjDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sgsLatnLt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSgsLatnLt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sgsLatnLt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSgsLatnLt", "__Internal")]
		IntPtr _SgsLatnLt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.si) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSi __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.si")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSi", "__Internal")]
		IntPtr _Si { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sk) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSk __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sk")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSk", "__Internal")]
		IntPtr _Sk { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.skgLatnMg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSkgLatnMg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.skgLatnMg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSkgLatnMg", "__Internal")]
		IntPtr _SkgLatnMg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSl", "__Internal")]
		IntPtr _Sl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sm) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSm __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sm")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSm", "__Internal")]
		IntPtr _Sm { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.snLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSnLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.snLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSnLatn", "__Internal")]
		IntPtr _SnLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.so) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSo __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.so")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSo", "__Internal")]
		IntPtr _So { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sq) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSq __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sq")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSq", "__Internal")]
		IntPtr _Sq { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.srCyrl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSrCyrl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.srCyrl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSrCyrl", "__Internal")]
		IntPtr _SrCyrl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.srLatnRs) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSrLatnRs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.srLatnRs")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSrLatnRs", "__Internal")]
		IntPtr _SrLatnRs { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ssSz) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSsSz __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ssSz")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSsSz", "__Internal")]
		IntPtr _SsSz { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.stvLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierStvLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.stvLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierStvLatn", "__Internal")]
		IntPtr _StvLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.suLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSuLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.suLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSuLatn", "__Internal")]
		IntPtr _SuLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sukLatnTz) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSukLatnTz __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sukLatnTz")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSukLatnTz", "__Internal")]
		IntPtr _SukLatnTz { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.svFi) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSvFi __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.svFi")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSvFi", "__Internal")]
		IntPtr _SvFi { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.svSe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSvSe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.svSe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSvSe", "__Internal")]
		IntPtr _SvSe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sw) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSw __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sw")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSw", "__Internal")]
		IntPtr _Sw { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.swvDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSwvDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.swvDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSwvDevaIn", "__Internal")]
		IntPtr _SwvDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sxuLatnDe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSxuLatnDe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sxuLatnDe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSxuLatnDe", "__Internal")]
		IntPtr _SxuLatnDe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.sylLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierSylLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.sylLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierSylLatn", "__Internal")]
		IntPtr _SylLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ta) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTa __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ta")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTa", "__Internal")]
		IntPtr _Ta { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.taLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTaLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.taLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTaLatn", "__Internal")]
		IntPtr _TaLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.tdxLatnMg) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTdxLatnMg __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.tdxLatnMg")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTdxLatnMg", "__Internal")]
		IntPtr _TdxLatnMg { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.te) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.te")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTe", "__Internal")]
		IntPtr _Te { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.teLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTeLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.teLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTeLatn", "__Internal")]
		IntPtr _TeLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.tetLatnTl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTetLatnTl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.tetLatnTl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTetLatnTl", "__Internal")]
		IntPtr _TetLatnTl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.tgCyrl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTgCyrl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.tgCyrl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTgCyrl", "__Internal")]
		IntPtr _TgCyrl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.th) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.th")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTh", "__Internal")]
		IntPtr _Th { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ti) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTi __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ti")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTi", "__Internal")]
		IntPtr _Ti { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.tkLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTkLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.tkLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTkLatn", "__Internal")]
		IntPtr _TkLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.tnBw) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTnBw __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.tnBw")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTnBw", "__Internal")]
		IntPtr _TnBw { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.tpi) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTpi __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.tpi")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTpi", "__Internal")]
		IntPtr _Tpi { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.trTr) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTrTr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.trTr")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTrTr", "__Internal")]
		IntPtr _TrTr { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.trfLatnTt) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTrfLatnTt __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.trfLatnTt")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTrfLatnTt", "__Internal")]
		IntPtr _TrfLatnTt { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.trpLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTrpLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.trpLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTrpLatn", "__Internal")]
		IntPtr _TrpLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ts) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTs __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ts")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTs", "__Internal")]
		IntPtr _Ts { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.tsgLatnPh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTsgLatnPh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.tsgLatnPh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTsgLatnPh", "__Internal")]
		IntPtr _TsgLatnPh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.tumLatnMw) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTumLatnMw __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.tumLatnMw")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTumLatnMw", "__Internal")]
		IntPtr _TumLatnMw { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.tuvLatnKe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTuvLatnKe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.tuvLatnKe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTuvLatnKe", "__Internal")]
		IntPtr _TuvLatnKe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.twdLatnNl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierTwdLatnNl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.twdLatnNl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierTwdLatnNl", "__Internal")]
		IntPtr _TwdLatnNl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.uk) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierUk __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.uk")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierUk", "__Internal")]
		IntPtr _Uk { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.unrDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierUnrDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.unrDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierUnrDevaIn", "__Internal")]
		IntPtr _UnrDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.unrLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierUnrLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.unrLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierUnrLatn", "__Internal")]
		IntPtr _UnrLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ur) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierUr __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ur")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierUr", "__Internal")]
		IntPtr _Ur { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.urLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierUrLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.urLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierUrLatn", "__Internal")]
		IntPtr _UrLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.urPk) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierUrPk __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.urPk")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierUrPk", "__Internal")]
		IntPtr _UrPk { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.uzLatn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierUzLatn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.uzLatn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierUzLatn", "__Internal")]
		IntPtr _UzLatn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.velLatnNl) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierVelLatnNl __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.velLatnNl")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierVelLatnNl", "__Internal")]
		IntPtr _VelLatnNl { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.vepLatnRu) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierVepLatnRu __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.vepLatnRu")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierVepLatnRu", "__Internal")]
		IntPtr _VepLatnRu { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.vi) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierVi __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.vi")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierVi", "__Internal")]
		IntPtr _Vi { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.vktLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierVktLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.vktLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierVktLatnId", "__Internal")]
		IntPtr _VktLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.waLatnBe) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierWaLatnBe __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.waLatnBe")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierWaLatnBe", "__Internal")]
		IntPtr _WaLatnBe { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.wbrDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierWbrDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.wbrDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierWbrDevaIn", "__Internal")]
		IntPtr _WbrDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.wryDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierWryDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.wryDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierWryDevaIn", "__Internal")]
		IntPtr _WryDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.xh) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierXh __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.xh")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierXh", "__Internal")]
		IntPtr _Xh { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.xmmLatnId) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierXmmLatnId __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.xmmLatnId")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierXmmLatnId", "__Internal")]
		IntPtr _XmmLatnId { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.xnrDevaIn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierXnrDevaIn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.xnrDevaIn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierXnrDevaIn", "__Internal")]
		IntPtr _XnrDevaIn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.ymmLatnSo) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierYmmLatnSo __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.ymmLatnSo")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierYmmLatnSo", "__Internal")]
		IntPtr _YmmLatnSo { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.zaLatnCn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierZaLatnCn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.zaLatnCn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierZaLatnCn", "__Internal")]
		IntPtr _ZaLatnCn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.zhHani) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierZhHani __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.zhHani")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierZhHani", "__Internal")]
		IntPtr _ZhHani { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.zhHaniCn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierZhHaniCn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.zhHaniCn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierZhHaniCn", "__Internal")]
		IntPtr _ZhHaniCn { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.zhHaniHk) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierZhHaniHk __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.zhHaniHk")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierZhHaniHk", "__Internal")]
		IntPtr _ZhHaniHk { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.zhHaniTw) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierZhHaniTw __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.zhHaniTw")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierZhHaniTw", "__Internal")]
		IntPtr _ZhHaniTw { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.zu) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierZu __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.zu")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierZu", "__Internal")]
		IntPtr _Zu { get; }

		// extern NS_SWIFT_NAME(DigitalInkRecognitionModelIdentifier.zyjLatnCn) MLKDigitalInkRecognitionModelIdentifier *const MLKDigitalInkRecognitionModelIdentifierZyjLatnCn __attribute__((swift_name("DigitalInkRecognitionModelIdentifier.zyjLatnCn")));
		[Internal]
		[Field ("MLKDigitalInkRecognitionModelIdentifierZyjLatnCn", "__Internal")]
		IntPtr _ZyjLatnCn { get; }
	}
	#endregion

	// @interface MLKDigitalInkRecognitionCandidate : NSObject
	[BaseType (typeof (NSObject), Name = "MLKDigitalInkRecognitionCandidate")]
	[DisableDefaultCtor]
	interface DigitalInkRecognitionCandidate {
		// @property (readonly, nonatomic) NSString * _Nonnull text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable score;
		[NullAllowed, Export ("score")]
		NSNumber Score { get; }
	}

	// @interface MLKDigitalInkRecognitionContext : NSObject
	[BaseType (typeof (NSObject), Name = "MLKDigitalInkRecognitionContext")]
	[DisableDefaultCtor]
	interface DigitalInkRecognitionContext {
		// @property (readonly, nonatomic) NSString * _Nullable preContext;
		[NullAllowed, Export ("preContext")]
		string PreContext { get; }

		// @property (readonly, nonatomic) MLKWritingArea * _Nullable writingArea;
		[NullAllowed, Export ("writingArea")]
		WritingArea WritingArea { get; }

		// -(instancetype _Nonnull)initWithPreContext:(NSString * _Nullable)preContext writingArea:(MLKWritingArea * _Nullable)writingArea __attribute__((objc_designated_initializer));
		[Export ("initWithPreContext:writingArea:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] string preContext, [NullAllowed] WritingArea writingArea);
	}

	// @interface MLKDigitalInkRecognitionModelIdentifier : NSObject
	[BaseType (typeof (NSObject), Name = "MLKDigitalInkRecognitionModelIdentifier")]
	[DisableDefaultCtor]
	interface DigitalInkRecognitionModelIdentifier : INativeObject {
		// @property (readonly, nonatomic) NSString * _Nonnull languageTag;
		[Export ("languageTag")]
		string LanguageTag { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull languageSubtag;
		[Export ("languageSubtag")]
		string LanguageSubtag { get; }

		// @property (readonly, nonatomic) NSString * _Nullable scriptSubtag;
		[NullAllowed, Export ("scriptSubtag")]
		string ScriptSubtag { get; }

		// @property (readonly, nonatomic) NSString * _Nullable regionSubtag;
		[NullAllowed, Export ("regionSubtag")]
		string RegionSubtag { get; }

		// +(MLKDigitalInkRecognitionModelIdentifier * _Nullable)modelIdentifierFromLanguageTag:(NSString * _Nonnull)languageTag error:(NSError * _Nullable * _Nullable)error __attribute__((swift_name("from(languageTag:)")));
		[Static]
		[Export ("modelIdentifierFromLanguageTag:error:")]
		[return: NullAllowed]
		DigitalInkRecognitionModelIdentifier ModelIdentifierFromLanguageTag (string languageTag, [NullAllowed] out NSError error);

		// +(MLKDigitalInkRecognitionModelIdentifier * _Nullable)modelIdentifierForLanguageTag:(NSString * _Nonnull)languageTag;
		[Static]
		[Export ("modelIdentifierForLanguageTag:")]
		[return: NullAllowed]
		DigitalInkRecognitionModelIdentifier ModelIdentifierForLanguageTag (string languageTag);

		// +(NSSet<MLKDigitalInkRecognitionModelIdentifier *> * _Nonnull)allModelIdentifiers;
		[Static]
		[Export ("allModelIdentifiers")]
		NSSet<DigitalInkRecognitionModelIdentifier> AllModelIdentifiers { get; }

		// +(NSSet<MLKDigitalInkRecognitionModelIdentifier *> * _Nonnull)modelIdentifiersForLanguageSubtag:(NSString * _Nonnull)languageSubtag;
		[Static]
		[Export ("modelIdentifiersForLanguageSubtag:")]
		NSSet<DigitalInkRecognitionModelIdentifier> ModelIdentifiersForLanguageSubtag (string languageSubtag);

		// +(NSSet<MLKDigitalInkRecognitionModelIdentifier *> * _Nonnull)modelIdentifiersForScriptSubtag:(NSString * _Nonnull)scriptSubtag;
		[Static]
		[Export ("modelIdentifiersForScriptSubtag:")]
		NSSet<DigitalInkRecognitionModelIdentifier> ModelIdentifiersForScriptSubtag (string scriptSubtag);

		// +(NSSet<MLKDigitalInkRecognitionModelIdentifier *> * _Nonnull)modelIdentifiersForRegionSubtag:(NSString * _Nonnull)regionSubtag;
		[Static]
		[Export ("modelIdentifiersForRegionSubtag:")]
		NSSet<DigitalInkRecognitionModelIdentifier> ModelIdentifiersForRegionSubtag (string regionSubtag);
	}

	// @interface MLKDigitalInkRecognitionModel : MLKRemoteModel
	[BaseType (typeof (RemoteModel), Name = "MLKDigitalInkRecognitionModel")]
	[DisableDefaultCtor]
	interface DigitalInkRecognitionModel {
		// @property (readonly, nonatomic) MLKDigitalInkRecognitionModelIdentifier * _Nonnull modelIdentifier;
		[Export ("modelIdentifier")]
		DigitalInkRecognitionModelIdentifier ModelIdentifier { get; }

		// -(instancetype _Nonnull)initWithModelIdentifier:(MLKDigitalInkRecognitionModelIdentifier * _Nonnull)modelIdentifier __attribute__((swift_name("init(modelIdentifier:)")));
		[Export ("initWithModelIdentifier:")]
		IntPtr Constructor (DigitalInkRecognitionModelIdentifier modelIdentifier);
	}

	// @interface MLKDigitalInkRecognitionResult : NSObject
	[BaseType (typeof (NSObject), Name = "MLKDigitalInkRecognitionResult")]
	[DisableDefaultCtor]
	interface DigitalInkRecognitionResult {
		// @property (readonly, nonatomic) NSArray<MLKDigitalInkRecognitionCandidate *> * _Nonnull candidates;
		[Export ("candidates")]
		DigitalInkRecognitionCandidate [] Candidates { get; }
	}

	// typedef void (^MLKDigitalInkRecognizerCallback)(MLKDigitalInkRecognitionResult * _Nullable, NSError * _Nullable);
	delegate void DigitalInkRecognizerCallback ([NullAllowed] DigitalInkRecognitionResult result, [NullAllowed] NSError error);

	// @interface MLKDigitalInkRecognizer : NSObject
	[BaseType (typeof (NSObject), Name = "MLKDigitalInkRecognizer")]
	[DisableDefaultCtor]
	interface DigitalInkRecognizer {
		// +(MLKDigitalInkRecognizer * _Nonnull)digitalInkRecognizerWithOptions:(MLKDigitalInkRecognizerOptions * _Nonnull)options __attribute__((swift_name("digitalInkRecognizer(options:)")));
		[Static]
		[Export ("digitalInkRecognizerWithOptions:")]
		DigitalInkRecognizer DigitalInkRecognizerWithOptions (DigitalInkRecognizerOptions options);

		// -(void)recognizeInk:(MLKInk * _Nonnull)ink completion:(MLKDigitalInkRecognizerCallback _Nonnull)completion __attribute__((swift_name("recognize(ink:completion:)")));
		[Export ("recognizeInk:completion:")]
		void RecognizeInk (Ink ink, DigitalInkRecognizerCallback completion);

		// -(void)recognizeInk:(MLKInk * _Nonnull)ink context:(MLKDigitalInkRecognitionContext * _Nonnull)context completion:(MLKDigitalInkRecognizerCallback _Nonnull)completion __attribute__((swift_name("recognize(ink:context:completion:)")));
		[Export ("recognizeInk:context:completion:")]
		void RecognizeInk (Ink ink, DigitalInkRecognitionContext context, DigitalInkRecognizerCallback completion);
	}

	// @interface MLKDigitalInkRecognizerOptions : NSObject
	[BaseType (typeof (NSObject), Name = "MLKDigitalInkRecognizerOptions")]
	[DisableDefaultCtor]
	interface DigitalInkRecognizerOptions {
		// @property (readonly, nonatomic) MLKDigitalInkRecognitionModel * _Nonnull model;
		[Export ("model")]
		DigitalInkRecognitionModel Model { get; }

		// @property (nonatomic) int maxResultCount;
		[Export ("maxResultCount")]
		int MaxResultCount { get; set; }

		// -(instancetype _Nonnull)initWithModel:(MLKDigitalInkRecognitionModel * _Nonnull)model __attribute__((objc_designated_initializer));
		[Export ("initWithModel:")]
		[DesignatedInitializer]
		IntPtr Constructor (DigitalInkRecognitionModel model);
	}

	// @interface MLKStrokePoint : NSObject
	[BaseType (typeof (NSObject), Name = "MLKStrokePoint")]
	[DisableDefaultCtor]
	interface StrokePoint {
		// @property (readonly, nonatomic) float x;
		[Export ("x")]
		float X { get; }

		// @property (readonly, nonatomic) float y;
		[Export ("y")]
		float Y { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable t;
		[NullAllowed, Export ("t")]
		NSNumber T { get; }

		// -(instancetype _Nonnull)initWithX:(float)x y:(float)y t:(long)t;
		[Export ("initWithX:y:t:")]
		IntPtr Constructor (float x, float y, nint t);

		// -(instancetype _Nonnull)initWithX:(float)x y:(float)y;
		[Export ("initWithX:y:")]
		IntPtr Constructor (float x, float y);
	}

	// @interface MLKStroke : NSObject
	[BaseType (typeof (NSObject), Name = "MLKStroke")]
	[DisableDefaultCtor]
	interface Stroke {
		// @property (readonly, nonatomic) NSArray<MLKStrokePoint *> * _Nonnull points;
		[Export ("points")]
		StrokePoint [] Points { get; }

		// -(instancetype _Nonnull)initWithPoints:(NSArray<MLKStrokePoint *> * _Nonnull)points __attribute__((objc_designated_initializer));
		[Export ("initWithPoints:")]
		[DesignatedInitializer]
		IntPtr Constructor (StrokePoint [] points);
	}

	// @interface MLKInk : NSObject
	[BaseType (typeof (NSObject), Name = "MLKInk")]
	[DisableDefaultCtor]
	interface Ink {
		// @property (readonly, nonatomic) NSArray<MLKStroke *> * _Nonnull strokes;
		[Export ("strokes")]
		Stroke [] Strokes { get; }

		// -(instancetype _Nonnull)initWithStrokes:(NSArray<MLKStroke *> * _Nonnull)strokes __attribute__((objc_designated_initializer));
		[Export ("initWithStrokes:")]
		[DesignatedInitializer]
		IntPtr Constructor (Stroke [] strokes);
	}

	// @interface MLKWritingArea : NSObject
	[BaseType (typeof (NSObject), Name = "MLKWritingArea")]
	[DisableDefaultCtor]
	interface WritingArea {
		// @property (readonly, nonatomic) float width;
		[Export ("width")]
		float Width { get; }

		// @property (readonly, nonatomic) float height;
		[Export ("height")]
		float Height { get; }

		// -(instancetype _Nonnull)initWithWidth:(float)width height:(float)height __attribute__((objc_designated_initializer));
		[Export ("initWithWidth:height:")]
		[DesignatedInitializer]
		IntPtr Constructor (float width, float height);
	}
}
