using System;
using System.Collections.Generic;

namespace WeatherListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BidirectionalList mainList = new BidirectionalList();
            string path = "weather_archive.json";

            mainList.AddFirst(new WeatherData(WeatherType.Windy, 11.2, true));
            mainList.AddFirst(new WeatherData(WeatherType.Sunny, 24.5, false));
            mainList.AddFirst(new WeatherData(WeatherType.Rainy, 14.8, true));
            mainList.AddFirst(new WeatherData(WeatherType.Cloudy, 15.0, false));
            mainList.AddFirst(new WeatherData(WeatherType.Snowy, -3.5, true));
            mainList.AddFirst(new WeatherData(WeatherType.Foggy, 8.0, true));

            while (true)
            {
                Console.WriteLine("\n================ КОНСОЛЬНЕ МЕНЮ ================");
                Console.WriteLine("1. Вивести весь список у вигляді таблиці");
                Console.WriteLine("2. Додати новий елемент на початок списку");
                Console.WriteLine("3. Видалити елемент за вказаним індексом");
                Console.WriteLine("4. Змінити дані елемента за індексом (Індексатор)");
                Console.WriteLine("5. Виконати пошук за критерієм (Дощ та Temp < 15°C)");
                Console.WriteLine("6. Розділити список на 3 частини за температурою");
                Console.WriteLine("7. Зберегти дані у файл (Серіалізація)");
                Console.WriteLine("8. Завантажити дані з файлу (Десеріалізація)");
                Console.WriteLine("9. Відсортувати список за зростанням температури (Bubble Sort)");
                Console.WriteLine("0. Завершити роботу програми");
                Console.Write("Ваш вибір: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (input)
                    {
                        case "1":
                            PrintAsTable(mainList, "ПОТОЧНІ ДАНІ СПИСКУ");
                            break;

                        case "2":
                            WeatherData data = EnterWeatherData();
                            mainList.AddFirst(data);
                            Console.WriteLine("Елемент додано успішно.");
                            PrintAsTable(mainList, "ОНОВЛЕНИЙ СПИСОК");
                            break;

                        case "3":
                            Console.Write($"Введіть індекс для видалення (0 - {mainList.Length - 1}): ");
                            int delIdx = int.Parse(Console.ReadLine());
                            mainList.RemoveAt(delIdx);
                            Console.WriteLine("Елемент видалено.");
                            PrintAsTable(mainList, "ОНОВЛЕНИЙ СПИСОК");
                            break;

                        case "4":
                            Console.Write($"Введіть індекс для редагування (0 - {mainList.Length - 1}): ");
                            int modIdx = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введіть нові значення для цього вузла:");
                            WeatherData modData = EnterWeatherData();
                            mainList[modIdx] = modData; 
                            Console.WriteLine("Дані успішно оновлено.");
                            PrintAsTable(mainList, "ОНОВЛЕНИЙ СПИСОК");
                            break;

                        case "5":
                            var search = mainList.SearchByCriteria();
                            Console.WriteLine("=== РЕЗУЛЬТАТИ ПОШУКУ (Дощ, Temp < 15°C) ===");
                            if (search.Count == 0) Console.WriteLine("Збігів не знайдено.");
                            else
                            {
                                PrintTableHeader();
                                foreach (var item in search) Console.WriteLine(item);
                            }
                            break;

                        case "6":
                            Console.Write("Введіть температурний поріг для розподілу: ");
                            double limit = double.Parse(Console.ReadLine());
                            var (below, equal, above) = mainList.SplitByTemperature(limit);

                            PrintAsTable(below, $"Температура нижче {limit}°C");
                            PrintAsTable(equal, $"Температура рівно {limit}°C");
                            PrintAsTable(above, $"Температура вище {limit}°C");
                            break;

                        case "7":
                            mainList.Serialize(path);
                            Console.WriteLine($"Успішно збережено у файл: {path}");
                            break;

                        case "8":
                            mainList = BidirectionalList.Deserialize(path);
                            Console.WriteLine("Дані успішно відновлено з файлу.");
                            PrintAsTable(mainList, "СПИСОК ПІСЛЯ ДЕСЕРІАЛІЗАЦІЇ");
                            break;

                        case "9":
                            mainList.SortByTemperature();
                            Console.WriteLine("Список успішно відсортовано за допомогою Bubble Sort (Бульбашкою)!");
                            PrintAsTable(mainList, "ВІДСОРТОВАНИЙ СПИСОК");
                            break;
                        
                        case "0":
                            Console.WriteLine("Програма завершила роботу.");
                            return;

                        default:
                            Console.WriteLine("Помилка! Невідома команда меню.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ПОМИЛКА]: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        static void PrintAsTable(BidirectionalList list, string title)
{
    Console.WriteLine($"\n--- {title} (Елементів: {list.Length}) ---");
    if (list.Length == 0)
    {
        Console.WriteLine("Список порожній.");
        return;
    }

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    PrintTableHeader();
    Console.ResetColor(); 

    int i = 0;
    foreach (var item in list)
    {
        Console.WriteLine($"[{i}] {item}");
        i++;
    }

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine(new string('-', 55));
    Console.ResetColor();
}

static void PrintTableHeader()
{
    Console.WriteLine(new string('-', 55)); // Верхня лінія таблиці
    Console.WriteLine($"{"Індекс",-5} | {"Тип Погоди",-10} | {"Температура",-11} | {"Опади (Є/Немає)",-15}");
    Console.WriteLine(new string('-', 55)); // Лінія під назвами колонок
}

        static WeatherData EnterWeatherData()
        {
            WeatherType type;
            while (true)
            {
                Console.Write("Тип погоди (Sunny, Rainy, Cloudy, Snowy, Foggy, Windy): ");
                if (Enum.TryParse(Console.ReadLine(), true, out type)) break;
                Console.WriteLine("Неправильний тип! Спробуйте ще раз.");
            }

            double temp;
            while (true)
            {
                Console.Write("Температура (дійсне число): ");
                if (double.TryParse(Console.ReadLine(), out temp)) break;
                Console.WriteLine("Помилка! Введіть число у правильному форматі.");
            }

            bool precip;
            while (true)
            {
                Console.Write("Наявність опадів (true / false): ");
                if (bool.TryParse(Console.ReadLine(), out precip)) break;
                Console.WriteLine("Помилка! Дозволено лише значення 'true' або 'false'.");
            }

            return new WeatherData(type, temp, precip);
        }
    }
}
