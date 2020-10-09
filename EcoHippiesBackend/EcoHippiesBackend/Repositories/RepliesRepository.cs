using AutoMapper;
using EcoHippiesBackend.DTOs;
using EcoHippiesBackend.Interfaces;
using EcoHippiesBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Repositories
{
    public class RepliesRepository: IRepository<Replies, RepliesDTO>
    {
        private readonly ApiContext _context;
        private IMapper _mapper;

        public RepliesRepository(ApiContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }

        public async Task<Replies> Create(Replies value)
        {

            _context.Replies.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Replies> Delete(Replies value)
        {
            _context.Set<Replies>().Remove(value);
            await _context.SaveChangesAsync();
            return value;


        }
        public async Task<Replies> Delete(int Id)
        {
            var entityToDelete = _context.Replies.FirstOrDefault(x => x.ReplyId == Id);
            if (entityToDelete != null)
            {
                _context.Replies.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return entityToDelete;
            }
            else
            {
                return null;
            }
        }


        public async Task<IList<RepliesDTO>> Read()
        {
            var replies = _context.Replies.AsEnumerable();
            var dtos = _mapper.Map<IList<RepliesDTO>>(replies);

            return await Task.Run(() =>dtos.ToList());
        }

        public async Task<RepliesDTO> ReadById(int Id)
        {
            var entityToReturn = await _context.Replies.FindAsync(Id);
            if (entityToReturn != null)
            {
                var dto = _mapper.Map<RepliesDTO>(entityToReturn);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<Replies> Update(Replies value)
        {
            var editedEntity = _context.Set<Replies>().FirstOrDefault(e => e.ReplyId == value.ReplyId);
            editedEntity = value;
            _context.Update(editedEntity);
            await _context.SaveChangesAsync();
            return value;

        }

       }
}
