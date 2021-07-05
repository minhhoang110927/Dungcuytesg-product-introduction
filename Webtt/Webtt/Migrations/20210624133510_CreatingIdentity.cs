using Microsoft.EntityFrameworkCore.Migrations;

namespace Webtt.Migrations
{
    public partial class CreatingIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "74a0a71c-46d1-47cc-94c7-c17ed7e9f448", "deaefc3e-adab-4353-bb83-77f1dc440ff8", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "05da4fa9-2898-4d91-a383-2d13830346f4", "231088b5-fb61-460b-b022-bb5a3b520c68", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "75d6966b-3213-4491-9a8e-627a203d8350", "ce64fd00-ca91-470d-b572-b30aaf79364b", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38b918ff-13be-4e01-b71f-c61c078bc15f", "649de8b9-7f97-43e1-8ba2-366ef82c779f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
