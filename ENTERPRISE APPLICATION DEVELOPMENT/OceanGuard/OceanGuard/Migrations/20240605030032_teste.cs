using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanGuard.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autoridades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    Contato = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autoridades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "varchar(60)", nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(30)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DensidadeBanhistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    QuantidadeBanhistas = table.Column<int>(type: "number(7)", nullable: false),
                    Latitude = table.Column<decimal>(type: "number(7,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "number(7,2)", nullable: false),
                    DataReporte = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DensidadeBanhistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DensidadeBanhistas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventosNaturais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(30)", nullable: false),
                    Latitude = table.Column<decimal>(type: "number(7,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "number(7,2)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosNaturais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventosNaturais_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OcorrenciasLixo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Latitude = table.Column<decimal>(type: "number(7,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "number(7,2)", nullable: false),
                    DataOcorrencia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcorrenciasLixo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OcorrenciasLixo_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataNotificacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Status = table.Column<string>(type: "varchar(30)", nullable: false),
                    AutoridadeId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OcorrenciaLixoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoNaturalId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DensidadeBanhistaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notificacoes_Autoridades_AutoridadeId",
                        column: x => x.AutoridadeId,
                        principalTable: "Autoridades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificacoes_DensidadeBanhistas_DensidadeBanhistaId",
                        column: x => x.DensidadeBanhistaId,
                        principalTable: "DensidadeBanhistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificacoes_EventosNaturais_EventoNaturalId",
                        column: x => x.EventoNaturalId,
                        principalTable: "EventosNaturais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificacoes_OcorrenciasLixo_OcorrenciaLixoId",
                        column: x => x.OcorrenciaLixoId,
                        principalTable: "OcorrenciasLixo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DensidadeBanhistas_UsuarioId",
                table: "DensidadeBanhistas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EventosNaturais_UsuarioId",
                table: "EventosNaturais",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_AutoridadeId",
                table: "Notificacoes",
                column: "AutoridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_DensidadeBanhistaId",
                table: "Notificacoes",
                column: "DensidadeBanhistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_EventoNaturalId",
                table: "Notificacoes",
                column: "EventoNaturalId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_OcorrenciaLixoId",
                table: "Notificacoes",
                column: "OcorrenciaLixoId");

            migrationBuilder.CreateIndex(
                name: "IX_OcorrenciasLixo_UsuarioId",
                table: "OcorrenciasLixo",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificacoes");

            migrationBuilder.DropTable(
                name: "Autoridades");

            migrationBuilder.DropTable(
                name: "DensidadeBanhistas");

            migrationBuilder.DropTable(
                name: "EventosNaturais");

            migrationBuilder.DropTable(
                name: "OcorrenciasLixo");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
