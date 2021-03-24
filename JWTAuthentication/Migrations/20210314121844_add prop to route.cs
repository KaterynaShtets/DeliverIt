using Microsoft.EntityFrameworkCore.Migrations;

namespace JWTAuthentication.Migrations
{
    public partial class addproptoroute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_City_FromCityId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_City_ToCityId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_FromCityId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_ToCityId",
                table: "Package");

            migrationBuilder.AddColumn<double>(
                name: "Distance",
                table: "Route",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "ToCityId",
                table: "Package",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromCityId",
                table: "Package",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Route");

            migrationBuilder.AlterColumn<int>(
                name: "ToCityId",
                table: "Package",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FromCityId",
                table: "Package",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Package_FromCityId",
                table: "Package",
                column: "FromCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_ToCityId",
                table: "Package",
                column: "ToCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_City_FromCityId",
                table: "Package",
                column: "FromCityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Package_City_ToCityId",
                table: "Package",
                column: "ToCityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
