using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatDb.Data.MySQLMigrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
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
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UserNickName = table.Column<string>(nullable: true),
                    UserMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChannelMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    ChannelId = table.Column<Guid>(nullable: false),
                    MessageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChannelMessage_Channel_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelMessage_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Channel",
                columns: new[] { "Id", "ChannelName", "CreatedDate", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("22a1d9b0-f452-46e3-9e4a-e13739ab1dd9"), "First Channel", null, null },
                    { new Guid("86c3c0d1-7d93-4286-9f39-acd12983dc07"), "Second Channel", null, null },
                    { new Guid("3ce2a3be-93b3-45d6-97fa-22600e7f5a91"), "Third Channel", null, null },
                    { new Guid("5feb5b2a-8d19-40f6-b142-6d6e26849a5c"), "Fourth Channel", null, null },
                    { new Guid("699e8187-5ff9-4f58-befe-a3d8e2a2bdc8"), "Fifth Channel", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelMessage_ChannelId",
                table: "ChannelMessage",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelMessage_MessageId",
                table: "ChannelMessage",
                column: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChannelMessage");

            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropTable(
                name: "Message");
        }
    }
}
