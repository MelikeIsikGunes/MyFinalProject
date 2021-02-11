using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //overloading-aşırı yükleme (Aynı isimden metotlar,imzaları farklı)
        public Result(bool success, string message):this(success)   //this-Result  Bu metot çalışacağı zaman Result'un tek parametreli olan metodu da çalışsın
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
