using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace SalesServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders:"*")]
    public class CustomerController : ApiController
    {
        private SalesDBEntities db = new SalesDBEntities();

        //[HttpGet]
        //public string Get(int id)
        //{
        //    var inputId = id;
        //    return "some idiot customer is eating my brain";
        //}
        //[HttpGet]


        public IHttpActionResult GetCustomerById(int id, Models.Customer customerById)
        {
            var customerfromDatabase = db.Customers.Find(id);
            if (customerfromDatabase == null)
            {
                return NotFound();
            }

            customerById = new Models.Customer() {
                CustomerID = customerfromDatabase.CustomerID,
                FirstName = customerfromDatabase.FirstName,
                LastName = customerfromDatabase.LastName,
                MiddleInitial = customerfromDatabase.MiddleInitial
            };


            return Ok(customerById);
        }
        //[HttpGet]
        public ActionResult GetCustomerByName(string name)
        {
            var inputName = name;
            SalesServices.Models.Customer customerByName;
            using (var SalesDBEntities = new SalesDBEntities())
            {
                var customerfromDatabase = SalesDBEntities.Customers.FirstOrDefault(item => item.FirstName.Contains(name) || item.LastName.Contains(name));
                if (customerfromDatabase == null)
                {

                }
                customerByName = new Models.Customer() { CustomerID = customerfromDatabase.CustomerID, FirstName = customerfromDatabase.FirstName, LastName = customerfromDatabase.LastName, MiddleInitial = customerfromDatabase.MiddleInitial };

            }
            var result = new JsonResult();
            result.Data = customerByName;

            return result;
        }

        ////[HttpPost]
        //public string post()
        //{
        //    return "custome is god/godess";
        //}

    }
}
