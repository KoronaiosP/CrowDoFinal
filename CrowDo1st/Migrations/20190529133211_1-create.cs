using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowDo1st.Migrations
{
    public partial class _1create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateOfRegister = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    Activity = table.Column<bool>(nullable: false),
                    ViewsCounter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProfilePage",
                columns: table => new
                {
                    ProjectProfilePageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    DurationInMonths = table.Column<int>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Goal = table.Column<decimal>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Demandedfunds = table.Column<decimal>(nullable: false),
                    CreatorUserId = table.Column<int>(nullable: true),
                    ViewsCounter = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProfilePage", x => x.ProjectProfilePageId);
                    table.ForeignKey(
                        name: "FK_ProjectProfilePage_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectProfilePage_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProjectProfilePageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_ProjectProfilePage_ProjectProfilePageId",
                        column: x => x.ProjectProfilePageId,
                        principalTable: "ProjectProfilePage",
                        principalColumn: "ProjectProfilePageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCategory",
                columns: table => new
                {
                    ProjectProfilePageId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ProjectProfilePageId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategory", x => new { x.ProjectProfilePageId, x.CategoryId });
                    table.UniqueConstraint("AK_ProjectCategory_ProjectProfilePageId", x => x.ProjectProfilePageId);
                    table.ForeignKey(
                        name: "FK_ProjectCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectCategory_ProjectProfilePage_ProjectProfilePageId1",
                        column: x => x.ProjectProfilePageId1,
                        principalTable: "ProjectProfilePage",
                        principalColumn: "ProjectProfilePageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Updates",
                columns: table => new
                {
                    UpdatesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    DescriptionOfUpdate = table.Column<string>(nullable: true),
                    DateOfUpdate = table.Column<DateTime>(nullable: false),
                    ProjectProfilePageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Updates", x => x.UpdatesId);
                    table.ForeignKey(
                        name: "FK_Updates_ProjectProfilePage_ProjectProfilePageId",
                        column: x => x.ProjectProfilePageId,
                        principalTable: "ProjectProfilePage",
                        principalColumn: "ProjectProfilePageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProject",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ProjectProfilePageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => new { x.UserId, x.ProjectProfilePageId });
                    table.ForeignKey(
                        name: "FK_UserProject_ProjectProfilePage_ProjectProfilePageId",
                        column: x => x.ProjectProfilePageId,
                        principalTable: "ProjectProfilePage",
                        principalColumn: "ProjectProfilePageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProject_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProjectProfilePageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_Videos_ProjectProfilePage_ProjectProfilePageId",
                        column: x => x.ProjectProfilePageId,
                        principalTable: "ProjectProfilePage",
                        principalColumn: "ProjectProfilePageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProjectProfilePageId",
                table: "Photos",
                column: "ProjectProfilePageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategory_CategoryId",
                table: "ProjectCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategory_ProjectProfilePageId1",
                table: "ProjectCategory",
                column: "ProjectProfilePageId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProfilePage_CategoryId",
                table: "ProjectProfilePage",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProfilePage_CreatorUserId",
                table: "ProjectProfilePage",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Updates_ProjectProfilePageId",
                table: "Updates",
                column: "ProjectProfilePageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProject_ProjectProfilePageId",
                table: "UserProject",
                column: "ProjectProfilePageId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ProjectProfilePageId",
                table: "Videos",
                column: "ProjectProfilePageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "ProjectCategory");

            migrationBuilder.DropTable(
                name: "Updates");

            migrationBuilder.DropTable(
                name: "UserProject");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "ProjectProfilePage");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
