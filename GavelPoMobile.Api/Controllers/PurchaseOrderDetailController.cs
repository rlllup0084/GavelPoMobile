using GavelPoMobile.Application.PurchaseOrders.Commands.UpdatePOLineStatus;
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
    public async Task<IActionResult> GetPurchaseOrderDetailsById(int id) {
        var query = _mapper.Map<GetPurchaseOrderDetailsByIdQuery>((new PurchaseOrderDetailRequest { }, id));

        var result = await _mediator.Send(query);

        return result.Match(
               purchaseOrderDetailResult => Ok(purchaseOrderDetailResult.Select(p => _mapper.Map<PurchaseOrderDetailResponse>(p)).ToList()),
                      errors => Problem(errors));
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePurchaseOrderDetailStatus(UpdatePOLineStatusCommand command) {
        var result = await _mediator.Send(command);
        return result.Match(
                          purchasOrderDetailResult => Ok(_mapper.Map<PurchaseOrderDetailResponse>(purchasOrderDetailResult)),
                                               errors => Problem(errors));
    }
}
