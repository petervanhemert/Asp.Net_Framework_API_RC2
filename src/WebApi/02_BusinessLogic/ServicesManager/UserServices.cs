using System.Collections.Generic;
using WebApi._00_CommonUtility.I_Contracts;
using WebApi._00_CommonUtility.I_Contracts.IRepo;
using WebApi._00_CommonUtility.I_Contracts.ISevices;
using WebApi._00_CommonUtility.Models;

namespace WebApi._02_BusinessLogic.ServicesManager
{
    public class UserServices : IUserServices
    {
        private readonly IUoW _uow;
        private readonly IUserRepo _userRepo;
        public UserServices(IUoW uow, IUserRepo userRepo)
        {
            _uow = uow;
            _userRepo = userRepo;
        }      


        public User Find(int id)
        {
            return _userRepo.Find(id);
            //return _uow.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
           return _userRepo.GetAll();
        }



        public void Add(User user)
        {
            //_userRepo.Add(user);
            //_uow.SaveChanges();
            _uow.Users.Add(user);
            _uow.SaveChanges();
        }

        public User Remove(int id)
        {
            var user = _uow.Users.Remove(id);
            _uow.SaveChanges();
            return user;
        }

        public void Update(User user)
        {
            _uow.Users.Update(user);
            _uow.SaveChanges();
        }
    }
}
