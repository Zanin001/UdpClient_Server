namespace UDP;

public class UdpService
{
 
    private static UdpClient UdpClient { get; set; }
    public static Socket Socket
    {
        get
        {
            if (Socket == null)
                _socket = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            return _socket;
        }
    }
    private static Socket _socket { get; set; }

    public UdpService()
    {
    }

    public async Task<bool> Send(Byte[] message, IPEndPoint address)
    {
        try
        {
            Socket.SendTo(message, address);
            return true;
        }
        catch(Exception e)
        {
            return false;
        }
    }
        
    public async Task<string> Listen(IPEndPoint address)
    {
        try
        {
            UdpClient = new (address.Port);

            byte[] message = UdpClient.Receive(ref address);

            return Encoding.ASCII.GetString(message, 0, message.Length);
        }
        catch(Exception e)
        {
            return e.Message;
        }
    }

    public void StopListen()
    {
        if (UdpClient is not null)
            UdpClient.Dispose();
    }
}