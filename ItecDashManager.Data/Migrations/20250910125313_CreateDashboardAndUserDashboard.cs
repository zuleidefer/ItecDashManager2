using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItecDashManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDashboardAndUserDashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Dashboards",
               columns: table => new
               {
                   Id = table.Column<Guid>(nullable: false),
                   Name = table.Column<string>(maxLength: 100, nullable: false),
                   Url = table.Column<string>(maxLength: 200, nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Dashboards", x => x.Id);
               });

                    migrationBuilder.CreateTable(
                        name: "UserDashboards",
                        columns: table => new
                        {
                            Id = table.Column<Guid>(nullable: false),
                            UserId = table.Column<Guid>(nullable: false),
                            DashboardId = table.Column<Guid>(nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PK_UserDashboards", x => x.Id);
                            table.ForeignKey(
                                name: "FK_UserDashboards_Users_UserId",
                                column: x => x.UserId,
                                principalTable: "Users",
                                principalColumn: "Id",
                                onDelete: ReferentialAction.Cascade);
                            table.ForeignKey(
                                name: "FK_UserDashboards_Dashboards_DashboardId",
                                column: x => x.DashboardId,
                                principalTable: "Dashboards",
                                principalColumn: "Id",
                                onDelete: ReferentialAction.Cascade);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "UserDashboards");
            migrationBuilder.DropTable(name: "Dashboards");

        }
    }
}
