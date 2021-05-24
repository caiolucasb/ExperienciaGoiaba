using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using User.Model;
using User.Context;

namespace User.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet("/Users")]
        public IActionResult MetodoGetTodos(){
            return Ok(_context.Users.ToList());
        }

        [HttpGet("/Users/{id}")]
        public IActionResult MetodoGetUm(int id){
            var user = _context.Users.Where(user => user.id == id).FirstOrDefault(); 
            return Ok(user);
        }




    }
}