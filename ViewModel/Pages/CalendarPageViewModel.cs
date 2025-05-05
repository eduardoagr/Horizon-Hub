namespace HorizonHub.ViewModel.Pages;

public partial class CalendarPageViewModel(GraphServiceClient graphClient, MicrosoftAuthHelper _authHelper)
    : ObservableObject {


    public ObservableCollection<CalendarEvent> CalendarEvents { get; set; } = [];

    public async Task FetchCalendarEventsAsync() {

        var accessToken = await _authHelper.GetAccessTokenAsync();

        if(string.IsNullOrEmpty(accessToken)) {
            Debug.WriteLine("Access Token retrieval failed!");
            return;
        }

        Debug.WriteLine($"Using Access Token: {accessToken}");

        // Fetch events from Microsoft Graph API
        var result = await graphClient.Me.CalendarView.GetAsync(
            (requestConfiguration) => {
                requestConfiguration.QueryParameters.StartDateTime = GetDates().Item1;
                requestConfiguration.QueryParameters.EndDateTime = GetDates().Item2;
            });

        // Clear the existing calendar days
        CalendarEvents.Clear();

        // Process fetched events and match them with stored calendar days
        if(result?.Value != null) {

            foreach(var item in result.Value) {

                var organizerName = item.Organizer?.EmailAddress?.Name ?? "Unknown Organizer";
                var subject = item.Subject ?? "Untitled Event";

                var startDate = item.Start.ToDateTime();
                var endDate = item.End.ToDateTime();

                var startTime = item.Start?.ToDateTime().ToString("t") ?? "Unknown Time";
                var endTime = item.End?.ToDateTime().ToString("t") ?? "Unknown Time";

                var location = item.Location?.DisplayName ?? "No Location";

                var attendeeEmails = item.Attendees?.Select(a => a.EmailAddress?.Address ?? "Unknown Email").ToList() ?? new List<string>();

                var joinUrl = item.OnlineMeeting?.JoinUrl ?? string.Empty;

                CalendarEvents.Add(new CalendarEvent() {
                    HasEvent = true,
                    EventOrganizerName = organizerName,
                    EventTitle = subject,
                    EventStartDate = startDate,
                    EventEndDate = endDate,
                    EventStartTime = startTime,
                    EventEndTime = endTime,
                    EventLocation = location,
                    EventAttendeeEmails = attendeeEmails,
                    EventJoinUrl = joinUrl
                });
            }
        }
    }

    private static (string, string) GetDates() {

        var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
                     .ToString(Constants.isoTimeFormat);

        var endDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
            DateTime.DaysInMonth(
                DateTime.Today.Year, DateTime.Today.Month),
            23, 59, 59).ToString(Constants.isoTimeFormat);

        return (firstDayOfMonth, endDayOfMonth);
    }

    [RelayCommand]
    void CreateEvent(object obj) { }

    [RelayCommand]
    void DeleteEvent(object obj) { }

    [RelayCommand]
    void UpdateEvent(object obj) { }

    [RelayCommand]
    void EventDetails(object obj) {
    }
}
