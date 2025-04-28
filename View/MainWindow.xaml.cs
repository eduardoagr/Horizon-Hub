namespace HorizonHub.View;

public sealed partial class MainWindow : WindowEx {

    public MainWindowViewModel MainWindowModel { get; set; }

    public MainWindow(MainWindowViewModel mainViewModlel) {
        InitializeComponent();

        MainWindowModel = mainViewModlel;

        NavView.DataContext = MainWindowModel;

        // Restore pane state from saved settings
        NavView.IsPaneOpen = !MainWindowModel.IsCompactModeEnabled;

       Activated  += (s, e) => {
            ContentFrame?.Navigate(MainWindowModel.CurrentPageType);
        };


        MainWindowModel.isCompactMode += (isCompact) => {
            NavView.IsPaneOpen = !isCompact;
            OptionsMenu.Hide();
        };

        MainWindowModel.PropertyChanged += (s, e) => {
            if(e.PropertyName == nameof(MainWindowModel.CurrentPageType)) {
                ContentFrame.Navigate(MainWindowModel.CurrentPageType);
            }
        };

    }

    private void NavView_Loaded(object sender, RoutedEventArgs e) {
        NavView.SelectedItem = NavView.MenuItems[0];
        ContentFrame?.Navigate(MainWindowModel.CurrentPageType);

    }
}
