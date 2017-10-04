using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGame.Data;

namespace ViewModal
{
    public class MainWindowViewModal : ViewModelBase
    {
        private EnterArhiv _enter;
     //   private static bool isSetting;

        public EnterArhiv CurrentEnter
        {
            get
            {
                if (_enter == null)
                {
                    _enter = new EnterArhiv();
                }

                return _enter;
            }
            set
            {
                _enter = value;
                OnPropertyChanged("CurrentEnter");
            }
        }

        //RelayCommand _openArhivCommand;
        //RelayCommand _pathPacketCommand;
        //RelayCommand _startPlayCommand;

        //public ICommand OpenArhiv
        //{
        //    get
        //    {
        //        if (_openArhivCommand == null)
        //        {
        //            _openArhivCommand = new RelayCommand
        //                (ExecuteOpenCommand, CanExecuteeOpenCommand);
        //        }

        //        return _openArhivCommand;
        //    }
        //}

        //public ICommand PathPacket
        //{
        //    get
        //    {
        //        if (_pathPacketCommand == null)
        //        {
        //            _pathPacketCommand = new RelayCommand
        //                (ExecutePathCommand, (parameter) => true);
        //        }

        //        return _pathPacketCommand;
        //    }
        //}

        //public ICommand StartPlay
        //{
        //    get
        //    {
        //        _startPlayCommand = new RelayCommand
        //            (ExecuteStartPlyCommand, (p) => true);

        //        return _startPlayCommand;

        //    }
        //}

        //public void ExecutePathCommand(object parameter)
        //{
        //    FolderBrowserDialog FBD = new FolderBrowserDialog();

        //    if (FBD.ShowDialog() == DialogResult.OK)
        //    {
        //        System.Windows.Forms.MessageBox.Show(FBD.SelectedPath);
        //    }
        //}

        public void ExecuteStartPlyCommand(object parameter)
        {
            //if (!isSetting)
            //{
            //    System.Windows.MessageBox.Show("Перейдіть до настройки ігри і авторизуйтеся");
            //}
            //else
            //{
            //    new MainWindow().Show();
            //}
        }

        public void ExecuteOpenCommand(object parameter)
        {
            //ReadStrategy r = new ReadStrategy();
            //r.Read(_enter.Login, _enter.Password);
            //isSetting = true;
        }

        public bool CanExecuteeOpenCommand(object parameter)
        {
            if (string.IsNullOrEmpty(CurrentEnter.Login) ||
                string.IsNullOrEmpty(CurrentEnter.Password))
            {
                return false;
            }

            return true;
        }


    }
}
