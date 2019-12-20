using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void itemsShouldDecreaseInQualityAndSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
            Assert.AreEqual(0, Items[0].Quality);
            Assert.AreEqual(0, Items[0].SellIn);
        }

        [Test]
        public void agedBrieIncreasesInQualityBy1AsItGetsOlderBeforeSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(1, Items[0].Quality);
            Assert.AreEqual(0, Items[0].SellIn);
        }

        [Test]
        public void agedBrieIncreasesInQualityBy2AsItGetsOlderEvenAfterSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(2, Items[0].Quality);
            Assert.AreEqual(-1, Items[0].SellIn);
        }

        [Test]
        public void theQualityOfAnItemIsNeverNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
            Assert.AreEqual(0, Items[0].Quality);
            Assert.AreEqual(0, Items[0].SellIn);
        }

        [Test]
        public void theQualityOfAnItemIsNeverMoreThan50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Aged Brie", Items[0].Name);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void sulfarasNeverHasToBeSoldOrDecreaseInQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Sulfuras, Hand of Ragnaros", Items[0].Name);
            Assert.AreEqual(80, Items[0].Quality);
            Assert.AreEqual(1, Items[0].SellIn);
        }

        [Test]
        public void backstagePassIncreasesBy2QualityWhenSellIn10OrLess()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(2, Items[0].Quality);
            Assert.AreEqual(9, Items[0].SellIn);
        }

        [Test]
        public void backstagePassIncreasesBy3QualityWhenSellIn5OrLess()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(3, Items[0].Quality);
            Assert.AreEqual(4, Items[0].SellIn);
        }

        [Test]
        public void backstagePassQualityDropsTo0WhenSellIn0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 48 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.AreEqual(0, Items[0].Quality);
            Assert.AreEqual(-1, Items[0].SellIn);
        }

        [Test]
        public void conjuredItemsDegradeInQualityBy2BeforeSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Conjured Mana Cake", Items[0].Name);
            Assert.AreEqual(4, Items[0].Quality);
            Assert.AreEqual(2, Items[0].SellIn);
        }

        [Test]
        public void conjuredItemsDegradeInQualityBy4AfterSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("Conjured Mana Cake", Items[0].Name);
            Assert.AreEqual(2, Items[0].Quality);
            Assert.AreEqual(-1, Items[0].SellIn);
        }
    }
}
