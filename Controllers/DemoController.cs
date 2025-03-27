using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers // Replace 'YourNamespace' with your actual namespace
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        // Example GET action
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from MyController");
        }
        
        // Additional actions can be added here
        // GET demo/factorial/{number}
        [HttpGet("{factorial}/{number}")]
        public ActionResult<long> GetFactorial(int number)
        {
            try
            {
                long result = Factorial(number);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private long Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers.");
            }
            else if (n == 0 || n == 1)
            {
                return 1;
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
