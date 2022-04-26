using System.ComponentModel.DataAnnotations;

namespace PictureShare_.Models
{
    public class ProfileModel
    {
        [Key]
        public string UserEmail { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string ProfilePicture { get; set; }
        public string About { get; set; }
    }
}
