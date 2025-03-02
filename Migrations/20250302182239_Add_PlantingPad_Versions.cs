using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace plantingPadBE.Migrations
{
    /// <inheritdoc />
    public partial class Add_PlantingPad_Versions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PlantingPads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PlantingPads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "PlantingPadVersion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlantingPadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SerializedData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingPadVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantingPadVersion_PlantingPads_PlantingPadId",
                        column: x => x.PlantingPadId,
                        principalTable: "PlantingPads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantingPadVersion_PlantingPadId",
                table: "PlantingPadVersion",
                column: "PlantingPadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantingPadVersion");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PlantingPads");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PlantingPads");
        }
    }
}
