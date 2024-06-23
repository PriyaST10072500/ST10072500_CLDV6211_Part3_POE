using System.ComponentModel.DataAnnotations;


namespace ST10072500_CLDV6211_Part2.Models
{
    public class Product
    {

        [Key] public int ArtId { get; set; }
        public string? ArtName { get; set; }
        public string? ArtCreatorName { get; set; }
        public double? ArtPrice { get; set; }
        public string? ArtCategory { get; set; }
        public Boolean ArtAvailability { get; set; }


        public string? ArtImg { get; set; }

        //Navigate to transactions (the bridge)
        public List<Transaction>? Transactions { get; set; }

    }

}

