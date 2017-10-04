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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfGame.Data;
using WpfGame.Style;
using WpfGame.ViewModal;

namespace WpfGame.View
{
    /// <summary>
    /// Interaction logic for ViewStartPage.xaml
    /// </summary>
    public partial class ViewStartPage : UserControl
    {
        private bool _isClose;

        public ViewStartPage()
        {
            InitializeComponent();
            ChangeThems.ThemeChange();
        }

        #region Menu
        private void textBox_Leave(object sender, MouseEventArgs e)
        {
            TextBlock box = (TextBlock)sender;
            box.Background = dockPanel.Background;

        }

        private void textBlock_Move(object sender, MouseEventArgs e)
        {
            TextBlock box = (TextBlock)sender;
            box.Background = textBlock2.Background;
        }

        private void button_Move(object sender, MouseEventArgs e)
        {
            Button box = (Button)sender;
            box.Background = textBlock2.Background;
        }

        private void button_Leave(object sender, MouseEventArgs e)
        {
            Button box = (Button)sender;
            box.Background = dockPanel.Background;
        }

        #endregion

        private void Label_MouseDown(object sender, RoutedEventArgs e)
        {
            if (!_isClose)
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 288;
                animation.To = 0;
                animation.Duration = TimeSpan.FromSeconds(0.3);
                dockPanel.BeginAnimation(Rectangle.WidthProperty, animation);
                label.Visibility = Visibility.Visible;
                _isClose = true;
            }
            else
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 0;
                animation.To = 288;
                animation.Duration = TimeSpan.FromSeconds(0.3);
                dockPanel.BeginAnimation(Rectangle.WidthProperty, animation);
                label.Visibility = Visibility.Hidden;
                _isClose = false;

            }
        }

        #region Help

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Help.ShowHelp(null, "Справка/СправкаГри.chm");
        }

        private void MenuItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Q)
            {
                System.Windows.Forms.Help.ShowHelp(null, "Справка/СправкаГри.chm");
            }
        }

        #endregion
    }
}
