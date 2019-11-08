using Microsoft.EntityFrameworkCore.Migrations;

namespace Forms.DA.Migrations
{
    public partial class ChangeColName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "Users",
                newName: "mobileNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mobileNumber",
                table: "Users",
                newName: "Mobile");
        }
    }
}
