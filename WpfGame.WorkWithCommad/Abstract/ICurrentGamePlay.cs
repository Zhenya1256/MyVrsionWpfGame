using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.WorkWithCommad.Abstract
{
    public interface ICurrentGamePlay
    {
        List<ICommand> GlobalistCommands { get; set; }
        List<IStage> Stages { get; set; }
    }
}
