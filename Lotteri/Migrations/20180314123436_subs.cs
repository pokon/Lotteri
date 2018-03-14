using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lotteri.Migrations
{
    public partial class subs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "LottoItemModel",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isLottad",
                table: "LottoItemModel",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "LottoItemModel");

            migrationBuilder.DropColumn(
                name: "isLottad",
                table: "LottoItemModel");
        }
    }
}
