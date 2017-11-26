using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplicationClient
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            PipeClient client = new PipeClient();
            client.OnCallBack += this.CallBack;
            client.SendData();
        }

        public void CallBack()
        {
            System.Console.WriteLine(">>> コールバック <<<");
        }
    }
}
