using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLab10;

namespace HashTable
{
    public class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        public Point<T>[] table;
        public int Capacity => table.Length;
        public int count;
        public int Count => count;


        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="length"></param>
        public MyHashTable(int length)
        {
            table = new Point<T>[length];
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public MyHashTable() { }

        public MyHashTable(params T[] coll)
        {
            if (coll == null)
                throw new Exception("Пустой список");
            else if (coll.Length == 0)
                throw new Exception("Нет элементов в списке");
            else
            {
                table = new Point<T>[coll.Length];
                for (int i = 0; i < coll.Length; i++)
                {
                    T newData = (T)coll[i].Clone();
                    AddItem(newData);
                }
            }
        }

        /// <summary>
        /// Печать таблицы
        /// </summary>
        public void PrintTable()
        {
            if (count <= 0 || table == null)
                throw new Exception("Таблица пустая");
            else
            {
                for (int i = 0; i < table.Length; i++)
                {
                    Console.WriteLine($"{i + 1}-ый элемент: ");
                    if (table[i] != null)
                    {
                        Console.WriteLine("   " + table[i].Data);

                        if (table[i].Next != null) // если цепочка не пустая
                        {
                            Point<T> curr = table[i].Next; //дальше по цепочке
                            while (curr != null) // пока не дойдем до конца цепочки
                            {
                                Console.WriteLine("   " + curr.Data);
                                curr = curr.Next;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Добавление элемента в таблицу
        /// </summary>
        /// <param name="data"></param>
        public int AddItem(T data)
        {
            if (table != null)
            {
                int index = GetIndex(data); //индекс в таблице
                if (table[index] == null) // в ячейке таблицы нет цепочки
                {
                    table[index] = new Point<T>(data); // добавление элемента
                    count++;
                    return 1;
                }
                else
                {
                    Point<T>? curr = table[index]; // "указатель" стоит на первом элементе в цепочке
                    while (curr.Next != null)
                    {
                        if (curr.Data.Equals(data)) // проверка на существование добавляемого элемента
                            return -1; //  такой элемент уже есть
                        curr = curr.Next;
                    }
                    curr.Next = new Point<T>(data); // создаем новый элемент
                    curr.Next.Prev = curr; // связывываем новый элемент с предыдущим 
                    count++;
                    return 1;
                }
            }
            return 0;
        }

        public Point<T>? FindName(string name)
        {
            if (table == null)
            {
                return null;
            }
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    if (table[i].Data is MusicalInstrument m && m.Name.Equals(name))
                        return table[i];
                    else if (table[i].Next != null)
                    {
                        Point<T>? curr = table[i].Next;
                        while (curr != null)
                        {
                            if (curr.Data is MusicalInstrument m1 && m1.Name.Equals(name))
                                return curr;
                            curr = curr.Next;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Поиск элемента в таблице
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int SearchItem(string name)
        {
            if (table == null)
            {
                return 0;
            }
            else
            {
                Point<T> item = FindName(name);
                if (item != null)
                {
                    int index = GetIndex(item.Data);

                    if (table[index] == null) //если цепочка пустая, искомого элемента нет
                        return -1;
                    else if (table[index].Data.Equals(item.Data)) //элемент найден
                        return 1;
                    else // идем по цепочке
                    {
                        Point<T> curr = table[index];
                        while (curr != null)
                        {
                            if (curr.Data.Equals(item.Data))
                                return 1;
                            curr = curr.Next;
                        }

                    }

                }
                return -1;
            }
        }

        /// <summary>
        /// Удаление элемента из таблицы
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int RemoveItem(string name)
        {
            if (table == null)
            {
                return 0;
            }
            else
            {
                Point<T> item = FindName(name);
                if (item != null)
                {
                    Point<T>? curr;
                    int index = GetIndex(item.Data);
                    if (table[index] == null) // пустая цепочка
                        return -1;
                    else if (table[index].Data.Equals(item.Data)) // если первый элемент в цепочке - искомый
                    {
                        if (table[index].Next == null) // один элемент в цепочке
                            table[index] = null; //"обнуляем" полностью цепочку
                        else // если элементов несколько
                        {
                            table[index] = table[index].Next; //ставим ссылку на слудющий эл-т
                            table[index].Prev = null;
                        }
                        count--;
                        return 1;
                    }
                    else // если искомый элемент в середине/конце цепочки
                    {
                        curr = table[index];
                        while (curr != null) //идем до конца цепочки
                        {
                            if (curr.Data.Equals(item.Data))
                            {
                                Point<T> prev = curr.Prev;
                                Point<T> next = curr.Next;
                                prev.Next = next;
                                curr.Prev = null;
                                if (next != null) //если такой элемнт сущ-т
                                    next.Prev = prev;
                                return 1;
                            }
                            curr = curr.Next;
                        }
                    }
                }
                return -1;
            }
        }

        /// <summary>
        /// Метод считает индекс элемента в таблице
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }

        /// <summary>
        /// Клонирование хэш-таблицы
        /// </summary>
        /// <param name="hashTable"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public MyHashTable<T> CloneTable(MyHashTable<T> hashTable)
        {
            MyHashTable<T> clonedTable;
            if (table == null)
                return null;
            else
            {
                clonedTable = new MyHashTable<T>(hashTable.Capacity);
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i] != null)
                    {
                        T clonedData = (T)table[i].Data.Clone();
                        clonedTable.AddItem(clonedData);

                        if (table[i].Next != null) // если цепочка не пустая
                        {
                            Point<T> curr = table[i].Next; //дальше по цепочке
                            while (curr != null) // пока не дойдем до конца цепочки
                            {
                                clonedData = (T)curr.Data.Clone();
                                clonedTable.AddItem(clonedData);
                                curr = curr.Next;
                            }
                        }
                    }
                }
            }
            return clonedTable;
        }

        /// <summary>
        /// Изменение первого ненулевого элемента для проверки клонирование 
        /// </summary>
        /// <param name="newData"></param>
        public void ChangeItem(T newData)
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    table[i].Data = newData;
                    break;
                }
            }
        }
    }
}
