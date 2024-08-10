using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IronDomeV2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attacker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Defender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volley",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volley", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Volley_Attacker_AttackerId",
                        column: x => x.AttackerId,
                        principalTable: "Attacker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MethodOfAttack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Range = table.Column<double>(type: "float", nullable: false),
                    Velocity = table.Column<double>(type: "float", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    TimeOfLaunch = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VolleyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodOfAttack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MethodOfAttack_Volley_VolleyId",
                        column: x => x.VolleyId,
                        principalTable: "Volley",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countermeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Range = table.Column<double>(type: "float", nullable: false),
                    DefenderId = table.Column<int>(type: "int", nullable: false),
                    Velocity = table.Column<double>(type: "float", nullable: false),
                    LaunchTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MethodOfAttackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countermeasure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countermeasure_Defender_DefenderId",
                        column: x => x.DefenderId,
                        principalTable: "Defender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countermeasure_MethodOfAttack_MethodOfAttackId",
                        column: x => x.MethodOfAttackId,
                        principalTable: "MethodOfAttack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countermeasure_DefenderId",
                table: "Countermeasure",
                column: "DefenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Countermeasure_MethodOfAttackId",
                table: "Countermeasure",
                column: "MethodOfAttackId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MethodOfAttack_VolleyId",
                table: "MethodOfAttack",
                column: "VolleyId");

            migrationBuilder.CreateIndex(
                name: "IX_Volley_AttackerId",
                table: "Volley",
                column: "AttackerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countermeasure");

            migrationBuilder.DropTable(
                name: "Defender");

            migrationBuilder.DropTable(
                name: "MethodOfAttack");

            migrationBuilder.DropTable(
                name: "Volley");

            migrationBuilder.DropTable(
                name: "Attacker");
        }
    }
}
