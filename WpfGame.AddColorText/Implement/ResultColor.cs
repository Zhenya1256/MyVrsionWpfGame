using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WpfGame.AddColorText.Abstarct;

namespace WpfGame.AddColorText.Implement
{
    public class ResultColor : IResultColor
    {
        public Color ColorText
        {
            get;

            set;
        }

        public string Message
        {
            get;

            set;
        }

        public bool Success
        {
            get;

            set;
        }
    }
}
