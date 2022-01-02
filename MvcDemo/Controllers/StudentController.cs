using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class StudentController : Controller
    {
        public StudentContext Context { get; }
        public StudentController(StudentContext _context)
        {
            Context = _context;
        }

        
        public IActionResult StudentList()
        {
            var studentList = from student in Context.tbl_student.DefaultIfEmpty()
                              join department in Context.tbl_department.DefaultIfEmpty()
                              on student.DepId equals department.Id
                              select new Student
                              {
                                  Id = student.Id,
                                  Name = student.Name,
                                  Mobile = student.Mobile,
                                  Email = student.Email,
                                  DepId = student.DepId,
                                  FullName = student.FullName,
                                  Department = department == null ? "" : department.Name
                              };
            return View(studentList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if(ModelState.IsValid)
            {
                if(student.Id == 0)
                {
                    Context.Add(student);
                    await Context.SaveChangesAsync();
                }
                else
                {
                    Context.Entry(student).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                }
                return RedirectToAction("StudentList");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadDepartment();
            return View();
        }

        void LoadDepartment()
        {
            List<Department> departments = Context.tbl_department.DefaultIfEmpty().ToList();
            ViewBag.DepartmentList = departments;
        }

        public async Task<IActionResult> Delete(int id)
        {
            Student student = await Context.tbl_student.FindAsync(id);
            if(student != null)
            {
                Context.Remove(student);
                await Context.SaveChangesAsync();
            }
            return RedirectToAction("StudentList");
        }
    }
}
