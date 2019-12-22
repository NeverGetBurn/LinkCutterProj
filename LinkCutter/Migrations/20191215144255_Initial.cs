using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkCutter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LongName = table.Column<string>(nullable: false),
                    ShortName = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    RedirectCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
