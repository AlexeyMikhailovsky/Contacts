using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts.Migrations
{
    /// <inheritdoc />
    public partial class ChangedToDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "contacts");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "contacts",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "contacts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MobilePhone",
                table: "contacts",
                newName: "mobile_phone");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "contacts",
                newName: "job_title");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "contacts",
                newName: "birth_date");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "contacts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "job_title",
                table: "contacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "birth_date",
                table: "contacts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacts",
                table: "contacts",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_contacts",
                table: "contacts");

            migrationBuilder.RenameTable(
                name: "contacts",
                newName: "Contacts");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Contacts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Contacts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "mobile_phone",
                table: "Contacts",
                newName: "MobilePhone");

            migrationBuilder.RenameColumn(
                name: "job_title",
                table: "Contacts",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "Contacts",
                newName: "BirthDate");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Contacts",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Contacts",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");
        }
    }
}
