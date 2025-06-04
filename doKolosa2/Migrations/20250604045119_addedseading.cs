using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doKolosa2.Migrations
{
    /// <inheritdoc />
    public partial class addedseading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentGroups",
                columns: table => new
                {
                    IdStudentGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroups", x => x.IdStudentGroup);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdStudentGroup = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Students_StudentGroups_IdStudentGroup",
                        column: x => x.IdStudentGroup,
                        principalTable: "StudentGroups",
                        principalColumn: "IdStudentGroup",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "IdStudentGroup", "Name" },
                values: new object[] { 1, "GrupaAng" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "IdStudent", "IdStudentGroup", "Name" },
                values: new object[] { 1, 1, "Karolina" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdStudentGroup",
                table: "Students",
                column: "IdStudentGroup");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudentGroups");
        }
    }
}
