﻿using Models.Models;
using System;
using System.Collections.Generic;

namespace Common.Utilities.Services
{
    public class Response<T>
    {
        public bool Status { get; set; }
        public List<MessageResult> Message { get; set; }
        public T ObjectResponse { get; set; }

        public Response()
        {
            Message = new List<MessageResult>();
        }

        public Response(bool status, List<MessageResult> message, T objectResponse)
        {
            this.Status = status;
            this.Message = message;
            this.ObjectResponse = objectResponse;
        }

        public static implicit operator Response<T>(Response<UnidadDto> v)
        {
            throw new NotImplementedException();
        }
    }
    public class MessageResult
    {
        public string Message { get; set; }

    }
}
