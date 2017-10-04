using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using WpfGame.Data;
using System.Windows;
using System.Windows.Forms;
using WpfGme.UiEntites.GamePlay;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.ViewModal
{
    public class MainWindowViewModal : ViewModelBase
    {
        private IMainWindowsCodeBehind _codeBehind;
        private RelayCommand _startPlayCommand;

        public MainWindowViewModal(IMainWindowsCodeBehind codeBehind)
        {
            _codeBehind = codeBehind;
             
        }

       
        

        public ICommand StartPlay
        {
            get
            {
                _startPlayCommand = new RelayCommand
                    (ExecuteStartPlyCommand, (p)=>true);

                return _startPlayCommand;
            }
        }

        public ICommand Setting
        {
            get
            {
                _startPlayCommand = new RelayCommand
                    (ExecuteSettingCommand, (p) => true);

                return _startPlayCommand;
            }
        }

        public ICommand SettingButton
        {
            get
            {
                _startPlayCommand = new RelayCommand
                    (ExecuteSettingButCommand, (p) => true);

                return _startPlayCommand;
            }
        }

        public ICommand SettingStyle
        {
            get
            {
                _startPlayCommand = new RelayCommand
                    (ExecuteSettingStyleCommand, (p) => true);

                return _startPlayCommand;
            }
        }
        public ICommand SettingCommand
        {
            get
            {
                _startPlayCommand = new RelayCommand
                    (ExecuteSettingCreatCommand, (p) => true);

                return _startPlayCommand;
            }
        }

        private void ExecuteSettingStyleCommand(object parameter)
        {

            Binary.Clear(PathType.TabSetting);
            Binary.Write("2", PathType.TabSetting);
            _codeBehind.LoadView(ViewType.Setting);
           
        }

        private void ExecuteSettingCreatCommand(object parameter)
        {
            Binary.Clear(PathType.TabSetting);
            Binary.Write("3", PathType.TabSetting);
            _codeBehind.LoadView(ViewType.Setting);
          
        }

        private void ExecuteSettingCommand(object parameter)
        {

            Binary.Clear(PathType.TabSetting);
            Binary.Write("1", PathType.TabSetting);
            _codeBehind.LoadView(ViewType.Setting);
        
        }
        private void ExecuteSettingButCommand(object parameter)
        {

            Binary.Clear(PathType.TabSetting);
            Binary.Write("0", PathType.TabSetting);
            _codeBehind.LoadView(ViewType.Setting);
          
           // isSetting = true;
        }

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
            if (!SettingViewModel.IsSettingPlay)
            {
                SomeSetting some = new SomeSetting();
                SomeSettingViewModal vm = new SomeSettingViewModal(_codeBehind);

                if (SettingViewModel.IsSettingCommand)
                {
                    some.CommandImage();
                  
                }
                some.DataContext = vm;
                some.Show();
                //System.Windows.MessageBox.Show("Перейдіть до настройки ігри і авторизуйтеся");
            }
            else if (!SettingViewModel.IsSettingCommand)
            {
                SomeSetting some = new SomeSetting();
                some.SettingImage();
                SomeSettingViewModal vm = new SomeSettingViewModal(_codeBehind);
                some.DataContext = vm;
                some.Show();
            }
            else
            {
                _codeBehind.LoadView(ViewType.ChooseStage);
            }

        }

        //public void ExecuteOpenCommand(object parameter)
        //{
        //    ReadStrategy r = new ReadStrategy();
        //    r.Read(_enter.Login, _enter.Password);
        //    isSetting = true;
        //}

        //public bool CanExecuteeOpenCommand(object parameter)
        //{
        //    if (string.IsNullOrEmpty(CurrentEnter.Login) ||
        //        string.IsNullOrEmpty(CurrentEnter.Password))
        //    {
        //        return false;
        //    }       

        //    return true;
        //}

    }
}
