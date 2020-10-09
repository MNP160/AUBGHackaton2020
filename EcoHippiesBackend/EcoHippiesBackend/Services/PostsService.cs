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
    public class PostsService : IService<PostsRepository, Posts, PostsDTO>
    {
        private readonly PostsRepository _repository;

        public PostsService(PostsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<PostsDTO>> Read()
        {
            return await _repository.Read();
        }


        public async Task<PostsDTO> ReadById(int Id)
        {
            return await _repository.ReadById(Id);
        }
        public async Task<Posts> Create(Posts value)
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

        public async Task<Posts> Update(Posts value)
        {
            return await _repository.Update(value);
        }

        public async Task<Posts> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<Posts> Delete(Posts value)
        {
            return await _repository.Delete(value);
        }
    
    }
}
