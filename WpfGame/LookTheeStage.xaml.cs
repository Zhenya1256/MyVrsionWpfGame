using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfGame.Data;

namespace WpfGame
{
    /// <summary>
    /// Interaction logic for LookTheeStage.xaml
    /// </summary>
    public partial class LookTheeStage : Window
    {
        SaveStyle styleName = new SaveStyle("Resourse\\StyleName.txt");
        SaveStyle backgroundImageName = new SaveStyle("Resourse\\BackgroundImageName.txt");

        public LookTheeStage()
        {
            InitializeComponent();
            ThemeChange();
            Next.Click += Next_Click;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ThemeChange()
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
