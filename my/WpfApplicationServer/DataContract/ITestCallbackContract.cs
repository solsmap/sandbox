using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    public interface ITestCallbackContract
    {
        [OperationContract(IsOneWay=true)]
        void SendDataCallBack();

        [OperationContract(IsOneWay=true)]
        void ChangeStateCallBack();
    }
}
