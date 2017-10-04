using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGme.UiEntites.GamePlay;

namespace WpfGame.OpenArchive
{
  public interface IStageBuilder
    {
        IResult BuildStage(FilesEntety ententy);
        IResult BuildPicture(FilesEntety ententy);
        IResult BuildSub(FilesEntety ententy);
        IResult BuildNameThems(FilesEntety ententy);
        IResult BuildFileWithData(FilesEntety ententy);
        IResult BuildDescription(FilesEntety ententy);
        IResult BuildFileWithPicture(FilesEntety ententy);

        LoaderEntyity GetInstance(FilesEntety ententy);
    }
}
