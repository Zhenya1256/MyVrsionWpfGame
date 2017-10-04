using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.WorkWithCommad.Abstract;

namespace WpfGame.WorkWithCommad.Implement
{
    public class CurrentGamePlay : ICurrentGamePlay
    {
        List<ICommand> _commands;
        List<IStage> _stage;

        public CurrentGamePlay()
        {
            _commands = new List<ICommand>();
            _stage = new List<IStage>();
        }

        public List<ICommand> GlobalistCommands
        {
            get
            {
                return _commands;
            }

            set
            {
                _commands = value;
            }
        }

        public List<IStage> Stages
        {
            get
            {
                return _stage;
            }

            set
            {
                _stage = value;
            }
        }
    }
}
