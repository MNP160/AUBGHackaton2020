using EcoHippiesBackend.DTOs;
using EcoHippiesBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Interfaces
{
    public interface IUserService
    {
        Users Authenticate(string email, string password);
        Task<IList<UsersDTO>> GetAll();
        Task<UsersDTO> GetById(int id);
        Users Create(Users user, string password);
        Users Update(Users user, string password);
        Users Delete(int Id);
    }
}
