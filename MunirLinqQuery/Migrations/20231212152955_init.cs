using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunirLinqQuery.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrolled",
                columns: table => new
                {
                    eid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sid = table.Column<int>(type: "int", nullable: false),
                    cid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolled", x => x.eid);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roomNo = table.Column<int>(type: "int", nullable: false),
                    facultyfid = table.Column<int>(type: "int", nullable: false),
                    Enrolledeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.cid);
                    table.ForeignKey(
                        name: "FK_Classes_Enrolled_Enrolledeid",
                        column: x => x.Enrolledeid,
                        principalTable: "Enrolled",
                        principalColumn: "eid");
                });

            migrationBuilder.CreateTable(
                name: "std",
                columns: table => new
                {
                    sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    standing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marks = table.Column<int>(type: "int", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    Classcid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_std", x => x.sid);
                    table.ForeignKey(
                        name: "FK_std_Classes_Classcid",
                        column: x => x.Classcid,
                        principalTable: "Classes",
                        principalColumn: "cid");
                });

            migrationBuilder.CreateTable(
                name: "EnrolledStudent",
                columns: table => new
                {
                    enrollseid = table.Column<int>(type: "int", nullable: false),
                    studentssid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledStudent", x => new { x.enrollseid, x.studentssid });
                    table.ForeignKey(
                        name: "FK_EnrolledStudent_Enrolled_enrollseid",
                        column: x => x.enrollseid,
                        principalTable: "Enrolled",
                        principalColumn: "eid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolledStudent_std_studentssid",
                        column: x => x.studentssid,
                        principalTable: "std",
                        principalColumn: "sid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    fid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    depid = table.Column<int>(type: "int", nullable: false),
                    standing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enrolleid = table.Column<int>(type: "int", nullable: false),
                    Studentsid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.fid);
                    table.ForeignKey(
                        name: "FK_Faculties_Enrolled_enrolleid",
                        column: x => x.enrolleid,
                        principalTable: "Enrolled",
                        principalColumn: "eid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faculties_std_Studentsid",
                        column: x => x.Studentsid,
                        principalTable: "std",
                        principalColumn: "sid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Enrolledeid",
                table: "Classes",
                column: "Enrolledeid");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_facultyfid",
                table: "Classes",
                column: "facultyfid");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledStudent_studentssid",
                table: "EnrolledStudent",
                column: "studentssid");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_enrolleid",
                table: "Faculties",
                column: "enrolleid");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_Studentsid",
                table: "Faculties",
                column: "Studentsid");

            migrationBuilder.CreateIndex(
                name: "IX_std_Classcid",
                table: "std",
                column: "Classcid");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Faculties_facultyfid",
                table: "Classes",
                column: "facultyfid",
                principalTable: "Faculties",
                principalColumn: "fid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Enrolled_Enrolledeid",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Enrolled_enrolleid",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Faculties_facultyfid",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "EnrolledStudent");

            migrationBuilder.DropTable(
                name: "Enrolled");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "std");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
