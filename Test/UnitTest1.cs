using NUnit.Framework;
using WindowsFormsApp1;
using System;

namespace Test
{
    public class Tests
    {
        GronsfeldCipher gc;
        [SetUp]
        public void Setup()
        {
            gc = new GronsfeldCipher();
        }

        [Test]
        public void TestEncode()
        {
            int key = 987;
            string word = "��������������";
            string  select = gc.Gronspheld(word, key,0);
            string expected = "��������������";
            Assert.Pass(expected,select);
        }
        [Test]
        public void TestDecode()
        {
            int key = 987;
            string word = "��������������";
            string select = gc.Gronspheld(word, key, 1);
            string expected = "��������������";
            Assert.Pass(expected, select);
        }

        [Test]
        public void TestMinus()
        {
            int key = -9;
            string word = "��������������";
            string select = gc.Gronspheld(word, key, 1);
            string expected = " ";
            Assert.Pass(expected, select);
        }

        [Test]
        public void TestNothing()
        {
            int key = 987;
            string word = " ";
            string select = gc.Gronspheld(word, key, 1);
            string expected = " ";
            Assert.Pass(expected, select);
        }
        [Test]
        public void TestLanguage()
        {
            int key = 987;
            string word = "ABCDAbdullinRuas ";
            string select = gc.Gronspheld(word, key, 1);
            string expected = "����������� ������� � ������ �����";
            Assert.Pass(expected, select);
        }
        [Test]
        public void TestLarge()
        {
            int key = 987565555;
            string word = "����������������������� ";
            string select = gc.Gronspheld(word, key, 1);
            string expected = " ";
            Assert.Pass(expected, select);
        }
        [Test]
        public void TestNullPasword()
        {
            int key = 0;
            string word = "��������������";
            string select = gc.Gronspheld(word, key, 1);
            string expected = " ";
            Assert.Pass(expected, select);
        }
    }
}