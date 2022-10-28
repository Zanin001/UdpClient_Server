using UDPClient.ViewModels;
using UDPClient.Models;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Media;
using System.Threading;

namespace UDPClient.ViewModels
{
    internal class Client_ViewModel : ViewModelBase
    {
        #region Private Variable
        private string _ipAddress;
        private string _port;
        #endregion

        #region Public Variables
        public string IpAddress
        {
            get
            {
                if (_ipAddress is null)
                    _ipAddress = "192.168.0.0";
                return _ipAddress;
            }
        }
        public string Port { get {  return _port; } set { _port = value; } }
        #endregion

        public Client_ViewModel() { }
    }
}
