using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lab3WebMvc.Migrations
{
    public partial class la : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Starting",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Starting",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
