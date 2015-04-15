using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Trial.Backend.Model;
using Trial.Backend.Model.ViewModel;
using Trial.Backend.RemoteService.com.dfhe.appservicedevelopment;
using Trial.Utils;

namespace Trial.Backend.WebAPI.Controllers
{
    public class InfoController : ApiController
    {
        NewsAndInfosManagement infos = new NewsAndInfosManagement();


        public InfosVO Get(int pageIndex, int pageSize)
        {
            var header = new Trial.Backend.RemoteService.com.dfhe.appservicedevelopment.MySoapHeader();
            header.privateKey = "L456D48T";
            infos.MySoapHeaderValue = header;
            var tmp = infos.GetInfomationList(pageIndex, pageSize, "", "");
            var res = JsonHelper.Deserialize<InfosVO>(tmp);
            res.Data[0].InfoList.ForEach(i =>
            {
                i.Title = Base64Helper.DecodeBase64(i.Title);
                i.Image = Base64Helper.DecodeBase64(i.Image);
                i.HotImage = Base64Helper.DecodeBase64(i.HotImage);
                i.Description = Base64Helper.DecodeBase64(i.Description);

            });
            return res;
        }

        public InfoDetailsVO GetInfoById(int id)
        {
            var header = new Trial.Backend.RemoteService.com.dfhe.appservicedevelopment.MySoapHeader();
            header.privateKey = "L456D48T";
            infos.MySoapHeaderValue = header;

            var tmp = infos.GetInfo(id, 3);
            var res = JsonHelper.Deserialize<InfoDetailsVO>(tmp);

            res.Data[0].Content = Base64Helper.DecodeBase64(res.Data[0].Content);
            res.Data[0].ShareContent = Base64Helper.DecodeBase64(res.Data[0].ShareContent);

            return res;
        }

        [HttpGet]
        public CommentVO Comments(int id, int pageIndex, int pageSize)
        {
            var header = new Trial.Backend.RemoteService.com.dfhe.appservicedevelopment.MySoapHeader();
            header.privateKey = "L456D48T";
            infos.MySoapHeaderValue = header;

            var tmp = infos.GetInfoCommentList(id, pageIndex, pageSize, string.Empty);
            var res = JsonHelper.Deserialize<CommentVO>(tmp);

            if (res.Data.Count > 0)
            {
                res.Data[0].InfoList.ForEach(c =>
                {
                    c.Remark = Base64Helper.DecodeBase64(c.Remark);
                    c.UserName = Base64Helper.DecodeBase64(c.UserName);
                });
            }
            return res;

        }

    }
}
