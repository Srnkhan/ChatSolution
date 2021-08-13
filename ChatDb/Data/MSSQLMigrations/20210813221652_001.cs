using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatDb.Data.MSSQLMigrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    ChannelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UserNickName = table.Column<string>(nullable: true),
                    UserMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Channel",
                columns: new[] { "Id", "ChannelName", "CreatedDate", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("22a1d9b0-f452-46e3-9e4a-e13739ab1dd9"), "First Channel", new DateTime(2021, 8, 14, 1, 16, 52, 93, DateTimeKind.Local).AddTicks(8517), null },
                    { new Guid("86c3c0d1-7d93-4286-9f39-acd12983dc07"), "Second Channel", new DateTime(2021, 8, 14, 1, 16, 52, 97, DateTimeKind.Local).AddTicks(7749), null },
                    { new Guid("3ce2a3be-93b3-45d6-97fa-22600e7f5a91"), "Third Channel", new DateTime(2021, 8, 14, 1, 16, 52, 97, DateTimeKind.Local).AddTicks(8165), null },
                    { new Guid("5feb5b2a-8d19-40f6-b142-6d6e26849a5c"), "Fourth Channel", new DateTime(2021, 8, 14, 1, 16, 52, 97, DateTimeKind.Local).AddTicks(8240), null },
                    { new Guid("699e8187-5ff9-4f58-befe-a3d8e2a2bdc8"), "Fifth Channel", new DateTime(2021, 8, 14, 1, 16, 52, 97, DateTimeKind.Local).AddTicks(8309), null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "Message");
        }
    }
}
