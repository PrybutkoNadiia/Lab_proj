using System;
using System.Collections.Generic;
using System.Linq;

namespace LabLibrary
{
    // Клас-контейнер, що реалізує інтерфейс для роботи з регістрами
    public class Text : ICaseManager
    {
        // Приватний список об'єктів класу MyString (це і є наш контейнер)
        private List<MyString> _lines = new List<MyString>();

        // Метод додавання нового рядка
        public void AddLine(string line)
        {
            _lines.Add(new MyString(line));
        }

        // Метод, який ми додаємо, щоб виправити помилку в Program.cs
        public List<MyString> GetLines()
        {
            return _lines;
        }

        // Реалізація інтерфейсу для переведення всього тексту у верхній регістр
        public void ToUpperCase()
        {
            foreach (var line in _lines)
            {
                line.Upper();
            }
        }

        // Пошук кількості рядків, у яких є задане слово/символ
        public int CountOccurrences(string searchStr)
        {
            int count = 0;
            foreach (var line in _lines)
            {
                if (line.Value.Contains(searchStr))
                {
                    count++;
                }
            }
            return count;
        }

        // Видалення всіх рядків, довжина яких дорівнює заданому числу
        public void RemoveByLength(int length)
        {
            _lines.RemoveAll(l => l.Length == length);
        }

        // Повне очищення контейнера
        public void Clear()
        {
            _lines.Clear();
        }
    }
}