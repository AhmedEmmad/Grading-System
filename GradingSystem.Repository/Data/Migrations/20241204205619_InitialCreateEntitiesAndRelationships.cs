using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingSystem.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateEntitiesAndRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradingCriterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingCriterias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradingSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradingSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrInstructions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrInstructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrInstructions_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsFromDrs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsFromDrs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsFromDrs_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcceptedProjectsFromDrs",
                columns: table => new
                {
                    ProjectFromDrId = table.Column<int>(type: "int", nullable: false),
                    RequestProjectFromTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedProjectsFromDrs", x => new { x.ProjectFromDrId, x.RequestProjectFromTeamId });
                    table.ForeignKey(
                        name: "FK_AcceptedProjectsFromDrs_ProjectsFromDrs_ProjectFromDrId",
                        column: x => x.ProjectFromDrId,
                        principalTable: "ProjectsFromDrs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcceptedProjectsFromTeams",
                columns: table => new
                {
                    ProjectFromTeamId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedProjectsFromTeams", x => new { x.ProjectFromTeamId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_AcceptedProjectsFromTeams_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommitteeGradings",
                columns: table => new
                {
                    GradingCriteriaId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    GradingScheduleId = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeGradings", x => new { x.GradingCriteriaId, x.DoctorId, x.StudentId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_CommitteeGradings_GradingCriterias_GradingCriteriaId",
                        column: x => x.GradingCriteriaId,
                        principalTable: "GradingCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    GradingScheduleId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => new { x.GradingScheduleId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_Committees_GradingSchedules_GradingScheduleId",
                        column: x => x.GradingScheduleId,
                        principalTable: "GradingSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorCommittees",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    GradingScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorCommittees", x => new { x.DoctorId, x.GradingScheduleId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_DoctorCommittees_Committees_TeamId_GradingScheduleId",
                        columns: x => new { x.TeamId, x.GradingScheduleId },
                        principalTable: "Committees",
                        principalColumns: new[] { "GradingScheduleId", "TeamId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorCommittees_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsFromTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsFromTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestProjectsFromTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestProjectsFromTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InTeam = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTaskAssignments",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Mark = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTaskAssignments", x => new { x.StudentId, x.TaskId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_StudentTaskAssignments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTaskAssignments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTaskAssignments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupervisorGradings",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    GradingCriteriaId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisorGradings", x => new { x.StudentId, x.GradingCriteriaId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_SupervisorGradings_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupervisorGradings_GradingCriterias_GradingCriteriaId",
                        column: x => x.GradingCriteriaId,
                        principalTable: "GradingCriterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupervisorGradings_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasProject = table.Column<bool>(type: "bit", nullable: false),
                    LeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Students_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTeamInvitations",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsInviterStudent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeamInvitations", x => new { x.StudentId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_StudentTeamInvitations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentTeamInvitations_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedProjectsFromDrs_ProjectFromDrId",
                table: "AcceptedProjectsFromDrs",
                column: "ProjectFromDrId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedProjectsFromDrs_RequestProjectFromTeamId",
                table: "AcceptedProjectsFromDrs",
                column: "RequestProjectFromTeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedProjectsFromTeams_DoctorId",
                table: "AcceptedProjectsFromTeams",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedProjectsFromTeams_ProjectFromTeamId",
                table: "AcceptedProjectsFromTeams",
                column: "ProjectFromTeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Email",
                table: "Admins",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_DoctorId_StudentId_Time",
                table: "Chats",
                columns: new[] { "DoctorId", "StudentId", "Time" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_StudentId",
                table: "Chats",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeGradings_DoctorId_GradingScheduleId_TeamId",
                table: "CommitteeGradings",
                columns: new[] { "DoctorId", "GradingScheduleId", "TeamId" });

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeGradings_StudentId",
                table: "CommitteeGradings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Committees_TeamId",
                table: "Committees",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorCommittees_TeamId_GradingScheduleId",
                table: "DoctorCommittees",
                columns: new[] { "TeamId", "GradingScheduleId" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                table: "Doctors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrInstructions_AdminId",
                table: "DrInstructions",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsFromDrs_DoctorId",
                table: "ProjectsFromDrs",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsFromTeams_TeamId",
                table: "ProjectsFromTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestProjectsFromTeams_TeamId",
                table: "RequestProjectsFromTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeamId",
                table: "Students",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTaskAssignments_DoctorId",
                table: "StudentTaskAssignments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTaskAssignments_TaskId",
                table: "StudentTaskAssignments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeamInvitations_TeamId",
                table: "StudentTeamInvitations",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorGradings_DoctorId",
                table: "SupervisorGradings",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorGradings_GradingCriteriaId",
                table: "SupervisorGradings",
                column: "GradingCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LeaderId",
                table: "Teams",
                column: "LeaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AcceptedProjectsFromDrs_RequestProjectsFromTeams_RequestProjectFromTeamId",
                table: "AcceptedProjectsFromDrs",
                column: "RequestProjectFromTeamId",
                principalTable: "RequestProjectsFromTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcceptedProjectsFromTeams_ProjectsFromTeams_ProjectFromTeamId",
                table: "AcceptedProjectsFromTeams",
                column: "ProjectFromTeamId",
                principalTable: "ProjectsFromTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Students_StudentId",
                table: "Chats",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeGradings_DoctorCommittees_DoctorId_GradingScheduleId_TeamId",
                table: "CommitteeGradings",
                columns: new[] { "DoctorId", "GradingScheduleId", "TeamId" },
                principalTable: "DoctorCommittees",
                principalColumns: new[] { "DoctorId", "GradingScheduleId", "TeamId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommitteeGradings_Students_StudentId",
                table: "CommitteeGradings",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Committees_Teams_TeamId",
                table: "Committees",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectsFromTeams_Teams_TeamId",
                table: "ProjectsFromTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestProjectsFromTeams_Teams_TeamId",
                table: "RequestProjectsFromTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teams_TeamId",
                table: "Students",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Students_LeaderId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "AcceptedProjectsFromDrs");

            migrationBuilder.DropTable(
                name: "AcceptedProjectsFromTeams");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "CommitteeGradings");

            migrationBuilder.DropTable(
                name: "DrInstructions");

            migrationBuilder.DropTable(
                name: "StudentTaskAssignments");

            migrationBuilder.DropTable(
                name: "StudentTeamInvitations");

            migrationBuilder.DropTable(
                name: "SupervisorGradings");

            migrationBuilder.DropTable(
                name: "ProjectsFromDrs");

            migrationBuilder.DropTable(
                name: "RequestProjectsFromTeams");

            migrationBuilder.DropTable(
                name: "ProjectsFromTeams");

            migrationBuilder.DropTable(
                name: "DoctorCommittees");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "GradingCriterias");

            migrationBuilder.DropTable(
                name: "Committees");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "GradingSchedules");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
