namespace UDP;

public class UdpService
{
        
    public static UdpClient UdpClient 
    {
        get
        {
            if (_udpClient == null)
                _udpClient = new UdpClient();
            return _udpClient;
        }
    }
    private static UdpClient _udpClient { get; set; }
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
    public static async Task Send(Byte[] message, IPEndPoint address)
    {
        try
        {
            Socket.SendTo(message, address);
        }
        catch(Exception e)
        {

        }
    }
        
    public static async Task Listen()
    {

    }
}