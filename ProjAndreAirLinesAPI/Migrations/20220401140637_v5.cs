using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjAndreAirLinesAPI.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Aeroporto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Aeroporto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
