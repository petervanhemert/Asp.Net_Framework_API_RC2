using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi._00_CommonUtility.I_Contracts.IRepo;
using WebApi._00_CommonUtility.Models;

namespace WebApi._01_DataAccess.Repo
{
    public class UserRepo: IUserRepo
    {
        //private readonly DataContext _context;
        //public UserRepo(DataContext context)
        //{
        //    _context = context;
        //}
        private readonly DataContext _context;
        public UserRepo(DataContext context)
        {
            _context = context;
        }


        public User Find(int id)
        {
            //var user = _context.Users.Single(m => m.Id == id);
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            return user;            
        }

        public IEnumerable<User> GetAll()
        {
            var users = _context.Users.ToList();
            return users;
        }



        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public User Remove(int id)
        {
            User user = _context.Users.Single(m => m.Id == id);
            _context.Users.Remove(user);
            return user;
        }
       
        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
