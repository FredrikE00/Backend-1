using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_1.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
    CREATE TABLE Products (
	Id int not null identity primary key,
	Name nvarchar(150) not null,
	Description nvarchar(max) not null,
	Price money not null,
	InStock bit
)");

            migrationBuilder.Sql(@"
    CREATE TABLE DeliveryTypes (
	Id int not null identity primary key,
	Name nvarchar(50) not null unique
)");

            migrationBuilder.Sql(@"
    CREATE TABLE Addresses (
	Id int not null identity primary key,
	AdressLine nvarchar(100) not null,
	HouseNr smallint null,
	ZipCode char(5) not null,
	City nvarchar(50) not null
)");

            migrationBuilder.Sql(@"
    CREATE TABLE Users (
	Id int not null identity primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Email varchar(100) not null unique
)
GO");

            migrationBuilder.Sql(@"
    CREATE TABLE UserHashes (
	UserId int not null references Users(Id) primary key,
	UserHash varchar(max) not null,
	UserSalt varchar(max) not null
)");

            migrationBuilder.Sql(@"
    CREATE TABLE UserAddresses (
	Id int not null identity primary key,
	UserId int not null references Users(Id),
	AddressId int not null references Addresses(Id)
)");

            migrationBuilder.Sql(@"
    CREATE TABLE Orders (
	Id int not null identity primary key,
	UserId int not null references Users(Id),
	OrderDate datetimeoffset not null,
	OurReference nvarchar(100) null,
	Status nvarchar(50) not null,
	DeliveryTypeId int not null references DeliveryTypes(Id),
	InvoiceAddressId int not null references UserAddresses(Id),
	DeliveryAddressId int not null references UserAddresses(Id)
)
GO");

            

            migrationBuilder.Sql(
                @"
                CREATE TABLE OrderLines (
	OrderId int not null references Orders(Id),
	ProductId int not null references Products(Id),
	Quantity int not null default 1,
	UnitPrice money not null default 0

	primary key (OrderId, ProductId)
)
GO");

            

            

            

            

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryTypes");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UserHashes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
