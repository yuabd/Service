using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hammer.Core.Models;

namespace Hammer.Core.Services
{
    public class StudentService
    {
        private SiteDataContext db = new SiteDataContext();

        public void InsertStudent(Student student)
        {
            try
            {
                if (db.Students.Any(m => m.StudentID == student.StudentID && m.Name == student.Name))
                {
                    return;
                }
                db.Students.Add(student);
                db.SaveChanges();

            }
            catch (Exception e)
            {
            }
        }

        public Student GetStudentByID(int id)
        {
            var student = db.Students.Find(id);

            return student;
        }

        public void UpdateStudent(Student student)
        {
            if (db.Students.Any(m => m.StudentID == student.StudentID && m.Name == student.Name && m.ID != student.ID))
            {
                return;
            }

            var stu = db.Students.Find(student.ID);

            stu.StudentID = student.StudentID;
            stu.BirthDate = student.BirthDate;
            stu.Contact = student.Contact;
            stu.Course = student.Course;
            stu.EndDate = student.EndDate;
            stu.IDCard = student.IDCard;
            stu.LisID = student.LisID;
            stu.Name = student.Name;
            stu.Sex = student.Sex;
            stu.StartDate = student.StartDate;
            stu.State = student.State;
            
            db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = db.Students.Find(id);

            if (student != null)
            {
                db.Students.Remove(student);
            }

            db.SaveChanges();
        }

        public List<Student> GetStudentList()
        {
            var list = (from l in db.Students
                        orderby l.StartDate descending
                        select l).ToList();

            return list;
        }
    }
}
