using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using GlobalLibrary;

namespace ClientApplication
{
    public partial class Form_Client : Form
    {
        Parametre param = new Parametre();

        public Form_Client()
        {
            InitializeComponent();

            param.KeepServerLog = true;

            DataBinding();
        }

        private void DataBinding()
        {
            textBox_ServerIP.DataBindings.Add("Text", param, "ServerIP", false);
            textBox_ServerPort.DataBindings.Add("Text", param, "ServerPort", false);
            textBox_Message.DataBindings.Add("Text", param, "Message", false);

            param.Message = "Please Enter Message";
            //param.ServerIP = "192.168.16.15"; 
            //param.ServerPort = 8081;
        }

        private void button_Gonder_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(param.Message))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            TCPConnection();
        }

        private void TCPConnection()
        {
            try
            {
                TcpClient client = new TcpClient(param.ServerIP, param.ServerPort);

                NetworkStream nwStream = client.GetStream();

                SendMessage(nwStream, client);
                client.Close();
            }
            catch (Exception ex)
            {
                SqlOperations.SQLLog(param.KeepServerLog, "Client - ERROR", "", "", "", param.ServerIP, param.ServerPort, String.Concat("ERROR ", ex.Message));
                throw;
            }
            finally
            {
                SqlOperations.CloseConnection(param.KeepServerLog);
            }
        }

        private void SendMessage(NetworkStream nwStream, TcpClient client)
        {
            StringBuilder sb = new StringBuilder();

            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(param.Message);

            SqlOperations.SQLLog(param.KeepServerLog, "Client", param.Message, "", "", param.ServerIP, param.ServerPort, "");
            sb.AppendLine(param.Message);
            sb.AppendLine(String.Concat("Sending:", param.Message));

            if (nwStream.CanWrite)
            {
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            }
            else
            {
                sb.AppendLine("Error: Don't write stream ");
                SqlOperations.SQLLog(param.KeepServerLog, "Client - ERROR", "", "", "", param.ServerIP, param.ServerPort, "Error: Don't write stream");
            }
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            param.DataReceived = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            sb.AppendLine(String.Concat("Received : ", Encoding.ASCII.GetString(bytesToRead, 0, bytesRead)));

            param.Message = sb.ToString();
            SqlOperations.SQLLog(param.KeepServerLog, "Client", "", param.DataReceived, "", param.ServerIP, param.ServerPort, "");
        }
    }

    public class Parametre : INotifyPropertyChanged
    {
        //KeepServerLog is true : SQL write log; false, don't log
        private Boolean fKeepServerLog;
        public Boolean KeepServerLog
        {
            get { return fKeepServerLog; }
            set
            {
                if (fKeepServerLog == value)
                    return;
                fKeepServerLog = value;
                NotifyPropertyChanged("KeepServerLog");
            }
        }

        private String fMessage;
        public String Message
        {
            get { return fMessage; }
            set
            {
                if (fMessage == value)
                    return;
                fMessage = value;
                NotifyPropertyChanged("Message");
            }
        }

        private String fDataReceived;
        public String DataReceived
        {
            get { return fDataReceived; }
            set
            {
                if (fDataReceived == value)
                    return;
                fDataReceived = value;
                NotifyPropertyChanged("DataReceived");
            }
        }

        private String fServerIP;
        public String ServerIP
        {
            get { return fServerIP; }
            set
            {
                if (fServerIP == value)
                    return;
                fServerIP = value;
                NotifyPropertyChanged("ServerIP");
            }
        }

        private Int32 fServerPort;
        public Int32 ServerPort
        {
            get { return fServerPort; }
            set
            {
                if (fServerPort == value)
                    return;
                fServerPort = value;
                NotifyPropertyChanged("ServerPort");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}
