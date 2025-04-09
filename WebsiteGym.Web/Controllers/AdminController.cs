using System.Linq;
using System.Web.Mvc;
using eUseControl.BusinessLogic.DBModel;     

namespace WebsiteGym.Web.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminDash()
        {
               using (var context = new UserContext())
               {
                    ViewBag.Users = context.Users.Count();
               }
               
                    return View();
        }
          public ActionResult ListOfUsers()
          {
               using (var context = new UserContext())
               {
                    var users = context.Users.ToList();
                    ViewBag.Users = users;
               }
               return View();
          }

          public ActionResult DeleteUser(int id)
          {
               using (var context = new UserContext())
               {
                    var user = context.Users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                    {
                         context.Users.Remove(user);
                         context.SaveChanges();
                    }
               }
               return RedirectToAction("ListOfUsers");
          }
     }
}