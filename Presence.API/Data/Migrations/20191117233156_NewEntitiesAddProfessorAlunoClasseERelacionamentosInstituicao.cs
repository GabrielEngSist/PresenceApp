using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Presence.API.Data.Migrations
{
    public partial class NewEntitiesAddProfessorAlunoClasseERelacionamentosInstituicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Matricula = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    InstituicaoId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Instituicao_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aluno_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlunoClasse",
                columns: table => new
                {
                    AlunoId = table.Column<Guid>(nullable: false),
                    ClasseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoClasse", x => new { x.AlunoId, x.ClasseId });
                    table.ForeignKey(
                        name: "FK_AlunoClasse_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoClasse_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_InstituicaoId",
                table: "Aluno",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_UserId",
                table: "Aluno",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoClasse_ClasseId",
                table: "AlunoClasse",
                column: "ClasseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoClasse");

            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
