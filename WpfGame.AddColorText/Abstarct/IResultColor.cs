using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.OpenArchive;

namespace WpfGame.AddColorText.Abstarct
{
   public  interface IResultColor :IResult
    {
       Color ColorText { get; set; }
       
    }
}
