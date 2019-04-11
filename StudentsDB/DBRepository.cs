using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Model;
using StudentsDB;


namespace StudentsDB
{
   public class DBRepository
    {        
        public int AddUser(StudentModel student)
        {
            using(var db = new StudentsEntities())
            {
                tbl_user tbl = new tbl_user()
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    FatherName = student.FatherName,
                    MotherName = student.MotherName,
                    Country = student.Country,
                    EmailId = student.EmailId,
                    Age = student.Age,
                    Password = student.Password,
                    ConfirmPassword = student.ConfirmPassword,
                    DateOfBirth = student.DateOfBirth                    
                    
                };

                db.tbl_user.Add(tbl);
                db.SaveChanges();
                return tbl.ursr_id;
            }
        }
    }
}
