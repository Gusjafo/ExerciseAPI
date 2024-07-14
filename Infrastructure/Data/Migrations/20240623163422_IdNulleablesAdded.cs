using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class IdNulleablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aliases_Exercises_ExerciseId",
                table: "Aliases");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Exercises_ExerciseId",
                table: "Instructions");

            migrationBuilder.DropForeignKey(
                name: "FK_PrimaryMuscles_Exercises_ExerciseId",
                table: "PrimaryMuscles");

            migrationBuilder.DropForeignKey(
                name: "FK_SecondaryMuscles_Exercises_ExerciseId",
                table: "SecondaryMuscles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tips_Exercises_ExerciseId",
                table: "Tips");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Tips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "SecondaryMuscles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "PrimaryMuscles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Instructions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Aliases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Aliases_Exercises_ExerciseId",
                table: "Aliases",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Exercises_ExerciseId",
                table: "Instructions",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrimaryMuscles_Exercises_ExerciseId",
                table: "PrimaryMuscles",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SecondaryMuscles_Exercises_ExerciseId",
                table: "SecondaryMuscles",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tips_Exercises_ExerciseId",
                table: "Tips",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aliases_Exercises_ExerciseId",
                table: "Aliases");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Exercises_ExerciseId",
                table: "Instructions");

            migrationBuilder.DropForeignKey(
                name: "FK_PrimaryMuscles_Exercises_ExerciseId",
                table: "PrimaryMuscles");

            migrationBuilder.DropForeignKey(
                name: "FK_SecondaryMuscles_Exercises_ExerciseId",
                table: "SecondaryMuscles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tips_Exercises_ExerciseId",
                table: "Tips");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Tips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "SecondaryMuscles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "PrimaryMuscles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Instructions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Aliases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aliases_Exercises_ExerciseId",
                table: "Aliases",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Exercises_ExerciseId",
                table: "Instructions",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrimaryMuscles_Exercises_ExerciseId",
                table: "PrimaryMuscles",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecondaryMuscles_Exercises_ExerciseId",
                table: "SecondaryMuscles",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tips_Exercises_ExerciseId",
                table: "Tips",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
