using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace MVCWithLinq1.Models
{
    public class StudentDAL
    {
        MVCDB_1DataContext dc = new MVCDB_1DataContext(ConfigurationManager.ConnectionStrings["MVCDB_1ConnectionString"].ConnectionString);

        #region Get Students Business Logic
        public List<Student> GetStudents(bool? status)
        {
            List<Student> students;
            if(status == null)
            {
                students=(from s in dc.Students select s).ToList();
            }
            else
            {
                students=(from s in dc.Students where s.Status == status select s).ToList(); 
            }
            return students;
        }
        #endregion


        #region  Add Student
        public void InsertStudent(Student student)
        {
            try
            {
                dc.Students.InsertOnSubmit(student);
                dc.SubmitChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        #endregion

    }
}