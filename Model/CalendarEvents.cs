namespace HorizonHub.Model {
    public class AdditionalData {
    }

    public class BackingStore {

        [JsonPropertyName("InitializationCompleted")]
        public bool InitializationCompleted { get; set; }

        [JsonPropertyName("ReturnOnlyChangedValues")]
        public bool ReturnOnlyChangedValues { get; set; }
    }

    public class Status {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }

        [JsonPropertyName("Response")]
        public int Response { get; set; }

        [JsonPropertyName("Time")]
        public DateTime Time { get; set; }
    }

    public class EmailAddress {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }
    }

    public class Attendee {

        [JsonPropertyName("ProposedNewTime")]
        public object ProposedNewTime { get; set; }

        [JsonPropertyName("Status")]
        public Status Status { get; set; }

        [JsonPropertyName("Type")]
        public int Type { get; set; }

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("EmailAddress")]
        public EmailAddress EmailAddress { get; set; }

        [JsonPropertyName("OdataType")]
        public string OdataType { get; set; }
    }

    public class Body {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("Content")]
        public string Content { get; set; }

        [JsonPropertyName("ContentType")]
        public int ContentType { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }
    }

    public class End {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("DateTime")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }

        [JsonPropertyName("TimeZone")]
        public string TimeZone { get; set; }
    }

    public class Address {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("City")]
        public object City { get; set; }

        [JsonPropertyName("CountryOrRegion")]
        public object CountryOrRegion { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }

        [JsonPropertyName("PostalCode")]
        public object PostalCode { get; set; }

        [JsonPropertyName("State")]
        public object State { get; set; }

        [JsonPropertyName("Street")]
        public object Street { get; set; }
    }

    public class Coordinates {

        [JsonPropertyName("Accuracy")]
        public object Accuracy { get; set; }

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("Altitude")]
        public object Altitude { get; set; }

        [JsonPropertyName("AltitudeAccuracy")]
        public object AltitudeAccuracy { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("Latitude")]
        public object Latitude { get; set; }

        [JsonPropertyName("Longitude")]
        public object Longitude { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }
    }

    public class Location {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("Address")]
        public Address Address { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("Coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonPropertyName("DisplayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("LocationEmailAddress")]
        public object LocationEmailAddress { get; set; }

        [JsonPropertyName("LocationType")]
        public int LocationType { get; set; }

        [JsonPropertyName("LocationUri")]
        public object LocationUri { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }

        [JsonPropertyName("UniqueId")]
        public string UniqueId { get; set; }

        [JsonPropertyName("UniqueIdType")]
        public int UniqueIdType { get; set; }
    }

    public class OnlineMeeting {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("ConferenceId")]
        public object ConferenceId { get; set; }

        [JsonPropertyName("JoinUrl")]
        public string JoinUrl { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }

        [JsonPropertyName("Phones")]
        public object Phones { get; set; }

        [JsonPropertyName("QuickDial")]
        public object QuickDial { get; set; }

        [JsonPropertyName("TollFreeNumbers")]
        public object TollFreeNumbers { get; set; }

        [JsonPropertyName("TollNumber")]
        public object TollNumber { get; set; }
    }

    public class Organizer {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("EmailAddress")]
        public EmailAddress EmailAddress { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }
    }

    public class Pattern {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("DayOfMonth")]
        public int DayOfMonth { get; set; }

        [JsonPropertyName("DaysOfWeek")]
        public IList<int> DaysOfWeek { get; set; }

        [JsonPropertyName("FirstDayOfWeek")]
        public int FirstDayOfWeek { get; set; }

        [JsonPropertyName("Index")]
        public int Index { get; set; }

        [JsonPropertyName("Interval")]
        public int Interval { get; set; }

        [JsonPropertyName("Month")]
        public int Month { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }

        [JsonPropertyName("Type")]
        public int Type { get; set; }
    }

    public class EndDate {

        [JsonPropertyName("DateTime")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("Year")]
        public int Year { get; set; }

        [JsonPropertyName("Month")]
        public int Month { get; set; }

        [JsonPropertyName("Day")]
        public int Day { get; set; }
    }

    public class StartDate {

        [JsonPropertyName("DateTime")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("Year")]
        public int Year { get; set; }

        [JsonPropertyName("Month")]
        public int Month { get; set; }

        [JsonPropertyName("Day")]
        public int Day { get; set; }
    }

    public class Range {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("EndDate")]
        public EndDate EndDate { get; set; }

        [JsonPropertyName("NumberOfOccurrences")]
        public int NumberOfOccurrences { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }

        [JsonPropertyName("RecurrenceTimeZone")]
        public string RecurrenceTimeZone { get; set; }

        [JsonPropertyName("StartDate")]
        public StartDate StartDate { get; set; }

        [JsonPropertyName("Type")]
        public int Type { get; set; }
    }

    public class Recurrence {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }

        [JsonPropertyName("Pattern")]
        public Pattern Pattern { get; set; }

        [JsonPropertyName("Range")]
        public Range Range { get; set; }
    }

    public class ResponseStatus {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }

        [JsonPropertyName("Response")]
        public int Response { get; set; }

        [JsonPropertyName("Time")]
        public DateTime Time { get; set; }
    }

    public class Start {

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("DateTime")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("OdataType")]
        public object OdataType { get; set; }

        [JsonPropertyName("TimeZone")]
        public string TimeZone { get; set; }
    }

    public class Value {

        [JsonPropertyName("AllowNewTimeProposals")]
        public bool AllowNewTimeProposals { get; set; }

        [JsonPropertyName("Attachments")]
        public object Attachments { get; set; }

        [JsonPropertyName("Attendees")]
        public IList<Attendee> Attendees { get; set; }

        [JsonPropertyName("Body")]
        public Body Body { get; set; }

        [JsonPropertyName("BodyPreview")]
        public string BodyPreview { get; set; }

        [JsonPropertyName("Calendar")]
        public object Calendar { get; set; }

        [JsonPropertyName("End")]
        public End End { get; set; }

        [JsonPropertyName("Extensions")]
        public object Extensions { get; set; }

        [JsonPropertyName("HasAttachments")]
        public bool HasAttachments { get; set; }

        [JsonPropertyName("HideAttendees")]
        public bool HideAttendees { get; set; }

        [JsonPropertyName("ICalUId")]
        public string ICalUId { get; set; }

        [JsonPropertyName("Importance")]
        public int Importance { get; set; }

        [JsonPropertyName("Instances")]
        public object Instances { get; set; }

        [JsonPropertyName("IsAllDay")]
        public bool IsAllDay { get; set; }

        [JsonPropertyName("IsCancelled")]
        public bool IsCancelled { get; set; }

        [JsonPropertyName("IsDraft")]
        public bool IsDraft { get; set; }

        [JsonPropertyName("IsOnlineMeeting")]
        public bool IsOnlineMeeting { get; set; }

        [JsonPropertyName("IsOrganizer")]
        public bool IsOrganizer { get; set; }

        [JsonPropertyName("IsReminderOn")]
        public bool IsReminderOn { get; set; }

        [JsonPropertyName("Location")]
        public Location Location { get; set; }

        [JsonPropertyName("Locations")]
        public IList<Location> Locations { get; set; }

        [JsonPropertyName("MultiValueExtendedProperties")]
        public object MultiValueExtendedProperties { get; set; }

        [JsonPropertyName("OnlineMeeting")]
        public OnlineMeeting OnlineMeeting { get; set; }

        [JsonPropertyName("OnlineMeetingProvider")]
        public int OnlineMeetingProvider { get; set; }

        [JsonPropertyName("OnlineMeetingUrl")]
        public string OnlineMeetingUrl { get; set; }

        [JsonPropertyName("Organizer")]
        public Organizer Organizer { get; set; }

        [JsonPropertyName("OriginalEndTimeZone")]
        public string OriginalEndTimeZone { get; set; }

        [JsonPropertyName("OriginalStart")]
        public object OriginalStart { get; set; }

        [JsonPropertyName("OriginalStartTimeZone")]
        public string OriginalStartTimeZone { get; set; }

        [JsonPropertyName("Recurrence")]
        public Recurrence Recurrence { get; set; }

        [JsonPropertyName("ReminderMinutesBeforeStart")]
        public int ReminderMinutesBeforeStart { get; set; }

        [JsonPropertyName("ResponseRequested")]
        public bool ResponseRequested { get; set; }

        [JsonPropertyName("ResponseStatus")]
        public ResponseStatus ResponseStatus { get; set; }

        [JsonPropertyName("Sensitivity")]
        public int Sensitivity { get; set; }

        [JsonPropertyName("SeriesMasterId")]
        public object SeriesMasterId { get; set; }

        [JsonPropertyName("ShowAs")]
        public int ShowAs { get; set; }

        [JsonPropertyName("SingleValueExtendedProperties")]
        public object SingleValueExtendedProperties { get; set; }

        [JsonPropertyName("Start")]
        public Start Start { get; set; }

        [JsonPropertyName("Subject")]
        public string Subject { get; set; }

        [JsonPropertyName("TransactionId")]
        public string TransactionId { get; set; }

        [JsonPropertyName("Type")]
        public int Type { get; set; }

        [JsonPropertyName("WebLink")]
        public string WebLink { get; set; }

        [JsonPropertyName("Categories")]
        public IList<object> Categories { get; set; }

        [JsonPropertyName("ChangeKey")]
        public string ChangeKey { get; set; }

        [JsonPropertyName("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonPropertyName("LastModifiedDateTime")]
        public DateTime LastModifiedDateTime { get; set; }

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("OdataType")]
        public string OdataType { get; set; }
    }

    public class CalendarEvents {

        [JsonPropertyName("Value")]
        public IList<Value> Value { get; set; }

        [JsonPropertyName("AdditionalData")]
        public AdditionalData AdditionalData { get; set; }

        [JsonPropertyName("BackingStore")]
        public BackingStore BackingStore { get; set; }

        [JsonPropertyName("OdataCount")]
        public object OdataCount { get; set; }

        [JsonPropertyName("OdataNextLink")]
        public string OdataNextLink { get; set; }
    }
}