using AutoMapper;
using EcoHippiesBackend.DTOs;
using EcoHippiesBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Repositories
{
    public class NotificationsRepository
    {
        private readonly ApiContext _context;
        private IMapper _mapper;

        public NotificationsRepository(ApiContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }

        public async Task<Notifications> Create(Notifications value)
        {

            _context.Notifications.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Notifications> Delete(Notifications value)
        {
            _context.Set<Notifications>().Remove(value);
            await _context.SaveChangesAsync();
            return value;


        }
        public async Task<Notifications> Delete(int Id)
        {
            var entityToDelete = _context.Notifications.FirstOrDefault(x => x.NotificationId == Id);
            if (entityToDelete != null)
            {
                _context.Notifications.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return entityToDelete;
            }
            else
            {
                return null;
            }
        }


        public async Task<IList<NotificationsDTO>> Read()
        {
            var replies = _context.Notifications.AsEnumerable();
            var dtos = _mapper.Map<IList<NotificationsDTO>>(replies);

            return await Task.Run(() => dtos.ToList());
        }

        public async Task<NotificationsDTO> ReadById(int Id)
        {
            var entityToReturn = await _context.Notifications.FindAsync(Id);
            if (entityToReturn != null)
            {
                var dto = _mapper.Map<NotificationsDTO>(entityToReturn);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<Notifications> Update(Notifications value)
        {
            var editedEntity = _context.Set<Notifications>().FirstOrDefault(e => e.NotificationId == value.NotificationId);
            editedEntity = value;
            _context.Update(editedEntity);
            await _context.SaveChangesAsync();
            return value;

        }
    }
}
