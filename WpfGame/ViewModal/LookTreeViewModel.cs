using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.ViewModal.StaticClass;
using WpfGame.WorkWithCommad.Implement;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.ViewModal
{
   public class LookTreeViewModel : ViewModelBase
    {
        ObservableCollection<TeamGroup> _group4;
        public ObservableCollection<TeamGroup> ListGroups
        {
            get
            {
                if (_group4 == null)
                {
                    _group4 = new ObservableCollection<TeamGroup>();

                  
                        Group.TeamGroups =
                           Binary.ReadTeamGroup(PathType.StageThree);
                    

                    int pos = 1;

                    for (int i = 0; i < Group.TeamGroups.Count; i++)
                    {
                        Group.TeamGroups[i].Position = pos;
                        _group4.Add(Group.TeamGroups[i]);
                        pos++;
                    }
                    // Group.TeamGroups;
                }

                return _group4;
            }
        }




    }
}
