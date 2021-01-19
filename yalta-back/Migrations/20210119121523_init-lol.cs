using Microsoft.EntityFrameworkCore.Migrations;

namespace Yalta.Migrations
{
    public partial class initlol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HatedPersonalities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    First = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Second = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Third = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Fourth = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Fifth = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HatedPersonalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HatedPersonalities_Profil_Id",
                        column: x => x.Id,
                        principalTable: "Profil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LovedPersonalities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    First = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Second = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Third = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Fourth = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Fifth = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LovedPersonalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LovedPersonalities_Profil_Id",
                        column: x => x.Id,
                        principalTable: "Profil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HatedPersonalities");

            migrationBuilder.DropTable(
                name: "LovedPersonalities");
        }
    }
}
