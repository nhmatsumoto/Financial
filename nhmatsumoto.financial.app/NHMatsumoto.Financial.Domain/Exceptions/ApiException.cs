﻿namespace NHMatsumoto.Financial.Domain.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }
        public object Errors { get; }

        public ApiException(int statusCode, object errors = null)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}
