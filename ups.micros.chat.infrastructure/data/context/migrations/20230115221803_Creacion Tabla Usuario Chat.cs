using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ups.micros.chat.infrastructure.data.context.migrations
{
    public partial class CreacionTablaUsuarioChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioChat",
                columns: table => new
                {
                    IdUsuarioChat = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificadorGrupo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioChat", x => x.IdUsuarioChat);
                    table.ForeignKey(
                        name: "FK_UsuarioChat_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioChat_IdUsuario",
                table: "UsuarioChat",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioChat");
        }
    }
}
