using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PagedList;

namespace pacesetter.Models
{
    public class GoalsModel
    {
        public int Goal_id { get; set; }

        public int UserId { get; set; }

        public string GoalName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string GoalDescription { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public List<goal_table> GoalsList { get; set; }
       

    }
}