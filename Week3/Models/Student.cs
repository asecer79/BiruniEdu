using System.ComponentModel.DataAnnotations;

namespace Week3.Models
{
    public class Student
    {
     
        [Required]
        public int? Id { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(2)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [Length(8,8)]
        public string? StudentId
        {
            get; set;

        }
    }
}
