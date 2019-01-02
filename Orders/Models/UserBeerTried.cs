namespace Orders.Models
{
    public class UserBeerTried
    {
        public int UserBeerTriedID { get; set; }
        public int UserID { get; set; }
        public int BeerID { get; set; }
        public virtual Beer Beer { get; set; }
        public virtual User User { get; set; }
    }
}