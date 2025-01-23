using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical_System.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<BMDCNO> BMDCNOs { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet <PatientProblem> patientproblems { get; set; }
        public DbSet<SpecialInetrest> specialInetrests { get; set; }

    }
}

