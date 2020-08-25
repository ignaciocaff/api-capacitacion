using AutoMapper;
using Capacitacion.IRepositorios;
using Capacitacion.Modelos;
using Core.EF;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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

        public bool Crear(Reparticion entity)
        {
            var reparticion = _mapper.Map<Reparticiones>(entity);
            DbSet.Add(reparticion);
            return SaveChanges() > 0;
        }

        public ICollection<Reparticion> ObtenerTodosSp()
        {
            OracleParameter cursor = new OracleParameter("O_CUR", OracleDbType.RefCursor, ParameterDirection.Output);
            var reparticiones = DbSet.FromSql("BEGIN PR_OBTENER_REPARTICIONES(:O_CUR); END;", cursor).Select(x => _mapper.Map<Reparticion>(x)).ToList();
            return reparticiones;
        }

        public bool Eliminar(Reparticion entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reparticion> ObtenerTodo()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Reparticion>> ObtenerTodoAsync()
        {
            return await DbSet.Select(x => _mapper.Map<Reparticion>(x)).ToListAsync();
        }

        public Reparticion ObtenerPorId(long id)
        {
            var reparticion = DbSet.FirstOrDefault(x => x.IdReparticion == id);
            return _mapper.Map<Reparticion>(reparticion);
        }

        public Task<Reparticion> ObtenerPorIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Reparticion entity)
        {
            throw new NotImplementedException();
        }
    }

}
