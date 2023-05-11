namespace GavelPoMobile.Maui.Services;
public static class ConnectivityService {
    public static async Task<bool> IsConnected() {
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;

        if (accessType == NetworkAccess.Internet) {
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }
}
