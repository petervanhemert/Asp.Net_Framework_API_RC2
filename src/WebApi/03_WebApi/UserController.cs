using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi._00_CommonUtility.I_Contracts.ISevices;
using WebApi._00_CommonUtility.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi._03_WebApi
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {


        //private readonly DataContext _context;
        //public UserController(DataContext context)
        //{
        //    _context = context;
        //}



        private readonly IUserServices _user;
        public UserController(IUserServices users)
        {
            this._user = users;
        }

        // GET: api/user
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _user.GetAll();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _user.Find(id);
        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                //_context.Users.Add(user);
                //_context.SaveChanges();
                _user.Add(user);
            }
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                _user.Update(user);
            }
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _user.Remove(id);
        }
    }
}
