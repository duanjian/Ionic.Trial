using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Backend.Model.ViewModel
{
    public class CourseVO
    {
        public int Result { get; set; }

        public string ErrorMsg { get; set; }

        public DateTime time { get; set; }

        public List<CourseList> Data { get; set; } 
    }

    public class CourseList
    {
        public int PageCount { get; set; }

        public int InfoCount { get; set; }

        public List<Course> InfoList { get; set; } 
    }

    public class Course
    {
        public int CourseId { get; set; }

        public string Image { get; set; }

        public string CourseName { get; set; }

        public string Description { get; set; }

        public string PublishDate { get; set; }

        public string HotImage { get; set; }

        public int IsFree { get; set; }

        public int Hours { get; set; }
    }
}
