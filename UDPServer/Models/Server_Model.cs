using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UDP;

namespace UDPServer.Models
{
    public class Server_Model
    {
        private UdpService _udpService;
        private IPAddress _ipAddress;
        private int _port;

        public IPAddress IpAddress { get { return _ipAddress; } set { _ipAddress = value; } }
        public int Port { get { return _port; } set { _port = value; } }

        public Server_Model()
        {
            _udpService = new ();
        }

        public async Task StartListen()
        {
            string message = await _udpService.Listen(new IPEndPoint(_ipAddress, _port));
        }


    }
}
