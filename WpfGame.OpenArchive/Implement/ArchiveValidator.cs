using SharpCompress.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.OpenArchive.Implement
{
   public class ArchiveValidator : IArhiveVolidator
    {
        //public List<ReaderEntety> Read()
        //{
        //    List<ReaderEntety> _filesStream = new List<ReaderEntety>();

        //    using (Stream stream = File.OpenRead(_location))
        //    {
        //        IReader reader = ReaderFactory.Open(stream);

        //        while (reader.MoveToNextEntry())
        //        {
        //            List<MemoryStream> filesStream =
        //                  new List<MemoryStream>();

        //            if (!reader.Entry.IsDirectory)
        //            {
        //                ReaderEntety read = new ReaderEntety();
        //                read.NameFile = reader.Entry.FilePath;
        //                MemoryStream fileStream = new MemoryStream();
        //                reader.WriteEntryTo(fileStream);
        //                read.ContenFiles = fileStream;
        //                _filesStream.Add(read);
        //            }
        //        }
        //    }

        //    Files.filesStream = _filesStream;

        //    return _filesStream;
        //}

    }
}
