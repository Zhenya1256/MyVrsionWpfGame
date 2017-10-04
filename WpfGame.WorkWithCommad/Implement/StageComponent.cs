using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.WorkWithCommad.Abstract;

namespace WpfGame.WorkWithCommad.Implement
{
    public class StageComponent : IStageComponent
    {
        public List<ITeamGroup> TeamGoups
        {
            get;
            set;
        }

        public IStage GetCuurent(StageType type)
        {
            CurrentGamePlay play = new CurrentGamePlay();

            List<IStage> stages = play.Stages;
            StageType index = type;

            return stages[(int)index];
        }

        public Dictionary<int, TeamGroup> StageComponentResult()
        {
            Dictionary<int, TeamGroup> result =
                new Dictionary<int, TeamGroup>();

            return result;
        }
    }
}
