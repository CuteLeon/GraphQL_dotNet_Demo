using System.Threading.Tasks;
using GraphQLWebAPIwithEFCore.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWebAPIwithEFCore.Controllers
{
    [ApiController]
    public class CommonAPIController : Controller
    {
        private readonly DatabaseContext context;

        public CommonAPIController(DatabaseContext context)
        {
            this.context = context;
        }

        [Route("Common/Property")]
        public async Task<IActionResult> GetProperties()
        {
            var properties = await context.Properties.ToListAsync();
            return this.Json(properties);
        }

        [Route("Common/Property/{PropertyId}")]
        public async Task<IActionResult> GetProperty(int propertyId)
        {
            var property = await context.Properties.FindAsync(propertyId);
            return this.Json(property);
        }

        [Route("Common/Payment")]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await context.Payments.ToListAsync();
            return this.Json(payments);
        }

        [Route("Common/Payment/{PaymentId}")]
        public async Task<IActionResult> GetPayment(int paymentId)
        {
            var payment = await context.Payments.FindAsync(paymentId);
            return this.Json(payment);
        }
    }
}
