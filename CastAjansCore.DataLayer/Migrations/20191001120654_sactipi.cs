using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class sactipi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SacTipi",
                schema: "Cast",
                table: "Oyuncular",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kisiler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SacTipi",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kisiler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 9, 25, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
