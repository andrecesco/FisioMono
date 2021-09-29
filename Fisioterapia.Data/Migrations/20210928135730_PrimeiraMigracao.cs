using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fisioterapia.Data.Migrations
{
    public partial class PrimeiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Documento = table.Column<string>(type: "varchar(20)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: true),
                    Celular = table.Column<string>(type: "varchar(20)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    Profissao = table.Column<string>(type: "varchar(200)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataDelecao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anamnese",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QP = table.Column<string>(type: "varchar(100)", nullable: true),
                    Investigacao = table.Column<string>(type: "varchar(100)", nullable: true),
                    HPM = table.Column<string>(type: "varchar(100)", nullable: true),
                    PressaoAlta = table.Column<bool>(type: "bit", nullable: true),
                    MedicamentoParaPressao = table.Column<string>(type: "varchar(100)", nullable: true),
                    PraticaAtividadeFisica = table.Column<bool>(type: "bit", nullable: true),
                    NomeAtividadeFisica = table.Column<string>(type: "varchar(100)", nullable: true),
                    ExameFisioPostural = table.Column<string>(type: "varchar(100)", nullable: true),
                    ConsumeSubstancias = table.Column<bool>(type: "bit", nullable: true),
                    AlgiaPalpacao = table.Column<string>(type: "varchar(100)", nullable: true),
                    TonusMuscular = table.Column<string>(type: "varchar(100)", nullable: true),
                    HipotrofiaMuscular = table.Column<string>(type: "varchar(100)", nullable: true),
                    ContraturaMuscular = table.Column<bool>(type: "bit", nullable: true),
                    ContraturaMuscularObservacao = table.Column<string>(type: "varchar(100)", nullable: true),
                    RetracaoMuscular = table.Column<bool>(type: "bit", nullable: true),
                    RetracaoMuscularObservacao = table.Column<string>(type: "varchar(100)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataDelecao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamnese", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anamnese_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conduta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(MAX)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataDelecao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conduta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conduta_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Convenio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Matricula = table.Column<string>(type: "varchar(100)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataDelecao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Convenio_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(150)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(50)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataDelecao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tratamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    CondutaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataDelecao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamento_Conduta_CondutaId",
                        column: x => x.CondutaId,
                        principalTable: "Conduta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CondutaTratamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TratamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataDelecao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondutaTratamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CondutaTratamento_Conduta_CondutaId",
                        column: x => x.CondutaId,
                        principalTable: "Conduta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondutaTratamento_Tratamento_TratamentoId",
                        column: x => x.TratamentoId,
                        principalTable: "Tratamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anamnese_PacienteId",
                table: "Anamnese",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conduta_PacienteId",
                table: "Conduta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CondutaTratamento_CondutaId",
                table: "CondutaTratamento",
                column: "CondutaId");

            migrationBuilder.CreateIndex(
                name: "IX_CondutaTratamento_TratamentoId",
                table: "CondutaTratamento",
                column: "TratamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Convenio_PacienteId",
                table: "Convenio",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PacienteId",
                table: "Endereco",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamento_CondutaId",
                table: "Tratamento",
                column: "CondutaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anamnese");

            migrationBuilder.DropTable(
                name: "CondutaTratamento");

            migrationBuilder.DropTable(
                name: "Convenio");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Tratamento");

            migrationBuilder.DropTable(
                name: "Conduta");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
