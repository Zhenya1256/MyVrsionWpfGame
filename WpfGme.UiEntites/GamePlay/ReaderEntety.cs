using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGme.UiEntites.GamePlay
{
    [Serializable]
    public class ReaderEntety
    {
        public string NameFile { get; set; }
        public MemoryStream ContenFiles { get; set; }
        public MemoryStream ContenFilesTxt { get; set; }
    }
}
