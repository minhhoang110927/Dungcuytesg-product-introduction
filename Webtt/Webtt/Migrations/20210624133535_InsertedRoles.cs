using Microsoft.EntityFrameworkCore.Migrations;

namespace Webtt.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05da4fa9-2898-4d91-a383-2d13830346f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74a0a71c-46d1-47cc-94c7-c17ed7e9f448");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cea4385d-10ab-4707-a1bc-671d354ef543", "96bc378f-acee-4d76-b59b-74e4b64945d7", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "595ac084-6702-473e-adcd-a73be3648391", "9cffd73f-1acd-4a4c-96a5-6a383cec5432", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "595ac084-6702-473e-adcd-a73be3648391");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cea4385d-10ab-4707-a1bc-671d354ef543");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74a0a71c-46d1-47cc-94c7-c17ed7e9f448", "deaefc3e-adab-4353-bb83-77f1dc440ff8", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05da4fa9-2898-4d91-a383-2d13830346f4", "231088b5-fb61-460b-b022-bb5a3b520c68", "Administrator", "ADMINISTRATOR" });
        }
    }
}
