using Application.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApi.UseCases.Person.GetAllPerson
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerGetAllUseCase customerGetAllUseCase;

        public CustomerController(ICustomerGetAllUseCase customerGetAllUseCase)
        {
            this.customerGetAllUseCase = customerGetAllUseCase;
        }


        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public ActionResult GetAll()
        {
            var customer = customerGetAllUseCase.Execute(1);

            if (!customer.Any())
                return BadRequest();

            return new ObjectResult(customer);

        }
    }
}