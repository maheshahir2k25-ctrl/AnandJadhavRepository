using DependencyProperties.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DependencyProperties.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private string _bannerText;

        public MainViewModel()
        {
            // Initial Data
            BannerText = "Warning: System update required.";

            // Logic: When command runs, clear the text
            ClearBannerCommand = new RelayCommand(Clear);

            // Logic: Reset text for testing
            ResetCommand = new RelayCommand(ErrorText);

            
        }

        public void Clear(object obj)
        {
            BannerText = string.Empty;
        }
        public void ErrorText(object obj)
        {
            BannerText = "New Error Detected!";
        }

        public string BannerText
        {
            get { return _bannerText; }
            set { _bannerText = value; OnPropertyChanged(); }
        }

        public ICommand ClearBannerCommand { get; }
        public ICommand ResetCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
       

    }
}
