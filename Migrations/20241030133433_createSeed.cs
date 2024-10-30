using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunGroop.Migrations
{
    /// <inheritdoc />
    public partial class createSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rases_Addresses_AddressId",
                table: "Rases");

            migrationBuilder.DropForeignKey(
                name: "FK_Rases_AppUser_AppUserId",
                table: "Rases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rases",
                table: "Rases");

            migrationBuilder.RenameTable(
                name: "Rases",
                newName: "Races");

            migrationBuilder.RenameIndex(
                name: "IX_Rases_AppUserId",
                table: "Races",
                newName: "IX_Races_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rases_AddressId",
                table: "Races",
                newName: "IX_Races_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Races",
                table: "Races",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Addresses_AddressId",
                table: "Races",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_AppUser_AppUserId",
                table: "Races",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Addresses_AddressId",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_AppUser_AppUserId",
                table: "Races");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Races",
                table: "Races");

            migrationBuilder.RenameTable(
                name: "Races",
                newName: "Rases");

            migrationBuilder.RenameIndex(
                name: "IX_Races_AppUserId",
                table: "Rases",
                newName: "IX_Rases_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Races_AddressId",
                table: "Rases",
                newName: "IX_Rases_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rases",
                table: "Rases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rases_Addresses_AddressId",
                table: "Rases",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rases_AppUser_AppUserId",
                table: "Rases",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id");
        }
    }
}
