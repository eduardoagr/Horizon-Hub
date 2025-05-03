namespace HorizonHub.View {

    public sealed partial class CalendarPage : Page {

        public CalendarPageViewModel CalendarPageViewModel { get; set; }

        public CalendarPage(CalendarPageViewModel calendarPageViewModel) {

            InitializeComponent();

            CalendarPageViewModel = calendarPageViewModel;

            DataContext = CalendarPageViewModel;

            Loaded += async (s, e) => {
                await CalendarPageViewModel.FetchCalendarEventsAsync();
            };
        }
    }
}
