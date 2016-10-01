using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System;
using System.Collections.Generic;

namespace T2IN1_SkinChanger.MenuHelper
{
    public static class MenuHelper
    {
        public static void CreateComboBox(this Menu m, string displayName, string uniqueId, List<string> options, int defaultValue = 0)
        {
            try
            {
                m.Add(uniqueId, new ComboBox(displayName, options, defaultValue));
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Error creating the combobox with the uniqueID = ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(uniqueId);
                Console.ResetColor();
            }
        }
    }
}