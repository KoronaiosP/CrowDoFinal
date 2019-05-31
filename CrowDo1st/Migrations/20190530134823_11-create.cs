using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowDo1st.Migrations
{
    public partial class _11create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Demandedfunds",
                table: "ProjectProfilePage");

            migrationBuilder.DropColumn(
                name: "DurationInMonths",
                table: "ProjectProfilePage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Demandedfunds",
                table: "ProjectProfilePage",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DurationInMonths",
                table: "ProjectProfilePage",
                nullable: false,
                defaultValue: 0);
        }
    }
}
