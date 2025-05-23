using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAfterInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "seguridad");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "User",
                newSchema: "seguridad");

            migrationBuilder.RenameTable(
                name: "RolUser",
                newName: "RolUser",
                newSchema: "seguridad");

            migrationBuilder.RenameTable(
                name: "RolFormPermission",
                newName: "RolFormPermission",
                newSchema: "seguridad");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Rol",
                newSchema: "seguridad");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Person",
                newSchema: "seguridad");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permission",
                newSchema: "seguridad");

            migrationBuilder.RenameTable(
                name: "Module",
                newName: "Module",
                newSchema: "seguridad");

            migrationBuilder.RenameTable(
                name: "FormModule",
                newName: "FormModule",
                newSchema: "seguridad");

            migrationBuilder.RenameTable(
                name: "Form",
                newName: "Form",
                newSchema: "seguridad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "User",
                schema: "seguridad",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "RolUser",
                schema: "seguridad",
                newName: "RolUser");

            migrationBuilder.RenameTable(
                name: "RolFormPermission",
                schema: "seguridad",
                newName: "RolFormPermission");

            migrationBuilder.RenameTable(
                name: "Rol",
                schema: "seguridad",
                newName: "Rol");

            migrationBuilder.RenameTable(
                name: "Person",
                schema: "seguridad",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "Permission",
                schema: "seguridad",
                newName: "Permission");

            migrationBuilder.RenameTable(
                name: "Module",
                schema: "seguridad",
                newName: "Module");

            migrationBuilder.RenameTable(
                name: "FormModule",
                schema: "seguridad",
                newName: "FormModule");

            migrationBuilder.RenameTable(
                name: "Form",
                schema: "seguridad",
                newName: "Form");
        }
    }
}
