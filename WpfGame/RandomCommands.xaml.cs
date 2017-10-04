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
using WpfGame.ViewModal;
using WpfGame.ViewModal.TempDir;
using WpfGame.WorkWithCommad.Implement;
using WpgGame.SaveBinaryFormat;

namespace WpfGame
{
    /// <summary>
    /// Interaction logic for RandomCommands.xaml
    /// </summary>
    public partial class RandomCommands : Window
    {
        public RandomCommands()
        {
            InitializeComponent();
            DataContext = new SettingViewModel();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }      
    }
}
