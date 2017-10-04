using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfGame.View;
using WpfGame.ViewModal.StaticClass;
using WpfGame.ViewModal.ViewModelStage;
using WpfGame.WorkWithCommad.Implement;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.ViewModal
{
   public class PlayViewModel :ViewModelBase
    {
        private static IMainWindowsCodeBehind _codeBehind;
        private RelayCommand _startPlayCommand;

        public PlayViewModel(IMainWindowsCodeBehind codeBehind)
        {
            _codeBehind = codeBehind;
        }

        public PlayViewModel()
        {
            if (ComposedStage.Stage == "4")
            {
                _codeBehind.LoadView(ViewType.ThemsFour);
            }
            else
            {
                _codeBehind.LoadView(ViewType.Thems);
            }

        }

        ObservableCollection<TeamGroup> _group;
        public ObservableCollection<TeamGroup> ListGroups
        {
            get
            {
                if (_group == null)
                {
                    _group = new ObservableCollection<TeamGroup>();

                    if (Group.TeamGroups.Count == 0)
                    {
                        Group.TeamGroups = 
                            Binary.ReadTeamGroup(PathType.CurrentGroup);
                    }

                    int pos = 1;

                    for(int i=0;i< Group.TeamGroups.Count;i++)
                    {
                        Group.TeamGroups[i].Position = pos;
                        _group.Add(Group.TeamGroups[i]);
                        pos++;
                    }
                        // Group.TeamGroups;
                }
               
                return _group;
            }
        }


        public ICommand BackStagePage
        {
            get
            {               
                _startPlayCommand = new RelayCommand
                    (ExecuteStartPlyCommand, (p) => true);

                return _startPlayCommand;
            }
        }

        public void ExecuteStartPlyCommand(object parameter)
        {
            _codeBehind.LoadView(ViewType.Thems);
        }
    }
}
