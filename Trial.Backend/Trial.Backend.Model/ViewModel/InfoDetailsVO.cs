using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Backend.Model.ViewModel
{
    public class InfoDetailsVO
    {
        public string Result { get; set; }

        public  string ErrorMsg { get; set; }

        public List<InfoData> Data { get; set; } 
    }

    public class InfoData
    {
        public int Hits { get; set; }

        public string Content { get; set; }

        public string ShareContent { get; set; }

        public string Image { get; set; }

        public string ShareLink { get; set; }
    }
}
