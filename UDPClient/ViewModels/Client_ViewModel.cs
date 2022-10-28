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

namespace UDPClient.ViewModels;

internal class Client_ViewModel : ViewModelBase
{
    #region Private Variable
    private Client_Model _model;
    private RelayCommand _sendCmd;
    private string _ipAddress;
    private string _port;
    private string _message;
    #endregion

    #region Public Variables
    public RelayCommand SendCmd
    {
        get
        {
            if (_sendCmd is null)
                _sendCmd = new(param => Send());
            return _sendCmd;

        }
    }
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
    public string Message { get { return _message; } set { _message = value; } }
    #endregion

    public Client_ViewModel() 
    {
        _model = new();
    }

    public async void Send()
    {
        BackgroundWorker _connectBw = new();
        _connectBw.DoWork += new(SendDoWork);
        _connectBw.RunWorkerAsync();
    }
    private void SendDoWork(object sender, DoWorkEventArgs e)
    {
        _model.IPAddress = IPAddress.Parse(_ipAddress);
        _model.Port = Convert.ToInt32(_port);
        _model.Message = _message;
        _model.SendMessage();
    }
}

