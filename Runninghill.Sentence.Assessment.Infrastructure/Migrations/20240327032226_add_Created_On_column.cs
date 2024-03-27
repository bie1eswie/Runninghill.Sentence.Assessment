using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Runninghill.Sentence.Assessment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_Created_On_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Sentences",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Sentences");
        }
    }
}
