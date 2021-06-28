using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class updateusercustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUseCase_Customers_CustomerId",
                table: "UserUseCase");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "UserUseCase",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserUseCase_CustomerId",
                table: "UserUseCase",
                newName: "IX_UserUseCase_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUseCase_Users_UserId",
                table: "UserUseCase",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUseCase_Users_UserId",
                table: "UserUseCase");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserUseCase",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserUseCase_UserId",
                table: "UserUseCase",
                newName: "IX_UserUseCase_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUseCase_Customers_CustomerId",
                table: "UserUseCase",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
