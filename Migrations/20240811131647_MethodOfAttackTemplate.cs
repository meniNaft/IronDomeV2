using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IronDomeV2.Migrations
{
    /// <inheritdoc />
    public partial class MethodOfAttackTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MethodOfAttackTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Range = table.Column<double>(type: "float", nullable: false),
                    Velocity = table.Column<double>(type: "float", nullable: false),
                    CountermeasureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodOfAttackTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MethodOfAttackTemplate_Countermeasure_CountermeasureId",
                        column: x => x.CountermeasureId,
                        principalTable: "Countermeasure",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MethodOfAttackTemplate_CountermeasureId",
                table: "MethodOfAttackTemplate",
                column: "CountermeasureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MethodOfAttackTemplate");
        }
    }
}
