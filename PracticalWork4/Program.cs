using System;
using System.Collections.Generic;

namespace PracticalWork4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int position = 1;
            DateTime datePos = DateTime.Now;
            ConsoleKeyInfo key;
            Note[] notesMassive = new Note[5] { null, null, null, null, null };

            Note note1 = new Note();
            note1.Name = "Приехать на пары";
            note1.Description = "С первой по пятую";
            note1.Date = DateTime.Now;
            Note note2 = new Note();
            note2.Name = "Купить хлеб";
            note2.Description = "Нужно купить дешёвый хлебушек в пятёрочке";
            note2.Date = DateTime.Now;
            Note note3 = new Note();
            note3.Name = "Поиграть в пк";
            note3.Description = "Развлекательная и образовательная игра Dota 2";
            note3.Date = DateTime.Now.AddDays(1);
            Note note4 = new Note();
            note4.Name = "Опять приехать на пары";
            note4.Description = "Не, ну тут хотя бы 3 пары всего";
            note4.Date = DateTime.Now.AddDays(2);
            Note note5 = new Note();
            note5.Name = "Спать";
            note5.Description = "Долгий и крепкий сон, ммм";
            note5.Date = DateTime.Now.AddDays(3);

            List<Note> Notes = new List<Note>() { note1, note2, note3, note4, note5 };
            while (true)
            {
                Console.WriteLine(datePos);
                Console.Clear();
                Console.WriteLine("Выбрана дата " + datePos.Day + "." + datePos.Month + "." + datePos.Year + "\t\tF1 для добавления заметки");
                int i = 1;
                notesMassive[1] = null;
                foreach (Note item in Notes)
                {
                    if (item.Date.Day == datePos.Day && item.Date.Month == datePos.Month && item.Date.Year == datePos.Year)
                    {
                        Console.Write("  ");
                        Console.WriteLine(item.Name);
                        notesMassive[i] = item;
                        i++;
                    }
                }
                Console.SetCursorPosition(0, position);
                Console.Write("->");
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.F1:
                        Note addNote = new Note();
                        addNote.Date = new DateTime();
                        Console.Clear();
                        Console.WriteLine("Введите название");
                        addNote.Name = Console.ReadLine();
                        Console.WriteLine("Введите описание");
                        addNote.Description = Console.ReadLine();
                        Console.WriteLine("Введите поочерёдно: день, месяц и год");
                        addNote.Date = addNote.Date.AddDays(int.Parse(Console.ReadLine()) - 1);
                        addNote.Date = addNote.Date.AddMonths(int.Parse(Console.ReadLine()) - 1);
                        addNote.Date = addNote.Date.AddYears(int.Parse(Console.ReadLine()) - 1);
                        Notes.Add(addNote);
                        break;
                    case ConsoleKey.Enter:
                        if (notesMassive[position] != null)
                        {
                            Info(notesMassive, position);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (position >= 2)
                            position = Arrow(position, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        if (position < i - 1)
                            position = Arrow(position, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        datePos = ChangeDate(-1, datePos);
                        position = 1;
                        break;
                    case ConsoleKey.RightArrow:
                        datePos = ChangeDate(1, datePos);
                        position = 1;
                        break;
                }



            }
        }

        static int Arrow(int position, int change)
        {
            position += change;
            return position;
        }

        static DateTime ChangeDate(int date, DateTime datePos)
        {
            datePos = datePos.AddDays(date);
            return datePos;
        }

        static void Info(Note[] notesMassive, int position)
        {
            Console.Clear();
            Console.WriteLine(notesMassive[position].Name);
            Console.WriteLine("-----------------------");
            Console.WriteLine("Описание:  " + notesMassive[position].Description);
            Console.WriteLine("Дата:  " + notesMassive[position].Date.Day + "." + notesMassive[position].Date.Month + "." + notesMassive[position].Date.Year);
            Console.ReadKey();
        }
    }
}
