using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yalta.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Label = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Password = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profil",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    BirthdayDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Gender = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profil_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreferredPeriod",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Lower = table.Column<int>(type: "int", nullable: false),
                    Upper = table.Column<int>(type: "int", nullable: false),
                    ProfilId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferredPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreferredPeriod_Profil_ProfilId",
                        column: x => x.ProfilId,
                        principalTable: "Profil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaPreferredPeriod",
                columns: table => new
                {
                    AreasId = table.Column<long>(type: "bigint", nullable: false),
                    PreferredPeriodsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaPreferredPeriod", x => new { x.AreasId, x.PreferredPeriodsId });
                    table.ForeignKey(
                        name: "FK_AreaPreferredPeriod_Area_AreasId",
                        column: x => x.AreasId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaPreferredPeriod_PreferredPeriod_PreferredPeriodsId",
                        column: x => x.PreferredPeriodsId,
                        principalTable: "PreferredPeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaPreferredPeriod_PreferredPeriodsId",
                table: "AreaPreferredPeriod",
                column: "PreferredPeriodsId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferredPeriod_ProfilId",
                table: "PreferredPeriod",
                column: "ProfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaPreferredPeriod");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "PreferredPeriod");

            migrationBuilder.DropTable(
                name: "Profil");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
