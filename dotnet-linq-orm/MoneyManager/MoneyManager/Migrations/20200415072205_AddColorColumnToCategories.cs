using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddColorColumnToCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e0175740-7ef9-47e2-a7ac-00d0c6c07e63"));

            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "Name", "ParentCategoryId", "Type" },
                values: new object[] { new Guid("9f3ee034-bb6e-4e89-a050-a3899e4fa0a8"), 2309453, "Transport", null, 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "Name", "ParentCategoryId", "Type" },
                values: new object[] { new Guid("f1126ef2-c701-4ad9-9cc6-80d3f1527f8a"), 2444109, "Food", null, 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "Name", "ParentCategoryId", "Type" },
                values: new object[,]
                {
                    { new Guid("b5b2d8db-5558-4613-91d0-634167579424"), 2309453, "Taxi", new Guid("9f3ee034-bb6e-4e89-a050-a3899e4fa0a8"), 2 },
                    { new Guid("053ca69a-963a-44f6-8bad-3a488ee68951"), 2309453, "Bus", new Guid("9f3ee034-bb6e-4e89-a050-a3899e4fa0a8"), 2 },
                    { new Guid("44f728a8-fb90-4c18-879a-67fde42c654d"), 2309453, "Sweet", new Guid("f1126ef2-c701-4ad9-9cc6-80d3f1527f8a"), 2 },
                    { new Guid("1ad92cde-b4e0-4f6c-be63-c60a57d4da53"), 2309453, "Dairy products", new Guid("f1126ef2-c701-4ad9-9cc6-80d3f1527f8a"), 2 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "Name", "ParentCategoryId", "Type" },
                values: new object[] { new Guid("d9b44a60-f7a1-4b53-90ca-ba2927c6b922"), 2309453, "Sweet", new Guid("44f728a8-fb90-4c18-879a-67fde42c654d"), 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "Name", "ParentCategoryId", "Type" },
                values: new object[] { new Guid("e784cd63-c32b-4710-8308-5c4770f70518"), 2309453, "Milk", new Guid("1ad92cde-b4e0-4f6c-be63-c60a57d4da53"), 2 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "Name", "ParentCategoryId", "Type" },
                values: new object[] { new Guid("82d5eb50-e377-4f32-9e90-32107ff8de12"), 2309453, "Cheese", new Guid("1ad92cde-b4e0-4f6c-be63-c60a57d4da53"), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("053ca69a-963a-44f6-8bad-3a488ee68951"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("82d5eb50-e377-4f32-9e90-32107ff8de12"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b5b2d8db-5558-4613-91d0-634167579424"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d9b44a60-f7a1-4b53-90ca-ba2927c6b922"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e784cd63-c32b-4710-8308-5c4770f70518"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1ad92cde-b4e0-4f6c-be63-c60a57d4da53"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44f728a8-fb90-4c18-879a-67fde42c654d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9f3ee034-bb6e-4e89-a050-a3899e4fa0a8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f1126ef2-c701-4ad9-9cc6-80d3f1527f8a"));

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId", "Type" },
                values: new object[] { new Guid("e0175740-7ef9-47e2-a7ac-00d0c6c07e63"), "Food", null, 2 });
        }
    }
}
