namespace HorizonHub.View;

public sealed partial class AboutPage : Page {

    public AboutPage(AboutPageViewModel aboutPageViewModel) {

        InitializeComponent();

        DataContext = aboutPageViewModel;
    }
}
