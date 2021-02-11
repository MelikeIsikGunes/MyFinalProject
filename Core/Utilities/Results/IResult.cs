using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } //işlem başarılı mı başarısız mı
        string Message { get; } //read only-sadece okunabilir ama constructer'de set edilebilirler

    }
}
