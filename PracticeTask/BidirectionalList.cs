using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WeatherListApp
{
    public class BidirectionalList : IEnumerable<WeatherData>
    {
        private ListNode head; 
        private ListNode tail; 
        private int count;     

        public int Length => count;

        public void AddFirst(WeatherData value)
        {
            ListNode newNode = new ListNode(value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index), "Вказаний індекс поза межами списку!");

            ListNode current = GetNodeAt(index);

            if (current.Previous != null)
                current.Previous.Next = current.Next;
            else
                head = current.Next; 

            if (current.Next != null)
                current.Next.Previous = current.Previous;
            else
                tail = current.Previous; 

            count--;
        }

        public WeatherData this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Вказаний індекс поза межами списку!");
                return GetNodeAt(index).Value;
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Вказаний індекс поза межами списку!");
                GetNodeAt(index).Value = value;
            }
        }

        private ListNode GetNodeAt(int index)
        {
            ListNode current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public IEnumerator<WeatherData> GetEnumerator()
        {
            ListNode current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public (BidirectionalList below, BidirectionalList equal, BidirectionalList above) SplitByTemperature(double threshold)
        {
            var below = new BidirectionalList();
            var equal = new BidirectionalList();
            var above = new BidirectionalList();

            ListNode current = tail;
            while (current != null)
            {
                if (current.Value.Temperature < threshold)
                    below.AddFirst(current.Value);
                else if (Math.Abs(current.Value.Temperature - threshold) < 0.001)
                    equal.AddFirst(current.Value);
                else
                    above.AddFirst(current.Value);

                current = current.Previous;
            }

            return (below, equal, above);
        }

        public List<WeatherData> SearchByCriteria()
        {
            List<WeatherData> results = new List<WeatherData>();
            ListNode current = head;
            while (current != null)
            {
                if (current.Value.Type == WeatherType.Rainy && current.Value.Temperature < 15.0)
                {
                    results.Add(current.Value);
                }
                current = current.Next;
            }
            return results;
        }

        public void Serialize(string filePath)
        {
            List<WeatherData> temporaryList = new List<WeatherData>();
            foreach (var item in this)
            {
                temporaryList.Add(item);
            }
            string json = JsonSerializer.Serialize(temporaryList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static BidirectionalList Deserialize(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Файл збереження не знайдено!");

            string json = File.ReadAllText(filePath);
            var dataList = JsonSerializer.Deserialize<List<WeatherData>>(json);

            BidirectionalList newList = new BidirectionalList();
            if (dataList != null)
            {
                for (int i = dataList.Count - 1; i >= 0; i--)
                {
                    newList.AddFirst(dataList[i]);
                }
            }
            return newList;
        }
public void SortByTemperature()
{
    if (head == null || head.Next == null) return;

    bool swapped;
    do
    {
        swapped = false;
        ListNode current = head;

        while (current.Next != null)
        {
            if (current.Value.Temperature > current.Next.Value.Temperature)
            {
                WeatherData temp = current.Value;
                current.Value = current.Next.Value;
                current.Next.Value = temp;

                swapped = true;
            }
            current = current.Next;
        }
    } while (swapped);
}
    }
}
