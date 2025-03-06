using System.ComponentModel.DataAnnotations;

namespace Week5.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Length(2,50)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }

        public string Brand { get; set; }
    }


}
