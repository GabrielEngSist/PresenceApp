using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Presence.API.Data.Migrations
{
    public partial class PresencasAddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClasseId",
                table: "Presencas",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Presencas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Nota",
                table: "Presencas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instituicao_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    InstituicaoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professor_Instituicao_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professor_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProfessorId = table.Column<Guid>(nullable: false),
                    InstituicaoId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classe_Instituicao_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classe_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_ClasseId",
                table: "Presencas",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Classe_InstituicaoId",
                table: "Classe",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Classe_ProfessorId",
                table: "Classe",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Instituicao_UserId",
                table: "Instituicao",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_InstituicaoId",
                table: "Professor",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_UserId",
                table: "Professor",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_Classe_ClasseId",
                table: "Presencas",
                column: "ClasseId",
                principalTable: "Classe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_Classe_ClasseId",
                table: "Presencas");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropIndex(
                name: "IX_Presencas_ClasseId",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "ClasseId",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Presencas");
        }
    }
}
