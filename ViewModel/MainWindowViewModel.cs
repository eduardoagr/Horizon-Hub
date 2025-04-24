namespace HorizonHub.ViewModel {

    public partial class MainWindowViewModel : ObservableObject {

        private const string IsCompactModeEnabledKey = "IsCompactModeEnabled";
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;
        private readonly CalendarPageViewModel _calendarPageViewModel;

        public Action<bool>? isCompactMode;

        [ObservableProperty]
        bool isCompactModeEnabled;

        [ObservableProperty]
        object? currentPage;

        public MainWindowViewModel(CalendarPageViewModel calendarPageViewModel) {

            _calendarPageViewModel = calendarPageViewModel;

            if(_localSettings.Values.TryGetValue(IsCompactModeEnabledKey, out var storedValue)
                && storedValue is bool savedBool) {

                IsCompactModeEnabled = savedBool;
            }
            else {
                IsCompactModeEnabled = false; // Default value
            }

            CurrentPage = new CalendarPage(_calendarPageViewModel);
        }

        [RelayCommand]
        void Navigate(NavigationViewSelectionChangedEventArgs args) {

            if(args.SelectedItem is NavigationViewItem selectedItem && selectedItem.Tag is string pageTag) {
                CurrentPage = pageTag switch {
                    "CalendarPage" => new CalendarPage(_calendarPageViewModel),
                    "AccountPage" => new AccountPage(),
                    "AboutPage" => new AboutPage(),
                    _ => new CalendarPage(_calendarPageViewModel) // Default fallback
                };
            }
        }

        partial void OnIsCompactModeEnabledChanged(bool value) {

            isCompactMode?.Invoke(value);

            _localSettings.Values["IsCompactModeEnabled"] = value;

        }
    }
}
