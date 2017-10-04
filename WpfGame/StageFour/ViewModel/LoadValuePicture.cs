using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.StageFour.ViewModel
{
   public class LoadValuePicture
    {
        private static bool CheckArchiv()
        {

            //check archive directiry name x1,x2,x3
            return false;
        }

        private static Dictionary<int,int> MyValuePicture()
        {
            Dictionary<int, int> pictures =
                new Dictionary<int, int>();

            for(int i = 1,j=2; i < 15; i = i + 4, j=j+4)
            {
                pictures.Add(i, 1);
                pictures.Add(j, 1);
            }

            for(int i = 3; i <= 16; i = i + 4)
            {
                pictures.Add(i, 2);
            }
            pictures.Add(8, 2);
            pictures.Add(16, 2);
            pictures.Add(4, 3);
            pictures.Add(12, 3);

            return pictures;
        }

        private static Dictionary<int,int> ArciveValuePicture()
        {
            Dictionary<int, int> pictures =
               new Dictionary<int, int>();

            return pictures;
        }

        public static Dictionary<int, int> ValuePicture()
        {

            if (CheckArchiv())
            {
                return ArciveValuePicture();
            }

            return MyValuePicture();
        }

        public static MemoryStream AddText(MemoryStream memoryStream,
            string text)
        {
            MemoryStream _output = new MemoryStream();
            string str = Encoding.UTF8.GetString(memoryStream.ToArray());
            Image img = Image.FromStream(memoryStream);
            int fontSize = 28;
            Font font = new Font("Arial", fontSize, FontStyle.Bold,
                GraphicsUnit.Pixel);
            System.Drawing.Color color =
                System.Drawing.Color.FromArgb(255, 255, 0, 0);
            Point point =
                new Point(img.Width  - fontSize*2, fontSize / 2);
            SolidBrush brush = new SolidBrush(color);
            Graphics graphics = Graphics.FromImage(img);

            graphics.DrawString(text, font, brush, point);
            img.Save(_output, ImageFormat.Png);
            img.Dispose();
            graphics.Dispose();

            return _output;
        }




    }
}
