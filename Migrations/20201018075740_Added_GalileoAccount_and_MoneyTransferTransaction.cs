using Microsoft.EntityFrameworkCore.Migrations;

namespace HackTheU_Escrow_Feature.Migrations
{
    public partial class Added_GalileoAccount_and_MoneyTransferTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GalileoAccountId",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GalileoAccountId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GalileoAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardholderId = table.Column<string>(nullable: true),
                    AccountId = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalileoAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoneyTransferTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderAccountId = table.Column<string>(nullable: true),
                    ReceiverAccountId = table.Column<string>(nullable: true),
                    Amt = table.Column<double>(nullable: false),
                    GalileoAccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyTransferTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyTransferTransaction_GalileoAccount_GalileoAccountId",
                        column: x => x.GalileoAccountId,
                        principalTable: "GalileoAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_GalileoAccountId",
                table: "Project",
                column: "GalileoAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GalileoAccountId",
                table: "AspNetUsers",
                column: "GalileoAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransferTransaction_GalileoAccountId",
                table: "MoneyTransferTransaction",
                column: "GalileoAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GalileoAccount_GalileoAccountId",
                table: "AspNetUsers",
                column: "GalileoAccountId",
                principalTable: "GalileoAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_GalileoAccount_GalileoAccountId",
                table: "Project",
                column: "GalileoAccountId",
                principalTable: "GalileoAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GalileoAccount_GalileoAccountId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_GalileoAccount_GalileoAccountId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "MoneyTransferTransaction");

            migrationBuilder.DropTable(
                name: "GalileoAccount");

            migrationBuilder.DropIndex(
                name: "IX_Project_GalileoAccountId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GalileoAccountId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GalileoAccountId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "GalileoAccountId",
                table: "AspNetUsers");
        }
    }
}
