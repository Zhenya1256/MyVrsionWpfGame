using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.Data;

namespace WpfGame.Style
{
   public  class ChangeThems
    {
        private static SaveStyle styleName = new SaveStyle("Resourse\\StyleName.txt");
        private static  SaveStyle backgroundImageName =
            new SaveStyle("Resourse\\BackgroundImageName.txt");

      public static void ThemeChange()
        {
            string style = styleName.GetStyleName();

            if (style != "Без стилю")
            {
                UpdateStyle.SetThemes(style);
            }
            else
            {
                style = backgroundImageName.GetStyleName();
                UpdateStyle.SetThemes(style);
            }
        }
    }
}
