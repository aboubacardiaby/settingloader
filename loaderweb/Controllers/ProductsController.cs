using loaderweb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace loaderweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository _repository;

        public ProductsController(IRepository repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        public IActionResult Getall()
        {
            return Ok(_repository.GetAll());
        }
        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            _repository.Add(product);
            return Ok();
        }
    }

}

