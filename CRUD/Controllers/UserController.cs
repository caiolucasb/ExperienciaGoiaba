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
            if(user == null)
                return BadRequest("Usuario Não Encontrado");
            return Ok(user);
        }

        [HttpPost("/Users")]
        public IActionResult MetodoPost([FromBody] UserModel user){
            if(user.age == 0 || user.firstName == "" || user.firstName == null)
                return BadRequest("Preencha os campos obrigatorios");
            
            user.creationDate = DateTime.Now;
            _context.Entry(user).State=EntityState.Added;
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("/Users/{id}")]
        public IActionResult MetodoPut([FromBody] UserModel user, int id){
            if(_context.Users.Where(user => user.id == id).FirstOrDefault() == null)
                return BadRequest("Usuario Não Encontrado");
            if(user.age == 0 || user.firstName == "" || user.firstName == null)
                return BadRequest("Preencha os campos obrigatorios");
            user.id = id;
            _context.Entry(user).State=EntityState.Modified;
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete("/Users/{id}")]
        public IActionResult MetodoDelete(int id){
            var user = _context.Users.Where(user => user.id == id).FirstOrDefault();
            _context.Entry(user).State=EntityState.Deleted;
            _context.SaveChanges();
            return Ok(user);
        }




    }
}