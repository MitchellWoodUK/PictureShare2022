using Microsoft.AspNetCore.Mvc.Rendering;

namespace PictureShare_.Models
{
    public class PictureViewModel
    {
        public PictureModel Picture { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
