using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PictureShare_.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }
        public Guid PictureId { get; set; }
        public string Comment { get; set; }
        public DateTime TimeStamp { get; set; }
        public IdentityUser User { get; set; }
    }
}
