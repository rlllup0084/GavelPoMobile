namespace GavelPoMobile.Maui.Services;
public interface ILoginService {
    Task<bool> Login(string email, string password);
}
