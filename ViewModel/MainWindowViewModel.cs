using System.Reflection;

namespace HorizonHub.ViewModel {

    public partial class MainWindowViewModel : ObservableObject {

        private const string IsCompactModeEnabledKey = "IsCompactModeEnabled";
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;

        public Action<bool>? isCompactMode;

        [ObservableProperty]
        Type? currentPageType;

        [ObservableProperty]
        bool isCompactModeEnabled;

        public MainWindowViewModel() {

            if(_localSettings.Values.TryGetValue(IsCompactModeEnabledKey, out var storedValue)
                && storedValue is bool savedBool) {

                IsCompactModeEnabled = savedBool;
            }
            else {
                IsCompactModeEnabled = false; // Default value
            }

            CurrentPageType = typeof(CalendarPage);

        }

        [RelayCommand]
        void Navigate(NavigationViewSelectionChangedEventArgs args) {
            if(args.SelectedItem is NavigationViewItem selectedItem && selectedItem.Tag is string pageTag) {

                var assembly = Assembly.GetExecutingAssembly(); // Get current assembly

                CurrentPageType = assembly.GetType($"HorizonHub.View.{pageTag}");
            }
        }

        partial void OnIsCompactModeEnabledChanged(bool value) {

            isCompactMode?.Invoke(value);

            _localSettings.Values["IsCompactModeEnabled"] = value;

        }
    }
}
