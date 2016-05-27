using System.Collections.Generic;
using WebApi._00_CommonUtility.Models;

namespace WebApi._00_CommonUtility.I_Contracts.ISevices
{
    public interface IUserServices
    {
        IEnumerable<User> GetAll();
        User Find(int id);
        void Add(User user);
        User Remove(int id);
        void Update(User user);
    }
}
