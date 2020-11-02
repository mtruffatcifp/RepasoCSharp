using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4_ToDoList
{
    class ToDoItem : INotifyPropertyChanged
    {
        private string content;
        private bool completed = false;
        private int position;

        public int Position
        {
            get => position;
            set
            {
                position = value;
                NotifyPropertyChanged();
            }
        }
        public string Content
        {
            get => content;
            set
            {
                content = value;
                NotifyPropertyChanged();
            }
        }
        public bool Completed
        {
            get => completed;
            set
            {
                completed = value;
                NotifyPropertyChanged();
            }
        }
        public string statusTodo()
        {
            if (Completed)
            {
                return "Completed!";
            }
            else
            {
                return "Pending...";
            }
        }
        public string ToDoDisplay => Position + " " + Content + "     " + statusTodo();

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
