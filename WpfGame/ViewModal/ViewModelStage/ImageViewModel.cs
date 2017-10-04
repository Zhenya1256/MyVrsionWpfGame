using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfGame.Data;
using WpfGame.View;
using WpfGme.UiEntites.GamePlay;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.ViewModal.ViewModelStage
{
    public enum ViewINfoType
    {
        Error,
        Right,
        ErrorAndRight
    }


    public class ImageViewModel
    {
        private List<ReaderEntety> _fileStream;
        private List<ReaderEntety> _readThrms;
        private List<ReaderEntety> _qution;


        private ReadStrategy _read;
        static List<ReaderEntety> data;

        public ImageViewModel()
        {
            _read = new ReadStrategy();
           
            data = Binary.ReadList(PathType.FilesArchiv);
            _fileStream = _read.Read(data);
            _readThrms = _read.ReadThems(data);
            _qution = _read.ReadQiation(data);


        }

        public MemoryStream AddText(MemoryStream memoryStream,
            string text)
        {
            MemoryStream _output = new MemoryStream();
            string str = Encoding.UTF8.GetString(memoryStream.ToArray());
            Image img = Image.FromStream(memoryStream);
            int fontSize = 280;
            Font font = new Font("Arial", fontSize, FontStyle.Bold,
                GraphicsUnit.Pixel);
            System.Drawing.Color color =
                System.Drawing.Color.FromArgb(100, 0, 0, 0);
            Point point =
                new Point(img.Width / 2 - fontSize / 2, img.Height / 2 - fontSize / 2);
            SolidBrush brush = new SolidBrush(color);
            Graphics graphics = Graphics.FromImage(img);

            graphics.DrawString(text, font, brush, point);
            img.Save(_output, ImageFormat.Png);
            img.Dispose();
            graphics.Dispose();

            return _output;
        }

        public static Image GetImage(ViewINfoType type)
        {
            Image image = null;

            switch (type)
            {
                case ViewINfoType.Right:
                    image = Image.FromFile("Resourse\\Right.png");

                    break;
                case ViewINfoType.Error:
                    image = Image.FromFile("Resourse\\Error.png");
                    break;
                case ViewINfoType.ErrorAndRight:
                    image = Image.FromFile("Resourse\\RightAndError.png");
                    break;
            }

            return image;
        }

        public Image AddImage(Image current, ViewINfoType type)
        {
            Image image = GetImage(type);

            return image;
        }

        public  MemoryStream AddImage(MemoryStream current, ViewINfoType type)
        {
            MemoryStream outStream = new MemoryStream();
            MemoryStream changeSize = current;
            if (current != null)
            {
                if (type == ViewINfoType.Error)
                {
                    changeSize = ChangeSize(current, 150, 150);
                }

                using (Image image = Image.FromStream(changeSize)) //оригинал
                using (Image watermarkImage = GetImage(type)) //вотемарк 
                using (Graphics imageGraphics = Graphics.FromImage(image))
                using (System.Drawing.Brush watermarkBrush = new TextureBrush(watermarkImage))
                {
                    

                    int x = (image.Width - watermarkImage.Width) / 2;
                    int y = (image.Height - watermarkImage.Height) / 2;
                    imageGraphics.FillRectangle(watermarkBrush,
                        new Rectangle(new Point(0, 0), watermarkImage.Size));
                    image.Save(outStream, ImageFormat.Png); 
                }
            }
            
       

            return outStream;
        }

        public static System.Windows.Controls.Image AddControlImage(MemoryStream stream,
             System.Windows.Controls.Image source)
        {
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.CacheOption = BitmapCacheOption.OnLoad;
            imageSource.StreamSource = stream;
            imageSource.EndInit();
            source.Source = imageSource;

            imageSource.StreamSource.Close();
            imageSource.StreamSource.Dispose();

            return source;

        }

        public MemoryStream ChangeSize(MemoryStream current)
        {
            MemoryStream mem = new MemoryStream();
            Image source = Image.FromStream(current);
            int height = 215;
            int width = 215;
            Bitmap bmp = new Bitmap(width, height);
            Graphics graphicsImage = Graphics.FromImage(bmp);

            graphicsImage.DrawImage(source, 0, 0, width, height);

            bmp.Save(mem, ImageFormat.Png);

            return mem;
        }

        public MemoryStream ChangeSize(MemoryStream current, int width, int height)
        {
            MemoryStream mem = new MemoryStream();
            Image source = Image.FromStream(current);
            Bitmap bmp = new Bitmap(width, height);
            Graphics graphicsImage = Graphics.FromImage(bmp);

            graphicsImage.DrawImage(source, 0, 0, width, height);

            bmp.Save(mem, ImageFormat.Png);

            return mem;
        }


        public static System.Windows.Media.Brush GetColor
            (System.Windows.Controls.Image imageCurrent,
            System.Windows.Media.Color currentColorText)
        {
            BitmapSource bitmapImage = imageCurrent.Source as BitmapSource;

            using (var outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                var bitmap = new System.Drawing.Bitmap(outStream);
                System.Windows.Media.Brush br = null;

                double R = 0;
                double G = 0;
                double B = 0;
                if (bitmap.Height >= 180)
                {
                    for (int i = 10; i < 200; i++)
                    {
                        for (int j = 180; j < 200; j++)
                        {
                            System.Drawing.Color color = bitmap.GetPixel(i, j);
                            R += color.R;
                            B += color.B;
                            G += color.G;
                        }
                    }
                    R = R / 3800;
                    G = G / 3800;
                    B = B / 3800;
                }
                else
                {
                    br = new SolidColorBrush
                        (System.Windows.Media.Color.FromArgb(0,0,0,0));

                    return br;
                }
                int result=-1;

      

                byte Rc = currentColorText.R;
                byte Gc = currentColorText.G;
                byte Bc = currentColorText.B;
                System.Windows.Media.Color outcolor =
                    System.Windows.Media.Color.FromRgb(Rc, Gc, Bc);

                byte max = MaxRGB(Rc, Gc, Bc);
                result = Volidate(max, (byte)R, Rc);
                if(result != -1)
                {
                    outcolor= System.Windows.Media.Color.
                       FromRgb((byte)(result), Gc, Bc);
                    br = new SolidColorBrush(outcolor);
                    return br;
                }

               else if (result == -1)
                {
                    result = Volidate(max, (byte)G, Gc);

                    if (result != -1)
                    {
                        outcolor= System.Windows.Media.Color.
                           FromRgb(Rc, (byte)(result), Bc);
                        br = new SolidColorBrush(outcolor);
                        return br;
                    }
                }
                else if (result == -1)
                {
                    result = Volidate(max, (byte)B, Bc);

                    if (result != -1)
                    {
                        outcolor = System.Windows.Media.Color.
                           FromRgb(Rc, Gc, (byte)(result));
                        br = new SolidColorBrush(outcolor);
                        return br;
                    }
                }
                br = new SolidColorBrush(outcolor);

                return br;
            }
        }

        private static byte MaxRGB(byte r, byte b, byte g)
        {
            if (r < b && b>g)
            {
                return b;
            }
            if(r>b && r > g)
            {
                return r;
            }
            if (g > b && r< g)
            {
                return g;
            }

            return g;
        }

        private static int Volidate(int max,byte rgb,byte c) 
        {
            int delta = 100;

            if (max == c)
            {
                if (max - delta <= rgb && rgb - delta <= max)
                {
                    if (max > 128)
                    {
                        delta = max + delta;
                    }
                    else
                    {
                        delta = max - delta;
                    }
                    if (delta > 254)
                    {
                        delta = delta-160;
                    }
                    if (delta < 1)
                    {
                        delta = delta + 160;
                    }

                    return delta;
                }
                //else if (rgb - delta <= max)
                //{
                //    delta = max - delta;
                   
                //    return delta;
                //}
            }

            return -1;
        }

        #region File

        public List<ReaderEntety> GetFiles(string stage)
        {
            List<ReaderEntety> fileStream =
                new List<ReaderEntety>();
            int i = 1;

            foreach (ReaderEntety s in _fileStream)
            {
                if (s.NameFile.Split('\\')[0].Contains(stage))
                {
                    MemoryStream stream = s.ContenFiles;
                    stream = AddText(stream, i.ToString());
                    ReaderEntety entety =
                        new ReaderEntety();
                    entety.NameFile = s.NameFile;
                    entety.ContenFiles = stream;
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

            foreach (ReaderEntety s in _readThrms)
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

        public ReaderEntety GetQution(int nomer, string them)
        {
            ReaderEntety listQutions =
                new ReaderEntety();
            List<ReaderEntety> list = GetThems(them);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].NameFile.Contains(".txt"))
                {
                    list.RemoveAt(i);
                }
            }

            ReaderEntety reader = list[nomer - 1];

            string path = reader.NameFile;

            while (path.Contains(".txt"))
            {
                reader = list[nomer];
                path = reader.NameFile;
                nomer++;
            }

            path = path.Replace
                (path.Split('\\')[path.Split('\\').Length - 1], "");

            foreach (var s in _qution)
            {
                if (s.NameFile.Contains(path))
                {
                    if (s.NameFile.Contains(".txt"))
                    {
                        listQutions.ContenFilesTxt = s.ContenFiles;
                    }
                    else
                    {
                        listQutions.ContenFiles = s.ContenFiles;
                        listQutions.NameFile = s.NameFile;
                    }
                }
            }

            return listQutions;
        }

        #endregion

    }
}
