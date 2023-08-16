using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckList.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoalItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    DateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoalItems_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motivations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motivations_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    DateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleItems_Dates_DateId",
                        column: x => x.DateId,
                        principalTable: "Dates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoalItems_DateId",
                table: "GoalItems",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_Motivations_DateId",
                table: "Motivations",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleItems_DateId",
                table: "ScheduleItems",
                column: "DateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoalItems");

            migrationBuilder.DropTable(
                name: "Motivations");

            migrationBuilder.DropTable(
                name: "ScheduleItems");

            migrationBuilder.DropTable(
                name: "Dates");
        }
    }
}
