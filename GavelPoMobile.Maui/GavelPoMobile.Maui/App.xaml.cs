using GavelPoMobile.Maui.Services;
using GavelPoMobile.Maui.ViewModels;
using GavelPoMobile.Maui.Views;
using System.IdentityModel.Tokens.Jwt;
using Application = Microsoft.Maui.Controls.Application;

namespace GavelPoMobile.Maui; 
public partial class App : Application {
    public App() {
        InitializeComponent();

        DependencyService.Register<NavigationService>();

        DependencyService.Register<LoginService>();

        DependencyService.Register<PurchaseOrderService>();

        Routing.RegisterRoute(typeof(PurchaseOrderPage).FullName, typeof(PurchaseOrderPage));

        MainPage = new MainPage();
        // Use the NavigateToAsync<ViewModelName> method
        // to display the corresponding view.
        // Code lines below show how to navigate to a specific page.
        // Comment out all but one of these lines
        // to open the corresponding page.
        var navigationService = DependencyService.Get<INavigationService>();

        if (IsAuthorized()) {
            navigationService.NavigateToAsync<AboutViewModel>(true);
        } else {
            navigationService.NavigateToAsync<LoginViewModel>(true);
        }
    }

    private bool IsAuthorized() {
        // Check if a valid JWT token exists in the user's storage
        var token = SecureStorage.GetAsync("gpo_jwt_token").Result;
        if (token != null && IsTokenValid(token)) {
            return true;
        } else {
            return false;
        }
    }

    public bool IsTokenValid(string token) {
        var jwtHandler = new JwtSecurityTokenHandler();
        var jwtToken = jwtHandler.ReadJwtToken(token);

        // Check if the token has expired
        var expirationTime = jwtToken.ValidTo;
        var currentTime = DateTime.UtcNow;
        return expirationTime > currentTime;
    }
}
