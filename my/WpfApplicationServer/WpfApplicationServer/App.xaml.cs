using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplicationServer
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private TestDataContract _dataContract = null;
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            this._dataContract = new TestDataContract();

            this._dataContract.OnDataReceive += this.Receive;

            this._dataContract.Start();
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);

            //if (this._dataContract.OnDataReceive != null)
            {
                this._dataContract.OnDataReceive -= this.Receive;
            }

            if (this._dataContract != null)
            {
                this._dataContract.Close();
            }
        }

        public void Receive()
        {
            var task = Processing();
        }

        async Task<bool> Processing()
        {
            await Task.Run(() => System.Threading.Thread.Sleep(100));

            return true;
        }
    }
}
