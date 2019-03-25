using System;
using Xunit;
using Isen.DotNet.Library.Lists;

namespace Isen.DotNet.Library.Tests
{
    public class MyCollectionTests
    {
        [Fact]
        public void AddTest()
        {
            var list = new MyCollection();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            var targetArray = new string[] {"A", "B", "C"};
            Assert.Equal(targetArray, list.Values);
        }

        [Fact]
        public void IndexTest()
        {
            var list = new MyCollection();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            Assert.True(list[0] == "A");
            Assert.True(list[1] == "B");
            Assert.True(list[2] == "C");

            list[0] = "2";
            Assert.True(list[0] == "2");
        }

        [Fact]
        public void RemoveAtTest()
        {
            var list = new MyCollection();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("D");

            list.RemoveAt(0);
            Assert.True(list[0] == "B");
            Assert.True(list[1] == "C");
            Assert.True(list[2] == "D");

            list.RemoveAt(1);
            Assert.True(list[0] == "B");
            Assert.True(list[1] == "D");

            list.RemoveAt(1);
            Assert.True(list[0] == "B");

            list.RemoveAt(0);
            Assert.True(list.Count == 0);
        }
    }
}
