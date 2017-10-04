using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.WorkWithCommad.Abstract
{
    public interface IAnsvers
    {
        ITeamGroup TeamGroup { get; set; }
        int PointCount { get; set; }
    }
}
