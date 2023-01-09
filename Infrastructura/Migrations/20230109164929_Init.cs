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
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    userName = table.Column<string>(name: "user_Name", type: "TEXT", nullable: false),
                    userlogin = table.Column<string>(name: "user_login", type: "TEXT", nullable: false),
                    userpassword = table.Column<string>(name: "user_password", type: "TEXT", nullable: false),
                    userIp = table.Column<string>(name: "user_Ip", type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(name: "Company_Name", type: "TEXT", nullable: false),
                    CompanyAddress = table.Column<string>(name: "Company_Address", type: "TEXT", nullable: false),
                    CompanyInn = table.Column<string>(name: "Company_Inn", type: "TEXT", nullable: false),
                    CompanyPaymentAccount = table.Column<string>(name: "Company_PaymentAccount", type: "TEXT", nullable: false),
                    CompanyBik = table.Column<string>(name: "Company_Bik", type: "TEXT", nullable: false),
                    SocialSecNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    SocialSecType = table.Column<string>(type: "TEXT", nullable: false),
                    ein = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    passportS = table.Column<int>(type: "INTEGER", nullable: false),
                    passportN = table.Column<int>(type: "INTEGER", nullable: false),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false),
                    country = table.Column<string>(type: "TEXT", nullable: false),
                    ua = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Code = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Service = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    identityName = table.Column<string>(name: "identity_Name", type: "TEXT", nullable: false),
                    identitylogin = table.Column<string>(name: "identity_login", type: "TEXT", nullable: false),
                    identitypassword = table.Column<string>(name: "identity_password", type: "TEXT", nullable: false),
                    identityIp = table.Column<string>(name: "identity_Ip", type: "TEXT", nullable: false),
                    services = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    lastenter = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bloods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    barcode = table.Column<int>(type: "INTEGER", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bloods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bloods_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bloodServices",
                columns: table => new
                {
                    BloodId = table.Column<int>(type: "INTEGER", nullable: false),
                    serviceCode = table.Column<int>(type: "INTEGER", nullable: false),
                    result = table.Column<double>(type: "REAL", nullable: false),
                    finished = table.Column<double>(type: "REAL", nullable: false),
                    accepted = table.Column<bool>(type: "INTEGER", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    analyzer = table.Column<string>(type: "TEXT", nullable: false),
                    userId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
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
                    table.ForeignKey(
                        name: "FK_bloodServices_bloods_BloodId",
                        column: x => x.BloodId,
                        principalTable: "bloods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bloods_PatientId",
                table: "bloods",
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
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "bloods");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
