using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.AddColorText.Implement
{
    public class MessageHolder
    {
        public static string Message(int stage,int sub)
        {
            string mess ="Вибачте ми не підібрали колір"+
                " тексту для етапу (" + stage + ") Сиб (" + sub +")";

            return mess;
        }
    }
}
