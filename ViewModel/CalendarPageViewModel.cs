using System.Diagnostics;
using System.Text.Json;

namespace HorizonHub.ViewModel {

    public partial class CalendarPageViewModel(GraphServiceClient graphClient) : ObservableObject {

        public ObservableCollection<CalendarEvents> CalendarEvents { get; set; } = [];

        public async Task FetchCalendarEventsAsync() {

            // Fetch calendar events from Microsoft Graph API

            var graphEventsResponse = await graphClient.Me.Events.GetAsync();

            // Convert the response to a JSON string
            string jsonString = JsonSerializer.Serialize(graphEventsResponse);

            // Now, deserialize into your CalendarEvents class
            CalendarEvents? calendarEvents = JsonSerializer.Deserialize<CalendarEvents>(jsonString);

            if(calendarEvents?.Value.Count > 0) {

                // Loop through each event and print its details
                foreach(var eventItem in calendarEvents.Value) {
                    Debug.WriteLine($"Subject: {eventItem.Subject}");
                    Debug.WriteLine($"Start: {eventItem.Start.DateTime} ({eventItem.Start.DateTime})");
                    Debug.WriteLine($"End: {eventItem.End.DateTime} ({eventItem.End.TimeZone})");
                    Debug.WriteLine($"Location: {eventItem.Location.DisplayName ?? "No Location"}");
                    Debug.WriteLine($"Organizer: {eventItem.Organizer.EmailAddress.Name} ({eventItem.Organizer.EmailAddress.Address})");
                    Debug.WriteLine($"Importance: {eventItem.Importance}");
                    Debug.WriteLine($"Reminder Minutes Before Start: {eventItem.ReminderMinutesBeforeStart}");
                    Debug.WriteLine($"Is Cancelled: {eventItem.IsCancelled}");
                    Debug.WriteLine($"Is Online Meeting: {eventItem.IsOnlineMeeting}");
                    Debug.WriteLine($"Online Meeting URL: {eventItem.OnlineMeetingUrl}");

                    Debug.WriteLine("\nAttendees:");
                    foreach(var attendee in eventItem.Attendees) {
                        Debug.WriteLine($"- {attendee.EmailAddress.Name} ({attendee.EmailAddress.Address})");
                    }

                    Debug.WriteLine(new string('-', 50)); // Separator for readability
                }
            }
            else {
                Debug.WriteLine("No calendar events found.");
            }

        }
    }
}
