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

            CreateMap<Comments, CommentsDTO>();
            CreateMap<CommentsDTO, Comments>();

            CreateMap<Locations, LocationsDTO>();
            CreateMap<LocationsDTO, Locations>();

            CreateMap<Notifications, NotificationsDTO>();
            CreateMap<NotificationsDTO, Notifications>();

            CreateMap<Posts, PostsDTO>();
            CreateMap<PostsDTO, Posts>();

            CreateMap<Replies, RepliesDTO>();
            CreateMap<RepliesDTO, Replies>();


        }
          
    }
}
