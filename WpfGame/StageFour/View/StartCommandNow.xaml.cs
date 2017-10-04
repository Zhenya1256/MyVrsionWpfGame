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
using WpfGame.StageFour.ViewModel;
using WpfGame.ViewModal.StaticClass;
using WpfGame.WorkWithCommad.Implement;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.StageFour.View
{
    /// <summary>
    /// Interaction logic for StartCommandNow.xaml
    /// </summary>
    public partial class StartCommandNow : Window
    {

        DispatcherTimer dt;
        private int second = 5;

        public StartCommandNow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            int index = IndexCommands.Index+1;

            if (Group.TeamGroups.Count == 0)
            {
                Group.TeamGroups =
                    Binary.ReadTeamGroup(PathType.CurrentGroup);
            }
            if(index == 4)
            {
                IndexCommands.Index = -1;
                index = 0;
            }
         

            TeamGroup team = Group.TeamGroups[index];
            textCommand.Foreground = new SolidColorBrush(team.colorCommand);
            textCommand.FontSize = 20;
            textCommand.Text += team.Name;
            Timer();
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
                this.Close();
            }
            else
            {
                second--;
            }
        }
    }
}
