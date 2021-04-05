using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bysj.Domain.Concrete;
using bysj.Domain.Abstract;

namespace bysj.WebUI.Models
{
    // 继承 AuthorizeAttribute 专门用于判断权限的 还有过滤器 但是其他类型是在参数绑定只会才运行的 用于判断action 处理前 以及处理之后
    public class LoginNeedAttribute : AuthorizeAttribute
    {
        // 重载 验证方法
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //如果Session中不存在该值，那么表示没有登录
            Admin temp_adminId = (Admin)filterContext.HttpContext.Session["Admin"];

            // 获取 管理员 id 并且判断id 是否为空
            if (temp_adminId == null)
            {
                filterContext.Result = new RedirectResult("/Admin/Login");
                return;
            }
            int admin_id = 0;
            int.TryParse(temp_adminId.id.ToString(), out admin_id);

            // 从数据库中读取用户 并检测用户是否为空
            BYSJEntities db = new BYSJEntities();
            // AsNoTracking EF 查询的时候可以不被缓存下来，避免数据不是最新的
            Admin admin = db.Admin.AsNoTracking().FirstOrDefault(r => r.id == admin_id);

            if (admin == null)
            {
                // 如果不满足 条件 则 设置 上下文的结果为 重定向到登入界面
                filterContext.Result = new RedirectResult("/Admin/Login");

                // 这里 new 一个读者对象是为了兼容 之前的代码
                admin = new Admin();
            }

            // 用于 上下文中的数据 传递 （官方推荐）
            filterContext.HttpContext.Items["admin"] = admin;
        }
    }
}