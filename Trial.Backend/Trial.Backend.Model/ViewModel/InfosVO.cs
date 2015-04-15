using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Backend.Model
{

    //Result
    //ErrorMsg
    //time
    //Data
    public class InfosVO
    {
        public string Result { get; set; }

        public string ErrorMsg { get; set; }

        public DateTime time { get; set; }

        public List<DataVO> Data { get; set; }
    }

    public class InfoVO
    {
        public int InfoId { get; set; }
        public string Title { get; set; }
        public DateTime PubDate { get; set; }
        public string Image { get; set; }
        public string HotImage { get; set; }
        public string PdfUrl { get; set; }
        public int Hits { get; set; }
        public int RemarkCount { get; set; }
        public string Description { get; set; }
    }

    //PageCount
    //InfoCount
    //InfoList
    public class DataVO
    {
        public int PageCount { get; set; }

        public int InfoCount { get; set; }

        public List<InfoVO> InfoList { get; set; }
    }
}
