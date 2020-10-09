using EcoHippiesBackend.DTOs;
using EcoHippiesBackend.Interfaces;
using EcoHippiesBackend.Models;
using EcoHippiesBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Services
{
    public class NotificationsService : IService<NotificationsRepository, Notifications, NotificationsDTO>
    {
        private readonly NotificationsRepository _repository;

        public NotificationsService(NotificationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<NotificationsDTO>> Read()
        {
            return await _repository.Read();
        }


        public async Task<NotificationsDTO> ReadById(int Id)
        {
            return await _repository.ReadById(Id);
        }
        public async Task<Notifications> Create(Notifications value)
        {
            return await _repository.Create(value);
        }

       /* public async Task<ProductDto> Create(ProductRequest value)
        {
            return await _repository.Create(value);
        }
        public async Task<List<string>> Create(IFormFile file)
        {
            return await _repository.Create(file);
        } */

        public async Task<Notifications> Update(Notifications value)
        {
            return await _repository.Update(value);
        }

        public async Task<Notifications> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<Notifications> Delete(Notifications value)
        {
            return await _repository.Delete(value);
        }
    
    }
}
