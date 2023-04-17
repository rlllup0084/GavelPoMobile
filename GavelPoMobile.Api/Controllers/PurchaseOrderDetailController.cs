using GavelPoMobile.Application.PurchaseOrders.Common;
using GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrderDetailsById;
using GavelPoMobile.Contract.PurchaseOrderDetail;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GavelPoMobile.Api.Controllers;

[Route("api/detail/")]
public class PurchaseOrderDetailController : ApiController {

    private readonly ISender _mediator;

    private readonly IMapper _mapper;

    public PurchaseOrderDetailController(ISender mediator, IMapper mapper) {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPurchaseOrderDetailsById(PurchaseOrderDetailRequest request, int id) {
        var query = _mapper.Map<GetPurchaseOrderDetailsByIdQuery>((request, id));

        var result = await _mediator.Send(query);

        return result.Match(
               purchaseOrderDetailResult => Ok(purchaseOrderDetailResult.Select(p => _mapper.Map<PurchaseOrderDetailResponse>(p)).ToList()),
                      errors => Problem(errors));
    }
}
