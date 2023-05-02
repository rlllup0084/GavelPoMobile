using System.Net.Http.Headers;
using DevExpress.Maui.Core.Internal;
using GavelPoMobile.Maui.Models;
using Newtonsoft.Json;
using System.Text;

namespace GavelPoMobile.Maui.Services;

public class LoginService : ILoginService {

    private static readonly HttpClient HttpClient = new HttpClient() { Timeout = new TimeSpan(0, 0, 10) };
    private readonly string _apiUrl = ON.Platform(android: "http://192.168.1.200:7082/auth/", iOS: "http://192.168.1.200:7082/auth/");

    public LoginService() {
    }

    public async Task<string> Login(string email, string password) {
        var loginData = new LoginData {
            Email = email,
            Password = password
        };

        var json = JsonConvert.SerializeObject(loginData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await HttpClient.PostAsync($"{_apiUrl}login", content);

        var reposeContent = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode) {
            var authData = JsonConvert.DeserializeObject<AuthenticationData>(reposeContent);
            //HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authData.Token);
            await SecureStorage.SetAsync("gpo_jwt_token", authData.Token);
            await SecureStorage.SetAsync("gpo_auth_id", authData.Email);
            return string.Empty;
        }

        return reposeContent;
    }

    public async Task<bool> Logout() {
        await Task.CompletedTask;

        SecureStorage.Remove("gpo_jwt_token");
        SecureStorage.Remove("gpo_auth_id");

        return true;
    }
}
