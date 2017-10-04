using SharpCompress.Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGme.UiEntites.GamePlay;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.OpenArchive.Implement
{
    public class StageBuilder : IStageBuilder
    {
        //public IResult BuildSomePart()
        //{
        //    throw new NotImplementedException();
        //}

        public IResult BuildStage(FilesEntety ententy)
        {

            List<string> elements = ententy.PathFile;

            List<string> parents = new List<string>();
            IResult result = new Result();

            foreach (string reader in elements)
            {

                string parent = reader.Split('\\')[0];

                if (!VoliteList(parents, parent))
                {
                    parents.Add(parent);
                }
            }

            result.Success = true;

            if (parents.Count != 5)
            {
                result.Success = false;
                result.Message = ErrorMessageHolder.GetErrorMessag(ErrorType.Stage);
            }

            return result;
        }

        public IResult BuildPicture(FilesEntety ententy)
        {
                List<string> elements = ententy.PathFile;
                IResult result = new Result();
                List<string> parents = new List<string>();

                int i = 0;

                foreach (string reader in elements)
                {
                    string[] array = reader.Split('\\');

                    if (array.Length == 3)
                    {
                        FileInfo info = new FileInfo(reader);
                        string parent = info.Extension;

                        if (parent != "")
                        {
                            i++;
                        }
                    }
                }

                result.Success = true;

                if (i != 17)
                {
                    //result.Success = false;
                    //result.Message =
                    //    ErrorMessageHolder.GetErrorMessag(ErrorType.Picture);
                }

                return result;
         }

        public IResult BuildSub(FilesEntety ententy)
        {
            List<string> elements = ententy.PathFile;
            IResult result = new Result();
            List<string> parents = new List<string>();
            int i = 0;

            foreach (string reader in elements)
            {
                string[] array = reader.Split('\\');

                if (array.Length == 2)
                {
                    string parent = array[1];
                    i++;
                }
            }

            result.Success = true;

            if (i != 17)
            {
                result.Success = false;
                result.Message =
                    ErrorMessageHolder.GetErrorMessag(ErrorType.Sub);
            }

            return result;
        }

        public IResult BuildNameThems(FilesEntety ententy)
        {
            List<string> elements = ententy.PathFile;
            IResult result = new Result();
            List<string> parents = new List<string>();
            int i = 0;

            foreach (string reader in elements)
            {
                string[] array = reader.Split('\\');

                if (array.Length == 3)
                {
                    string parent = array[2];

                    FileInfo file = new FileInfo(reader);
                    string strFile = file.Extension;

                    if (strFile == "")
                    {
                        i++;
                    }
                }
            }

            result.Success = true;

            if (i != 68)
            {
                result.Success = true;
                result.Message =
                    ErrorMessageHolder.GetErrorMessag(ErrorType.NameThems);
            }

            return result;
        }

        public IResult BuildFileWithData(FilesEntety ententy)
        {
            List<string> elements = ententy.PathFile;
            IResult result = new Result();
            List<string> parents = new List<string>();
            int i = 0;

            foreach (string reader in elements)
            {
                string[] array = reader.Split('\\');

                if (array.Length == 4 && !array[3].Contains("."))
                {
                    string parent = array[3];
                    i++;
                }
            }

            result.Success = true;

            if (i != 272)
            {
                result.Success = false;
                result.Message =
                  ErrorMessageHolder.GetErrorMessag(ErrorType.FileWithData);
            }

            return result;
        }

        public IResult BuildDescription(FilesEntety ententy)
        {
            List<string> elements = ententy.PathFile;
            IResult result = new Result();
            List<string> parents = new List<string>();
            int i = 0;

            foreach (string reader in elements)
            {
                string[] array = reader.Split('\\');

                if (array.Length == 4 && array[3].Contains("."))
                {
                    string parent = array[3];
                    i++;
                }
            }

            result.Success = true;

            if (i != 68)
            {
                result.Success = false;
                result.Message =
                ErrorMessageHolder.GetErrorMessag(ErrorType.Description);
            }

            return result;
        }

        public IResult BuildFileWithPicture(FilesEntety ententy)
        {
            List<string> elements = ententy.PathFile;
            IResult result = new Result();
            List<string> parents = new List<string>();
            int i = 0;

            foreach (string reader in elements)
            {
                string[] array = reader.Split('\\');

                if (array.Length == 5 && array[4].Contains(".")
                    && !array[4].Contains("txt"))
                {
                    string parent = array[4];
                    i++;
                }
            }

            result.Success = true;

            if (i != 272)
            {
                result.Success = false;
                result.Message =
                    ErrorMessageHolder.GetErrorMessag
                    (ErrorType.FileWithPicture);
            }

            return result;
        }

        private bool VoliteList(List<string> parents, string parent)
        {
            bool isParent = false;

            if (parents != null)
            {
                foreach (var s in parents)
                {
                    if (s.Equals(parent))
                    {
                        isParent = true;
                        break;
                    }
                }
            }

            return isParent;
        }

        public LoaderEntyity GetInstance(FilesEntety ententy)
        {
            LoaderEntyity loader = new LoaderEntyity();

            List<ReaderEntety> filesStream = new List<ReaderEntety>();
            string location = ententy.PathArchiv;

            using (Stream stream = File.OpenRead(location))
            {
                IReader reader = ReaderFactory.Open(stream);

                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        ReaderEntety read = new ReaderEntety();
                        read.NameFile = reader.Entry.FilePath;
                        MemoryStream fileStream = new MemoryStream();
                        reader.WriteEntryTo(fileStream);
                        read.ContenFiles = fileStream;
                        filesStream.Add(read);
                    }
                }
 
                    Binary.Clear(PathType.FilesArchiv);
                    Binary.WriteReaderEntety(filesStream, PathType.FilesArchiv);
           
            }

            loader.FilesData = filesStream;

            return loader;
        }
    }
}
