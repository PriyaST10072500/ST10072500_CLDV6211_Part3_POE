using ST10072500_CLDV6211_Part2.Models;

namespace ST10072500_CLDV6211_Part2.ViewModels
{
    public class TrasactionProductViewModel
    {
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}
