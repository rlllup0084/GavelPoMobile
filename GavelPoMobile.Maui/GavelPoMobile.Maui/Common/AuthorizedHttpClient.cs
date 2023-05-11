using System.Net.Http.Headers;

namespace GavelPoMobile.Maui.Common;
public class AuthorizedHttpClient : HttpClient {
    public AuthorizedHttpClient(string token) {
        Timeout = new TimeSpan(0, 0, 10);
        DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}

