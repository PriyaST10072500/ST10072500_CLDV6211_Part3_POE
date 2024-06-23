using System.ComponentModel.DataAnnotations;


namespace ST10072500_CLDV6211_Part2.Models
{
    public class Transaction
    {

        [Key] public int TransactionId { get; set; }
        public int? UserId { get; set; }
        public int? ArtId { get; set; }
        
        public DateTime TransactionDate { get; set; }
        public DateTime ModifiedDate { get; set; }  

        //Navigation properties
        public User? User { get; set; }
        public Product? Product { get; set; }



    }
}
