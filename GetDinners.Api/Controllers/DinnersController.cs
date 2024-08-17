using Microsoft.AspNetCore.Mvc;

namespace GetDinners.Api.Controllers
{
    [Route("[controller]")]

    //[Route("dinners")]
    public class DinnersController : ApiController
    {
        [HttpGet("DinnersList")]
        public IActionResult DinnersList()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
