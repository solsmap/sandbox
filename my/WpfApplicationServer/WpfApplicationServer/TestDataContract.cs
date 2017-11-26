using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TestDataContract : ITestDataContract
    {
        private ServiceHost _host = null;

        // 受信イベント
        public delegate void DataReceiveEvent();
        public event DataReceiveEvent OnDataReceive = null;

        public void Start()
        {
            this._host = new ServiceHost(typeof(TestDataContract));
            this._host.AddServiceEndpoint(
                typeof(ITestDataContract),
                new NetNamedPipeBinding(NetNamedPipeSecurityMode.None),
                "net.pipe://localhost/sampleService");
            this._host.Open();
        }

        public void Close()
        {
            this._host.Close();
        }

        public void SendData()
        {
            ITestCallbackContract callbackContract = OperationContext.Current.GetCallbackChannel<ITestCallbackContract>();

            if (OnDataReceive != null)
            {
                this.OnDataReceive();
            }

            callbackContract.SendDataCallBack();
        }
    }
}
