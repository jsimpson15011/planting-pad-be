using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace plantingPadBE.Migrations
{
    /// <inheritdoc />
    public partial class Add_PlantingPad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlantingPadId",
                table: "CanvasItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlantingPads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingPads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantingPads_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CanvasItems_PlantingPadId",
                table: "CanvasItems",
                column: "PlantingPadId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingPads_UserId",
                table: "PlantingPads",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CanvasItems_PlantingPads_PlantingPadId",
                table: "CanvasItems",
                column: "PlantingPadId",
                principalTable: "PlantingPads",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CanvasItems_PlantingPads_PlantingPadId",
                table: "CanvasItems");

            migrationBuilder.DropTable(
                name: "PlantingPads");

            migrationBuilder.DropIndex(
                name: "IX_CanvasItems_PlantingPadId",
                table: "CanvasItems");

            migrationBuilder.DropColumn(
                name: "PlantingPadId",
                table: "CanvasItems");
        }
    }
}
