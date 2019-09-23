using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class oyuncuCastTipi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CastTipi",
                schema: "Cast",
                table: "Oyuncular",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kisiler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 8, 28, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CastTipi",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kisiler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 27, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 27, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 27, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 27, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
