﻿// <auto-generated />
using System;
using Medical_System.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Medical_System.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250123101404_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Medical_System.Model.BMDCNO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BMDCNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConsultationId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialInterestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.HasIndex("SpecialInterestId");

                    b.ToTable("BMDCNOs");
                });

            modelBuilder.Entity("Medical_System.Model.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("Medical_System.Model.Degree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DegreeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("Medical_System.Model.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DegreeId")
                        .HasColumnType("int");

                    b.Property<int>("InstituteId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DegreeId");

                    b.HasIndex("InstituteId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Medical_System.Model.Institute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("InstituteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("Medical_System.Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("Medical_System.Model.PatientProblem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("ProblemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("ProblemId");

                    b.ToTable("patientproblems");
                });

            modelBuilder.Entity("Medical_System.Model.Problem", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("Medical_System.Model.SpecialInetrest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("InterestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("specialInetrests");
                });

            modelBuilder.Entity("Medical_System.Model.BMDCNO", b =>
                {
                    b.HasOne("Medical_System.Model.Consultation", "Consultation")
                        .WithMany()
                        .HasForeignKey("ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medical_System.Model.SpecialInetrest", "SpecialInterest")
                        .WithMany("BMDCNOs")
                        .HasForeignKey("SpecialInterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultation");

                    b.Navigation("SpecialInterest");
                });

            modelBuilder.Entity("Medical_System.Model.Consultation", b =>
                {
                    b.HasOne("Medical_System.Model.Doctor", "Doctor")
                        .WithMany("Consultations")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medical_System.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Medical_System.Model.Doctor", b =>
                {
                    b.HasOne("Medical_System.Model.Degree", "Degree")
                        .WithMany("Doctors")
                        .HasForeignKey("DegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medical_System.Model.Institute", "Institute")
                        .WithMany("Doctors")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Degree");

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("Medical_System.Model.PatientProblem", b =>
                {
                    b.HasOne("Medical_System.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medical_System.Model.Problem", "Problem")
                        .WithMany("PatientProblems")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("Problem");
                });

            modelBuilder.Entity("Medical_System.Model.Degree", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Medical_System.Model.Doctor", b =>
                {
                    b.Navigation("Consultations");
                });

            modelBuilder.Entity("Medical_System.Model.Institute", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Medical_System.Model.Problem", b =>
                {
                    b.Navigation("PatientProblems");
                });

            modelBuilder.Entity("Medical_System.Model.SpecialInetrest", b =>
                {
                    b.Navigation("BMDCNOs");
                });
#pragma warning restore 612, 618
        }
    }
}
