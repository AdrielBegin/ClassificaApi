using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassificaApi.Migrations
{
    /// <inheritdoc />
    public partial class auth_test_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Classificados_ClassificadosId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ClassificadosId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "ClassificadosId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "Classificados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classificados_UsuariosId",
                table: "Classificados",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classificados_Usuarios_UsuariosId",
                table: "Classificados",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classificados_Usuarios_UsuariosId",
                table: "Classificados");

            migrationBuilder.DropIndex(
                name: "IX_Classificados_UsuariosId",
                table: "Classificados");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "Classificados");

            migrationBuilder.AlterColumn<int>(
                name: "ClassificadosId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ClassificadosId",
                table: "Usuarios",
                column: "ClassificadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Classificados_ClassificadosId",
                table: "Usuarios",
                column: "ClassificadosId",
                principalTable: "Classificados",
                principalColumn: "Id");
        }
    }
}
