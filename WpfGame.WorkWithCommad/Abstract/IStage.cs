using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.WorkWithCommad.Abstract
{
    public interface IStage
    {
        List<IStageComponent> StagesComponentn { get; set; }
        List<IAnsvers> ListAnsvers { get; set;}
    }
}
