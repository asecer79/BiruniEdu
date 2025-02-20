namespace Week3.Models
{
    public class SchoolDb
    {
        public static List<Student> StudentsTable { get; set; } = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "Ayşe Dalman",
                StudentId = "8965435123",
            },
            new Student()
            {
                Id = 2,
                Name = "Ahmet Salman",
                StudentId = "678435123",
            },
            new Student()
            {
                Id = 3,
                Name = "Mustafa Baykara",
                StudentId = "234435123",
            },
            new Student()
            {
                Id = 4,
                Name = "Mehmet Karaca",
                StudentId = "7895435123",
            },
            new Student()
            {
                Id = 5,
                Name = "Mahmut Yılmaz",
                StudentId = "12345435123",
            },


        };
        
    }
}
