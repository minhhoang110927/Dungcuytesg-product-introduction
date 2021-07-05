using Microsoft.EntityFrameworkCore.Migrations;

namespace Webtt.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2565affb-8273-4f0d-bcca-cd3a5d6cec64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a3020ae-3ad2-4c75-bb6e-2bdeb5328b63");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75d6966b-3213-4491-9a8e-627a203d8350", "ce64fd00-ca91-470d-b572-b30aaf79364b", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38b918ff-13be-4e01-b71f-c61c078bc15f", "649de8b9-7f97-43e1-8ba2-366ef82c779f", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b918ff-13be-4e01-b71f-c61c078bc15f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75d6966b-3213-4491-9a8e-627a203d8350");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a3020ae-3ad2-4c75-bb6e-2bdeb5328b63", "96094adc-5def-4b9b-a4d1-80b7c37087eb", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2565affb-8273-4f0d-bcca-cd3a5d6cec64", "872ed4e5-b1da-4295-97c0-13e376960a52", "Administrator", "ADMINISTRATOR" });
        }
    }
}
