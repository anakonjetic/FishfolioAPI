using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishfolioAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FishFavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FishFamilyIncompatibility_FishFamilies_CompatibleId",
                table: "FishFamilyIncompatibility");

            migrationBuilder.RenameColumn(
                name: "CompatibleId",
                table: "FishFamilyIncompatibility",
                newName: "IncompatibleId");

            migrationBuilder.RenameIndex(
                name: "IX_FishFamilyIncompatibility_CompatibleId",
                table: "FishFamilyIncompatibility",
                newName: "IX_FishFamilyIncompatibility_IncompatibleId");

            migrationBuilder.CreateTable(
                name: "FavoriteFish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteFish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteFish_Fish_FishId",
                        column: x => x.FishId,
                        principalTable: "Fish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteFish_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteFish_FishId",
                table: "FavoriteFish",
                column: "FishId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteFish_UserId",
                table: "FavoriteFish",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FishFamilyIncompatibility_FishFamilies_IncompatibleId",
                table: "FishFamilyIncompatibility",
                column: "IncompatibleId",
                principalTable: "FishFamilies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FishFamilyIncompatibility_FishFamilies_IncompatibleId",
                table: "FishFamilyIncompatibility");

            migrationBuilder.DropTable(
                name: "FavoriteFish");

            migrationBuilder.RenameColumn(
                name: "IncompatibleId",
                table: "FishFamilyIncompatibility",
                newName: "CompatibleId");

            migrationBuilder.RenameIndex(
                name: "IX_FishFamilyIncompatibility_IncompatibleId",
                table: "FishFamilyIncompatibility",
                newName: "IX_FishFamilyIncompatibility_CompatibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_FishFamilyIncompatibility_FishFamilies_CompatibleId",
                table: "FishFamilyIncompatibility",
                column: "CompatibleId",
                principalTable: "FishFamilies",
                principalColumn: "Id");
        }
    }
}
