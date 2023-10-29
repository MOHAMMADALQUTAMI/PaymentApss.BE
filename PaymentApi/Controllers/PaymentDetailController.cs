using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentApi.Models;

namespace PaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailContext _context;
        public PaymentDetailController(PaymentDetailContext context)
        {
            _context = context;
        }
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetail()
        {
            if (_context.PaymentDetails == null)
            {
                return NotFound();
            }
            return await _context.PaymentDetails.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            if (_context.PaymentDetails == null)
            {
                return NotFound();
            }
            var PaymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (PaymentDetail == null)
            {
                return NotFound();
            }
            return PaymentDetail;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            
            if (id != paymentDetail.PaymentDetailId)
            {
                return BadRequest();
            }
            _context.Entry(paymentDetail).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!PaymentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
             return Ok(await _context.PaymentDetails.ToListAsync());

        }

        private bool PaymentDetailExists(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            if (_context.PaymentDetails == null)
            {
                return Problem("Entity set 'PaymentDetailContext.PaymentDetails' is null");
            }
            _context.PaymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();
            return Ok(await _context.PaymentDetails.ToListAsync());
                //CreatedAtAction("GetPaymentDetails",new {id = paymentDetail .PaymentDetailId},paymentDetail);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaymentDetail(int id)
        {
            if (_context.PaymentDetails == null)
            {
                return NotFound();
            }
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }
            _context.PaymentDetails.Remove(paymentDetail);
            await _context.SaveChangesAsync();
            return Ok(await _context.PaymentDetails.ToListAsync());
        }


    }
}