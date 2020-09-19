using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddStatusForOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserName1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserName1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserName1",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserName",
                table: "Orders",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserName",
                table: "Orders",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserName",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "UserName1",
                table: "Orders",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserName1",
                table: "Orders",
                column: "UserName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserName1",
                table: "Orders",
                column: "UserName1",
                principalTable: "Users",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
