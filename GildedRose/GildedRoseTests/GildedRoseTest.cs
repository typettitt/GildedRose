using GildedRoseKata;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseTests.NET8;

public class GildedRoseTest
{
    [Fact]
    public void Foo()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal("fixme", items[0].Name);
    }
}