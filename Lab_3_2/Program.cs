using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTreeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== 1. WORKING WITH ARRAYS AND COLLECTIONS (Variant 4) ===");

            Circle c1 = new Circle("Red", "Black", 5.0);
            Circle c2 = new Circle("Blue", "White", 3.0);
            Circle c3 = new Circle("Green", "Yellow", 7.0);

            // 1. Array
            Circle[] circleArray = new Circle[] { c1, c2 };
            Console.WriteLine("\n-- Array --");
            circleArray[0].Radius = 5.5; // Update
            foreach (var item in circleArray)
                item.DisplayInfo();

            // 2. Non-generic collection (ArrayList)
            ArrayList arrayList = new ArrayList();
            arrayList.Add(c1);
            arrayList.Add(c2);
            arrayList.Remove(c1); // Removal
            Console.WriteLine("\n-- Non-generic Collection (ArrayList) --");
            foreach (object obj in arrayList)
            {
                Circle item = (Circle)obj; // Unboxing / Casting
                item.DisplayInfo();
            }

            // 3. Generic collection (List<T>)
            List<Circle> circleList = new List<Circle> { c1, c2, c3 };
            Console.WriteLine("\n-- Generic Collection (List<Circle>) --");
            foreach (var item in circleList)
                item.DisplayInfo();

            Console.WriteLine("\n=== 2. GENERIC BINARY TREE (Preorder Traversal) ===");

            BinaryTree<Circle> circleTree = new BinaryTree<Circle>();
            circleTree.Add(c1);
            circleTree.Add(c2);
            circleTree.Add(c3);

            Console.WriteLine("\nTree traversal in Preorder:");
            foreach (var circle in circleTree)
            {
                Console.WriteLine(circle);
            }

            // Using custom IComparer<T> (sorting by area)
            BinaryTree<Circle> treeByArea = new BinaryTree<Circle>(new CircleAreaComparer());
            treeByArea.Add(c1);
            treeByArea.Add(c2);
            treeByArea.Add(c3);

            Console.WriteLine("\nTree traversal using IComparer<T> (by Area):");
            foreach (var circle in treeByArea)
            {
                Console.WriteLine(circle);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}