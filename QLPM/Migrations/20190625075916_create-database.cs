using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLPM.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOP",
                columns: table => new
                {
                    MALOP = table.Column<string>(nullable: false),
                    TENLOP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOP", x => x.MALOP);
                });

            migrationBuilder.CreateTable(
                name: "PHONG",
                columns: table => new
                {
                    MAPHONG = table.Column<string>(nullable: false),
                    TENPHONG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHONG", x => x.MAPHONG);
                });

            migrationBuilder.CreateTable(
                name: "QUYENHAN",
                columns: table => new
                {
                    MAQH = table.Column<string>(nullable: false),
                    TENQH = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUYENHAN", x => x.MAQH);
                });

            migrationBuilder.CreateTable(
                name: "TRANGTHAI",
                columns: table => new
                {
                    MATT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TENTT = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANGTHAI", x => x.MATT);
                });

            migrationBuilder.CreateTable(
                name: "GIANGVIEN",
                columns: table => new
                {
                    MAGV = table.Column<string>(nullable: false),
                    TEN = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true),
                    SDT = table.Column<string>(nullable: true),
                    MAQH = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIANGVIEN", x => x.MAGV);
                    table.ForeignKey(
                        name: "FK_GIANGVIEN_QUYENHAN_MAQH",
                        column: x => x.MAQH,
                        principalTable: "QUYENHAN",
                        principalColumn: "MAQH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TAIKHOAN",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    USERNAME = table.Column<string>(nullable: true),
                    PASSWORD = table.Column<string>(nullable: true),
                    MAQH = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAIKHOAN", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TAIKHOAN_QUYENHAN_MAQH",
                        column: x => x.MAQH,
                        principalTable: "QUYENHAN",
                        principalColumn: "MAQH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DAYMAY",
                columns: table => new
                {
                    MADM = table.Column<string>(nullable: false),
                    TENDM = table.Column<string>(nullable: true),
                    MATT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DAYMAY", x => x.MADM);
                    table.ForeignKey(
                        name: "FK_DAYMAY_TRANGTHAI_MATT",
                        column: x => x.MATT,
                        principalTable: "TRANGTHAI",
                        principalColumn: "MATT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DANGKYTIETHOC",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MADM = table.Column<string>(nullable: true),
                    MAGV = table.Column<string>(nullable: true),
                    MALOP = table.Column<string>(nullable: true),
                    MAPHONG = table.Column<string>(nullable: true),
                    CABATDAU = table.Column<DateTime>(nullable: true),
                    GHICHU = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANGKYTIETHOC", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DANGKYTIETHOC_DAYMAY_MADM",
                        column: x => x.MADM,
                        principalTable: "DAYMAY",
                        principalColumn: "MADM",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DANGKYTIETHOC_GIANGVIEN_MAGV",
                        column: x => x.MAGV,
                        principalTable: "GIANGVIEN",
                        principalColumn: "MAGV",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DANGKYTIETHOC_LOP_MALOP",
                        column: x => x.MALOP,
                        principalTable: "LOP",
                        principalColumn: "MALOP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DANGKYTIETHOC_PHONG_MAPHONG",
                        column: x => x.MAPHONG,
                        principalTable: "PHONG",
                        principalColumn: "MAPHONG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MAYTINH",
                columns: table => new
                {
                    MAMT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TENMT = table.Column<string>(nullable: true),
                    MADM = table.Column<string>(nullable: true),
                    MATT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAYTINH", x => x.MAMT);
                    table.ForeignKey(
                        name: "FK_MAYTINH_DAYMAY_MADM",
                        column: x => x.MADM,
                        principalTable: "DAYMAY",
                        principalColumn: "MADM",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MAYTINH_TRANGTHAI_MATT",
                        column: x => x.MATT,
                        principalTable: "TRANGTHAI",
                        principalColumn: "MATT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DANGKYTIETHOC_MADM",
                table: "DANGKYTIETHOC",
                column: "MADM");

            migrationBuilder.CreateIndex(
                name: "IX_DANGKYTIETHOC_MAGV",
                table: "DANGKYTIETHOC",
                column: "MAGV");

            migrationBuilder.CreateIndex(
                name: "IX_DANGKYTIETHOC_MALOP",
                table: "DANGKYTIETHOC",
                column: "MALOP");

            migrationBuilder.CreateIndex(
                name: "IX_DANGKYTIETHOC_MAPHONG",
                table: "DANGKYTIETHOC",
                column: "MAPHONG");

            migrationBuilder.CreateIndex(
                name: "IX_DAYMAY_MATT",
                table: "DAYMAY",
                column: "MATT");

            migrationBuilder.CreateIndex(
                name: "IX_GIANGVIEN_MAQH",
                table: "GIANGVIEN",
                column: "MAQH");

            migrationBuilder.CreateIndex(
                name: "IX_MAYTINH_MADM",
                table: "MAYTINH",
                column: "MADM");

            migrationBuilder.CreateIndex(
                name: "IX_MAYTINH_MATT",
                table: "MAYTINH",
                column: "MATT");

            migrationBuilder.CreateIndex(
                name: "IX_TAIKHOAN_MAQH",
                table: "TAIKHOAN",
                column: "MAQH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DANGKYTIETHOC");

            migrationBuilder.DropTable(
                name: "MAYTINH");

            migrationBuilder.DropTable(
                name: "TAIKHOAN");

            migrationBuilder.DropTable(
                name: "GIANGVIEN");

            migrationBuilder.DropTable(
                name: "LOP");

            migrationBuilder.DropTable(
                name: "PHONG");

            migrationBuilder.DropTable(
                name: "DAYMAY");

            migrationBuilder.DropTable(
                name: "QUYENHAN");

            migrationBuilder.DropTable(
                name: "TRANGTHAI");
        }
    }
}
