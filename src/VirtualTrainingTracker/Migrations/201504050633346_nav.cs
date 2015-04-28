using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.MigrationsModel;
using System;

namespace VirtualTrainingTracker.Migrations
{
    public partial class nav : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("AspNetRoles",
                c => new
                    {
                        Id = c.String(),
                        ConcurrencyStamp = c.String(),
                        Name = c.String(),
                        NormalizedName = c.String()
                    })
                .PrimaryKey("PK_AspNetRoles", t => t.Id);
            
            migrationBuilder.CreateTable("AspNetRoleClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        RoleId = c.String()
                    })
                .PrimaryKey("PK_AspNetRoleClaims", t => t.Id);
            
            migrationBuilder.CreateTable("AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        UserId = c.String()
                    })
                .PrimaryKey("PK_AspNetUserClaims", t => t.Id);
            
            migrationBuilder.CreateTable("AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ProviderDisplayName = c.String(),
                        UserId = c.String()
                    })
                .PrimaryKey("PK_AspNetUserLogins", t => new { t.LoginProvider, t.ProviderKey });
            
            migrationBuilder.CreateTable("AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(),
                        RoleId = c.String()
                    })
                .PrimaryKey("PK_AspNetUserRoles", t => new { t.UserId, t.RoleId });
            
            migrationBuilder.CreateTable("AspNetUsers",
                c => new
                    {
                        Id = c.String(),
                        AccessFailedCount = c.Int(nullable: false),
                        ConcurrencyStamp = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        LockoutEnabled = c.Boolean(nullable: false),
                        LockoutEnd = c.DateTimeOffset(),
                        NormalizedEmail = c.String(),
                        NormalizedUserName = c.String(),
                        PasswordHash = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        SecurityStamp = c.String(),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        UserName = c.String()
                    })
                .PrimaryKey("PK_AspNetUsers", t => t.Id);
            
            migrationBuilder.CreateTable("Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Duration = c.Int(nullable: false),
                        Title = c.String()
                    })
                .PrimaryKey("PK_Course", t => t.CourseID);
            
            migrationBuilder.CreateTable("CourseTracker",
                c => new
                    {
                        CourseTrackerID = c.Int(nullable: false, identity: true),
                        IsCompleted = c.Boolean(nullable: false),
                        ApplicationUserId = c.String(),
                        CourseID = c.Int(nullable: false)
                    })
                .PrimaryKey("PK_CourseTracker", t => t.CourseTrackerID);
            
            migrationBuilder.AddForeignKey(
                "AspNetRoleClaims",
                "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                new[] { "RoleId" },
                "AspNetRoles",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "AspNetUserClaims",
                "FK_AspNetUserClaims_AspNetUsers_UserId",
                new[] { "UserId" },
                "AspNetUsers",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "AspNetUserLogins",
                "FK_AspNetUserLogins_AspNetUsers_UserId",
                new[] { "UserId" },
                "AspNetUsers",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "CourseTracker",
                "FK_CourseTracker_AspNetUsers_ApplicationUserId",
                new[] { "ApplicationUserId" },
                "AspNetUsers",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "CourseTracker",
                "FK_CourseTracker_Course_CourseID",
                new[] { "CourseID" },
                "Course",
                new[] { "CourseID" },
                cascadeDelete: false);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("AspNetRoleClaims", "FK_AspNetRoleClaims_AspNetRoles_RoleId");
            
            migrationBuilder.DropForeignKey("AspNetUserClaims", "FK_AspNetUserClaims_AspNetUsers_UserId");
            
            migrationBuilder.DropForeignKey("AspNetUserLogins", "FK_AspNetUserLogins_AspNetUsers_UserId");
            
            migrationBuilder.DropForeignKey("CourseTracker", "FK_CourseTracker_AspNetUsers_ApplicationUserId");
            
            migrationBuilder.DropForeignKey("CourseTracker", "FK_CourseTracker_Course_CourseID");
            
            migrationBuilder.DropTable("AspNetRoles");
            
            migrationBuilder.DropTable("AspNetRoleClaims");
            
            migrationBuilder.DropTable("AspNetUserClaims");
            
            migrationBuilder.DropTable("AspNetUserLogins");
            
            migrationBuilder.DropTable("AspNetUserRoles");
            
            migrationBuilder.DropTable("AspNetUsers");
            
            migrationBuilder.DropTable("Course");
            
            migrationBuilder.DropTable("CourseTracker");
        }
    }
}