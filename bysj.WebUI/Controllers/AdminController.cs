using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bysj.Domain.Abstract;
using bysj.Domain.Concrete;
using bysj.WebUI.Models;
using bysj.WebUI.Infrastructure;

namespace bysj.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IMachinesRepository repository;
        public int PageSize = 6;

        public AdminController(IMachinesRepository machinesRepository)
        {
            this.repository = machinesRepository;
        }
        // GET: Machine
        public ActionResult List(Admin admin, int areaId = 0, int page = 1, string searchString = "")
        {
            if (admin.id == 0)
            {
                //return RedirectToAction("Login", "Admin");
            }
            MachinesListViewModel viewModel = new MachinesListViewModel
            {
                Machines = repository.Machines.OrderBy(b => b.id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                pagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Machines.Count()
                },
                AreaId = areaId
            };
            return View(viewModel);
            //return View(repository.Machines);
        }

        public ActionResult Login()
        {
            if (HttpContext.Session["Id"] != null)
            {
                LoginViewModel admin = new LoginViewModel();
                admin.Id = (int)HttpContext.Session["Id"];
                return View(admin);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //根据客户提交的用户名和密码，查询客户，如果找到表示用户名密码正确
                Admin AdminEntry = repository.Admins.FirstOrDefault(c =>
                                                c.id == model.Id &&
                                                c.pwd == model.Password);
                if (AdminEntry != null)
                {
                    HttpContext.Session["Admin"] = AdminEntry;//客户信息写入Session
                    return Redirect(returnUrl ?? Url.Action("List", "Admin"));
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

        public PartialViewResult Summary(Admin admin)
        {
            return PartialView(admin);
        }

        public ActionResult LogOff()
        {
            HttpContext.Session["Admin"] = null;
            //FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}