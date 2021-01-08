using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yalta.Migrations
{
    public partial class addprofil2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Profil_Id",
                table: "User");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "User",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Profil",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Profil_User_Id",
                table: "Profil",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profil_User_Id",
                table: "Profil");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "User",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Profil",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Profil_Id",
                table: "User",
                column: "Id",
                principalTable: "Profil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
