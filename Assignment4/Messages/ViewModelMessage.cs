using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace Assignment3.Messages
{
    public class ViewModelMessage : MessageBase
    {
        public string FirstText { get; set; }
        public string LastText { get; set; }
        public string EmailText { get; set; }
    }

    public class MessageData : MessageBase
    {
        public string FirstContext { get; set; }
        public string LastContext { get; set; }
        public string EmailContext { get; set; }
    }

    public class SelectedData: MessageBase
    {
        public string SelectedFirst { get; set; }
        public string SelectedLast { get; set; }
        public string SelectedEmail { get; set; }
    }
}
