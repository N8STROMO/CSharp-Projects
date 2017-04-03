using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace Chat_Bot
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        StreamReader reader;
        StreamWriter writer;

        readonly string chatMessagePrefix;
        readonly string userName;
        readonly string password;
        readonly string chatCommandID;

        public Form1()
        {
            InitializeComponent();
            Reconnect();
        }

        private void Reconnect()
        {
            tcpClient = new TcpClient(); //Takes in IP adress and port 
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());

            writer.WriteLine(""); //send username and password

            writer.WriteLine(""); //select channel to join
            writer.Flush();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!tcpClient.Connected)
            {
                Reconnect();
            }

            if (tcpClient.Available > 0 || reader.Peek() >= 0)
            {
                var message = reader.ReadLine();

                var iPrefix = message.IndexOf(""); 
                if(iPrefix > 0)
                {
                    var command = message.Substring(iPrefix + 1);
                    if(message.Contains(chatCommandID))
                    {
                        var iBang = command.IndexOf("!");
                        if(iBang > 0)
                        {
                            var speaker = command.Substring(0, iBang);
                            var chatMessage = message.Substring(chatMessagePrefix.Length + 2);

                            ReceiveMessage(speaker, chatMessage);
                        }
                    }
                }

            }
        }

        void ReceiveMessage(string speaker, string message)
        {
            Chat.Text += $"\r\n {speaker} : {message}";
        }

        void SendMessage(string message)
        {
            writer.WriteLine(message);
            writer.Flush();
        }
    }
}