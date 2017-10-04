using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGme.UiEntites.GamePlay;

namespace WpfGame.AddColorText.Implement
{
    public class Reader
    {
        public List<ReaderEntety> ReadSub(List<ReaderEntety> filesStream)
        {
            List<ReaderEntety> stges = new List<ReaderEntety>();

            foreach (var s in filesStream)
            {
                string path = s.NameFile;
                string[] array = path.Split('\\');

                if (array.Length == 3 && array[2].Contains("."))
                {
                    ReaderEntety entety =
                           new ReaderEntety();
                    entety.ContenFiles = s.ContenFiles;
                    entety.NameFile = path.Replace(array[2], "");
                    stges.Add(entety);
                }
            }

            return stges;
        }

        public List<ReaderEntety> ReadThems(List<ReaderEntety> filesStream)
        {
            List<ReaderEntety> read =
                new List<ReaderEntety>();

            foreach (var s in filesStream)
            {
                string path = s.NameFile;
                string[] array = path.Split('\\');


                if (array.Length == 5 && array[4].Contains("."))
                {
                    ReaderEntety entety =
                           new ReaderEntety();
                    entety.ContenFiles = s.ContenFiles;
                    entety.NameFile = path;
                    read.Add(entety);
                }
            }

            return read;
        }

    }
}
