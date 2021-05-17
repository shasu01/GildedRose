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
            foreach (var t in Items)
            {
                var notAged = t.Name != "Aged Brie";
                var notBackstage = t.Name != "Backstage passes to a TAFKAL80ETC concert";
                var notSulfuras = t.Name != "Sulfuras, Hand of Ragnaros";
                if (notAged && notBackstage)
                {
                    if (t.Quality > 0 && notSulfuras)
                    {
                        t.Quality -= 1;
                    }
                }
                else
                {
                    QualityLess50(t, notBackstage);
                }

                if (!notSulfuras) continue;
                t.SellIn -= 1;
                if (t.SellIn >= 0) continue;
                if (notAged)
                {
                    NotAged(notBackstage, t);
                }
                else
                {
                    if (t.Quality < 50)
                    {
                        t.Quality += 1;
                    }
                }
            }
        }

        private static void NotAged(bool notBackstage, Item t)
        {
            if (notBackstage)
            {
                if (t.Quality > 0)
                {
                    t.Quality -= 1;
                }
            }
            else
            {
                t.Quality -= t.Quality;
            }
        }

        private static void QualityLess50(Item t, bool notBackstage)
        {
            if (t.Quality < 50)
            {
                t.Quality += 1;
                if (!notBackstage && t.SellIn < 11 && t.Quality < 50)
                {
                    t.Quality += 1;
                    if (t.SellIn < 6)
                    {
                        t.Quality += 1;
                    }
                }
            }
        }
    }
}

//using System;
//using System.Collections.Generic;

//namespace csharp
//{
//    public class GildedRose
//    {
//        IList<Item> Items;
//        public GildedRose(IList<Item> Items)
//        {
//            this.Items = Items;
//        }

//        public void UpdateQuality()
//        {
//            for (var i = 0; i < Items.Count; i++)
//            {
//                var notAged = Items[i].Name != "Aged Brie";
//                var backstage = Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
//                var notSulfuras = Items[i].Name != "Sulfuras, Hand of Ragnaros";
//                var qualityLess50 = Items[i].Quality < 50;

//                if (notAged && !backstage)
//                {
//                    NegativeQualityOrNotSulfuras(i, notSulfuras);
//                }
//                else
//                {
//                    if (qualityLess50) qualityLess50 = AgedWithQualityLessThan50(i, backstage);
//                }

//                if (notSulfuras)
//                {
//                    Items[i].SellIn--;
//                }

//                if (Items[i].SellIn < 0 && notAged)
//                {
//                    Items[i].Quality = NegativeSellInAndNotAged(Items[i].Quality, backstage, notSulfuras);

//                }

//                if (Items[i].SellIn >= 0 || notAged || !qualityLess50) continue;
//                if (qualityLess50)
//                {
//                    Items[i].Quality++;
//                }
//            }
//        }

//        private void NegativeQualityOrNotSulfuras(int i, bool notSulfuras)
//        {
//            if (!(Items[i].Quality <= 0 || !notSulfuras))
//            {
//                Items[i].Quality--;
//            }
//        }

//        private int NegativeSellInAndNotAged(int quality, bool backstage, bool notSulfuras)
//        {
//            if (backstage) return 0;
//            if (quality <= 0 || !notSulfuras) return quality;
//            return quality -= 1;
//        }

//        private bool AgedWithQualityLessThan50(int i, bool backstage)
//        {
//            Items[i].Quality++;
//            var qualityLess50 = Items[i].Quality < 50;

//            if (!backstage || !qualityLess50 || Items[i].SellIn >= 11) return qualityLess50;
//            Items[i].Quality++;
//            if (Items[i].SellIn >= 6) return true;
//            Items[i].Quality++;
//            return true;
//        }
//    }
//}
