using System;
using System.Threading;
using System.Windows.Forms;

namespace CSThread08
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
            _WorkThread = new Thread(WorkThread);
        }
        private Thread _WorkThread;

        private delegate void ShowLogDelegate(string aText);
        private void ShowLog(string aText)
        {
            lstLog.Items.Add(aText);
            //if (lstLog.InvokeRequired)
            //{
            //    lstLog.Invoke(new ShowLogDelegate(ShowLog), aText);
            //}
            //else
            //{
            //    lstLog.Items.Add(aText);
            //}
        }

        private int _Count = 0;
        private volatile bool _StopRequest = false;
        private void WorkThread()
        {
            while (!_StopRequest)
            {
                _Count++;
                ShowLog($"Count is {_Count}");
                Thread.Sleep(500);
            }
            ShowLog("Work thread ending...");
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            _StopRequest = false;
            _WorkThread.Start();
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            _StopRequest = true;
        }
    }
}
