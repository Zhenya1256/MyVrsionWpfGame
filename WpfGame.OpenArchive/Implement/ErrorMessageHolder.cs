using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.OpenArchive.Implement
{
    public static class ErrorMessageHolder 
    {
        private readonly static Dictionary<ErrorType, string> _errorsDictionary;

        static ErrorMessageHolder()
        {
            _errorsDictionary = new Dictionary<ErrorType, string>();
            Initialize();
        }

        private static void Initialize()
        {
            _errorsDictionary.Add(ErrorType.Stage, "не має стеджу");
            _errorsDictionary.Add(ErrorType.Picture, "не має картінок");
            _errorsDictionary.Add(ErrorType.Sub, "не має саб");
            _errorsDictionary.Add(ErrorType.NameThems, "не має тем");
            _errorsDictionary.Add
                (ErrorType.FileWithPicture, "не має файлів з картнками");
            _errorsDictionary.Add(ErrorType.FileWithData, "не має файлів");
            _errorsDictionary.Add(ErrorType.Description, "не має опис");
            _errorsDictionary.Add(ErrorType.Default, "не піддержується");
            _errorsDictionary.Add(ErrorType.NonFormat, 
                "Повинен бути архів з розштренням:" +
                                "Rar,Zip,GZip2,Tar");
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
