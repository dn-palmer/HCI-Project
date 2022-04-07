using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BitWise.Migrations
{
    public partial class fkupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BitWiseUserId",
                table: "Trophies",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trophies_BitWiseUserId",
                table: "Trophies",
                column: "BitWiseUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trophies_AspNetUsers_BitWiseUserId",
                table: "Trophies",
                column: "BitWiseUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trophies_AspNetUsers_BitWiseUserId",
                table: "Trophies");

            migrationBuilder.DropIndex(
                name: "IX_Trophies_BitWiseUserId",
                table: "Trophies");

            migrationBuilder.DropColumn(
                name: "BitWiseUserId",
                table: "Trophies");
        }
    }
}
