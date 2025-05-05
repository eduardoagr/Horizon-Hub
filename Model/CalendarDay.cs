namespace HorizonHub.Model {

    public partial class CalendarEvent : ObservableObject {

        [ObservableProperty]
        string eventOrganizerName;

        [ObservableProperty]
        private DateTime eventStartDate;

        [ObservableProperty]
        private DateTime eventEndDate;

        [ObservableProperty]
        private bool hasEvent;

        [ObservableProperty]
        private string eventTitle;

        [ObservableProperty]
        private List<string> eventAttendeeEmails = [];

        [ObservableProperty]
        private string eventJoinUrl;

        [ObservableProperty]
        private string eventLocation;

        [ObservableProperty]
        private bool eventIsOnline;

        [ObservableProperty]
        private string eventStartTime;

        [ObservableProperty]
        private string eventEndTime;
    }
}