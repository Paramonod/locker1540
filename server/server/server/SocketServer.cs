// SocketServer.cs
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Устанавливаем для сокета локальную конечную точку
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);
            

            // Создаем сокет Tcp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);

                // Начинаем слушать соединения
                while (true)
                {
                    Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);

                    // Программа приостанавливается, ожидая входящее соединение
                    Socket handler = sListener.Accept();
                    string data = null;

                    // Мы дождались клиента, пытающегося с нами соединиться

                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);

                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    // Показываем данные на консоли
                    Console.Write("Полученный текст: " + data + "\n\n");
                    string reply = "";
                    switch (data[0])
                    {
                        case 'A':
                            reply = ServAuth(data);
                            break;
                        case 'N':
                            reply = ServAddNew(data);
                            break;
                    }                 
                    Console.Write(reply);
                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    handler.Send(msg);

                    if (data.IndexOf("<TheEnd>") > -1)
                    {
                        Console.WriteLine("Сервер завершил соединение с клиентом.");
                        break;
                    }

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
        public static string ServAddNew(string data)
        {
            data = data.Substring(1);
            string [] q =  data.Split(':');
            for (int i = 0; i < q.Length; i++)
            {
                Console.WriteLine(q[i]);
            }
            Authq card = new Authq();
            IAuthq addcard = card;
            addcard.addN(q[4], q[0], q[1], q[2], q[3]);
            return "1";
        }
        public static string ServAuth(string data)
        {
            Authq _auth = new Authq();
            IAuthq auth = _auth;
            string _login = data.Substring(1, data.IndexOf(":") - 1);
            string _password = data.Substring(data.IndexOf(":") + 1);


            // Отправляем ответ клиенту
            string reply;
            int req = auth.ConAuth(_login, _password);
            if (req == 1)
            {
                reply = "1";
            }
            else
            {
                reply = "-1";
            }
            return reply;
        }
        public interface IAuthq
        {
            int ConAuth(string login, string password);
            bool addN(string card, string name, string surname, string secname, string admission);
        }
        public class Authq : IAuthq
        {
            public bool addN(string card, string name, string surname, string secname, string admission)
            {
                MySqlConnectionStringBuilder mysqlCSB;
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = "localhost";
                mysqlCSB.Database = "lockerdb";
                mysqlCSB.UserID = "reader";
                mysqlCSB.Password = "IT108";
                MySqlConnection con = new MySqlConnection(mysqlCSB.ToString());
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    con.Open();

                    string sql = "INSERT INTO lockerdb.userstable (Name, Surname, SecName, Admission, Auth)" +
                        " VALUES ('" + name +
                        "', '" + surname + "', '" + secname + "', '" + admission + "', '1');";
                    Console.WriteLine(sql);
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    Console.WriteLine("Неверный логин или пароль");
                    //needGroup = -1;
                }
                con.Close();
                Console.WriteLine("Done.");
                return true;
            }
            public int ConAuth(string login, string password)
            {
                int needGroup = 0;
                MySqlConnectionStringBuilder mysqlCSB;
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = "localhost";
                mysqlCSB.Database = "lockerdb";
                mysqlCSB.UserID = "reader";
                mysqlCSB.Password = "IT108";
                MySqlConnection con = new MySqlConnection(mysqlCSB.ToString());
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    con.Open();

                    string sql = "SELECT Admission FROM lockerdb.userstable WHERE login = '" + login + "' AND password = '" + password + "'";
                    Console.WriteLine(sql);
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0]);
                        needGroup = Int32.Parse(rdr[0].ToString());
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Неверный логин или пароль");
                    needGroup = -1;
                }
                con.Close();
                Console.WriteLine("Done.");
                return needGroup;
            }
        }
    }
}