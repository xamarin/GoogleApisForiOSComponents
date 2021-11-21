using System;
using System.Collections.Generic;

using Foundation;
using CoreGraphics;
using UIKit;

namespace MLKit.DigitalInkRecognition {
	public partial class ModelIdentifiers {
		static DigitalInkRecognitionModelIdentifier _autodraw;
		public static DigitalInkRecognitionModelIdentifier Autodraw => GetModelIdentifier (ref _autodraw, ModelIdentifiers._Autodraw);

		static DigitalInkRecognitionModelIdentifier _emoji;
		public static DigitalInkRecognitionModelIdentifier Emoji => GetModelIdentifier (ref _emoji, ModelIdentifiers._Emoji);

		static DigitalInkRecognitionModelIdentifier _shapes;
		public static DigitalInkRecognitionModelIdentifier Shapes => GetModelIdentifier (ref _shapes, ModelIdentifiers._Shapes);

		static DigitalInkRecognitionModelIdentifier _aaLatn;
		public static DigitalInkRecognitionModelIdentifier AaLatn => GetModelIdentifier (ref _aaLatn, ModelIdentifiers._AaLatn);

		static DigitalInkRecognitionModelIdentifier _absLatnId;
		public static DigitalInkRecognitionModelIdentifier AbsLatnId => GetModelIdentifier (ref _absLatnId, ModelIdentifiers._AbsLatnId);

		static DigitalInkRecognitionModelIdentifier _aceLatnId;
		public static DigitalInkRecognitionModelIdentifier AceLatnId => GetModelIdentifier (ref _aceLatnId, ModelIdentifiers._AceLatnId);

		static DigitalInkRecognitionModelIdentifier _actLatnNl;
		public static DigitalInkRecognitionModelIdentifier ActLatnNl => GetModelIdentifier (ref _actLatnNl, ModelIdentifiers._ActLatnNl);

		static DigitalInkRecognitionModelIdentifier _af;
		public static DigitalInkRecognitionModelIdentifier Af => GetModelIdentifier (ref _af, ModelIdentifiers._Af);

		static DigitalInkRecognitionModelIdentifier _am;
		public static DigitalInkRecognitionModelIdentifier Am => GetModelIdentifier (ref _am, ModelIdentifiers._Am);

		static DigitalInkRecognitionModelIdentifier _anLatnEs;
		public static DigitalInkRecognitionModelIdentifier AnLatnEs => GetModelIdentifier (ref _anLatnEs, ModelIdentifiers._AnLatnEs);

		static DigitalInkRecognitionModelIdentifier _anwLatnNg;
		public static DigitalInkRecognitionModelIdentifier AnwLatnNg => GetModelIdentifier (ref _anwLatnNg, ModelIdentifiers._AnwLatnNg);

		static DigitalInkRecognitionModelIdentifier _ar;
		public static DigitalInkRecognitionModelIdentifier Ar => GetModelIdentifier (ref _ar, ModelIdentifiers._Ar);

		static DigitalInkRecognitionModelIdentifier _as;
		public static DigitalInkRecognitionModelIdentifier As => GetModelIdentifier (ref _as, ModelIdentifiers._As);

		static DigitalInkRecognitionModelIdentifier _awaDevaIn;
		public static DigitalInkRecognitionModelIdentifier AwaDevaIn => GetModelIdentifier (ref _awaDevaIn, ModelIdentifiers._AwaDevaIn);

		static DigitalInkRecognitionModelIdentifier _azLatnAz;
		public static DigitalInkRecognitionModelIdentifier AzLatnAz => GetModelIdentifier (ref _azLatnAz, ModelIdentifiers._AzLatnAz);

		static DigitalInkRecognitionModelIdentifier _bahLatnBs;
		public static DigitalInkRecognitionModelIdentifier BahLatnBs => GetModelIdentifier (ref _bahLatnBs, ModelIdentifiers._BahLatnBs);

		static DigitalInkRecognitionModelIdentifier _barLatnAt;
		public static DigitalInkRecognitionModelIdentifier BarLatnAt => GetModelIdentifier (ref _barLatnAt, ModelIdentifiers._BarLatnAt);

		static DigitalInkRecognitionModelIdentifier _bcqLatnEt;
		public static DigitalInkRecognitionModelIdentifier BcqLatnEt => GetModelIdentifier (ref _bcqLatnEt, ModelIdentifiers._BcqLatnEt);

		static DigitalInkRecognitionModelIdentifier _be;
		public static DigitalInkRecognitionModelIdentifier Be => GetModelIdentifier (ref _be, ModelIdentifiers._Be);

		static DigitalInkRecognitionModelIdentifier _berLatn;
		public static DigitalInkRecognitionModelIdentifier BerLatn => GetModelIdentifier (ref _berLatn, ModelIdentifiers._BerLatn);

		static DigitalInkRecognitionModelIdentifier _bewLatnId;
		public static DigitalInkRecognitionModelIdentifier BewLatnId => GetModelIdentifier (ref _bewLatnId, ModelIdentifiers._BewLatnId);

		static DigitalInkRecognitionModelIdentifier _bfyDevaIn;
		public static DigitalInkRecognitionModelIdentifier BfyDevaIn => GetModelIdentifier (ref _bfyDevaIn, ModelIdentifiers._BfyDevaIn);

		static DigitalInkRecognitionModelIdentifier _bfzDevaIn;
		public static DigitalInkRecognitionModelIdentifier BfzDevaIn => GetModelIdentifier (ref _bfzDevaIn, ModelIdentifiers._BfzDevaIn);

		static DigitalInkRecognitionModelIdentifier _bg;
		public static DigitalInkRecognitionModelIdentifier Bg => GetModelIdentifier (ref _bg, ModelIdentifiers._Bg);

		static DigitalInkRecognitionModelIdentifier _bgcDevaIn;
		public static DigitalInkRecognitionModelIdentifier BgcDevaIn => GetModelIdentifier (ref _bgcDevaIn, ModelIdentifiers._BgcDevaIn);

		static DigitalInkRecognitionModelIdentifier _bgqDevaIn;
		public static DigitalInkRecognitionModelIdentifier BgqDevaIn => GetModelIdentifier (ref _bgqDevaIn, ModelIdentifiers._BgqDevaIn);

		static DigitalInkRecognitionModelIdentifier _bgqDevaPk;
		public static DigitalInkRecognitionModelIdentifier BgqDevaPk => GetModelIdentifier (ref _bgqDevaPk, ModelIdentifiers._BgqDevaPk);

		static DigitalInkRecognitionModelIdentifier _bgxLatnTr;
		public static DigitalInkRecognitionModelIdentifier BgxLatnTr => GetModelIdentifier (ref _bgxLatnTr, ModelIdentifiers._BgxLatnTr);

		static DigitalInkRecognitionModelIdentifier _bgzLatnId;
		public static DigitalInkRecognitionModelIdentifier BgzLatnId => GetModelIdentifier (ref _bgzLatnId, ModelIdentifiers._BgzLatnId);

		static DigitalInkRecognitionModelIdentifier _bhbDeva;
		public static DigitalInkRecognitionModelIdentifier BhbDeva => GetModelIdentifier (ref _bhbDeva, ModelIdentifiers._BhbDeva);

		static DigitalInkRecognitionModelIdentifier _bhoDevaIn;
		public static DigitalInkRecognitionModelIdentifier BhoDevaIn => GetModelIdentifier (ref _bhoDevaIn, ModelIdentifiers._BhoDevaIn);

		static DigitalInkRecognitionModelIdentifier _biLatnVu;
		public static DigitalInkRecognitionModelIdentifier BiLatnVu => GetModelIdentifier (ref _biLatnVu, ModelIdentifiers._BiLatnVu);

		static DigitalInkRecognitionModelIdentifier _bikLatnPh;
		public static DigitalInkRecognitionModelIdentifier BikLatnPh => GetModelIdentifier (ref _bikLatnPh, ModelIdentifiers._BikLatnPh);

		static DigitalInkRecognitionModelIdentifier _bjjDevaIn;
		public static DigitalInkRecognitionModelIdentifier BjjDevaIn => GetModelIdentifier (ref _bjjDevaIn, ModelIdentifiers._BjjDevaIn);

		static DigitalInkRecognitionModelIdentifier _bjnLatnId;
		public static DigitalInkRecognitionModelIdentifier BjnLatnId => GetModelIdentifier (ref _bjnLatnId, ModelIdentifiers._BjnLatnId);

		static DigitalInkRecognitionModelIdentifier _bn;
		public static DigitalInkRecognitionModelIdentifier Bn => GetModelIdentifier (ref _bn, ModelIdentifiers._Bn);

		static DigitalInkRecognitionModelIdentifier _bnLatn;
		public static DigitalInkRecognitionModelIdentifier BnLatn => GetModelIdentifier (ref _bnLatn, ModelIdentifiers._BnLatn);

		static DigitalInkRecognitionModelIdentifier _boTibt;
		public static DigitalInkRecognitionModelIdentifier BoTibt => GetModelIdentifier (ref _boTibt, ModelIdentifiers._BoTibt);

		static DigitalInkRecognitionModelIdentifier _bomLatnNg;
		public static DigitalInkRecognitionModelIdentifier BomLatnNg => GetModelIdentifier (ref _bomLatnNg, ModelIdentifiers._BomLatnNg);

		static DigitalInkRecognitionModelIdentifier _brxDeva;
		public static DigitalInkRecognitionModelIdentifier BrxDeva => GetModelIdentifier (ref _brxDeva, ModelIdentifiers._BrxDeva);

		static DigitalInkRecognitionModelIdentifier _brxLatn;
		public static DigitalInkRecognitionModelIdentifier BrxLatn => GetModelIdentifier (ref _brxLatn, ModelIdentifiers._BrxLatn);

		static DigitalInkRecognitionModelIdentifier _bs;
		public static DigitalInkRecognitionModelIdentifier Bs => GetModelIdentifier (ref _bs, ModelIdentifiers._Bs);

		static DigitalInkRecognitionModelIdentifier _btoLatnPh;
		public static DigitalInkRecognitionModelIdentifier BtoLatnPh => GetModelIdentifier (ref _btoLatnPh, ModelIdentifiers._BtoLatnPh);

		static DigitalInkRecognitionModelIdentifier _btzLatnId;
		public static DigitalInkRecognitionModelIdentifier BtzLatnId => GetModelIdentifier (ref _btzLatnId, ModelIdentifiers._BtzLatnId);

		static DigitalInkRecognitionModelIdentifier _bzcLatnMg;
		public static DigitalInkRecognitionModelIdentifier BzcLatnMg => GetModelIdentifier (ref _bzcLatnMg, ModelIdentifiers._BzcLatnMg);

		static DigitalInkRecognitionModelIdentifier _ca;
		public static DigitalInkRecognitionModelIdentifier Ca => GetModelIdentifier (ref _ca, ModelIdentifiers._Ca);

		static DigitalInkRecognitionModelIdentifier _cebLatn;
		public static DigitalInkRecognitionModelIdentifier CebLatn => GetModelIdentifier (ref _cebLatn, ModelIdentifiers._CebLatn);

		static DigitalInkRecognitionModelIdentifier _cggLatnUg;
		public static DigitalInkRecognitionModelIdentifier CggLatnUg => GetModelIdentifier (ref _cggLatnUg, ModelIdentifiers._CggLatnUg);

		static DigitalInkRecognitionModelIdentifier _chGu;
		public static DigitalInkRecognitionModelIdentifier ChGu => GetModelIdentifier (ref _chGu, ModelIdentifiers._ChGu);

		static DigitalInkRecognitionModelIdentifier _cjkLatnCd;
		public static DigitalInkRecognitionModelIdentifier CjkLatnCd => GetModelIdentifier (ref _cjkLatnCd, ModelIdentifiers._CjkLatnCd);

		static DigitalInkRecognitionModelIdentifier _coLatn;
		public static DigitalInkRecognitionModelIdentifier CoLatn => GetModelIdentifier (ref _coLatn, ModelIdentifiers._CoLatn);

		static DigitalInkRecognitionModelIdentifier _cpsLatnPh;
		public static DigitalInkRecognitionModelIdentifier CpsLatnPh => GetModelIdentifier (ref _cpsLatnPh, ModelIdentifiers._CpsLatnPh);

		static DigitalInkRecognitionModelIdentifier _crsLatnSc;
		public static DigitalInkRecognitionModelIdentifier CrsLatnSc => GetModelIdentifier (ref _crsLatnSc, ModelIdentifiers._CrsLatnSc);

		static DigitalInkRecognitionModelIdentifier _cs;
		public static DigitalInkRecognitionModelIdentifier Cs => GetModelIdentifier (ref _cs, ModelIdentifiers._Cs);

		static DigitalInkRecognitionModelIdentifier _cy;
		public static DigitalInkRecognitionModelIdentifier Cy => GetModelIdentifier (ref _cy, ModelIdentifiers._Cy);

		static DigitalInkRecognitionModelIdentifier _cyoLatnPh;
		public static DigitalInkRecognitionModelIdentifier CyoLatnPh => GetModelIdentifier (ref _cyoLatnPh, ModelIdentifiers._CyoLatnPh);

		static DigitalInkRecognitionModelIdentifier _da;
		public static DigitalInkRecognitionModelIdentifier Da => GetModelIdentifier (ref _da, ModelIdentifiers._Da);

		static DigitalInkRecognitionModelIdentifier _de;
		public static DigitalInkRecognitionModelIdentifier De => GetModelIdentifier (ref _de, ModelIdentifiers._De);

		static DigitalInkRecognitionModelIdentifier _deAt;
		public static DigitalInkRecognitionModelIdentifier DeAt => GetModelIdentifier (ref _deAt, ModelIdentifiers._DeAt);

		static DigitalInkRecognitionModelIdentifier _deBe;
		public static DigitalInkRecognitionModelIdentifier DeBe => GetModelIdentifier (ref _deBe, ModelIdentifiers._DeBe);

		static DigitalInkRecognitionModelIdentifier _deCh;
		public static DigitalInkRecognitionModelIdentifier DeCh => GetModelIdentifier (ref _deCh, ModelIdentifiers._DeCh);

		static DigitalInkRecognitionModelIdentifier _deDe;
		public static DigitalInkRecognitionModelIdentifier DeDe => GetModelIdentifier (ref _deDe, ModelIdentifiers._DeDe);

		static DigitalInkRecognitionModelIdentifier _deLu;
		public static DigitalInkRecognitionModelIdentifier DeLu => GetModelIdentifier (ref _deLu, ModelIdentifiers._DeLu);

		static DigitalInkRecognitionModelIdentifier _dnjLatnCi;
		public static DigitalInkRecognitionModelIdentifier DnjLatnCi => GetModelIdentifier (ref _dnjLatnCi, ModelIdentifiers._DnjLatnCi);

		static DigitalInkRecognitionModelIdentifier _doiDeva;
		public static DigitalInkRecognitionModelIdentifier DoiDeva => GetModelIdentifier (ref _doiDeva, ModelIdentifiers._DoiDeva);

		static DigitalInkRecognitionModelIdentifier _doiLatn;
		public static DigitalInkRecognitionModelIdentifier DoiLatn => GetModelIdentifier (ref _doiLatn, ModelIdentifiers._DoiLatn);

		static DigitalInkRecognitionModelIdentifier _drsLatnEt;
		public static DigitalInkRecognitionModelIdentifier DrsLatnEt => GetModelIdentifier (ref _drsLatnEt, ModelIdentifiers._DrsLatnEt);

		static DigitalInkRecognitionModelIdentifier _drtLatnNl;
		public static DigitalInkRecognitionModelIdentifier DrtLatnNl => GetModelIdentifier (ref _drtLatnNl, ModelIdentifiers._DrtLatnNl);

		static DigitalInkRecognitionModelIdentifier _dsbDe;
		public static DigitalInkRecognitionModelIdentifier DsbDe => GetModelIdentifier (ref _dsbDe, ModelIdentifiers._DsbDe);

		static DigitalInkRecognitionModelIdentifier _el;
		public static DigitalInkRecognitionModelIdentifier El => GetModelIdentifier (ref _el, ModelIdentifiers._El);

		static DigitalInkRecognitionModelIdentifier _en;
		public static DigitalInkRecognitionModelIdentifier En => GetModelIdentifier (ref _en, ModelIdentifiers._En);

		static DigitalInkRecognitionModelIdentifier _enAu;
		public static DigitalInkRecognitionModelIdentifier EnAu => GetModelIdentifier (ref _enAu, ModelIdentifiers._EnAu);

		static DigitalInkRecognitionModelIdentifier _enCa;
		public static DigitalInkRecognitionModelIdentifier EnCa => GetModelIdentifier (ref _enCa, ModelIdentifiers._EnCa);

		static DigitalInkRecognitionModelIdentifier _enGb;
		public static DigitalInkRecognitionModelIdentifier EnGb => GetModelIdentifier (ref _enGb, ModelIdentifiers._EnGb);

		static DigitalInkRecognitionModelIdentifier _enIn;
		public static DigitalInkRecognitionModelIdentifier EnIn => GetModelIdentifier (ref _enIn, ModelIdentifiers._EnIn);

		static DigitalInkRecognitionModelIdentifier _enKe;
		public static DigitalInkRecognitionModelIdentifier EnKe => GetModelIdentifier (ref _enKe, ModelIdentifiers._EnKe);

		static DigitalInkRecognitionModelIdentifier _enNg;
		public static DigitalInkRecognitionModelIdentifier EnNg => GetModelIdentifier (ref _enNg, ModelIdentifiers._EnNg);

		static DigitalInkRecognitionModelIdentifier _enPh;
		public static DigitalInkRecognitionModelIdentifier EnPh => GetModelIdentifier (ref _enPh, ModelIdentifiers._EnPh);

		static DigitalInkRecognitionModelIdentifier _enUs;
		public static DigitalInkRecognitionModelIdentifier EnUs => GetModelIdentifier (ref _enUs, ModelIdentifiers._EnUs);

		static DigitalInkRecognitionModelIdentifier _enZa;
		public static DigitalInkRecognitionModelIdentifier EnZa => GetModelIdentifier (ref _enZa, ModelIdentifiers._EnZa);

		static DigitalInkRecognitionModelIdentifier _eo;
		public static DigitalInkRecognitionModelIdentifier Eo => GetModelIdentifier (ref _eo, ModelIdentifiers._Eo);

		static DigitalInkRecognitionModelIdentifier _es;
		public static DigitalInkRecognitionModelIdentifier Es => GetModelIdentifier (ref _es, ModelIdentifiers._Es);

		static DigitalInkRecognitionModelIdentifier _esAr;
		public static DigitalInkRecognitionModelIdentifier EsAr => GetModelIdentifier (ref _esAr, ModelIdentifiers._EsAr);

		static DigitalInkRecognitionModelIdentifier _esEs;
		public static DigitalInkRecognitionModelIdentifier EsEs => GetModelIdentifier (ref _esEs, ModelIdentifiers._EsEs);

		static DigitalInkRecognitionModelIdentifier _esMx;
		public static DigitalInkRecognitionModelIdentifier EsMx => GetModelIdentifier (ref _esMx, ModelIdentifiers._EsMx);

		static DigitalInkRecognitionModelIdentifier _esUs;
		public static DigitalInkRecognitionModelIdentifier EsUs => GetModelIdentifier (ref _esUs, ModelIdentifiers._EsUs);

		static DigitalInkRecognitionModelIdentifier _et;
		public static DigitalInkRecognitionModelIdentifier Et => GetModelIdentifier (ref _et, ModelIdentifiers._Et);

		static DigitalInkRecognitionModelIdentifier _etEe;
		public static DigitalInkRecognitionModelIdentifier EtEe => GetModelIdentifier (ref _etEe, ModelIdentifiers._EtEe);

		static DigitalInkRecognitionModelIdentifier _eu;
		public static DigitalInkRecognitionModelIdentifier Eu => GetModelIdentifier (ref _eu, ModelIdentifiers._Eu);

		static DigitalInkRecognitionModelIdentifier _euEs;
		public static DigitalInkRecognitionModelIdentifier EuEs => GetModelIdentifier (ref _euEs, ModelIdentifiers._EuEs);

		static DigitalInkRecognitionModelIdentifier _extLatnEs;
		public static DigitalInkRecognitionModelIdentifier ExtLatnEs => GetModelIdentifier (ref _extLatnEs, ModelIdentifiers._ExtLatnEs);

		static DigitalInkRecognitionModelIdentifier _fa;
		public static DigitalInkRecognitionModelIdentifier Fa => GetModelIdentifier (ref _fa, ModelIdentifiers._Fa);

		static DigitalInkRecognitionModelIdentifier _fanLatnGq;
		public static DigitalInkRecognitionModelIdentifier FanLatnGq => GetModelIdentifier (ref _fanLatnGq, ModelIdentifiers._FanLatnGq);

		static DigitalInkRecognitionModelIdentifier _fi;
		public static DigitalInkRecognitionModelIdentifier Fi => GetModelIdentifier (ref _fi, ModelIdentifiers._Fi);

		static DigitalInkRecognitionModelIdentifier _filLatn;
		public static DigitalInkRecognitionModelIdentifier FilLatn => GetModelIdentifier (ref _filLatn, ModelIdentifiers._FilLatn);

		static DigitalInkRecognitionModelIdentifier _fjFj;
		public static DigitalInkRecognitionModelIdentifier FjFj => GetModelIdentifier (ref _fjFj, ModelIdentifiers._FjFj);

		static DigitalInkRecognitionModelIdentifier _foFo;
		public static DigitalInkRecognitionModelIdentifier FoFo => GetModelIdentifier (ref _foFo, ModelIdentifiers._FoFo);

		static DigitalInkRecognitionModelIdentifier _fr;
		public static DigitalInkRecognitionModelIdentifier Fr => GetModelIdentifier (ref _fr, ModelIdentifiers._Fr);

		static DigitalInkRecognitionModelIdentifier _fr002;
		public static DigitalInkRecognitionModelIdentifier Fr002 => GetModelIdentifier (ref _fr002, ModelIdentifiers._Fr002);

		static DigitalInkRecognitionModelIdentifier _frBe;
		public static DigitalInkRecognitionModelIdentifier FrBe => GetModelIdentifier (ref _frBe, ModelIdentifiers._FrBe);

		static DigitalInkRecognitionModelIdentifier _frCa;
		public static DigitalInkRecognitionModelIdentifier FrCa => GetModelIdentifier (ref _frCa, ModelIdentifiers._FrCa);

		static DigitalInkRecognitionModelIdentifier _frCh;
		public static DigitalInkRecognitionModelIdentifier FrCh => GetModelIdentifier (ref _frCh, ModelIdentifiers._FrCh);

		static DigitalInkRecognitionModelIdentifier _frFr;
		public static DigitalInkRecognitionModelIdentifier FrFr => GetModelIdentifier (ref _frFr, ModelIdentifiers._FrFr);

		static DigitalInkRecognitionModelIdentifier _fy;
		public static DigitalInkRecognitionModelIdentifier Fy => GetModelIdentifier (ref _fy, ModelIdentifiers._Fy);

		static DigitalInkRecognitionModelIdentifier _ga;
		public static DigitalInkRecognitionModelIdentifier Ga => GetModelIdentifier (ref _ga, ModelIdentifiers._Ga);

		static DigitalInkRecognitionModelIdentifier _gaxLatnEt;
		public static DigitalInkRecognitionModelIdentifier GaxLatnEt => GetModelIdentifier (ref _gaxLatnEt, ModelIdentifiers._GaxLatnEt);

		static DigitalInkRecognitionModelIdentifier _gayLatnId;
		public static DigitalInkRecognitionModelIdentifier GayLatnId => GetModelIdentifier (ref _gayLatnId, ModelIdentifiers._GayLatnId);

		static DigitalInkRecognitionModelIdentifier _gbmDevaIn;
		public static DigitalInkRecognitionModelIdentifier GbmDevaIn => GetModelIdentifier (ref _gbmDevaIn, ModelIdentifiers._GbmDevaIn);

		static DigitalInkRecognitionModelIdentifier _gcrLatnGf;
		public static DigitalInkRecognitionModelIdentifier GcrLatnGf => GetModelIdentifier (ref _gcrLatnGf, ModelIdentifiers._GcrLatnGf);

		static DigitalInkRecognitionModelIdentifier _gdLatn;
		public static DigitalInkRecognitionModelIdentifier GdLatn => GetModelIdentifier (ref _gdLatn, ModelIdentifiers._GdLatn);

		static DigitalInkRecognitionModelIdentifier _gdLatnGb;
		public static DigitalInkRecognitionModelIdentifier GdLatnGb => GetModelIdentifier (ref _gdLatnGb, ModelIdentifiers._GdLatnGb);

		static DigitalInkRecognitionModelIdentifier _gdxDevaIn;
		public static DigitalInkRecognitionModelIdentifier GdxDevaIn => GetModelIdentifier (ref _gdxDevaIn, ModelIdentifiers._GdxDevaIn);

		static DigitalInkRecognitionModelIdentifier _gjuDeva;
		public static DigitalInkRecognitionModelIdentifier GjuDeva => GetModelIdentifier (ref _gjuDeva, ModelIdentifiers._GjuDeva);

		static DigitalInkRecognitionModelIdentifier _gl;
		public static DigitalInkRecognitionModelIdentifier Gl => GetModelIdentifier (ref _gl, ModelIdentifiers._Gl);

		static DigitalInkRecognitionModelIdentifier _glEs;
		public static DigitalInkRecognitionModelIdentifier GlEs => GetModelIdentifier (ref _glEs, ModelIdentifiers._GlEs);

		static DigitalInkRecognitionModelIdentifier _gosLatnNl;
		public static DigitalInkRecognitionModelIdentifier GosLatnNl => GetModelIdentifier (ref _gosLatnNl, ModelIdentifiers._GosLatnNl);

		static DigitalInkRecognitionModelIdentifier _gpeLatnGh;
		public static DigitalInkRecognitionModelIdentifier GpeLatnGh => GetModelIdentifier (ref _gpeLatnGh, ModelIdentifiers._GpeLatnGh);

		static DigitalInkRecognitionModelIdentifier _gswCh;
		public static DigitalInkRecognitionModelIdentifier GswCh => GetModelIdentifier (ref _gswCh, ModelIdentifiers._GswCh);

		static DigitalInkRecognitionModelIdentifier _gu;
		public static DigitalInkRecognitionModelIdentifier Gu => GetModelIdentifier (ref _gu, ModelIdentifiers._Gu);

		static DigitalInkRecognitionModelIdentifier _guLatn;
		public static DigitalInkRecognitionModelIdentifier GuLatn => GetModelIdentifier (ref _guLatn, ModelIdentifiers._GuLatn);

		static DigitalInkRecognitionModelIdentifier _gv;
		public static DigitalInkRecognitionModelIdentifier Gv => GetModelIdentifier (ref _gv, ModelIdentifiers._Gv);

		static DigitalInkRecognitionModelIdentifier _gynLatn;
		public static DigitalInkRecognitionModelIdentifier GynLatn => GetModelIdentifier (ref _gynLatn, ModelIdentifiers._GynLatn);

		static DigitalInkRecognitionModelIdentifier _haqLatnTz;
		public static DigitalInkRecognitionModelIdentifier HaqLatnTz => GetModelIdentifier (ref _haqLatnTz, ModelIdentifiers._HaqLatnTz);

		static DigitalInkRecognitionModelIdentifier _hawLatn;
		public static DigitalInkRecognitionModelIdentifier HawLatn => GetModelIdentifier (ref _hawLatn, ModelIdentifiers._HawLatn);

		static DigitalInkRecognitionModelIdentifier _hdyLatn;
		public static DigitalInkRecognitionModelIdentifier HdyLatn => GetModelIdentifier (ref _hdyLatn, ModelIdentifiers._HdyLatn);

		static DigitalInkRecognitionModelIdentifier _he;
		public static DigitalInkRecognitionModelIdentifier He => GetModelIdentifier (ref _he, ModelIdentifiers._He);

		static DigitalInkRecognitionModelIdentifier _hi;
		public static DigitalInkRecognitionModelIdentifier Hi => GetModelIdentifier (ref _hi, ModelIdentifiers._Hi);

		static DigitalInkRecognitionModelIdentifier _hiLatn;
		public static DigitalInkRecognitionModelIdentifier HiLatn => GetModelIdentifier (ref _hiLatn, ModelIdentifiers._HiLatn);

		static DigitalInkRecognitionModelIdentifier _hifDeva;
		public static DigitalInkRecognitionModelIdentifier HifDeva => GetModelIdentifier (ref _hifDeva, ModelIdentifiers._HifDeva);

		static DigitalInkRecognitionModelIdentifier _hilLatnPh;
		public static DigitalInkRecognitionModelIdentifier HilLatnPh => GetModelIdentifier (ref _hilLatnPh, ModelIdentifiers._HilLatnPh);

		static DigitalInkRecognitionModelIdentifier _hmnLatn;
		public static DigitalInkRecognitionModelIdentifier HmnLatn => GetModelIdentifier (ref _hmnLatn, ModelIdentifiers._HmnLatn);

		static DigitalInkRecognitionModelIdentifier _hneDevaIn;
		public static DigitalInkRecognitionModelIdentifier HneDevaIn => GetModelIdentifier (ref _hneDevaIn, ModelIdentifiers._HneDevaIn);

		static DigitalInkRecognitionModelIdentifier _hniLatnCn;
		public static DigitalInkRecognitionModelIdentifier HniLatnCn => GetModelIdentifier (ref _hniLatnCn, ModelIdentifiers._HniLatnCn);

		static DigitalInkRecognitionModelIdentifier _hoLatnPg;
		public static DigitalInkRecognitionModelIdentifier HoLatnPg => GetModelIdentifier (ref _hoLatnPg, ModelIdentifiers._HoLatnPg);

		static DigitalInkRecognitionModelIdentifier _hojDevaIn;
		public static DigitalInkRecognitionModelIdentifier HojDevaIn => GetModelIdentifier (ref _hojDevaIn, ModelIdentifiers._HojDevaIn);

		static DigitalInkRecognitionModelIdentifier _hr;
		public static DigitalInkRecognitionModelIdentifier Hr => GetModelIdentifier (ref _hr, ModelIdentifiers._Hr);

		static DigitalInkRecognitionModelIdentifier _hrxLatnBr;
		public static DigitalInkRecognitionModelIdentifier HrxLatnBr => GetModelIdentifier (ref _hrxLatnBr, ModelIdentifiers._HrxLatnBr);

		static DigitalInkRecognitionModelIdentifier _ht;
		public static DigitalInkRecognitionModelIdentifier Ht => GetModelIdentifier (ref _ht, ModelIdentifiers._Ht);

		static DigitalInkRecognitionModelIdentifier _hu;
		public static DigitalInkRecognitionModelIdentifier Hu => GetModelIdentifier (ref _hu, ModelIdentifiers._Hu);

		static DigitalInkRecognitionModelIdentifier _hy;
		public static DigitalInkRecognitionModelIdentifier Hy => GetModelIdentifier (ref _hy, ModelIdentifiers._Hy);

		static DigitalInkRecognitionModelIdentifier _id;
		public static DigitalInkRecognitionModelIdentifier Id => GetModelIdentifier (ref _id, ModelIdentifiers._Id);

		static DigitalInkRecognitionModelIdentifier _igbLatnNg;
		public static DigitalInkRecognitionModelIdentifier IgbLatnNg => GetModelIdentifier (ref _igbLatnNg, ModelIdentifiers._IgbLatnNg);

		static DigitalInkRecognitionModelIdentifier _iiLatn;
		public static DigitalInkRecognitionModelIdentifier IiLatn => GetModelIdentifier (ref _iiLatn, ModelIdentifiers._IiLatn);

		static DigitalInkRecognitionModelIdentifier _iloLatnPh;
		public static DigitalInkRecognitionModelIdentifier IloLatnPh => GetModelIdentifier (ref _iloLatnPh, ModelIdentifiers._IloLatnPh);

		static DigitalInkRecognitionModelIdentifier _is;
		public static DigitalInkRecognitionModelIdentifier Is => GetModelIdentifier (ref _is, ModelIdentifiers._Is);

		static DigitalInkRecognitionModelIdentifier _it;
		public static DigitalInkRecognitionModelIdentifier It => GetModelIdentifier (ref _it, ModelIdentifiers._It);

		static DigitalInkRecognitionModelIdentifier _itCh;
		public static DigitalInkRecognitionModelIdentifier ItCh => GetModelIdentifier (ref _itCh, ModelIdentifiers._ItCh);

		static DigitalInkRecognitionModelIdentifier _itIt;
		public static DigitalInkRecognitionModelIdentifier ItIt => GetModelIdentifier (ref _itIt, ModelIdentifiers._ItIt);

		static DigitalInkRecognitionModelIdentifier _iumLatnCn;
		public static DigitalInkRecognitionModelIdentifier IumLatnCn => GetModelIdentifier (ref _iumLatnCn, ModelIdentifiers._IumLatnCn);

		static DigitalInkRecognitionModelIdentifier _ja;
		public static DigitalInkRecognitionModelIdentifier Ja => GetModelIdentifier (ref _ja, ModelIdentifiers._Ja);

		static DigitalInkRecognitionModelIdentifier _jamLatnJm;
		public static DigitalInkRecognitionModelIdentifier JamLatnJm => GetModelIdentifier (ref _jamLatnJm, ModelIdentifiers._JamLatnJm);

		static DigitalInkRecognitionModelIdentifier _jaxLatnId;
		public static DigitalInkRecognitionModelIdentifier JaxLatnId => GetModelIdentifier (ref _jaxLatnId, ModelIdentifiers._JaxLatnId);

		static DigitalInkRecognitionModelIdentifier _jboLatn;
		public static DigitalInkRecognitionModelIdentifier JboLatn => GetModelIdentifier (ref _jboLatn, ModelIdentifiers._JboLatn);

		static DigitalInkRecognitionModelIdentifier _jvLatn;
		public static DigitalInkRecognitionModelIdentifier JvLatn => GetModelIdentifier (ref _jvLatn, ModelIdentifiers._JvLatn);

		static DigitalInkRecognitionModelIdentifier _ka;
		public static DigitalInkRecognitionModelIdentifier Ka => GetModelIdentifier (ref _ka, ModelIdentifiers._Ka);

		static DigitalInkRecognitionModelIdentifier _kdeLatnTz;
		public static DigitalInkRecognitionModelIdentifier KdeLatnTz => GetModelIdentifier (ref _kdeLatnTz, ModelIdentifiers._KdeLatnTz);

		static DigitalInkRecognitionModelIdentifier _kfrDevaIn;
		public static DigitalInkRecognitionModelIdentifier KfrDevaIn => GetModelIdentifier (ref _kfrDevaIn, ModelIdentifiers._KfrDevaIn);

		static DigitalInkRecognitionModelIdentifier _kfyDevaIn;
		public static DigitalInkRecognitionModelIdentifier KfyDevaIn => GetModelIdentifier (ref _kfyDevaIn, ModelIdentifiers._KfyDevaIn);

		static DigitalInkRecognitionModelIdentifier _kgeLatnId;
		public static DigitalInkRecognitionModelIdentifier KgeLatnId => GetModelIdentifier (ref _kgeLatnId, ModelIdentifiers._KgeLatnId);

		static DigitalInkRecognitionModelIdentifier _khaLatnIn;
		public static DigitalInkRecognitionModelIdentifier KhaLatnIn => GetModelIdentifier (ref _khaLatnIn, ModelIdentifiers._KhaLatnIn);

		static DigitalInkRecognitionModelIdentifier _kjLatn;
		public static DigitalInkRecognitionModelIdentifier KjLatn => GetModelIdentifier (ref _kjLatn, ModelIdentifiers._KjLatn);

		static DigitalInkRecognitionModelIdentifier _kk;
		public static DigitalInkRecognitionModelIdentifier Kk => GetModelIdentifier (ref _kk, ModelIdentifiers._Kk);

		static DigitalInkRecognitionModelIdentifier _kl;
		public static DigitalInkRecognitionModelIdentifier Kl => GetModelIdentifier (ref _kl, ModelIdentifiers._Kl);

		static DigitalInkRecognitionModelIdentifier _km;
		public static DigitalInkRecognitionModelIdentifier Km => GetModelIdentifier (ref _km, ModelIdentifiers._Km);

		static DigitalInkRecognitionModelIdentifier _kmbLatnAo;
		public static DigitalInkRecognitionModelIdentifier KmbLatnAo => GetModelIdentifier (ref _kmbLatnAo, ModelIdentifiers._KmbLatnAo);

		static DigitalInkRecognitionModelIdentifier _kmzLatn;
		public static DigitalInkRecognitionModelIdentifier KmzLatn => GetModelIdentifier (ref _kmzLatn, ModelIdentifiers._KmzLatn);

		static DigitalInkRecognitionModelIdentifier _kn;
		public static DigitalInkRecognitionModelIdentifier Kn => GetModelIdentifier (ref _kn, ModelIdentifiers._Kn);

		static DigitalInkRecognitionModelIdentifier _knLatn;
		public static DigitalInkRecognitionModelIdentifier KnLatn => GetModelIdentifier (ref _knLatn, ModelIdentifiers._KnLatn);

		static DigitalInkRecognitionModelIdentifier _ko;
		public static DigitalInkRecognitionModelIdentifier Ko => GetModelIdentifier (ref _ko, ModelIdentifiers._Ko);

		static DigitalInkRecognitionModelIdentifier _kok;
		public static DigitalInkRecognitionModelIdentifier Kok => GetModelIdentifier (ref _kok, ModelIdentifiers._Kok);

		static DigitalInkRecognitionModelIdentifier _kokIn;
		public static DigitalInkRecognitionModelIdentifier KokIn => GetModelIdentifier (ref _kokIn, ModelIdentifiers._KokIn);

		static DigitalInkRecognitionModelIdentifier _kokLatn;
		public static DigitalInkRecognitionModelIdentifier KokLatn => GetModelIdentifier (ref _kokLatn, ModelIdentifiers._KokLatn);

		static DigitalInkRecognitionModelIdentifier _kruDevaIn;
		public static DigitalInkRecognitionModelIdentifier KruDevaIn => GetModelIdentifier (ref _kruDevaIn, ModelIdentifiers._KruDevaIn);

		static DigitalInkRecognitionModelIdentifier _ksDeva;
		public static DigitalInkRecognitionModelIdentifier KsDeva => GetModelIdentifier (ref _ksDeva, ModelIdentifiers._KsDeva);

		static DigitalInkRecognitionModelIdentifier _ksLatn;
		public static DigitalInkRecognitionModelIdentifier KsLatn => GetModelIdentifier (ref _ksLatn, ModelIdentifiers._KsLatn);

		static DigitalInkRecognitionModelIdentifier _kshLatnDe;
		public static DigitalInkRecognitionModelIdentifier KshLatnDe => GetModelIdentifier (ref _kshLatnDe, ModelIdentifiers._KshLatnDe);

		static DigitalInkRecognitionModelIdentifier _ktbLatn;
		public static DigitalInkRecognitionModelIdentifier KtbLatn => GetModelIdentifier (ref _ktbLatn, ModelIdentifiers._KtbLatn);

		static DigitalInkRecognitionModelIdentifier _ktuLatnCd;
		public static DigitalInkRecognitionModelIdentifier KtuLatnCd => GetModelIdentifier (ref _ktuLatnCd, ModelIdentifiers._KtuLatnCd);

		static DigitalInkRecognitionModelIdentifier _kuLatn;
		public static DigitalInkRecognitionModelIdentifier KuLatn => GetModelIdentifier (ref _kuLatn, ModelIdentifiers._KuLatn);

		static DigitalInkRecognitionModelIdentifier _kwLatnGb;
		public static DigitalInkRecognitionModelIdentifier KwLatnGb => GetModelIdentifier (ref _kwLatnGb, ModelIdentifiers._KwLatnGb);

		static DigitalInkRecognitionModelIdentifier _kyCyrl;
		public static DigitalInkRecognitionModelIdentifier KyCyrl => GetModelIdentifier (ref _kyCyrl, ModelIdentifiers._KyCyrl);

		static DigitalInkRecognitionModelIdentifier _la;
		public static DigitalInkRecognitionModelIdentifier La => GetModelIdentifier (ref _la, ModelIdentifiers._La);

		static DigitalInkRecognitionModelIdentifier _ladLatnBa;
		public static DigitalInkRecognitionModelIdentifier LadLatnBa => GetModelIdentifier (ref _ladLatnBa, ModelIdentifiers._LadLatnBa);

		static DigitalInkRecognitionModelIdentifier _lajLatnUg;
		public static DigitalInkRecognitionModelIdentifier LajLatnUg => GetModelIdentifier (ref _lajLatnUg, ModelIdentifiers._LajLatnUg);

		static DigitalInkRecognitionModelIdentifier _lb;
		public static DigitalInkRecognitionModelIdentifier Lb => GetModelIdentifier (ref _lb, ModelIdentifiers._Lb);

		static DigitalInkRecognitionModelIdentifier _ledLatnCd;
		public static DigitalInkRecognitionModelIdentifier LedLatnCd => GetModelIdentifier (ref _ledLatnCd, ModelIdentifiers._LedLatnCd);

		static DigitalInkRecognitionModelIdentifier _lldLatnIt;
		public static DigitalInkRecognitionModelIdentifier LldLatnIt => GetModelIdentifier (ref _lldLatnIt, ModelIdentifiers._LldLatnIt);

		static DigitalInkRecognitionModelIdentifier _lmnDeva;
		public static DigitalInkRecognitionModelIdentifier LmnDeva => GetModelIdentifier (ref _lmnDeva, ModelIdentifiers._LmnDeva);

		static DigitalInkRecognitionModelIdentifier _lo;
		public static DigitalInkRecognitionModelIdentifier Lo => GetModelIdentifier (ref _lo, ModelIdentifiers._Lo);

		static DigitalInkRecognitionModelIdentifier _lonLatnMw;
		public static DigitalInkRecognitionModelIdentifier LonLatnMw => GetModelIdentifier (ref _lonLatnMw, ModelIdentifiers._LonLatnMw);

		static DigitalInkRecognitionModelIdentifier _lt;
		public static DigitalInkRecognitionModelIdentifier Lt => GetModelIdentifier (ref _lt, ModelIdentifiers._Lt);

		static DigitalInkRecognitionModelIdentifier _luyLatnKe;
		public static DigitalInkRecognitionModelIdentifier LuyLatnKe => GetModelIdentifier (ref _luyLatnKe, ModelIdentifiers._LuyLatnKe);

		static DigitalInkRecognitionModelIdentifier _lv;
		public static DigitalInkRecognitionModelIdentifier Lv => GetModelIdentifier (ref _lv, ModelIdentifiers._Lv);

		static DigitalInkRecognitionModelIdentifier _madLatnId;
		public static DigitalInkRecognitionModelIdentifier MadLatnId => GetModelIdentifier (ref _madLatnId, ModelIdentifiers._MadLatnId);

		static DigitalInkRecognitionModelIdentifier _magDevaIn;
		public static DigitalInkRecognitionModelIdentifier MagDevaIn => GetModelIdentifier (ref _magDevaIn, ModelIdentifiers._MagDevaIn);

		static DigitalInkRecognitionModelIdentifier _maiIn;
		public static DigitalInkRecognitionModelIdentifier MaiIn => GetModelIdentifier (ref _maiIn, ModelIdentifiers._MaiIn);

		static DigitalInkRecognitionModelIdentifier _maiLatn;
		public static DigitalInkRecognitionModelIdentifier MaiLatn => GetModelIdentifier (ref _maiLatn, ModelIdentifiers._MaiLatn);

		static DigitalInkRecognitionModelIdentifier _masLatnKe;
		public static DigitalInkRecognitionModelIdentifier MasLatnKe => GetModelIdentifier (ref _masLatnKe, ModelIdentifiers._MasLatnKe);

		static DigitalInkRecognitionModelIdentifier _maxLatnId;
		public static DigitalInkRecognitionModelIdentifier MaxLatnId => GetModelIdentifier (ref _maxLatnId, ModelIdentifiers._MaxLatnId);

		static DigitalInkRecognitionModelIdentifier _mdhLatnPh;
		public static DigitalInkRecognitionModelIdentifier MdhLatnPh => GetModelIdentifier (ref _mdhLatnPh, ModelIdentifiers._MdhLatnPh);

		static DigitalInkRecognitionModelIdentifier _melLatnMy;
		public static DigitalInkRecognitionModelIdentifier MelLatnMy => GetModelIdentifier (ref _melLatnMy, ModelIdentifiers._MelLatnMy);

		static DigitalInkRecognitionModelIdentifier _meoLatnMy;
		public static DigitalInkRecognitionModelIdentifier MeoLatnMy => GetModelIdentifier (ref _meoLatnMy, ModelIdentifiers._MeoLatnMy);

		static DigitalInkRecognitionModelIdentifier _mfbLatnId;
		public static DigitalInkRecognitionModelIdentifier MfbLatnId => GetModelIdentifier (ref _mfbLatnId, ModelIdentifiers._MfbLatnId);

		static DigitalInkRecognitionModelIdentifier _mfpLatnId;
		public static DigitalInkRecognitionModelIdentifier MfpLatnId => GetModelIdentifier (ref _mfpLatnId, ModelIdentifiers._MfpLatnId);

		static DigitalInkRecognitionModelIdentifier _mg;
		public static DigitalInkRecognitionModelIdentifier Mg => GetModelIdentifier (ref _mg, ModelIdentifiers._Mg);

		static DigitalInkRecognitionModelIdentifier _miLatn;
		public static DigitalInkRecognitionModelIdentifier MiLatn => GetModelIdentifier (ref _miLatn, ModelIdentifiers._MiLatn);

		static DigitalInkRecognitionModelIdentifier _minLatnId;
		public static DigitalInkRecognitionModelIdentifier MinLatnId => GetModelIdentifier (ref _minLatnId, ModelIdentifiers._MinLatnId);

		static DigitalInkRecognitionModelIdentifier _mk;
		public static DigitalInkRecognitionModelIdentifier Mk => GetModelIdentifier (ref _mk, ModelIdentifiers._Mk);

		static DigitalInkRecognitionModelIdentifier _ml;
		public static DigitalInkRecognitionModelIdentifier Ml => GetModelIdentifier (ref _ml, ModelIdentifiers._Ml);

		static DigitalInkRecognitionModelIdentifier _mlLatn;
		public static DigitalInkRecognitionModelIdentifier MlLatn => GetModelIdentifier (ref _mlLatn, ModelIdentifiers._MlLatn);

		static DigitalInkRecognitionModelIdentifier _mnCyrl;
		public static DigitalInkRecognitionModelIdentifier MnCyrl => GetModelIdentifier (ref _mnCyrl, ModelIdentifiers._MnCyrl);

		static DigitalInkRecognitionModelIdentifier _mniLatn;
		public static DigitalInkRecognitionModelIdentifier MniLatn => GetModelIdentifier (ref _mniLatn, ModelIdentifiers._MniLatn);

		static DigitalInkRecognitionModelIdentifier _mqyLatnId;
		public static DigitalInkRecognitionModelIdentifier MqyLatnId => GetModelIdentifier (ref _mqyLatnId, ModelIdentifiers._MqyLatnId);

		static DigitalInkRecognitionModelIdentifier _mr;
		public static DigitalInkRecognitionModelIdentifier Mr => GetModelIdentifier (ref _mr, ModelIdentifiers._Mr);

		static DigitalInkRecognitionModelIdentifier _mrIn;
		public static DigitalInkRecognitionModelIdentifier MrIn => GetModelIdentifier (ref _mrIn, ModelIdentifiers._MrIn);

		static DigitalInkRecognitionModelIdentifier _mrLatn;
		public static DigitalInkRecognitionModelIdentifier MrLatn => GetModelIdentifier (ref _mrLatn, ModelIdentifiers._MrLatn);

		static DigitalInkRecognitionModelIdentifier _mrwLatnPh;
		public static DigitalInkRecognitionModelIdentifier MrwLatnPh => GetModelIdentifier (ref _mrwLatnPh, ModelIdentifiers._MrwLatnPh);

		static DigitalInkRecognitionModelIdentifier _ms;
		public static DigitalInkRecognitionModelIdentifier Ms => GetModelIdentifier (ref _ms, ModelIdentifiers._Ms);

		static DigitalInkRecognitionModelIdentifier _msBn;
		public static DigitalInkRecognitionModelIdentifier MsBn => GetModelIdentifier (ref _msBn, ModelIdentifiers._MsBn);

		static DigitalInkRecognitionModelIdentifier _msMy;
		public static DigitalInkRecognitionModelIdentifier MsMy => GetModelIdentifier (ref _msMy, ModelIdentifiers._MsMy);

		static DigitalInkRecognitionModelIdentifier _msiLatnMy;
		public static DigitalInkRecognitionModelIdentifier MsiLatnMy => GetModelIdentifier (ref _msiLatnMy, ModelIdentifiers._MsiLatnMy);

		static DigitalInkRecognitionModelIdentifier _mt;
		public static DigitalInkRecognitionModelIdentifier Mt => GetModelIdentifier (ref _mt, ModelIdentifiers._Mt);

		static DigitalInkRecognitionModelIdentifier _mtrDevaIn;
		public static DigitalInkRecognitionModelIdentifier MtrDevaIn => GetModelIdentifier (ref _mtrDevaIn, ModelIdentifiers._MtrDevaIn);

		static DigitalInkRecognitionModelIdentifier _muiLatnId;
		public static DigitalInkRecognitionModelIdentifier MuiLatnId => GetModelIdentifier (ref _muiLatnId, ModelIdentifiers._MuiLatnId);

		static DigitalInkRecognitionModelIdentifier _mupDevaIn;
		public static DigitalInkRecognitionModelIdentifier MupDevaIn => GetModelIdentifier (ref _mupDevaIn, ModelIdentifiers._MupDevaIn);

		static DigitalInkRecognitionModelIdentifier _mveDevaPk;
		public static DigitalInkRecognitionModelIdentifier MveDevaPk => GetModelIdentifier (ref _mveDevaPk, ModelIdentifiers._MveDevaPk);

		static DigitalInkRecognitionModelIdentifier _mwrDevaIn;
		public static DigitalInkRecognitionModelIdentifier MwrDevaIn => GetModelIdentifier (ref _mwrDevaIn, ModelIdentifiers._MwrDevaIn);

		static DigitalInkRecognitionModelIdentifier _mwwLatnCn;
		public static DigitalInkRecognitionModelIdentifier MwwLatnCn => GetModelIdentifier (ref _mwwLatnCn, ModelIdentifiers._MwwLatnCn);

		static DigitalInkRecognitionModelIdentifier _my;
		public static DigitalInkRecognitionModelIdentifier My => GetModelIdentifier (ref _my, ModelIdentifiers._My);

		static DigitalInkRecognitionModelIdentifier _myxLatnUg;
		public static DigitalInkRecognitionModelIdentifier MyxLatnUg => GetModelIdentifier (ref _myxLatnUg, ModelIdentifiers._MyxLatnUg);

		static DigitalInkRecognitionModelIdentifier _nahLatn;
		public static DigitalInkRecognitionModelIdentifier NahLatn => GetModelIdentifier (ref _nahLatn, ModelIdentifiers._NahLatn);

		static DigitalInkRecognitionModelIdentifier _napLatnIt;
		public static DigitalInkRecognitionModelIdentifier NapLatnIt => GetModelIdentifier (ref _napLatnIt, ModelIdentifiers._NapLatnIt);

		static DigitalInkRecognitionModelIdentifier _ndcLatnZw;
		public static DigitalInkRecognitionModelIdentifier NdcLatnZw => GetModelIdentifier (ref _ndcLatnZw, ModelIdentifiers._NdcLatnZw);

		static DigitalInkRecognitionModelIdentifier _ne;
		public static DigitalInkRecognitionModelIdentifier Ne => GetModelIdentifier (ref _ne, ModelIdentifiers._Ne);

		static DigitalInkRecognitionModelIdentifier _neIn;
		public static DigitalInkRecognitionModelIdentifier NeIn => GetModelIdentifier (ref _neIn, ModelIdentifiers._NeIn);

		static DigitalInkRecognitionModelIdentifier _neLatn;
		public static DigitalInkRecognitionModelIdentifier NeLatn => GetModelIdentifier (ref _neLatn, ModelIdentifiers._NeLatn);

		static DigitalInkRecognitionModelIdentifier _neNp;
		public static DigitalInkRecognitionModelIdentifier NeNp => GetModelIdentifier (ref _neNp, ModelIdentifiers._NeNp);

		static DigitalInkRecognitionModelIdentifier _newDevaNp;
		public static DigitalInkRecognitionModelIdentifier NewDevaNp => GetModelIdentifier (ref _newDevaNp, ModelIdentifiers._NewDevaNp);

		static DigitalInkRecognitionModelIdentifier _ngLatnNa;
		public static DigitalInkRecognitionModelIdentifier NgLatnNa => GetModelIdentifier (ref _ngLatnNa, ModelIdentifiers._NgLatnNa);

		static DigitalInkRecognitionModelIdentifier _ngaLatnCd;
		public static DigitalInkRecognitionModelIdentifier NgaLatnCd => GetModelIdentifier (ref _ngaLatnCd, ModelIdentifiers._NgaLatnCd);

		static DigitalInkRecognitionModelIdentifier _niqLatnKe;
		public static DigitalInkRecognitionModelIdentifier NiqLatnKe => GetModelIdentifier (ref _niqLatnKe, ModelIdentifiers._NiqLatnKe);

		static DigitalInkRecognitionModelIdentifier _nlBe;
		public static DigitalInkRecognitionModelIdentifier NlBe => GetModelIdentifier (ref _nlBe, ModelIdentifiers._NlBe);

		static DigitalInkRecognitionModelIdentifier _nlNl;
		public static DigitalInkRecognitionModelIdentifier NlNl => GetModelIdentifier (ref _nlNl, ModelIdentifiers._NlNl);

		static DigitalInkRecognitionModelIdentifier _nnNo;
		public static DigitalInkRecognitionModelIdentifier NnNo => GetModelIdentifier (ref _nnNo, ModelIdentifiers._NnNo);

		static DigitalInkRecognitionModelIdentifier _no;
		public static DigitalInkRecognitionModelIdentifier No => GetModelIdentifier (ref _no, ModelIdentifiers._No);

		static DigitalInkRecognitionModelIdentifier _noeDevaIn;
		public static DigitalInkRecognitionModelIdentifier NoeDevaIn => GetModelIdentifier (ref _noeDevaIn, ModelIdentifiers._NoeDevaIn);

		static DigitalInkRecognitionModelIdentifier _nrZa;
		public static DigitalInkRecognitionModelIdentifier NrZa => GetModelIdentifier (ref _nrZa, ModelIdentifiers._NrZa);

		static DigitalInkRecognitionModelIdentifier _nso;
		public static DigitalInkRecognitionModelIdentifier Nso => GetModelIdentifier (ref _nso, ModelIdentifiers._Nso);

		static DigitalInkRecognitionModelIdentifier _ny;
		public static DigitalInkRecognitionModelIdentifier Ny => GetModelIdentifier (ref _ny, ModelIdentifiers._Ny);

		static DigitalInkRecognitionModelIdentifier _nymLatnTz;
		public static DigitalInkRecognitionModelIdentifier NymLatnTz => GetModelIdentifier (ref _nymLatnTz, ModelIdentifiers._NymLatnTz);

		static DigitalInkRecognitionModelIdentifier _nyoLatnUg;
		public static DigitalInkRecognitionModelIdentifier NyoLatnUg => GetModelIdentifier (ref _nyoLatnUg, ModelIdentifiers._NyoLatnUg);

		static DigitalInkRecognitionModelIdentifier _ocLatnFr;
		public static DigitalInkRecognitionModelIdentifier OcLatnFr => GetModelIdentifier (ref _ocLatnFr, ModelIdentifiers._OcLatnFr);

		static DigitalInkRecognitionModelIdentifier _ojLatn;
		public static DigitalInkRecognitionModelIdentifier OjLatn => GetModelIdentifier (ref _ojLatn, ModelIdentifiers._OjLatn);

		static DigitalInkRecognitionModelIdentifier _oloLatnRu;
		public static DigitalInkRecognitionModelIdentifier OloLatnRu => GetModelIdentifier (ref _oloLatnRu, ModelIdentifiers._OloLatnRu);

		static DigitalInkRecognitionModelIdentifier _om;
		public static DigitalInkRecognitionModelIdentifier Om => GetModelIdentifier (ref _om, ModelIdentifiers._Om);

		static DigitalInkRecognitionModelIdentifier _or;
		public static DigitalInkRecognitionModelIdentifier Or => GetModelIdentifier (ref _or, ModelIdentifiers._Or);

		static DigitalInkRecognitionModelIdentifier _orLatn;
		public static DigitalInkRecognitionModelIdentifier OrLatn => GetModelIdentifier (ref _orLatn, ModelIdentifiers._OrLatn);

		static DigitalInkRecognitionModelIdentifier _pa;
		public static DigitalInkRecognitionModelIdentifier Pa => GetModelIdentifier (ref _pa, ModelIdentifiers._Pa);

		static DigitalInkRecognitionModelIdentifier _paLatn;
		public static DigitalInkRecognitionModelIdentifier PaLatn => GetModelIdentifier (ref _paLatn, ModelIdentifiers._PaLatn);

		static DigitalInkRecognitionModelIdentifier _pagLatnPh;
		public static DigitalInkRecognitionModelIdentifier PagLatnPh => GetModelIdentifier (ref _pagLatnPh, ModelIdentifiers._PagLatnPh);

		static DigitalInkRecognitionModelIdentifier _pamLatnPh;
		public static DigitalInkRecognitionModelIdentifier PamLatnPh => GetModelIdentifier (ref _pamLatnPh, ModelIdentifiers._PamLatnPh);

		static DigitalInkRecognitionModelIdentifier _papLatn;
		public static DigitalInkRecognitionModelIdentifier PapLatn => GetModelIdentifier (ref _papLatn, ModelIdentifiers._PapLatn);

		static DigitalInkRecognitionModelIdentifier _pccLatnCn;
		public static DigitalInkRecognitionModelIdentifier PccLatnCn => GetModelIdentifier (ref _pccLatnCn, ModelIdentifiers._PccLatnCn);

		static DigitalInkRecognitionModelIdentifier _pcdLatnBe;
		public static DigitalInkRecognitionModelIdentifier PcdLatnBe => GetModelIdentifier (ref _pcdLatnBe, ModelIdentifiers._PcdLatnBe);

		static DigitalInkRecognitionModelIdentifier _pcmLatnNg;
		public static DigitalInkRecognitionModelIdentifier PcmLatnNg => GetModelIdentifier (ref _pcmLatnNg, ModelIdentifiers._PcmLatnNg);

		static DigitalInkRecognitionModelIdentifier _pkoLatnKe;
		public static DigitalInkRecognitionModelIdentifier PkoLatnKe => GetModelIdentifier (ref _pkoLatnKe, ModelIdentifiers._PkoLatnKe);

		static DigitalInkRecognitionModelIdentifier _pl;
		public static DigitalInkRecognitionModelIdentifier Pl => GetModelIdentifier (ref _pl, ModelIdentifiers._Pl);

		static DigitalInkRecognitionModelIdentifier _pmsLatnIt;
		public static DigitalInkRecognitionModelIdentifier PmsLatnIt => GetModelIdentifier (ref _pmsLatnIt, ModelIdentifiers._PmsLatnIt);

		static DigitalInkRecognitionModelIdentifier _pmyLatnId;
		public static DigitalInkRecognitionModelIdentifier PmyLatnId => GetModelIdentifier (ref _pmyLatnId, ModelIdentifiers._PmyLatnId);

		static DigitalInkRecognitionModelIdentifier _povLatnGw;
		public static DigitalInkRecognitionModelIdentifier PovLatnGw => GetModelIdentifier (ref _povLatnGw, ModelIdentifiers._PovLatnGw);

		static DigitalInkRecognitionModelIdentifier _prkLatnMm;
		public static DigitalInkRecognitionModelIdentifier PrkLatnMm => GetModelIdentifier (ref _prkLatnMm, ModelIdentifiers._PrkLatnMm);

		static DigitalInkRecognitionModelIdentifier _pseLatnId;
		public static DigitalInkRecognitionModelIdentifier PseLatnId => GetModelIdentifier (ref _pseLatnId, ModelIdentifiers._PseLatnId);

		static DigitalInkRecognitionModelIdentifier _pt;
		public static DigitalInkRecognitionModelIdentifier Pt => GetModelIdentifier (ref _pt, ModelIdentifiers._Pt);

		static DigitalInkRecognitionModelIdentifier _pt002;
		public static DigitalInkRecognitionModelIdentifier Pt002 => GetModelIdentifier (ref _pt002, ModelIdentifiers._Pt002);

		static DigitalInkRecognitionModelIdentifier _ptBr;
		public static DigitalInkRecognitionModelIdentifier PtBr => GetModelIdentifier (ref _ptBr, ModelIdentifiers._PtBr);

		static DigitalInkRecognitionModelIdentifier _ptPt;
		public static DigitalInkRecognitionModelIdentifier PtPt => GetModelIdentifier (ref _ptPt, ModelIdentifiers._PtPt);

		static DigitalInkRecognitionModelIdentifier _quPe;
		public static DigitalInkRecognitionModelIdentifier QuPe => GetModelIdentifier (ref _quPe, ModelIdentifiers._QuPe);

		static DigitalInkRecognitionModelIdentifier _qucLatn;
		public static DigitalInkRecognitionModelIdentifier QucLatn => GetModelIdentifier (ref _qucLatn, ModelIdentifiers._QucLatn);

		static DigitalInkRecognitionModelIdentifier _rcfLatnRe;
		public static DigitalInkRecognitionModelIdentifier RcfLatnRe => GetModelIdentifier (ref _rcfLatnRe, ModelIdentifiers._RcfLatnRe);

		static DigitalInkRecognitionModelIdentifier _rktDevaIn;
		public static DigitalInkRecognitionModelIdentifier RktDevaIn => GetModelIdentifier (ref _rktDevaIn, ModelIdentifiers._RktDevaIn);

		static DigitalInkRecognitionModelIdentifier _rmCh;
		public static DigitalInkRecognitionModelIdentifier RmCh => GetModelIdentifier (ref _rmCh, ModelIdentifiers._RmCh);

		static DigitalInkRecognitionModelIdentifier _rnBi;
		public static DigitalInkRecognitionModelIdentifier RnBi => GetModelIdentifier (ref _rnBi, ModelIdentifiers._RnBi);

		static DigitalInkRecognitionModelIdentifier _roRo;
		public static DigitalInkRecognitionModelIdentifier RoRo => GetModelIdentifier (ref _roRo, ModelIdentifiers._RoRo);

		static DigitalInkRecognitionModelIdentifier _ru;
		public static DigitalInkRecognitionModelIdentifier Ru => GetModelIdentifier (ref _ru, ModelIdentifiers._Ru);

		static DigitalInkRecognitionModelIdentifier _rwrDevaIn;
		public static DigitalInkRecognitionModelIdentifier RwrDevaIn => GetModelIdentifier (ref _rwrDevaIn, ModelIdentifiers._RwrDevaIn);

		static DigitalInkRecognitionModelIdentifier _saDevaIn;
		public static DigitalInkRecognitionModelIdentifier SaDevaIn => GetModelIdentifier (ref _saDevaIn, ModelIdentifiers._SaDevaIn);

		static DigitalInkRecognitionModelIdentifier _saLatn;
		public static DigitalInkRecognitionModelIdentifier SaLatn => GetModelIdentifier (ref _saLatn, ModelIdentifiers._SaLatn);

		static DigitalInkRecognitionModelIdentifier _satDeva;
		public static DigitalInkRecognitionModelIdentifier SatDeva => GetModelIdentifier (ref _satDeva, ModelIdentifiers._SatDeva);

		static DigitalInkRecognitionModelIdentifier _satLatn;
		public static DigitalInkRecognitionModelIdentifier SatLatn => GetModelIdentifier (ref _satLatn, ModelIdentifiers._SatLatn);

		static DigitalInkRecognitionModelIdentifier _scLatnIt;
		public static DigitalInkRecognitionModelIdentifier ScLatnIt => GetModelIdentifier (ref _scLatnIt, ModelIdentifiers._ScLatnIt);

		static DigitalInkRecognitionModelIdentifier _sckDevaIn;
		public static DigitalInkRecognitionModelIdentifier SckDevaIn => GetModelIdentifier (ref _sckDevaIn, ModelIdentifiers._SckDevaIn);

		static DigitalInkRecognitionModelIdentifier _scoLatnGb;
		public static DigitalInkRecognitionModelIdentifier ScoLatnGb => GetModelIdentifier (ref _scoLatnGb, ModelIdentifiers._ScoLatnGb);

		static DigitalInkRecognitionModelIdentifier _sdDeva;
		public static DigitalInkRecognitionModelIdentifier SdDeva => GetModelIdentifier (ref _sdDeva, ModelIdentifiers._SdDeva);

		static DigitalInkRecognitionModelIdentifier _sdLatn;
		public static DigitalInkRecognitionModelIdentifier SdLatn => GetModelIdentifier (ref _sdLatn, ModelIdentifiers._SdLatn);

		static DigitalInkRecognitionModelIdentifier _sdcLatnIt;
		public static DigitalInkRecognitionModelIdentifier SdcLatnIt => GetModelIdentifier (ref _sdcLatnIt, ModelIdentifiers._SdcLatnIt);

		static DigitalInkRecognitionModelIdentifier _sgCf;
		public static DigitalInkRecognitionModelIdentifier SgCf => GetModelIdentifier (ref _sgCf, ModelIdentifiers._SgCf);

		static DigitalInkRecognitionModelIdentifier _sgcLatnKe;
		public static DigitalInkRecognitionModelIdentifier SgcLatnKe => GetModelIdentifier (ref _sgcLatnKe, ModelIdentifiers._SgcLatnKe);

		static DigitalInkRecognitionModelIdentifier _sgjDevaIn;
		public static DigitalInkRecognitionModelIdentifier SgjDevaIn => GetModelIdentifier (ref _sgjDevaIn, ModelIdentifiers._SgjDevaIn);

		static DigitalInkRecognitionModelIdentifier _sgsLatnLt;
		public static DigitalInkRecognitionModelIdentifier SgsLatnLt => GetModelIdentifier (ref _sgsLatnLt, ModelIdentifiers._SgsLatnLt);

		static DigitalInkRecognitionModelIdentifier _si;
		public static DigitalInkRecognitionModelIdentifier Si => GetModelIdentifier (ref _si, ModelIdentifiers._Si);

		static DigitalInkRecognitionModelIdentifier _sk;
		public static DigitalInkRecognitionModelIdentifier Sk => GetModelIdentifier (ref _sk, ModelIdentifiers._Sk);

		static DigitalInkRecognitionModelIdentifier _skgLatnMg;
		public static DigitalInkRecognitionModelIdentifier SkgLatnMg => GetModelIdentifier (ref _skgLatnMg, ModelIdentifiers._SkgLatnMg);

		static DigitalInkRecognitionModelIdentifier _sl;
		public static DigitalInkRecognitionModelIdentifier Sl => GetModelIdentifier (ref _sl, ModelIdentifiers._Sl);

		static DigitalInkRecognitionModelIdentifier _sm;
		public static DigitalInkRecognitionModelIdentifier Sm => GetModelIdentifier (ref _sm, ModelIdentifiers._Sm);

		static DigitalInkRecognitionModelIdentifier _snLatn;
		public static DigitalInkRecognitionModelIdentifier SnLatn => GetModelIdentifier (ref _snLatn, ModelIdentifiers._SnLatn);

		static DigitalInkRecognitionModelIdentifier _so;
		public static DigitalInkRecognitionModelIdentifier So => GetModelIdentifier (ref _so, ModelIdentifiers._So);

		static DigitalInkRecognitionModelIdentifier _sq;
		public static DigitalInkRecognitionModelIdentifier Sq => GetModelIdentifier (ref _sq, ModelIdentifiers._Sq);

		static DigitalInkRecognitionModelIdentifier _srCyrl;
		public static DigitalInkRecognitionModelIdentifier SrCyrl => GetModelIdentifier (ref _srCyrl, ModelIdentifiers._SrCyrl);

		static DigitalInkRecognitionModelIdentifier _srLatnRs;
		public static DigitalInkRecognitionModelIdentifier SrLatnRs => GetModelIdentifier (ref _srLatnRs, ModelIdentifiers._SrLatnRs);

		static DigitalInkRecognitionModelIdentifier _ssSz;
		public static DigitalInkRecognitionModelIdentifier SsSz => GetModelIdentifier (ref _ssSz, ModelIdentifiers._SsSz);

		static DigitalInkRecognitionModelIdentifier _stvLatn;
		public static DigitalInkRecognitionModelIdentifier StvLatn => GetModelIdentifier (ref _stvLatn, ModelIdentifiers._StvLatn);

		static DigitalInkRecognitionModelIdentifier _suLatn;
		public static DigitalInkRecognitionModelIdentifier SuLatn => GetModelIdentifier (ref _suLatn, ModelIdentifiers._SuLatn);

		static DigitalInkRecognitionModelIdentifier _sukLatnTz;
		public static DigitalInkRecognitionModelIdentifier SukLatnTz => GetModelIdentifier (ref _sukLatnTz, ModelIdentifiers._SukLatnTz);

		static DigitalInkRecognitionModelIdentifier _svFi;
		public static DigitalInkRecognitionModelIdentifier SvFi => GetModelIdentifier (ref _svFi, ModelIdentifiers._SvFi);

		static DigitalInkRecognitionModelIdentifier _svSe;
		public static DigitalInkRecognitionModelIdentifier SvSe => GetModelIdentifier (ref _svSe, ModelIdentifiers._SvSe);

		static DigitalInkRecognitionModelIdentifier _sw;
		public static DigitalInkRecognitionModelIdentifier Sw => GetModelIdentifier (ref _sw, ModelIdentifiers._Sw);

		static DigitalInkRecognitionModelIdentifier _swvDevaIn;
		public static DigitalInkRecognitionModelIdentifier SwvDevaIn => GetModelIdentifier (ref _swvDevaIn, ModelIdentifiers._SwvDevaIn);

		static DigitalInkRecognitionModelIdentifier _sxuLatnDe;
		public static DigitalInkRecognitionModelIdentifier SxuLatnDe => GetModelIdentifier (ref _sxuLatnDe, ModelIdentifiers._SxuLatnDe);

		static DigitalInkRecognitionModelIdentifier _sylLatn;
		public static DigitalInkRecognitionModelIdentifier SylLatn => GetModelIdentifier (ref _sylLatn, ModelIdentifiers._SylLatn);

		static DigitalInkRecognitionModelIdentifier _ta;
		public static DigitalInkRecognitionModelIdentifier Ta => GetModelIdentifier (ref _ta, ModelIdentifiers._Ta);

		static DigitalInkRecognitionModelIdentifier _taLatn;
		public static DigitalInkRecognitionModelIdentifier TaLatn => GetModelIdentifier (ref _taLatn, ModelIdentifiers._TaLatn);

		static DigitalInkRecognitionModelIdentifier _tdxLatnMg;
		public static DigitalInkRecognitionModelIdentifier TdxLatnMg => GetModelIdentifier (ref _tdxLatnMg, ModelIdentifiers._TdxLatnMg);

		static DigitalInkRecognitionModelIdentifier _te;
		public static DigitalInkRecognitionModelIdentifier Te => GetModelIdentifier (ref _te, ModelIdentifiers._Te);

		static DigitalInkRecognitionModelIdentifier _teLatn;
		public static DigitalInkRecognitionModelIdentifier TeLatn => GetModelIdentifier (ref _teLatn, ModelIdentifiers._TeLatn);

		static DigitalInkRecognitionModelIdentifier _tetLatnTl;
		public static DigitalInkRecognitionModelIdentifier TetLatnTl => GetModelIdentifier (ref _tetLatnTl, ModelIdentifiers._TetLatnTl);

		static DigitalInkRecognitionModelIdentifier _tgCyrl;
		public static DigitalInkRecognitionModelIdentifier TgCyrl => GetModelIdentifier (ref _tgCyrl, ModelIdentifiers._TgCyrl);

		static DigitalInkRecognitionModelIdentifier _th;
		public static DigitalInkRecognitionModelIdentifier Th => GetModelIdentifier (ref _th, ModelIdentifiers._Th);

		static DigitalInkRecognitionModelIdentifier _ti;
		public static DigitalInkRecognitionModelIdentifier Ti => GetModelIdentifier (ref _ti, ModelIdentifiers._Ti);

		static DigitalInkRecognitionModelIdentifier _tkLatn;
		public static DigitalInkRecognitionModelIdentifier TkLatn => GetModelIdentifier (ref _tkLatn, ModelIdentifiers._TkLatn);

		static DigitalInkRecognitionModelIdentifier _tnBw;
		public static DigitalInkRecognitionModelIdentifier TnBw => GetModelIdentifier (ref _tnBw, ModelIdentifiers._TnBw);

		static DigitalInkRecognitionModelIdentifier _tpi;
		public static DigitalInkRecognitionModelIdentifier Tpi => GetModelIdentifier (ref _tpi, ModelIdentifiers._Tpi);

		static DigitalInkRecognitionModelIdentifier _trTr;
		public static DigitalInkRecognitionModelIdentifier TrTr => GetModelIdentifier (ref _trTr, ModelIdentifiers._TrTr);

		static DigitalInkRecognitionModelIdentifier _trfLatnTt;
		public static DigitalInkRecognitionModelIdentifier TrfLatnTt => GetModelIdentifier (ref _trfLatnTt, ModelIdentifiers._TrfLatnTt);

		static DigitalInkRecognitionModelIdentifier _trpLatn;
		public static DigitalInkRecognitionModelIdentifier TrpLatn => GetModelIdentifier (ref _trpLatn, ModelIdentifiers._TrpLatn);

		static DigitalInkRecognitionModelIdentifier _ts;
		public static DigitalInkRecognitionModelIdentifier Ts => GetModelIdentifier (ref _ts, ModelIdentifiers._Ts);

		static DigitalInkRecognitionModelIdentifier _tsgLatnPh;
		public static DigitalInkRecognitionModelIdentifier TsgLatnPh => GetModelIdentifier (ref _tsgLatnPh, ModelIdentifiers._TsgLatnPh);

		static DigitalInkRecognitionModelIdentifier _tumLatnMw;
		public static DigitalInkRecognitionModelIdentifier TumLatnMw => GetModelIdentifier (ref _tumLatnMw, ModelIdentifiers._TumLatnMw);

		static DigitalInkRecognitionModelIdentifier _tuvLatnKe;
		public static DigitalInkRecognitionModelIdentifier TuvLatnKe => GetModelIdentifier (ref _tuvLatnKe, ModelIdentifiers._TuvLatnKe);

		static DigitalInkRecognitionModelIdentifier _twdLatnNl;
		public static DigitalInkRecognitionModelIdentifier TwdLatnNl => GetModelIdentifier (ref _twdLatnNl, ModelIdentifiers._TwdLatnNl);

		static DigitalInkRecognitionModelIdentifier _uk;
		public static DigitalInkRecognitionModelIdentifier Uk => GetModelIdentifier (ref _uk, ModelIdentifiers._Uk);

		static DigitalInkRecognitionModelIdentifier _unrDevaIn;
		public static DigitalInkRecognitionModelIdentifier UnrDevaIn => GetModelIdentifier (ref _unrDevaIn, ModelIdentifiers._UnrDevaIn);

		static DigitalInkRecognitionModelIdentifier _unrLatn;
		public static DigitalInkRecognitionModelIdentifier UnrLatn => GetModelIdentifier (ref _unrLatn, ModelIdentifiers._UnrLatn);

		static DigitalInkRecognitionModelIdentifier _ur;
		public static DigitalInkRecognitionModelIdentifier Ur => GetModelIdentifier (ref _ur, ModelIdentifiers._Ur);

		static DigitalInkRecognitionModelIdentifier _urLatn;
		public static DigitalInkRecognitionModelIdentifier UrLatn => GetModelIdentifier (ref _urLatn, ModelIdentifiers._UrLatn);

		static DigitalInkRecognitionModelIdentifier _urPk;
		public static DigitalInkRecognitionModelIdentifier UrPk => GetModelIdentifier (ref _urPk, ModelIdentifiers._UrPk);

		static DigitalInkRecognitionModelIdentifier _uzLatn;
		public static DigitalInkRecognitionModelIdentifier UzLatn => GetModelIdentifier (ref _uzLatn, ModelIdentifiers._UzLatn);

		static DigitalInkRecognitionModelIdentifier _velLatnNl;
		public static DigitalInkRecognitionModelIdentifier VelLatnNl => GetModelIdentifier (ref _velLatnNl, ModelIdentifiers._VelLatnNl);

		static DigitalInkRecognitionModelIdentifier _vepLatnRu;
		public static DigitalInkRecognitionModelIdentifier VepLatnRu => GetModelIdentifier (ref _vepLatnRu, ModelIdentifiers._VepLatnRu);

		static DigitalInkRecognitionModelIdentifier _vi;
		public static DigitalInkRecognitionModelIdentifier Vi => GetModelIdentifier (ref _vi, ModelIdentifiers._Vi);

		static DigitalInkRecognitionModelIdentifier _vktLatnId;
		public static DigitalInkRecognitionModelIdentifier VktLatnId => GetModelIdentifier (ref _vktLatnId, ModelIdentifiers._VktLatnId);

		static DigitalInkRecognitionModelIdentifier _waLatnBe;
		public static DigitalInkRecognitionModelIdentifier WaLatnBe => GetModelIdentifier (ref _waLatnBe, ModelIdentifiers._WaLatnBe);

		static DigitalInkRecognitionModelIdentifier _wbrDevaIn;
		public static DigitalInkRecognitionModelIdentifier WbrDevaIn => GetModelIdentifier (ref _wbrDevaIn, ModelIdentifiers._WbrDevaIn);

		static DigitalInkRecognitionModelIdentifier _wryDevaIn;
		public static DigitalInkRecognitionModelIdentifier WryDevaIn => GetModelIdentifier (ref _wryDevaIn, ModelIdentifiers._WryDevaIn);

		static DigitalInkRecognitionModelIdentifier _xh;
		public static DigitalInkRecognitionModelIdentifier Xh => GetModelIdentifier (ref _xh, ModelIdentifiers._Xh);

		static DigitalInkRecognitionModelIdentifier _xmmLatnId;
		public static DigitalInkRecognitionModelIdentifier XmmLatnId => GetModelIdentifier (ref _xmmLatnId, ModelIdentifiers._XmmLatnId);

		static DigitalInkRecognitionModelIdentifier _xnrDevaIn;
		public static DigitalInkRecognitionModelIdentifier XnrDevaIn => GetModelIdentifier (ref _xnrDevaIn, ModelIdentifiers._XnrDevaIn);

		static DigitalInkRecognitionModelIdentifier _ymmLatnSo;
		public static DigitalInkRecognitionModelIdentifier YmmLatnSo => GetModelIdentifier (ref _ymmLatnSo, ModelIdentifiers._YmmLatnSo);

		static DigitalInkRecognitionModelIdentifier _zaLatnCn;
		public static DigitalInkRecognitionModelIdentifier ZaLatnCn => GetModelIdentifier (ref _zaLatnCn, ModelIdentifiers._ZaLatnCn);

		static DigitalInkRecognitionModelIdentifier _zhHani;
		public static DigitalInkRecognitionModelIdentifier ZhHani => GetModelIdentifier (ref _zhHani, ModelIdentifiers._ZhHani);

		static DigitalInkRecognitionModelIdentifier _zhHaniCn;
		public static DigitalInkRecognitionModelIdentifier ZhHaniCn => GetModelIdentifier (ref _zhHaniCn, ModelIdentifiers._ZhHaniCn);

		static DigitalInkRecognitionModelIdentifier _zhHaniHk;
		public static DigitalInkRecognitionModelIdentifier ZhHaniHk => GetModelIdentifier (ref _zhHaniHk, ModelIdentifiers._ZhHaniHk);

		static DigitalInkRecognitionModelIdentifier _zhHaniTw;
		public static DigitalInkRecognitionModelIdentifier ZhHaniTw => GetModelIdentifier (ref _zhHaniTw, ModelIdentifiers._ZhHaniTw);

		static DigitalInkRecognitionModelIdentifier _zu;
		public static DigitalInkRecognitionModelIdentifier Zu => GetModelIdentifier (ref _zu, ModelIdentifiers._Zu);

		static DigitalInkRecognitionModelIdentifier _zyjLatnCn;
		public static DigitalInkRecognitionModelIdentifier ZyjLatnCn => GetModelIdentifier (ref _zyjLatnCn, ModelIdentifiers._ZyjLatnCn);

		static DigitalInkRecognitionModelIdentifier GetModelIdentifier (ref DigitalInkRecognitionModelIdentifier identifier, IntPtr intPtr)
		{
			if (identifier == null && intPtr != null) {
				identifier = ObjCRuntime.Runtime.GetNSObject<DigitalInkRecognitionModelIdentifier> (intPtr);
			}

			return identifier;
		}
	}
}
