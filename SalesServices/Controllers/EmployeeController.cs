using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SalesServices.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        private SalesDBEntities db = new SalesDBEntities();

        public IQueryable<Employee> GetEmployees()
        {
            var data = db.Employees;
            return data;
        }

        //[ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id, Employee employee)
        {

            employee = db.Employees.FirstOrDefault(x => x.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
            //return employee;

            //SalesServices.Models.Employee employee;
            //using (var entity = new SalesDBEntities())
            //{
            //    var employeeFromDb = entity.Employees.FirstOrDefault(x => x.EmployeeID == id);

            //    employee = new Models.Employee
            //    {
            //        EmployeeID = employeeFromDb.EmployeeID,
            //        FirstName = employeeFromDb.FirstName,
            //        LastName = employeeFromDb.LastName,
            //        MiddleInitial = employeeFromDb.MiddleInitial
            //    };
            //}

        }

        [HttpGet, Route("getbyname/{name}", Name = "getemployeebyname")]
        public IHttpActionResult GetEmployeeByName(string name)
        {
            
            var employeeFromDb = db.Employees.FirstOrDefault(x => x.FirstName.Contains(name) || x.LastName.Contains(name));

            if (employeeFromDb == null)
            {
                return NotFound();
            }
            var employee = new Models.Employee
            {
                EmployeeID = employeeFromDb.EmployeeID,
                FirstName = employeeFromDb.FirstName,
                LastName = employeeFromDb.LastName,
                MiddleInitial = employeeFromDb.MiddleInitial
            };
            return Ok(employee);
        }

        public IHttpActionResult PostEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Employees.Add(employee);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeID }, employee);
        }

        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            var EmpExists = db.Employees.Where(e => e.EmployeeID == id).FirstOrDefault();
            //var emp = new Models.Employee();
            if (EmpExists != null)
            {
                EmpExists.FirstName = employee.FirstName;
                EmpExists.LastName = employee.LastName;
                EmpExists.MiddleInitial = employee.MiddleInitial;

                db.SaveChanges();
            }
            return Ok();
        }

        //public IHttpActionResult PostCustomer(int id, Customer customer)
        //{ 
            

        //}
    }
}
