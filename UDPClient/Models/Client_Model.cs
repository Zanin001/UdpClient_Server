using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UDP;

namespace UDPClient.Models;
internal class Client_Model
{
    private UdpService UdpService;
    private IPAddress _ipAddress;
    private int _port;
    private string message;

    public IPAddress IPAddress { set { _ipAddress = value; } }
    public int Port { set { _port = value; } }
    public string Message {  set { message = value; } }

    public Client_Model()
    {
        UdpService = new();
    }

    public async Task SendMessage()
    {
        int attempt = 0;

        while (attempt != 3)
        {
            var response = await UdpService.Send
            (
                Encoding.ASCII.GetBytes(message),
                new IPEndPoint(_ipAddress, _port)
            );

            if (response)
                return;

            attempt++;
        }
    }
}
