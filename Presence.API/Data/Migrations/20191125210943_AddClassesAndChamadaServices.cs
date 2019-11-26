using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Presence.API.Data.Migrations
{
    public partial class AddClassesAndChamadaServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChamadaId",
                table: "Presencas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Chamadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClasseId = table.Column<Guid>(nullable: false),
                    Ativa = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamadas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_ChamadaId",
                table: "Presencas",
                column: "ChamadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_Chamadas_ChamadaId",
                table: "Presencas",
                column: "ChamadaId",
                principalTable: "Chamadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_Chamadas_ChamadaId",
                table: "Presencas");

            migrationBuilder.DropTable(
                name: "Chamadas");

            migrationBuilder.DropIndex(
                name: "IX_Presencas_ChamadaId",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "ChamadaId",
                table: "Presencas");
        }
    }
}
