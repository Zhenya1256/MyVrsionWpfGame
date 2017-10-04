using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGme.UiEntites.GamePlay;

namespace WpfGame.OpenArchive
{
   public interface IArchiveLoader
    {
        IDataResult<LoaderEntyity> DataResult(FilesEntety files);
    }
}
