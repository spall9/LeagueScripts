////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                            //
//           Credits to MarioGK for his Lib & Template also Credits to Joker for Parts of his Lib             //
//                                                                                                            //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////// 

using System;
using EloBuddy;
using EloBuddy.SDK.Rendering;
using T2IN1_Lib;

namespace T2IN1_Sona.Base
{
    internal class DrawingsManager
    {
        public static void InitializeDrawings()
        {
            Drawing.OnDraw += Drawing_OnDraw;
            Drawing.OnEndScene += Drawing_OnEndScene;
            DamageIndicator.Init();
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            var readyDraw = Menus.DrawingsMenu.GetCheckBoxValue("readyDraw");

            if (Menus.DrawingsMenu.GetCheckBoxValue("qDraw") && readyDraw
                ? SpellsManager.Q.IsReady()
                : Menus.DrawingsMenu.GetCheckBoxValue("qDraw"))
                Circle.Draw(Menus.QColorSlide.GetSharpColor(), SpellsManager.Q.Range, 1f, Player.Instance);

            if (Menus.DrawingsMenu.GetCheckBoxValue("wDraw") && readyDraw
                ? SpellsManager.W.IsReady()
                : Menus.DrawingsMenu.GetCheckBoxValue("wDraw"))
                Circle.Draw(Menus.WColorSlide.GetSharpColor(), SpellsManager.W.Range, 1f, Player.Instance);

            if (Menus.DrawingsMenu.GetCheckBoxValue("eDraw") && readyDraw
                ? SpellsManager.E.IsReady()
                : Menus.DrawingsMenu.GetCheckBoxValue("eDraw"))
                Circle.Draw(Menus.EColorSlide.GetSharpColor(), SpellsManager.E.Range, 1f, Player.Instance);

            if (Menus.DrawingsMenu.GetCheckBoxValue("rDraw") && readyDraw
                ? SpellsManager.R.IsReady()
                : Menus.DrawingsMenu.GetCheckBoxValue("rDraw"))
                Circle.Draw(Menus.RColorSlide.GetSharpColor(), SpellsManager.R.Range, 1f, Player.Instance);
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
        }
    }
}