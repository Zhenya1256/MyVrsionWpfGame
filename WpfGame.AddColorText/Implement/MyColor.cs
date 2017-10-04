using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.AddColorText.Implement
{
    public static class MyColor  
    {
        public static List<Color> GetColors()
        {
            List<Color> colors = new List<Color>();
            colors.Add(Color.FromArgb(47, 18, 179));// blue
            colors.Add(Color.FromArgb(212, 6, 6));//red
            colors.Add(Color.FromArgb(191, 212, 6));//yellow
            colors.Add(Color.FromArgb(15, 205, 212));//yellow
            colors.Add(Color.FromArgb(31, 212, 15));//yellow  
            colors.Add(Color.FromArgb(240, 230, 230));//yellow

            return colors;

        }


    }
}
