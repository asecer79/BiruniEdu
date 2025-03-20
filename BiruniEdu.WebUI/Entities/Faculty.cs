using System.ComponentModel.DataAnnotations;

namespace BiruniEdu.WebUI.Entities;

public class Faculty
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string FacultyName { get; set; }

    [MaxLength(100)]
    public string? DeanName { get; set; }

    public DateTime? EstablishedDate { get; set; }

    public virtual ICollection<Department>? Departments { get; set; }
}