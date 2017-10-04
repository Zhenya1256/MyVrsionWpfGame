using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGame.Data
{
   public class EnterArhiv
    {
        private string _path;
        private string _login;
        private string _password;

        //public Enter(string path , string login, string password)
        //{
        //    _path = path;
        //    _login = login;
        //    _password = password;
        //}
        public EnterArhiv()
        {
                
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
    }
}
