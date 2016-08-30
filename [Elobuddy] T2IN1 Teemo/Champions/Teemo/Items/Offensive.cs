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
    public static class Offensive
    {
        public static Item Hydra = new Item(ItemId.Ravenous_Hydra, 250);
        public static Item HydraTitanic = new Item(ItemId.Titanic_Hydra, 250);
        public static Item Tiamat = new Item(ItemId.Tiamat, 250);
        public static Item Cutlass = new Item(ItemId.Bilgewater_Cutlass, 550);
        public static Item Botrk = new Item(ItemId.Blade_of_the_Ruined_King, 550);
        public static Item Youmuu = new Item(ItemId.Youmuus_Ghostblade);
        public static Item Gunblade = new Item(ItemId.Hextech_Gunblade, 700);
        public static Item Protobelt = new Item(ItemId.Will_of_the_Ancients, 600);
        public static Item GLP = new Item(3030, 600);

        public static List<Item> ItemList = new List<Item>
        {
            Hydra,
            HydraTitanic,
            Tiamat,
            Cutlass,
            Botrk,
            Youmuu,
            Gunblade,
            Protobelt,
            GLP
        };
    }
}