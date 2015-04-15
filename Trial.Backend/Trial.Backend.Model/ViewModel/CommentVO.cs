using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Backend.Model.ViewModel
{
    public class CommentVO
    {
        public string Result { get; set; }

        public string ErrorMsg { get; set; }

        public DateTime? time { get; set; }

        public List<CommentDataVO> Data { get; set; }
    }

    //InfoCount
    //InfoList
    public class CommentDataVO
    {
        public int PageCount { get; set; }

        public int InfoCount { get; set; }

        public List<Comment> InfoList { get; set; }
    }

    public class Comment
    {
        public int RemarkId { get; set; }

        public string Remark { get; set; }

        public string CreateDate { get; set; }

        public string UserName { get; set; }

        public string HeadImg { get; set; }
    }
}
