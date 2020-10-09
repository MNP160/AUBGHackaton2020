using AutoMapper;
using EcoHippiesBackend.DTOs;
using EcoHippiesBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Repositories
{
    public class LocationsRepository
    {
        private readonly ApiContext _context;
        private IMapper _mapper;

        public LocationsRepository(ApiContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }

        public async Task<Locations> Create(Locations value)
        {

            _context.Locations.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Locations> Delete(Locations value)
        {
            _context.Set<Locations>().Remove(value);
            await _context.SaveChangesAsync();
            return value;


        }
        public async Task<Locations> Delete(int Id)
        {
            var entityToDelete = _context.Locations.FirstOrDefault(x => x.LocationId == Id);
            if (entityToDelete != null)
            {
                _context.Locations.Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return entityToDelete;
            }
            else
            {
                return null;
            }
        }


        public async Task<IList<LocationsDTO>> Read()
        {
            var replies = _context.Locations.AsEnumerable();
            var dtos = _mapper.Map<IList<LocationsDTO>>(replies);

            return await Task.Run(() => dtos.ToList());
        }

        public async Task<LocationsDTO> ReadById(int Id)
        {
            var entityToReturn = await _context.Locations.FindAsync(Id);
            if (entityToReturn != null)
            {
                var dto = _mapper.Map<LocationsDTO>(entityToReturn);
                return dto;
            }
            else
            {
                return null;
            }
        }

        public async Task<Locations> Update(Locations value)
        {
            var editedEntity = _context.Set<Locations>().FirstOrDefault(e => e.LocationId == value.LocationId);
            editedEntity = value;
            _context.Update(editedEntity);
            await _context.SaveChangesAsync();
            return value;

        }
    }
}
