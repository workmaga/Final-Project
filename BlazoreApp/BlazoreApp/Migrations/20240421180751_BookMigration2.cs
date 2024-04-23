using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazoreApp.Migrations
{
    /// <inheritdoc />
    public partial class BookMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "MoneyAmount", "UserName" },
                values: new object[] { 0, "George R.R. Martin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "MoneyAmount", "UserName" },
                values: new object[] { 0, "J.K. Rowling" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "MoneyAmount", "UserName" },
                values: new object[,]
                {
                    { 3, 0, "Neal Stephenson" },
                    { 4, 0, "Steven King" },
                    { 5, 0, "Roald Dahl" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "MoneyAmount", "UserName" },
                values: new object[] { 1000, "Gabe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "MoneyAmount", "UserName" },
                values: new object[] { 20000, "Mikayla" });
        }
    }
}
