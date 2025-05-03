namespace HorizonHub.Model {

    public partial class CalendarDay : ObservableObject {

        [ObservableProperty]
        string organizerName;

        [ObservableProperty]
        private string date;

        [ObservableProperty]
        private bool hasEvent;

        [ObservableProperty]
        private string eventTitle;

        [ObservableProperty]
        private List<string> attendeeEmails = [];

        [ObservableProperty]
        private string joinUrl;

        [ObservableProperty]
        private string location;

        [ObservableProperty]
        private bool isOnline;

        [ObservableProperty]
        private string eventTime;

        [ObservableProperty]
        private string longDate;

        public CalendarDay(string date, bool hasEvent, string eventTitle, List<string> attendeeEmails,
            string joinUrl, string location, bool isOnline, string eventTime,
            string organizerName, string longDate) {

            Date = date;
            HasEvent = hasEvent;
            EventTitle = eventTitle;
            AttendeeEmails = attendeeEmails ?? [];
            JoinUrl = joinUrl;
            Location = location;
            IsOnline = isOnline;
            EventTime = eventTime;
            this.organizerName = organizerName;
            this.longDate = longDate;
        }
    }
}