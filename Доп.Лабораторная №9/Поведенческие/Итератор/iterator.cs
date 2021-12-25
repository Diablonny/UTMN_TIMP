using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp8
{
    class SimpleSet<T> : IEnumerator<T>
    {
        int index; //какой элемент нужно возвращать
        readonly T[] storage;
        public SimpleSet(params T[] args)
        {
            storage = args;
            Reset();
        }

        public T Current => storage[index]; //возвращаем элемент хранилища

        object IEnumerator.Current => Current;
        public bool MoveNext() => --index >= 0; //метод узнает, дошли ли мы до конца хранилища
        public void Reset() => index = storage.Length; //обнуление значения индекса, чтобы выводить элементы с начала
                                              
        //изменяя значения переменной index мы можем менять способ, как будет выводится наш массив
        //допустим --index >= 2 и storage.Lenght - 1 выведет 5 4 3
        public void Dispose() { } 
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6 };

            SimpleSet<int> set = new(array);

            set.Reset();
            while (set.MoveNext()) Console.Write($"{set.Current} "); 
            //выведет 6 5 4 3 2 1

        }
    }
}
