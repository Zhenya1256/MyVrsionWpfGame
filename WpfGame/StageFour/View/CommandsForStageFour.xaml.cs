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
using System.Windows.Threading;
using WpfGame.Style;

namespace WpfGame.StageFour.View
{
    /// <summary>
    /// Interaction logic for CommandsForStageFour.xaml
    /// </summary>
    public partial class CommandsForStageFour : Window
    {
        DispatcherTimer dt;
        private int second = 6;

        public CommandsForStageFour()
        {
            InitializeComponent();
            ChangeThems.ThemeChange();
            Timer();
            this.Closing += Main_Closing;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Timer()
        {
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private void dtTicker(object sender, EventArgs e)
        {
            if (second < 5)
            {
                dt.Stop();
                StartCommandNow stn = new StartCommandNow();
                stn.Show();
                this.Close();
            }
            else
            {
                second--;
            }

        }
        private void Main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           /// StartCommandNow stn = new StartCommandNow();
           // stn.Show();
        }
    }
}
