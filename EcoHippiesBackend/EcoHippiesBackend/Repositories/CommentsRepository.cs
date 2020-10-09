using AutoMapper;
using EcoHippiesBackend.DTOs;
using EcoHippiesBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Repositories
{
    public class CommentsRepository
    {
        private readonly ApiContext _context;
        private IMapper _mapper;

        public CommentsRepository(ApiContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }

        public async Task<Comments> Create(Comments value)
        {

            _context.Comments.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Comments> Delete(Comments value)
        {
            _context.Set<Comments>().Remove(value);
            await _context.SaveChangesAsync();
            return value;


        }
        public async Task<Comments> Delete(int Id)
        {
            var entityToDelete = _context.Comments.FirstOrDefault(x => x.CommentId == Id);
            if (entityToDelete != null)
            {
                _context.Comments.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return entityToDelete;
            }
            else
            {
                return null;
            }
        }


        public async Task<IList<CommentsDTO>> Read()
        {
            var replies = _context.Comments.AsEnumerable();
            var dtos = _mapper.Map<IList<CommentsDTO>>(replies);

            return await Task.Run(() => dtos.ToList());
        }

        public async Task<CommentsDTO> ReadById(int Id)
        {
            var entityToReturn = await _context.Comments.FindAsync(Id);
            if (entityToReturn != null)
            {
                var dto = _mapper.Map<CommentsDTO>(entityToReturn);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<Comments> Update(Comments value)
        {
            var editedEntity = _context.Set<Comments>().FirstOrDefault(e => e.CommentId == value.CommentId);
            editedEntity = value;
            _context.Update(editedEntity);
            await _context.SaveChangesAsync();
            return value;

        }
    }
}
