using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lab3WebMvc.Migrations
{
    public partial class fixedmodelclassses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "AvailableSeats",
                table: "Movie",
                newName: "SeatsTaken");

            migrationBuilder.AddColumn<int>(
                name: "TicketCount",
                table: "Visitor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketCount",
                table: "Visitor");

            migrationBuilder.RenameColumn(
                name: "SeatsTaken",
                table: "Movie",
                newName: "AvailableSeats");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
