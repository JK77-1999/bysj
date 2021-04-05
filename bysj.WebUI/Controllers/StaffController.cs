using bysj.Domain.Abstract;
using bysj.Domain.Concrete;
using bysj.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bysj.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private IStaffsRepository staffrepository;

        public StaffController(IStaffsRepository staffrepository)
        {
            this.staffrepository = staffrepository;
        }

        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            if (HttpContext.Session["Id"] != null)
            {
                LoginViewModel staff = new LoginViewModel();
                staff.Id = (int)HttpContext.Session["Id"];
                return View(staff);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //根据客户提交的用户名和密码，查询客户，如果找到表示用户名密码正确
                Staff StaffEntry = staffrepository.Staffs.FirstOrDefault(c =>
                                                c.id == model.Id &&
                                                c.pwd == model.Password);
                if (StaffEntry != null)
                {
                    HttpContext.Session["Staff"] = StaffEntry;//Staff信息写入Session
                    return Redirect(returnUrl ?? Url.Action("Login", "Staff"));
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码不正确! ");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}