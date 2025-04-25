namespace HorizonHub.ViewModel {

    public partial class CalendarPageViewModel(GraphServiceClient graphClient) : ObservableObject {

        public ObservableCollection<Microsoft.Graph.Models.Event> CalendarEvents { get; set; } = [];

        public async Task FetchCalendarEventsAsync() {

            try {
                // Fetch calendar events from Microsoft Graph API
                var graphEventsResponse = await graphClient.Me.Events.GetAsync();

                // Clear existing collection
                CalendarEvents.Clear();

                // Populate ObservableCollection with retrieved events
                foreach(var eventItem in graphEventsResponse!.Value!) {

                    CalendarEvents.Add(eventItem);
                }
            } catch(Exception ex) {
                Console.WriteLine($"Error fetching events: {ex.Message}");
            }
        }
    }
}
