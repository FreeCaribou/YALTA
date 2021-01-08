using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yalta.Migrations
{
    public partial class addprofil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "User",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "Profil",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BirthdayDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profil", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Profil_Id",
                table: "User",
                column: "Id",
                principalTable: "Profil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Profil_Id",
                table: "User");

            migrationBuilder.DropTable(
                name: "Profil");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "User",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
