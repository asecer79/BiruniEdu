using System.ComponentModel.DataAnnotations;

namespace BiruniEdu.Entities.Concrete.Security
{
    public class OperationClaim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
