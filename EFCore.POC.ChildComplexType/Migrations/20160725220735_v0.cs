using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.POC.ChildComplexType.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefundUnit",
                columns: table => new
                {
                    RefundUnitId = table.Column<int>(nullable: false),
                    Acronym = table.Column<string>(nullable: true),
                    ActiveIndicator = table.Column<string>(nullable: true),
                    Item = table.Column<bool>(nullable: false),
                    Km = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Person = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundUnit", x => x.RefundUnitId);
                });

            migrationBuilder.CreateTable(
                name: "RefundType",
                columns: table => new
                {
                    RefundTypeId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<long>(nullable: false),
                    DarkIcon = table.Column<string>(nullable: true),
                    HelpText = table.Column<string>(nullable: true),
                    IsAttachmentRequired = table.Column<bool>(nullable: false),
                    IsCommentRequired = table.Column<bool>(nullable: false),
                    IsPeopleRequired = table.Column<bool>(nullable: false),
                    LightIcon = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RefundUnitId = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundType", x => x.RefundTypeId);
                    table.ForeignKey(
                        name: "FK_RefundType_RefundUnit_RefundUnitId",
                        column: x => x.RefundUnitId,
                        principalTable: "RefundUnit",
                        principalColumn: "RefundUnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefundType_RefundUnitId",
                table: "RefundType",
                column: "RefundUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefundType");

            migrationBuilder.DropTable(
                name: "RefundUnit");
        }
    }
}
