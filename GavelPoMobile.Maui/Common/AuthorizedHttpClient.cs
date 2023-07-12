using System.Net.Http.Headers;

namespace GavelPoMobile.Maui.Common;
public class AuthorizedHttpClient : HttpClient {
    public AuthorizedHttpClient(string token) {
        DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}

