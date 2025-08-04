using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassE.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_People_PersonId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Classes",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "ClassBalance",
                table: "People",
                newName: "Gender");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Balance",
                table: "People",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConsentDate",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContact",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactNumber",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JoiningNotes",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "People",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Classes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Classes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_People_PersonId",
                table: "Payments",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_People_PersonId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ConsentDate",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EmergencyContact",
                table: "People");

            migrationBuilder.DropColumn(
                name: "EmergencyContactNumber",
                table: "People");

            migrationBuilder.DropColumn(
                name: "JoiningNotes",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "People");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "People",
                newName: "ClassBalance");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Payments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Classes",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<byte>(
                name: "StartTime",
                table: "Classes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<float>(
                name: "Cost",
                table: "Classes",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Classes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Classes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_People_PersonId",
                table: "Payments",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
