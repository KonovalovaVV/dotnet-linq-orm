using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    Hash = table.Column<string>(maxLength: 1024, nullable: false),
                    Salt = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    AssetId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(16,3)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    Comment = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentId", "Type" },
                values: new object[,]
                {
                    { new Guid("bba4892d-aa7d-48cd-b993-7c6c4ad7795b"), "IVW3WG4", new Guid("00000000-0000-0000-0000-000000000000"), 1 },
                    { new Guid("21c24ee8-400f-425f-827f-3a5a63cfc41a"), "4MWTC6C", new Guid("00000000-0000-0000-0000-000000000000"), 1 },
                    { new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), "6AD4L8L", new Guid("00000000-0000-0000-0000-000000000000"), 1 },
                    { new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), "H2CA6CC", new Guid("00000000-0000-0000-0000-000000000000"), 0 },
                    { new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), "V2QAPRS", new Guid("00000000-0000-0000-0000-000000000000"), 0 },
                    { new Guid("00744991-0be3-49b1-a210-dfa198507abe"), "ZRVY3CN", new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), 1 },
                    { new Guid("1399213d-7895-42c8-9eca-48161c848d50"), "XVH5BJR", new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), 0 },
                    { new Guid("63ef9870-05cc-4658-a065-660c8f0d26f4"), "W4H5Y0N", new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), 0 },
                    { new Guid("2c894af1-88c0-4ec4-881a-17c7fff4773c"), "SORASTL", new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), 0 },
                    { new Guid("c8b61123-108e-4829-955a-06b6d6765f7d"), "XL4OEW3", new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Hash", "Name", "Salt" },
                values: new object[,]
                {
                    { new Guid("12e7dc3a-1b52-4811-a848-1e748168db53"), "PVQS9JY", "59CP5IO", "INLM3CM", "UJMWRZF" },
                    { new Guid("0c072651-0a8c-4819-82be-03f91183934e"), "UM5DK9P", "NS3YCHK", "TVAJFSS", "TZB6S9P" },
                    { new Guid("093d4313-7992-42f6-85c3-8a15e3ccbd2b"), "RFKCBJM", "0GWED1U", "HM9PHNB", "8FFTW1L" },
                    { new Guid("10a43690-3d99-48bf-894a-2fbdc4296ad8"), "QP3LN7O", "Q9WCV2D", "65EOH2J", "72XL7YD" },
                    { new Guid("e68808ab-20fa-4191-ad88-f662ec6fb9da"), "9PNPVIT", "LYJE831", "TRT5PZB", "THPI47E" }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("23dcddec-ea26-4ac2-a0f0-4ee19293d71c"), "Q7ZC1NN", new Guid("12e7dc3a-1b52-4811-a848-1e748168db53") },
                    { new Guid("df8a6e5e-f402-462b-976c-9d307ec12ee7"), "MMVM71M", new Guid("e68808ab-20fa-4191-ad88-f662ec6fb9da") },
                    { new Guid("11f8fdde-907b-4789-bfc4-4c957863cf08"), "9CYIGU4", new Guid("e68808ab-20fa-4191-ad88-f662ec6fb9da") },
                    { new Guid("7245285b-415c-497f-8e05-46601832d5a6"), "FWYL16D", new Guid("10a43690-3d99-48bf-894a-2fbdc4296ad8") },
                    { new Guid("7aae3717-f242-43b2-a74a-50dc23a1b355"), "7K4J545", new Guid("10a43690-3d99-48bf-894a-2fbdc4296ad8") },
                    { new Guid("c34312b6-0d0f-4ef7-b41f-dc8452416b69"), "K8FHF40", new Guid("10a43690-3d99-48bf-894a-2fbdc4296ad8") },
                    { new Guid("9ae88eb3-6566-4bc9-a324-d2f02be4fe97"), "NW9L5Q0", new Guid("10a43690-3d99-48bf-894a-2fbdc4296ad8") },
                    { new Guid("1180a574-d677-49e9-9109-bc5492e60ca4"), "RBX40PJ", new Guid("093d4313-7992-42f6-85c3-8a15e3ccbd2b") },
                    { new Guid("e9ccf1cd-714a-405e-bf7d-4924693e80fb"), "2RPHVLI", new Guid("093d4313-7992-42f6-85c3-8a15e3ccbd2b") },
                    { new Guid("ecceeaed-787c-4750-bb40-f5d517e5c3db"), "DK1SB3F", new Guid("093d4313-7992-42f6-85c3-8a15e3ccbd2b") },
                    { new Guid("e8138054-fa82-41d6-8151-a0beae0e9ce3"), "XYO6E9B", new Guid("093d4313-7992-42f6-85c3-8a15e3ccbd2b") },
                    { new Guid("83a5f742-d236-4dae-8aad-74ad63af0433"), "D8V5OYG", new Guid("0c072651-0a8c-4819-82be-03f91183934e") },
                    { new Guid("78c7348d-88ff-41f0-8259-0d97675a5f9c"), "RNHNM83", new Guid("0c072651-0a8c-4819-82be-03f91183934e") },
                    { new Guid("ae4ca653-cc94-4b79-90f6-3cd3da759bf7"), "PWRWZUR", new Guid("0c072651-0a8c-4819-82be-03f91183934e") },
                    { new Guid("ca8d21c5-e52f-4332-a334-1cf88f33c8ad"), "7QB45WO", new Guid("0c072651-0a8c-4819-82be-03f91183934e") },
                    { new Guid("0ea9e1f1-4c0c-4bfa-875a-d31750df7414"), "8B8OP60", new Guid("12e7dc3a-1b52-4811-a848-1e748168db53") },
                    { new Guid("69c6d469-00f8-4f28-9f04-f7e17df4f5f7"), "R4ZVJ5X", new Guid("12e7dc3a-1b52-4811-a848-1e748168db53") },
                    { new Guid("bc4e06fe-7a90-4b59-958a-1c3c1aebe354"), "ZWH188J", new Guid("12e7dc3a-1b52-4811-a848-1e748168db53") },
                    { new Guid("f3583cf4-e20f-4eae-8740-e47074979b1d"), "LG5KM7S", new Guid("e68808ab-20fa-4191-ad88-f662ec6fb9da") },
                    { new Guid("91d62eae-5a19-406f-914d-84feb1e5f182"), "Q4AL63U", new Guid("e68808ab-20fa-4191-ad88-f662ec6fb9da") }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "AssetId", "CategoryId", "Comment", "Date" },
                values: new object[,]
                {
                    { new Guid("e2e3eac2-11cd-4eb7-992b-e5816f2a8cf0"), 0.0299506141012304m, new Guid("23dcddec-ea26-4ac2-a0f0-4ee19293d71c"), new Guid("bba4892d-aa7d-48cd-b993-7c6c4ad7795b"), null, new DateTime(2020, 4, 1, 16, 23, 58, 382, DateTimeKind.Local).AddTicks(393) },
                    { new Guid("286daf36-cabf-4281-9059-89f8fe09514a"), 0.2269078601277m, new Guid("7aae3717-f242-43b2-a74a-50dc23a1b355"), new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5973) },
                    { new Guid("9bb944db-b2c7-4466-9dfb-296206deb9df"), 0.996931511907341m, new Guid("7aae3717-f242-43b2-a74a-50dc23a1b355"), new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5569) },
                    { new Guid("42982135-d98b-4e0e-93cd-98c28ac9e6e7"), 0.86153335723166m, new Guid("7aae3717-f242-43b2-a74a-50dc23a1b355"), new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5159) },
                    { new Guid("c6e6ec09-2487-461d-a656-0af03e045dd0"), 0.885307124296812m, new Guid("c34312b6-0d0f-4ef7-b41f-dc8452416b69"), new Guid("2c894af1-88c0-4ec4-881a-17c7fff4773c"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6717) },
                    { new Guid("52557bad-9f18-4aaa-b99d-9dc5a932f41f"), 0.578589509976371m, new Guid("c34312b6-0d0f-4ef7-b41f-dc8452416b69"), new Guid("2c894af1-88c0-4ec4-881a-17c7fff4773c"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6313) },
                    { new Guid("c18dc8e1-c00f-4a44-8214-2772d8713694"), 0.0884600771071669m, new Guid("c34312b6-0d0f-4ef7-b41f-dc8452416b69"), new Guid("2c894af1-88c0-4ec4-881a-17c7fff4773c"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5869) },
                    { new Guid("aa7d25e6-b792-452a-83e3-30f877c25e83"), 0.876170352043663m, new Guid("c34312b6-0d0f-4ef7-b41f-dc8452416b69"), new Guid("2c894af1-88c0-4ec4-881a-17c7fff4773c"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5461) },
                    { new Guid("c17298a4-7bf3-4fea-b171-dbea1fc4bb40"), 0.576904108085159m, new Guid("c34312b6-0d0f-4ef7-b41f-dc8452416b69"), new Guid("2c894af1-88c0-4ec4-881a-17c7fff4773c"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5039) },
                    { new Guid("db1d8806-0ae2-4eca-94fa-c83d65600352"), 0.302197379200811m, new Guid("9ae88eb3-6566-4bc9-a324-d2f02be4fe97"), new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6617) },
                    { new Guid("e49a5e46-b1d7-444b-a192-a30d4566ee09"), 0.936476256668789m, new Guid("9ae88eb3-6566-4bc9-a324-d2f02be4fe97"), new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6177) },
                    { new Guid("b19f18c6-5347-4150-a45d-009ad1a3dbec"), 0.972879442839361m, new Guid("9ae88eb3-6566-4bc9-a324-d2f02be4fe97"), new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5766) },
                    { new Guid("f5487ad3-0d03-4d36-8b51-9e187fbf08ea"), 0.194135709290456m, new Guid("9ae88eb3-6566-4bc9-a324-d2f02be4fe97"), new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5363) },
                    { new Guid("c7eaac8c-9a8e-477c-9c7f-445679b36eb6"), 0.32080914514177m, new Guid("9ae88eb3-6566-4bc9-a324-d2f02be4fe97"), new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(4919) },
                    { new Guid("ce79df20-08df-47d0-9a8f-1624d2148a48"), 0.790492565739198m, new Guid("1180a574-d677-49e9-9109-bc5492e60ca4"), new Guid("63ef9870-05cc-4658-a065-660c8f0d26f4"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6895) },
                    { new Guid("d9098e12-df53-4e7d-8835-9a821ad6c4bf"), 0.167315946504155m, new Guid("1180a574-d677-49e9-9109-bc5492e60ca4"), new Guid("63ef9870-05cc-4658-a065-660c8f0d26f4"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6499) },
                    { new Guid("88369920-ee45-4a36-b234-d0a3b99f8623"), 0.759320997520965m, new Guid("1180a574-d677-49e9-9109-bc5492e60ca4"), new Guid("63ef9870-05cc-4658-a065-660c8f0d26f4"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6058) },
                    { new Guid("05f55b52-db91-4faa-8b69-82fbc1b02a3a"), 0.897685491432289m, new Guid("1180a574-d677-49e9-9109-bc5492e60ca4"), new Guid("63ef9870-05cc-4658-a065-660c8f0d26f4"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5649) },
                    { new Guid("005ef2ba-404f-4946-80dd-2169efaec089"), 0.557433252482411m, new Guid("1180a574-d677-49e9-9109-bc5492e60ca4"), new Guid("63ef9870-05cc-4658-a065-660c8f0d26f4"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5238) },
                    { new Guid("c1506e49-cf77-4c6d-953a-de4eae0ec136"), 0.47761610545107m, new Guid("e9ccf1cd-714a-405e-bf7d-4924693e80fb"), new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6795) },
                    { new Guid("024b7fa2-37ac-4441-8849-6c2055ab33f2"), 0.944188711673109m, new Guid("e9ccf1cd-714a-405e-bf7d-4924693e80fb"), new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6393) },
                    { new Guid("4e860fa5-5598-4647-9716-3930f0b5cef7"), 0.747592647908066m, new Guid("e9ccf1cd-714a-405e-bf7d-4924693e80fb"), new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5950) },
                    { new Guid("b03859a7-3832-43a9-99fa-8af8334b887b"), 0.996493846176422m, new Guid("7aae3717-f242-43b2-a74a-50dc23a1b355"), new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6414) },
                    { new Guid("e56fb071-9782-4fa8-9eb2-c2b37afe2b7d"), 0.985820349764926m, new Guid("e9ccf1cd-714a-405e-bf7d-4924693e80fb"), new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5548) },
                    { new Guid("39d9983a-d52a-45c7-8f5d-c4b2e99282e4"), 0.0189952887683154m, new Guid("7aae3717-f242-43b2-a74a-50dc23a1b355"), new Guid("0fc0895e-3770-4751-b418-8214dd05fdb2"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6817) },
                    { new Guid("27003c64-30a5-469c-a027-ce09a957d5ed"), 0.339487810777262m, new Guid("7245285b-415c-497f-8e05-46601832d5a6"), new Guid("2c894af1-88c0-4ec4-881a-17c7fff4773c"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5669) },
                    { new Guid("8905f7a5-9540-46ec-96ee-36ea2deb9e01"), 0.0467357919769063m, new Guid("91d62eae-5a19-406f-914d-84feb1e5f182"), new Guid("c8b61123-108e-4829-955a-06b6d6765f7d"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6096) },
                    { new Guid("f9fb14f8-66ab-4a98-9d54-0cba77b73513"), 0.323947774862846m, new Guid("91d62eae-5a19-406f-914d-84feb1e5f182"), new Guid("c8b61123-108e-4829-955a-06b6d6765f7d"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5688) },
                    { new Guid("56c0876d-cbd2-48b4-9d36-a067a187d83e"), 0.0253863642110426m, new Guid("91d62eae-5a19-406f-914d-84feb1e5f182"), new Guid("c8b61123-108e-4829-955a-06b6d6765f7d"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5278) },
                    { new Guid("e558e5b6-756a-4655-9e27-1419e33ed8ef"), 0.397217169588998m, new Guid("f3583cf4-e20f-4eae-8740-e47074979b1d"), new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6837) },
                    { new Guid("44dc5b0e-0ed9-48c4-b237-b6dc27d276ab"), 0.78705709697076m, new Guid("f3583cf4-e20f-4eae-8740-e47074979b1d"), new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6433) },
                    { new Guid("d2249b9c-1be8-4713-8d65-b3a1b123bf3a"), 0.837867657578489m, new Guid("f3583cf4-e20f-4eae-8740-e47074979b1d"), new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5998) },
                    { new Guid("358634f9-be26-4b22-8b66-b8de2e2908f2"), 0.00918711722324934m, new Guid("f3583cf4-e20f-4eae-8740-e47074979b1d"), new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5589) },
                    { new Guid("7f545a56-3ead-4f88-998d-30b7ded096e9"), 0.221420383183947m, new Guid("f3583cf4-e20f-4eae-8740-e47074979b1d"), new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5178) },
                    { new Guid("1afd0748-f91a-4046-8cd4-370676295c6d"), 0.781967277537085m, new Guid("df8a6e5e-f402-462b-976c-9d307ec12ee7"), new Guid("c8b61123-108e-4829-955a-06b6d6765f7d"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6736) },
                    { new Guid("bb765a8c-91aa-4a28-a432-7a35773a54a5"), 0.75576456857648m, new Guid("df8a6e5e-f402-462b-976c-9d307ec12ee7"), new Guid("c8b61123-108e-4829-955a-06b6d6765f7d"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6335) },
                    { new Guid("57642168-a2cf-44ea-bd17-67f0ccee158e"), 0.300216242810812m, new Guid("df8a6e5e-f402-462b-976c-9d307ec12ee7"), new Guid("c8b61123-108e-4829-955a-06b6d6765f7d"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5890) },
                    { new Guid("9193aa5e-27ce-436d-996a-d451dcc34999"), 0.36667112138433m, new Guid("df8a6e5e-f402-462b-976c-9d307ec12ee7"), new Guid("c8b61123-108e-4829-955a-06b6d6765f7d"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5483) },
                    { new Guid("93c94f0c-a7ab-457d-80c5-3d9fd14bdde4"), 0.729424388021894m, new Guid("df8a6e5e-f402-462b-976c-9d307ec12ee7"), new Guid("c8b61123-108e-4829-955a-06b6d6765f7d"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5060) },
                    { new Guid("3ce1fb3a-1c14-46be-a036-d129578a3410"), 0.436602003144381m, new Guid("11f8fdde-907b-4789-bfc4-4c957863cf08"), new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6637) },
                    { new Guid("981c66c7-2dc1-47c2-85bd-f88d9c2eef14"), 0.897454203524373m, new Guid("11f8fdde-907b-4789-bfc4-4c957863cf08"), new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6196) },
                    { new Guid("e001fafc-69e3-43da-8f6a-caccdc620523"), 0.640175224114291m, new Guid("11f8fdde-907b-4789-bfc4-4c957863cf08"), new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5785) },
                    { new Guid("59d82998-5986-4300-a575-e138cfeacce1"), 0.90073975916055m, new Guid("11f8fdde-907b-4789-bfc4-4c957863cf08"), new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5382) },
                    { new Guid("a07999a7-ada9-4d4b-84e1-b4cd8d0ac7b7"), 0.551171180583151m, new Guid("11f8fdde-907b-4789-bfc4-4c957863cf08"), new Guid("9b7883e9-748b-43f6-836d-8d45e0fe8728"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(4940) },
                    { new Guid("14b92f0b-2be8-46a9-9404-f0bc2e94141e"), 0.801668509282949m, new Guid("7245285b-415c-497f-8e05-46601832d5a6"), new Guid("2c894af1-88c0-4ec4-881a-17c7fff4773c"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6919) },
                    { new Guid("2c270bf7-644c-476f-b0a7-e7cb34137c5e"), 0.280203755144125m, new Guid("7245285b-415c-497f-8e05-46601832d5a6"), new Guid("2c894af1-88c0-4ec4-881a-17c7fff4773c"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6518) },
                    { new Guid("d48d6e2e-757a-4816-9423-bbdedaac8298"), 0.146312655949179m, new Guid("7245285b-415c-497f-8e05-46601832d5a6"), new Guid("2c894af1-88c0-4ec4-881a-17c7fff4773c"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6078) },
                    { new Guid("bd1822df-bbb0-4955-81cd-83cc0e13a428"), 0.594198351071309m, new Guid("7245285b-415c-497f-8e05-46601832d5a6"), new Guid("2c894af1-88c0-4ec4-881a-17c7fff4773c"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5257) },
                    { new Guid("80a938e7-5176-4ee2-8fc8-0915741ff54d"), 0.695734268378343m, new Guid("e9ccf1cd-714a-405e-bf7d-4924693e80fb"), new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5135) },
                    { new Guid("06aa4b25-1fdb-4e3c-b52a-815ebf6ced52"), 0.485155759605186m, new Guid("ecceeaed-787c-4750-bb40-f5d517e5c3db"), new Guid("63ef9870-05cc-4658-a065-660c8f0d26f4"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6698) },
                    { new Guid("24fbae34-ccf6-4996-b787-bfa5e421dd4d"), 0.425046026438962m, new Guid("ecceeaed-787c-4750-bb40-f5d517e5c3db"), new Guid("63ef9870-05cc-4658-a065-660c8f0d26f4"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6294) },
                    { new Guid("4b15986a-10ad-4a48-a284-5fe5e052c89c"), 0.802730774415066m, new Guid("ca8d21c5-e52f-4332-a334-1cf88f33c8ad"), new Guid("21c24ee8-400f-425f-827f-3a5a63cfc41a"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5322) },
                    { new Guid("054c2647-001c-4d78-9653-5e72699d09ef"), 0.505493903302352m, new Guid("ca8d21c5-e52f-4332-a334-1cf88f33c8ad"), new Guid("21c24ee8-400f-425f-827f-3a5a63cfc41a"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(4839) },
                    { new Guid("f5989e75-6bf9-49b7-8c7c-14056351c25b"), 0.209564393949492m, new Guid("0ea9e1f1-4c0c-4bfa-875a-d31750df7414"), new Guid("00744991-0be3-49b1-a210-dfa198507abe"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6857) },
                    { new Guid("ba1c0e08-c495-45c9-b769-629e275f50d1"), 0.888238636259101m, new Guid("0ea9e1f1-4c0c-4bfa-875a-d31750df7414"), new Guid("00744991-0be3-49b1-a210-dfa198507abe"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6454) },
                    { new Guid("869c1ff4-7586-4e1e-9604-1a716538aa74"), 0.953463109654124m, new Guid("0ea9e1f1-4c0c-4bfa-875a-d31750df7414"), new Guid("00744991-0be3-49b1-a210-dfa198507abe"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6017) },
                    { new Guid("05e0b60c-e516-4f35-a131-37a7fcf42569"), 0.191899084575427m, new Guid("0ea9e1f1-4c0c-4bfa-875a-d31750df7414"), new Guid("00744991-0be3-49b1-a210-dfa198507abe"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5608) },
                    { new Guid("2d0a2e38-1e17-4b42-9678-f6e51bac9c45"), 0.562892019545143m, new Guid("0ea9e1f1-4c0c-4bfa-875a-d31750df7414"), new Guid("00744991-0be3-49b1-a210-dfa198507abe"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5198) },
                    { new Guid("314beccb-01e8-46c9-945d-3ec1d52a4dc0"), 0.100357300648632m, new Guid("69c6d469-00f8-4f28-9f04-f7e17df4f5f7"), new Guid("bba4892d-aa7d-48cd-b993-7c6c4ad7795b"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6756) },
                    { new Guid("28c9042c-7b0e-4b5f-b11f-eab2008ac229"), 0.690572485183632m, new Guid("69c6d469-00f8-4f28-9f04-f7e17df4f5f7"), new Guid("bba4892d-aa7d-48cd-b993-7c6c4ad7795b"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6354) },
                    { new Guid("6fac3535-963e-4bff-84d9-0ad03e6bf85e"), 0.656312388207909m, new Guid("69c6d469-00f8-4f28-9f04-f7e17df4f5f7"), new Guid("bba4892d-aa7d-48cd-b993-7c6c4ad7795b"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5909) },
                    { new Guid("5a22ab31-b39a-4890-8385-54807f7f63ec"), 0.558213454465481m, new Guid("69c6d469-00f8-4f28-9f04-f7e17df4f5f7"), new Guid("bba4892d-aa7d-48cd-b993-7c6c4ad7795b"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5503) },
                    { new Guid("7d1983a5-b178-4d79-9645-ac469c3011c7"), 0.987133041949539m, new Guid("69c6d469-00f8-4f28-9f04-f7e17df4f5f7"), new Guid("bba4892d-aa7d-48cd-b993-7c6c4ad7795b"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5081) },
                    { new Guid("3b994310-1344-462c-9085-2e2e6f6a1911"), 0.453236327717656m, new Guid("bc4e06fe-7a90-4b59-958a-1c3c1aebe354"), new Guid("00744991-0be3-49b1-a210-dfa198507abe"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6659) },
                    { new Guid("6e206ae3-53f1-47a4-a044-16f18ec926ec"), 0.124092500248967m, new Guid("bc4e06fe-7a90-4b59-958a-1c3c1aebe354"), new Guid("00744991-0be3-49b1-a210-dfa198507abe"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6215) },
                    { new Guid("5d4aaf65-38cc-4160-9590-8179ba22a097"), 0.636413871141343m, new Guid("bc4e06fe-7a90-4b59-958a-1c3c1aebe354"), new Guid("00744991-0be3-49b1-a210-dfa198507abe"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5808) },
                    { new Guid("c95aab66-d691-497f-ace8-5fdfa696e0cc"), 0.230678658574204m, new Guid("bc4e06fe-7a90-4b59-958a-1c3c1aebe354"), new Guid("00744991-0be3-49b1-a210-dfa198507abe"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5401) },
                    { new Guid("3fd2b360-5969-461f-a67e-a47edacc0b48"), 0.862305555894182m, new Guid("bc4e06fe-7a90-4b59-958a-1c3c1aebe354"), new Guid("00744991-0be3-49b1-a210-dfa198507abe"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(4976) },
                    { new Guid("18328327-5568-4ba5-a191-cabae1e7026f"), 0.722459453494502m, new Guid("23dcddec-ea26-4ac2-a0f0-4ee19293d71c"), new Guid("bba4892d-aa7d-48cd-b993-7c6c4ad7795b"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6557) },
                    { new Guid("1a019f25-6525-4f89-b430-0f06681c4b6b"), 0.652973875241808m, new Guid("23dcddec-ea26-4ac2-a0f0-4ee19293d71c"), new Guid("bba4892d-aa7d-48cd-b993-7c6c4ad7795b"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6116) },
                    { new Guid("70e522fb-2c97-46cd-882e-d2fdd162f48d"), 0.964572537208242m, new Guid("23dcddec-ea26-4ac2-a0f0-4ee19293d71c"), new Guid("bba4892d-aa7d-48cd-b993-7c6c4ad7795b"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5709) },
                    { new Guid("a7018c09-c235-4af9-bd07-6b9929c512cd"), 0.544164116282092m, new Guid("23dcddec-ea26-4ac2-a0f0-4ee19293d71c"), new Guid("bba4892d-aa7d-48cd-b993-7c6c4ad7795b"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5299) },
                    { new Guid("74926ee6-8fdf-4fd3-b867-fdc63fae090a"), 0.382168749990952m, new Guid("ca8d21c5-e52f-4332-a334-1cf88f33c8ad"), new Guid("21c24ee8-400f-425f-827f-3a5a63cfc41a"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5728) },
                    { new Guid("1a14bd80-6d6b-462f-a903-bafc2b8d2756"), 0.48125141322671m, new Guid("ca8d21c5-e52f-4332-a334-1cf88f33c8ad"), new Guid("21c24ee8-400f-425f-827f-3a5a63cfc41a"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6139) },
                    { new Guid("3141c810-8aa7-4524-824a-058f7728017d"), 0.572106967480903m, new Guid("ca8d21c5-e52f-4332-a334-1cf88f33c8ad"), new Guid("21c24ee8-400f-425f-827f-3a5a63cfc41a"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6577) },
                    { new Guid("e59d4710-991c-44a4-a773-91ddbb274868"), 0.00547851855190402m, new Guid("ae4ca653-cc94-4b79-90f6-3cd3da759bf7"), new Guid("1399213d-7895-42c8-9eca-48161c848d50"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(4997) },
                    { new Guid("78be4070-7534-470a-b01d-22f9565b9094"), 0.089711253107391m, new Guid("ecceeaed-787c-4750-bb40-f5d517e5c3db"), new Guid("63ef9870-05cc-4658-a065-660c8f0d26f4"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5849) },
                    { new Guid("06a936c5-a383-44b7-adde-244f8774dca5"), 0.250470375293154m, new Guid("ecceeaed-787c-4750-bb40-f5d517e5c3db"), new Guid("63ef9870-05cc-4658-a065-660c8f0d26f4"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5441) },
                    { new Guid("fb63b691-b2d1-4a20-867f-00acd8724e00"), 0.971693047774813m, new Guid("ecceeaed-787c-4750-bb40-f5d517e5c3db"), new Guid("63ef9870-05cc-4658-a065-660c8f0d26f4"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5018) },
                    { new Guid("8d8825f5-838a-4b61-bbaf-6c8309feeea3"), 0.888253568153946m, new Guid("e8138054-fa82-41d6-8151-a0beae0e9ce3"), new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6598) },
                    { new Guid("c47fd02e-e3cf-4275-ab7d-1ca22154bb42"), 0.821765965699109m, new Guid("e8138054-fa82-41d6-8151-a0beae0e9ce3"), new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6157) },
                    { new Guid("55f0a296-d148-43b1-8cb6-6c3cbdb1c1c8"), 0.000725552440027498m, new Guid("e8138054-fa82-41d6-8151-a0beae0e9ce3"), new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5747) },
                    { new Guid("c8d5b667-e44d-47ba-85b5-b8cb4296ef7a"), 0.413952119375557m, new Guid("e8138054-fa82-41d6-8151-a0beae0e9ce3"), new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5343) },
                    { new Guid("4bc878ab-911e-423a-afc2-f0ec075fd409"), 0.227213436843461m, new Guid("e8138054-fa82-41d6-8151-a0beae0e9ce3"), new Guid("4465055f-f51c-4eab-8a9e-00381104b17f"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(4894) },
                    { new Guid("ba2d05b2-5b7a-49e4-8e6a-1ea4312729fc"), 0.286646054259802m, new Guid("83a5f742-d236-4dae-8aad-74ad63af0433"), new Guid("1399213d-7895-42c8-9eca-48161c848d50"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6876) },
                    { new Guid("a6da231d-7aaa-465f-a4ab-d31429ce33b1"), 0.528248491942998m, new Guid("83a5f742-d236-4dae-8aad-74ad63af0433"), new Guid("1399213d-7895-42c8-9eca-48161c848d50"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6477) },
                    { new Guid("334f8c8f-d690-4eb0-81b9-f451e5a9a1e9"), 0.990569157987167m, new Guid("91d62eae-5a19-406f-914d-84feb1e5f182"), new Guid("c8b61123-108e-4829-955a-06b6d6765f7d"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6538) },
                    { new Guid("eee84f62-4d45-435f-888b-22f4669f3312"), 0.817785053894755m, new Guid("83a5f742-d236-4dae-8aad-74ad63af0433"), new Guid("1399213d-7895-42c8-9eca-48161c848d50"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6037) },
                    { new Guid("8192b804-4438-4f9b-bba4-a5b038e30869"), 0.774823381460655m, new Guid("83a5f742-d236-4dae-8aad-74ad63af0433"), new Guid("1399213d-7895-42c8-9eca-48161c848d50"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5218) },
                    { new Guid("d1c0ef6a-a4e8-482d-becd-3d062637ecfb"), 0.565485076776466m, new Guid("78c7348d-88ff-41f0-8259-0d97675a5f9c"), new Guid("21c24ee8-400f-425f-827f-3a5a63cfc41a"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6775) },
                    { new Guid("48819415-3d2d-4f33-a2d2-09c588f594c3"), 0.603381159996326m, new Guid("78c7348d-88ff-41f0-8259-0d97675a5f9c"), new Guid("21c24ee8-400f-425f-827f-3a5a63cfc41a"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6374) },
                    { new Guid("ce6ef68a-430d-412b-a888-177d4f02c44c"), 0.831220396715785m, new Guid("78c7348d-88ff-41f0-8259-0d97675a5f9c"), new Guid("21c24ee8-400f-425f-827f-3a5a63cfc41a"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5929) },
                    { new Guid("88f137c9-cdaa-4bb3-a53a-ee5d6caa3ecf"), 0.589283811668532m, new Guid("78c7348d-88ff-41f0-8259-0d97675a5f9c"), new Guid("21c24ee8-400f-425f-827f-3a5a63cfc41a"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5522) },
                    { new Guid("dec247cf-d4e7-4f4a-aef5-66284c64a5ed"), 0.89461384243081m, new Guid("78c7348d-88ff-41f0-8259-0d97675a5f9c"), new Guid("21c24ee8-400f-425f-827f-3a5a63cfc41a"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5115) },
                    { new Guid("64d700be-2272-416a-b14b-877f69b8f061"), 0.567934433728426m, new Guid("ae4ca653-cc94-4b79-90f6-3cd3da759bf7"), new Guid("1399213d-7895-42c8-9eca-48161c848d50"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6678) },
                    { new Guid("f687f184-c6be-468f-97d5-4c4d559c54db"), 0.635036762633844m, new Guid("ae4ca653-cc94-4b79-90f6-3cd3da759bf7"), new Guid("1399213d-7895-42c8-9eca-48161c848d50"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6234) },
                    { new Guid("dc831135-5d8a-4437-bf0f-8ab02b9121b9"), 0.234462475047662m, new Guid("ae4ca653-cc94-4b79-90f6-3cd3da759bf7"), new Guid("1399213d-7895-42c8-9eca-48161c848d50"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5828) },
                    { new Guid("05716cec-d194-470d-af5f-2c2b77808394"), 0.935574950620334m, new Guid("ae4ca653-cc94-4b79-90f6-3cd3da759bf7"), new Guid("1399213d-7895-42c8-9eca-48161c848d50"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5421) },
                    { new Guid("fd9f939f-84ca-463d-9015-829f74c9617c"), 0.598562804329471m, new Guid("83a5f742-d236-4dae-8aad-74ad63af0433"), new Guid("1399213d-7895-42c8-9eca-48161c848d50"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(5627) },
                    { new Guid("e3b41033-d308-4ed5-81ab-09ff06538835"), 0.242325993833284m, new Guid("91d62eae-5a19-406f-914d-84feb1e5f182"), new Guid("c8b61123-108e-4829-955a-06b6d6765f7d"), null, new DateTime(2020, 4, 1, 16, 23, 58, 383, DateTimeKind.Local).AddTicks(6939) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserId",
                table: "Assets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AssetId",
                table: "Transactions",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
