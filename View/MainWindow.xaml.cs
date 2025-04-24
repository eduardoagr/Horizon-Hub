namespace HorizonHub.View;

public sealed partial class MainWindow : WindowEx {

    public MainWindowViewModel MainWindowModel { get; set; }

    public MainWindow(MainWindowViewModel mainViewModlel) {
        InitializeComponent();

        MainWindowModel = mainViewModlel;

        rootContainer.DataContext = MainWindowModel;

        // Restore pane state from saved settings
        rootContainer.IsPaneOpen = !MainWindowModel.IsCompactModeEnabled;

        MainWindowModel.isCompactMode += (isCompact) => {
            rootContainer.IsPaneOpen = !isCompact;
            OptionsMenu.Hide();
        };
    }
}
