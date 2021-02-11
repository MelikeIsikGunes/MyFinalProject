using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message) //sadece data ve mesaj ver
        {

        }

        public ErrorDataResult(T data) : base(data, false) //sadece data ver
        {

        }

        public ErrorDataResult(string message) : base(default, false, message) //sadece mesaj ver
        {

        }

        public ErrorDataResult() : base(default, false) //hiçbir şey verme
        {

        }
    }
}
