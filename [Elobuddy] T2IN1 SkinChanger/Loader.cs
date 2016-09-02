////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace T2IN1_SkinChanger
{
    internal class Loader
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            SkinChanger.CreateMenu();
            Chat.Print("T2IN1 SkinChanger Loaded!");
        }
    }
}