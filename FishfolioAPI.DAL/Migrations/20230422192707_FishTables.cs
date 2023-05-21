using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FishfolioAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FishTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FishFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habitats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FishFamilyCompatibility",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    CompatibilityId = table.Column<int>(type: "int", nullable: false),
                    CompatibleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishFamilyCompatibility", x => new { x.ParentId, x.CompatibilityId });
                    table.ForeignKey(
                        name: "FK_FishFamilyCompatibility_FishFamilies_CompatibleId",
                        column: x => x.CompatibleId,
                        principalTable: "FishFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FishFamilyCompatibility_FishFamilies_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FishFamilies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FishFamilyIncompatibility",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    CompatibilityId = table.Column<int>(type: "int", nullable: false),
                    CompatibleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishFamilyIncompatibility", x => new { x.ParentId, x.CompatibilityId });
                    table.ForeignKey(
                        name: "FK_FishFamilyIncompatibility_FishFamilies_CompatibleId",
                        column: x => x.CompatibleId,
                        principalTable: "FishFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FishFamilyIncompatibility_FishFamilies_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FishFamilies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterTypeId = table.Column<int>(type: "int", nullable: false),
                    FishFamilyId = table.Column<int>(type: "int", nullable: false),
                    HabitatId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinSchoolSize = table.Column<int>(type: "int", nullable: false),
                    AvgSchoolSize = table.Column<int>(type: "int", nullable: false),
                    MinAquariumSizeInL = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxNumberOfSameGender = table.Column<int>(type: "int", nullable: false),
                    AvailableInStore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fish_FishFamilies_FishFamilyId",
                        column: x => x.FishFamilyId,
                        principalTable: "FishFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fish_Habitats_HabitatId",
                        column: x => x.HabitatId,
                        principalTable: "Habitats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fish_WaterTypes_WaterTypeId",
                        column: x => x.WaterTypeId,
                        principalTable: "WaterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FishFamilies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tetra" },
                    { 2, "Rasbora" },
                    { 3, "Gourami" },
                    { 4, "Barb" },
                    { 5, "Cichlid" },
                    { 6, "Betta" }
                });

            migrationBuilder.InsertData(
                table: "Habitats",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tropical waters of South America" });

            migrationBuilder.InsertData(
                table: "WaterTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Salty" },
                    { 2, "Fresh" }
                });

            migrationBuilder.InsertData(
                table: "FishFamilyCompatibility",
                columns: new[] { "CompatibilityId", "ParentId", "CompatibleId" },
                values: new object[,]
                {
                    { 2, 1, null },
                    { 3, 1, null },
                    { 4, 1, null }
                });

            migrationBuilder.InsertData(
                table: "FishFamilyIncompatibility",
                columns: new[] { "CompatibilityId", "ParentId", "CompatibleId" },
                values: new object[,]
                {
                    { 5, 1, null },
                    { 6, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fish_FishFamilyId",
                table: "Fish",
                column: "FishFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_HabitatId",
                table: "Fish",
                column: "HabitatId");

            migrationBuilder.CreateIndex(
                name: "IX_Fish_WaterTypeId",
                table: "Fish",
                column: "WaterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FishFamilyCompatibility_CompatibleId",
                table: "FishFamilyCompatibility",
                column: "CompatibleId");

            migrationBuilder.CreateIndex(
                name: "IX_FishFamilyIncompatibility_CompatibleId",
                table: "FishFamilyIncompatibility",
                column: "CompatibleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fish");

            migrationBuilder.DropTable(
                name: "FishFamilyCompatibility");

            migrationBuilder.DropTable(
                name: "FishFamilyIncompatibility");

            migrationBuilder.DropTable(
                name: "Habitats");

            migrationBuilder.DropTable(
                name: "WaterTypes");

            migrationBuilder.DropTable(
                name: "FishFamilies");
        }
    }
}
