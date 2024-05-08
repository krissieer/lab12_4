using ClassLibraryLab10;
using HashTable;
using System;
using System.Collections;
using System.Reflection;

namespace lab12____4
{
    public class Program
    {
        static int ChooseOption(string msg)
        {
            int number;
            bool isConvert;
            do
            {
                Console.Write(msg);
                isConvert = int.TryParse(Console.ReadLine(), out number);
                if (!isConvert || number <= 0) Console.WriteLine("Неверный ввод. Попробуйте еще раз");
            } while (!isConvert || number <= 0);

            return number;
        }

        static void PrintChoice()
        {
            Console.WriteLine("1. Музыкальные инструменты");
            Console.WriteLine("2. Гитары");
            Console.WriteLine("3. Электрогитары");
            Console.WriteLine("4. Фортепиано");
            Console.WriteLine();
        }

        static MyCollection<MusicalInstrument> MakeCollection(MyCollection<MusicalInstrument> tableCollection)
        {
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            MusicalInstrument m2 = new MusicalInstrument();
            m2.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            Guitar g2 = new Guitar();
            g2.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            ElectricGuitar e2 = new ElectricGuitar();
            e2.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();
            Piano p2 = new Piano();
            p2.IRandomInit();
            tableCollection = new MyCollection<MusicalInstrument>(m1, m2, g1, g2, e1, e2, p1, p2);
            return tableCollection;
        }

        static void AddElement(MyCollection<MusicalInstrument> tableCollection)
        {
            try
            {
                if (tableCollection.Count <= 0 || tableCollection == null)
                    Console.WriteLine("Таблица не создана");
                else
                {
                    MusicalInstrument m = new MusicalInstrument();
                    m.IRandomInit();
                    tableCollection.Add(m);
                    Console.WriteLine($"Элемент {m} добавлен");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n Исключение: {e.Message}");
            }
        }

        static void Delete(MusicalInstrument item, MyCollection<MusicalInstrument> table)
        {
            if (table.Contains(item))
            {
                table.Remove(item);
                Console.WriteLine($"Элемент {item} удален");
            }
            else
                Console.WriteLine($"Элемента ' {item} ' нет в таблице");
        }

        static void RemoveElement(MyCollection<MusicalInstrument> tableCollection)
        {
            if (tableCollection.Count <= 0 || tableCollection == null)
                Console.WriteLine("Таблица пуста");
            else
            {
                PrintChoice();
                int choice;
                choice = ChooseOption("Выберете тип элемента для удаления: ");

                switch (choice)
                {
                    case 1:
                        MusicalInstrument m = new MusicalInstrument();
                        m.Init();
                        Delete(m, tableCollection);
                        break;
                    case 2:
                        Guitar g = new Guitar();
                        g.Init();
                        Delete(g, tableCollection);
                        break;
                    case 3:
                        ElectricGuitar e = new ElectricGuitar();
                        e.Init();
                        Delete(e, tableCollection);
                        break;
                    case 4:
                        Piano p = new Piano();
                        p.Init();
                        Delete(p, tableCollection);
                        break;
                }
            }
        }

        static void Search(MusicalInstrument item, MyCollection<MusicalInstrument> table)
        {
            if (table.Contains(item))
                Console.WriteLine($"Элемент {item} есть в таблице");
            else
                Console.WriteLine($"Элемента ' {item} ' нет в таблице");
        }

        static void FindElement(MyCollection<MusicalInstrument> tableCollection)
        {
            if (tableCollection.Count <= 0 || tableCollection == null)
                Console.WriteLine("Таблица пуста");
            else
            {
                PrintChoice();
                int choice;
                choice = ChooseOption("Выберете тип элемента для поиска: ");

                switch (choice)
                {
                    case 1:
                        MusicalInstrument m = new MusicalInstrument();
                        m.Init();
                        Search(m, tableCollection);
                        break;
                    case 2:
                        Guitar g = new Guitar();
                        g.Init();
                        Search(g, tableCollection);
                        break;
                    case 3:
                        ElectricGuitar e = new ElectricGuitar();
                        e.Init();
                        Search(e, tableCollection);
                        break;
                    case 4:
                        Piano p = new Piano();
                        p.Init();
                        Search(p, tableCollection);
                        break;
                }
            }
        }

        static void PrintAndCheckClone(MyCollection<MusicalInstrument> clonedTableCollection)
        {
            try
            {
                clonedTableCollection.PrintTable();
                Console.WriteLine();
                Console.WriteLine("== Измененный клон: ==");
                foreach (MusicalInstrument item in clonedTableCollection)
                {
                    item.Name = "НОВОЕ ИМЯ";
                    break;
                }
                clonedTableCollection.PrintTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
        }

        static MusicalInstrument[] CopyTo(MyCollection<MusicalInstrument> tableCollection, MusicalInstrument[] arrCollection)
        {
            if (tableCollection.Count <= 0 || tableCollection == null)
                Console.WriteLine("Таблица пуста");
            else
            {
                int length = ChooseOption("Введите длину массива: ");
                arrCollection = new MusicalInstrument[length];
                int index = ChooseOption("Введите индекс, начиная с которого элементы будут добавлены в массив: ");
                try
                {
                    tableCollection.CopyTo(arrCollection, index - 1);
                    Console.WriteLine(" Коллекция скопирована в массив ");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n Исключение: {e.Message}");
                }
            }
            return arrCollection;
        }

        static MyCollection<MusicalInstrument> MakeCopy(MyCollection<MusicalInstrument> copiedTableCollection, MyCollection<MusicalInstrument> tableCollection)
        {
            try
            {
                copiedTableCollection = tableCollection.ShallowCopy(tableCollection);
                Console.WriteLine("Таблицы скопирована");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Исключение: {ex.Message}");
            }
            return copiedTableCollection;
        }

        static void PrintAndCheckCopy(MyCollection<MusicalInstrument> copiedTableCollection)
        {
            try
            {
                copiedTableCollection.PrintTable();
                Console.WriteLine();
                Console.WriteLine("Измененная копия: ");
                foreach (MusicalInstrument item in copiedTableCollection)
                {
                    item.Name = "НОВОЕ ИМЯ";
                    break;
                }
                copiedTableCollection.PrintTable();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            MyCollection<MusicalInstrument> tableCollection = new MyCollection<MusicalInstrument>();
            MyCollection<MusicalInstrument> clonedTableCollection = new MyCollection<MusicalInstrument>();
            MyCollection<MusicalInstrument> copiedTableCollection = new MyCollection<MusicalInstrument>();
            MusicalInstrument[] arrCollection = new MusicalInstrument[0];
            int ans;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Создание хэш-таблицы ");
                Console.WriteLine("2. Печать хэш-таблицы");
                Console.WriteLine("3. Добавление элемента в хэш-таблицу");
                Console.WriteLine("4. Удаление элемента по названию");
                Console.WriteLine("5. Поиск элемента по названию");
                Console.WriteLine("6. Клонирование элементов хэш-таблицы");
                Console.WriteLine("7. Печать и проврка правильности клонирования");
                Console.WriteLine("8. Копирование элементов таблицы в массив");
                Console.WriteLine("9. Печать массива");
                Console.WriteLine("10. Удаление коллекции из памяти");
                Console.WriteLine("11. Поверхностное копирование коллекции");
                Console.WriteLine("12. Печать копии и ее проверка");
                Console.WriteLine("0. Закончить работу");
                Console.WriteLine();

                ans = ChooseOption("Выберете пункт меню: ");
                switch (ans)
                {
                    case 1:
                        {
                            tableCollection = MakeCollection(tableCollection);
                            Console.WriteLine("Таблица создана");
                            break;
                        }

                    case 2: //Печать
                        {
                            Console.WriteLine("===  Хэш-таблица  ===");
                            if (tableCollection.Count == 0)
                                Console.WriteLine("В таблице нет элементов");
                            else
                                tableCollection.PrintTable();
                            break;
                        }

                    case 3: //Добавление
                        {
                            Console.WriteLine("Добавление элемента в коллекцию");
                            AddElement(tableCollection);
                            break;
                        }

                    case 4: //удаление
                        {
                            Console.WriteLine("Удаление элемента из коллекции");
                            RemoveElement(tableCollection);
                            break;
                        }

                    case 5: //поиск
                        {
                            Console.WriteLine("Поиск элемента в коллекции");
                            FindElement(tableCollection);
                            break;
                        }

                    case 6: //Клонирование
                        {
                            try
                            {
                                clonedTableCollection = tableCollection.CloneCollection(tableCollection);
                                Console.WriteLine(" Коллекция склонирована ");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Исключение: {ex.Message}");
                            }
                            break;
                        }

                    case 7: //Печать клона и проверка клонирования
                        {
                            Console.WriteLine("=== КЛОН КОЛЛЕКЦИИ === ");
                            PrintAndCheckClone(clonedTableCollection);
                            break;
                        }
                    case 8: //Копирование в массив
                        {
                            arrCollection = CopyTo(tableCollection, arrCollection);
                            break;
                        }
                    case 9: // Печать массива
                        {
                            Console.WriteLine("=== МАССИВ, ОСНОВАННЫЙ НА КОЛЛЕКЦИИ  === ");
                            if (arrCollection.Length > 0)
                            {
                                for (int i = 0; i < arrCollection.Length; i++)
                                    Console.WriteLine($"{i + 1}. " + arrCollection[i]);
                            }
                            else
                                Console.WriteLine(" Массив пустой ");
                            break;
                        }
                    case 10: // Очищение памяти
                        {
                            tableCollection.Clear();
                            Console.WriteLine($"Хэш-таблица удалена");
                            break;
                        }
                    case 11: // Копия таблицы
                        {
                            copiedTableCollection = MakeCopy(copiedTableCollection, tableCollection);
                            break;
                        }
                    case 12: // печать копии
                        {
                            Console.WriteLine(" ===  КОПИЯ КОЛЛЕКЦИИ === ");
                            PrintAndCheckCopy(copiedTableCollection);
                            break;
                        }
                }
            } while (ans != 0);
        }
    }
}
