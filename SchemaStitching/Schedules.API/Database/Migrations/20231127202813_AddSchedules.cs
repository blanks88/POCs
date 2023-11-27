using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Schedules.API.Database.Migrations
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
                    Tenant = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Note = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "DeletedAt", "ModifiedAt", "Note", "Tenant", "Title" },
                values: new object[,]
                {
                    { new Guid("3a7c06b5-d658-47d4-a9c4-c228435a3980"), new Guid("402ab577-379f-4e42-86ea-9ecf2e454dd5"), new DateTime(2023, 11, 27, 14, 28, 12, 824, DateTimeKind.Utc).AddTicks(2660), null, null, "Oklahoma #1", "Oklahoma", "The Oklahoma Schedule #1" },
                    { new Guid("a339325e-edba-4c64-9863-fb8a5d6eaea7"), new Guid("402ab577-379f-4e42-86ea-9ecf2e454dd5"), new DateTime(2023, 11, 27, 14, 28, 12, 824, DateTimeKind.Utc).AddTicks(2620), null, null, "Sidearm u note / category #1", "Sidearmu", "The Sidearm Schedule #1" },
                    { new Guid("b0356b8e-9fed-4df1-a94c-ae3b3c316d53"), new Guid("be4cc0d7-029c-45b6-a121-726a53ccd21a"), new DateTime(2023, 11, 27, 14, 28, 12, 824, DateTimeKind.Utc).AddTicks(2660), null, null, "Oklahoma #2", "Oklahoma", "The Oklahoma Schedule #2" },
                    { new Guid("b4b90521-c8dd-4a16-abab-ebf41efa60f7"), new Guid("0fdc6594-102f-4f05-872b-6746b65bdee9"), new DateTime(2023, 11, 27, 14, 28, 12, 824, DateTimeKind.Utc).AddTicks(2670), null, null, "Oklahoma #3", "Oklahoma", "The Oklahoma Schedule #3" },
                    { new Guid("d5015ad1-1ba7-4314-83d0-d223b394ee73"), new Guid("0fdc6594-102f-4f05-872b-6746b65bdee9"), new DateTime(2023, 11, 27, 14, 28, 12, 824, DateTimeKind.Utc).AddTicks(2670), null, null, "Oklahoma #3-1", "Oklahoma", "The Oklahoma Schedule #3.1" }
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
