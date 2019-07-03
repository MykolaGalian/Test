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
    public class TestsBT
    {
        BinaryTree<StudentInfo> StInfos;
        StudentInfo s1, s2;
        static bool eventFired = false;

        public delegate void AddItemToTreeHandler(string message);
        // метод для вывода сообщений о добавлении элемента в дерево
        public static void Show_Message(String message)
        {
            //Console.WriteLine(message);
            eventFired = true;
        }


        [Test]
        public void BinaryTreeChekHeadValue() 
        {
            DateTime d1 = new DateTime(2019, 12, 2);
            s1 = new StudentInfo() { StudentName = "Petr", TestName = "Mat", TestTime = d1, TestMark = 8 };
           
            StInfos = new BinaryTree<StudentInfo>(s1);         

            Assert.AreEqual(s1,StInfos.Node);
        }

        [Test]
        public void BinaryTreeChekRightTreeNode()
        {
            DateTime d1 = new DateTime(2019, 12, 2);
            s1 = new StudentInfo() { StudentName = "Petr", TestName = "Mat", TestTime = d1, TestMark = 8 };
            s2 = new StudentInfo() { StudentName = "Niko", TestName = "Mat", TestTime = d1, TestMark = 9 };
            
            StInfos = new BinaryTree<StudentInfo>(s1);

            // добавляем элементы с помощью метода расширения
            StInfos.InsertItems<StudentInfo>(s2);

            Assert.AreEqual(s2, StInfos.RightTree.Node);
        }

        [Test]
        public void BinaryTreeChekEvent()
        {
            DateTime d1 = new DateTime(2019, 12, 2);
            s1 = new StudentInfo() { StudentName = "Petr", TestName = "Mat", TestTime = d1, TestMark = 8 };
            s2 = new StudentInfo() { StudentName = "Niko", TestName = "Mat", TestTime = d1, TestMark = 9 };
            
            StInfos = new BinaryTree<StudentInfo>(s1);

            // Добавляем обработчики события
            StInfos.MessageAdd += Show_Message;

            // добавляем элементы с помощью метода расширения
            StInfos.InsertItems<StudentInfo>(s2);            

            Assert.AreEqual(true, eventFired);
        }

    }
}
