using BiruniEdu.Entities.Concrete;
using BiruniEdu.Entities.Concrete.Security;
using Microsoft.EntityFrameworkCore;

namespace BiruniEdu.DataAccess.Context
{
    public class UniEduDbContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var con =
                "Server=localhost;Database=UniEduDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(con);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<DisciplinaryRecord>? DisciplinaryRecords { get; set; }
        public DbSet<Enrollment>? Enrollments { get; set; }
        public DbSet<Event>? Events { get; set; }
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<Faculty>? Faculties { get; set; }
        public DbSet<Instructor>? Instructors { get; set; }
        public DbSet<LibraryBook>? LibraryBooks { get; set; }
        public DbSet<LibraryLoan>? LibraryLoan { get; set; }
        public DbSet<Payment>? Payments { get; set; }
        public DbSet<Semester>? Semesters { get; set; }
        public DbSet<Student>? Student { get; set; }


        public DbSet<User>? Users { get; set; }
        public DbSet<OperationClaim>? OperationClaims { get; set; }
        public DbSet<UserOperationClaim>? UserOperationClaims { get; set; }
















    }
}
