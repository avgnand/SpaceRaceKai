using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceRaceKai.Server.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PopulationChange = table.Column<int>(type: "int", nullable: false),
                    ApprovalChange = table.Column<int>(type: "int", nullable: false),
                    TechChange = table.Column<int>(type: "int", nullable: false),
                    IndustryChange = table.Column<int>(type: "int", nullable: false),
                    WealthChange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEffects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemperatureRating = table.Column<int>(type: "int", nullable: false),
                    LandCover = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DecisionEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventEffectIdA = table.Column<int>(type: "int", nullable: false),
                    EventEffectIdB = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecisionEvents_EventEffects_EventEffectIdA",
                        column: x => x.EventEffectIdA,
                        principalTable: "EventEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecisionEvents_EventEffects_EventEffectIdB",
                        column: x => x.EventEffectIdB,
                        principalTable: "EventEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colonies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    ApprovalRating = table.Column<int>(type: "int", nullable: false),
                    TechLevel = table.Column<int>(type: "int", nullable: false),
                    IndustryLevel = table.Column<int>(type: "int", nullable: false),
                    WealthLevel = table.Column<int>(type: "int", nullable: false),
                    Playthroughs = table.Column<int>(type: "int", nullable: false),
                    PlanetTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colonies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colonies_PlanetTypes_PlanetTypeId",
                        column: x => x.PlanetTypeId,
                        principalTable: "PlanetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorldEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanetTypeId = table.Column<int>(type: "int", nullable: false),
                    EventEffectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorldEvents_EventEffects_EventEffectId",
                        column: x => x.EventEffectId,
                        principalTable: "EventEffects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorldEvents_PlanetTypes_PlanetTypeId",
                        column: x => x.PlanetTypeId,
                        principalTable: "PlanetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colonies_PlanetTypeId",
                table: "Colonies",
                column: "PlanetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DecisionEvents_EventEffectIdA",
                table: "DecisionEvents",
                column: "EventEffectIdA");

            migrationBuilder.CreateIndex(
                name: "IX_DecisionEvents_EventEffectIdB",
                table: "DecisionEvents",
                column: "EventEffectIdB");

            migrationBuilder.CreateIndex(
                name: "IX_WorldEvents_EventEffectId",
                table: "WorldEvents",
                column: "EventEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldEvents_PlanetTypeId",
                table: "WorldEvents",
                column: "PlanetTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colonies");

            migrationBuilder.DropTable(
                name: "DecisionEvents");

            migrationBuilder.DropTable(
                name: "WorldEvents");

            migrationBuilder.DropTable(
                name: "EventEffects");

            migrationBuilder.DropTable(
                name: "PlanetTypes");
        }
    }
}
