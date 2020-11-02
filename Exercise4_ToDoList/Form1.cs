using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise4_ToDoList
{
    public partial class Form1 : Form
    {
        BindingList<ToDoItem> todolist = new BindingList<ToDoItem>();
        ToDoItem currentEdit = null;
        public Form1()
        {
            InitializeComponent();
            listBox1.DoubleClick += new EventHandler(listBox1_DoubleClick);
            listBox1.DataSource = todolist;
            listBox1.DisplayMember = nameof(ToDoItem.ToDoDisplay);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (currentEdit == null)
            {
                AddItem(textBox1.Text);
                textBox1.Text = "";
            }

        }

        private void AddItem(string todoText)
        {
            ToDoItem todoitem = new ToDoItem
            {
                Position = todolist.Count + 1,
                Content = todoText
            };
            todolist.Add(todoitem);
        }

        private void Reorder()
        {
            for (int i = 0; i < todolist.Count; i++)
            {
                todolist[i].Position = (i + 1);
            }
        }

        private void Remove(ToDoItem todo)
        {
            todolist.Remove(todo);
            Reorder();
        }

        private void StartEditItem(ToDoItem todo)
        {
            currentEdit = todo;
            button3.Text = "Update ToDo Item";
            textBox1.Text = currentEdit.Content;

        }

        private void CompleteEditItem()
        {
            currentEdit.Content = textBox1.Text;
            button3.Text = "Edit Item";
            currentEdit = null;
            textBox1.Text = "";
        }

        private void CompleteItem(ToDoItem todo)
        {
            todo.Completed = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                ToDoItem todo = (ToDoItem)listBox1.SelectedItem;
                Remove(todo);
            }
        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                ToDoItem todo = (ToDoItem)listBox1.SelectedItem;
                CompleteItem(todo);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentEdit == null)
            {
                ToDoItem todo = (ToDoItem)listBox1.SelectedItem;
                StartEditItem(todo);
            }
            else
            {
                CompleteEditItem();
            }
        }
    }
}
