using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projeto_integrador.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioContratante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    NomeEmpresa = table.Column<string>(type: "varchar(100)", nullable: true),
                    EnderecoEmpresa = table.Column<string>(type: "varchar(100)", nullable: true),
                    UrlFotoEmpresa = table.Column<string>(type: "varchar(100)", nullable: true),
                    DescricaoEmpresa = table.Column<string>(type: "varchar(100)", nullable: true),
                    NumeroContato = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioContratante", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioContratante");
        }
    }
}
