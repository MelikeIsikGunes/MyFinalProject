using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data,true,message) //sadece data ve mesaj ver
        {

        }

        public SuccessDataResult(T data):base(data,true) //sadece data ver
        {

        }

        //default dataya karşılık geliyor. Liste olduğu için defaultu null.
        //Örneğin return tipi int ama bir şey döndürmek istemiyorsak int'in defaultu(0) geçsin.

        public SuccessDataResult(string message):base(default,true,message) //sadece mesaj ver
        {

        }

        public SuccessDataResult():base(default,true) //hiçbir şey verme
        {

        }
    }
}
