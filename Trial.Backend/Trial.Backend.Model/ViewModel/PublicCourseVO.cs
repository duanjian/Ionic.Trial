using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Backend.Model.ViewModel
{
    public class PublicCourseVO
    {
        public int Result { get; set; }

        public string ErrorMsg { get; set; }

        public List<PublicCourse> Data { get; set; } 
    }

    public class PublicCourse
    {
        public int CourseId { get; set; }

        public string Description { get; set; }

        public string CourseName { get; set; }

        public string Content { get; set; }

        public string CCUserId { get; set; }

        public string CCVideoId { get; set; }

        public string CCVideoUrl { get; set; }

        public string ShareContent { get; set; }

        public string ShareLink { get; set; }
    }
}
