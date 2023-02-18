using Microsoft.AspNetCore.Mvc;
using PracticumHW2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticumHW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>()
        {
            new Customer{ Id = 1, Email = "customer_one@cus.com", Name = "CusOne", PhoneNumber="5554442233"},
            new Customer{ Id = 2, Email = "customer_two@cus.com", Name = "CusTwo", PhoneNumber="5554442233"}
        };

        public CustomerController()
        {

        }

        #region GET Method(s)
        // GET: api/<CustomerController> -> Get All Customers
        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(customers);
        }

        // GET api/<CustomerController>/{id} -> Get Customer By Id via using Route
        [HttpGet("GetIdByRoute/{id}")]
        public IActionResult GetIdByRoute([FromRoute] int id)
        {
            var customer = customers.FirstOrDefault(x => x.Id == id);

            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound("Object Not Found!");
            }
        }

        // GET api/<CustomerController>/{id} -> Get Customer By Id via using Query
        [HttpGet("GetIdByQuery")]
        public IActionResult GetIdByQuery([FromQuery] int id)
        {
            var customer = customers.FirstOrDefault(x => x.Id == id);

            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NotFound("Object Not Found!");
            }
        }

        // GET api/<CustomerController>/{filter} - Get Customer By Name Filter using Query
        [HttpGet]
        [Route("GetByFilter")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var filteredCustomers = customers.FindAll(x => x.Name.ToUpper().Contains(name.ToUpper()));

            if (filteredCustomers != null)
            {
                return Ok(filteredCustomers);
            }
            else
            {
                return NotFound("Object Not Found!");
            }
        }
        #endregion


        #region POST Method(s)
        // POST api/<CustomerController> -> Add New Customer
        [HttpPost]
        public IActionResult Post([FromBody] Customer newCustomer)
        {
            var customer = customers.SingleOrDefault(x => x.Id == newCustomer.Id);

            if (customer != null)
            {
                return BadRequest("Obejct Already Exists!");
            }
            else
            {
                customers.Add(newCustomer);
                return Ok(customers);
            }

        }
        #endregion

        #region PUT Method(s)
        // PUT api/<CustomerController>/5 -> Update Customer By Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer newCustomer)
        {
            var customer = customers.SingleOrDefault(x => x.Id == id);

            if (customer is null)
            {
                return NotFound("Object Not Found!");
            }
            else
            {
                customers.Remove(customer);
                newCustomer.Id = id;
                customers.Add(newCustomer);
                return Ok(customers);
            }
        }
        #endregion

        #region Delete Method(s)
        // DELETE api/<CustomerController>/5 -> Delete Customer By Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = customers.SingleOrDefault(x => x.Id == id);
            if (customer != null)
            {
                customers.Remove(customer);
                return Ok(customers);
            }
            else
            {
                return NotFound("Object Not Found!");
            }

        }
        #endregion

    }
}