using Microsoft.EntityFrameworkCore.Migrations;

namespace fullstackdotnet.repository.Migrations
{
    public partial class novo_campo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Conteudo",
                table: "Eventos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conteudo",
                table: "Eventos");
        }
    }
}
