using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.UseCases.Customer.CreateCustomer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;               

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]      
        [Route("CreateCustomer")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreateCustomer(CreateRequest createRequest)
        {        
            var response =  mediator.Send(createRequest);

            return Ok(response.Result);
        }
    }
}