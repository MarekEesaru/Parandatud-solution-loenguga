using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class v2304262 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCurrencies_Countries_CountryId",
                table: "CountryCurrencies");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryCurrencies_Currencies_CurrencyId",
                table: "CountryCurrencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Monies_Currencies_CurrencyId",
                table: "Monies");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "Monies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "CountryCurrencies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "CountryCurrencies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrencies_Countries_CountryId",
                table: "CountryCurrencies",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrencies_Currencies_CurrencyId",
                table: "CountryCurrencies",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monies_Currencies_CurrencyId",
                table: "Monies",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCurrencies_Countries_CountryId",
                table: "CountryCurrencies");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryCurrencies_Currencies_CurrencyId",
                table: "CountryCurrencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Monies_Currencies_CurrencyId",
                table: "Monies");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "Monies",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrencyId",
                table: "CountryCurrencies",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "CountryCurrencies",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrencies_Countries_CountryId",
                table: "CountryCurrencies",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrencies_Currencies_CurrencyId",
                table: "CountryCurrencies",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monies_Currencies_CurrencyId",
                table: "Monies",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
