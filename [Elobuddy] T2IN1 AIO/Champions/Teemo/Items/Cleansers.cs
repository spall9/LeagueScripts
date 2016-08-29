////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;

namespace T2IN1_Teemo
{
    public static class Cleansers
    {
        // Cleansers
        public static Item Mikael = new Item(ItemId.Mikaels_Crucible, 750);
        public static Item Qss = new Item(ItemId.Quicksilver_Sash);
        public static Item Mercurial = new Item(ItemId.Mercurial_Scimitar);

        public static List<Item> ItemList = new List<Item>
        {
            Mikael,
            Qss,
            Mercurial
        };
    }
}