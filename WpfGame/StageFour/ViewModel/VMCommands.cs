using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.ViewModal;
using WpfGame.ViewModal.StaticClass;
using WpfGame.WorkWithCommad.Implement;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.StageFour.ViewModel
{
   public class VMCommands : ViewModelBase
    {
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

                    for (int i = 0; i < Group.TeamGroups.Count; i++)
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
    }
}
