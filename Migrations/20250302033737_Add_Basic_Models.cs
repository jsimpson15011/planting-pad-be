using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace plantingPadBE.Migrations
{
    /// <inheritdoc />
    public partial class Add_Basic_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBigDog",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "CanvasItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    X = table.Column<float>(type: "real", nullable: false),
                    Y = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    BufferHeight = table.Column<float>(type: "real", nullable: false),
                    BufferWidth = table.Column<float>(type: "real", nullable: false),
                    CatalogItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanvasItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Species = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StartIndoors = table.Column<bool>(type: "bit", nullable: true),
                    StartIndoorsWeeksLower = table.Column<int>(type: "int", nullable: true),
                    StartIndoorsWeeksUpper = table.Column<int>(type: "int", nullable: true),
                    StartOutdoorsWeeksLower = table.Column<int>(type: "int", nullable: true),
                    StartOutdoorsWeeksUpper = table.Column<int>(type: "int", nullable: true),
                    PlantingInstructions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    HardinessZoneLower = table.Column<int>(type: "int", nullable: true),
                    HardinessZoneUpper = table.Column<int>(type: "int", nullable: true),
                    DaysToGerminate = table.Column<int>(type: "int", nullable: true),
                    DaysToMaturity = table.Column<int>(type: "int", nullable: true),
                    RowSpacing = table.Column<float>(type: "real", nullable: true),
                    PlantSpacing = table.Column<float>(type: "real", nullable: true),
                    MinSunLower = table.Column<int>(type: "int", nullable: true),
                    MinSunUpper = table.Column<int>(type: "int", nullable: true),
                    MinWaterLower = table.Column<int>(type: "int", nullable: true),
                    MinWaterUpper = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanvasItems");

            migrationBuilder.DropTable(
                name: "CatalogItems");

            migrationBuilder.AddColumn<bool>(
                name: "IsBigDog",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
