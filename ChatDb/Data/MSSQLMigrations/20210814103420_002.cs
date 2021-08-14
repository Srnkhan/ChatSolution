using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatDb.Data.MSSQLMigrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Message",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Channel",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

            migrationBuilder.UpdateData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("22a1d9b0-f452-46e3-9e4a-e13739ab1dd9"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("3ce2a3be-93b3-45d6-97fa-22600e7f5a91"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("5feb5b2a-8d19-40f6-b142-6d6e26849a5c"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("699e8187-5ff9-4f58-befe-a3d8e2a2bdc8"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("86c3c0d1-7d93-4286-9f39-acd12983dc07"),
                column: "CreatedDate",
                value: null);

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Message",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Channel",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("22a1d9b0-f452-46e3-9e4a-e13739ab1dd9"),
                column: "CreatedDate",
                value: new DateTime(2021, 8, 14, 1, 16, 52, 93, DateTimeKind.Local).AddTicks(8517));

            migrationBuilder.UpdateData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("3ce2a3be-93b3-45d6-97fa-22600e7f5a91"),
                column: "CreatedDate",
                value: new DateTime(2021, 8, 14, 1, 16, 52, 97, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("5feb5b2a-8d19-40f6-b142-6d6e26849a5c"),
                column: "CreatedDate",
                value: new DateTime(2021, 8, 14, 1, 16, 52, 97, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("699e8187-5ff9-4f58-befe-a3d8e2a2bdc8"),
                column: "CreatedDate",
                value: new DateTime(2021, 8, 14, 1, 16, 52, 97, DateTimeKind.Local).AddTicks(8309));

            migrationBuilder.UpdateData(
                table: "Channel",
                keyColumn: "Id",
                keyValue: new Guid("86c3c0d1-7d93-4286-9f39-acd12983dc07"),
                column: "CreatedDate",
                value: new DateTime(2021, 8, 14, 1, 16, 52, 97, DateTimeKind.Local).AddTicks(7749));
        }
    }
}
