using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebCRUDOperation.Models;

namespace WebCRUDOperation.Controllers
{
    public class EmployeeController : Controller
    {
        //  private PracticeDBEntities db = new PracticeDBEntities();
        // GET: Employee
        public ActionResult Index()
        {
           
            using (PracticeDBEntities db = new PracticeDBEntities())
            {
                var emplist = db.Employees.ToList();
                List<TestEmployee> list = new List<TestEmployee>();                
                list = emplist.Select(m => new TestEmployee { Eno = m.Eno,Ename=m.Ename,Job=m.Job, Salary = m.Salary,Dname=m.Dname}).ToList();
                return View(list);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TestEmployee model)
        {
            using(PracticeDBEntities db = new PracticeDBEntities())
            {
                Employee employee = new Employee();
                employee.Eno = model.Eno;
                employee.Ename = model.Ename;
                employee.Job = model.Job;
                employee.Salary = model.Salary;
                employee.Dname = model.Dname;

                db.Employees.Add(employee);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            using (PracticeDBEntities db=new PracticeDBEntities())
            {
                var employee = db.Employees.Where(x => x.Eno == id).FirstOrDefault();
                TestEmployee model = new TestEmployee();
                model.Eno = employee.Eno;
                model.Ename = employee.Ename;
                model.Job = employee.Job;
                model.Salary = employee.Salary;
                model.Dname = employee.Dname;
                return View(model);
            }
        }
       public ActionResult Edit(int id)
        {
            using (PracticeDBEntities db=new PracticeDBEntities())
            {
                var employee = db.Employees.Where(x => x.Eno == id).FirstOrDefault();
                TestEmployee model = new TestEmployee();
                model.Eno = employee.Eno;
                model.Ename = employee.Ename;
                model.Job = employee.Job;
                model.Salary = employee.Salary;
                model.Dname = employee.Dname;
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, TestEmployee model)
        {
            using (PracticeDBEntities db=new PracticeDBEntities())
            {
                Employee employee = new Employee();
                employee.Eno = model.Eno;
                employee.Ename = model.Ename;
                employee.Job = model.Job;
                employee.Salary = model.Salary;
                employee.Dname = model.Dname;

                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
            }
                return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            using (PracticeDBEntities db=new PracticeDBEntities())
            {
                var employee = db.Employees.Where(x => x.Eno == id).FirstOrDefault();
                TestEmployee model = new TestEmployee();
                model.Eno = employee.Eno;
                model.Ename = employee.Ename;
                model.Job = employee.Job;
                model.Salary = employee.Salary;
                model.Dname = employee.Dname;
                return View(model);
            }               
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            using (PracticeDBEntities db=new PracticeDBEntities())
            {
                Employee employee = db.Employees.Where(x => x.Eno == id).FirstOrDefault();
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
                return RedirectToAction("Index");
        }
    }
}