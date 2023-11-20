using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Categories.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tenant = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Abbrev = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ShortDisplay = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Abbrev", "CreatedAt", "DeletedAt", "ModifiedAt", "ShortDisplay", "ShortName", "Tenant", "Title" },
                values: new object[,]
                {
                    { new Guid("0fdc6594-102f-4f05-872b-6746b65bdee9"), "OC2", new DateTime(2023, 11, 20, 14, 10, 19, 977, DateTimeKind.Utc).AddTicks(2600), null, null, "Oklahoma Category #2", "OklCategory#2", "Oklahoma", "The Oklahoma Category #2" },
                    { new Guid("402ab577-379f-4e42-86ea-9ecf2e454dd5"), "SC", new DateTime(2023, 11, 20, 14, 10, 19, 977, DateTimeKind.Utc).AddTicks(2560), null, null, "Sidearm Category", "SCat", "Sidearmu", "The Sidearm Category" },
                    { new Guid("be4cc0d7-029c-45b6-a121-726a53ccd21a"), "OC1", new DateTime(2023, 11, 20, 14, 10, 19, 977, DateTimeKind.Utc).AddTicks(2590), null, null, "Oklahoma Category #1", "OklCategory#1", "Oklahoma", "The Oklahoma Category #1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
