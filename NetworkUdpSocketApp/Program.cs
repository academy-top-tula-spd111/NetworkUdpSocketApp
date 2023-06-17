using System.Net;
using System.Net.Sockets;
using System.Text;

using Socket socketUdp = new Socket(AddressFamily.InterNetwork, 
                                    SocketType.Dgram, 
                                    ProtocolType.Udp);
var localPoint = new IPEndPoint(IPAddress.Loopback, 7777);
socketUdp.Bind(localPoint);

Console.WriteLine("UDP server start...");

byte[] buffer  = new byte[1024];

EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);

while(true)
{
    var result = await socketUdp.ReceiveFromAsync(buffer, remoteIp);
    var message = Encoding.UTF8.GetString(buffer, 0, result.ReceivedBytes);
    if (result.ReceivedBytes == 0) break;
    Console.WriteLine($"Sends {result.ReceivedBytes} bytes from {result.RemoteEndPoint}");
    Console.WriteLine(message);
}


