using ClassLibraryLab10;
using HashTable;
using lab12____4;
namespace TestLaba12_4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructorWithCollection()
        {
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();
            MusicalInstrument[] list = { m1, g1, e1, p1 };
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(list);
            Assert.AreEqual(list.Length, table.Count);
        }

        [TestMethod]
        public void ConstructorWithLength()
        {
            int length = 4;
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(length);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            table.Add(m1);
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            table.Add(g1);
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            table.Add(e1);
            Piano p1 = new Piano();
            p1.IRandomInit();
            table.Add(p1);
            Assert.AreEqual(length, table.Count);
        }

        [TestMethod]
        public void ConstructorWithoutParameters()
        {
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>();
            Assert.AreEqual(0, table.Count);
        }

        [TestMethod]
        public void AddException()
        {
            try
            {
                MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(3);
                MusicalInstrument m1 = new MusicalInstrument();
                m1.IRandomInit();
                table.Add(m1);
                table.Add(m1);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Элемент уже существует в хеш-таблице", ex.Message);
            }
        }

        [TestMethod]
        public void Add()
        {
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(8);
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
            table.Add(m1);
            table.Add(m2);
            table.Add(g1);
            table.Add(g2);
            table.Add(e1);
            table.Add(e2);
            table.Add(p1);
            table.Add(p2);
            int count = 0;
            foreach (MusicalInstrument m in table)
            {
                if (m != null)
                    count++;
            }
            Assert.AreEqual(count, table.Count);
        }

        [TestMethod]
        public void Clear()
        {
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(3);
            table.Clear();
            Assert.AreEqual(0, table.Count);
        }

        [TestMethod]
        public void ContainsNullTable()
        {
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>();

            Assert.AreEqual(table.Contains(new MusicalInstrument("ff", 4)), false);
        }

        [TestMethod]
        public void Contains()
        {
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(8);
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
            table.Add(m1);
            table.Add(m2);
            table.Add(g1);
            table.Add(g2);
            table.Add(e1);
            table.Add(e2);
            table.Add(p1);
            table.Add(p2);
            Assert.AreEqual(table.Contains(m1), true);
            Assert.AreEqual(table.Contains(g1), true);
            Assert.AreEqual(table.Contains(e1), true);
            Assert.AreEqual(table.Contains(p1), true);
            Assert.AreEqual(table.Contains(m2), true);
            Assert.AreEqual(table.Contains(g2), true);
            Assert.AreEqual(table.Contains(e2), true);
            Assert.AreEqual(table.Contains(p2), true);
        }

        [TestMethod]
        public void CopyToException()
        {
            try
            {
                MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(3);
                MusicalInstrument m1 = new MusicalInstrument();
                m1.IRandomInit();
                MusicalInstrument m2 = new MusicalInstrument();
                m1.IRandomInit();
                table.Add(m1);
                table.Add(m2);
                MusicalInstrument[] arr = new MusicalInstrument[1];
                table.CopyTo(arr, 0);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("В массиве недостаточно места для копирования элементов", ex.Message);
            }
        }

        [TestMethod]
        public void CopyToExceptionNullArr()
        {
            try
            {
                MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(3);
                MusicalInstrument m1 = new MusicalInstrument();
                m1.IRandomInit();
                MusicalInstrument m2 = new MusicalInstrument();
                m1.IRandomInit();
                table.Add(m1);
                table.Add(m2);
                MusicalInstrument[] arr = null;
                table.CopyTo(arr, 0);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Пустой массив", ex.Message);
            }
        }

        [TestMethod]
        public void CopyTo()
        {
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(3);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            MusicalInstrument m2 = new MusicalInstrument();
            m1.IRandomInit();
            table.Add(m1);
            table.Add(m2);
            MusicalInstrument[] arr = new MusicalInstrument[3];
            table.CopyTo(arr, 0);
            Assert.AreEqual(table.Capacity, arr.Length);
        }

        [TestMethod]
        public void RemoveTrue()
        {
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(6);
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
            table.Add(m1);
            table.Add(m2);
            table.Add(g1);
            table.Add(g2);
            table.Add(e1);
            table.Add(e2);
            table.Add(p1);
            table.Add(p2);

            Assert.AreEqual(table.Remove(p1), true);
            Assert.AreEqual(table.Remove(m1), true);
            Assert.AreEqual(table.Remove(g1), true);
            Assert.AreEqual(table.Remove(e1), true);
            Assert.AreEqual(table.Remove(p2), true);
            Assert.AreEqual(table.Remove(m2), true);
            Assert.AreEqual(table.Remove(g2), true);
            Assert.AreEqual(table.Remove(e2), true);
        }

        [TestMethod]
        public void RemoveFalse()
        {
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(6);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();
            table.AddItem(m1);
            table.AddItem(g1);
            table.AddItem(e1);
            table.AddItem(p1);
            MusicalInstrument m2 = new MusicalInstrument();
            Guitar g2 = new Guitar();
            ElectricGuitar e2 = new ElectricGuitar();
            Piano p2 = new Piano();

            Assert.AreEqual(table.Remove(p2), false);
            Assert.AreEqual(table.Remove(m2), false);
            Assert.AreEqual(table.Remove(g2), false);
            Assert.AreEqual(table.Remove(e2), false);
        }

        [TestMethod]
        public void RemoveNull()
        {
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>();
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();
            table.AddItem(m1);
            table.AddItem(g1);
            table.AddItem(e1);
            table.AddItem(p1);

            Assert.AreEqual(table.Remove(p1), false);
        }

        [TestMethod]
        public void CloneNullTable()
        {
            try
            {
                MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>();
                MyCollection<MusicalInstrument> clonedTable = table.CloneCollection(table);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Исходная таблица пустая", ex.Message);
            }
        }

        [TestMethod]
        public void Clone()
        {
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(4);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();
            table.AddItem(m1);
            table.AddItem(g1);
            table.AddItem(e1);
            table.AddItem(p1);
            MyCollection<MusicalInstrument> clonedTable = table.CloneCollection(table);
            Assert.AreEqual(table.Count, clonedTable.Count);
        }

        [TestMethod]
        public void CopyNullTable()
        {
            try
            {
                MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>();
                MyCollection<MusicalInstrument> copiedTable = table.ShallowCopy(table);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Исходная таблица пустая", ex.Message);
            }
        }

        [TestMethod]
        public void Copy()
        {
            MyCollection<MusicalInstrument> table = new MyCollection<MusicalInstrument>(4);
            MusicalInstrument m1 = new MusicalInstrument();
            m1.IRandomInit();
            Guitar g1 = new Guitar();
            g1.IRandomInit();
            ElectricGuitar e1 = new ElectricGuitar();
            e1.IRandomInit();
            Piano p1 = new Piano();
            p1.IRandomInit();
            table.AddItem(m1);
            table.AddItem(g1);
            table.AddItem(e1);
            table.AddItem(p1);
            MyCollection<MusicalInstrument> copiedTable = table.ShallowCopy(table);
            Assert.AreEqual(table.Count, copiedTable.Count);
        }
    }
}
