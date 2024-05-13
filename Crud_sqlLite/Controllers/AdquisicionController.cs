﻿using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Crud_sqlLite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdquisicionController : ControllerBase
    {
        #region Propierties
        private readonly IAdquisicionesServices Service;
        #endregion

        #region Constructor
        public AdquisicionController(IAdquisicionesServices service)
        {
            Service = service;
        }
        #endregion

        /// <summary>
        /// Obtener estudiantes
        /// </summary>
        /// <returns>Response model StudentDto</returns>
        /// <author>Andres Cabezas</author>
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(Response<List<AdquisicionDto>>), StatusCodes.Status200OK)]
        public async Task<Response<List<AdquisicionDto>>> GetAll()
        {
            Response<List<AdquisicionDto>> response;
            try
            {
                response = await Service.GetAll();
                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<AdquisicionDto>>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// crear estudiantes
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Post(AdquisicionDto request)
        {
            Response<bool> response;
            try
            {
                response = await Service.Create(request);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// actualizar estudiantes
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Update(AdquisicionDto request)
        {
            Response<bool> response;
            try
            {
                response = await Service.Update(request);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }


        /// <summary>
        /// eliminar by id
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> DeleteById(int id)
        {
            Response<bool> response;
            try
            {
                response = await Service.DeleteById(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }
    }
}
