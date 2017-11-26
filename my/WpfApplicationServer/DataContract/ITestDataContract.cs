﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DataContract
{
    [ServiceContract(CallbackContract=typeof(ITestCallbackContract))]
    public interface ITestDataContract
    {
        [OperationContract(IsOneWay=true)]
        void SendData();
    }
}
