using Common.Helpers;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Core.Implements
{
    public class ServicioRepository : IServicioRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        #endregion

        #region Contructor
        public ServicioRepository(DbCrudContext context)
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
                List<Servicio> query = await context.Servicios.Where(x => x.Estado == 1).ToListAsync();

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

        public async Task<Response<bool>> Update(ServicioDto request)
        {
            Response<bool> response = new();
            try
            {
                var servicio = context.Servicios.Where(x => x.Id == request.Id).FirstOrDefault();

                servicio.Estado = request.Estado;
                servicio.Descripcion = request.Descripcion;

                context.Update(servicio);
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

        public async Task<Response<bool>> Create(ServicioDto request)
        {
            Response<bool> response = new();
            try
            {
                Servicio servicio = new()
                {
                    Descripcion = request.Descripcion,
                    Estado = request.Estado,
                };

                context.Add(servicio);
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
                var servicio = context.Servicios.Where(x => x.Id == id).FirstOrDefault();

                servicio.Estado = 0;

                context.Update(servicio);
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
