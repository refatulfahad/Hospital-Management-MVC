using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class addPatientBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Doctors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phn_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialist = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Doctors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phn_Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientDoctor",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDoctor", x => new { x.PatientId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_PatientDoctor_tbl_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "tbl_Doctors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDoctor_tbl_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tbl_Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PatientBill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bill_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bill_Amount = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PatientBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_PatientBill_tbl_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "tbl_Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctor_DoctorId",
                table: "PatientDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PatientBill_PatientId",
                table: "tbl_PatientBill",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientDoctor");

            migrationBuilder.DropTable(
                name: "tbl_PatientBill");

            migrationBuilder.DropTable(
                name: "tbl_Doctors");

            migrationBuilder.DropTable(
                name: "tbl_Patients");
        }
    }
}
