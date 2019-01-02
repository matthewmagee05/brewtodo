
namespace Orders.Models
{
    public class Beer
    {
        public int BeerID { get; set; }
        public string BeerName { get; set; }
        public string Description { get; set; }
        public double ABV { get; set; }
        public int BeerTypeID { get; set; }
        public int BreweryID { get; set; }
    }
}