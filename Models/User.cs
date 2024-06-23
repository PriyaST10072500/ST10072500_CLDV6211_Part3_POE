using System.ComponentModel.DataAnnotations;

namespace ST10072500_CLDV6211_Part2.Models
{
    public class User
    {
        public enum UserType
        {
            Customer,
            Artisan
        }

        [Key] public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public UserType UserTypes { get; set; }


        //Navigate to transactions (the bridge)
        public List<Transaction>? Transactions { get; set; }

    }

}

