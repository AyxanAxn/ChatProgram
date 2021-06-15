using ChatProgram.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChatProgram.ViewModel
{
    class StartWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<ListBox> addToList = new List<ListBox>();
        private List<SecondWindow> Viewers = new List<SecondWindow>();
        private ObservableCollection<string> chat = new ObservableCollection<string>();
        public RelayCommand JoinCommand { get; set; }
        private string _nick;
        public string Nick
        {
            get { return _nick; }
            set { _nick = value; OnPropertyChanged(); }
        }
        public StartWindow()
        {
            JoinCommand = new RelayCommand(Join, delegate { return string.IsNullOrWhiteSpace(Nick) == false; });
        }
        public void Join(object parameter = null)
        {
            adingToList();
            NotifyAllSubscribers($"{Nick} join to chat.");
            Nick = "";
        }
        public void NotifyAllSubscribers(string message)
        {
            chat.Add(message);
        }
        public void adingToList()
        {
            Viewers.Add(new SecondWindow(this, Nick));
            ChatWindow cw = new ChatWindow
            {
                DataContext = Viewers[Viewers.Count - 1]
            };
            addToList.Add(cw.ListBx);
            cw.Show();
        }
        public void removeFrom(SecondWindow sw) {
            Viewers.Remove(sw);
        }
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
