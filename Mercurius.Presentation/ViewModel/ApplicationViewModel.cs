using System.Collections.Generic;
using System.ComponentModel;

namespace Mercurius.Presentation.ViewModel
{
    public class ViewModelMessage
    {
        public string SendersName { get; set; }
        public string Content     { get; set; }
        public string Time        { get; set; }
    }

    public class ViewModelChat
    {

        public string InterlocutorName { get; set; }
        public string PhoneNumber      { get; set; }
        public int    NumberOfMessages { get; set; }

        public IEnumerable<ViewModelMessage> Messages { get; set; }
    }

    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ViewModelChat _activeChat;
        private IList<ViewModelChat> _allChats;

        public ViewModelChat ActiveChat
        {
            get
            {
                return _activeChat;
            }
            set
            {
                _activeChat = value;
                NotifyPropertyChanged("ActiveChat");
            }
        }
        public IList<ViewModelChat> AllChats
        {
            get
            {
                return _allChats;
            }
            set
            {
                _allChats = value;
                NotifyPropertyChanged("AllChats");
            }
        }

        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}