using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignTabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignTabs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignCategoryPivots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignCategoryPivots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignCategoryPivots_CampaignCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CampaignCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignCategoryPivots_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    IconType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatureText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignFeatures_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignPricingOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractMonths = table.Column<int>(type: "int", nullable: false),
                    PriceMonthly = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceMonthlyAfter = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IncludesDevice = table.Column<bool>(type: "bit", nullable: false),
                    DeviceFeeMonthly = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignPricingOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignPricingOptions_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignTabContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    CampaignTabId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignTabContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignTabContents_CampaignTabs_CampaignTabId",
                        column: x => x.CampaignTabId,
                        principalTable: "CampaignTabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignTabContents_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignCategoryPivots_CampaignId",
                table: "CampaignCategoryPivots",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignCategoryPivots_CategoryId",
                table: "CampaignCategoryPivots",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignFeatures_CampaignId",
                table: "CampaignFeatures",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignPricingOptions_CampaignId",
                table: "CampaignPricingOptions",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTabContents_CampaignId",
                table: "CampaignTabContents",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignTabContents_CampaignTabId",
                table: "CampaignTabContents",
                column: "CampaignTabId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignCategoryPivots");

            migrationBuilder.DropTable(
                name: "CampaignFeatures");

            migrationBuilder.DropTable(
                name: "CampaignPricingOptions");

            migrationBuilder.DropTable(
                name: "CampaignTabContents");

            migrationBuilder.DropTable(
                name: "CampaignCategories");

            migrationBuilder.DropTable(
                name: "CampaignTabs");

            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}
