using System.ComponentModel.DataAnnotations;

namespace Andersweb.Models;

    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Display order")]
        [Range(1,10,ErrorMessage ="to long")]
        public int DisplayOrder { get; set; }

    }

