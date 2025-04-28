namespace HorizonHub.ViewModel {

    public partial class MainWindowViewModel : ObservableObject {

        private const string IsCompactModeEnabledKey = "IsCompactModeEnabled";
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;
        private readonly CalendarPageViewModel _calendarPageViewModel;

        public Action<bool>? isCompactMode;

        [ObservableProperty]
        string selectedMenuItemTag;

        [ObservableProperty]
        Type? currentPageType;

        [ObservableProperty]
        bool isCompactModeEnabled;

        public MainWindowViewModel(CalendarPageViewModel calendarPageViewModel) {

            _calendarPageViewModel = calendarPageViewModel;

            if(_localSettings.Values.TryGetValue(IsCompactModeEnabledKey, out var storedValue)
                && storedValue is bool savedBool) {

                IsCompactModeEnabled = savedBool;
            }
            else {
                IsCompactModeEnabled = false; // Default value
            }

            // Set default page type
            CurrentPageType = typeof(CalendarPage);

        }

        [RelayCommand]
        void Navigate(NavigationViewSelectionChangedEventArgs args) {

            if(args.SelectedItem is NavigationViewItem selectedItem && selectedItem.Tag is string tagValue) {
                SelectedMenuItemTag = tagValue; // Update selection in ViewModel

                CurrentPageType = tagValue switch {
                    "CalendarPage" => typeof(CalendarPage),
                    "AccountPage" => typeof(AccountPage),
                    "AboutPage" => typeof(AboutPage),
                    _ => typeof(CalendarPage) // Default fallback
                };
            }
        }
        partial void OnIsCompactModeEnabledChanged(bool value) {

            isCompactMode?.Invoke(value);

            _localSettings.Values["IsCompactModeEnabled"] = value;

        }
    }
}
