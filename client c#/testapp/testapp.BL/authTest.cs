using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace testapp.BL
{
    public interface IAuth
    {
        bool auth(string login, string passwd);
    }
    public class authTest : IAuth
    {
        const int port = 8888;
        const string address = "127.0.0.1";
        public bool auth(string login, string passwd)
        {
            bool q = false;
            try
            {
                q = SendMessageFromSocket(11000, passwd, login);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
                return q;
        }

        static bool SendMessageFromSocket(int port, string password, string login)
        {
            bool need = false;
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];

            // Соединяемся с удаленным устройством

            // Устанавливаем удаленную точку для сокета
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            sender.Connect(ipEndPoint);


            Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
            byte[] msg = Encoding.UTF8.GetBytes("A" + login + ":" + password);

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);

            String ans =  Encoding.UTF8.GetString(bytes, 0, bytesRec);
            if (ans == "1")
            {
                need = true;
            } else
            {
                need = false;
            }

            // Используем рекурсию для неоднократного вызова SendMessageFromSocket()

            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            return need;
        }
    }
}
