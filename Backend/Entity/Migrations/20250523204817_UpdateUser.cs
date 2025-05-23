using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "seguridad",
                table: "User",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "seguridad",
                table: "RolUser",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "seguridad",
                table: "RolFormPermission",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "seguridad",
                table: "Rol",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "seguridad",
                table: "Person",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "seguridad",
                table: "Permission",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "seguridad",
                table: "Module",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "seguridad",
                table: "FormModule",
                newName: "IsDelete");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "seguridad",
                table: "Form",
                newName: "IsDelete");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                schema: "seguridad",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "seguridad",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                schema: "seguridad",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "seguridad",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "seguridad",
                table: "User",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "seguridad",
                table: "RolUser",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "seguridad",
                table: "RolFormPermission",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "seguridad",
                table: "Rol",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "seguridad",
                table: "Person",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "seguridad",
                table: "Permission",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "seguridad",
                table: "Module",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "seguridad",
                table: "FormModule",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDelete",
                schema: "seguridad",
                table: "Form",
                newName: "IsDeleted");
        }
    }
}
