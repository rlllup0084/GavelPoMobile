﻿using DevExpress.Maui.Core.Internal;
using GavelPoMobile.Maui.Common;
using GavelPoMobile.Maui.Models;
using GavelPoMobile.Maui.Views;
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

        if (authToken != null && !JwtTokenValidator.IsTokenValid(authToken)) {
            await Application.Current.MainPage.DisplayAlert("Session Expired", "Your session has expired. Please log in again.", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            return null;
        }

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

        var response = await HttpClient.SendAsync(request);

        var responseContent = await response.Content.ReadAsStringAsync();

        return responseContent;
    }

    public async Task<string> GetPurchaseOrderByStatus(int status, int page, int pageSize) {

        var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/order/status/{status}?page={page}&pageSize={pageSize}");

        var authToken = await SecureStorage.GetAsync("gpo_jwt_token");

        if (authToken != null && !JwtTokenValidator.IsTokenValid(authToken)) {
            await Application.Current.MainPage.DisplayAlert("Session Expired", "Your session has expired. Please log in again.", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            return null;
        }

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

        var response = await HttpClient.SendAsync(request);

        var responseContent = await response.Content.ReadAsStringAsync();

        return responseContent;
    }

    public async Task<string> GetPurchaseOrderById(int id) {

        var request = new HttpRequestMessage(HttpMethod.Get, $"{_apiUrl}/order/{id}");

        var authToken = await SecureStorage.GetAsync("gpo_jwt_token");

        if (authToken != null && !JwtTokenValidator.IsTokenValid(authToken)) {
            await Application.Current.MainPage.DisplayAlert("Session Expired", "Your session has expired. Please log in again.", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            return null;
        }

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

        var response = await HttpClient.SendAsync(request);

        var responseContent = await response.Content.ReadAsStringAsync();

        return responseContent;
    }

    public async Task<string> UpdatePurchaseOrderDetailStatus(int id, int status, string remarks) {
        var body = new {
            id = id,
            lineApprovalStatus = status,
            remarks = remarks
        };
        var json = JsonConvert.SerializeObject(body);
        var request = new HttpRequestMessage(HttpMethod.Put, $"{_apiUrl}/detail");
        var authToken = await SecureStorage.GetAsync("gpo_jwt_token");

        if (authToken != null && !JwtTokenValidator.IsTokenValid(authToken)) {
            await Application.Current.MainPage.DisplayAlert("Session Expired", "Your session has expired. Please log in again.", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            return null;
        }

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await HttpClient.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode) {
            return string.Empty;
        }

        return responseContent;
    }

    public async Task<string> UpdatePurchaseOrderStatus(int id, int status, string remarks) {
        var body = new {
            id = id,
            status = status,
            remarks = remarks
        };
        var json = JsonConvert.SerializeObject(body);
        var request = new HttpRequestMessage(HttpMethod.Put, $"{_apiUrl}/order");
        var authToken = await SecureStorage.GetAsync("gpo_jwt_token");

        if (authToken != null && !JwtTokenValidator.IsTokenValid(authToken)) {
            await Application.Current.MainPage.DisplayAlert("Session Expired", "Your session has expired. Please log in again.", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            return null;
        }

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await HttpClient.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode) {
            return string.Empty;
        }
        return responseContent;
    }
}
