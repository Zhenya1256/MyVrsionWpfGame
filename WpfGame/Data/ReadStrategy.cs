using SharpCompress.Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfGme.UiEntites.GamePlay;

namespace WpfGame.Data
{
    public class ReadStrategy
    {
        public List<ReaderEntety> Read(List<ReaderEntety> filesStream)
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
                    entety.NameFile =path.Replace(array[2],"");
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

        public List<ReaderEntety> ReadQiation(List<ReaderEntety> filesStream)
        {
            List<ReaderEntety> read =
                new List<ReaderEntety>();

            foreach (var s in filesStream)
            {
                string path = s.NameFile;
                string[] array = path.Split('\\');


                if (array.Length == 6 && array[5].Contains("."))
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
