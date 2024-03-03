using Microsoft.EntityFrameworkCore;
using RadiologyPatientsExams.Models;

namespace RadiologyPatientsExams.Data
{
    public class RadiologyDb : DbContext
    {
        public RadiologyDb(DbContextOptions<RadiologyDb> options) : base(options) { }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<RadiologyPatientsExams.Models.ExamViewModel> ExamViewModel { get; set; } = default!;
    }
}
