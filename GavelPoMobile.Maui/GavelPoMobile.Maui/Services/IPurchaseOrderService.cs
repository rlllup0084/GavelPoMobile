using GavelPoMobile.Maui.Models;

namespace GavelPoMobile.Maui.Services;

public interface IPurchaseOrderService {
    Task<string> GetPurchaseOrderByStatus(int status, int page, int pageSize);
}
