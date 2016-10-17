using System;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Rendering;
using T2IN1_Lib;
using static T2IN1_Blitzcrank.Menus;
using static T2IN1_Blitzcrank.SpellsManager;
using static T2IN1_Blitzcrank.Combo;

namespace T2IN1_Blitzcrank
{
    internal class DrawingsManager
    {
        private static void Drawing_OnDraw(EventArgs args)
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
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

            if (DrawingsMenu.GetCheckBoxValue("QPredictionDraw") && readyDraw
                ? Q.IsReady()
                : DrawingsMenu.GetCheckBoxValue("QPredictionDraw"))
            {
                if (qtarget != null && qtarget.IsValidTarget(Q.Range))
                {
                    var pred = Q.GetPrediction(qtarget);
                    var rect = new Geometry.Polygon.Rectangle(ObjectManager.Player.Position, pred.CastPosition, Q.Width);
                    rect.Draw((Q.GetPrediction(qtarget).HitChance >= HitChance.High && Q.IsReady()) ? Color.Blue : Color.Brown);
                    Drawing.DrawText(pred.CastPosition.WorldToScreen(), Color.Wheat, Q.GetPrediction(qtarget).HitChance.ToString(), 2);
                }
            }
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