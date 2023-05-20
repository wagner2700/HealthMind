using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAPIidwall.Migrations
{
    /// <inheritdoc />
    public partial class PESSOASsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_NACIONALIDADES",
                columns: table => new
                {
                    NACIONALIDADEID = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    NACIONALIDADEDESC = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_NACIONALIDADES", x => x.NACIONALIDADEID);
                });

            migrationBuilder.CreateTable(
                name: "PESSOAS",
                columns: table => new
                {
                    SUSPEITOID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOMESUSPEITO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CLASSIFICACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SEXO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NacionalidadeId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOAS", x => x.SUSPEITOID);
                    table.ForeignKey(
                        name: "FK_PESSOAS_TB_NACIONALIDADES_NacionalidadeId",
                        column: x => x.NacionalidadeId,
                        principalTable: "TB_NACIONALIDADES",
                        principalColumn: "NACIONALIDADEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PESSOAS_NacionalidadeId",
                table: "PESSOAS",
                column: "NacionalidadeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PESSOAS");

            migrationBuilder.DropTable(
                name: "TB_NACIONALIDADES");
        }
    }
}
