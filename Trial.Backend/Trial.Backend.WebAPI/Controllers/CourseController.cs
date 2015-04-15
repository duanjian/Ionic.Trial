using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Trial.Backend.Model;
using Trial.Backend.Model.ViewModel;
using Trial.Backend.RemoteService.com.dfhe.appservicedevelopment;
using Trial.Utils;

namespace Trial.Backend.WebAPI.Controllers
{
    public class CourseController : ApiController
    {
        NewsAndInfosManagement course = new NewsAndInfosManagement();

        [HttpGet]
        public CategoryVO Category()
        {

            var header = new Trial.Backend.RemoteService.com.dfhe.appservicedevelopment.MySoapHeader();
            header.privateKey = "L456D48T";
            course.MySoapHeaderValue = header;
            var tmp = course.GetPublicCategoryList();
            var res = JsonHelper.Deserialize<CategoryVO>(tmp);

            res.Data.ForEach(c =>
            {
                c.SubjectName = Base64Helper.DecodeBase64(c.SubjectName);
            });

            return res;
        }

        [HttpGet]
        public CourseVO Courses(int id, int pageIndex, int pageSize)
        {
             var header = new Trial.Backend.RemoteService.com.dfhe.appservicedevelopment.MySoapHeader();
            header.privateKey = "L456D48T";
            course.MySoapHeaderValue = header;
            var tmp = course.GetPublicCourseList(id, pageIndex, pageSize, string.Empty, string.Empty);
            var res = JsonHelper.Deserialize<CourseVO>(tmp);

            res.Data[0].InfoList.ForEach(c =>
            {
                c.CourseName = Base64Helper.DecodeBase64(c.CourseName);
                c.Description = Base64Helper.DecodeBase64(c.Description);               
            });

            return res;
        }

        [HttpGet]
        public PublicCourseVO CoursePlay(int id)
        {
             var header = new Trial.Backend.RemoteService.com.dfhe.appservicedevelopment.MySoapHeader();
            header.privateKey = "L456D48T";
            course.MySoapHeaderValue = header;
            var tmp = course.PublicCoursePlay(id, "0", 3);

            var res = JsonHelper.Deserialize<PublicCourseVO>(tmp);

            res.Data.ForEach( p =>
            {
                p.Description = Base64Helper.DecodeBase64(p.Description);
                p.CourseName = Base64Helper.DecodeBase64(p.CourseName);
                p.Content = Base64Helper.DecodeBase64(p.Content);
                p.CCUserId = Base64Helper.DecodeBase64(p.CCUserId);
                p.CCVideoId = Base64Helper.DecodeBase64(p.CCVideoId);
                p.CCVideoUrl = Base64Helper.DecodeBase64(p.CCVideoUrl);
                p.ShareContent = Base64Helper.DecodeBase64(p.ShareContent);
            });

            return res;

        }

        
    }
}
