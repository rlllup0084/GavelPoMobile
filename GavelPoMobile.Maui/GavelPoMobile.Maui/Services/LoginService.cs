using DevExpress.Maui.Core.Internal;
using GavelPoMobile.Maui.Models;
using Newtonsoft.Json;
using System.Text;

namespace GavelPoMobile.Maui.Services;
public class LoginService : ILoginService {

    private readonly HttpClient _httpClient;
    private readonly string _apiUrl = ON.Platform(android: "https://localhost:7082/api/", iOS: "https://localhost:7082/api/");

    public LoginService(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<bool> Login(string email, string password) {
        var loginData = new LoginData {
            Email = email,
            Password = password
        };

        var json = JsonConvert.SerializeObject(loginData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_apiUrl}login", content);

        if (!response.IsSuccessStatusCode) {
            throw new Exception("Invalid email or password.");
        }

        return response.IsSuccessStatusCode;
    }
}
