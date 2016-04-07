using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laurids_Vestergaard.Models.BaseModels
{
    public class Private : BaseModel
    {
        public int PrivateID { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
    }
}