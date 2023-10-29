using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentApi.Models
{
    public class PaymentDetail
    {
        public int Id { get; set;}
        [Key]
        public int PaymentDetailId { get; set; }
        [StringLength(100, ErrorMessage = "CardOwnerName cannot be longer than 100 characters")]
        //[Column(TypeName ="char(100)")]
        public string CardOwnerName { get; set; } = "";
        [MaxLength(16, ErrorMessage = "CardNumber cannot be long than 16 characters")]
        //[Column(TypeName = "char(16)")]
        public string CardNumber { get; set; } = "";
        [MaxLength(5, ErrorMessage = "ExpirationDate cannot be long than 5 characters")]
        //mm//yy
        //[Column(TypeName = "char(5)")]
        public string ExpirationDate { get; set; } = "";
        [MaxLength(3, ErrorMessage = "SecurityCode cannot be long than 3 characters")]
        //[Column(TypeName = "char(3)")]
        public string SecurityCode { get; set; } = "";
        
    }
}
