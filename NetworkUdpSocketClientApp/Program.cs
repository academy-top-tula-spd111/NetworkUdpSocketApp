using System.Net;
using System.Net.Sockets;
using System.Text;

using Socket socketUdp = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Dgram,
                                    ProtocolType.Udp);

string message = "Hello world, from UDP Socket!";
byte[] buffer = Encoding.UTF8.GetBytes(message);

EndPoint remoteEP = new IPEndPoint(IPAddress.Loopback, 7777);
int bytes = await socketUdp.SendToAsync(buffer, remoteEP);
Console.WriteLine($"Sends {bytes} bytes");