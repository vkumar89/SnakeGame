using MVCWithLinq1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithLinq1.Models;
using System.IO;
namespace MVCWithLinq1.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL dal = new StudentDAL();

        #region Display Students
        public ViewResult DisplayStudents()
        {
            
            return View(dal.GetStudents(true));
        }
        #endregion

        #region Display Single Student

        public ViewResult DisplayStudent(int Sid)
        {
            return View();
        }

        #endregion

        #region Add Student
        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student student,HttpPostedFileBase SelectedFile)
        {

            if(SelectedFile !=null)
            {
              string FolderPath=  Server.MapPath("~/Uploads/");
                if(!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                SelectedFile.SaveAs(FolderPath+SelectedFile.FileName);
                student.Photo = SelectedFile.FileName;
            }
            student.Status = true;


            return RedirectToAction("DisplayStudents");
        }
        #endregion

        #region  Edit Student
        [HttpGet]
        public ViewResult EditStudent(int sid)
        {
            return View();
        }
        [HttpPost]

        public RedirectToRouteResult UpdateStudent(int sid,Student student)
        {
            return RedirectToAction("DisplayStudent");
        }
        #endregion

        #region Delete student
        public RedirectToRouteResult DeleteStudent(int sid)
        {
            return RedirectToAction("DisplayStudent");
        }
        #endregion

    }
}