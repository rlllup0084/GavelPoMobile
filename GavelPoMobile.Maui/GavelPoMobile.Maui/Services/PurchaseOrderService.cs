using DevExpress.Maui.Core.Internal;
using GavelPoMobile.Maui.Common;
using GavelPoMobile.Maui.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace GavelPoMobile.Maui.Services;

public class PurchaseOrderService : IPurchaseOrderService {

    private static readonly HttpClient HttpClient = new HttpClient();
    private readonly string _apiUrl = ON.Platform(android: "https://gavellogistics.com:7082/api", iOS: "https://gavellogistics.com:7082/api");

    public PurchaseOrderService() {
    }

    public async Task<string> GetAllPurchaseOrders(int page, int pageSize) {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/order?page={page}&pageSize={pageSize}");

        var authToken = await SecureStorage.GetAsync("gpo_jwt_token");

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

        var response = await HttpClient.SendAsync(request);

        var responseContent = await response.Content.ReadAsStringAsync();

        return responseContent;
    }

    public async Task<string> GetPurchaseOrderByStatus(int status, int page, int pageSize) {

        var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/order/status/{status}?page={page}&pageSize={pageSize}");

        var authToken = await SecureStorage.GetAsync("gpo_jwt_token");

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

        var response = await HttpClient.SendAsync(request);

        var responseContent = await response.Content.ReadAsStringAsync();

        return responseContent;
    }

    public async Task<string> GetPurchaseOrderById(int id) {

        var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/order/{id}");

        var authToken = await SecureStorage.GetAsync("gpo_jwt_token");

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

        var response = await HttpClient.SendAsync(request);

        var responseContent = await response.Content.ReadAsStringAsync();

        return responseContent;
    }
}
