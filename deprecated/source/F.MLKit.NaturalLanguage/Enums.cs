using System;

using ObjCRuntime;

namespace Firebase.MLKit.NaturalLanguage {
	/// 
	/// FirebaseMLNLSmartReply.framework
	///

	[Native]
	public enum SmartReplyResultStatus : long
	{
		Success,
		NotSupportedLanguage,
		NoReply
	}

	/// 
	/// end - FirebaseMLNLSmartReply.framework
	///


	/// 
	/// FirebaseMLNLTranslate.framework
	///

	[Native]
	public enum TranslateLanguage : ulong
	{
		Af = 0,
		Ar = 1,
		Be = 2,
		Bg = 3,
		Bn = 4,
		Ca = 5,
		Cs = 6,
		Cy = 7,
		Da = 8,
		De = 9,
		El = 10,
		En = 11,
		Eo = 12,
		Es = 13,
		Et = 14,
		Fa = 15,
		Fi = 16,
		Fr = 17,
		Ga = 18,
		Gl = 19,
		Gu = 20,
		He = 21,
		Hi = 22,
		Hr = 23,
		Ht = 24,
		Hu = 25,
		Id = 26,
		Is = 27,
		It = 28,
		Ja = 29,
		Ka = 30,
		Kn = 31,
		Ko = 32,
		Lt = 33,
		Lv = 34,
		Mk = 35,
		Mr = 36,
		Ms = 37,
		Mt = 38,
		Nl = 39,
		No = 40,
		Pl = 41,
		Pt = 42,
		Ro = 43,
		Ru = 44,
		Sk = 45,
		Sl = 46,
		Sq = 47,
		Sv = 48,
		Sw = 49,
		Ta = 50,
		Te = 51,
		Th = 52,
		Tl = 53,
		Tr = 54,
		Uk = 55,
		Ur = 56,
		Vi = 57,
		Zh = 58,
		Invalid = 65535
	}

	/// 
	/// end - FirebaseMLNLTranslate.framework
	///
}
