using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication15.Data;
using WebApplication15.Models;


namespace WebApplication15.Controllers
{
    public class EmployeesController : Controller
    {
        // Inject in Constructor
        private WebApplication15DbContext _context; //Obj of the parent calss
        public EmployeesController(WebApplication15DbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Employees.Where(x => x.IsActive == true && x.IsDeleted == false));
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // LINQ
            // Obj     sql: select x from emplist where x = empId
            var emp = _context.Employees.Find(id);
            if (emp == null)
            {
                return RedirectToAction("NotFound");
            }

            return View(emp);
        }
        public IActionResult SoftDeletedDetails(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // LINQ
            // Obj     sql: select x from emplist where x = empId
            var emp = _context.Employees.Find(id);
            if (emp == null)
            {
                return RedirectToAction("NotFound");
            }

            return View(emp);
        }

        public IActionResult NotFound()
        {
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // LINQ
            // Obj     sql: select x from emplist where x = empId
            var emp = _context.Employees.Find(id);
            if (emp == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee editEmployee)
        {
            _context.Employees.Update(editEmployee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            // LINQ
            // Obj     sql: select x from emplist where x = empId
            var emp = _context.Employees.Find(id);
            if (emp == null)
            {
                return RedirectToAction("NotFound");
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult Delete(Employee deleteEmployee)
        {
            // LINQ
            // Obj     sql: select x from emplist where x = empId
            var emp = _context.Employees.Find(deleteEmployee.EmployeeId);
            //   id                               Find() only accept PK
            if (emp == null)
            {
                return RedirectToAction("NotFound");
            }
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Status()
        {
            return View(_context.Employees);
        }
        public IActionResult SoftDelete(int? id)
        {
            // LINQ
            // Obj     sql: select x from emplist where x = empId
            var emp = _context.Employees.Find(id);
            if (emp == null)
            {
                return RedirectToAction("NotFound");
            }
            emp.IsDeleted = true;
            _context.SaveChanges(); //force post
            return RedirectToAction("Index");
        }
        public IActionResult Restore(int? id)
        {
            // LINQ
            // Obj     sql: select x from emplist where x = empId
            var emp = _context.Employees.Find(id);
            if (emp == null)
            {
                return RedirectToAction("NotFound");
            }
            emp.IsDeleted = false;
            _context.SaveChanges();
            return RedirectToAction("SoftDeletedEmployees");
        }
        public IActionResult SoftDeletedEmployees()
        {
            return View(_context.Employees.Where(x => x.IsDeleted == true));
        }
    }
}
