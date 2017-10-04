using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfGame.View;
using WpfGame.ViewModal.ViewModelStage;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.ViewModal.StaticClass
{
   public static class Result
    {
        public static ViewINfoType Type = ViewINfoType.Error;
        public static string ImageResult;
        public static List<ResultDataThems> ListResultDatas = new List<ResultDataThems>();

        public static void Clear(PathType type)
        {
            string path = PathBinary.GetPath(type);
            File.Delete(path);
        }

        public static void BinaryWriter(List<ResultDataThems> data, PathType type)
        {
            string path = PathBinary.GetPath(type);
            try
            {
                File.Delete(path);
            }
            catch { }
            using (BinaryWriter writer =
            new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (var s in data)
                {
                    writer.Write(s.Name);
                    writer.Write(s.Content);
                    writer.Write(s.Type.ToString());
                }
            }
        }
        public static List<ResultDataThems> Read(PathType type)
        {
            List<ResultDataThems> data = new List<ResultDataThems>();
            string path = PathBinary.GetPath(type);

            try
            {
                if (File.Exists(path))
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    {

                        while (reader.PeekChar() > -1)
                        {
                            string name = reader.ReadString();
                            string content = reader.ReadString();
                            string info = reader.ReadString();
                            ResultDataThems them = new ResultDataThems();
                            them.Name = name;
                            them.Content = content;
                            foreach (ViewINfoType s in Enum.GetValues(typeof(ViewINfoType)))
                            {
                                if (s.ToString().Equals(info))
                                {
                                    them.Type = s;
                                    break;
                                }
                            }
                            data.Add(them);

                        }
                    }
                }
            }
            catch { }

            return data;
        }
    }

}
