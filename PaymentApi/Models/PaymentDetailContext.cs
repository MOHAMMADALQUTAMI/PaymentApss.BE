using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace PaymentApi.Models
{
    public class PaymentDetailContext : IdentityDbContext
    {
        public PaymentDetailContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
