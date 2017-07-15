using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pacesetter.Models;
using Microsoft.AspNet.Identity;

namespace pacesetter.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            pacesetter_master_dbEntities pc = new pacesetter_master_dbEntities();

            string useremail = User.Identity.GetUserName();

            //string count_email = "select count(*) from dbo.user_table where EmailAddress = @p0";

            //string temp = pc.Database.SqlQuery<string>(count_email, useremail).FirstOrDefault();

            var tmp = (from a in pc.user_table
                       where a.EmailAddress.Contains(useremail)
                       select new IndexViewModel { EmailExist = a.EmailAddress});

            if (tmp.Count() > 0)
            {

                ViewBag.data = "Contains";

            }
            else {

                ViewBag.data = "Empty";
            }
                
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.IndexViewModel obj)
        {
            if (ModelState.IsValid)
            {
                pacesetter_master_dbEntities pc = new pacesetter_master_dbEntities();

                var tab = new user_table();

                tab.Firstname = obj.S_FirstName;
                tab.Lastname = obj.S_LastName;
                tab.EmailAddress = User.Identity.GetUserName();
                tab.Role = obj.S_role;
                tab.Contact_number = obj.S_contact;

                pc.user_table.Add(tab);
                pc.SaveChanges();

                return RedirectToAction("Index", new IndexViewModel());
            }

            return View(obj);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}