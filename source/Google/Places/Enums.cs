using System;

using Foundation;
using ObjCRuntime;

namespace Google.Places {
	[Native]
	public enum AutocompleteBoundsMode : ulong {
		Bias,
		Restrict
	}

	[Native]
	public enum PlacesAutocompleteTypeFilter : long {
		NoFilter,
		Geocode,
		Address,
		Establishment,
		Region,
		City
	}

	[Native]
	public enum OpenNowStatus : long {
		Yes,
		No,
		Unknown
	}

	[Native]
	public enum DayOfWeek : ulong {
		Sunday = 1,
		Monday = 2,
		Tuesday = 3,
		Wednesday = 4,
		Thursday = 5,
		Friday = 6,
		Saturday = 7
	}

	[Obsolete ("This enum is currently not supported and should not be used. Use PlaceOpenStatus enum instead.")]
	[Native]
	public enum PlacesOpenNowStatus : long {
		Yes,
		No,
		Unknown
	}

	[Native]
	public enum PlacesPriceLevel : long {
		Unknown = -1,
		Free = 0,
		Cheap = 1,
		Medium = 2,
		High = 3,
		Expensive = 4
	}

	[Native]
	public enum PlaceOpenStatus : long {
		Unknown,
		Open,
		Closed
	}

	[Native]
	public enum PlacesBusinessStatus : long {
		Unknown,
		Operational,
		ClosedTemporarily,
		ClosedPermanently
	}

	[Flags]
	[Native]
	public enum PlaceField : ulong {
		Name = 1 << 0,
		PlaceId = 1 << 1,
		[Obsolete ("Use PlaceId value instead. This will be removed in future verions.")]
		PlaceID = PlaceId,
		PlusCode = 1 << 2,
		Coordinate = 1 << 3,
		OpeningHours = 1 << 4,
		PhoneNumber = 1 << 5,
		FormattedAddress = 1 << 6,
		Rating = 1 << 7,
		PriceLevel = 1 << 8,
		Types = 1 << 9,
		Website = 1 << 10,
		Viewport = 1 << 11,
		AddressComponents = 1 << 12,
		Photos = 1 << 13,
		UserRatingsTotal = 1 << 14,
		UtcOffsetMinutes = 1 << 15,
		BusinessStatus = 1 << 16,
		All = ulong.MaxValue
	}

	[Native]
	public enum PlacesErrorCode : long {
		NetworkError = -1,
		ServerError = -2,
		InternalError = -3,
		KeyInvalid = -4,
		KeyExpired = -5,
		UsageLimitExceeded = -6,
		RateLimitExceeded = -7,
		DeviceRateLimitExceeded = -8,
		AccessNotConfigured = -9,
		IncorrectBundleIdentifier = -10,
		LocationError = -11,
		InvalidRequest = -12
	}

	public enum PlaceType {
		// extern NSString *const kGMSPlaceTypeAccounting;
		[Field ("kGMSPlaceTypeAccounting", "__Internal")]
		Accounting,

		// extern NSString *const kGMSPlaceTypeAdministrativeAreaLevel1;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel1", "__Internal")]
		AdministrativeAreaLevel1,

		// extern NSString *const kGMSPlaceTypeAdministrativeAreaLevel2;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel2", "__Internal")]
		AdministrativeAreaLevel2,

		// extern NSString *const kGMSPlaceTypeAdministrativeAreaLevel3;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel3", "__Internal")]
		AdministrativeAreaLevel3,

		// extern NSString *const kGMSPlaceTypeAdministrativeAreaLevel4;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel4", "__Internal")]
		AdministrativeAreaLevel4,

		// extern NSString *const kGMSPlaceTypeAdministrativeAreaLevel5;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel5", "__Internal")]
		AdministrativeAreaLevel5,

		// extern NSString *const kGMSPlaceTypeAirport;
		[Field ("kGMSPlaceTypeAirport", "__Internal")]
		Airport,

		// extern NSString *const kGMSPlaceTypeAmusementPark;
		[Field ("kGMSPlaceTypeAmusementPark", "__Internal")]
		AmusementPark,

		// extern NSString *const kGMSPlaceTypeAquarium;
		[Field ("kGMSPlaceTypeAquarium", "__Internal")]
		Aquarium,

		// extern NSString *const kGMSPlaceTypeArtGallery;
		[Field ("kGMSPlaceTypeArtGallery", "__Internal")]
		ArtGallery,

		// extern NSString *const kGMSPlaceTypeAtm;
		[Field ("kGMSPlaceTypeAtm", "__Internal")]
		Atm,

		// extern NSString *const kGMSPlaceTypeBakery;
		[Field ("kGMSPlaceTypeBakery", "__Internal")]
		Bakery,

		// extern NSString *const kGMSPlaceTypeBank;
		[Field ("kGMSPlaceTypeBank", "__Internal")]
		Bank,

		// extern NSString *const kGMSPlaceTypeBar;
		[Field ("kGMSPlaceTypeBar", "__Internal")]
		Bar,

		// extern NSString *const kGMSPlaceTypeBeautySalon;
		[Field ("kGMSPlaceTypeBeautySalon", "__Internal")]
		BeautySalon,

		// extern NSString *const kGMSPlaceTypeBicycleStore;
		[Field ("kGMSPlaceTypeBicycleStore", "__Internal")]
		BicycleStore,

		// extern NSString *const kGMSPlaceTypeBookStore;
		[Field ("kGMSPlaceTypeBookStore", "__Internal")]
		BookStore,

		// extern NSString *const kGMSPlaceTypeBowlingAlley;
		[Field ("kGMSPlaceTypeBowlingAlley", "__Internal")]
		BowlingAlley,

		// extern NSString *const kGMSPlaceTypeBusStation;
		[Field ("kGMSPlaceTypeBusStation", "__Internal")]
		BusStation,

		// extern NSString *const kGMSPlaceTypeCafe;
		[Field ("kGMSPlaceTypeCafe", "__Internal")]
		Cafe,

		// extern NSString *const kGMSPlaceTypeCampground;
		[Field ("kGMSPlaceTypeCampground", "__Internal")]
		Campground,

		// extern NSString *const kGMSPlaceTypeCarDealer;
		[Field ("kGMSPlaceTypeCarDealer", "__Internal")]
		CarDealer,

		// extern NSString *const kGMSPlaceTypeCarRental;
		[Field ("kGMSPlaceTypeCarRental", "__Internal")]
		CarRental,

		// extern NSString *const kGMSPlaceTypeCarRepair;
		[Field ("kGMSPlaceTypeCarRepair", "__Internal")]
		CarRepair,

		// extern NSString *const kGMSPlaceTypeCarWash;
		[Field ("kGMSPlaceTypeCarWash", "__Internal")]
		CarWash,

		// extern NSString *const kGMSPlaceTypeCasino;
		[Field ("kGMSPlaceTypeCasino", "__Internal")]
		Casino,

		// extern NSString *const kGMSPlaceTypeCemetery;
		[Field ("kGMSPlaceTypeCemetery", "__Internal")]
		Cemetery,

		// extern NSString *const kGMSPlaceTypeChurch;
		[Field ("kGMSPlaceTypeChurch", "__Internal")]
		Church,

		// extern NSString *const kGMSPlaceTypeCityHall;
		[Field ("kGMSPlaceTypeCityHall", "__Internal")]
		CityHall,

		// extern NSString *const kGMSPlaceTypeClothingStore;
		[Field ("kGMSPlaceTypeClothingStore", "__Internal")]
		ClothingStore,

		// extern NSString *const kGMSPlaceTypeColloquialArea;
		[Field ("kGMSPlaceTypeColloquialArea", "__Internal")]
		ColloquialArea,

		// extern NSString *const kGMSPlaceTypeConvenienceStore;
		[Field ("kGMSPlaceTypeConvenienceStore", "__Internal")]
		ConvenienceStore,

		// extern NSString *const kGMSPlaceTypeCountry;
		[Field ("kGMSPlaceTypeCountry", "__Internal")]
		Country,

		// extern NSString *const kGMSPlaceTypeCourthouse;
		[Field ("kGMSPlaceTypeCourthouse", "__Internal")]
		Courthouse,

		// extern NSString *const kGMSPlaceTypeDentist;
		[Field ("kGMSPlaceTypeDentist", "__Internal")]
		Dentist,

		// extern NSString *const kGMSPlaceTypeDepartmentStore;
		[Field ("kGMSPlaceTypeDepartmentStore", "__Internal")]
		DepartmentStore,

		// extern NSString *const kGMSPlaceTypeDoctor;
		[Field ("kGMSPlaceTypeDoctor", "__Internal")]
		Doctor,

		// extern NSString *const kGMSPlaceTypeElectrician;
		[Field ("kGMSPlaceTypeElectrician", "__Internal")]
		Electrician,

		// extern NSString *const kGMSPlaceTypeElectronicsStore;
		[Field ("kGMSPlaceTypeElectronicsStore", "__Internal")]
		ElectronicsStore,

		// extern NSString *const kGMSPlaceTypeEmbassy;
		[Field ("kGMSPlaceTypeEmbassy", "__Internal")]
		Embassy,

		// extern NSString *const kGMSPlaceTypeEstablishment;
		[Field ("kGMSPlaceTypeEstablishment", "__Internal")]
		Establishment,

		// extern NSString *const kGMSPlaceTypeFinance;
		[Field ("kGMSPlaceTypeFinance", "__Internal")]
		Finance,

		// extern NSString *const kGMSPlaceTypeFireStation;
		[Field ("kGMSPlaceTypeFireStation", "__Internal")]
		FireStation,

		// extern NSString *const kGMSPlaceTypeFloor;
		[Field ("kGMSPlaceTypeFloor", "__Internal")]
		Floor,

		// extern NSString *const kGMSPlaceTypeFlorist;
		[Field ("kGMSPlaceTypeFlorist", "__Internal")]
		Florist,

		// extern NSString *const kGMSPlaceTypeFood;
		[Field ("kGMSPlaceTypeFood", "__Internal")]
		Food,

		// extern NSString *const kGMSPlaceTypeFuneralHome;
		[Field ("kGMSPlaceTypeFuneralHome", "__Internal")]
		FuneralHome,

		// extern NSString *const kGMSPlaceTypeFurnitureStore;
		[Field ("kGMSPlaceTypeFurnitureStore", "__Internal")]
		FurnitureStore,

		// extern NSString *const kGMSPlaceTypeGasStation;
		[Field ("kGMSPlaceTypeGasStation", "__Internal")]
		GasStation,

		// extern NSString *const kGMSPlaceTypeGeneralContractor;
		[Field ("kGMSPlaceTypeGeneralContractor", "__Internal")]
		GeneralContractor,

		// extern NSString *const kGMSPlaceTypeGeocode;
		[Field ("kGMSPlaceTypeGeocode", "__Internal")]
		Geocode,

		// extern NSString *const kGMSPlaceTypeGroceryOrSupermarket;
		[Field ("kGMSPlaceTypeGroceryOrSupermarket", "__Internal")]
		GroceryOrSupermarket,

		// extern NSString *const kGMSPlaceTypeGym;
		[Field ("kGMSPlaceTypeGym", "__Internal")]
		Gym,

		// extern NSString *const kGMSPlaceTypeHairCare;
		[Field ("kGMSPlaceTypeHairCare", "__Internal")]
		HairCare,

		// extern NSString *const kGMSPlaceTypeHardwareStore;
		[Field ("kGMSPlaceTypeHardwareStore", "__Internal")]
		HardwareStore,

		// extern NSString *const kGMSPlaceTypeHealth;
		[Field ("kGMSPlaceTypeHealth", "__Internal")]
		Health,

		// extern NSString *const kGMSPlaceTypeHinduTemple;
		[Field ("kGMSPlaceTypeHinduTemple", "__Internal")]
		HinduTemple,

		// extern NSString *const kGMSPlaceTypeHomeGoodsStore;
		[Field ("kGMSPlaceTypeHomeGoodsStore", "__Internal")]
		HomeGoodsStore,

		// extern NSString *const kGMSPlaceTypeHospital;
		[Field ("kGMSPlaceTypeHospital", "__Internal")]
		Hospital,

		// extern NSString *const kGMSPlaceTypeInsuranceAgency;
		[Field ("kGMSPlaceTypeInsuranceAgency", "__Internal")]
		InsuranceAgency,

		// extern NSString *const kGMSPlaceTypeIntersection;
		[Field ("kGMSPlaceTypeIntersection", "__Internal")]
		Intersection,

		// extern NSString *const kGMSPlaceTypeJewelryStore;
		[Field ("kGMSPlaceTypeJewelryStore", "__Internal")]
		JewelryStore,

		// extern NSString *const kGMSPlaceTypeLaundry;
		[Field ("kGMSPlaceTypeLaundry", "__Internal")]
		Laundry,

		// extern NSString *const kGMSPlaceTypeLawyer;
		[Field ("kGMSPlaceTypeLawyer", "__Internal")]
		Lawyer,

		// extern NSString *const kGMSPlaceTypeLibrary;
		[Field ("kGMSPlaceTypeLibrary", "__Internal")]
		Library,

		// extern NSString *const kGMSPlaceTypeLiquorStore;
		[Field ("kGMSPlaceTypeLiquorStore", "__Internal")]
		LiquorStore,

		// extern NSString *const kGMSPlaceTypeLocalGovernmentOffice;
		[Field ("kGMSPlaceTypeLocalGovernmentOffice", "__Internal")]
		LocalGovernmentOffice,

		// extern NSString *const kGMSPlaceTypeLocality;
		[Field ("kGMSPlaceTypeLocality", "__Internal")]
		Locality,

		// extern NSString *const kGMSPlaceTypeLocksmith;
		[Field ("kGMSPlaceTypeLocksmith", "__Internal")]
		Locksmith,

		// extern NSString *const kGMSPlaceTypeLodging;
		[Field ("kGMSPlaceTypeLodging", "__Internal")]
		Lodging,

		// extern NSString *const kGMSPlaceTypeMealDelivery;
		[Field ("kGMSPlaceTypeMealDelivery", "__Internal")]
		MealDelivery,

		// extern NSString *const kGMSPlaceTypeMealTakeaway;
		[Field ("kGMSPlaceTypeMealTakeaway", "__Internal")]
		MealTakeaway,

		// extern NSString *const kGMSPlaceTypeMosque;
		[Field ("kGMSPlaceTypeMosque", "__Internal")]
		Mosque,

		// extern NSString *const kGMSPlaceTypeMovieRental;
		[Field ("kGMSPlaceTypeMovieRental", "__Internal")]
		MovieRental,

		// extern NSString *const kGMSPlaceTypeMovieTheater;
		[Field ("kGMSPlaceTypeMovieTheater", "__Internal")]
		MovieTheater,

		// extern NSString *const kGMSPlaceTypeMovingCompany;
		[Field ("kGMSPlaceTypeMovingCompany", "__Internal")]
		MovingCompany,

		// extern NSString *const kGMSPlaceTypeMuseum;
		[Field ("kGMSPlaceTypeMuseum", "__Internal")]
		Museum,

		// extern NSString *const kGMSPlaceTypeNaturalFeature;
		[Field ("kGMSPlaceTypeNaturalFeature", "__Internal")]
		NaturalFeature,

		// extern NSString *const kGMSPlaceTypeNeighborhood;
		[Field ("kGMSPlaceTypeNeighborhood", "__Internal")]
		Neighborhood,

		// extern NSString *const kGMSPlaceTypeNightClub;
		[Field ("kGMSPlaceTypeNightClub", "__Internal")]
		NightClub,

		// extern NSString *const kGMSPlaceTypePainter;
		[Field ("kGMSPlaceTypePainter", "__Internal")]
		Painter,

		// extern NSString *const kGMSPlaceTypePark;
		[Field ("kGMSPlaceTypePark", "__Internal")]
		Park,

		// extern NSString *const kGMSPlaceTypeParking;
		[Field ("kGMSPlaceTypeParking", "__Internal")]
		Parking,

		// extern NSString *const kGMSPlaceTypePetStore;
		[Field ("kGMSPlaceTypePetStore", "__Internal")]
		PetStore,

		// extern NSString *const kGMSPlaceTypePharmacy;
		[Field ("kGMSPlaceTypePharmacy", "__Internal")]
		Pharmacy,

		// extern NSString *const kGMSPlaceTypePhysiotherapist;
		[Field ("kGMSPlaceTypePhysiotherapist", "__Internal")]
		Physiotherapist,

		// extern NSString *const kGMSPlaceTypePlaceOfWorship;
		[Field ("kGMSPlaceTypePlaceOfWorship", "__Internal")]
		PlaceOfWorship,

		// extern NSString *const kGMSPlaceTypePlumber;
		[Field ("kGMSPlaceTypePlumber", "__Internal")]
		Plumber,

		// extern NSString *const kGMSPlaceTypePointOfInterest;
		[Field ("kGMSPlaceTypePointOfInterest", "__Internal")]
		PointOfInterest,

		// extern NSString *const kGMSPlaceTypePolice;
		[Field ("kGMSPlaceTypePolice", "__Internal")]
		Police,

		// extern NSString *const kGMSPlaceTypePolitical;
		[Field ("kGMSPlaceTypePolitical", "__Internal")]
		Political,

		// extern NSString *const kGMSPlaceTypePostBox;
		[Field ("kGMSPlaceTypePostBox", "__Internal")]
		PostBox,

		// extern NSString *const kGMSPlaceTypePostOffice;
		[Field ("kGMSPlaceTypePostOffice", "__Internal")]
		PostOffice,

		// extern NSString *const kGMSPlaceTypePostalCode;
		[Field ("kGMSPlaceTypePostalCode", "__Internal")]
		PostalCode,

		// extern NSString *const kGMSPlaceTypePostalCodePrefix;
		[Field ("kGMSPlaceTypePostalCodePrefix", "__Internal")]
		PostalCodePrefix,

		// extern NSString *const kGMSPlaceTypePostalCodeSuffix;
		[Field ("kGMSPlaceTypePostalCodeSuffix", "__Internal")]
		PostalCodeSuffix,

		// extern NSString *const kGMSPlaceTypePostalTown;
		[Field ("kGMSPlaceTypePostalTown", "__Internal")]
		PostalTown,

		// extern NSString *const kGMSPlaceTypePremise;
		[Field ("kGMSPlaceTypePremise", "__Internal")]
		Premise,

		// extern NSString *const kGMSPlaceTypeRealEstateAgency;
		[Field ("kGMSPlaceTypeRealEstateAgency", "__Internal")]
		RealEstateAgency,

		// extern NSString *const kGMSPlaceTypeRestaurant;
		[Field ("kGMSPlaceTypeRestaurant", "__Internal")]
		Restaurant,

		// extern NSString *const kGMSPlaceTypeRoofingContractor;
		[Field ("kGMSPlaceTypeRoofingContractor", "__Internal")]
		RoofingContractor,

		// extern NSString *const kGMSPlaceTypeRoom;
		[Field ("kGMSPlaceTypeRoom", "__Internal")]
		Room,

		// extern NSString *const kGMSPlaceTypeRoute;
		[Field ("kGMSPlaceTypeRoute", "__Internal")]
		Route,

		// extern NSString *const kGMSPlaceTypeRvPark;
		[Field ("kGMSPlaceTypeRvPark", "__Internal")]
		RvPark,

		// extern NSString *const kGMSPlaceTypeSchool;
		[Field ("kGMSPlaceTypeSchool", "__Internal")]
		School,

		// extern NSString *const kGMSPlaceTypeShoeStore;
		[Field ("kGMSPlaceTypeShoeStore", "__Internal")]
		ShoeStore,

		// extern NSString *const kGMSPlaceTypeShoppingMall;
		[Field ("kGMSPlaceTypeShoppingMall", "__Internal")]
		ShoppingMall,

		// extern NSString *const kGMSPlaceTypeSpa;
		[Field ("kGMSPlaceTypeSpa", "__Internal")]
		Spa,

		// extern NSString *const kGMSPlaceTypeStadium;
		[Field ("kGMSPlaceTypeStadium", "__Internal")]
		Stadium,

		// extern NSString *const kGMSPlaceTypeStorage;
		[Field ("kGMSPlaceTypeStorage", "__Internal")]
		Storage,

		// extern NSString *const kGMSPlaceTypeStore;
		[Field ("kGMSPlaceTypeStore", "__Internal")]
		Store,

		// extern NSString *const kGMSPlaceTypeStreetAddress;
		[Field ("kGMSPlaceTypeStreetAddress", "__Internal")]
		StreetAddress,

		// extern NSString *const kGMSPlaceTypeStreetNumber;
		[Field ("kGMSPlaceTypeStreetNumber", "__Internal")]
		StreetNumber,

		// extern NSString *const kGMSPlaceTypeSublocality;
		[Field ("kGMSPlaceTypeSublocality", "__Internal")]
		Sublocality,

		// extern NSString *const kGMSPlaceTypeSublocalityLevel1;
		[Field ("kGMSPlaceTypeSublocalityLevel1", "__Internal")]
		SublocalityLevel1,

		// extern NSString *const kGMSPlaceTypeSublocalityLevel2;
		[Field ("kGMSPlaceTypeSublocalityLevel2", "__Internal")]
		SublocalityLevel2,

		// extern NSString *const kGMSPlaceTypeSublocalityLevel3;
		[Field ("kGMSPlaceTypeSublocalityLevel3", "__Internal")]
		SublocalityLevel3,

		// extern NSString *const kGMSPlaceTypeSublocalityLevel4;
		[Field ("kGMSPlaceTypeSublocalityLevel4", "__Internal")]
		SublocalityLevel4,

		// extern NSString *const kGMSPlaceTypeSublocalityLevel5;
		[Field ("kGMSPlaceTypeSublocalityLevel5", "__Internal")]
		SublocalityLevel5,

		// extern NSString *const kGMSPlaceTypeSubpremise;
		[Field ("kGMSPlaceTypeSubpremise", "__Internal")]
		Subpremise,

		// extern NSString *const kGMSPlaceTypeSubwayStation;
		[Field ("kGMSPlaceTypeSubwayStation", "__Internal")]
		SubwayStation,

		// extern NSString *const kGMSPlaceTypeSynagogue;
		[Field ("kGMSPlaceTypeSynagogue", "__Internal")]
		Synagogue,

		// extern NSString *const kGMSPlaceTypeTaxiStand;
		[Field ("kGMSPlaceTypeTaxiStand", "__Internal")]
		TaxiStand,

		// extern NSString *const kGMSPlaceTypeTrainStation;
		[Field ("kGMSPlaceTypeTrainStation", "__Internal")]
		TrainStation,

		// extern NSString *const kGMSPlaceTypeTransitStation;
		[Field ("kGMSPlaceTypeTransitStation", "__Internal")]
		TransitStation,

		// extern NSString *const kGMSPlaceTypeTravelAgency;
		[Field ("kGMSPlaceTypeTravelAgency", "__Internal")]
		TravelAgency,

		// extern NSString *const kGMSPlaceTypeUniversity;
		[Field ("kGMSPlaceTypeUniversity", "__Internal")]
		University,

		// extern NSString *const kGMSPlaceTypeVeterinaryCare;
		[Field ("kGMSPlaceTypeVeterinaryCare", "__Internal")]
		VeterinaryCare,

		// extern NSString *const kGMSPlaceTypeZoo;
		[Field ("kGMSPlaceTypeZoo", "__Internal")]
		Zoo
	}
}
