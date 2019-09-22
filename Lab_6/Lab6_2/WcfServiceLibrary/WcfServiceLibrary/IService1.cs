using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        // TODO: Добавьте здесь операции служб'
        [OperationContract]
        int Sum(int x, int y);

        [OperationContract]
        int Sub(int x, int y);

        [OperationContract]
        string ConCat(string x, string y);
    }
}
