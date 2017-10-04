using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.ViewModal
{
    public class SomeSettingViewModal : ViewModelBase
    {
        private IMainWindowsCodeBehind _codeBehind;


        public SomeSettingViewModal(IMainWindowsCodeBehind codeBehind)
        {
            _codeBehind = codeBehind;



        }

        private RelayCommand _startPlayCommand;

        public ICommand Setting
        {
            get
            {
                _startPlayCommand = new RelayCommand
                    (ExecuteSettingCommand, (p) => true);

                return _startPlayCommand;
            }
        }

        private void ExecuteSettingCommand(object parameter)
        {

            Binary.Clear(PathType.TabSetting);
            Binary.Write("1", PathType.TabSetting);
            _codeBehind.LoadView(ViewType.Setting);

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

        private void ExecuteSettingCreatCommand(object parameter)
        {
            Binary.Clear(PathType.TabSetting);
            Binary.Write("3", PathType.TabSetting);
            _codeBehind.LoadView(ViewType.Setting);


        }

    }
}
