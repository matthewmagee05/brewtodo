﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orders.Data;

namespace Orders.Migrations
{
    [DbContext(typeof(BreweryContext))]
    partial class BreweryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Orders.Models.Beer", b =>
                {
                    b.Property<int>("BeerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ABV");

                    b.Property<string>("BeerName");

                    b.Property<int>("BeerTypeID");

                    b.Property<int>("BreweryID");

                    b.Property<string>("Description");

                    b.HasKey("BeerID");

                    b.HasIndex("BreweryID");

                    b.ToTable("Beers");

                    b.HasData(
                        new
                        {
                            BeerID = 1,
                            ABV = 5.5,
                            BeerName = "Sam Adams",
                            BeerTypeID = 1,
                            BreweryID = 1,
                            Description = "Boston's Tastiest beer"
                        });
                });

            modelBuilder.Entity("Orders.Models.BeerType", b =>
                {
                    b.Property<int>("BeerTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BeerTypeName");

                    b.HasKey("BeerTypeID");

                    b.ToTable("BeerTypes");

                    b.HasData(
                        new
                        {
                            BeerTypeID = 1,
                            BeerTypeName = "IPA"
                        },
                        new
                        {
                            BeerTypeID = 2,
                            BeerTypeName = "Ale"
                        },
                        new
                        {
                            BeerTypeID = 3,
                            BeerTypeName = "Pilsner"
                        });
                });

            modelBuilder.Entity("Orders.Models.Brewery", b =>
                {
                    b.Property<int>("BreweryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("BusinessHours");

                    b.Property<string>("Description");

                    b.Property<bool>("HasFood");

                    b.Property<bool>("HasGrowler");

                    b.Property<bool>("HasMug");

                    b.Property<bool>("HasTShirt");

                    b.Property<string>("ImageURL");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("StateID");

                    b.Property<string>("ZipCode");

                    b.HasKey("BreweryID");

                    b.HasIndex("StateID");

                    b.ToTable("Breweries");

                    b.HasData(
                        new
                        {
                            BreweryID = 1,
                            Address = "123 Main Street",
                            BusinessHours = "24/7",
                            Description = "A Fun Beer House",
                            HasFood = true,
                            HasGrowler = true,
                            HasMug = false,
                            HasTShirt = true,
                            ImageURL = "http://www.example.com",
                            Name = "Beer House",
                            PhoneNumber = "123456789",
                            StateID = 4,
                            ZipCode = "76705"
                        });
                });

            modelBuilder.Entity("Orders.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BreweryID");

                    b.Property<float>("Rating");

                    b.Property<string>("ReviewDescription");

                    b.Property<int>("UserID");

                    b.HasKey("ReviewID");

                    b.HasIndex("BreweryID");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewID = 1,
                            BreweryID = 1,
                            Rating = 4f,
                            ReviewDescription = "Best Place Ever",
                            UserID = 2
                        },
                        new
                        {
                            ReviewID = 2,
                            BreweryID = 1,
                            Rating = 2f,
                            ReviewDescription = "It Was OK",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("Orders.Models.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateAbbr");

                    b.Property<string>("StateFullName");

                    b.HasKey("StateID");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            StateID = 1,
                            StateAbbr = "AL",
                            StateFullName = "Alabama"
                        },
                        new
                        {
                            StateID = 2,
                            StateAbbr = "AK",
                            StateFullName = "Alaska"
                        },
                        new
                        {
                            StateID = 3,
                            StateAbbr = "AZ",
                            StateFullName = "Arizona"
                        },
                        new
                        {
                            StateID = 4,
                            StateAbbr = "AR",
                            StateFullName = "Arkansas"
                        },
                        new
                        {
                            StateID = 5,
                            StateAbbr = "CA",
                            StateFullName = "California"
                        },
                        new
                        {
                            StateID = 6,
                            StateAbbr = "CO",
                            StateFullName = "Colorado"
                        },
                        new
                        {
                            StateID = 7,
                            StateAbbr = "CT",
                            StateFullName = "Connecticut"
                        },
                        new
                        {
                            StateID = 8,
                            StateAbbr = "DE",
                            StateFullName = "Delaware"
                        },
                        new
                        {
                            StateID = 9,
                            StateAbbr = "DC",
                            StateFullName = "District of Columbia"
                        },
                        new
                        {
                            StateID = 10,
                            StateAbbr = "FL",
                            StateFullName = "Florida"
                        },
                        new
                        {
                            StateID = 11,
                            StateAbbr = "GA",
                            StateFullName = "Georgia"
                        },
                        new
                        {
                            StateID = 12,
                            StateAbbr = "HI",
                            StateFullName = "Hawaii"
                        });
                });

            modelBuilder.Entity("Orders.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("IdentityID");

                    b.Property<string>("LastName");

                    b.Property<int>("ProfileImage");

                    b.Property<string>("Username");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            FirstName = "Mateo",
                            IdentityID = "213fds",
                            LastName = "Magee",
                            ProfileImage = 123213,
                            Username = "Poop_Pants"
                        },
                        new
                        {
                            UserID = 2,
                            FirstName = "John",
                            IdentityID = "fdsf",
                            LastName = "SMith",
                            ProfileImage = 2433,
                            Username = "Diabeto"
                        },
                        new
                        {
                            UserID = 3,
                            FirstName = "Jack",
                            IdentityID = "213ffdds",
                            LastName = "What",
                            ProfileImage = 544234,
                            Username = "Sharty"
                        },
                        new
                        {
                            UserID = 4,
                            FirstName = "Jim",
                            IdentityID = "432fsf",
                            LastName = "watt",
                            ProfileImage = 23432,
                            Username = "McShartFace"
                        },
                        new
                        {
                            UserID = 5,
                            FirstName = "James",
                            IdentityID = "324fsf",
                            LastName = "Brady",
                            ProfileImage = 4324234,
                            Username = "Diablo"
                        });
                });

            modelBuilder.Entity("Orders.Models.UserBeerTried", b =>
                {
                    b.Property<int>("UserBeerTriedID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeerID");

                    b.Property<int>("UserID");

                    b.HasKey("UserBeerTriedID");

                    b.HasIndex("BeerID");

                    b.HasIndex("UserID");

                    b.ToTable("UserBeersTried");
                });

            modelBuilder.Entity("Orders.Models.UserPurchasedItem", b =>
                {
                    b.Property<int>("UserPurchasedItemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BreweryID");

                    b.Property<bool>("PurchasedGrowler");

                    b.Property<bool>("PurchasedMug");

                    b.Property<bool>("PurchasedTShirt");

                    b.Property<bool>("TriedFood");

                    b.Property<int>("UserID");

                    b.HasKey("UserPurchasedItemID");

                    b.HasIndex("BreweryID");

                    b.HasIndex("UserID");

                    b.ToTable("UserPurchasedItems");
                });

            modelBuilder.Entity("Orders.Models.Beer", b =>
                {
                    b.HasOne("Orders.Models.Brewery")
                        .WithMany("Beers")
                        .HasForeignKey("BreweryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Orders.Models.Brewery", b =>
                {
                    b.HasOne("Orders.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Orders.Models.Review", b =>
                {
                    b.HasOne("Orders.Models.Brewery", "Brewery")
                        .WithMany("Reviews")
                        .HasForeignKey("BreweryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Orders.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Orders.Models.UserBeerTried", b =>
                {
                    b.HasOne("Orders.Models.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Orders.Models.User", "User")
                        .WithMany("UserBeersTried")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Orders.Models.UserPurchasedItem", b =>
                {
                    b.HasOne("Orders.Models.Brewery", "Brewery")
                        .WithMany()
                        .HasForeignKey("BreweryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Orders.Models.User", "User")
                        .WithMany("UserPurchasedItems")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}