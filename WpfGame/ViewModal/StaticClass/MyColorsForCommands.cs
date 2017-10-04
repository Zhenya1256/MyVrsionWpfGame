using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfGame.ViewModal.StaticClass
{
   public static class MyColorsForCommands
    {
        private static List<Color> Colors =
            new List<Color>();

        public static List<Color> GetColors()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Color.FromRgb(0, 255, 0));
            colors.Add(Color.FromRgb(0, 0, 255));
            colors.Add(Color.FromRgb(255, 0, 0));
            colors.Add(Color.FromRgb(0, 254, 255));
            colors.Add(Color.FromRgb(255, 0, 254));
            colors.Add(Color.FromRgb(0, 128, 0));
            colors.Add(Color.FromRgb(0, 255, 0));
            colors.Add(Color.FromRgb(128, 128, 129));
            colors.Add(Color.FromRgb(128, 0, 0));
            colors.Add(Color.FromRgb(0,0,128));
            colors.Add(Color.FromRgb(127, 128, 0));
            colors.Add(Color.FromRgb(128, 0, 127));
            colors.Add(Color.FromRgb(0, 128, 127));
            colors.Add(Color.FromRgb(255, 254, 0));
            colors.Add(Color.FromRgb(0, 128, 255));
            colors.Add(Color.FromRgb(0, 255, 128));
            colors.Add(Color.FromRgb(0, 0, 0));
            colors.Add(Color.FromRgb(255, 255, 255));

            //colors.Add(Color.FromRgb(255, 128, 128));
            //colors.Add(Color.FromRgb(255, 255, 128));
            //colors.Add(Color.FromRgb(128, 255, 128));
            //colors.Add(Color.FromRgb(128, 128, 255));


            //colors.Add(Color.FromRgb(128, 255, 0));
            //colors.Add(Color.FromRgb(128, 255, 255));
            //colors.Add(Color.FromRgb(128, 0, 255));

            //colors.Add(Color.FromRgb(255, 0, 255));
            //colors.Add(Color.FromRgb(255, 128, 255));
            //colors.Add(Color.FromRgb(255, 255, 255));
            //colors.Add(Color.FromRgb(0, 0, 0));


            return colors;
        }

    }
}
