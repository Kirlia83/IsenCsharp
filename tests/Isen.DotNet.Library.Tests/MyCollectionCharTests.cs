using System;
using Xunit;
using Isen.DotNet.Library.Lists;

namespace Isen.DotNet.Library.Tests
{
    public class MyCollectionCharTests
    {
        [Fact]
        public void CountTest()
        {
            var list = new MyCollection<char>();
            Assert.True(list.Count == 0);
            list.Add('A');
            Assert.True(list.Count == 1);
            list.Add('B');
            Assert.True(list.Count == 2);
            list.Add('C');
            Assert.True(list.Count == 3);
        }
        [Fact]
        public void AddTest()
        {
            var list = new MyCollection<char>();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            var targetArray = new char[] {'A', 'B', 'C'};
            Assert.Equal(targetArray, list.Values);
        }

        [Fact]
        public void IndexTest()
        {
            var list = new MyCollection<char>();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            Assert.True(list[0] == 'A');
            Assert.True(list[1] == 'B');
            Assert.True(list[2] == 'C');

            list[0] = '2';
            Assert.True(list[0] == '2');
        }

        [Fact]
        public void RemoveAtTest()
        {
            var list = new MyCollection<char>();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');

            list.RemoveAt(0);
            Assert.True(list[0] == 'B');
            Assert.True(list[1] == 'C');
            Assert.True(list[2] == 'D');

            list.RemoveAt(1);
            Assert.True(list[0] == 'B');
            Assert.True(list[1] == 'D');

            list.RemoveAt(1);
            Assert.True(list[0] == 'B');

            list.RemoveAt(0);
            Assert.True(list.Count == 0);

            try
            {
                list.RemoveAt(0);
            }
            catch(Exception e)
            {
                Assert.True(e is IndexOutOfRangeException);
            }
            try
            {
                list.RemoveAt(1);
            }
            catch(Exception e)
            {
                Assert.True(e is IndexOutOfRangeException);
            }
            try
            {
                list.RemoveAt(-1);
            }
            catch(Exception e)
            {
                Assert.True(e is IndexOutOfRangeException);
            }
        }
        [Fact]
        public void IndexOfTest()
        {
            var list = new MyCollection<char>();
            list.Add('A');
            list.Add('B');
            list.Add('B');
            list.Add('C');
            Assert.True(list.IndexOf( 'B' ) == 1);
            Assert.True(list.IndexOf( 'A' ) == 0);
            Assert.True(list.IndexOf( 'C' ) == 3);
            Assert.True(list.IndexOf( 'Z' ) < 0);
            #pragma warning disable xUnit2017
            Assert.True(list.Contains('A'));
            Assert.False(list.Contains('Z'));
            #pragma warning restore xUnit2017
        }

        [Fact]
        public void RemoveTest(){
            var list = new MyCollection<char>();
            list.Add('A');
            list.Add('B');
            list.Add('B');
            list.Add('C');
            Assert.True(list.Remove('B'));
            Assert.True(list.Count == 3);
            Assert.True(list[2] == 'C');
            Assert.False(list.Remove('Z'));
        }

        [Fact]
        public void InsertTest(){
            var list = new MyCollection<char>();
            list.Insert(0, 'C');
            list.Insert(0, 'B');
            list.Insert(0, 'A');
            list.Insert(3, 'D');
            list.Insert(2, 'b');
            var targetArray = new char[] {'A', 'B', 'b', 'C', 'D'};
            Assert.Equal(targetArray, list);
            try
            {
                list.Insert(-1, 'E');
            }
            catch(Exception e)
            {
                Assert.True(e is IndexOutOfRangeException);
            }
            try
            {
                list.Insert(5, 'E');
            }
            catch(Exception e)
            {
                Assert.True(e is IndexOutOfRangeException);
            }
        }
        [Fact]
        public void EnumeratorTest()
        {
            var list = new MyCollection<char>();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');

            var targetArray = new char[] {'A', 'B', 'C', 'D'};
            foreach(var item in list)
            {
                Assert.True(true);
            }
        }
        [Fact]
        public void ClearTest()
        {
            var list = new MyCollection<char>();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');

            Assert.True(list.Count == 4);
            list.Clear();
            Assert.True(list.Count == 0);
            
        }

        [Fact]
        public void CopyToTest(){
            var list = new MyCollection<char>();
            list.Add('A');
            list.Add('B');
            list.Add('C');

            var biggerArray = new char[] {'1', '2', 'a', 'b', 'c', 'd'};
            var biggerExpected = new char[] {'1', '2', 'A', 'B', 'C', 'd'};
            list.CopyTo(biggerArray, 2);
            Assert.Equal(biggerArray, biggerExpected);

            var equalArray = new char[]{'1', '2', '3', '4'};
            var equalExpected = new char[]{'1', 'A', 'B', 'C'};
            list.CopyTo(equalArray, 1);
            Assert.Equal(equalArray, equalExpected);
            

            var smallArray = new char[]{'1', '2', '3'};
            try
            {
                list.CopyTo(smallArray, 2);
            }
            catch(Exception e)
            {
                Assert.True(e is ArgumentException);
            }
        }
    }
}