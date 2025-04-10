using System.ComponentModel.DataAnnotations;

namespace BiruniEdu.WebUI.Entities.Security
{
    public class OperationClaim
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
