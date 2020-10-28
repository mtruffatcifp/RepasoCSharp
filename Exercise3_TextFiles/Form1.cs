using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise3_TextFiles
{
    public partial class Form1 : Form
    {
        static void main(string[] args)
        {
            

        }
        List<Person> people = new List<Person>();
        string filePath = @"C:\Users\Marco\source\repos\RepasoCSharp\Exercise3_TextFiles\person.csv";
        public Form1()
        {
            InitializeComponent();
            
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                Person newPerson = new Person();

                newPerson.FirstName = entries[0];
                newPerson.LastName = entries[1];
                newPerson.Age = entries[2];
                newPerson.Alive = entries[3];

                people.Add(newPerson);
            }

            foreach (var person in people)
            {
                string a = person.Alive.Equals("1") ? "alive" : "dead";
                listBox1.Items.Add($"{person.FirstName} {person.LastName} {person.Age} years, is {a}.");
            }
        }
        public void button1_Click(object sender, EventArgs e)
        {
            people.Add(new Person { FirstName = textBox1.Text, LastName = textBox2.Text, Age = numericUpDown1.Value.ToString(), Alive = checkBox1.Checked ? "1" : "0"});
            int i = people.Count - 1;
            string a = people[i].Alive.Equals("1") ? "alive" : "dead";
            listBox1.Items.Add($"{people[i].FirstName} {people[i].LastName} {people[i].Age} years, is {a}.");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> output = new List<string>();
            foreach (var person in people)
            {
                output.Add($"{person.FirstName},{person.LastName},{person.Age},{person.Alive}");
            }
            File.WriteAllLines(filePath, output);
        }
    }
}
