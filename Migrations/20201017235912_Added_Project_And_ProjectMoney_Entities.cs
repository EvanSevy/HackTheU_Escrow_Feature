using Microsoft.EntityFrameworkCore.Migrations;

namespace HackTheU_Escrow_Feature.Migrations
{
    public partial class Added_Project_And_ProjectMoney_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MoneyThresholdForRelease = table.Column<double>(nullable: false),
                    CurrentMoneyDonated = table.Column<double>(nullable: false),
                    MoneyTrusteeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_MoneyTrusteeId",
                        column: x => x.MoneyTrusteeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMoney",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: true),
                    MoneyForProject = table.Column<double>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMoney", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectMoney_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectMoney_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatorId",
                table: "Project",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_MoneyTrusteeId",
                table: "Project",
                column: "MoneyTrusteeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMoney_ProjectId",
                table: "ProjectMoney",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMoney_UserId",
                table: "ProjectMoney",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectMoney");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
