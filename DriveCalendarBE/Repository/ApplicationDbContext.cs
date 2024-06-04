using DriveCalendarBE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace DriveCalendarBE.Repository
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Drive> Drives { get; set; }
        public DbSet<Student> Students { set; get; }
        public DbSet<Users> Users { get; set; }
        public DbSet<DriveStatus> DriveStatus { get; set; }
        public DbSet<StudentDriveStatus> StudentDriveStatus { get; set; }
        public DbSet<StudentDrive> StudentDrives { get; set; }

        public DbSet<Batch> Batchs { set; get; }

        public DbSet<StudentModes> StudentModes { set; get; }
        public DbSet<Roles> Roles { set; get; }
        public DbSet<StudentDriveDetails> Details { set; get;}

        public DbSet<Round>Rounds { set; get; }
        public DbSet<Technology> technologies { set; get; }
    }
}
