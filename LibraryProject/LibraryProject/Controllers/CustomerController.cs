﻿using LibraryProject.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProject.Controllers
{
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        //add, delate and check list of users 
        private readonly LibraryDbContext _dbContext;
        public CustomerController(LibraryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            var customers = _dbContext
                .Books
                .ToList();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get([FromRoute] int id)
        {
            var customer = _dbContext
               .Customers
               .FirstOrDefault(x => x.Id == id);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}
