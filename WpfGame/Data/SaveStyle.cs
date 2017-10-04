using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGame.Data
{
    public class SaveStyle
    {
      //private const string  _path = "Resourse\\StyleName.txt";
        private string _path;
        FileInfo fileStyleName;

        public SaveStyle(string path)
        {
            this._path = path;
            fileStyleName = new FileInfo(_path);
        }


        public void SaveStyleName(string style)
        {
            if (IsExistFile() == true)
            {
                File.WriteAllText(_path, String.Empty);

                using (FileStream fstream = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    if (style != null)
                    {
                        byte[] array = System.Text.Encoding.Default.GetBytes(style);
                        fstream.Write(array, 0, array.Length);
                    }

                }
            }
        }

        public string GetStyleName()
        {
            string StyleName = string.Empty;

            if (IsExistFile() == true)
            {

                using (FileStream fstream = File.OpenRead(_path))
                {

                    byte[] array = new byte[fstream.Length];

                    fstream.Read(array, 0, array.Length);
                    StyleName = System.Text.Encoding.Default.GetString(array);

                }
            }

            return StyleName;
        }

        public bool IsExistFile()
        {
            if (fileStyleName.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Write(string text)
        {
            using (StreamWriter sw = new StreamWriter(_path, true, System.Text.Encoding.Default))
            {

                sw.WriteLine(text);
            }
        }
    }
}
