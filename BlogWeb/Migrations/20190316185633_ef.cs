using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWeb.Migrations
{
    public partial class ef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Usuarios_UsuarioId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Posts",
                newName: "AutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UsuarioId",
                table: "Posts",
                newName: "IX_Posts_AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Usuarios_AutorId",
                table: "Posts",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Usuarios_AutorId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Posts",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AutorId",
                table: "Posts",
                newName: "IX_Posts_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Usuarios_UsuarioId",
                table: "Posts",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
