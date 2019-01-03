using Microsoft.EntityFrameworkCore;
using Orders.Models;

namespace Orders.Data
{
    public class BreweryContext: DbContext
    {
        public DbSet<Brewery> Breweries {get; set;}
        public DbSet<BeerType> BeerTypes {get; set;}
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBeerTried> UserBeersTried { get; set; }
        public DbSet<UserPurchasedItem> UserPurchasedItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:deliveryservice.database.windows.net,1433;Initial Catalog=BrewTodo;Persist Security Info=False;User ID=****;Password=***;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().HasData(
                new State {StateID=1, StateAbbr = "AL", StateFullName= "Alabama" },
                new State {StateID=2, StateAbbr = "AK", StateFullName= "Alaska" },
                new State {StateID=3, StateAbbr = "AZ", StateFullName= "Arizona" },
                new State {StateID=4, StateAbbr = "AR", StateFullName= "Arkansas" },
                new State {StateID=5, StateAbbr = "CA", StateFullName= "California" },
                new State {StateID=6, StateAbbr = "CO", StateFullName= "Colorado" },
                new State {StateID=7, StateAbbr = "CT", StateFullName= "Connecticut" },
                new State {StateID=8, StateAbbr = "DE", StateFullName= "Delaware" },
                new State {StateID=9, StateAbbr = "DC", StateFullName= "District of Columbia" },
                new State {StateID=10, StateAbbr = "FL", StateFullName= "Florida" },
                new State {StateID=11, StateAbbr = "GA", StateFullName= "Georgia" },
                new State {StateID=12, StateAbbr = "HI", StateFullName= "Hawaii" }

            );
            modelBuilder.Entity<User>().HasData(
                new User{UserID= 1, IdentityID= "213fds", Username="Poop_Pants", FirstName="Mateo", LastName="Magee", ProfileImage=123213},
                new User{UserID= 2, IdentityID= "fdsf", Username="Diabeto", FirstName="John", LastName="SMith", ProfileImage=2433},
                new User{UserID= 3, IdentityID= "213ffdds", Username="Sharty", FirstName="Jack", LastName="What", ProfileImage=544234},
                new User{UserID= 4, IdentityID= "432fsf", Username="McShartFace", FirstName="Jim", LastName="watt", ProfileImage=23432},
                new User{UserID= 5, IdentityID= "324fsf", Username="Diablo", FirstName="James", LastName="Brady", ProfileImage=4324234}
            );
            modelBuilder.Entity<Brewery>().HasData(
                new Brewery{BreweryID=1, Name="Beer House", Description="A Fun Beer House", ImageURL="http://www.example.com",Address="123 Main Street", ZipCode="76705", StateID=4, PhoneNumber="123456789", BusinessHours="24/7", HasFood=true, HasGrowler=true, HasMug=false, HasTShirt=true}
            );
            modelBuilder.Entity<BeerType>().HasData(
                 new BeerType{BeerTypeID=1, BeerTypeName="IPA"},
                 new BeerType{BeerTypeID=2, BeerTypeName="Ale"},
                 new BeerType{BeerTypeID=3, BeerTypeName="Pilsner"}
            );
            modelBuilder.Entity<Beer>().HasData(
                 new Beer{BeerID=1, BeerName="Sam Adams",Description="Boston's Tastiest beer",ABV=5.5, BeerTypeID=1, BreweryID=1}
            );
            modelBuilder.Entity<Review>().HasData(
                new Review{ReviewID=1,ReviewDescription="Best Place Ever", Rating= 4, UserID=2, BreweryID=1},
                new Review{ReviewID=2,ReviewDescription="It Was OK", Rating= 2, UserID=1, BreweryID=1}
            );
        }
    }
}