using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PictureShare_.Models
{
    public class PictureModel
    {
        [Key]
        public Guid Id { get; set; }
    
        [EmailAddress]
        public string UserEmail { get; set; }

        public string  Caption { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public DateTime TimeStamp { get; set; }
        public bool Public { get; set; }
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel Category { get; set; }
        public List<CommentModel> Comments { get; set; } = new List<CommentModel>();
    }
}
