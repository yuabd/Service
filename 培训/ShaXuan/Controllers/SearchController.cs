using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShaXuan.Helpers;

namespace ShaXuan.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult GetValidateCode()
        {
            ValidCodeHelper vCode = new ValidCodeHelper();
            string code = vCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);

            return File(bytes, @"image/jpeg");
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Result(string name, string studentID, string validCode)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(studentID))
            {
                ViewBag.Error = "必须输入姓名和准考证号";
                return View("Index");
            }

            if (validCode != Session["ValidateCode"].ToString())
            {
                ViewBag.Error = "验证码错误！";
                return View("Index");
            }

            var item = new LabelHelper().SearchStudent(name, studentID);

            return View(item);
        }

    }
}
