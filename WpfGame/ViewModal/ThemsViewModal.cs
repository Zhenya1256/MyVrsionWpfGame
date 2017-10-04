using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfGame.View;
using WpfGame.ViewModal.StaticClass;


namespace WpfGame.ViewModal
{
    public class ThemsViewModal : ViewModelBase
    {
        private static IMainWindowsCodeBehind _codeBehind;
        private RelayCommand _startPlayCommand;
        ViewThems wt = new ViewThems();

        public ThemsViewModal(IMainWindowsCodeBehind codeBehind)
        {
            _codeBehind = codeBehind;
          //  wt.action += ThemsViewModal_action;
        }

        public ThemsViewModal()
        {
            Group.TeamGroups.Clear();
            _codeBehind.LoadView(ViewType.ChooseStage);
        }

        //public ThemsViewModal(string stage)
        //{
        //    _codeBehind.LoadView(ViewType.Thems);
        //}

        private  void ThemsViewModal_action()
        {

            Group.TeamGroups.Clear();
            _codeBehind.LoadView(ViewType.ChooseStage);
        }

        public ICommand StartGame
        {
            get
            {
                _startPlayCommand = new RelayCommand
                    (ExecuteStartPlayCommand, PlayCommand);

                return _startPlayCommand;
            }
        }

        //public ICommand BackStagePage
        //{
        //    get
        //    {
        //        _startPlayCommand = new RelayCommand
        //            (ExecuteBackCommand, BackCommand);

        //        return _startPlayCommand;
        //    }
        //}

        public bool PlayCommand(object parameter)
        {
            return true;
        }

        public bool BackCommand(object parameter)
        {
            //ViewThems thems = new ViewThems();
            // foreach(var s in thems.Panels())
            //{
            //    if (s.Children.Count != 1)
            //    {
            //        return false;

            //    }
            //}

            return true;
        }

        public ICommand NextTimer
        {
            get
            {
                _startPlayCommand = new RelayCommand
                    (ExecuteNextTimerCommand, (x)=>true);

                return _startPlayCommand;
            }

        }

        //ConMenu



        public void ExecuteBackCommand(object parameter)
        {
            Group.TeamGroups.Clear();
            _codeBehind.LoadView(ViewType.ChooseStage);
        }

        public void ExecuteStartPlayCommand(object parameter)
        {
            _codeBehind.LoadView(ViewType.PLay);
        }

        public void ExecuteNextTimerCommand(object parameter)
        {
            _codeBehind.LoadView(ViewType.PLay);
        }
    }
}
