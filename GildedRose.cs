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

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var notAged = Items[i].Name != "Aged Brie";
                var backstage = Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
                var notSulfuras = Items[i].Name != "Sulfuras, Hand of Ragnaros";
                var qualityLess50 = Items[i].Quality < 50;
                if (notAged && !backstage)
                {
                    if (Items[i].Quality > 0 && notSulfuras)
                    {
                        Items[i].Quality--;
                    }
                }
                else
                {
                    if (qualityLess50)
                    {
                        Items[i].Quality++;
                        qualityLess50 = Items[i].Quality < 50;

                        if (backstage && qualityLess50)
                        {
                            if (Items[i].SellIn < 11)
                            {
                                Items[i].Quality++;
                            }

                            if (Items[i].SellIn < 6)
                            {
                                Items[i].Quality++;
                            }
                        }
                    }
                }

                if (notSulfuras)
                {
                    Items[i].SellIn--;
                }

                if (Items[i].SellIn < 0)
                {
                    if (notAged)
                    {
                        if (!backstage)
                        {
                            if (Items[i].Quality > 0 && notSulfuras)
                            {
                                Items[i].Quality--;
                            }
                        }
                        else
                        {
                            Items[i].Quality = 0;
                        }
                    }
                    else
                    {
                        if (qualityLess50)
                        {
                            Items[i].Quality++;
                        }
                    }
                }
            }
        }
    }
}
