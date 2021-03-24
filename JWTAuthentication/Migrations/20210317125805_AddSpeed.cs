using Microsoft.EntityFrameworkCore.Migrations;

namespace JWTAuthentication.Migrations
{
    public partial class AddSpeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_City_FromCityId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_City_ToCityId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_FromCityId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_ToCityId",
                table: "Route");

            migrationBuilder.AddColumn<double>(
                name: "AverageSpeedPerKm",
                table: "Transport",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "ToCityId",
                table: "Route",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromCityId",
                table: "Route",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageSpeedPerKm",
                table: "Transport");

            migrationBuilder.AlterColumn<int>(
                name: "ToCityId",
                table: "Route",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FromCityId",
                table: "Route",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Route_FromCityId",
                table: "Route",
                column: "FromCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_ToCityId",
                table: "Route",
                column: "ToCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_City_FromCityId",
                table: "Route",
                column: "FromCityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_City_ToCityId",
                table: "Route",
                column: "ToCityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
