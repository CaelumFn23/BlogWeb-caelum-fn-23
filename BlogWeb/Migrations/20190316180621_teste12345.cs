using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWeb.Migrations
{
    public partial class teste12345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UsuarioId",
                table: "Posts",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Usuarios_UsuarioId",
                table: "Posts",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Usuarios_UsuarioId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UsuarioId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Posts");
        }
    }
}
