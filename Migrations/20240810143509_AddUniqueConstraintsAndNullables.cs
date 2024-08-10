using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IronDomeV2.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintsAndNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MethodOfAttack",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Defender",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Attacker",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_MethodOfAttack_Name",
                table: "MethodOfAttack",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Defender_Name",
                table: "Defender",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attacker_Name",
                table: "Attacker",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MethodOfAttack_Name",
                table: "MethodOfAttack");

            migrationBuilder.DropIndex(
                name: "IX_Defender_Name",
                table: "Defender");

            migrationBuilder.DropIndex(
                name: "IX_Attacker_Name",
                table: "Attacker");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MethodOfAttack",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Defender",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Attacker",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
