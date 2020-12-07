using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class updateconfigurationmobile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Cars_CarId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Mobiles_CarId",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Mobiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Mobiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_CarId",
                table: "Mobiles",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_Cars_CarId",
                table: "Mobiles",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
