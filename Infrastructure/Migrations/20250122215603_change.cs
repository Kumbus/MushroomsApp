using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropTable(
                name: "MushroomingUser");*/

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Mushroomings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("a7b06772-0a0f-45f8-b34b-08dd3b151955"));

            migrationBuilder.CreateIndex(
                name: "IX_Mushroomings_UserId",
                table: "Mushroomings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mushroomings_AspNetUsers_UserId",
                table: "Mushroomings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mushroomings_AspNetUsers_UserId",
                table: "Mushroomings");

            migrationBuilder.DropIndex(
                name: "IX_Mushroomings_UserId",
                table: "Mushroomings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Mushroomings");

            migrationBuilder.CreateTable(
                name: "MushroomingUser",
                columns: table => new
                {
                    MushroomingsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MushroomingUser", x => new { x.MushroomingsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MushroomingUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MushroomingUser_Mushroomings_MushroomingsId",
                        column: x => x.MushroomingsId,
                        principalTable: "Mushroomings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MushroomingUser_UsersId",
                table: "MushroomingUser",
                column: "UsersId");
        }
    }
}
