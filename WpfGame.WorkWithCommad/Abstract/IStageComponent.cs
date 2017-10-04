using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.WorkWithCommad.Implement;

namespace WpfGame.WorkWithCommad.Abstract
{
    public interface IStageComponent 
    {
        List<ITeamGroup> TeamGoups { get; set; }
        IStage GetCuurent(StageType type);

    }
}
