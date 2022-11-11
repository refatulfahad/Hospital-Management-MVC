using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management.Migrations
{
    /// <inheritdoc />
    public partial class forOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctor_tbl_Doctors_DoctorId",
                table: "PatientDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctor_tbl_Patients_PatientId",
                table: "PatientDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_MedicalReport_tbl_Patients_PatientId",
                table: "tbl_MedicalReport");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_PatientBill_tbl_Patients_PatientId",
                table: "tbl_PatientBill");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctor_tbl_Doctors_DoctorId",
                table: "PatientDoctor",
                column: "DoctorId",
                principalTable: "tbl_Doctors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctor_tbl_Patients_PatientId",
                table: "PatientDoctor",
                column: "PatientId",
                principalTable: "tbl_Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_MedicalReport_tbl_Patients_PatientId",
                table: "tbl_MedicalReport",
                column: "PatientId",
                principalTable: "tbl_Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_PatientBill_tbl_Patients_PatientId",
                table: "tbl_PatientBill",
                column: "PatientId",
                principalTable: "tbl_Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctor_tbl_Doctors_DoctorId",
                table: "PatientDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDoctor_tbl_Patients_PatientId",
                table: "PatientDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_MedicalReport_tbl_Patients_PatientId",
                table: "tbl_MedicalReport");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_PatientBill_tbl_Patients_PatientId",
                table: "tbl_PatientBill");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctor_tbl_Doctors_DoctorId",
                table: "PatientDoctor",
                column: "DoctorId",
                principalTable: "tbl_Doctors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDoctor_tbl_Patients_PatientId",
                table: "PatientDoctor",
                column: "PatientId",
                principalTable: "tbl_Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_MedicalReport_tbl_Patients_PatientId",
                table: "tbl_MedicalReport",
                column: "PatientId",
                principalTable: "tbl_Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_PatientBill_tbl_Patients_PatientId",
                table: "tbl_PatientBill",
                column: "PatientId",
                principalTable: "tbl_Patients",
                principalColumn: "Id");
        }
    }
}
