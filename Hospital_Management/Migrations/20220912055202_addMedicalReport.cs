using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class addMedicalReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_MedicalReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientProblem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalTest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalResult = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_MedicalReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_MedicalReport_tbl_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tbl_Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_MedicalReport_PatientId",
                table: "tbl_MedicalReport",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_MedicalReport");
        }
    }
}
