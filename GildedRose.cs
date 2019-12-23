using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void ModifyItemQuality(Item item, int value)
        {
            item.Quality = item.Quality + value;

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }

        public void UpdateQuality()
        {
            foreach(Item item in Items)
            {
                if (item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    int modifier = 1;
                    if (item.Name == "Aged Brie") { modifier = -1; }
                    if (item.Name == "Conjured Mana Cake") { modifier = 2; }

                    if (item.SellIn > 0)
                        ModifyItemQuality(item, -1 * modifier);
                    
                    if (item.SellIn <= 0)
                        ModifyItemQuality(item, -2 * modifier);

                    item.SellIn = item.SellIn - 1;
                }

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn > 10)
                        ModifyItemQuality(item, 1);

                    if (item.SellIn > 5 && item.SellIn < 11)
                        ModifyItemQuality(item, 2);

                    if (item.SellIn < 6)
                        ModifyItemQuality(item, 3);

                    if (item.SellIn <= 0)
                        ModifyItemQuality(item, -item.Quality);

                    item.SellIn = item.SellIn - 1;
                }
            }
        }
    }
}
