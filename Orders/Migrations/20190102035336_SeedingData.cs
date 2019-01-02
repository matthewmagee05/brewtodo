using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orders.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeerTypes",
                columns: table => new
                {
                    BeerTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeerTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerTypes", x => x.BeerTypeID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateAbbr = table.Column<string>(nullable: true),
                    StateFullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentityID = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ProfileImage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    BreweryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    StateID = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    BusinessHours = table.Column<string>(nullable: true),
                    HasTShirt = table.Column<bool>(nullable: false),
                    HasMug = table.Column<bool>(nullable: false),
                    HasGrowler = table.Column<bool>(nullable: false),
                    HasFood = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.BreweryID);
                    table.ForeignKey(
                        name: "FK_Breweries_States_StateID",
                        column: x => x.StateID,
                        principalTable: "States",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    BeerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeerName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ABV = table.Column<double>(nullable: false),
                    BeerTypeID = table.Column<int>(nullable: false),
                    BreweryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.BeerID);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryID",
                        column: x => x.BreweryID,
                        principalTable: "Breweries",
                        principalColumn: "BreweryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReviewDescription = table.Column<string>(nullable: true),
                    Rating = table.Column<float>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    BreweryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Breweries_BreweryID",
                        column: x => x.BreweryID,
                        principalTable: "Breweries",
                        principalColumn: "BreweryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPurchasedItems",
                columns: table => new
                {
                    UserPurchasedItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    BreweryID = table.Column<int>(nullable: false),
                    PurchasedTShirt = table.Column<bool>(nullable: false),
                    PurchasedMug = table.Column<bool>(nullable: false),
                    PurchasedGrowler = table.Column<bool>(nullable: false),
                    TriedFood = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPurchasedItems", x => x.UserPurchasedItemID);
                    table.ForeignKey(
                        name: "FK_UserPurchasedItems_Breweries_BreweryID",
                        column: x => x.BreweryID,
                        principalTable: "Breweries",
                        principalColumn: "BreweryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPurchasedItems_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBeersTried",
                columns: table => new
                {
                    UserBeerTriedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    BeerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBeersTried", x => x.UserBeerTriedID);
                    table.ForeignKey(
                        name: "FK_UserBeersTried_Beers_BeerID",
                        column: x => x.BeerID,
                        principalTable: "Beers",
                        principalColumn: "BeerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBeersTried_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BeerTypes",
                columns: new[] { "BeerTypeID", "BeerTypeName" },
                values: new object[,]
                {
                    { 1, "IPA" },
                    { 2, "Ale" },
                    { 3, "Pilsner" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "StateAbbr", "StateFullName" },
                values: new object[,]
                {
                    { 12, "HI", "Hawaii" },
                    { 11, "GA", "Georgia" },
                    { 10, "FL", "Florida" },
                    { 9, "DC", "District of Columbia" },
                    { 8, "DE", "Delaware" },
                    { 7, "CT", "Connecticut" },
                    { 5, "CA", "California" },
                    { 4, "AR", "Arkansas" },
                    { 3, "AZ", "Arizona" },
                    { 2, "AK", "Alaska" },
                    { 1, "AL", "Alabama" },
                    { 6, "CO", "Colorado" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "FirstName", "IdentityID", "LastName", "ProfileImage", "Username" },
                values: new object[,]
                {
                    { 4, "Jim", "432fsf", "watt", 23432, "McShartFace" },
                    { 1, "Mateo", "213fds", "Magee", 123213, "Poop_Pants" },
                    { 2, "John", "fdsf", "SMith", 2433, "Diabeto" },
                    { 3, "Jack", "213ffdds", "What", 544234, "Sharty" },
                    { 5, "James", "324fsf", "Brady", 4324234, "Diablo" }
                });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "BreweryID", "Address", "BusinessHours", "Description", "HasFood", "HasGrowler", "HasMug", "HasTShirt", "ImageURL", "Name", "PhoneNumber", "StateID", "ZipCode" },
                values: new object[] { 1, "123 Main Street", "24/7", "A Fun Beer House", true, true, false, true, "http://www.example.com", "Beer House", "123456789", 4, "76705" });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "BeerID", "ABV", "BeerName", "BeerTypeID", "BreweryID", "Description" },
                values: new object[] { 1, 5.5, "Sam Adams", 1, 1, "Boston's Tastiest beer" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewID", "BreweryID", "Rating", "ReviewDescription", "UserID" },
                values: new object[] { 1, 1, 4f, "Best Place Ever", 2 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewID", "BreweryID", "Rating", "ReviewDescription", "UserID" },
                values: new object[] { 2, 1, 2f, "It Was OK", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryID",
                table: "Beers",
                column: "BreweryID");

            migrationBuilder.CreateIndex(
                name: "IX_Breweries_StateID",
                table: "Breweries",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BreweryID",
                table: "Reviews",
                column: "BreweryID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserID",
                table: "Reviews",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBeersTried_BeerID",
                table: "UserBeersTried",
                column: "BeerID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBeersTried_UserID",
                table: "UserBeersTried",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPurchasedItems_BreweryID",
                table: "UserPurchasedItems",
                column: "BreweryID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPurchasedItems_UserID",
                table: "UserPurchasedItems",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerTypes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserBeersTried");

            migrationBuilder.DropTable(
                name: "UserPurchasedItems");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Breweries");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
