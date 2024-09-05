using System.Linq;
using System.Web.Mvc;
using StudentCourseOneToOne.Data;
using StudentCourseOneToOne.Models;

namespace StudentCourseOneToOne.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var students = session.Query<Student>().ToList();
                return View(students);
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            ModelState.Remove("Course.CourseId");
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var txn = session.BeginTransaction())
                    {
                        student.Course.Student = student;
                        session.Save(student);
                        txn.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(student);
        }
        public ActionResult Edit(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().FirstOrDefault(s => s.StudentId == id);
                return View(student);
            }
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var txn = session.BeginTransaction())
                    {
                        student.Course.Student = student;
                        session.Update(student);
                        txn.Commit();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(student);
        }

        public ActionResult Details(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().FirstOrDefault(s => s.StudentId == id);
                return View(student);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Get<Student>(id);
                return View(student);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStudent(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var txn = session.BeginTransaction())
                {
                    var student = session.Get<Student>(id);
                    session.Delete(student);
                    txn.Commit();
                    return RedirectToAction("Index");
                }
            }
        }
    }
}