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
                    MySqlConnectionStringBuilder mysqlCSB;
                    mysqlCSB = new MySqlConnectionStringBuilder();
                    mysqlCSB.Server = "localhost";
                    mysqlCSB.Database = "lockerdb";
                    mysqlCSB.UserID = "reader";
                    mysqlCSB.Password = "IT108";
                    MySqlConnection con = new MySqlConnection("server=localhost;user=reader;database=lockerdb;port=3306;password=IT108;");
                    try
                    {
                        Console.WriteLine("Connecting to MySQL...");
                        con.Open();

                        string sql = "SELECT Name FROM userstable WHERE Surname = 'Paramonov'";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        MySqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                        }
                        rdr.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    con.Close();
                    Console.WriteLine("Done.");

                    // Программа приостанавливается, ожидая входящее соединение
                    Socket handler = sListener.Accept();
                    string data = null;

                    // Мы дождались клиента, пытающегося с нами соединиться

                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);

                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    // Показываем данные на консоли
                    Console.Write("Полученный текст: " + data + "\n\n");
                    


                    // Отправляем ответ клиенту\
                    string reply;
                    if (data == "Aparamonod:12345")
                    {
                        reply = "1";
                    }
                    else
                    {
                        reply = "0";
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
        public interface IAuthq
        {
            bool ConAuth();
        }
        public class Authq : IAuthq
        {
            public bool ConAuth()
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

                    string sql = "SELECT Name FROM userstable WHERE Surname = 'Paramonov'";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                con.Close();
                Console.WriteLine("Done.");
                return false;
            }
        }
    }
}