using Microsoft.Graph.Models;

namespace HorizonHub.ViewModel {

    public partial class CalendarPageViewModel(GraphServiceClient graphClient) : ObservableObject {

        public ObservableCollection<Event> CalendarEvents { get; set; } = [];

        [ObservableProperty]
        string hh = "dd";

        public async Task FetchCalendarEventsAsync() {

            //    var firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToString();
            //    var endOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month,
            //        DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month),
            //        23, 59, 59).ToString("yyyy-MM-ddTHH:mm:ssZ");


            //    var result = await graphClient.Me.CalendarView.GetAsync((requestConfiguration) => {
            //        requestConfiguration.QueryParameters.StartDateTime = firstDayOfMonth;
            //        requestConfiguration.QueryParameters.EndDateTime = endOfMonth;
            //    });

            //    foreach(var items in result!.Value!) {
            //        CalendarEvents.Add(items);
            //    }
            //}
        }
    }
}
