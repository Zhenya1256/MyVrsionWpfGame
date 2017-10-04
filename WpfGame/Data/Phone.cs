using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.Data
{
    public class Phone 
    {
        private string title;
        private static int i = -1;
        // private string company;
        // private int price;
        public Phone(string title)
        {
            Title = title;
        }
        public Phone()
        {

        }


        private const int maxCountCommand = 16;

        public static int MaxCountCommand { get { return maxCountCommand; } }
        public string Title { get; set; }

        public override string ToString()
        {
            i++;
            if (i == 16)
            {
                i = 0;
            }

            return Coms()[i];
            //    return string.Format("-"+Title);

        }

        private static List<string> Coms()
        {
            List<string> list = new List<string>();
            list.Add("Деймос");
            list.Add("Зірка");
            list.Add("Говерла");
            list.Add("Фобос");

            list.Add("Галілей");
            list.Add("Ньютон");
            list.Add("Тітан");
            list.Add("Лебідь");

            list.Add("Калісто");
            list.Add("Кратер");
            list.Add("Лагранж");
            list.Add("Дніпро");


            list.Add("Волопас");
            list.Add("Церефей");
            list.Add("Квант");
            list.Add("Атом");



            return list;
        }



    }
}