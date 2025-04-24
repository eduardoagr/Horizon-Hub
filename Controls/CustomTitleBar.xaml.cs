namespace HorizonHub.Controls;

public sealed partial class CustomTitleBar : UserControl {

    public CustomTitleBarViewModel? TitleBarViewModel { get; set; }

    public CustomTitleBar(CustomTitleBarViewModel titleBarViewModel) {

        InitializeComponent();

        TitleBarViewModel = titleBarViewModel;

        DataContext = TitleBarViewModel;


    }
}
