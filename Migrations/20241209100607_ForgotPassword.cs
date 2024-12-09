using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Appointy.Migrations
{
    /// <inheritdoc />
    public partial class ForgotPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Doctors_DoctorId1",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Patients_PatientId1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_DoctorId1",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_PatientId1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Contacts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "MessageWrite",
                table: "Contacts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Contacts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_DoctorId",
                table: "Contacts",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PatientId",
                table: "Contacts",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Doctors_DoctorId",
                table: "Contacts",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Patients_PatientId",
                table: "Contacts",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Doctors_DoctorId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Patients_PatientId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_DoctorId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_PatientId",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MessageWrite",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "Contacts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "Contacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "Contacts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_DoctorId1",
                table: "Contacts",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PatientId1",
                table: "Contacts",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Doctors_DoctorId1",
                table: "Contacts",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Patients_PatientId1",
                table: "Contacts",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            
        }
    }
}
