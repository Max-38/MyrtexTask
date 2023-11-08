using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyrtexTask.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "DateOfEmployment", "Department", "FullName", "Salary" },
                values: new object[,]
                {
                    { new Guid("12406d89-efec-48ef-bab6-fcb1c048bb5d"), new DateTime(1995, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Разработчики", "Аполин С.Ю.", 170000m },
                    { new Guid("162c8c91-bc25-4228-9ffc-16bae5c499d2"), new DateTime(1998, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Маркетинг", "Елисеева А.С.", 90000m },
                    { new Guid("23f0ef2b-5a57-43d1-b6fc-9c47d56fed9c"), new DateTime(1991, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Управление", "Савин В.Г.", 200000m },
                    { new Guid("5c752058-3da8-41a6-ae30-ae555749e7a2"), new DateTime(1996, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Поддержка", "Воронов Е.В.", 100000m },
                    { new Guid("9a34cea2-91fe-4d9a-a746-291601bd574a"), new DateTime(1997, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Разработчики", "Волков А.В.", 130000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Id",
                table: "Employees",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
