﻿using System;
using EloBuddy;
using EloBuddy.SDK.Rendering;
using T2IN1_Lib;
using static T2IN1_Blitzcrank.Menus;
using static T2IN1_Blitzcrank.SpellsManager;

namespace T2IN1_Blitzcrank
{
    internal class DrawingsManager
    {
        private static void Drawing_OnDraw(EventArgs args)
        {
            var readyDraw = DrawingsMenu.GetCheckBoxValue("readyDraw");

            if (DrawingsMenu.GetCheckBoxValue("qDraw") && readyDraw
                ? Q.IsReady()
                : DrawingsMenu.GetCheckBoxValue("qDraw"))
                Circle.Draw(QColorSlide.GetSharpColor(), Q.Range, 1f, Player.Instance);

            if (DrawingsMenu.GetCheckBoxValue("wDraw") && readyDraw
                ? W.IsReady()
                : DrawingsMenu.GetCheckBoxValue("wDraw"))
                Circle.Draw(WColorSlide.GetSharpColor(), W.Range, 1f, Player.Instance);

            if (DrawingsMenu.GetCheckBoxValue("eDraw") && readyDraw
                ? E.IsReady()
                : DrawingsMenu.GetCheckBoxValue("eDraw"))
                Circle.Draw(EColorSlide.GetSharpColor(), E.Range, 1f, Player.Instance);

            if (DrawingsMenu.GetCheckBoxValue("rDraw") && readyDraw
                ? R.IsReady()
                : DrawingsMenu.GetCheckBoxValue("rDraw"))
                Circle.Draw(RColorSlide.GetSharpColor(), R.Range, 1f, Player.Instance);
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
        }

        public static void InitializeDrawings()
        {
            Drawing.OnDraw += Drawing_OnDraw;
            Drawing.OnEndScene += Drawing_OnEndScene;
            DamageIndicator.Init();
        }
    }
}