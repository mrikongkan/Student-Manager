using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.Model;
using Students.MVC.Models;
using StudentsDB;

namespace Students.MVC.Controllers
{
    public class UserController : Controller
    {
        DBRepository repository = null;
        public UserController()
        {
            repository = new DBRepository();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude ="IsEmailVerified, ActivationCode")] StudentModel student)
        {
            bool status = false;
            string message = " ";
            #region // Model Validation
            if (ModelState.IsValid)
            {
                #region    //Email is already exist
                var isexist = IsEmailExist(student.EmailId);
                if (isexist)
                {
                    ModelState.AddModelError("EmailExist", "That Email Aleady Exist!");
                    return View(student);
                }
                #endregion

                #region //Activation Code
                student.ActivationCode = Guid.NewGuid();
                #endregion


                #region //Password Hashing
                student.Password = PasswordHashing.PasswordConvert(student.Password);
                student.ConfirmPassword = PasswordHashing.PasswordConvert(student.ConfirmPassword);
                #endregion

                int id = repository.AddUser(student);
                if(id> 0)
                {
                    ModelState.Clear();
                    message = "Registration Successfully Done!";
                    status = true;
                }
                
            }
            else
            {
                message = "Invalid Request";
            }
            #endregion

            ViewBag.Message = message;
            ViewBag.Status = status;
            return View(student);
        }
        [NonAction]
        public bool IsEmailExist(string EmailId)
        {
            using (StudentsEntities DB = new StudentsEntities())
            {
                var email = DB.tbl_user.Where(a => a.EmailId == EmailId).FirstOrDefault();
                return email != null;
            }
           
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(StudentModel id)
        {
            if (ModelState.IsValid)
            {
                using (StudentsEntities DB = new StudentsEntities())
                {
                    var ID = DB.tbl_user.Where(a => a.EmailId.Equals(id.EmailId) && a.Password.Equals(id.Password)).FirstOrDefault();
                    if (ID != null)
                    {
                        Session["LoggedEmailID"] = ID.EmailId.ToString();
                        Session["LoggedUserFirstName"] = ID.FirstName.ToString();
                        return RedirectToAction("Registration");
                    }
                    
                }
            }

            return View(id);
        }       
    }    
}