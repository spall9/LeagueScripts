////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
// Credits to MarioGK for his Lib, Template and his Help, also thanks & Credits to Joker for Parts of his Lib //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;

namespace T2IN1_Teemo
{
    public static class Defensive
    {
        // Cleansers
        public static Item Zhonyas = new Item(ItemId.Zhonyas_Hourglass);
        public static Item Seraph = new Item(ItemId.Seraphs_Embrace);
        public static Item Solari = new Item(ItemId.Locket_of_the_Iron_Solari, 600);
        public static Item Face = new Item(ItemId.Face_of_the_Mountain, 600);

        public static List<Item> ItemList = new List<Item>
        {
            Zhonyas,
            Seraph,
            Solari,
            Face
        };
    }
}
