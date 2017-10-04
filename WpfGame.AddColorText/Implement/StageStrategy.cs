using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGme.UiEntites.GamePlay;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace WpfGame.AddColorText.Implement
{
    public class StageStrategy
    {
        private const int NUMBERSTAGE = 5;
        private Stages stage;

        public StageStrategy(List<ReaderEntety> archiv)
        {
            stage = new Stages(archiv);
        }

        public List<StageEntety> Stratage()
        {
            List<StageEntety> listStages = new List<StageEntety>();
            for (int i = 1; i <= NUMBERSTAGE; i++)
            {
                List<ReaderEntety> sub = stage.GetSub(i.ToString());
                int nomerSub = 1;
                foreach(var currentSub in sub)
                {
                    string name = currentSub.NameFile;
                   
                    List<ReaderEntety> thems = stage.GetThems(name);
                    List<Image> images = CurrentIMages(thems);
                    List<Color> listColor= WorkWithImage(images);
                    StageEntety entety = new StageEntety();
                    entety.ListColor = listColor;
                    entety.Stage = i;
                    entety.Sub = nomerSub;
                    listStages.Add(entety);
                    nomerSub++;
                }
            }

            return listStages;
        }

        private List<Color> WorkWithImage(List<Image> images)
        {
            List<Color> listColor = new List<Color>();

            for (int k = 0; k < images.Count; k++)
            {
                images[k] = ChangeSize(images[k]);
                Color color = GetColor(images[k]);
                listColor.Add(color);
            }

            return listColor;
        }

        private Color GetColor(Image image)
        {
            var bitmap = new System.Drawing.Bitmap(image);
            List<ColorEntety> colors = new List<ColorEntety>();

            for (int i = 10; i < 140; i++)
            {
                for (int j = 110; j < 140; j++)
                {
                    System.Drawing.Color color = bitmap.GetPixel(i, j);
                    ColorEntety entety = new ColorEntety();
                    entety.CurrentColor = color;
                    entety.number += 1;
                    colors= Volidate(colors, entety);
                   

                }
            }
            Color colo=new Color();
            foreach (var s in colors.OrderByDescending((x) => x.number))
            {
                colo = s.CurrentColor;
                break;
            }
           
            return colo;
        }

        private List<ColorEntety> Volidate
            (List<ColorEntety> vol, ColorEntety entety)
        {
            bool isEqual  =false;
            foreach (var s in vol)
            {
                Color color = s.CurrentColor;
                byte r1 = color.R;
                byte g1 = color.G;
                byte b1 = color.B;
                Color currentColor = entety.CurrentColor;
                byte r2 = currentColor.R;
                byte g2 = currentColor.G;
                byte b2 = currentColor.B;

                if ((r2 <= r1+5 && r1 <= r2 + 5 )
                    && (g2 <= g1 + 5 && g1 <= g2 + 5)
                    && (b2 <= b1 + 5 && b1 <= b2 + 5)
                    )
                {
                    s.number += 1;
                    isEqual = true;
                    break;
                }
            }

            if (!isEqual)
            {
                vol.Add(entety);
            }

            return vol;
        }

        private List<Image> CurrentIMages(List<ReaderEntety> thems)
        {
            List<Image> listImage = new List<Image>();

            foreach (var n in thems)
            {
                if (!n.NameFile.Contains(".mp3") && !n.NameFile.Contains(".txt"))
                {
                    Image image = GetImage(n.ContenFiles,n.NameFile);
                    listImage.Add(image);
                }

              
            }

            return listImage;
        }

        private Image GetImage(MemoryStream file,string na)
        {
            Image image = Image.FromStream(file);

            return image;
        }

        private Image ChangeSize(Image source)
        {
            MemoryStream mem = new MemoryStream();
            int width = 150;
            int height = 150;
            Bitmap bmp = new Bitmap(width, height);
            Graphics graphicsImage = Graphics.FromImage(bmp);

            graphicsImage.DrawImage(source, 0, 0, width, height);

            bmp.Save(mem, ImageFormat.Png);

            return GetImage(mem,"234567");
        }
    }
}
