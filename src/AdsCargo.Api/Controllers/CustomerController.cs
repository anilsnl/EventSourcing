using AdsCargo.Abstraction.Responses.Customer;
using AdsCargo.Applications.Customer.Commands.CreateRetailCustomer;
using AdsCargo.Applications.Customer.Queries.GetRetailCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdsCargo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("retail/{id}")]
    [ProducesResponseType(typeof(RetailCustomerDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRetailCustomer(
        [FromRoute] string id,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetRetailCustomerQuery(id), cancellationToken);
        return Ok(response);
    }
    
    [HttpPost("retail")]
    [ProducesResponseType(typeof(RetailCustomerDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateRetailCustomer(
        [FromBody] CreateRetailCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}