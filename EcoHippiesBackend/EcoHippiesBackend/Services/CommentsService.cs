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
    public class CommentsService : IService<CommentsRepository, Comments, CommentsDTO>
    {
        private readonly  CommentsRepository _repository;

        public CommentsService(CommentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<CommentsDTO>> Read()
        {
            return await _repository.Read();
        }


        public async Task<CommentsDTO> ReadById(int Id)
        {
            return await _repository.ReadById(Id);
        }
        public async Task<Comments> Create(Comments value)
        {
            return await _repository.Create(value);
        }

      
     /*   public async Task<List<string>> Create(IFormFile file)
        {
            return await _repository.Create(file);
        } */

        public async Task<Comments> Update(Comments value)
        {
            return await _repository.Update(value);
        }

        public async Task<Comments> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<Comments> Delete(Comments value)
        {
            return await _repository.Delete(value);
        }
    
    }
}
