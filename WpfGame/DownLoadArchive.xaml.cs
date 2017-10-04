using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfGame.View;

namespace WpfGame
{
    /// <summary>
    /// Interaction logic for DownLoadArchive.xaml
    /// </summary>
    public partial class DownLoadArchive : Window
    {
        public DownLoadArchive()
        {
            InitializeComponent();
            this.Loaded += DownLoadArchive_Loaded;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void DownLoadArchive_Loaded(object sender, RoutedEventArgs e)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //Duration duration = new Duration(TimeSpan.FromSeconds());
            //DoubleAnimation animation = new DoubleAnimation(0, 320, duration);
            //ProgressBar.BeginAnimation(ProgressBar.ValueProperty, animation);
            //   ProgressBar.Maximum = 320;
            //Duration duration = new Duration(TimeSpan.FromSeconds(25));
            //DoubleAnimation animation = new DoubleAnimation(0, 320, duration);
            //ProgressBar.BeginAnimation(ProgressBar.ValueProperty, animation);

            //for (int i = 0; i < 320; i++)
            //{
            //    //Duration duration = new Duration(TimeSpan.FromSeconds(5));
            //    //DoubleAnimation animation = new DoubleAnimation(i, i+1, duration);
            //    //ProgressBar.BeginAnimation(ProgressBar.ValueProperty, animation);
            //  ///  ProgressBar.Value++;
            //}
            //ProgressBar.BeginInit();


        }





    }
}
