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
    public class LocationsService : IService<LocationsRepository, Locations, LocationsDTO>
    {
        private readonly LocationsRepository _repository;

        public LocationsService(LocationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<LocationsDTO>> Read()
        {
            return await _repository.Read();
        }


        public async Task<LocationsDTO> ReadById(int Id)
        {
            return await _repository.ReadById(Id);
        }
        public async Task<Locations> Create(Locations value)
        {
            return await _repository.Create(value);
        }

        /* async Task<ProductDto> Create(ProductRequest value)
        {
            return await _repository.Create(value);
        }
        public async Task<List<string>> Create(IFormFile file)
        {
            return await _repository.Create(file);
        } */

        public async Task<Locations> Update(Locations value)
        {
            return await _repository.Update(value);
        }

        public async Task<Locations> Delete(int Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<Locations> Delete(Locations value)
        {
            return await _repository.Delete(value);
        }
    
    }
}
