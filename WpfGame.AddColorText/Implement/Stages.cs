using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGme.UiEntites.GamePlay;

namespace WpfGame.AddColorText.Implement
{
   public class Stages
    {

        private List<ReaderEntety> _subFiles;
        private List<ReaderEntety> _themsFiles;
        private Reader _read;

        public Stages(List<ReaderEntety> archiv)
        {
            _read = new Reader();

            _subFiles = _read.ReadSub(archiv);
            _themsFiles = _read.ReadThems(archiv);
        }

        public List<ReaderEntety> GetSub(string stage)
        {
            List<ReaderEntety> fileStream =
                new List<ReaderEntety>();
            int i = 1;

            foreach (ReaderEntety s in _subFiles)
            {
                if (s.NameFile.Split('\\')[0].Contains(stage))
                {
                 
                    ReaderEntety entety =
                        new ReaderEntety();
                    entety.NameFile = s.NameFile;
                    entety.ContenFiles = s.ContenFiles;
                    fileStream.Add(entety);
                    i++;
                }
            }

            return fileStream;
        }

        public List<ReaderEntety> GetThems(string sub)
        {
            List<ReaderEntety> fileStream =
              new List<ReaderEntety>();

            foreach (ReaderEntety s in _themsFiles)
            {
                if (s.NameFile.Contains(sub))
                {
                    ReaderEntety entety =
                       new ReaderEntety();
                    entety.NameFile = s.NameFile;
                    entety.ContenFiles = s.ContenFiles;
                    fileStream.Add(entety);
                }
            }

            return fileStream;
        }

    }
}
