using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laurids_Vestergaard.Models.BaseModels;

namespace Laurids_Vestergaard.Models.ViewModels
{
    public class GalleryListItem
    {
        public Galleries Gallery { get; set; }
        public GalleryItems GalleryItem { get; set; }
    }
}