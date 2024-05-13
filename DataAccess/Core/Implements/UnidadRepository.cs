using Common.Helpers;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using DataAccess.Core.Contract;

namespace DataAccess.Core.Implements
{
    public class UnidadRepository : IUnidadRepository
    {
        #region Propierties
        private readonly DbCrudContext context;        
        #endregion

        #region Contructor
        public UnidadRepository(DbCrudContext context)
        {
            this.context = context;            
        }

        #endregion

        #region Method
        public async Task<Response<Object>> GetAll()
        {
            Response<Object> response = new();
            try
            {
                List<Unidad> query = await context.Unidades.Where(x=> x.Estado == 1).ToListAsync();

                response = new()
                {
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa),
                    ObjectResponse = query,
                    Status = true
                };

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                return new Response<Object>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        public async Task<Response<bool>> Update(UnidadDto request)
        {
            Response<bool> response = new();
            try
            {
                var unidad = context.Unidades.Where(x => x.Id == request.Id).FirstOrDefault();

                unidad.Estado = request.Estado;
                unidad.Descripcion = request.Descripcion;
                
                context.Update(unidad);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.UpdateSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.UpdateError)
                };
            }
        }

        public async Task<Response<bool>> Create(UnidadDto request)
        {
            Response<bool> response = new();
            try
            {
                Unidad unidad = new()
                {
                    Descripcion = request.Descripcion,
                    Estado = request.Estado,
                };
               
                context.Add(unidad);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.CreateSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.CreateError)
                };
            }
        }

        public async Task<Response<bool>> DeleteById(int id)
        {
            Response<bool> response = new();
            try
            {
                var unidad = context.Unidades.Where(x => x.Id == id).FirstOrDefault();

                unidad.Estado = 0;

                context.Update(unidad);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.DeleteSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.DeleteError)
                };
            }
        }        
        #endregion
    }
}
