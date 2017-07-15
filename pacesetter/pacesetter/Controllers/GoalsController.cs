using pacesetter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;

namespace pacesetter.Controllers
{

    public class GoalsController : Controller
    {
        // GET: Goals
        [Authorize]
        public ActionResult main()
        {
            pacesetter_master_dbEntities pc = new pacesetter_master_dbEntities();

            var model = new GoalsModel()
            {
                CategoryList = new SelectList(pc.goal_category, "Category_id", "CategoryName")       

            };

            model.GoalsList = pc.goal_table.OrderByDescending(m => m.Goal_id).ToList();

            return View(model);
        }

        //PostData
        [HttpPost]
        public ActionResult main(Models.GoalsModel obj)
        {
            if (ModelState.IsValid)
            {
                using (pacesetter_master_dbEntities sm = new pacesetter_master_dbEntities())
                {

                    string useremail = User.Identity.GetUserName();

                        var emp = new goal_table();
                        emp.GoalName = obj.GoalName;
                        emp.GoalDescription = obj.GoalDescription;

                        //Input CategoryName on Goal table
                        string query = "select CategoryName from dbo.goal_category where Category_id = @p0";
                        string category = sm.Database.SqlQuery<string>(query, obj.CategoryId).FirstOrDefault<string>();


                        emp.GoalCategoryId = obj.CategoryId;
                        emp.GoalCategoryName = category;
                        //emp.UserId = 
                        sm.goal_table.Add(emp);
                        sm.SaveChanges();

                        return RedirectToAction("main", new GoalsModel());
                }

            }

            return View(obj);
        }

        [HttpGet]
        public ActionResult edit(int id)
        {
            pacesetter_master_dbEntities sm = new pacesetter_master_dbEntities();

            var res = sm.goal_table.First(x => x.Goal_id == id);

            var goal = new GoalsModel();

            goal.GoalName = res.GoalName;
            goal.GoalDescription = res.GoalDescription;
            goal.CategoryName = res.GoalCategoryName;
            goal.CategoryId = (int)res.GoalCategoryId;

            goal.CategoryList = new SelectList(sm.goal_category, "Category_id", "CategoryName");

            //goal.CategoryId = res.GoalCategoryId;

            return PartialView("edit", goal);
        }

        [HttpPost]
        public ActionResult edit(Models.GoalsModel obj)
        {

            if (ModelState.IsValid)
            {
                using (pacesetter_master_dbEntities sm = new pacesetter_master_dbEntities())
                {
                    string useremail = User.Identity.GetUserName();

                    var emp = new goal_table();

                    emp.GoalName = obj.GoalName;
                    emp.GoalDescription = obj.GoalDescription;

                    //Input CategoryName on Goal table
                    string query = "select CategoryName from dbo.goal_category where Category_id = @p0";
                    string category = sm.Database.SqlQuery<string>(query, obj.CategoryId).FirstOrDefault<string>();


                    emp.GoalCategoryId = obj.CategoryId;
                    emp.GoalCategoryName = category;

                   // obj.CategoryList = new SelectList(sm.goal_category, "Category_id", "CategoryName");

                    sm.goal_table.Add(emp);
                    sm.SaveChanges();
                }
            }

            return PartialView("edit", obj);
        }
    }
}