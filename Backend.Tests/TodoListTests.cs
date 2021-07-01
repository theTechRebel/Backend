using Backend.Services.Services.Concrete;
using System;
using System.Collections.Generic;
using Xunit;

namespace Backend.Tests
{
    public class TodoListTests
    {
        [Fact]
        public void Add_AddsItemToDictionary()
        {
            //arrange
            var item = "new item";
            var list = new TodoListService();

            //act
            var id = list.Add(item);

            //assert
            var newItem = Assert.Single(list.List());
            Assert.NotNull(newItem);
            var dic = new KeyValuePair<int, string>(id,item);
            Assert.Equal(dic, newItem);
            Assert.Equal(1, id);
        }

        [Fact]
        public void DictionaryIdIncrementsWhenAdding()
        {
            //arrange
            var item = "new item";
            var list = new TodoListService();

            //act
            var id1 = list.Add(item);
            var id2 = list.Add(item);
            var id3 = list.Add(item);

            //assert
            Assert.NotEqual(0, id1);
            Assert.Equal(1, id1);
            Assert.Equal(2, id2);
            Assert.Equal(3, id3);

            var output = "";
            list.List().TryGetValue(1, out output);
            Assert.Equal(output, item);
            list.List().TryGetValue(2, out output);
            Assert.Equal(output, item);
            list.List().TryGetValue(3, out output);
            Assert.Equal(output, item);
            list.List().TryGetValue(0, out output);
            Assert.NotEqual(output, item);
        }

        [Fact]
        public void Remove_RemovesItemFromDictionary()
        {
            //arrange
            var item = "another one";
            var list = new TodoListService();
            //act
            var id = list.Add(item);
            var result = list.Remove(id);
            var result1 = list.Remove(4);

            //assert
            Assert.True(result);
            Assert.False(result1);
            Assert.NotEqual(0, id);
            Assert.Equal(1, id);

        }

    }
}
