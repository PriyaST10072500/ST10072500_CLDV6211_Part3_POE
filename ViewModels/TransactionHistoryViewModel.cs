using ST10072500_CLDV6211_Part2.Models;

namespace ST10072500_CLDV6211_Part2.ViewModels
{
    public class TransactionHistoryViewModel
    {
        public List<Transaction>? Transactions { get; set; }

        public int? FilterArtID { get; set; }
        public int? FilterUserID { get; set;}
        public DateTime? FilerOrderDate { get; set; }

        public DateTime? FilterDeliveryDate { get; set; }


    }
}
