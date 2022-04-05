using Microsoft.EntityFrameworkCore.Migrations;

namespace FormClean.Infra.Data.Migrations
{
    public partial class NewFieldsForAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "endereco_cliente",
                table: "Clients",
                newName: "rua_cliente");

            migrationBuilder.AddColumn<string>(
                name: "bairro_cliente",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "numero_endereco_cliente",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bairro_cliente",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "numero_endereco_cliente",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "rua_cliente",
                table: "Clients",
                newName: "endereco_cliente");
        }
    }
}
