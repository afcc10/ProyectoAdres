using Common.Helpers;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Models;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DataAccess.Core.Contract;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Core.Implements
{
    public class AdquisicionRepository : IAdquisicionRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        #endregion

        #region Contructor
        public AdquisicionRepository(DbCrudContext context)
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
                List<Adquisicion> query = await context.Adquisiciones.Where(x => x.Estado == 1).ToListAsync();

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

        public async Task<Response<bool>> Update(AdquisicionDto request)
        {
            Response<bool> response = new();
            try
            {
                var adquisicion = context.Adquisiciones.Where(x => x.Id == request.Id).FirstOrDefault();

                adquisicion.Estado = request.Estado;
                adquisicion.Documentacion = request.Documentacion;
                adquisicion.Fecha_Adquisicion = DateTime.Now.ToString();
                adquisicion.Presupuesto = request.Presupuesto;
                adquisicion.Cantidad = request.Cantidad;
                adquisicion.Id_Proveedor = request.Id_Proveedor;
                adquisicion.Id_Servicio = request.Id_Servicio;
                adquisicion.Id_Unidad = request.Id_Unidad;
                adquisicion.Valor_Unitario = request.Valor_Unitario;
                adquisicion.Valor_Total = request.Valor_Unitario * request.Valor_Unitario;

                context.Update(adquisicion);
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

        public async Task<Response<bool>> Create(AdquisicionDto request)
        {
            Response<bool> response = new();
            try
            {
                Adquisicion adquisicion = new()
                {
                    Estado = request.Estado,
                    Documentacion = request.Documentacion,
                    Fecha_Adquisicion = DateTime.Now.ToString(),
                    Presupuesto = request.Presupuesto,
                    Cantidad = request.Cantidad,
                    Id_Proveedor = request.Id_Proveedor,
                    Id_Servicio = request.Id_Servicio,
                    Id_Unidad = request.Id_Unidad,
                    Valor_Unitario = request.Valor_Unitario,
                    Valor_Total = request.Valor_Unitario * request.Valor_Unitario            
                    
                };

                context.Add(adquisicion);
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
                var adquisiciones = context.Adquisiciones.Where(x => x.Id == id).FirstOrDefault();

                adquisiciones.Estado = 0;

                context.Update(adquisiciones);
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
