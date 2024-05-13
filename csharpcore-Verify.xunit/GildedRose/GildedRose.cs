using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
public  void UpdateQuality()
{
    foreach (var item in Items)
    {
        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.SellIn -= 1;

            if (item.Name == "Aged Brie")
            {
                IncreaseQuality(item);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateBackstagePass(item);
            }
            else if (item.Name.StartsWith("Conjured"))
            {
                DecreaseQuality(item, 2);
            }
            else
            {
                DecreaseQuality(item);
            }

            if (item.SellIn < 0)
            {
                if (item.Name == "Aged Brie")
                {
                    IncreaseQuality(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.Quality = 0;
                }
                else if (item.Name.StartsWith("Conjured"))
                {
                    DecreaseQuality(item, 4);
                }
                else
                {
                    DecreaseQuality(item);
                }
            }
        }
    }
}

private static void DecreaseQuality(Item item, int factor = 1)
{
    item.Quality = Math.Max(0, item.Quality - (factor * (item.SellIn < 0 ? 2 : 1)));
}

private static void IncreaseQuality(Item item)
{
    item.Quality = Math.Min(50, item.Quality + 1);
}

private static void UpdateBackstagePass(Item item)
{
    if (item.SellIn < 0)
    {
        item.Quality = 0;
    }
    else if (item.SellIn < 5)
    {
        IncreaseQuality(item, 3);
    }
    else if (item.SellIn < 10)
    {
        IncreaseQuality(item, 2);
    }
    else
    {
        IncreaseQuality(item);
    }
}
}
