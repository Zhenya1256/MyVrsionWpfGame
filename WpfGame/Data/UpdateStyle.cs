using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGame.Data
{
   public class UpdateStyle
    {
        public static void SetThemes(string styleSource)
        {
            if (styleSource != "Без стилю")
            {
                var uri = new Uri("Style/" + styleSource + ".xaml", UriKind.RelativeOrAbsolute);

                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
        }
    }
}
