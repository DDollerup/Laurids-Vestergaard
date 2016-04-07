using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laurids_Vestergaard.Models.BaseModels
{
    public class Galleries : BaseModel
    {
        public int GalleryID { get; set; }
        public string Title { get; set; }
        public DateTime DateAdded { get; set; }
    }
}