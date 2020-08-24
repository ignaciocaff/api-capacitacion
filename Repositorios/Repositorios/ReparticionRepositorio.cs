using AutoMapper;
using Capacitacion.IRepositorios;
using Capacitacion.Modelos;
using Core.EF;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.Repositorios
{
    public class ReparticionRepositorio : Repository<Reparticiones>, IReparticionRepositorio
    {
        private readonly IMapper _mapper;
        public ReparticionRepositorio(IUnitOfWork context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public bool Create(Reparticion entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Reparticion entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reparticion> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Reparticion>> GetAllAsync()
        {
            return await DbSet.Select(x => _mapper.Map<Reparticion>(x)).ToListAsync();
        }

        public Reparticion GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Reparticion> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Reparticion entity)
        {
            throw new NotImplementedException();
        }
    }

}
