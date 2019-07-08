using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Sistem",
                table: "Uyruklar",
                columns: new[] { "Id", "Adi", "Aktif", "EklemeZamani", "EkleyenId", "GuncellemeZamani", "GuncelleyenId" },
                values: new object[] { 1, "TC", true, new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 1, new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                schema: "Sistem",
                table: "Uyruklar",
                columns: new[] { "Id", "Adi", "Aktif", "EklemeZamani", "EkleyenId", "GuncellemeZamani", "GuncelleyenId" },
                values: new object[] { 2, "Diğer", true, new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 1, new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
