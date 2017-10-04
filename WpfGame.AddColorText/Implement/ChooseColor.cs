using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.AddColorText.Abstarct;
using WpfGme.UiEntites.GamePlay;

namespace WpfGame.AddColorText.Implement
{
   public class ChooseColor
    {
        private StageStrategy _stageStrategy;
        private int delta = 100;

        public ChooseColor(List<ReaderEntety> archiv)
        {
            _stageStrategy = new StageStrategy(archiv);
        }

        public List<IResultColor> Chose()
        {
            List<IResultColor> listResult = new List<IResultColor>();

            foreach (var s in _stageStrategy.Stratage())
            {
              //  int i = 0;
                List<Color> listCurrentColors =
                    MyColor.GetColors();
               foreach (var color in s.ListColor)
                {
                    byte r1 = color.R;
                    byte g1 = color.G;
                    byte b1 = color.B;

                    for (int i = 0;i< listCurrentColors.Count; i++) 
                    {
                        Color color2 = listCurrentColors[i];

                        byte r2 = color2.R;
                        byte g2 = color2.G;
                        byte b2 = color2.B;



                        if ((r2 <= r1 + delta && r1 <= r2 + delta)
                      && (g2 <= g1 + delta && g1 <= g2 + delta)
                      && (b2 <= b1 + delta && b1 <= b2 + delta)
                      )
                        {
                            listCurrentColors.Remove(color2);
                        }
                        
                    }
                }
                IResultColor result = new ResultColor();
         
               if (listCurrentColors.Count == 0)
                {
                    result.Success = false;
                    result.Message = MessageHolder.Message(s.Stage,s.Sub);
                }
                else
                {
                    result.Success = true;
                    //не так все просто!!!!!
                    result.ColorText = listCurrentColors[0];
                }
                listResult.Add(result);
            }

            return listResult;
        }
    }
}
