namespace HorizonHub.ViewModel.Pages;

public partial class CalendarPageViewModel(GraphServiceClient graphClient, MicrosoftAuthHelper _authHelper)
    : ObservableObject {

    public ObservableCollection<CalendarDay> CalendarDays { get; set; } = [];

    public async Task FetchCalendarEventsAsync() {

        var accessToken = await _authHelper.GetAccessTokenAsync();
        if(string.IsNullOrEmpty(accessToken)) {
            Debug.WriteLine("Access Token retrieval failed!");
            return;
        }

        Debug.WriteLine($"Using Access Token: {accessToken}");



        // Correctly format start and end dates for Microsoft Graph API
        var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
            .ToString(Constants.isoTimeFormat);

        var endOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
            DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month), 23, 59, 59)
            .ToString(Constants.isoTimeFormat);

        // Fetch events from Microsoft Graph API
        var result = await graphClient.Me.CalendarView.GetAsync(
            (requestConfiguration) => {
                requestConfiguration.QueryParameters.StartDateTime = firstDayOfMonth;
                requestConfiguration.QueryParameters.EndDateTime = endOfMonth;
            });

        // Clear the existing calendar days
        CalendarDays.Clear();

        int daysInMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);

        // Populate `CalendarDays` with every full day of the month
        for(var day = 1; day <= daysInMonth; day++) {

            var dateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, day);
            var date = dateTime.ToString("yyyy-MM-dd"); // Store formatted date
            var longDate = dateTime.ToString("D"); // Short date format (dd/MM/yyyy)

            CalendarDays.Add(new CalendarDay(date, false,
                string.Empty, [],
                string.Empty, string.Empty,
                false, string.Empty, string.Empty, longDate));
        }

        // Process fetched events and match them with stored calendar days
        if(result?.Value != null) {

            foreach(var item in result.Value) {

                var eventTitle = item.Subject ?? "No title";
                var organizerName = item.Organizer!.EmailAddress!.Name ?? "Unknown Organizer";
                var eventDateTime = item.Start.ToDateTime().ToString("yyyy-MM-dd");
                var attendeeEmails = item.Attendees?.Select(a => a.EmailAddress?.Address).ToList();
                var joinUrl = item.OnlineMeeting?.JoinUrl;
                var location = item.Location?.DisplayName ?? "No location";
                var isOnline = item.IsOnlineMeeting.GetValueOrDefault();

                // Find the matching calendar day based on full timestamp
                var eventDay = CalendarDays.FirstOrDefault(x => x.Date == eventDateTime);

                if(eventDay is not null) {

                    eventDay.HasEvent = true;
                    eventDay.EventTitle = eventTitle;
                    eventDay.AttendeeEmails = attendeeEmails!;
                    eventDay.JoinUrl = joinUrl!;
                    eventDay.Location = location;
                    eventDay.IsOnline = isOnline;
                    eventDay.Date = eventDateTime;
                    eventDay.EventTime = item.Start.ToDateTime().ToString("T");
                    eventDay.OrganizerName = organizerName;
                }

            }
        }
    }
}
