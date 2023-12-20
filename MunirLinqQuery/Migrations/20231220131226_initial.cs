using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunirLinqQuery.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "depts",
                columns: table => new
                {
                    deptid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deptName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_depts", x => x.deptid);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    fid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    standing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deptid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.fid);
                });

            migrationBuilder.CreateTable(
                name: "std",
                columns: table => new
                {
                    sid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    major = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    standing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    marks = table.Column<int>(type: "int", nullable: false),
                    EnrolledClassesCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_std", x => x.sid);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    cid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roomNo = table.Column<int>(type: "int", nullable: false),
                    fid = table.Column<int>(type: "int", nullable: false),
                    Facultyfid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.cid);
                    table.ForeignKey(
                        name: "FK_Classes_Faculties_Facultyfid",
                        column: x => x.Facultyfid,
                        principalTable: "Faculties",
                        principalColumn: "fid");
                });

            migrationBuilder.CreateTable(
                name: "ClassStudent",
                columns: table => new
                {
                    classescid = table.Column<int>(type: "int", nullable: false),
                    studentssid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudent", x => new { x.classescid, x.studentssid });
                    table.ForeignKey(
                        name: "FK_ClassStudent_Classes_classescid",
                        column: x => x.classescid,
                        principalTable: "Classes",
                        principalColumn: "cid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudent_std_studentssid",
                        column: x => x.studentssid,
                        principalTable: "std",
                        principalColumn: "sid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrolled",
                columns: table => new
                {
                    eid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fid = table.Column<int>(type: "int", nullable: false),
                    sid = table.Column<int>(type: "int", nullable: false),
                    cid = table.Column<int>(type: "int", nullable: false),
                    facultyfid = table.Column<int>(type: "int", nullable: true),
                    clscid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolled", x => x.eid);
                    table.ForeignKey(
                        name: "FK_Enrolled_Classes_clscid",
                        column: x => x.clscid,
                        principalTable: "Classes",
                        principalColumn: "cid");
                    table.ForeignKey(
                        name: "FK_Enrolled_Faculties_facultyfid",
                        column: x => x.facultyfid,
                        principalTable: "Faculties",
                        principalColumn: "fid");
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

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Facultyfid",
                table: "Classes",
                column: "Facultyfid");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudent_studentssid",
                table: "ClassStudent",
                column: "studentssid");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolled_clscid",
                table: "Enrolled",
                column: "clscid");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolled_facultyfid",
                table: "Enrolled",
                column: "facultyfid");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledStudent_studentssid",
                table: "EnrolledStudent",
                column: "studentssid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudent");

            migrationBuilder.DropTable(
                name: "depts");

            migrationBuilder.DropTable(
                name: "EnrolledStudent");

            migrationBuilder.DropTable(
                name: "Enrolled");

            migrationBuilder.DropTable(
                name: "std");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
