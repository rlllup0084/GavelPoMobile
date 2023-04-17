using GavelPoMobile.Application.PurchaseOrders.Query.GetAllPurchaseOrders;
using GavelPoMobile.Application.PurchaseOrders.Query.GetOrdersById;
using GavelPoMobile.Contract.PurchaseOrder.PurchaseOrderById;
using GavelPoMobile.Contract.PurchaseOrder.PurchaseOrdersList;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GavelPoMobile.Api.Controllers;

[Route("api/order/")]
public class PurchaseOrderController : ApiController {

    private readonly ISender _mediator;

    private readonly IMapper _mapper;

    public PurchaseOrderController(ISender mediator, IMapper mapper) {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GetAllPurchaseOrders
    [HttpGet]
    public async Task<IActionResult> GetAllPurchaseOrders(PurchaseOrderListRequest request, int page, int pageSize) {
        var query = _mapper.Map<GetAllPurchaseOrdersQuery>((request, page, pageSize));

        var result = await _mediator.Send(query);

        return result.Match(
               purchaseOrderResult => Ok(_mapper.Map<PurchaseOrderResponse>(purchaseOrderResult)),
                      errors => Problem(errors));
    }

    // GetPurchaseOrderById
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPurchaseOrderById(PurchaseOrderByIdRequest request, int id) {
        var query = _mapper.Map<GetOrdersByIdQuery>((request, id));

        var result = await _mediator.Send(query);

        return result.Match(
               purchaseOrderResult => Ok(_mapper.Map<PurchaseOrderByIdResponse>(purchaseOrderResult)),
                      errors => Problem(errors));
    }

    // GetPurchaseOrdersByStatus
}
