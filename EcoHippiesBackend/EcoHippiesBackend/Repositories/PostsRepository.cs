using AutoMapper;
using EcoHippiesBackend.DTOs;
using EcoHippiesBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Repositories
{
    public class PostsRepository
    {
        private readonly ApiContext _context;
        private IMapper _mapper;

        public PostsRepository(ApiContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }

        public async Task<Posts> Create(Posts value)
        {

            _context.Posts.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Posts> Delete(Posts value)
        {
            _context.Set<Posts>().Remove(value);
            await _context.SaveChangesAsync();
            return value;


        }
        public async Task<Posts> Delete(int Id)
        {
            var entityToDelete = _context.Posts.FirstOrDefault(x => x.PostId == Id);
            if (entityToDelete != null)
            {
                _context.Posts.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return entityToDelete;
            }
            else
            {
                return null;
            }
        }


        public async Task<IList<PostsDTO>> Read()
        {
            var replies = _context.Posts.AsEnumerable();
            var dtos = _mapper.Map<IList<PostsDTO>>(replies);

            return await Task.Run(() => dtos.ToList());
        }

        public async Task<PostsDTO> ReadById(int Id)
        {
            var entityToReturn = await _context.Posts.FindAsync(Id);
            if (entityToReturn != null)
            {
                var dto = _mapper.Map<PostsDTO>(entityToReturn);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<Posts> Update(Posts value)
        {
            var editedEntity = _context.Set<Posts>().FirstOrDefault(e => e.PostId == value.PostId);
            editedEntity = value;
            _context.Update(editedEntity);
            await _context.SaveChangesAsync();
            return value;

        }
    }
}
