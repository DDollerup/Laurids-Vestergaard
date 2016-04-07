using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laurids_Vestergaard.Models.BaseModels
{
    public class Apartments : BaseModel
    {
        public int ApartmentsID { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
    }
}