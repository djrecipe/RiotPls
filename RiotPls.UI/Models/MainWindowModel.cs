using GalaSoft.MvvmLight.Command;
using RiotPls.UI.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace RiotPls.UI.Models
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ApplicationSettingsPage pageApplicationSettings = new ApplicationSettingsPage();
        private object _MainFrameContent = null;
        public object MainFrameContent
        {
            get
            {
                return this._MainFrameContent;
            }
            private set
            {
                this._MainFrameContent = value;
                this.OnPropertyChanged("MainFrameContent");
            }
        }
        public ICommand CommandShowSettingsPage { get; private set;}
        private WindowPages _CurrentPage = WindowPages.None;
        public WindowPages CurrentPage
        {
            get
            {
                return this._CurrentPage;
            }
            set
            {
                this._CurrentPage = value;
                this.UpdateFrame();
            }
        }
        public MainWindowModel()
        {
            this.CommandShowSettingsPage = new RelayCommand(this.ShowSettingsPage);
        }
        private void ShowSettingsPage()
        {
            this.CurrentPage = WindowPages.Settings;
        }
        private void UpdateFrame()
        {
            switch(this.CurrentPage)
            {
                case WindowPages.None:
                    this.MainFrameContent = null;
                    break;
                case WindowPages.Settings:
                    this.MainFrameContent = this.pageApplicationSettings;
                    break;
            }
        }
        private void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
