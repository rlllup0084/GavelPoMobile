using GavelPoMobile.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GavelPoMobile.Maui.ViewModels;

public class AccountViewModel : BaseViewModel {
    private string userName;

    public AccountViewModel() {
        LogoutCommand = new Command(ExecuteLogoutCommmand);
        UserName = SecureStorage.GetAsync("gpo_auth_id").Result;
    }

    async void ExecuteLogoutCommmand() {
        if (await LoginService.Logout()) {
            await Navigation.NavigateToAsync<LoginViewModel>(true);
        }
    }

    public Command LogoutCommand { get; }

    public string UserName {
        get => this.userName;
        set => SetProperty(ref this.userName, value);
    }
}
