using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class guidId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GuidId",
                schema: "Cast",
                table: "Projeler",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Durumu",
                schema: "Cast",
                table: "Oyuncular",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kisiler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuidId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "Durumu",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kisiler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 12, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
