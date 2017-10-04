using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfGame.WorkWithCommad.Abstract;

namespace WpfGame.WorkWithCommad.Implement
{

    public class TeamGroup : ITeamGroup
    {
        private int _point=0;
        private int position = 0;
        private string _name;

        public TeamGroup(string name)
        {
            _name = name;
        }

        public Color colorCommand
        {
            get;
            set;
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

        public int Point
        {
            get
            { 
                return _point;
            }
            set
            {
                _point = value;
            }
        }

        public int Position
        {
            get;
            set;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
