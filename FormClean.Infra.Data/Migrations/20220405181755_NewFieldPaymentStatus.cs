﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FormClean.Infra.Data.Migrations
{
    public partial class NewFieldPaymentStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status_pagamento",
                table: "Demandeds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status_pagamento",
                table: "Demandeds");
        }
    }
}