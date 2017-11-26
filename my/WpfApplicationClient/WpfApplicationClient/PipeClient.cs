using DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplicationClient
{
    public class PipeClient : ITestCallbackContract
    {
        public delegate void CallBackEvent();
        public event CallBackEvent OnCallBack = null;

        public void SendData()
        {
            DuplexChannelFactory<ITestDataContract> factory = new DuplexChannelFactory<ITestDataContract>(
                this,
                new NetNamedPipeBinding(NetNamedPipeSecurityMode.None),
                "net.pipe://localhost/sampleService");

            ITestDataContract channel = factory.CreateChannel();
            channel.SendData();
        }

        public void SendDataCallBack()
        {
            System.Console.WriteLine(">>> 受信 <<<");

            if (this.OnCallBack != null)
            {
                this.OnCallBack();
            }
        }

        public void ChangeStateCallBack()
        {
            throw new NotImplementedException();
        }
    }
}
