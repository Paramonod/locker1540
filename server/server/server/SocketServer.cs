// SocketServer.cs
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using MySql.Data;
using System.Collections.Generic;
using System.Collections;
using MySql.Data.MySqlClient;

namespace SocketServer
{
    class Program
    {
        const string IPADDRESS = "78.106.118.23";
        const string DATABASE = "lockerdb";
        const string TABLE = "userstable";
        const string USER = "reader";
        const string PASSWORD = "IT108";
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
                    List<List<string>> DBreply = new List<List<string>>();
                    switch (data[0])
                    {
                        case 'C':
                            reply = "1";
                            ServChange(data);
                            break;
                        case 'A':
                            reply = ServAuth(data);
                            break;
                        case 'N':
                            reply = "1";
                            ServAddNew(data);
                            break;
                        case 'G':
                            DBreply = GetDB();
                            for (int i = 0; i < DBreply.Count; i++)
                            {
                                Console.WriteLine(DBreply[i]);
                            }
                            break;
                    }                 
                    Console.Write(reply);
                    byte[] msg;
                    if (data[0] == 'G')
                    {
                        string q = "";
                        for (int i = 0; i < DBreply.Count; i++)
                        {
                            for (int j = 0; j < DBreply[i].Count; j++)
                            {
                                q += DBreply[i][j] + ":";
                            }
                            q += ";";
                        }
                        msg = Encoding.UTF8.GetBytes(q);
                    } else
                    msg = Encoding.UTF8.GetBytes(reply);
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
        public static List<List<string>> GetDB()
        {
            Authq card = new Authq();
            IAuthq addcard = card;
            return  addcard.GetA();
        }
        public static void ServAddNew(string data)
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
        public static void ServChange(string data)
        {
            data = data.Substring(1);
            string[] q = data.Split(':');
            for (int i = 0; i < q.Length; i++)
            {
                Console.WriteLine(q[i]);
            }
            Authq card = new Authq();
            IAuthq addcard = card;
            addcard.changeC(q[0],q[5],q[1],q[2],q[3],q[4]);
        }
        public interface IAuthq
        {
            int ConAuth(string login, string password);
            bool addN(string card, string name, string surname, string secname, string admission);
            bool changeC(string id, string card, string name, string surname, string secname, string admission);
            List<List<string>> GetA();
        }
        public class Authq : IAuthq
        {
            public List<List<string>> GetA()
            {
                List<List<string>> q = new List<List<string>>();
                MySqlConnectionStringBuilder mysqlCSB;
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = IPADDRESS;
                mysqlCSB.Database = DATABASE;
                mysqlCSB.UserID = USER;
                mysqlCSB.Password = PASSWORD;
                MySqlConnection con = new MySqlConnection(mysqlCSB.ToString());
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    con.Open();

                    string sql = "SELECT Name, Surname, SecName, Admission, card FROM lockerdb.userstable;";
                    Console.WriteLine(sql);
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    int i = 0;
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0].ToString() + " " + rdr[1].ToString() + " " + rdr[2].ToString() + " "
                            + rdr[3].ToString() + " " + rdr[4].ToString() + " ");
                        List<string> tmp = new List<string> { rdr[0].ToString(), rdr[1].ToString(),
                            rdr[2].ToString(), rdr[3].ToString(), rdr[4].ToString() };
                        q.Add(tmp);
                        i++;
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    Console.WriteLine("Невозможно подключиться к БД");
                }
                con.Close();
                Console.WriteLine("Done.");
                return q;
            }
            public bool addN(string card, string name, string surname, string secname, string admission)
            {
                MySqlConnectionStringBuilder mysqlCSB;
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = IPADDRESS;
                mysqlCSB.Database = DATABASE;
                mysqlCSB.UserID = USER;
                mysqlCSB.Password = PASSWORD;
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
            public bool changeC(string id,string card, string name, string surname, string secname, string admission)
            {
                MySqlConnectionStringBuilder mysqlCSB;
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = IPADDRESS;
                mysqlCSB.Database = DATABASE;
                mysqlCSB.UserID = USER;
                mysqlCSB.Password = PASSWORD;
                MySqlConnection con = new MySqlConnection(mysqlCSB.ToString());
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    con.Open();

                    string sql = "UPDATE lockerdb.userstable SET Name='" + name +
                        "', Surname='" + surname + "', SecName ='" + secname + "', Admission='" + admission + "',card='" + card
                        +"' WHERE id='"+id+"';";
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
                mysqlCSB.Server = IPADDRESS;
                mysqlCSB.Database = DATABASE;
                mysqlCSB.UserID = USER;
                mysqlCSB.Password = PASSWORD;
                MySqlConnection con = new MySqlConnection(mysqlCSB.ToString());
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    Console.WriteLine(mysqlCSB.ToString());
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
                    
                    Console.WriteLine(ex.ToString()); //"Неверный логин или пароль"
                    needGroup = -1;
                }
                con.Close();
                Console.WriteLine("Done.");
                return needGroup;
            }
        }
    }
}