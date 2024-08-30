using G5.NetITIMVCDay04.Context;
using G5.NetITIMVCDay04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace G5.NetITIMVCDay04.Controllers
{
    public class EmployeeController : Controller
    {
        /*---------------------------------------------------------*/
        CompanyContext db = new CompanyContext();
        /*---------------------------------------------------------*/
        // Index - List of all Employees
        [HttpGet]
        public IActionResult Index()
        {
            var _Employees = db.Employees.Include(emp => emp.Department);
            // View Model To Pass Data To View
            return View(_Employees);
        }
        /*---------------------------------------------------------*/
        // View Details
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Employee = db.Employees.Include(e => e.Department).FirstOrDefault(emp => emp.Id == id);
            if(_Employee == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Employee);
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Departments = new SelectList(db.Departments, "Id", "Name");
            return View();
        }
        /*---------------------------------------------------------*/
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            ModelState.Remove("Department");
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Departments = new SelectList(db.Departments, "Id", "Name");
                return View();
            }
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _Employee = db.Employees.Include(e => e.Department).FirstOrDefault(emp => emp.Id == id);
            if(_Employee == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag._Departments = new SelectList(db.Departments, "Id", "Name");
            return View(_Employee);
        }
        /*---------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            ModelState.Remove("Department");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Departments = new SelectList(db.Departments, "Id", "Name");
                return View();
            }
            db.Employees.Update(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
        public IActionResult Delete(int id)
        {
            var _Employee = db.Employees.Find(id);
            if(_Employee == null)
            {
                return RedirectToAction("Index");
            }
            db.Employees.Remove(_Employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
    }
}
