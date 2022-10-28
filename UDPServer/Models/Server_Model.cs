using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UDP;

namespace UDPServer.Models;

public class Server_Model
{
    private UdpService _udpService;
    private IPAddress _ipAddress;
    private int _port;
    private bool _isListen;
    private bool stop;

    public IPAddress IpAddress { get { return _ipAddress; } set { _ipAddress = value; } }
    public int Port { get { return _port; } set { _port = value; } }
    public bool IsListen { get { return _isListen; } set { _isListen = value; } }

    public Server_Model()
    {
        _udpService = new ();
        _isListen = default;
    }

    public async Task StartListen()
    {
        try
        {
            stop = false;
            _isListen = true;

            while(stop != true)
            {
                string message = await _udpService.Listen(new IPEndPoint(_ipAddress, _port));
            }

            _isListen = false;
        }
        catch(Exception e)
        {
            _isListen = false;
        }
    }

    public void StopListen()
    {
        stop = true;
        _udpService.StopListen();
    }

}

