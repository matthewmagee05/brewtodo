using System.Collections.Generic;

namespace Orders.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string IdentityID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProfileImage { get; set; }

        public virtual ICollection<UserBeerTried> UserBeersTried { get; set; }
        public virtual ICollection<UserPurchasedItem> UserPurchasedItems { get; set; }
    }
}