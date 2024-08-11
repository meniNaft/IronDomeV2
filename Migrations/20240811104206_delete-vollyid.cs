using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IronDomeV2.Migrations
{
    /// <inheritdoc />
    public partial class deletevollyid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MethodOfAttack_Volley_VolleyId",
                table: "MethodOfAttack");

            migrationBuilder.AlterColumn<int>(
                name: "VolleyId",
                table: "MethodOfAttack",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MethodOfAttack_Volley_VolleyId",
                table: "MethodOfAttack",
                column: "VolleyId",
                principalTable: "Volley",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MethodOfAttack_Volley_VolleyId",
                table: "MethodOfAttack");

            migrationBuilder.AlterColumn<int>(
                name: "VolleyId",
                table: "MethodOfAttack",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MethodOfAttack_Volley_VolleyId",
                table: "MethodOfAttack",
                column: "VolleyId",
                principalTable: "Volley",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
