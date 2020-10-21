using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2_DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a date: (dd/MM/yyyy)");
            var current = DateTime.Now;
            DateTime datetime = DateTime.Parse(Console.ReadLine());
            var diff = current - datetime;
            Console.WriteLine("Han pasado " + diff.Days + " dias desde " + datetime.ToShortDateString());

            Console.WriteLine("Write a time: (H:mm)");
            DateTime timetime = DateTime.Parse(Console.ReadLine());
            var difftime = current - timetime;
            if (current.Ticks < timetime.Ticks)
            {
                difftime = TimeSpan.FromDays(1) + (current - timetime);
            }

            Console.WriteLine("Han pasado " + difftime.Hours + " horas y " + difftime.Minutes + " minutos desde las " + timetime.ToShortTimeString());

            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
    }
}
