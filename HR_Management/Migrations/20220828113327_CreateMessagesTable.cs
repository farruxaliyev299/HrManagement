using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_Management.Migrations
{
    public partial class CreateMessagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    FromUserId = table.Column<string>(nullable: true),
                    ToUserId = table.Column<string>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SendMessages_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SendMessages_AspNetUsers_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SendMessages_FromUserId",
                table: "SendMessages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SendMessages_ToUserId",
                table: "SendMessages",
                column: "ToUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendMessages");
        }
    }
}
