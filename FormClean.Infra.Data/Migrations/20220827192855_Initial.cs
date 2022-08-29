using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FormClean.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_cliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    whatsapp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    rua_cliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bairro_cliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    numero_endereco_cliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Demandeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    data_entrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    preco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endereco_entrega = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    status_pagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status_pedido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demandeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demandeds_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Demandeds_ClientId",
                table: "Demandeds",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demandeds");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
