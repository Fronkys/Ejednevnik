using Microsoft.VisualBasic;
using Prac4.Ejednevnik;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Prac4.Ejednevnik
{
    internal class Program
    {
        private static void Main()
        {
            DateTime bbb = new DateTime(2022, 9, 25);
            Telo daybefore = new Telo();
            daybefore.Name = "Сходить на пары";
            daybefore.description = "Написать контрольную на 5";
            daybefore.data = new DateTime(2022, 9, 25);

            Telo day2 = new Telo();
            day2.Name = "Сходить на пары";
            day2.description = "Написать контрольную на 5";
            day2.data = new DateTime(2022, 9, 26);

            Telo day = new Telo();
            day.Name = "Купить продукты";
            day.description = "Молоко, хлеб, сахар и макароны ";
            day.data = new DateTime(2022, 9, 26);

            Telo dayafter = new Telo();
            dayafter.Name = "Сходить в парк";
            dayafter.description = "Встретиться с друзьями и хорошо провести время";
            dayafter.data = new DateTime(2022, 9, 27);

            List<Telo> info = new List<Telo>();
            info.Add(daybefore);
            info.Add(day);
            info.Add(day2);
            info.Add(dayafter);

            int position = 1;
            ConsoleKeyInfo clavisha = Console.ReadKey();

            while (clavisha.Key != ConsoleKey.Escape)
            {
                List<Telo> koil = info.Where(x => x.data.Date == bbb.Date).ToList();
                int ggg = koil.Count();
                ggg = ggg + 1;
                if ((clavisha.Key == ConsoleKey.UpArrow) && (ggg != 0))
                {
                    position--;
                    if (position == 0)
                    {
                        position = ggg;
                    }
                }
                if ((clavisha.Key == ConsoleKey.DownArrow) && (ggg != 0))
                {
                    position++;
                    if (position == ggg + 1)
                    {
                        position = 1;
                    }
                }


                Console.Clear();
                Console.WriteLine(bbb);

                foreach (var item in koil)
                {

                    Console.WriteLine(" " + item.Name);
                    for (int i = 0; i < position; i++)

                    {
                        if (clavisha.Key == ConsoleKey.Enter)
                        {
                            SubMenu(koil[i]);
                        }
                    }
                }
                if (clavisha.Key == ConsoleKey.F1)

                    info.Add(dop());

                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                clavisha = Console.ReadKey();
                if (clavisha.Key == ConsoleKey.LeftArrow)
                {
                    bbb = bbb.AddDays(-1);

                }
                if (clavisha.Key == ConsoleKey.RightArrow)
                {
                    bbb = bbb.AddDays(+1);
                }
            }
            static void SubMenu(Telo koil)
            {
                Console.Clear();
                Console.WriteLine("Ваши задачи на сегодня");

                Console.WriteLine(' ' + koil.description);


            }

            static Telo dop()
            {
                Console.Clear();
                Telo newzametka = new Telo();
                Console.WriteLine("Введите дату, в которую вы хотите добавить заметку");
                string input = Console.ReadLine();
                string[] split = input.Split('.');

                double day = Double.Parse(split[0]);
                double month = Double.Parse(split[1]);
                double year = Double.Parse(split[2]);
                int daay = Convert.ToInt32(day);
                int moonth = Convert.ToInt32(month);
                int yeaar = Convert.ToInt32(year);

                Console.WriteLine("Введите имя заметки");
                newzametka.Name = Console.ReadLine();

                Console.WriteLine("Введите описание заметки");
                newzametka.description = Console.ReadLine();
                newzametka.data = new DateTime(daay, moonth, yeaar);
                List<Telo> addinfo = new List<Telo>();
                addinfo.Add(newzametka);
                Console.Clear();
                return newzametka;
            }
        }
    }
}









