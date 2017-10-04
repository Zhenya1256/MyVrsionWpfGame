using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.StaticClasses
{
   public static class StageFife
    {
        private  static int _index = 4;


        public static int Index
        {
            get
            {
                return GetIndex();
            }
            set
            {
                _index = value;
                Binary.WriteNomer(_index.ToString(),
                     PathType.NomerCommandsForFifeStage);

            }
        }
        
        private static int GetIndex()
        {      
            string i =Binary.Read
                (PathType.NomerCommandsForFifeStage);
            if (i != null)
            {
                _index = int.Parse(i);
            }

            return _index;
            ///////// NomerCommandsForFifeStage
        } 

    }
}
