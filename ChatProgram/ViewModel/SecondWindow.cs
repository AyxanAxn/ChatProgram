using ChatProgram.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChatProgram.ViewModel
{
    class SecondWindow
    {
        public SecondWindow(StartWindow sd,string nick)
        {
            s = sd;
            Nick = nick;
            SendCommand=new RelayCommand(Send);
        }

        public StartWindow s { get; set; }
        public string Nick { get; set; }
        public RelayCommand SendCommand { get; set; }
        public ChatWindow cw { get; set; }
        private void Send(object parameter = null)
        {
            if (/*parameter is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text) == false*/string.IsNullOrWhiteSpace(cw.TxtBox.Text) == false)
            {
                s.NotifyAllSubscribers($"{Nick} : {cw.TxtBox.Text}");
                cw.TxtBox.Text = "";
            }

        }
        private void Exit() {
            s.removeFrom(this);
            s.NotifyAllSubscribers($"{Nick} left from chat bro");
        }
    }
}
