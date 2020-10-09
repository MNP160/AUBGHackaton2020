using AutoMapper;
using EcoHippiesBackend.DTOs;
using EcoHippiesBackend.Models;


namespace EcoHippiesBackend.Utility
{
    public class AutoMapperProfile :Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<UsersDTO, Users>();
            CreateMap<RegisterModel, Users>();
            CreateMap<Users, UsersDTO>();
            CreateMap<Users, RegisterModel>();

        }
          
    }
}
