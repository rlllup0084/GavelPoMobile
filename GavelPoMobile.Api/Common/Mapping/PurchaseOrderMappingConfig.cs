using GavelPoMobile.Application.PurchaseOrders.Commands.UpdatePurchaseOrderStatus;
using GavelPoMobile.Application.PurchaseOrders.Common;
using GavelPoMobile.Application.PurchaseOrders.Query.GetAllPurchaseOrders;
using GavelPoMobile.Application.PurchaseOrders.Query.GetOrdersById;
using GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrderDetailsById;
using GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrdersByStatus;
using GavelPoMobile.Contract.PurchaseOrder.PurchaseOrderById;
using GavelPoMobile.Contract.PurchaseOrder.PurchaseOrdersList;
using GavelPoMobile.Contract.PurchaseOrderDetail;
using GavelPoMobile.Domain.Aggregates;
using GavelPoMobile.Domain.Aggregates.Entities;
using Mapster;

namespace GavelPoMobile.Api.Common.Mapping;
public class PurchaseOrderMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {

        config.NewConfig<(PurchaseOrderListRequest, int page, int pageSize), GetAllPurchaseOrdersQuery>()
            .Map(dest => dest.Page, src => src.page)
            .Map(dest => dest.PageSize, src => src.pageSize);

        config.NewConfig<(PurchaseOrderListRequest, int status, int page, int pageSize), GetPurchaseOrdersByStatusQuery>()
            .Map(dest => dest.Status, src => src.status)
            .Map(dest => dest.Page, src => src.page)
            .Map(dest => dest.PageSize, src => src.pageSize);

        config.NewConfig<(PurchaseOrderByIdRequest, int id), GetOrdersByIdQuery>()
            .Map(dest => dest.Id, src => src.id);

        config.NewConfig<PurchaseOrder, PurchaseOrderResult>()
            .Map(dest => dest.Id, src => src.OID);

        config.NewConfig<(PurchaseOrderDetailRequest, int id), GetPurchaseOrderDetailsByIdQuery>()
            .Map(dest => dest.Id, src => src.id);

        config.NewConfig<PurchaseOrderDetail, PurchaseOrderDetailResponse>();

        config.NewConfig<PurchaseOrderDetail, PurchaseOrderDetailResult>()
            .Map(dest => dest.Id, src => src.OID);
    }
}
