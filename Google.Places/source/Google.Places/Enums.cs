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
	public enum PlaceField : ulong {
		Name = 1 << 0,
		PlaceID = 1 << 1,
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
		LocationError = -11
	}

	public enum PlaceType {
		// -(NSString *)kGMSPlaceTypeAccountingExported;
		[Field ("kGMSPlaceTypeAccounting", "__Internal")]
		Accounting,

		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel1Exported;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel1", "__Internal")]
		AdministrativeAreaLevel1,

		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel2Exported;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel2", "__Internal")]
		AdministrativeAreaLevel2,

		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel3Exported;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel3", "__Internal")]
		AdministrativeAreaLevel3,

		// -(NSString *)kGMSPlaceTypeAirportExported;
		[Field ("kGMSPlaceTypeAirport", "__Internal")]
		Airport,

		// -(NSString *)kGMSPlaceTypeAmusementParkExported;
		[Field ("kGMSPlaceTypeAmusementPark", "__Internal")]
		AmusementPark,

		// -(NSString *)kGMSPlaceTypeAquariumExported;
		[Field ("kGMSPlaceTypeAquarium", "__Internal")]
		Aquarium,

		// -(NSString *)kGMSPlaceTypeArtGalleryExported;
		[Field ("kGMSPlaceTypeArtGallery", "__Internal")]
		ArtGallery,

		// -(NSString *)kGMSPlaceTypeAtmExported;
		[Field ("kGMSPlaceTypeAtm", "__Internal")]
		Atm,

		// -(NSString *)kGMSPlaceTypeBakeryExported;
		[Field ("kGMSPlaceTypeBakery", "__Internal")]
		Bakery,

		// -(NSString *)kGMSPlaceTypeBankExported;
		[Field ("kGMSPlaceTypeBank", "__Internal")]
		Bank,

		// -(NSString *)kGMSPlaceTypeBarExported;
		[Field ("kGMSPlaceTypeBar", "__Internal")]
		Bar,

		// -(NSString *)kGMSPlaceTypeBeautySalonExported;
		[Field ("kGMSPlaceTypeBeautySalon", "__Internal")]
		BeautySalon,

		// -(NSString *)kGMSPlaceTypeBicycleStoreExported;
		[Field ("kGMSPlaceTypeBicycleStore", "__Internal")]
		BicycleStore,

		// -(NSString *)kGMSPlaceTypeBookStoreExported;
		[Field ("kGMSPlaceTypeBookStore", "__Internal")]
		BookStore,

		// -(NSString *)kGMSPlaceTypeBowlingAlleyExported;
		[Field ("kGMSPlaceTypeBowlingAlley", "__Internal")]
		BowlingAlley,

		// -(NSString *)kGMSPlaceTypeBusStationExported;
		[Field ("kGMSPlaceTypeBusStation", "__Internal")]
		BusStation,

		// -(NSString *)kGMSPlaceTypeCafeExported;
		[Field ("kGMSPlaceTypeCafe", "__Internal")]
		Cafe,

		// -(NSString *)kGMSPlaceTypeCampgroundExported;
		[Field ("kGMSPlaceTypeCampground", "__Internal")]
		Campground,

		// -(NSString *)kGMSPlaceTypeCarDealerExported;
		[Field ("kGMSPlaceTypeCarDealer", "__Internal")]
		CarDealer,

		// -(NSString *)kGMSPlaceTypeCarRentalExported;
		[Field ("kGMSPlaceTypeCarRental", "__Internal")]
		CarRental,

		// -(NSString *)kGMSPlaceTypeCarRepairExported;
		[Field ("kGMSPlaceTypeCarRepair", "__Internal")]
		CarRepair,

		// -(NSString *)kGMSPlaceTypeCarWashExported;
		[Field ("kGMSPlaceTypeCarWash", "__Internal")]
		CarWash,

		// -(NSString *)kGMSPlaceTypeCasinoExported;
		[Field ("kGMSPlaceTypeCasino", "__Internal")]
		Casino,

		// -(NSString *)kGMSPlaceTypeCemeteryExported;
		[Field ("kGMSPlaceTypeCemetery", "__Internal")]
		Cemetery,

		// -(NSString *)kGMSPlaceTypeChurchExported;
		[Field ("kGMSPlaceTypeChurch", "__Internal")]
		Church,

		// -(NSString *)kGMSPlaceTypeCityHallExported;
		[Field ("kGMSPlaceTypeCityHall", "__Internal")]
		CityHall,

		// -(NSString *)kGMSPlaceTypeClothingStoreExported;
		[Field ("kGMSPlaceTypeClothingStore", "__Internal")]
		ClothingStore,

		// -(NSString *)kGMSPlaceTypeColloquialAreaExported;
		[Field ("kGMSPlaceTypeColloquialArea", "__Internal")]
		ColloquialArea,

		// -(NSString *)kGMSPlaceTypeConvenienceStoreExported;
		[Field ("kGMSPlaceTypeConvenienceStore", "__Internal")]
		ConvenienceStore,

		// -(NSString *)kGMSPlaceTypeCountryExported;
		[Field ("kGMSPlaceTypeCountry", "__Internal")]
		Country,

		// -(NSString *)kGMSPlaceTypeCourthouseExported;
		[Field ("kGMSPlaceTypeCourthouse", "__Internal")]
		Courthouse,

		// -(NSString *)kGMSPlaceTypeDentistExported;
		[Field ("kGMSPlaceTypeDentist", "__Internal")]
		Dentist,

		// -(NSString *)kGMSPlaceTypeDepartmentStoreExported;
		[Field ("kGMSPlaceTypeDepartmentStore", "__Internal")]
		DepartmentStore,

		// -(NSString *)kGMSPlaceTypeDoctorExported;
		[Field ("kGMSPlaceTypeDoctor", "__Internal")]
		Doctor,

		// -(NSString *)kGMSPlaceTypeElectricianExported;
		[Field ("kGMSPlaceTypeElectrician", "__Internal")]
		Electrician,

		// -(NSString *)kGMSPlaceTypeElectronicsStoreExported;
		[Field ("kGMSPlaceTypeElectronicsStore", "__Internal")]
		ElectronicsStore,

		// -(NSString *)kGMSPlaceTypeEmbassyExported;
		[Field ("kGMSPlaceTypeEmbassy", "__Internal")]
		Embassy,

		// -(NSString *)kGMSPlaceTypeEstablishmentExported;
		[Field ("kGMSPlaceTypeEstablishment", "__Internal")]
		Establishment,

		// -(NSString *)kGMSPlaceTypeFinanceExported;
		[Field ("kGMSPlaceTypeFinance", "__Internal")]
		Finance,

		// -(NSString *)kGMSPlaceTypeFireStationExported;
		[Field ("kGMSPlaceTypeFireStation", "__Internal")]
		FireStation,

		// -(NSString *)kGMSPlaceTypeFloorExported;
		[Field ("kGMSPlaceTypeFloor", "__Internal")]
		Floor,

		// -(NSString *)kGMSPlaceTypeFloristExported;
		[Field ("kGMSPlaceTypeFlorist", "__Internal")]
		Florist,

		// -(NSString *)kGMSPlaceTypeFoodExported;
		[Field ("kGMSPlaceTypeFood", "__Internal")]
		Food,

		// -(NSString *)kGMSPlaceTypeFuneralHomeExported;
		[Field ("kGMSPlaceTypeFuneralHome", "__Internal")]
		FuneralHome,

		// -(NSString *)kGMSPlaceTypeFurnitureStoreExported;
		[Field ("kGMSPlaceTypeFurnitureStore", "__Internal")]
		FurnitureStore,

		// -(NSString *)kGMSPlaceTypeGasStationExported;
		[Field ("kGMSPlaceTypeGasStation", "__Internal")]
		GasStation,

		// -(NSString *)kGMSPlaceTypeGeneralContractorExported;
		[Field ("kGMSPlaceTypeGeneralContractor", "__Internal")]
		GeneralContractor,

		// -(NSString *)kGMSPlaceTypeGeocodeExported;
		[Field ("kGMSPlaceTypeGeocode", "__Internal")]
		Geocode,

		// -(NSString *)kGMSPlaceTypeGroceryOrSupermarketExported;
		[Field ("kGMSPlaceTypeGroceryOrSupermarket", "__Internal")]
		GroceryOrSupermarket,

		// -(NSString *)kGMSPlaceTypeGymExported;
		[Field ("kGMSPlaceTypeGym", "__Internal")]
		Gym,

		// -(NSString *)kGMSPlaceTypeHairCareExported;
		[Field ("kGMSPlaceTypeHairCare", "__Internal")]
		HairCare,

		// -(NSString *)kGMSPlaceTypeHardwareStoreExported;
		[Field ("kGMSPlaceTypeHardwareStore", "__Internal")]
		HardwareStore,

		// -(NSString *)kGMSPlaceTypeHealthExported;
		[Field ("kGMSPlaceTypeHealth", "__Internal")]
		Health,

		// -(NSString *)kGMSPlaceTypeHinduTempleExported;
		[Field ("kGMSPlaceTypeHinduTemple", "__Internal")]
		HinduTemple,

		// -(NSString *)kGMSPlaceTypeHomeGoodsStoreExported;
		[Field ("kGMSPlaceTypeHomeGoodsStore", "__Internal")]
		HomeGoodsStore,

		// -(NSString *)kGMSPlaceTypeHospitalExported;
		[Field ("kGMSPlaceTypeHospital", "__Internal")]
		Hospital,

		// -(NSString *)kGMSPlaceTypeInsuranceAgencyExported;
		[Field ("kGMSPlaceTypeInsuranceAgency", "__Internal")]
		InsuranceAgency,

		// -(NSString *)kGMSPlaceTypeIntersectionExported;
		[Field ("kGMSPlaceTypeIntersection", "__Internal")]
		Intersection,

		// -(NSString *)kGMSPlaceTypeJewelryStoreExported;
		[Field ("kGMSPlaceTypeJewelryStore", "__Internal")]
		JewelryStore,

		// -(NSString *)kGMSPlaceTypeLaundryExported;
		[Field ("kGMSPlaceTypeLaundry", "__Internal")]
		Laundry,

		// -(NSString *)kGMSPlaceTypeLawyerExported;
		[Field ("kGMSPlaceTypeLawyer", "__Internal")]
		Lawyer,

		// -(NSString *)kGMSPlaceTypeLibraryExported;
		[Field ("kGMSPlaceTypeLibrary", "__Internal")]
		Library,

		// -(NSString *)kGMSPlaceTypeLiquorStoreExported;
		[Field ("kGMSPlaceTypeLiquorStore", "__Internal")]
		LiquorStore,

		// -(NSString *)kGMSPlaceTypeLocalGovernmentOfficeExported;
		[Field ("kGMSPlaceTypeLocalGovernmentOffice", "__Internal")]
		LocalGovernmentOffice,

		// -(NSString *)kGMSPlaceTypeLocalityExported;
		[Field ("kGMSPlaceTypeLocality", "__Internal")]
		Locality,

		// -(NSString *)kGMSPlaceTypeLocksmithExported;
		[Field ("kGMSPlaceTypeLocksmith", "__Internal")]
		Locksmith,

		// -(NSString *)kGMSPlaceTypeLodgingExported;
		[Field ("kGMSPlaceTypeLodging", "__Internal")]
		Lodging,

		// -(NSString *)kGMSPlaceTypeMealDeliveryExported;
		[Field ("kGMSPlaceTypeMealDelivery", "__Internal")]
		MealDelivery,

		// -(NSString *)kGMSPlaceTypeMealTakeawayExported;
		[Field ("kGMSPlaceTypeMealTakeaway", "__Internal")]
		MealTakeaway,

		// -(NSString *)kGMSPlaceTypeMosqueExported;
		[Field ("kGMSPlaceTypeMosque", "__Internal")]
		Mosque,

		// -(NSString *)kGMSPlaceTypeMovieRentalExported;
		[Field ("kGMSPlaceTypeMovieRental", "__Internal")]
		MovieRental,

		// -(NSString *)kGMSPlaceTypeMovieTheaterExported;
		[Field ("kGMSPlaceTypeMovieTheater", "__Internal")]
		MovieTheater,

		// -(NSString *)kGMSPlaceTypeMovingCompanyExported;
		[Field ("kGMSPlaceTypeMovingCompany", "__Internal")]
		MovingCompany,

		// -(NSString *)kGMSPlaceTypeMuseumExported;
		[Field ("kGMSPlaceTypeMuseum", "__Internal")]
		Museum,

		// -(NSString *)kGMSPlaceTypeNaturalFeatureExported;
		[Field ("kGMSPlaceTypeNaturalFeature", "__Internal")]
		NaturalFeature,

		// -(NSString *)kGMSPlaceTypeNeighborhoodExported;
		[Field ("kGMSPlaceTypeNeighborhood", "__Internal")]
		Neighborhood,

		// -(NSString *)kGMSPlaceTypeNightClubExported;
		[Field ("kGMSPlaceTypeNightClub", "__Internal")]
		NightClub,

		// -(NSString *)kGMSPlaceTypePainterExported;
		[Field ("kGMSPlaceTypePainter", "__Internal")]
		Painter,

		// -(NSString *)kGMSPlaceTypeParkExported;
		[Field ("kGMSPlaceTypePark", "__Internal")]
		Park,

		// -(NSString *)kGMSPlaceTypeParkingExported;
		[Field ("kGMSPlaceTypeParking", "__Internal")]
		Parking,

		// -(NSString *)kGMSPlaceTypePetStoreExported;
		[Field ("kGMSPlaceTypePetStore", "__Internal")]
		PetStore,

		// -(NSString *)kGMSPlaceTypePharmacyExported;
		[Field ("kGMSPlaceTypePharmacy", "__Internal")]
		Pharmacy,

		// -(NSString *)kGMSPlaceTypePhysiotherapistExported;
		[Field ("kGMSPlaceTypePhysiotherapist", "__Internal")]
		Physiotherapist,

		// -(NSString *)kGMSPlaceTypePlaceOfWorshipExported;
		[Field ("kGMSPlaceTypePlaceOfWorship", "__Internal")]
		PlaceOfWorship,

		// -(NSString *)kGMSPlaceTypePlumberExported;
		[Field ("kGMSPlaceTypePlumber", "__Internal")]
		Plumber,

		// -(NSString *)kGMSPlaceTypePointOfInterestExported;
		[Field ("kGMSPlaceTypePointOfInterest", "__Internal")]
		PointOfInterest,

		// -(NSString *)kGMSPlaceTypePoliceExported;
		[Field ("kGMSPlaceTypePolice", "__Internal")]
		Police,

		// -(NSString *)kGMSPlaceTypePoliticalExported;
		[Field ("kGMSPlaceTypePolitical", "__Internal")]
		Political,

		// -(NSString *)kGMSPlaceTypePostBoxExported;
		[Field ("kGMSPlaceTypePostBox", "__Internal")]
		PostBox,

		// -(NSString *)kGMSPlaceTypePostOfficeExported;
		[Field ("kGMSPlaceTypePostOffice", "__Internal")]
		PostOffice,

		// -(NSString *)kGMSPlaceTypePostalCodeExported;
		[Field ("kGMSPlaceTypePostalCode", "__Internal")]
		PostalCode,

		// -(NSString *)kGMSPlaceTypePostalCodePrefixExported;
		[Field ("kGMSPlaceTypePostalCodePrefix", "__Internal")]
		PostalCodePrefix,

		// -(NSString *)kGMSPlaceTypePostalTownExported;
		[Field ("kGMSPlaceTypePostalTown", "__Internal")]
		PostalTown,

		// -(NSString *)kGMSPlaceTypePremiseExported;
		[Field ("kGMSPlaceTypePremise", "__Internal")]
		Premise,

		// -(NSString *)kGMSPlaceTypeRealEstateAgencyExported;
		[Field ("kGMSPlaceTypeRealEstateAgency", "__Internal")]
		RealEstateAgency,

		// -(NSString *)kGMSPlaceTypeRestaurantExported;
		[Field ("kGMSPlaceTypeRestaurant", "__Internal")]
		Restaurant,

		// -(NSString *)kGMSPlaceTypeRoofingContractorExported;
		[Field ("kGMSPlaceTypeRoofingContractor", "__Internal")]
		RoofingContractor,

		// -(NSString *)kGMSPlaceTypeRoomExported;
		[Field ("kGMSPlaceTypeRoom", "__Internal")]
		Room,

		// -(NSString *)kGMSPlaceTypeRouteExported;
		[Field ("kGMSPlaceTypeRoute", "__Internal")]
		Route,

		// -(NSString *)kGMSPlaceTypeRvParkExported;
		[Field ("kGMSPlaceTypeRvPark", "__Internal")]
		RvPark,

		// -(NSString *)kGMSPlaceTypeSchoolExported;
		[Field ("kGMSPlaceTypeSchool", "__Internal")]
		School,

		// -(NSString *)kGMSPlaceTypeShoeStoreExported;
		[Field ("kGMSPlaceTypeShoeStore", "__Internal")]
		ShoeStore,

		// -(NSString *)kGMSPlaceTypeShoppingMallExported;
		[Field ("kGMSPlaceTypeShoppingMall", "__Internal")]
		ShoppingMall,

		// -(NSString *)kGMSPlaceTypeSpaExported;
		[Field ("kGMSPlaceTypeSpa", "__Internal")]
		Spa,

		// -(NSString *)kGMSPlaceTypeStadiumExported;
		[Field ("kGMSPlaceTypeStadium", "__Internal")]
		Stadium,

		// -(NSString *)kGMSPlaceTypeStorageExported;
		[Field ("kGMSPlaceTypeStorage", "__Internal")]
		Storage,

		// -(NSString *)kGMSPlaceTypeStoreExported;
		[Field ("kGMSPlaceTypeStore", "__Internal")]
		Store,

		// -(NSString *)kGMSPlaceTypeStreetAddressExported;
		[Field ("kGMSPlaceTypeStreetAddress", "__Internal")]
		StreetAddress,

		// -(NSString *)kGMSPlaceTypeSublocalityExported;
		[Field ("kGMSPlaceTypeSublocality", "__Internal")]
		Sublocality,

		// -(NSString *)kGMSPlaceTypeSublocalityLevel1Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel1", "__Internal")]
		SublocalityLevel1,

		// -(NSString *)kGMSPlaceTypeSublocalityLevel2Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel2", "__Internal")]
		SublocalityLevel2,

		// -(NSString *)kGMSPlaceTypeSublocalityLevel3Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel3", "__Internal")]
		SublocalityLevel3,

		// -(NSString *)kGMSPlaceTypeSublocalityLevel4Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel4", "__Internal")]
		SublocalityLevel4,

		// -(NSString *)kGMSPlaceTypeSublocalityLevel5Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel5", "__Internal")]
		SublocalityLevel5,

		// -(NSString *)kGMSPlaceTypeSubpremiseExported;
		[Field ("kGMSPlaceTypeSubpremise", "__Internal")]
		Subpremise,

		// -(NSString *)kGMSPlaceTypeSubwayStationExported;
		[Field ("kGMSPlaceTypeSubwayStation", "__Internal")]
		SubwayStation,

		// -(NSString *)kGMSPlaceTypeSynagogueExported;
		[Field ("kGMSPlaceTypeSynagogue", "__Internal")]
		Synagogue,

		// -(NSString *)kGMSPlaceTypeTaxiStandExported;
		[Field ("kGMSPlaceTypeTaxiStand", "__Internal")]
		TaxiStand,

		// -(NSString *)kGMSPlaceTypeTrainStationExported;
		[Field ("kGMSPlaceTypeTrainStation", "__Internal")]
		TrainStation,

		// -(NSString *)kGMSPlaceTypeTransitStationExported;
		[Field ("kGMSPlaceTypeTransitStation", "__Internal")]
		TransitStation,

		// -(NSString *)kGMSPlaceTypeTravelAgencyExported;
		[Field ("kGMSPlaceTypeTravelAgency", "__Internal")]
		TravelAgency,

		// -(NSString *)kGMSPlaceTypeUniversityExported;
		[Field ("kGMSPlaceTypeUniversity", "__Internal")]
		University,

		// -(NSString *)kGMSPlaceTypeVeterinaryCareExported;
		[Field ("kGMSPlaceTypeVeterinaryCare", "__Internal")]
		VeterinaryCare,

		// -(NSString *)kGMSPlaceTypeZooExported;
		[Field ("kGMSPlaceTypeZoo", "__Internal")]
		Zoo
	}
}

namespace Google.Places.Picker {
	[Native]
	public enum PlacePickerErrorCode : long {
		UnknownError = -1,
		InternalError = -2,
		InvalidConfig = -3,
		OverlappingCalls = -4
	}
}
