using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNameAr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Subjects",
                newName: "NameAr");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "NameAr");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "NameAr");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "Subjects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "Departments",
                newName: "Name");
        }
    }
}
