using SharpCompress.Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.Data
{
    class StageHolder
    {
        //public List<MemoryStream> ReadStages(string location)
        //{
        //    List<MemoryStream> directorys = new List<MemoryStream>();

        //    using (Stream stream = File.OpenRead(location))
        //    {
        //        IReader reader = ReaderFactory.Open(stream);

        //        while (reader.MoveToNextEntry())
        //        {
        //            MemoryStream fileMemory = new MemoryStream();
        //            reader.WriteEntryTo(fileMemory);
        //            directorys.Add(fileMemory);
        //        }
        //    }

        //    return directorys;
        //}

    }
}
