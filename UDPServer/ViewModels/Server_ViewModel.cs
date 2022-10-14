using UDPServer.ViewModels;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using UDPServer.Models;

namespace UDPServer.ViewModels
{
    public class Server_ViewModel : ViewModelBase
    {
        private Server_Model _model;
        private RelayCommand _startCmd;
        private RelayCommand _stopCmd;
        private string _ipAddress;
        private string _port;
        public RelayCommand StartCmd
        {
            get
            {
                if( _startCmd == null)
                    _startCmd = new (param => Start(), param => CanStart());

                return _startCmd;
            }
        }
        public RelayCommand StopCmd
        {
            get
            {
                if (_stopCmd == null)
                    _stopCmd = new(param => Stop(), param => CanStop());

                return _stopCmd;
            }
        }
        public string IpAddress
        {
            get
            {
                if (_ipAddress is null)
                    _ipAddress = IPAddress.Any.ToString();

                return _ipAddress;
            }
        }
        public string Port 
        { 
            get 
            { 
                return _port; 
            }
            set
            {
                _port = value;
            }
        }

        public Server_ViewModel()
        {
            _model = new ();
        }

        public void Start()
        {
            if (_port is not null)
            {
                _model.IpAddress = IPAddress.Parse(_ipAddress);
                _model.Port = Convert.ToInt16(_port);
                _model.StartListen();
            }
        }   
        public void Stop()
        {

        }

        public bool CanStart()
        {
            if (Port is null)
                return false;

            return true;
        }

        public bool CanStop()
        {
            return false;
        }

    }
}
