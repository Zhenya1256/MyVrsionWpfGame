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
using WpfGame.Style;
using WpfGame.ViewModal;
using WpfGame.ViewModal.ViewModelStage;
using WpfGame.WorkWithCommad.Implement;
using WpgGame.SaveBinaryFormat;

namespace WpfGame
{
    /// <summary>
    /// Interaction logic for WinCommand.xaml
    /// </summary>
    public partial class WinCommand : Window
    {
        private string _nameCommand;

        public WinCommand()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ChangeThems.ThemeChange();
            SaveButton.Click += SaveButton_Click;
            InctalCheckBox();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameCommand.SelectedIndex != -1)
            {
                TeamGroup winTeam = null;

                List<TeamGroup> allcommands = 
                    Binary.ReadTeamGroup(PathType.AllCommands);

                foreach(TeamGroup s in allcommands)
                {
                    if (s.Name.Equals(_nameCommand))
                    {
                        winTeam = s;
                        break;
                    }
                }


                Binary.Clear(PathType.WinCommandsStageThree);
                Binary.Write(winTeam,PathType.WinCommandsStageThree);

                if (ComposedStage.Stage.Equals("5") || ComposedStage.Stage.Equals("6"))
                {
                    SettingViewModel.IsSettingCommand = false;
                    SettingViewModel.IsSettingPlay = false;
                    Binary.Clear();
                    new ChooseStageViewModal();
                }
                this.Close();             
            }
        }

        private void InctalCheckBox()
        {
            string current = Binary.Read(PathType.CurrentStage);

            if (current != null)
            {
                ComposedStage.Stage = current;
            }

            List<TeamGroup> teams = null;

            if (ComposedStage.Stage.Equals("3"))
            {
               teams= Binary.ReadTeamGroup(PathType.StageThree);
            }

            if (ComposedStage.Stage.Equals("5"))
            {
                teams = Binary.ReadTeamGroup(PathType.Groups1);
            }

            foreach (var s in teams)
            {
                NameCommand.Items.Add(s.Name);
            }
            NameCommand.FontSize = 22;
        }

        private void Combobox_Selected(object sender, RoutedEventArgs e)
        {
            _nameCommand = NameCommand.SelectedItem.ToString();
        }
    }
}
