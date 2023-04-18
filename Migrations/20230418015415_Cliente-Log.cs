using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleProdutos.Migrations
{
    /// <inheritdoc />
    public partial class ClienteLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ControleProdutos");

            migrationBuilder.RenameTable(
                name: "Unidade",
                newName: "Unidade",
                newSchema: "ControleProdutos");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produto",
                newSchema: "ControleProdutos");

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "ControleProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpfcnpj = table.Column<string>(type: "text", nullable: false),
                    dtnascimento = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogErros",
                schema: "ControleProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Err = table.Column<string>(type: "text", nullable: false),
                    ErrDesc = table.Column<string>(type: "text", nullable: false),
                    ErrDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogErros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "ControleProdutos");

            migrationBuilder.DropTable(
                name: "LogErros",
                schema: "ControleProdutos");

            migrationBuilder.RenameTable(
                name: "Unidade",
                schema: "ControleProdutos",
                newName: "Unidade");

            migrationBuilder.RenameTable(
                name: "Produto",
                schema: "ControleProdutos",
                newName: "Produto");
        }
    }
}
