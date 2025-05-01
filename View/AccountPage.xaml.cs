namespace HorizonHub.View;

public sealed partial class AccountPage : Page {

    public AccountPage(AccountPageViewModel accountPageViewModel) {

        InitializeComponent();

        DataContext = accountPageViewModel;
    }
}
