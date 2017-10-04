using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.WorkWithCommad.Abstract;

namespace WpfGame.WorkWithCommad.Implement
{
    public class Command : ICommand
    {
        private string _name;

        public Command(string name)
        {
            _name = name;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
