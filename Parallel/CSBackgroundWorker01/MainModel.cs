using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CSBackgroundWorker01
{
    class MainModel : INotifyPropertyChanged
    {
        public MainModel()
        {
            _BackgroundWorker = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true,
            };
            _BackgroundWorker.DoWork += OnBackgroundWorker_DoWork;
            _BackgroundWorker.RunWorkerCompleted += OnBackgroundWorker_RunWorkerCompleted;
            _BackgroundWorker.ProgressChanged += OnBackgroundWorker_ProgressChanged;
        }

        private void OnBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressPercent = e.ProgressPercentage;
        }

        private void OnBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsWorking = false;
        }

        private void OnBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker aWorker = sender as BackgroundWorker;
            for (int i = 0; i < 100; i++)
            {
                if (aWorker.CancellationPending) return;
                aWorker.ReportProgress(i);
                Thread.Sleep(200);
            }
            aWorker.ReportProgress(100);
        }

        public void Start()
        {
            IsWorking = true;
            ProgressPercent = 0;
            _BackgroundWorker.RunWorkerAsync();
        }
        public void Stop()
        {
            _BackgroundWorker.CancelAsync();
            IsWorking = false;
        }

        public bool IsWorking { get { return _IsWorking; } set { if (_IsWorking == value) return; _IsWorking = value; OnPropertyChanged(nameof(IsWorking)); } }
        private bool _IsWorking = false;

        public int ProgressPercent { get { return _ProgressPercent; } set { if (_ProgressPercent == value) return; _ProgressPercent = value; OnPropertyChanged(nameof(ProgressPercent)); } }
        private int _ProgressPercent = 0;

        private BackgroundWorker _BackgroundWorker;

        private void OnPropertyChanged([CallerMemberName]string aPropertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
