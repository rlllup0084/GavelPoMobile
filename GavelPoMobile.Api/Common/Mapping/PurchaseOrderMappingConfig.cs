using GavelPoMobile.Application.PurchaseOrders.Query.GetAllPurchaseOrders;
using GavelPoMobile.Application.PurchaseOrders.Query.GetOrdersById;
using GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrdersByStatus;
using GavelPoMobile.Contract.PurchaseOrder.PurchaseOrderById;
using Mapster;

namespace GavelPoMobile.Api.Common.Mapping;
public class PurchaseOrderMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        config.NewConfig<(int Page, int PageSize), GetAllPurchaseOrdersQuery>()
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.PageSize, src => src.PageSize);

        config.NewConfig<(int Status, int Page, int PageSize), GetPurchaseOrdersByStatusQuery>()
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.PageSize, src => src.PageSize);

        config.NewConfig<(PurchaseOrderByIdRequest, int Id), GetOrdersByIdQuery>()
            .Map(dest => dest.Id, src => src.Id);
    }
}
