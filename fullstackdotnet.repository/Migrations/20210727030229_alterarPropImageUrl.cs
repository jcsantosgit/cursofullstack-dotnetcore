using Microsoft.EntityFrameworkCore.Migrations;

namespace fullstackdotnet.repository.Migrations
{
    public partial class alterarPropImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Eventos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Eventos",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
