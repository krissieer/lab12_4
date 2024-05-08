using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLibraryLab10;
using HashTable;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lab12____4
{
    public class MyCollection<T> : MyHashTable<T>, IEnumerable<T>, ICollection<T> where T : IInit, ICloneable, new()
    {
        public MyCollection() : base() { }

        public MyCollection(int length) : base(length) { }

        public MyCollection(params T[] coll) : base(coll) { }

        public new int Count => base.Count;

        public bool IsReadOnly => false; //коллекция не только для чтения

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < table.Length; i++) //проходимся по каждой строке-элементу таблицы
            {
                if (table[i] != null) //если строка не пустая
                {
                    Point<T> current = table[i];
                    while (current != null) //если  элемент в строке существует
                    {
                        yield return current.Data; //возвращаем инф.поле элемента
                        current = current.Next;//сдвигаемся дальше по цепочке
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Добавление элемента в таблицу
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public void Add(T item)
        {
            if (Contains(item)) throw new Exception("Элемент уже существует в хеш-таблице");
            else
            {
                int index = GetIndex(item); //индекс в таблице
                if (table[index] == null) // в ячейке таблицы нет цепочки
                {
                    table[index] = new Point<T>(item); // добавление элемента
                    count++;
                }
                else
                {
                    Point<T>? curr = table[index]; // "указатель" стоит на первом элементе в цепочке
                    while (curr.Next != null)
                    {
                        curr = curr.Next;
                    }
                    curr.Next = new Point<T>(item); // создаем новый элемент
                    curr.Next.Prev = curr; // связывываем новый элемент с предыдущим 
                    count++;
                }
            }
        }

        /// <summary>
        /// Очищает память
        /// </summary>
        public void Clear()
        {
            table = null;
            count = 0;
        }

        /// <summary>
        /// Проверяет, есть ли элемент в таблице
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            if (table == null) return false;
            else
            {
                if (item != null)
                {
                    int index = GetIndex(item);

                    if (table[index] == null) //если цепочка пустая, искомого элемента нет
                        return false;
                    else if (table[index].Data.Equals(item)) //элемент найден
                        return true;
                    else // идем по цепочке
                    {
                        Point<T> curr = table[index];
                        while (curr != null)
                        {
                            if (curr.Data.Equals(item))
                                return true;
                            curr = curr.Next;
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Копирует коллекцию в массив, с заданного индекса
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new Exception("Пустой массив");

            else if (array.Length - arrayIndex < Count)
            {
                throw new Exception("В массиве недостаточно места для копирования элементов");
            }

            int ind = arrayIndex;
            foreach (T item in this)
            {
                array[ind] = (T)item.Clone(); // Присваиваем в массив глубокую копию элемента
                ind++;
            }
        }

        /// <summary>
        /// Удаление элемента из таблицы
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            if (table == null) return false;
            else
            {
                if (item != null)
                {
                    Point<T>? curr;
                    int index = GetIndex(item);

                    if (table[index] == null) // пустая цепочка
                        return false;
                    else if (table[index].Data.Equals(item)) // если первый элемент в цепочке - искомый
                    {
                        if (table[index].Next == null) // один элемент в цепочке
                            table[index] = null; //"обнуляем" полностью цепочку
                        else // если элементов несколько
                        {
                            table[index] = table[index].Next; //ставим ссылку на слудющий эл-т
                            table[index].Prev = null;
                        }
                        count--;
                        return true;
                    }
                    else // если искомый элемент в середине/конце цепочки
                    {
                        curr = table[index];
                        while (curr != null) //идем до конца цепочки
                        {
                            if (curr.Data.Equals(item))
                            {
                                Point<T> prev = curr.Prev;
                                Point<T> next = curr.Next;
                                prev.Next = next;
                                curr.Prev = null;
                                if (next != null) //если такой элемнт сущ-т
                                    next.Prev = prev;
                                count--;
                                return true;
                            }
                            curr = curr.Next;
                        }
                    }
                }
                return false;
            }
        }

        public MyCollection<T> CloneCollection(MyCollection<T> coll)
        {
            MyCollection<T> clonedColl;
            if (table == null)
                throw new Exception("Исходная таблица пустая");
            else
            {
                clonedColl = new MyCollection<T>(coll.Capacity);
                foreach (T item in coll)
                {
                    clonedColl.Add((T)item.Clone());
                }
            }
            return clonedColl;
        }

        public MyCollection<T> ShallowCopy(MyCollection<T> coll)
        {
            MyCollection<T> copyColl;
            if (table == null)
                throw new Exception("Исходная таблица пустая");
            else
            {
                copyColl = new MyCollection<T>(coll.Capacity);
                foreach (T item in coll)
                {
                    copyColl.Add(item);
                }
            }
            return copyColl;
        }
    }
}