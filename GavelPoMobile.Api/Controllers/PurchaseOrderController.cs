using GavelPoMobile.Application.PurchaseOrders.Query.GetOrdersById;
using GavelPoMobile.Contract.PurchaseOrder.PurchaseOrderById;
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

    // GetPurchaseOrderById
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPurchaseOrderById(PurchaseOrderByIdRequest request,int id) {
        var query = _mapper.Map<GetOrdersByIdQuery>((request,id));

        var result = await _mediator.Send(query);

        return Ok(result);
    }
    // GetAllPurchaseOrders
    // GetPurchaseOrdersByStatus
    // GetPOApprovalsHistory
}
