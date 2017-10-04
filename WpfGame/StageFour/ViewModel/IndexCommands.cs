using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.StageFour.ViewModel
{
   public static class IndexCommands
    {
        private static int _index = -1;

        public static int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }

    }
}
