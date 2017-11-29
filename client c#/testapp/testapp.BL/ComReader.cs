using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace testapp.BL
{
    public interface IReader
    {
        byte[] readFrom(string Com);
    }
    public class ComReader:IReader
    {
        private string indata = "";
        private byte[] data = new byte[1];
        public byte[] readFrom(string Com)
        {
            SerialPort port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            //port.Read(data, 0, data.Length);
            //port.Close();
            while (data.Count() == 1) { }
            return data;
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            data = new byte[12];
            sp.Read(data, 0, data.Length);
            indata = data.ToString();
            sp.Close();
            //spRec?.Invoke(this, EventArgs.Empty);
        }
    }
}
