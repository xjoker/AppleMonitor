using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AppleMonitor.Model
{
    public class QueryInfoModel
    {
        [JsonProperty("head")] public Head Head { get; set; }

        [JsonProperty("body")] public Body Body { get; set; }
    }

    public class Body
    {
        [JsonProperty("noSimilarModelsText")] public string NoSimilarModelsText { get; set; }

        [JsonProperty("availableStoresText")] public string AvailableStoresText { get; set; }

        [JsonProperty("availableStoreText")] public string AvailableStoreText { get; set; }

        [JsonProperty("PickupMessage")] public PickupMessage PickupMessage { get; set; }

        [JsonProperty("content")] public Content Content { get; set; }
    }

    public class Content
    {
        [JsonProperty("PickupMessage")] public PickupMessage PickupMessage { get; set; }
    }

    public class PickupMessage
    {
        [JsonProperty("stores")] public List<Store> Stores { get; set; }

        [JsonProperty("overlayInitiatedFromWarmStart")]
        public bool OverlayInitiatedFromWarmStart { get; set; }

        [JsonProperty("viewMoreHoursLinkText")]
        public string ViewMoreHoursLinkText { get; set; }

        [JsonProperty("storesCount")] public string StoresCount { get; set; }

        [JsonProperty("little")] public bool Little { get; set; }

        [JsonProperty("location")] public string Location { get; set; }

        [JsonProperty("notAvailableNearby")] public string NotAvailableNearby { get; set; }

        [JsonProperty("notAvailableNearOneStore")]
        public string NotAvailableNearOneStore { get; set; }

        [JsonProperty("warmDudeWithAPU")] public bool WarmDudeWithApu { get; set; }

        [JsonProperty("viewMoreHoursVoText")] public string ViewMoreHoursVoText { get; set; }

        [JsonProperty("availability")] public Availability Availability { get; set; }

        [JsonProperty("viewDetailsText")] public string ViewDetailsText { get; set; }

        [JsonProperty("recommendedProducts")] public string[] RecommendedProducts { get; set; }
    }

    public class Availability
    {
        [JsonProperty("isComingSoon")] public bool IsComingSoon { get; set; }
    }

    public class Store
    {
        [JsonProperty("storeEmail")] public string StoreEmail { get; set; }

        [JsonProperty("storeName")] public string StoreName { get; set; }

        [JsonProperty("reservationUrl")] public Uri ReservationUrl { get; set; }

        [JsonProperty("makeReservationUrl")] public Uri MakeReservationUrl { get; set; }

        [JsonProperty("state")] public string State { get; set; }

        [JsonProperty("storeImageUrl")] public Uri StoreImageUrl { get; set; }

        [JsonProperty("country")] public string Country { get; set; }

        [JsonProperty("city")] public string City { get; set; }

        [JsonProperty("storeNumber")] public string StoreNumber { get; set; }

        [JsonProperty("partsAvailability")]
        public Dictionary<string, AvailabilityProduct> PartsAvailability { get; set; }

        [JsonProperty("phoneNumber")] public string PhoneNumber { get; set; }

        [JsonProperty("pickupTypeAvailabilityText")]
        public string PickupTypeAvailabilityText { get; set; }

        [JsonProperty("address")] public StoreAddress Address { get; set; }

        [JsonProperty("hoursUrl")] public Uri HoursUrl { get; set; }

        [JsonProperty("storeHours")] public StoreHours StoreHours { get; set; }

        [JsonProperty("specialHours")] public SpecialHours SpecialHours { get; set; }

        [JsonProperty("storelatitude")] public double Storelatitude { get; set; }

        [JsonProperty("storelongitude")] public double Storelongitude { get; set; }

        [JsonProperty("storedistance")] public double Storedistance { get; set; }

        [JsonProperty("storeDistanceWithUnit")]
        public string StoreDistanceWithUnit { get; set; }

        [JsonProperty("storeDistanceVoText")] public string StoreDistanceVoText { get; set; }

        [JsonProperty("retailStore")] public RetailStore RetailStore { get; set; }

        [JsonProperty("storelistnumber")] public long Storelistnumber { get; set; }

        [JsonProperty("storeListNumber")] public long StoreListNumber { get; set; }

        [JsonProperty("pickupOptionsDetails")] public PickupOptionsDetails PickupOptionsDetails { get; set; }

        [JsonProperty("rank")] public long Rank { get; set; }
    }

    public class StoreAddress
    {
        [JsonProperty("address")] public string Address { get; set; }

        [JsonProperty("address3")] public string Address3 { get; set; }

        [JsonProperty("address2")] public string Address2 { get; set; }

        [JsonProperty("postalCode")] public string PostalCode { get; set; }
    }

    public class PartsAvailability
    {
        [JsonProperty("MLT83CH/A", NullValueHandling = NullValueHandling.Ignore)]
        public AvailabilityProduct Mlt83ChA { get; set; }

        [JsonProperty("MLT63CH/A", NullValueHandling = NullValueHandling.Ignore)]
        public AvailabilityProduct Mlt63ChA { get; set; }

        [JsonProperty("MLT73CH/A", NullValueHandling = NullValueHandling.Ignore)]
        public AvailabilityProduct Mlt73ChA { get; set; }
    }

    public class AvailabilityProduct
    {
        [JsonProperty("storePickEligible")] public bool StorePickEligible { get; set; }

        [JsonProperty("storeSearchEnabled")] public bool StoreSearchEnabled { get; set; }

        [JsonProperty("storeSelectionEnabled")]
        public bool StoreSelectionEnabled { get; set; }

        [JsonProperty("storePickupQuote")] public string StorePickupQuote { get; set; }

        [JsonProperty("storePickupQuote2_0")] public string StorePickupQuote20 { get; set; }

        [JsonProperty("pickupSearchQuote")] public string PickupSearchQuote { get; set; }

        [JsonProperty("storePickupLabel")] public string StorePickupLabel { get; set; }

        [JsonProperty("partNumber")] public string PartNumber { get; set; }

        [JsonProperty("purchaseOption")] public string PurchaseOption { get; set; }

        [JsonProperty("ctoOptions")] public string CtoOptions { get; set; }

        [JsonProperty("storePickupLinkText")] public string StorePickupLinkText { get; set; }

        [JsonProperty("storePickupProductTitle")]
        public string StorePickupProductTitle { get; set; }

        [JsonProperty("pickupDisplay")] public string PickupDisplay { get; set; }

        [JsonProperty("pickupType")] public string PickupType { get; set; }

        [JsonProperty("messageTypes")] public MessageTypes MessageTypes { get; set; }
    }

    public class MessageTypes
    {
        [JsonProperty("regular")] public Regular Regular { get; set; }
    }

    public class Regular
    {
        [JsonProperty("storeSearchEnabled")] public bool StoreSearchEnabled { get; set; }

        [JsonProperty("storePickupLabel")] public string StorePickupLabel { get; set; }

        [JsonProperty("storeSelectionEnabled")]
        public bool StoreSelectionEnabled { get; set; }

        [JsonProperty("storePickupQuote")] public string StorePickupQuote { get; set; }

        [JsonProperty("storePickupQuote2_0")] public string StorePickupQuote20 { get; set; }

        [JsonProperty("storePickupLinkText")] public string StorePickupLinkText { get; set; }

        [JsonProperty("storePickupProductTitle")]
        public string StorePickupProductTitle { get; set; }
    }

    public class PickupOptionsDetails
    {
        [JsonProperty("whatToExpectAtPickup")] public string WhatToExpectAtPickup { get; set; }

        [JsonProperty("comparePickupOptionsLink")]
        public string ComparePickupOptionsLink { get; set; }

        [JsonProperty("pickupOptions")] public PickupOption[] PickupOptions { get; set; }
    }

    public class PickupOption
    {
        [JsonProperty("pickupOptionTitle")] public string PickupOptionTitle { get; set; }

        [JsonProperty("pickupOptionDescription")]
        public string PickupOptionDescription { get; set; }

        [JsonProperty("index")] public long Index { get; set; }
    }

    public class RetailStore
    {
        [JsonProperty("storeNumber")] public string StoreNumber { get; set; }

        [JsonProperty("storeUniqueId")] public string StoreUniqueId { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("storeTypeKey")] public string StoreTypeKey { get; set; }

        [JsonProperty("storeSubTypeKey")] public string StoreSubTypeKey { get; set; }

        [JsonProperty("storeType")] public string StoreType { get; set; }

        [JsonProperty("phoneNumber")] public string PhoneNumber { get; set; }

        [JsonProperty("email")] public string Email { get; set; }

        [JsonProperty("carrierCode")] public object CarrierCode { get; set; }

        [JsonProperty("locationType")] public object LocationType { get; set; }

        [JsonProperty("latitude")] public double Latitude { get; set; }

        [JsonProperty("longitude")] public double Longitude { get; set; }

        [JsonProperty("address")] public RetailStoreAddress Address { get; set; }

        [JsonProperty("urlKey")] public object UrlKey { get; set; }

        [JsonProperty("directionsUrl")] public object DirectionsUrl { get; set; }

        [JsonProperty("storeImageUrl")] public Uri StoreImageUrl { get; set; }

        [JsonProperty("makeReservationUrl")] public Uri MakeReservationUrl { get; set; }

        [JsonProperty("hoursAndInfoUrl")] public Uri HoursAndInfoUrl { get; set; }

        [JsonProperty("storeHours")] public StoreHour[] StoreHours { get; set; }

        [JsonProperty("storeHolidays")] public StoreHoliday[] StoreHolidays { get; set; }

        [JsonProperty("secureStoreImageUrl")] public Uri SecureStoreImageUrl { get; set; }

        [JsonProperty("distance")] public double Distance { get; set; }

        [JsonProperty("distanceUnit")] public string DistanceUnit { get; set; }

        [JsonProperty("distanceWithUnit")] public string DistanceWithUnit { get; set; }

        [JsonProperty("timezone")] public string Timezone { get; set; }

        [JsonProperty("storeIsActive")] public bool StoreIsActive { get; set; }

        [JsonProperty("lastUpdated")] public long LastUpdated { get; set; }

        [JsonProperty("lastFetched")] public long LastFetched { get; set; }

        [JsonProperty("dateStamp")] public string DateStamp { get; set; }

        [JsonProperty("distanceSeparator")] public string DistanceSeparator { get; set; }

        [JsonProperty("nextAvailableDate")] public object NextAvailableDate { get; set; }

        [JsonProperty("storeHolidayLookAheadWindow")]
        public long StoreHolidayLookAheadWindow { get; set; }

        [JsonProperty("driveDistanceWithUnit")]
        public object DriveDistanceWithUnit { get; set; }

        [JsonProperty("driveDistanceInMeters")]
        public object DriveDistanceInMeters { get; set; }

        [JsonProperty("dynamicAttributes")] public Data DynamicAttributes { get; set; }

        [JsonProperty("storePickupMethodByType")]
        public StorePickupMethodByType StorePickupMethodByType { get; set; }

        [JsonProperty("storeTimings")] public object StoreTimings { get; set; }

        [JsonProperty("availableNow")] public bool AvailableNow { get; set; }
    }

    public class RetailStoreAddress
    {
        [JsonProperty("city")] public string City { get; set; }

        [JsonProperty("companyName")] public string CompanyName { get; set; }

        [JsonProperty("countryCode")] public string CountryCode { get; set; }

        [JsonProperty("county")] public object County { get; set; }

        [JsonProperty("district")] public string District { get; set; }

        [JsonProperty("geoCode")] public object GeoCode { get; set; }

        [JsonProperty("label")] public object Label { get; set; }

        [JsonProperty("languageCode")] public string LanguageCode { get; set; }

        [JsonProperty("mailStop")] public object MailStop { get; set; }

        [JsonProperty("postalCode")] public string PostalCode { get; set; }

        [JsonProperty("province")] public object Province { get; set; }

        [JsonProperty("state")] public string State { get; set; }

        [JsonProperty("street")] public string Street { get; set; }

        [JsonProperty("street2")] public string Street2 { get; set; }

        [JsonProperty("street3")] public object Street3 { get; set; }

        [JsonProperty("suburb")] public object Suburb { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("addrSourceType")] public object AddrSourceType { get; set; }

        [JsonProperty("outsideCityFlag")] public object OutsideCityFlag { get; set; }

        [JsonProperty("daytimePhoneAreaCode")] public object DaytimePhoneAreaCode { get; set; }

        [JsonProperty("eveningPhoneAreaCode")] public object EveningPhoneAreaCode { get; set; }

        [JsonProperty("daytimePhone")] public string DaytimePhone { get; set; }

        [JsonProperty("fullPhoneNumber")] public object FullPhoneNumber { get; set; }

        [JsonProperty("eveningPhone")] public object EveningPhone { get; set; }

        [JsonProperty("emailAddress")] public object EmailAddress { get; set; }

        [JsonProperty("firstName")] public object FirstName { get; set; }

        [JsonProperty("lastName")] public object LastName { get; set; }

        [JsonProperty("suffix")] public object Suffix { get; set; }

        [JsonProperty("lastNamePhonetic")] public object LastNamePhonetic { get; set; }

        [JsonProperty("firstNamePhonetic")] public object FirstNamePhonetic { get; set; }

        [JsonProperty("title")] public object Title { get; set; }

        [JsonProperty("businessAddress")] public bool BusinessAddress { get; set; }

        [JsonProperty("uuid")] public string Uuid { get; set; }

        [JsonProperty("mobilePhone")] public object MobilePhone { get; set; }

        [JsonProperty("mobilePhoneAreaCode")] public object MobilePhoneAreaCode { get; set; }

        [JsonProperty("cityStateZip")] public object CityStateZip { get; set; }

        [JsonProperty("daytimePhoneSelected")] public bool DaytimePhoneSelected { get; set; }

        [JsonProperty("middleName")] public object MiddleName { get; set; }

        [JsonProperty("residenceStatus")] public object ResidenceStatus { get; set; }

        [JsonProperty("moveInDate")] public object MoveInDate { get; set; }

        [JsonProperty("subscriberId")] public object SubscriberId { get; set; }

        [JsonProperty("locationType")] public object LocationType { get; set; }

        [JsonProperty("carrierCode")] public object CarrierCode { get; set; }

        [JsonProperty("metadata")] public Data Metadata { get; set; }

        [JsonProperty("verificationState")] public string VerificationState { get; set; }

        [JsonProperty("expiration")] public object Expiration { get; set; }

        [JsonProperty("markForDeletion")] public bool MarkForDeletion { get; set; }

        [JsonProperty("primaryAddress")] public bool PrimaryAddress { get; set; }

        [JsonProperty("fullEveningPhone")] public object FullEveningPhone { get; set; }

        [JsonProperty("fullDaytimePhone")] public string FullDaytimePhone { get; set; }

        [JsonProperty("correctionResult")] public object CorrectionResult { get; set; }

        [JsonProperty("twoLineAddress")] public string TwoLineAddress { get; set; }

        [JsonProperty("addressVerified")] public bool AddressVerified { get; set; }
    }

    public class Data
    {
    }

    public class StoreHoliday
    {
        [JsonProperty("date")] public string Date { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("hours")] public string Hours { get; set; }

        [JsonProperty("comments")] public string Comments { get; set; }

        [JsonProperty("closed")] public bool Closed { get; set; }
    }

    public class StoreHour
    {
        [JsonProperty("storeDays")] public string StoreDays { get; set; }

        [JsonProperty("voStoreDays")] public object VoStoreDays { get; set; }

        [JsonProperty("storeTimings")] public string StoreTimings { get; set; }
    }

    public class StorePickupMethodByType
    {
        [JsonProperty("INSTORE")] public Instore Instore { get; set; }
    }

    public class Instore
    {
        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("services")] public string[] Services { get; set; }

        [JsonProperty("typeCoordinate")] public TypeCoordinate TypeCoordinate { get; set; }

        [JsonProperty("typeDirection")] public TypeDirection TypeDirection { get; set; }

        [JsonProperty("typeMeetupLocation")] public TypeMeetupLocation TypeMeetupLocation { get; set; }
    }

    public class TypeCoordinate
    {
        [JsonProperty("lat")] public double Lat { get; set; }

        [JsonProperty("lon")] public double Lon { get; set; }
    }

    public class TypeDirection
    {
        [JsonProperty("directionByLocale")] public object DirectionByLocale { get; set; }
    }

    public class TypeMeetupLocation
    {
        [JsonProperty("meetingLocationByLocale")]
        public object MeetingLocationByLocale { get; set; }
    }

    public class SpecialHours
    {
        [JsonProperty("specialHoursText")] public string SpecialHoursText { get; set; }

        [JsonProperty("bopisPickupDays")] public string BopisPickupDays { get; set; }

        [JsonProperty("bopisPickupHours")] public string BopisPickupHours { get; set; }

        [JsonProperty("specialHoursData")] public SpecialHoursDatum[] SpecialHoursData { get; set; }

        [JsonProperty("viewAllSpecialHours")] public bool ViewAllSpecialHours { get; set; }
    }

    public class SpecialHoursDatum
    {
        [JsonProperty("specialDays")] public string SpecialDays { get; set; }

        [JsonProperty("specialTimings")] public string SpecialTimings { get; set; }
    }

    public class StoreHours
    {
        [JsonProperty("storeHoursText")] public string StoreHoursText { get; set; }

        [JsonProperty("bopisPickupDays")] public string BopisPickupDays { get; set; }

        [JsonProperty("bopisPickupHours")] public string BopisPickupHours { get; set; }

        [JsonProperty("hours")] public Hour[] Hours { get; set; }
    }

    public class Hour
    {
        [JsonProperty("storeTimings")] public string StoreTimings { get; set; }

        [JsonProperty("storeDays")] public string StoreDays { get; set; }
    }

    public class Head
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("data")] public Data Data { get; set; }
    }
}