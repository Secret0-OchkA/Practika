using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(name: "user_Name", type: "nvarchar(max)", nullable: false),
                    userlogin = table.Column<string>(name: "user_login", type: "nvarchar(max)", nullable: false),
                    userpassword = table.Column<string>(name: "user_password", type: "nvarchar(max)", nullable: false),
                    userIp = table.Column<string>(name: "user_Ip", type: "nvarchar(max)", nullable: false),
                    personName = table.Column<string>(name: "person_Name", type: "nvarchar(max)", nullable: false),
                    personBirthdate = table.Column<DateTime>(name: "person_Birthdate", type: "datetime2", nullable: false),
                    CompanyName = table.Column<string>(name: "Company_Name", type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(name: "Company_Address", type: "nvarchar(max)", nullable: false),
                    CompanyInn = table.Column<string>(name: "Company_Inn", type: "nvarchar(max)", nullable: false),
                    CompanyPaymentAccount = table.Column<string>(name: "Company_PaymentAccount", type: "nvarchar(max)", nullable: false),
                    CompanyBik = table.Column<string>(name: "Company_Bik", type: "nvarchar(max)", nullable: false),
                    SocialSecNumber = table.Column<int>(type: "int", nullable: false),
                    SocialSecType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ein = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportSerial = table.Column<string>(name: "Passport_Serial", type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(name: "Passport_Number", type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ua = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    identityName = table.Column<string>(name: "identity_Name", type: "nvarchar(max)", nullable: false),
                    identitylogin = table.Column<string>(name: "identity_login", type: "nvarchar(max)", nullable: false),
                    identitypassword = table.Column<string>(name: "identity_password", type: "nvarchar(max)", nullable: false),
                    identityIp = table.Column<string>(name: "identity_Ip", type: "nvarchar(max)", nullable: false),
                    services = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    lastenter = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bloods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    barcode = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloods_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bloodServices",
                columns: table => new
                {
                    BloodId = table.Column<int>(type: "int", nullable: false),
                    serviceCode = table.Column<int>(type: "int", nullable: false),
                    result = table.Column<double>(type: "float", nullable: false),
                    finished = table.Column<double>(type: "float", nullable: false),
                    accepted = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    analyzer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_bloodServices_Bloods_BloodId",
                        column: x => x.BloodId,
                        principalTable: "Bloods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bloodServices_Services_serviceCode",
                        column: x => x.serviceCode,
                        principalTable: "Services",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bloodServices_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bloods_PatientId",
                table: "Bloods",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_bloodServices_BloodId",
                table: "bloodServices",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_bloodServices_serviceCode",
                table: "bloodServices",
                column: "serviceCode");

            migrationBuilder.CreateIndex(
                name: "IX_bloodServices_userId",
                table: "bloodServices",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bloodServices");

            migrationBuilder.DropTable(
                name: "Bloods");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
