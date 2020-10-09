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
    public class RepliesService : IService<RepliesRepository, Replies, RepliesDTO>
    {
        private readonly RepliesRepository _repository;

        public RepliesService(RepliesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<RepliesDTO>> Read()
        {
            return await _repository.Read();
        }


        public async Task<RepliesDTO> ReadById(int Id)
        {
            return await _repository.ReadById(Id);
        }
        public async Task<Replies> Create(Replies value)
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

        public async Task<Replies> Update(Replies value)
        {
            return await _repository.Update(value);
        }

        public async Task<Replies> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<Replies> Delete(Replies value)
        {
            return await _repository.Delete(value);
        }
    

    }
}
