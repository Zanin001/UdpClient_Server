using UDPServer.ViewModels;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using UDPServer.Models;
using System.Windows.Media;
using System.Threading;

namespace UDPServer.ViewModels
{
    public class Server_ViewModel : ViewModelBase
    {
        #region Private variables
        private Server_Model _model;
        private RelayCommand _startCmd;
        private RelayCommand _stopCmd;
        private string _ipAddress;
        private string _port;
        private bool _isConnectd
        {
            get
            {
                if (_model is null)
                    return false;

                return _model.IsListen;
            }
        }
        private Color _statusColor
        {
            get
            {
                return _isConnectd ? Colors.Green : Colors.Red;
            }
        }
        #endregion

        #region Public variables
        public RelayCommand StartCmd
        {
            get
            {
                if( _startCmd == null)
                    _startCmd = new (param => Start());

                return _startCmd;
            }
        }
        public RelayCommand StopCmd
        {
            get
            {
                if (_stopCmd == null)
                    _stopCmd = new(param => Stop());

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
        public Brush StatusColor
        {
            get
            {
                return new SolidColorBrush(_statusColor);
            }
        }
        #endregion

        public Server_ViewModel()
        {
            _model = new ();
            new Thread(StatusSync).Start();
        }
        //GIT TEST
        public async void Start()
        {
            if (_port is not null)
            {
                BackgroundWorker _startBw = new();
                _startBw.DoWork += new DoWorkEventHandler(StartListenDoWork);
                _startBw.RunWorkerAsync();
            }
        }   
        private void StartListenDoWork(object sender, DoWorkEventArgs e)
        {
            _model.IpAddress = IPAddress.Parse(_ipAddress);
            _model.Port = Convert.ToInt16(_port);
            _model.StartListen();
        }
        public void Stop()
        {
            _model.StopListen();
        }

        private void StatusSync()
        {
            while (true)
            {
                NotifyPropertyChanged("StatusColor");
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }

    }
}
