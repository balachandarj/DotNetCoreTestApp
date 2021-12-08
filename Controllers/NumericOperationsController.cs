using Microsoft.AspNetCore.Mvc;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("api/NumericOperations/")]
    public class NumericOperationsController : ControllerBase
    {


        [HttpGet("AddTwoNumbers")]
        public int AddTwoNumbers(int a,int b)
        {
            return a + b;
        }

        [HttpGet("SubTwoNumbers")]
        public int SubTwoNumbers(int a, int b)
        {
            return a - b;
        }

        [HttpGet("MultiplyTwoNumbers")]
        public int MultiplyTwoNumbers(int a, int b)
        {
            return a * b;
        }

        [HttpGet("DivTwoNumbers")]
        public int DivTwoNumbers(int a, int b)
        {
            return a/ b;
        }
    }
}
