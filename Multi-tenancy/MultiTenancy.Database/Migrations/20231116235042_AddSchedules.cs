using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MultiTenancy.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSchedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tenant = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Note", "Tenant", "Title" },
                values: new object[,]
                {
                    { new Guid("3c89a400-9be7-4bb0-b1e5-b98b70b611b7"), "Oklahoma #1", "Oklahoma", "The Oklahoma Schedule #1" },
                    { new Guid("a15d827e-3f08-49e4-b84d-f5ba82679bc1"), "Oklahoma #2", "Oklahoma", "The Oklahoma Schedule #2" },
                    { new Guid("d07125be-3834-4360-ad55-a28951ba9ea9"), "Sidearm u note", "Sidearmu", "The Sidearm Schedule" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
