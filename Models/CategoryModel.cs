using System.ComponentModel.DataAnnotations;

namespace Dharati.Models
{
    public class CategoryModel
    {
        [Key]
        public int Category_Id { get; set; }

        [Required]
        public string Title {  get; set; }

        [Required]
        public string Image {  get; set; }

        [Required]
        public string Category {  get; set; }

        [Required]
        public string Description { get; set; }
    }
}
