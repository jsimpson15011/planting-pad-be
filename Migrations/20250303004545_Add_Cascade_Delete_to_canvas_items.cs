using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace plantingPadBE.Migrations
{
    /// <inheritdoc />
    public partial class Add_Cascade_Delete_to_canvas_items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CanvasItems_PlantingPads_PlantingPadId",
                table: "CanvasItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlantingPadId",
                table: "CanvasItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CanvasItems_PlantingPads_PlantingPadId",
                table: "CanvasItems",
                column: "PlantingPadId",
                principalTable: "PlantingPads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CanvasItems_PlantingPads_PlantingPadId",
                table: "CanvasItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlantingPadId",
                table: "CanvasItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CanvasItems_PlantingPads_PlantingPadId",
                table: "CanvasItems",
                column: "PlantingPadId",
                principalTable: "PlantingPads",
                principalColumn: "Id");
        }
    }
}
