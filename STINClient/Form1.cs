using STINInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
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

            webBrowser1.DocumentText = server.GetUserID();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            server.GetCurrentTime(TimeZone.CurrentTimeZone);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
