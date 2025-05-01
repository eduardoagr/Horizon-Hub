namespace HorizonHub.View;

public sealed partial class MainWindow : WindowEx {

    public MainWindowViewModel MainWindowModel { get; set; }

    public MainWindow(MainWindowViewModel mainViewModlel) {
        InitializeComponent();

        MainWindowModel = mainViewModlel;

        NavView.DataContext = MainWindowModel;

        NavView.SelectedItem = NavView.MenuItems[0];

        // Restore pane state from saved settings
        NavView.IsPaneOpen = !MainWindowModel.IsCompactModeEnabled;

        Activated += (s, e) => { LoadCurrentPage(); };

        // Subscribe to property changes
        SubscribeToPropertyChanges();

        MainWindowModel.isCompactMode += (isCompact) => {
            NavView.IsPaneOpen = !isCompact;
            OptionsMenu.Hide();
        };
    }

    private void SubscribeToPropertyChanges() {

        MainWindowModel.PropertyChanged += (s, e) => {
            if(e.PropertyName == nameof(MainWindowModel.CurrentPageType)) {
                LoadCurrentPage();
            }
        };
    }

    private void LoadCurrentPage() {

        var page = (Page)App.Services!.GetService(MainWindowModel!.CurrentPageType!)!;

        if(page != null) {
            // Set the ContentFrame to the created page instance
            ContentFrame.Content = page;
        }
    }
}

