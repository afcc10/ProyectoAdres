using Common.Helpers;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace DataAccess.Core.Implements
{
    public class ProveedorRepository : IProveedorRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        #endregion

        #region Contructor
        public ProveedorRepository(DbCrudContext context)
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
                List<Proveedor> query = await context.Proveedores.Where(x => x.Estado == 1).ToListAsync();

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

        public async Task<Response<bool>> Update(ProveedorDto request)
        {
            Response<bool> response = new();
            try
            {
                var proveedor = context.Proveedores.Where(x => x.Id == request.Id).FirstOrDefault();

                proveedor.Estado = request.Estado;
                proveedor.Descripcion = request.Descripcion;

                context.Update(proveedor);
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

        public async Task<Response<bool>> Create(ProveedorDto request)
        {
            Response<bool> response = new();
            try
            {
                Proveedor proveedor = new()
                {
                    Descripcion = request.Descripcion,
                    Estado = request.Estado,
                };

                context.Add(proveedor);
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
                var proveedor = context.Proveedores.Where(x => x.Id == id).FirstOrDefault();

                proveedor.Estado = 0;

                context.Update(proveedor);
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
