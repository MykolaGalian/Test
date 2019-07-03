using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_Ar;

namespace TestAr
{
    [TestFixture]
    public class TestArray
    {
        [TestCase(7)]
        public void Constructor_ChecArrayLenght(int len)
        {
            CustomArray<int> arTests = new CustomArray<int>(-4, 2);

            for (int i = arTests.Start; i < arTests.End; i++)
            {
                arTests[i] = i * 2;
            }

            Assert.AreEqual(len, arTests.Lenght);
        }


        [TestCase(-8)]
        public void Constructor_ChecArrayIndexValue(int value)
        {
            CustomArray<int> arTests = new CustomArray<int>(-4, 2);

            for (int i = arTests.Start; i < arTests.End; i++)
            {
                arTests[i] = i * 2;
            }
            Assert.AreEqual(value, arTests[arTests.Start]);
        }

        [Test]        
        public void Constructor_ChecWrongIndexExeption()
        {
            
            Assert.Throws<WrongIndexExeption>(()=>new CustomArray<int>(-4, -8));     
        }

        [TestCase(10)]
        public void Constructor_ChecIndexOutOfRangeException(int index) 
        {
            CustomArray<int> arTests = new CustomArray<int>(-4, 2);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                for (int i = arTests.Start; i < arTests.End + index; i++)
                {
                    arTests[i] = i * 2;
                }
            }
            );
        }
    }
}

    
    
