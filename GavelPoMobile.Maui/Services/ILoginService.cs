namespace GavelPoMobile.Maui.Services;
public interface ILoginService {
    Task<string> Login(string email, string password);
}
