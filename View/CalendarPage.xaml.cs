namespace HorizonHub.View {

    public sealed partial class CalendarPage : Page {

        public CalendarPageViewModel CalendarPageViewModel { get; set; }

        public CalendarPage(CalendarPageViewModel calendarPageViewModel) {

            InitializeComponent();

            CalendarPageViewModel = calendarPageViewModel;

            DataContext = CalendarPageViewModel;

            Loaded += async (s, e) => {
                await CalendarPageViewModel.FetchCalendarEventsAsync();
                Calendar.MinimumDate = DateTime.Today;
            };
        }

        private void Calendar_AppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e) {

            e.Cancel = true;
        }

        private void Calendar_ContextFlyoutOpening(object sender, SchedulerContextFlyoutOpeningEventArgs e) {

            if(e.MenuInfo.Appointment is CalendarEvent calendarEvent) {
                // Set DataContext at the MenuInfo level
                e.MenuInfo.ContextFlyout.DataContext = calendarEvent;
            }


        }
    }
}
