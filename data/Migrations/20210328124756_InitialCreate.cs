using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    NameUrl = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    NameUrl = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    NameUrl = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 35, nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    UniversityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Point = table.Column<int>(type: "INTEGER", nullable: false),
                    About = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    InstagramLink = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    TwitterLink = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 35, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityDepartments",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityDepartments", x => new { x.DepartmentId, x.UniversityId });
                    table.ForeignKey(
                        name: "FK_UniversityDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniversityDepartments_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    IsReported = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getdate()"),
                    LikeCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsVisible = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatPosts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getdate()"),
                    LikeCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPopular = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsVisible = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsReported = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UniversityId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniPosts_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniPosts_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFollowUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    FollowerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowUser", x => new { x.UserId, x.FollowerId });
                    table.ForeignKey(
                        name: "FK_UserFollowUser_AspNetUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFollowUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommentContent = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CommentDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getdate()"),
                    LikeCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsVisible = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFavorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsReported = table.Column<bool>(type: "INTEGER", nullable: false),
                    CatPostId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatComments_CatPosts_CatPostId",
                        column: x => x.CatPostId,
                        principalTable: "CatPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatPostImages",
                columns: table => new
                {
                    CatPostId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPostImages", x => new { x.CatPostId, x.ImageUrl });
                    table.ForeignKey(
                        name: "FK_CatPostImages_CatPosts_CatPostId",
                        column: x => x.CatPostId,
                        principalTable: "CatPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatPostUserLikes",
                columns: table => new
                {
                    CatPostId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatPostUserLikes", x => new { x.CatPostId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CatPostUserLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatPostUserLikes_CatPosts_CatPostId",
                        column: x => x.CatPostId,
                        principalTable: "CatPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommentContent = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CommentDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getdate()"),
                    LikeCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsReported = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsVisible = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsFavorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    UniPostId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniComments_UniPosts_UniPostId",
                        column: x => x.UniPostId,
                        principalTable: "UniPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniPostImages",
                columns: table => new
                {
                    UniPostId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniPostImages", x => new { x.ImageUrl, x.UniPostId });
                    table.ForeignKey(
                        name: "FK_UniPostImages_UniPosts_UniPostId",
                        column: x => x.UniPostId,
                        principalTable: "UniPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniPostUserLikes",
                columns: table => new
                {
                    UniPostId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniPostUserLikes", x => new { x.UserId, x.UniPostId });
                    table.ForeignKey(
                        name: "FK_UniPostUserLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniPostUserLikes_UniPosts_UniPostId",
                        column: x => x.UniPostId,
                        principalTable: "UniPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatCommentUserLikes",
                columns: table => new
                {
                    CatCommentId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatCommentUserLikes", x => new { x.UserId, x.CatCommentId });
                    table.ForeignKey(
                        name: "FK_CatCommentUserLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatCommentUserLikes_CatComments_CatCommentId",
                        column: x => x.CatCommentId,
                        principalTable: "CatComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniCommentUserLikes",
                columns: table => new
                {
                    UniCommentId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniCommentUserLikes", x => new { x.UserId, x.UniCommentId });
                    table.ForeignKey(
                        name: "FK_UniCommentUserLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniCommentUserLikes_UniComments_UniCommentId",
                        column: x => x.UniCommentId,
                        principalTable: "UniComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "NameUrl" },
                values: new object[] { 1, "Herhangi bir dilde karşılaştığınız problemlere analitik çözümler bulabilirsin ve insanlara sorunlarını çözmekte yardım edebilirsin.", "kodlama.jfif", "Yazılım", "yazilim" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "NameUrl" },
                values: new object[] { 2, "Grafik Tasarımı hakkında aklınıza takılan her soruya cevap bulabilir ve insanlara sorunlarını çözmekte yardım edebilirsin.", "grafiktasarimi.png", "Grafik Tasarım", "grafiktasarim" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "NameUrl" },
                values: new object[] { 3, "Üniversite sınavına hazırlanırken sana gereken desteği ve motivasyonu burada bulabilirsin ve insanlara yardım edebilirsin", "tyt-ayt.jpg", "YKS Sınavı", "yks" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "NameUrl" },
                values: new object[] { 4, "Okuduğunuz kitaplar hakkında insanlarla tartışabilir ve fikir alışverişinde bulunabilirsin ve insanlara sorunlarını çözmekte yardım edebilirsin.", "kitap.jpg", "Kitap", "kitap" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 101, "Moleküler Biyoloji ve Genetik", "moleküler-biyoloji-genetik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 102, "Muhasebe", "muhasebe" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 103, "Mütercim Tercümanlık", "mütercim-tercüman" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 104, "Müzecilik", "müzecilik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 105, "Nanoteknoloji Mühendisliği", "nano-teknoloji-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 106, "Odyoloji", "odyoloji" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 107, "Okul Öncesi Öğretmenliği", "okul-öncesi-ögretmenligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 109, "Ortez-Protez", "ortez-protez" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 100, "Moda Tasarımı", "moda-tasarim" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 110, "Otomotiv Mühendisliği", "otomotiv-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 111, "Pazarlama", "pazarlama" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 112, "Petrol ve Doğalgaz Mühendisliği", "petrol-dogalgaz-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 113, "Peyzaj Mimarlığı", "peyzaj-mimarligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 114, "Pilotaj", "pilotaj" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 115, "Psikoloji", "psikoloji" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 108, "Optik ve Akustik Mühendisliği", "optik-akustik-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 99, "Mimarlık", "mimarlik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 97, "Metalurji ve Malzeme Mühendisliği", "metalurji-malzeme-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 116, "Radyo ve Televizyon", "radyo-televizyon" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 81, "Kontrol ve Otomasyon Mühendisliği", "kontrol-otomasyon-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 82, "Küresel Siyaset ve Uluslarası İlişkiler", "küresel-siyaset-uluslarası-iliskiler" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 83, "Kürt Dili ve Edebiyatı", "kürt-dili-edebiyati" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 84, "Kuyumculuk ve Mücevher Tasarımı", "kuyumculuk-mücevher-tasarimi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 85, "Latin Dili ve Edebiyatı", "latin-dili-edebiyati" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 86, "Lojistik", "lojistik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 87, "Maden Mühendisliği", "maden-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 98, "Meteoroloji Mühendisliği", "meteoroloji-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 88, "Makine Mühendisliği", "makine-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 90, "Maliye", "maliye" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 91, "Malzeme Bilimi ve Mühendisliği", "malzeme" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 92, "Matematik", "matematik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 93, "Matematik Mühendisliği", "matematik-mühendsiligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 94, "Matematik Öğretmenliği", "matematik-ögretmenligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 95, "Medya ve İletişim", "medya-iletisim" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 96, "Mekatronik Mühendislği", "mekatronik-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 89, "Makine ve İmalat Mühendisliği", "makine-imalat-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 117, "Rehberlik ve Psikolojik Danışmanlık", "rehberlik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 119, "Rekreasyon", "rekreasyon" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 80, "Konaklama İşletmeciliği", "konaklama" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 141, "Türk Dili ve Edebiyatı", "türk-dili-edebiyati" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 142, "Türkoloji", "türkoloji" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 143, "Uçak Mühendisliği", "ucak-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 144, "Ulaştırma ve Lojistik", "ulastirma-ve-lojistik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 145, "Uluslarası Finans", "uluslarasi-finans" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 146, "Uluslarası İlişkiler", "uluslarasi-iliskiler" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 147, "Uluslarası İşletmecilik", "uluslarasi-isletmecilik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 140, "Turizm İşletmeciliği", "turizm-isletmeciligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 148, "Uluslarası Lojistik", "uluslarasi-lojistik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 150, "Uzay Mühendisliği", "uzay-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 151, "Veterinerlik", "veterinerlik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 152, "Yazılım Mühendisliği", "yazilim-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 153, "Yeni Medya", "yeni-medya" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 154, "Ziraat Mühendisliği Programları", "ziraat-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 155, "Zootekni", "zootekni" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 1000, "none", "none" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 149, "Uluslarası Ticaret", "uluslarasi-ticaret" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 118, "Raklamcılık", "reklamcilik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 139, "Tıp Mühendisliği", "tip-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 137, "Tekstil Mühendisliği", "tekstil-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 120, "Rus Dili ve Edebiyatı", "rus-dili-edebiyati" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 121, "Sağlık Yönetimi", "saglik-yönetimi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 122, "Sanat Tarihi", "sanat-tarihi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 123, "Şehir ve Bölge Planlama", "sehir-bölge-planlama" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 124, "Sermaye Piyasaları ve Portföy Yönetimi", "sermaye-piyasalari-portfoy-yonetimi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 125, "Seyahat İşletmeciliği", "seyahat-isletmeciligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 126, "Sigortacılık", "sigortacilik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 138, "Tıp", "tip" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 128, "Sınıf Öğretmenliği", "sinif-ögretmenligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 130, "Sosyal Hizmet", "sosyal-hizmet" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 131, "Sosyoloji", "sosyoloji" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 132, "Spor Yöneticiliği", "spor-yöneticiligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 133, "Su Bilimleri Mühendisliği", "su-bilimleri-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 134, "Tarih", "tarih" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 135, "Tarım Ekonomisi", "tarim-ekonomisi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 136, "Tarımsal Biyoteknoloji", "tarimsal-biyoloji" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 129, "Siyasal Bilimler", "siyasal-bilimler" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 79, "Kimya Mühendisliği", "kimya-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 127, "Sinema ve Televizyon", "sinema-televizyon" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 77, "Kamu Yönetimi", "kamu-yönetimi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 21, "Biyoteknoloji", "biyoteknoloji" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 22, "Çağdaş Türk Lehçeleri ve Edebiyatları", "cagdas-turk-lehceleri" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 23, "Çevre Mühendisliği", "cevre-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 24, "Çocuk Gelişimi", "cocuk-gelisimi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 25, "Coğrafya", "cografya" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 26, "Deniz İşletmeciliği ve Yönetimi", "deniz-isletmeciligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 27, "Deniz Ulaştırma İşletme Mühendisliği", "deniz-ulastirma" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 20, "Biyomühendislik", "biyomühendislik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 28, "Dijital Oyun Tasarımı", "dijital-oyun-tasarimi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 30, "Diş Hekimliği", "dis-hekimligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 31, "Ebelik", "ebelik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 32, "Eczacılık", "eczacilik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 33, "Ekonomi", "ekonomi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 34, "El Sanatları", "el-sanatlari" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 35, "Elektirik Elektronik Mühendisliği", "elektiri-kmühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 36, "Elektronik Mühendisliği", "elektronik-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 29, "Dilbilim", "dil-bilim" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 37, "Elektronik ve Haberleşme Mühendisliği", "elektronik-haberlesme-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 19, "Biyomedikal Mühendisliği", "biyomedikal" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 17, "Biyokimya", "biyokimya" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 78, "Kimya", "kimya" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 1, "Acil Yardım ve Afet Yönetimi", "acil-yardim" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 2, "Adli Bilimler", "adli-bilimler" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 3, "Aktüerya", "aktuerya" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 4, "Alman Dili ve Edebiyatı", "alman-dili-edebiyati" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 5, "Animasyon Oyun Tasarımı", "animasyon-oyun-tasarimi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 6, "Antropoloji", "antropoloji" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 18, "Biyoloji", "biyoloji" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 7, "Arap Dili ve Edebiyatı", "arap-dili-edebiyatı" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 9, "Astronomi ve Uzay Bilimleri", "astronomi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 10, "Bankacılık Finans Sigortacılık", "bankacilik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 11, "Basın ve Yayın", "basin-yayin" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 12, "Beden Eğitimi ve Spor Öğretmenliği", "beden-egitimi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 13, "Beslenme ve Diyetetik", "beslenmediyetetik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 14, "Bilgisayar Mühendisliği", "bilgisayarmühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 16, "Bilim Tarihi", "bilimtarihi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 8, "Arkeoloji", "arkeoloji" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 38, "Endüstri Mühendisliği", "endüstri-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 15, "Bilgisayar Teknolojileri ve Bilişim Sistemleri", "bilisim" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 40, "Enerji Mühendisliği", "enerji-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 61, "Havacılık ve Uzay Mühendisliği", "havacilik-ve-uzay" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 62, "Hemşirelik", "hemsirelik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 63, "Hukuk", "hukuk" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 64, "İç Mimarlık", "ic-mimarlik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 65, "İktisat", "iktisat" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 66, "İlahiyat", "ilahiyat" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 67, "İletişim", "iletisim" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 60, "Havacılık Elektirik ve Elektroniği", "havacilik-elektiril-elektronik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 69, "İngiliz Dili ve Edebiyatı", "ingiliz-dili-edebiyati" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 71, "İnsan Kaynakları Yönetimi", "insan-kaynaklari" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 72, "İş Sağlığı ve Güvenliği", "is-sagligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 73, "İslami Bilimler", "islami-bilimler" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 74, "İşletme", "isletme" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 75, "İstatistik", "istatistik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 39, "Endüstri Tasarımı", "endüstri-tasarimi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 76, "Jeofizik Mühendisliği", "jeofizik-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 70, "İnşaat Mühendisliği", "insaat-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 59, "Harita Mühendisliği", "harita-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 68, "İmalat Mühendisliği", "imalat-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 57, "Gümrük İşletme", "gümrük-isletme" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 42, "Felsefe", "felsefe" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 58, "Halkla İlişkiler", "halkla-iliskiler" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 43, "Fen Bilgisi Öğretmenliği", "fen-bilgisi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 44, "Film Tasarım ve Yazarlık", "film-tasarimi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 45, "Finans ve Bankacılık", "finans" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 46, "Fizik", "fizik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 41, "Ergoterapi", "ergoterapi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 48, "Fizyoterapi ve Rehabilitasyon", "fizyoterapi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 47, "Fizik Mühendisliği", "fizik-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 50, "Gastronomi", "gastronomi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 51, "Gazetecilik", "gazetecilik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 52, "Gemi İnşaatı ve Makineleri Mühendisliği", "gemi-insaati" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 53, "Gıda Mühendisliği", "gida-mühendisligi" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 54, "Girişimcilik", "girisimcilik" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 49, "Fransız Dili ve Edebiyatı", "fransiz-dili-edebiyati" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 56, "Grafik Tasarımı", "grafik-tasarim" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 55, "Görsel Sanatlar", "görsel-sanatlar" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 131, "KASTAMONU ÜNİVERSİTESİ", "kastamonu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 138, "KOCAELİ ÜNİVERSİTESİ", "kocaeli" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 137, "KOCAELİ SAĞLIK VE TEKNOLOJİ ÜNİVERSİTESİ", "kstu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 136, "KİLİS 7 ARALIK ÜNİVERSİTESİ", "kilis" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 133, "KIRIKKALE ÜNİVERSİTESİ", "kku" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 134, "KIRIKLARELİ ÜNİVERSİTESİ", "klu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 130, "KARAMANOĞLU MEHMET BEY ÜNİVERSİTESİ", "kmu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 132, "KAYSERİ ÜNİVERSİTESİ", "kayseri" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 135, "KIRŞEHİR AHİ EVRAN ÜNİVERSİTESİ", "ahievran" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 139, "KOÇ ÜNİVERSİTESİ", "ku" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 146, "MALATYA TURGUT ÖZAL ÜNİVERSİTESİ", "ozal" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 141, "KONYA TEKNİK ÜNİVERSİTESİ", "ktun" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 142, "KTO KARATAY ÜNİVERSİTESİ", "karatay" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 143, "KÜTAHYA DUMLUPINAR ÜNİVERSİTESİ", "dumlupinar" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 144, "KÜTAHYA SAĞLIK BİLİMLERİ ÜNİVERSİTESİ", "ksbu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 145, "LOKMAN HEKİM ÜNİVERSİTESİ", "lokmanhekim" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 147, "MALTEPE ÜNİVERSİTESİ", "maltepe" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 148, "MANİSA CELÂL BAYAR ÜNİVERSİTESİ", "cbu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 150, "MARMARA ÜNİVERSİTESİ", "marmara" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 129, "KARADENİZ TEKNİK ÜNİVERSİTESİ", "ktu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 149, "MARDİN ARTUKLU ÜNİVERSİTESİ", "artuklu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 140, "KONYA GIDA VE TARIM ÜNİVERSİTESİ", "gidatarim" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 128, "KARABÜK ÜNİVERSİTESİ", "karabuk" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 110, "İSTANBUL TİCARET ÜNİVERSİTESİ", "ticaret" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 126, "KAHRAMANMARAŞ SÜTÇÜ İMAM ÜNİVERSİTESİ", "ksu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 104, "İSTANBUL OKAN ÜNİVERSİTESİ", "okan" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 151, "MEF ÜNİVERSİTESİ", "mef" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 105, "İSTANBUL RUMELİ ÜNİVERSİTESİ", "rumeli" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 106, "İSTANBUL SABAHATTİN ÜNİVERSİTESİ", "izu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 107, "İSTANBUL SAĞLIK VE TEKNOLOJİ ÜNİVERSİTESİ", "istun" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 108, "İSTANBUL ŞİŞLİ MESLEK YÜKSEKOKULU", "sisli" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 109, "İSTANBUL TEKNİK ÜNİVERSİTESİ", "itu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 111, "İSTANBUL ÜNİVERSİTESİ", "iu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 112, "İSTANBUL ÜNİVERSİTESİ-CERRAHPAŞA", "iuc" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 113, "İSTANBUL YENİ YÜZYIL ÜNİVERSİTESİ", "yeniyuzyil" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 127, "KAPADOKYA ÜNİVERSİTESİ", "kapadokya" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 114, "İSTANBUL 29 MAYIS ÜNİVERSİTESİ", "29mayis" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 116, "İZMİR BAKIRÇAY ÜNİVERSİTESİ", "bakircay" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 117, "İZMİR DEMOKRASİ ÜNİVERSİTESİ", "idu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 118, "İZMİR EKONOMİ ÜNİVERSİTESİ", "ieu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 119, "İZMİR KATİP ÇELEBİ ÜNİVERSİTESİ", "ikc" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 120, "İZMİR KAVRAM MESLEK YÜKSEKOKULU", "kavram" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 121, "İZMİR TINAZTEPE ÜNİVERSİTESİ", "tinaztepe" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 122, "İZMİR YÜKSEK TEKNOLOJİ ENSTİTÜSÜ", "iyte" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 123, "KADİR HAS ÜNİVERSİTESİ", "khas" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 124, "KAFKAS ÜNİVERSİTESİ", "kafkas" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 125, "KAHRAMANMARAŞ İSTİKLAL ÜNİVERSİTESİ", "istiklal" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 115, "İSTİNYE ÜNİVERSİTESİ", "istinye" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 152, "MERSİN ÜNİVERSİTESİ", "mersin" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 191, "TRAKYA ÜNİVERSİTESİ", "trakya" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 154, "MUĞLA SITKI KOÇMAN ÜNİVERSİTESİ", "mu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 181, "SİVAS CUMHURİYET ÜNİVERSİTESİ", "cumhuriyet" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 182, "SÜLEYMAN DEMİREL ÜNİVERSİTESİ", "sdu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 183, "ŞIRNAK ÜNİVERSİTESİ", "sirnak" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 184, "TARSUS ÜNİVERSİTESİ", "tarsus" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 185, "TED ÜNİVERSİTESİ", "tedu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 186, "TEKİRDAĞ NAMIK KEMAL ÜNİVERSİTESİ", "nku" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 187, "TOBB EKONOMİ VE TEKNOLOJİ ÜNİVERSİTvESİ", "etu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 188, "TOKAT GAZİOSMANPAŞA ÜNİVERSİTESİ", "gop" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 189, "TOROS ÜNİVERSİTESİ", "toros" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 190, "TRABZON ÜNİVERSİTESİ", "trabzon" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 180, "SİVAS BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ", "sivas" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 192, "TÜRK HAVA KURUMU ÜNİVERSİTESİ", "thk" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 194, "UFUK ÜNİVERSİTESİ", "ufuk" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 195, "UŞAK ÜNİVERSİTESİ", "usak" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 196, "ÜSKÜDAR ÜNİVERSİTESİ", "uskudar" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 197, "VAN YÜZÜNCÜ YIL ÜNİVERSİTESİ", "vyyu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 198, "YALOVA ÜNİVERSİTESİ", "yalova" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 199, "YAŞAR ÜNİVERSİTESİ", "yasar" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 200, "YEDİTEPE ÜNİVERSİTESİ", "yeditepe" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 201, "YILDIZ TEKNİK ÜNİVERSİTESİ", "ytu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 202, "YOZGAT BOZOK ÜNİVERSİTESİ", "bozok" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 103, "İSTANBUL MEDİPOL ÜNİVERSİTESİ", "medipol" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 193, "TÜRK-ALMAN ÜNİVERSİTESİ", "tau" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 153, "MİMAR SİNAN GÜZEL SANATLAR ÜNİVERSİTESİ", "msgsu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 179, "SİNOP ÜNİVERSİTESİ", "sinop" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 177, "SELÇUK ÜNİVERSİTESİ", "selcuk" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 155, "MUNZUR ÜNİVERSİTESİ", "munzur" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 156, "MUŞ ALPARSLAN ÜNİVERSİTESİ", "alparslan" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 157, "NECMETTİN ERBAKAN ÜNİVERSİTESİ", "erbakan" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 158, "NEVŞEHİR HACI BEKTAŞ VELİ ÜNİVERSİTESİ", "nevsehir" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 159, "NİĞDE ÖMER HALİSDEMİR ÜNİVERSİTESİ", "ohu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 160, "NİŞANTAŞI ÜNİVERSİTESİ", "nisantasi" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 161, "NUH NACİ YAZGAN ÜNİVERSİTESİ", "nny" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 162, "ONDOKUZ MAYIS ÜNİVERSİTESİ", "omu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 163, "ORDU ÜNİVERSİTESİ", "odu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 164, "ORTA DOĞU TEKNİK ÜNİVERSİTESİ", "odtu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 178, "SİİRT ÜNİVERSİTESİ", "siirt" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 165, "OSMANİYE KORKUT ATA ÜNİVERSİTESİ", "osmaniye" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 167, "ÖZYEĞİN ÜNİVERSİTESİ", "ozyegin" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 168, "PAMUKKALE ÜNİVERSİTESİ", "pau" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 169, "PİRİ REİS ÜNİVERSİTESİ", "pirireis" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 170, "RECEP TAYYİP ERDOĞAN ÜNİVERSİTESİ", "erdogan" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 171, "SABANCI ÜNİVERSİTESİ", "sabanci" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 172, "SAĞLIK BİLİMLERİ ÜNİVERSİTESİ", "sbu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 173, "SAKARYA UYGULAMALI BİLİMLER ÜNİVERSİTESİ", "subu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 174, "SAKARYA ÜNİVERSİTESİ", "sakarya" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 175, "SAMSUN ÜNİVERSİTESİ", "samsun" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 176, "SANKO ÜNİVERSİTESİ", "sanko" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 166, "OSTİM TEKNİK ÜNİVERSİTESİ", "ostimteknik" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 102, "İSTANBUL MEDENİYET ÜNİVERSİTESİ", "medeniyet" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 22, "ANKARA YILDIRIM BEYAZIT ÜNİVERSİTESİ", "aybu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 100, "İSTANBUL KENT ÜNİVERSİTESİ", "kent" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 27, "ATAŞEHİR ADIGÜZEL MESLEK YÜKSEKOKULU", "adiguzel" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 28, "ATATÜRK ÜNİVERSİTESİ", "atauni" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 29, "ATILIM ÜNİVERSİTES", "atilim" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 30, "AVRASYA ÜNİVERSİTESİ", "avrasya" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 31, "AYDIN ADNAN MENDERES ÜNİVERSİTESİ", "adu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 32, "BAHÇEŞEHİR ÜNİVERSİTESİ", "bahcesehir" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 33, "BALIKESİR ÜNİVERSİTESİ", "balikesir" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 34, "BANDIRMA ONYEDİ EYLÜL ÜNİVERSİTESİ", "bandirma" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 35, "BARTIN ÜNİVERSİTESİ", "bartin" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 36, "BAŞKENT ÜNİVERSİTESİ", "baskent" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 37, "BATMAN ÜNİVERSİTESİ", "batman" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 38, "BAYBURT ÜNİVERSİTESİ", "bayburt" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 39, "BEYKENT ÜNİVERSİTESİ", "beykent" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 40, "BEYKOZ ÜNİVERSİTESİ", "beykoz" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 41, "BEZM-İ ÂLEM VAKIF ÜNİVERSİTESİ", "bezmialem" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 42, "BİLECİK ŞEYH EDEBALİ ÜNİVERSİTESİ", "bilecik" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 43, "BİNGÖL ÜNİVERSİTESİ", "bingol" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 44, "BİRUNİ ÜNİVERSİTESİ", "biruni" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 45, "BİTLİS EREN ÜNİVERSİTESİ", "beu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 46, "BOĞAZİÇİ ÜNİVERSİTESİ", "boun" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 47, "BOLU ABANT İZZET BAYSAL ÜNİVERSİTESİ", "ibu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 26, "ARTVİN ÇORUH ÜNİVERSİTESİ", "artvin" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 25, "ARDAHAN ÜNİVERSİTESİ", "ardahan" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 24, "ANTALYA BİLİM ÜNİVERSİTESİ", "antalya" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 23, "ANTALYA AKEV ÜNİVERSİTESİ", "akev" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 1, "ABDULLAH GÜL ÜNİVERSİTESİ", "agu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 2, "ACIBADEM MEHMET ALİ AYDINLAR ÜNİVERSİTESİ", "acibadem" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 3, "ADANA ALPARSLAN TÜRKEŞ BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ", "atu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 4, "ADIYAMAN ÜNİVERSİTESİ", "adiyaman" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 5, "AFYON KOCATEPE ÜNİVERSİTESİ", "aku" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 6, "AFYONKARAHİSAR SAĞLIK BİLİMLERİ ÜNİVERSİTESİ", "afsu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 7, "AĞRI İBRAHİM ÇEÇEN ÜNİVERSİTESİ", "agri" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 8, "AKDENİZ ÜNİVERSİTESİ", "akdeniz" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 9, "AKSARAY ÜNİVERSİTESİ", "aksaray" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 10, "ALANYA ALAADDİN KEYKUBAT ÜNİVERSİTESİ", "alanya" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 48, "BURDUR MEHMET AKİF ERSOY ÜNİVERSİTESİ", "mehmetakif" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 11, "ALANYA HAMDULLAH EMİN PAŞA ÜNİVERSİTESİ", "ahep" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 13, "AMASYA ÜNİVERSİTESİ", "amasya" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 14, "ANADOLU ÜNİVERSİTESİ", "adiyamanadoluan" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 15, "ANKA TEKNOLOJİ ÜNİVERSİTESİ", "anka" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 16, "ANKARA BİLİM ÜNİVERSİTESİ", "ankarabilim" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 17, "ANKARA HACI BAYRAM VELİ ÜNİVERSİTESİ", "hacibayram" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 18, "ANKARA MEDİPOL ÜNİVERSİTESİ", "hacibayram" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 19, "ANKARA MÜZİK VE GÜZEL SANATLAR ÜNİVERSİTESİ", "mgu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 20, "ANKARA SOSYAL BİLİMLER ÜNİVERSİTESİ", "asbu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 21, "ANKARA ÜNİVERSİTESİ", "ankara" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 203, "YÜKSEK İHTİSAS ÜNİVERSİTESİ", "yiu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 12, "ALTINBAŞ ÜNİVERSİTESİ", "altinbas" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 49, "BURSA TEKNİK ÜNİVERSİTESİ", "btu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 50, "BURSA ULUDAĞ ÜNİVERSİTESİ", "uludag" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 51, "ÇAĞ ÜNİVERSİTESİ", "cag" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 78, "HAKKARİ ÜNİVERSİTESİ", "hakkari" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 79, "HALİÇ ÜNİVERSİTESİ", "halic" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 80, "HARRAN ÜNİVERSİTESİ", "harran" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 81, "HASAN KALYONCU ÜNİVERSİTESİ", "hku" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 82, "HATAY MUSTAFA KEMAL ÜNİVERSİTESİ", "mku" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 83, "HİTİT ÜNİVERSİTESİ", "hitit" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 84, "IĞDIR ÜNİVERSİTESİ", "igdir" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 85, "ISPARTA UYGULAMALI BİLİMLER ÜNİVERSİTESİ", "ısparta" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 86, "IŞIK ÜNİVERSİTESİ", "isikun" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 87, "İBN HALDUN ÜNİVERSİTESİ", "ihu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 77, "HACETTEPE ÜNİVERSİTESİ", "hacettepe" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 88, "İHSAN DOĞRAMACI ÜNİVERSİTESİ", "idbilkent" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 90, "İSKENDERUN TEKNİK ÜNİVERSİTESİ", "iste" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 91, "İSTANBUL AREL ÜNİVERSİTESİ", "arel" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 92, "İSTANBUL ATLAS ÜNİVERSİTESİ", "atlas" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 93, "İSTANBUL AYDIN ÜNİVERSİTESİ", "aydin" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 94, "İSTANBUL AYVANSARAY ÜNİVERSİTESİ", "ayvansaray" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 95, "İSTANBUL BİLGİ ÜNİVERSİTESİ", "bilgi" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 96, "İSTANBUL ESENYURT ÜNİVERSİTESİ", "esenyurt" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 97, "İSTANBUL GALATA ÜNİVERSİTESİ", "galata" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 98, "İSTANBUL GEDİK ÜNİVERSİTESİ", "gedik" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 99, "İSTANBUL GELİŞİM ÜNİVERSİTESİ", "gelisim" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 89, "İNÖNÜ ÜNİVERSİTESİ", "inonu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 101, "İSTANBUL KÜLTÜR ÜNİVERSİTESİ", "kültür" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 76, "GÜMÜŞHANE ÜNİVERSİTESİ", "gumushane" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 74, "GEBZE TEKNİK ÜNİVERSİTESİ", "gtu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 52, "ÇANAKKALE ONSEKİZ MART ÜNİVERSİTESİ", "comu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 53, "ÇANKAYA ÜNİVERSİTESİ", "cankaya" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 54, "ÇANKIRI KARATEKİN ÜNİVERSİTESİ", "karatekin" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 55, "ÇUKUROVA ÜNİVERSİTESİ", "cu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 56, "DEMİROĞLU BİLİM ÜNİVERSİTESİ", "istanbulbilim" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 57, "DİCLE ÜNİVERSİTESİ", "dicle" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 58, "DOĞUŞ ÜNİVERSİTESİ", "dogus" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 59, "DOKUZ EYLÜL ÜNİVERSİTESİ", "deu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 60, "EGE ÜNİVERSİTESİ", "ege" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 61, "ERCİYES ÜNİVERSİTESİ", "erciyes" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 75, "GİRESUN ÜNİVERSİTESİ", "giresun" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 62, "ERZİNCAN BİNALİ YILDIRIM ÜNİVERSİTESİ", "erzincan" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 64, "ESKİŞEHİR OSMANGAZİ ÜNİVERSİTESİ", "ogu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 65, "ESKİŞEHİR TEKNİK ÜNİVERSİTESİ", "eskisehir" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 66, "FARUK SARAÇ TASARIM MESLEK YÜKSEKOKULU", "faruksarac" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 67, "FATİH SULTAN MEHMET VAKIF ÜNİVERSİTESİ", "fsm" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 68, "FENERBAHÇE ÜNİVERSİTESİ", "fbu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 69, "FIRAT ÜNİVERSİTESİ", "fırat" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 70, "GALATASARY ÜNİVERSİTESİ", "gsu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 71, "GAZİ ÜNİVERSİTESİ", "gazi" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 72, "GAZİANTEP İSLAM BİLİM VE TEKNOLOJİ ÜNİVERSİTESİ", "gibtu" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 73, "GAZİANTEP ÜNİVERSİTESİ", "gantep" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 63, "ERZURUM TEKNİK ÜNİVERSİTESİ", "erzurum" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name", "NameUrl" },
                values: new object[] { 204, "ZONGULDAK BÜLENT ECEVİT ÜNİVERSİTESİ", "beun" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UniversityId",
                table: "AspNetUsers",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatComments_CatPostId",
                table: "CatComments",
                column: "CatPostId");

            migrationBuilder.CreateIndex(
                name: "IX_CatComments_UserId",
                table: "CatComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CatCommentUserLikes_CatCommentId",
                table: "CatCommentUserLikes",
                column: "CatCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CatPosts_CategoryId",
                table: "CatPosts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CatPosts_UserId",
                table: "CatPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CatPostUserLikes_UserId",
                table: "CatPostUserLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UniComments_UniPostId",
                table: "UniComments",
                column: "UniPostId");

            migrationBuilder.CreateIndex(
                name: "IX_UniComments_UserId",
                table: "UniComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UniCommentUserLikes_UniCommentId",
                table: "UniCommentUserLikes",
                column: "UniCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_UniPostImages_UniPostId",
                table: "UniPostImages",
                column: "UniPostId");

            migrationBuilder.CreateIndex(
                name: "IX_UniPosts_DepartmentId",
                table: "UniPosts",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UniPosts_UniversityId",
                table: "UniPosts",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_UniPosts_UserId",
                table: "UniPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UniPostUserLikes_UniPostId",
                table: "UniPostUserLikes",
                column: "UniPostId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityDepartments_UniversityId",
                table: "UniversityDepartments",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowUser_FollowerId",
                table: "UserFollowUser",
                column: "FollowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CatCommentUserLikes");

            migrationBuilder.DropTable(
                name: "CatPostImages");

            migrationBuilder.DropTable(
                name: "CatPostUserLikes");

            migrationBuilder.DropTable(
                name: "UniCommentUserLikes");

            migrationBuilder.DropTable(
                name: "UniPostImages");

            migrationBuilder.DropTable(
                name: "UniPostUserLikes");

            migrationBuilder.DropTable(
                name: "UniversityDepartments");

            migrationBuilder.DropTable(
                name: "UserFollowUser");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CatComments");

            migrationBuilder.DropTable(
                name: "UniComments");

            migrationBuilder.DropTable(
                name: "CatPosts");

            migrationBuilder.DropTable(
                name: "UniPosts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
