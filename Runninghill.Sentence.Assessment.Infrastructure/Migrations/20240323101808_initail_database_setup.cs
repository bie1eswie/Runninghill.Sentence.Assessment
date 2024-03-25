using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Runninghill.Sentence.Assessment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initail_database_setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WordGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    WordType = table.Column<int>(type: "int", nullable: false),
                    WordGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordItem_WordGroup",
                        column: x => x.WordGroupId,
                        principalTable: "WordGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordItems_WordGroupId",
                table: "WordItems",
                column: "WordGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordItems");

            migrationBuilder.DropTable(
                name: "WordGroups");
        }
    }
}
