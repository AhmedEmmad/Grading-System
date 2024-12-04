﻿// <auto-generated />
using System;
using GradingSystem.Repository.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GradingSystem.Repository.Data.Migrations
{
    [DbContext(typeof(GradingSystemDbContext))]
    partial class GradingSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GradingSystem.Core.Entities.AcceptedProjectFromDr", b =>
                {
                    b.Property<int>("ProjectFromDrId")
                        .HasColumnType("int");

                    b.Property<int>("RequestProjectFromTeamId")
                        .HasColumnType("int");

                    b.HasKey("ProjectFromDrId", "RequestProjectFromTeamId");

                    b.HasIndex("ProjectFromDrId")
                        .IsUnique();

                    b.HasIndex("RequestProjectFromTeamId")
                        .IsUnique();

                    b.ToTable("AcceptedProjectsFromDrs");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.AcceptedProjectFromTeam", b =>
                {
                    b.Property<int>("ProjectFromTeamId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.HasKey("ProjectFromTeamId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("ProjectFromTeamId")
                        .IsUnique();

                    b.ToTable("AcceptedProjectsFromTeams");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("DoctorId", "StudentId", "Time")
                        .IsUnique();

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Committee", b =>
                {
                    b.Property<int>("GradingScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("GradingScheduleId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("Committees");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.CommitteeGrading", b =>
                {
                    b.Property<int>("GradingCriteriaId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("GradingScheduleId")
                        .HasColumnType("int");

                    b.Property<double>("Marks")
                        .HasColumnType("float");

                    b.HasKey("GradingCriteriaId", "DoctorId", "StudentId", "TeamId");

                    b.HasIndex("StudentId");

                    b.HasIndex("DoctorId", "GradingScheduleId", "TeamId");

                    b.ToTable("CommitteeGradings");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.DoctorCommittee", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("GradingScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId", "GradingScheduleId", "TeamId");

                    b.HasIndex("TeamId", "GradingScheduleId");

                    b.ToTable("DoctorCommittees");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.DrInstruction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("DrInstructions");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.GradingCriteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxGrade")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GradingCriterias");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.GradingSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("GradingSchedules");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.ProjectFromDr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("ProjectsFromDrs");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.ProjectFromTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("ProjectsFromTeams");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.RequestProjectFromTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("RequestProjectsFromTeams");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("InTeam")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.StudentTaskDoctor", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Mark")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId", "TaskId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("TaskId");

                    b.ToTable("StudentTaskAssignments");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.StudentTeamInvitation", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<bool>("IsInviterStudent")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("StudentTeamInvitations");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.SupervisorGrading", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("GradingCriteriaId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<double>("Marks")
                        .HasColumnType("float");

                    b.HasKey("StudentId", "GradingCriteriaId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("GradingCriteriaId");

                    b.ToTable("SupervisorGradings");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("HasProject")
                        .HasColumnType("bit");

                    b.Property<int>("LeaderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LeaderId")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.AcceptedProjectFromDr", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.ProjectFromDr", "ProjectFromDr")
                        .WithOne("AcceptedProjectFromDr")
                        .HasForeignKey("GradingSystem.Core.Entities.AcceptedProjectFromDr", "ProjectFromDrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.RequestProjectFromTeam", "RequestProjectFromTeam")
                        .WithOne("AcceptedProjectFromDr")
                        .HasForeignKey("GradingSystem.Core.Entities.AcceptedProjectFromDr", "RequestProjectFromTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectFromDr");

                    b.Navigation("RequestProjectFromTeam");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.AcceptedProjectFromTeam", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Doctor", "Doctor")
                        .WithMany("AcceptedProjectsFromTeams")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.ProjectFromTeam", "ProjectFromTeam")
                        .WithOne("AcceptedProjectFromTeam")
                        .HasForeignKey("GradingSystem.Core.Entities.AcceptedProjectFromTeam", "ProjectFromTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("ProjectFromTeam");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Chat", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Doctor", "Doctor")
                        .WithMany("Chats")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.Student", "Student")
                        .WithMany("Chats")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Committee", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.GradingSchedule", "GradingSchedule")
                        .WithMany("Committees")
                        .HasForeignKey("GradingScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.Team", "Team")
                        .WithMany("Committees")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("GradingSchedule");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.CommitteeGrading", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.GradingCriteria", "GradingCriteria")
                        .WithMany("CommitteeGradings")
                        .HasForeignKey("GradingCriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.Student", "Student")
                        .WithMany("CommitteeGradings")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.DoctorCommittee", "DoctorCommittee")
                        .WithMany("CommitteeGradings")
                        .HasForeignKey("DoctorId", "GradingScheduleId", "TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoctorCommittee");

                    b.Navigation("GradingCriteria");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.DoctorCommittee", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Doctor", "Doctor")
                        .WithMany("DoctorCommittees")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.Committee", "Committee")
                        .WithMany("DoctorCommittees")
                        .HasForeignKey("TeamId", "GradingScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Committee");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.DrInstruction", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Admin", "Admin")
                        .WithMany("DrInstructions")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.ProjectFromDr", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Doctor", "Doctor")
                        .WithMany("ProjectsFromDrs")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.ProjectFromTeam", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Team", "Team")
                        .WithMany("ProjectsFromTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.RequestProjectFromTeam", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Team", "Team")
                        .WithMany("RequestProjectsFromTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Student", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Team", "Team")
                        .WithMany("Students")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.StudentTaskDoctor", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Doctor", "Doctor")
                        .WithMany("StudentTaskDoctors")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.Student", "Student")
                        .WithMany("StudentTaskDoctors")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.Task", "Task")
                        .WithMany("StudentTaskDoctors")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Student");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.StudentTeamInvitation", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Student", "Student")
                        .WithMany("StudentInvitations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.Team", "Team")
                        .WithMany("TeamInvitations")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.SupervisorGrading", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Doctor", "Doctor")
                        .WithMany("SupervisorGradings")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.GradingCriteria", "GradingCriteria")
                        .WithMany("SupervisorGradings")
                        .HasForeignKey("GradingCriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingSystem.Core.Entities.Student", "Student")
                        .WithMany("SupervisorGradings")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("GradingCriteria");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Team", b =>
                {
                    b.HasOne("GradingSystem.Core.Entities.Student", "Leader")
                        .WithOne("TeamLeader")
                        .HasForeignKey("GradingSystem.Core.Entities.Team", "LeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Admin", b =>
                {
                    b.Navigation("DrInstructions");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Committee", b =>
                {
                    b.Navigation("DoctorCommittees");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Doctor", b =>
                {
                    b.Navigation("AcceptedProjectsFromTeams");

                    b.Navigation("Chats");

                    b.Navigation("DoctorCommittees");

                    b.Navigation("ProjectsFromDrs");

                    b.Navigation("StudentTaskDoctors");

                    b.Navigation("SupervisorGradings");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.DoctorCommittee", b =>
                {
                    b.Navigation("CommitteeGradings");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.GradingCriteria", b =>
                {
                    b.Navigation("CommitteeGradings");

                    b.Navigation("SupervisorGradings");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.GradingSchedule", b =>
                {
                    b.Navigation("Committees");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.ProjectFromDr", b =>
                {
                    b.Navigation("AcceptedProjectFromDr")
                        .IsRequired();
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.ProjectFromTeam", b =>
                {
                    b.Navigation("AcceptedProjectFromTeam")
                        .IsRequired();
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.RequestProjectFromTeam", b =>
                {
                    b.Navigation("AcceptedProjectFromDr")
                        .IsRequired();
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Student", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("CommitteeGradings");

                    b.Navigation("StudentInvitations");

                    b.Navigation("StudentTaskDoctors");

                    b.Navigation("SupervisorGradings");

                    b.Navigation("TeamLeader")
                        .IsRequired();
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Task", b =>
                {
                    b.Navigation("StudentTaskDoctors");
                });

            modelBuilder.Entity("GradingSystem.Core.Entities.Team", b =>
                {
                    b.Navigation("Committees");

                    b.Navigation("ProjectsFromTeams");

                    b.Navigation("RequestProjectsFromTeams");

                    b.Navigation("Students");

                    b.Navigation("TeamInvitations");
                });
#pragma warning restore 612, 618
        }
    }
}