using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;

namespace AWSEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter IP Address:\t");      //129.177.63.214 - bergen
            //196.43.133.125 - MUK
            string ipadd = Console.ReadLine();
            Console.WriteLine("Enter Port:\t");
            int port = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Delay between transmissions (in milli seconds):\t");
            int ms = Int32.Parse(Console.ReadLine());

            TcpClient client = new TcpClient(ipadd, port);
            try
            {
                Stream s = client.GetStream();
                Console.WriteLine("connected!");
                StreamWriter sw = new StreamWriter(s);
                StreamReader sr = new StreamReader("sample.dat");
                sw.AutoFlush = true;
                string line = "";
                while ((line = sr.ReadLine())!=null)
                {
                        sw.WriteLine(line);
                        System.Threading.Thread.Sleep(ms);
                        Console.WriteLine("Data Sent: " + line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}