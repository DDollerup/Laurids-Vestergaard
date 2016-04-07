using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laurids_Vestergaard.Models.BaseModels
{
    public class GalleryItems : BaseModel
    {
        public int GalleryItemID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int GalleryID { get; set; }
        public DateTime DateAdded { get; set; }
    }
}