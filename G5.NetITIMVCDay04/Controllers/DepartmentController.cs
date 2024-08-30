using G5.NetITIMVCDay04.Context;
using Microsoft.AspNetCore.Mvc;

namespace G5.NetITIMVCDay04.Controllers
{
    public class DepartmentController : Controller
    {
        /*---------------------------------------------------------*/
        CompanyContext db = new CompanyContext();
        /*---------------------------------------------------------*/
        // Index - List of All Departmrnts
        [HttpGet]
        public IActionResult Index()
        {
            var _Departments = db.Departments;
            //ViewBag.Departments = _Departments;   // => View Bag
            // View Model To Pass data to View
            return View(_Departments);            // => View Model
        }
        /*---------------------------------------------------------*/
        // View Details
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Department = db.Departments.Find(id);
            if(_Department == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Department);
        }
        /*---------------------------------------------------------*/
    }
}
