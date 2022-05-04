using STINInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STINClient
{
    public partial class Form1 : Form
    {
        IWCFService server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChannelFactory<IWCFService> channelFactory =
                new ChannelFactory<IWCFService>("STINServiceEndpoint");
            server = channelFactory.CreateChannel();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            webBrowser1.DocumentText = Wrapper.Wrap("Čekám na odpověd serveru");
            new Thread(() =>
            {
                try
                {
                    webBrowser1.DocumentText = server.GetUserID();
                }
                catch (EndpointNotFoundException)
                {
                    webBrowser1.DocumentText = Wrapper.Wrap("Chyba při připojení k serveru");
                }
                catch (CommunicationException)
                {
                    webBrowser1.DocumentText = Wrapper.Wrap("Chyba při přijmu odpovědi/ztráta spojení");
                }
            }).Start();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = Wrapper.Wrap("Čekám na odpověd serveru");
            new Thread(() =>
            {
                try
                {
                    webBrowser1.DocumentText = server.GetCurrentRate();
                }
                catch (EndpointNotFoundException)
                {
                    webBrowser1.DocumentText = Wrapper.Wrap("Chyba při připojení k serveru");
                }
                catch (CommunicationException)
                {
                    webBrowser1.DocumentText = Wrapper.Wrap("Chyba při přijmu odpovědi/ztráta spojení");
                }
            }).Start();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TimeZone curTimeZone = TimeZone.CurrentTimeZone;
            TimeSpan offset = curTimeZone.GetUtcOffset(DateTime.Now);

            webBrowser1.DocumentText = Wrapper.Wrap("Čekám na odpověd serveru");
            new Thread(() =>
            {
                try
                {
                    webBrowser1.DocumentText = server.GetCurrentTime(offset);
                }
                catch (EndpointNotFoundException)
                {
                    webBrowser1.DocumentText = Wrapper.Wrap("Chyba při připojení k serveru");
                }
                catch (CommunicationException)
                {
                    webBrowser1.DocumentText = Wrapper.Wrap("Chyba při přijmu odpovědi/ztráta spojení");
                }
            }).Start();
        }
    }
}
