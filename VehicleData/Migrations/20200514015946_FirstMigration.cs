using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleApiData.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(maxLength: 36, nullable: true),
                    LastName = table.Column<string>(maxLength: 36, nullable: true),
                    Username = table.Column<string>(maxLength: 36, nullable: true),
                    Password = table.Column<string>(maxLength: 36, nullable: true),
                    Provider = table.Column<string>(maxLength: 36, nullable: true),
                    ReferenceId = table.Column<string>(maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => new { x.Id, x.Email });
                    table.UniqueConstraint("AK_Users_Email_Id", x => new { x.Email, x.Id });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
