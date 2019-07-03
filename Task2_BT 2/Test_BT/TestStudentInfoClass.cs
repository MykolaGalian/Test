using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_BT;

namespace Test_BT
{

    [TestFixture]
    public class TestStudentInfoClass
    {
       
        StudentInfo s1,s2,s3;


        [SetUp] //  method starts at the beginning of each test run
        public void Init()
        {
            DateTime d1 = new DateTime(2019, 12, 2);
            
            s2 = new StudentInfo() { StudentName = "Niko", TestName = "Mat", TestTime = d1, TestMark = 9 };
            s3 = new StudentInfo() { StudentName = "Jenya", TestName = "Mat", TestTime = d1, TestMark = 9 };
        }

       
        [Test]
        public void StudentInfoChekCompareTo()
        {
            Assert.AreEqual(0, s2.TestMark.CompareTo(s3.TestMark));
        }


        [Test]
        public void BinaryTreeChekNodeToString()
        {
            string str = "Mark: " + s2.TestMark + ", Student: " + s2.StudentName;
            Assert.AreEqual(str, s2.ToString());
        }
    }
}
