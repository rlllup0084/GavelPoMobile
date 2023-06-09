﻿using GavelPoMobile.Application.PurchaseOrders.Commands.UpdatePurchaseOrderStatus;
using GavelPoMobile.Application.PurchaseOrders.Query.GetAllPurchaseOrders;
using GavelPoMobile.Application.PurchaseOrders.Query.GetOrdersById;
using GavelPoMobile.Application.PurchaseOrders.Query.GetPurchaseOrdersByStatus;
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

    [HttpGet]
    public async Task<IActionResult> GetAllPurchaseOrders(int page, int pageSize) {
        var query = _mapper.Map<GetAllPurchaseOrdersQuery>((page, pageSize));

        var result = await _mediator.Send(query);

        return result.Match(
               purchaseOrderResult => Ok(_mapper.Map<PurchaseOrderResponse>(purchaseOrderResult)),
                      errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPurchaseOrderById(int id) {
        var query = _mapper.Map<GetOrdersByIdQuery>((new PurchaseOrderByIdRequest { },id));

        var result = await _mediator.Send(query);

        return result.Match(
               purchaseOrderResult => Ok(_mapper.Map<PurchaseOrderByIdResponse>(purchaseOrderResult)),
                      errors => Problem(errors));
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetPurchaseOrdersByStatus(int status, int page, int pageSize) {
        var query = _mapper.Map<GetPurchaseOrdersByStatusQuery>((status, page, pageSize));

        var result = await _mediator.Send(query);

        return result.Match(
               purchaseOrderResult => Ok(_mapper.Map<PurchaseOrderResponse>(purchaseOrderResult)),
                      errors => Problem(errors));
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePurchaseOrderStatus(UpdatePurchaseOrderStatusCommand command) {
        var result = await _mediator.Send(command);
        return result.Match(
                          purchaseOrderResult => Ok(_mapper.Map<PurchaseOrderByIdResponse>(purchaseOrderResult)),
                                               errors => Problem(errors));
    }
}
