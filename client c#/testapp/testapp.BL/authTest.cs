using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Net;

namespace testapp.BL
{
    public interface IAuth
    {
        bool auth(string login, string passwd);
        bool addCard(string card, string name, string surname, string secname, string admission);
        List<List<string>> GetDB();
        //bool SendMessageFromSocket(int port, string password, string login);
    }
    public class authTest : IAuth
    {
        const int port = 8888;
        const string address = "127.0.0.1";
        public List<List<string>> GetDB()
        {
            string q =  SendMessageFromSocket("G",11000);
            List<List<string>> res = new List<List<string>>();
            string[] tmp = q.Split(';');
            for (int i = 0; i < tmp.Length; i++)
            {
                Console.Write(i + " ");
                List<string> tmp1 = new List<string>();
                string[] tmp2 = tmp[i].Split(':');
                for (int j = 0; j < tmp2.Length; j++)
                {
                    tmp1.Add(tmp2[j]);
                    Console.Write(tmp2[j] + " ");
                }
                res.Add(tmp1);
                Console.WriteLine();
            }
            return res;
        }
        public bool addCard(string card,string name, string surname, string secname, string admission)
        {
            SendMessageFromSocket("N", 11000, card, name,surname,secname,admission);
            return true;
        }
        public bool auth(string login, string passwd)
        {
            bool q = false;
            try
            {
                string ans = SendMessageFromSocket("A",11000, passwd, login);
                if (ans == "1")
                {
                    q = true;
                }
                else
                {
                    q = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
                return q;
        }
        public static string SendMessageFromSocket(string operation, int port, string password, string login)
        {
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
            byte[] msg = Encoding.UTF8.GetBytes(operation + login + ":" + password);

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);

            string ans = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            // Используем рекурсию для неоднократного вызова SendMessageFromSocket()

            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            return ans;
        }
        public static string SendMessageFromSocket(string operation, int port, string card, string name, string surname, string secname, string admission)
        {
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
            byte[] msg = Encoding.UTF8.GetBytes(operation + name + ":" + surname + ":" + secname + ":" + admission + ":" + card);

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);

            string ans = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            // Используем рекурсию для неоднократного вызова SendMessageFromSocket()

            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            return ans;
        }
        public static string SendMessageFromSocket(string message, int port)
        {
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
            byte[] msg = Encoding.UTF8.GetBytes(message);

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);

            string ans = Encoding.UTF8.GetString(bytes, 0, bytesRec);
            // Используем рекурсию для неоднократного вызова SendMessageFromSocket()

            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            return ans;
        }
    }
}
