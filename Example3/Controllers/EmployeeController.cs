using Example3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example3.Controllers
{
    public class EmployeeController : Controller
    {
      
        private readonly EmpDataContext objDataContext;
       // EmpDataContext objDataContext = new EmpDataContext();
        // GET: Employee
        public EmployeeController()
        {
            objDataContext = new EmpDataContext();
        }
        public ActionResult EmpDetails(EmpDataContext empDataContext)
        {
            
            return View(objDataContext.employees.ToList());
        }

        public ActionResult create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult create(Employee objEmp)
        {
            if (ModelState.IsValid)
            {
                objDataContext.employees.Add(objEmp);
                objDataContext.SaveChanges();
                return RedirectToAction("EmpDetails");

            }
            return View();

        }
        public ActionResult Edit(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee objEmp)
        {
          var data =  objDataContext.employees.Find(objEmp.EmpId);
            if(data != null)
            {
                data.FirstName = objEmp.FirstName;
                data.LastName = objEmp.LastName;
                data.Address = objEmp.Address;
                data.Email = objEmp.Email;
                data.MobileNo = objEmp.MobileNo;               
            }
            objDataContext.SaveChanges();
            return RedirectToAction("EmpDetails");
        }
        public ActionResult Details(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }
        public ActionResult Delete(string id)
        {
            int empId = Convert.ToInt32(id);
            var emp = objDataContext.employees.Find(empId);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(Employee objEmp)
        {
            var emp = objDataContext.employees.Find(objEmp.EmpId);
            objDataContext.employees.Remove(emp);
            objDataContext.SaveChanges();
            return RedirectToAction("EmpDetails");
        }
    }
}