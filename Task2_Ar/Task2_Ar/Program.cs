using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2_Ar
{
    public static class Str
    {   // метод расширения для создания произвольных строк
        public static string Random(this string chars, int length = 4)
        {
            var randomString = new StringBuilder();
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                randomString.Append(chars[random.Next(chars.Length)]);
                Thread.Sleep(10); // для создания разных строк
            }
            return randomString.ToString();
        }
    }


    class Program
    {
        
        static void Main(string[] args)
        {
           // int _start = -4; //начальный индекс массива
           // int _end =2;    //конечный индекс массива -1

           // // создание массива string -ов с заданными границами индексов
           // var array = new CustomArray<string>(_start, _end);
           // //заполнение массива
           //// var rnd = new Random();    // для int
           // for (int i = _start; i < _end; i++)
           // {
           //     array[i] = "ABCDEFGHIJKLMNOP".Random();   //rnd.Next(0, 10);
           // }

           // Console.WriteLine("Array lenght: " + array.Lenght + "\n");

           // foreach (var n in array) {
           //     Console.WriteLine($"array element: {n.ToString()}");
           // }
           // Console.WriteLine("\n");

           // //Range генерирует последовательность целых чисел - начиная со значения, переданного в первом арг., протяженностью второго арг.
           // Console.WriteLine(string.Join("\n", Enumerable.Range(_start, (_end - _start)).Select(x => string.Format("index:{0} - value:{1}", x, array[x]))));




            Console.WriteLine();
            CustomArray<int>  arTests = new CustomArray<int>(-4, 2);
            for (int i = arTests.Start; i < arTests.End; i++)
            {
                arTests[i] = i*2;
            }

            Console.WriteLine("Array lenght: " + arTests.Lenght + "\n");

            foreach (var n in arTests)
            {
                Console.WriteLine($"array element: {n.ToString()}");
            }
            Console.WriteLine("\n");
            //Range генерирует последовательность целых чисел - начиная со значения, переданного в первом арг., протяженностью второго арг.
            Console.WriteLine(string.Join("\n", Enumerable.Range(arTests.Start, (arTests.End - arTests.Start)).Select(x => string.Format("index:{0} - value:{1}", x, arTests[x]))));

           // CustomArray<int> arTests1 = new CustomArray<int>(-4, -8);
            Console.ReadKey();




        }
    }

    public class CustomArray<T> : IEnumerable<T>
    {
        private int start;
        public int Start {
            get
            {
                return start;
            }

            set
            {               
                start = value;
            }
        }


        private int end;

        public int End
        {
            get
            {
                return end;
            }

            set
            {
                if (value <= start) throw new WrongIndexExeption("Invalid index");
                end = value;
            }
        }

        T[] array;

        public int Lenght { get { return array.Length; } }       
       
        public CustomArray(int start, int end)
        {
            if (end <= start) throw new WrongIndexExeption("Invalid index");

            this.start = start;
            this.end = end+1;

            var len = Math.Abs(end +1 - start); // for negative index
            array = new T[len];
        }

        //индексатор
        public T this[int index]
        {

            get
            {       //4-4=0,  5-4=1 ...-1 0 1  -1--1=0
                if (index >= start || index <= end) return array[index - start];
                else throw new WrongIndexExeption("Invalid index");
            } 
            set
            {
                if (index >= start || index <= end) array[index - start] = value;
                else throw new WrongIndexExeption("Invalid index");

            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
