using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.MessageCreateCommnds
{
   public static class CommandMessge
    {
        private readonly static Dictionary<ErrorType, string> _errorsDictionary;

        static CommandMessge()
        {
            _errorsDictionary = new Dictionary<ErrorType, string>();
            Initialize();
        }

        private static void Initialize()
        {
            _errorsDictionary.Add(ErrorType.IsEmpty, "Назва команди не може містити пробіли");
            _errorsDictionary.Add(ErrorType.ExistCommand, "Команда з такою назвою існує");
            _errorsDictionary.Add(ErrorType.CreatName, "Придумайте имя команди");
            _errorsDictionary.Add(ErrorType.AllCommands, "16 команд вже добавлено");
            
        }

        public static string GetErrorMessag(ErrorType type)
        {
            if (_errorsDictionary.ContainsKey(type))
            {
                return _errorsDictionary[type];
            }

            return null;
        }
    }
}
