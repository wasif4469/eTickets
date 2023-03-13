using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTickets.Migrations
{
    /// <inheritdoc />
    public partial class NewInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_Actors_ActorId",
                table: "Actors_Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cenimas_CenimaId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "ProducerID",
                table: "Producers",
                newName: "ProducerId");

            migrationBuilder.RenameColumn(
                name: "CenimaId",
                table: "Movies",
                newName: "CenimaID");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Movies",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CenimaId",
                table: "Movies",
                newName: "IX_Movies_CenimaID");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "Actors_Movies",
                newName: "ActorID");

            migrationBuilder.RenameIndex(
                name: "IX_Actors_Movies_ActorId",
                table: "Actors_Movies",
                newName: "IX_Actors_Movies_ActorID");

            migrationBuilder.RenameColumn(
                name: "ActorID",
                table: "Actors",
                newName: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_Actors_ActorID",
                table: "Actors_Movies",
                column: "ActorID",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cenimas_CenimaID",
                table: "Movies",
                column: "CenimaID",
                principalTable: "Cenimas",
                principalColumn: "CenimaID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_Actors_ActorID",
                table: "Actors_Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cenimas_CenimaID",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "ProducerId",
                table: "Producers",
                newName: "ProducerID");

            migrationBuilder.RenameColumn(
                name: "CenimaID",
                table: "Movies",
                newName: "CenimaId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movies",
                newName: "MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CenimaID",
                table: "Movies",
                newName: "IX_Movies_CenimaId");

            migrationBuilder.RenameColumn(
                name: "ActorID",
                table: "Actors_Movies",
                newName: "ActorId");

            migrationBuilder.RenameIndex(
                name: "IX_Actors_Movies_ActorID",
                table: "Actors_Movies",
                newName: "IX_Actors_Movies_ActorId");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "Actors",
                newName: "ActorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_Actors_ActorId",
                table: "Actors_Movies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "ActorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cenimas_CenimaId",
                table: "Movies",
                column: "CenimaId",
                principalTable: "Cenimas",
                principalColumn: "CenimaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
