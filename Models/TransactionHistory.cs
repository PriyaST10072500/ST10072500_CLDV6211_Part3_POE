using System.ComponentModel.DataAnnotations;


namespace ST10072500_CLDV6211_Part2.Models
{
    public class TransactionHistory
    {
        [Key] public int TransactionHistoryId { get; set; }
        public int? TransactionId { get; set; }

        public DateTime ChangeDate { get; set; }

        public Transaction? Transaction { get; set; }
    }
}
