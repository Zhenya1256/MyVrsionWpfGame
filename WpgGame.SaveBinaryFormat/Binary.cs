using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfGame.WorkWithCommad.Implement;
using WpfGme.UiEntites.GamePlay;

namespace WpgGame.SaveBinaryFormat
{
    public static class Binary
    {
        public static List<ReaderEntety> _datasReader = new List<ReaderEntety>();

        public static void WriteNomer(string data, PathType type)
        {
            string path = PathBinary.GetPath(type);

            using (BinaryWriter writer =
            new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(data);
            }
        }

        public static void Write(string data, PathType type)
        {
            string path = PathBinary.GetPath(type);

            using (BinaryWriter writer =
            new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write(data);

            }
        }

        public static void Write(List<string> data, PathType type)
        {
            string path = PathBinary.GetPath(type);

            using (BinaryWriter writer =
            new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (var s in data)
                {
                    writer.Write(s);
                }
            }
        }

        public static void WriteReaderEntety(List<ReaderEntety> data, PathType type)
        {
            string path = PathBinary.GetPath(type);
            List<string> counts = new List<string>();
            using (BinaryWriter writer =
            new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (var s in data)
                {
                    writer.Write(s.NameFile);
                    // writer.Write(Encoding.ASCII.GetString(s.ContenFiles.ToArray()));
                    writer.Write(s.ContenFiles.ToArray());
                    counts.Add(s.ContenFiles.ToArray().Length.ToString());
                }
            }
            Clear(PathType.CountList);
            Write(counts, PathType.CountList);

        }

        public static void Write(List<TeamGroup> data, PathType type)
        {
            string path = PathBinary.GetPath(type);
            List<string> counts = new List<string>();
            using (BinaryWriter writer =
            new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (var s in data)
                {
                    writer.Write(s.Name);
                    writer.Write(s.Point);
                    Color color = s.colorCommand;
                    byte r = color.R;
                    byte g = color.G;
                    byte b = color.B;
                    writer.Write((int)r);
                    writer.Write((int)g);
                    writer.Write((int)b);
                }
            }
        }

        public static void Write(TeamGroup data, PathType type)
        {
            string path = PathBinary.GetPath(type);
            List<string> counts = new List<string>();
            using (BinaryWriter writer =
            new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {

                writer.Write(data.Name);
                writer.Write(data.Point);
                Color color = data.colorCommand;
                byte r = color.R;
                byte g = color.G;
                byte b = color.B;
                writer.Write((int)r);
                writer.Write((int)g);
                writer.Write((int)b);
                // writer.Write();
            }

        }

        public static TeamGroup CurrentTeam(PathType type)
        {
            TeamGroup data = null;
            string path = PathBinary.GetPath(type);

            if (File.Exists(path))
            {
                try
                {
                    using (BinaryReader reader =
                        new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        while (reader.PeekChar() > -1)
                        {
                            TeamGroup team =
                                new TeamGroup(reader.ReadString());
                            team.Point = reader.ReadInt32();
                            int r = reader.ReadInt32();
                            int g = reader.ReadInt32();
                            int b = reader.ReadInt32();
                            Color color = Color.FromRgb((byte)r, (byte)g, (byte)b);
                            team.colorCommand = color;
                            data = team;
                        }
                    }
                }
                catch { }
            }

            return data;
        }

        public static List<TeamGroup> ReadTeamGroup(PathType type)
        {
            List<TeamGroup> data = new List<TeamGroup>();
            string path = PathBinary.GetPath(type);

            if (File.Exists(path))
            {
                try
                {
                    using (BinaryReader reader =
                        new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        while (reader.PeekChar() > -1)
                        {
                            TeamGroup team = new TeamGroup(reader.ReadString());
                            team.Point = reader.ReadInt32();
                            int r = reader.ReadInt32();
                            int g = reader.ReadInt32();
                            int b = reader.ReadInt32();
                            Color color = Color.FromRgb((byte)r, (byte)g, (byte)b);
                            team.colorCommand = color;
                            data.Add(team);
                        }
                    }
                }
                catch { }
            }

            return data;
        }

        public static List<ReaderEntety> ReadList(PathType type)
        {
            List<ReaderEntety> data = new List<ReaderEntety>();
            string path = PathBinary.GetPath(type);
            if (_datasReader.Count == 0)
            {
                if (File.Exists(path))
                {

                    bool isRead = true;
                    while (isRead) {
                        try {
                            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                            {
                                List<string> counts = ReadListString(PathType.CountList);
                                int i = 0;
                                while (reader.PeekChar() > -1)
                                {
                                    string str = reader.ReadString();
                                    int number = int.Parse(counts[i]);
                                    byte[] str1 = reader.ReadBytes(number);
                                    //string str1 = reader.ReadString();
                                    if (i == 761)
                                    {

                                    }
                                    ReaderEntety entety = new ReaderEntety();
                                    entety.NameFile = str;
                                    entety.ContenFiles = new MemoryStream(str1);
                                    // new MemoryStream(Encoding.ASCII.GetBytes(str1));
                                    data.Add(entety);
                                    i++;
                                    isRead = false;
                                }
                            }
                        }
                        catch 
                        {
                            isRead = true;
                        }
                    }
                }
                foreach(var s in data)
                {
                    _datasReader.Add(s);
                }

                data.Clear();
            }

            return _datasReader;
        }

        public static void Clear(PathType type)
        {
            string path = PathBinary.GetPath(type);

            if (File.Exists(path))
            {

                File.Delete(path);
            }
        }

        public static void Clear()
        {
            //  Array arrayEnum = Enum.GetValues(typeof(Items));
            Array enums = Enum.GetValues(typeof(PathType));

            

            for(int i = 0; i < enums.Length; i++)
            {
                PathType p =(PathType)enums.GetValue(i);
                Clear(p);
            }

        }

        public static List<string> ReadListString(PathType type)
        {
            string content = null;
            string path = PathBinary.GetPath(type);
            List<string> list = new List<string>();

            if (File.Exists(path))
            {
                try
                {
                    using (BinaryReader reader =
                        new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        while (reader.PeekChar() > -1)
                        {
                            content = reader.ReadString();
                            list.Add(content);
                        }
                    }
                }
                catch (Exception)
                {

                }
            }

            return list;
        }

        public static string Read(PathType type)
        {
            string content = null;
            string path = PathBinary.GetPath(type);

            if (File.Exists(path))
            {
                try
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        content = reader.ReadString();
                    }
                }
                catch { }
            }

            return content;
        }

    }
}
