using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MushroomingLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mushroomings_Locations_LocationId",
                table: "Mushroomings");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Mushroomings");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Mushroomings");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Mushroomings");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Mushroomings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Mushroomings_Locations_LocationId",
                table: "Mushroomings",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mushroomings_Locations_LocationId",
                table: "Mushroomings");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationId",
                table: "Mushroomings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Mushroomings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Mushroomings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Mushroomings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Mushroomings_Locations_LocationId",
                table: "Mushroomings",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
