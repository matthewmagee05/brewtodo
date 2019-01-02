using System.Collections.Generic;

namespace Orders.Models
{
    public class Brewery
    {
        public int BreweryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public int StateID { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessHours { get; set; }
        public bool HasTShirt { get; set; }
        public bool HasMug { get; set; }
        public bool HasGrowler { get; set; }
        public bool HasFood { get; set; }
        public virtual State State { get; set; }
        public virtual IEnumerable<Review> Reviews { get; set; }
        public virtual IEnumerable<Beer> Beers  { get; set; }
    }
}