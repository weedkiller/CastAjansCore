using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class musterilertelefon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefon2",
                schema: "Cast",
                table: "Musteriler",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 13,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                schema: "Cast",
                table: "Musteriler",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 13,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Faks",
                schema: "Cast",
                table: "Musteriler",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 13,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefon2",
                schema: "Cast",
                table: "Musteriler",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                schema: "Cast",
                table: "Musteriler",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Faks",
                schema: "Cast",
                table: "Musteriler",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kisiler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                schema: "Sistem",
                table: "Uyruklar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EklemeZamani", "GuncellemeZamani" },
                values: new object[] { new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
