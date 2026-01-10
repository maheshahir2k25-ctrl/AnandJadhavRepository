using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DependencyProperties
{
    /// <summary>
    /// Interaction logic for WindowCounter.xaml
    /// </summary>
    public partial class WindowCounter : Window, INotifyPropertyChanged
    {
        CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        public WindowCounter()
        {
            InitializeComponent();
            this.DataContext = this;
            UpdateCounterAsync(_cancellationTokenSource.Token);

        }

        public async Task UpdateCounterAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(5000, cancellationToken);
                    Counter++;
                    if (Counter == 100)
                        Counter = 0;
                }
            }
            catch (TaskCanceledException)
            {
                // This exception is expected when the delay is cancelled.
                // We can safely ignore it or log that the task stopped.
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _counter = 0;

        public int Counter
        {
            get { return _counter; }
            set { _counter = value; OnPropertyChanged(); }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
            }
        }
    }
}
