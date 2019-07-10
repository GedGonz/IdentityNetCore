using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityNetCore.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SEG");

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "SEG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "SEG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleNotificacion",
                schema: "SEG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleNotificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleNotificacion_Rol_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "SEG",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioLogin",
                schema: "SEG",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    IdUsuarioLogin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.UniqueConstraint("AK_UsuarioLogin_IdUsuarioLogin", x => x.IdUsuarioLogin);
                    table.ForeignKey(
                        name: "FK_UsuarioLogin_Usuario_UserId",
                        column: x => x.UserId,
                        principalSchema: "SEG",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioNotificacion",
                schema: "SEG",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioNotificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioNotificacion_Usuario_UserId",
                        column: x => x.UserId,
                        principalSchema: "SEG",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRole",
                schema: "SEG",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsuarioRole_Rol_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "SEG",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRole_Usuario_UserId",
                        column: x => x.UserId,
                        principalSchema: "SEG",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioToken",
                schema: "SEG",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    IdUsuarioToken = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.UniqueConstraint("AK_UsuarioToken_IdUsuarioToken", x => x.IdUsuarioToken);
                    table.ForeignKey(
                        name: "FK_UsuarioToken_Usuario_UserId",
                        column: x => x.UserId,
                        principalSchema: "SEG",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "SEG",
                table: "Rol",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleNotificacion_RoleId",
                schema: "SEG",
                table: "RoleNotificacion",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "SEG",
                table: "Usuario",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "SEG",
                table: "Usuario",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioLogin_UserId",
                schema: "SEG",
                table: "UsuarioLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioNotificacion_UserId",
                schema: "SEG",
                table: "UsuarioNotificacion",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRole_RoleId",
                schema: "SEG",
                table: "UsuarioRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleNotificacion",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "UsuarioLogin",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "UsuarioNotificacion",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "UsuarioRole",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "UsuarioToken",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "SEG");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "SEG");
        }
    }
}
