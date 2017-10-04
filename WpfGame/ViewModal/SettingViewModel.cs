using SharpCompress.Reader;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;
using WpfGame.Data;
using WpfGame.OpenArchive;
using WpfGame.OpenArchive.Implement;
using WpfGame.ViewModal.ViewModelStage;
using WpfGame.WorkWithCommad.Implement;
using WpfGme.UiEntites.GamePlay;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.ViewModal
{
    public class SettingViewModel : ViewModelBase
    {
        private IMainWindowsCodeBehind _codeBehind;
        private RelayCommand _startPlayCommand;
        public static bool IsSettingPlay;
        public static bool IsSettingCommand = false;
        DownLoadArchive _downLoad;
        event Action<string> MessageChanged;

        public SettingViewModel()
        {
        }

        public SettingViewModel(IMainWindowsCodeBehind codeBehind)
        {
            _codeBehind = codeBehind;
            MessageChanged += (str) => { str = ""; };
        }

        string _currentClient;
        int index = 1;
        public string Title
        {
            get
            {
                //if (_currentClient == null) 
                //    _currentClient = "command"+index;
                //index++;
                return _currentClient;
            }
            set
            {
                _currentClient = value;
                OnPropertyChanged("Title");
            }
        }

        public ICommand PathPacket
        {
            get
            {
                _startPlayCommand = new RelayCommand
                    (ExecutePathCommand, (p) => true);

                return _startPlayCommand;
            }

        }

        public async void ExecutePathCommand(object parameter)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _downLoad = new DownLoadArchive();

            _downLoad.Show();
            await ArchiveLoad(openFileDialog1.FileName);
        }

        private async Task ArchiveLoad(string path)
        {
            IDataResult<LoaderEntyity> dataResult = null;
            //Action<string> action = GetText;
            string message = "";

            await Task.Factory.StartNew(() =>
            {
                List<string> files = null;
                try
                {
                    files = Read(path);
                }
                catch (Exception)
                {
                    message =
                   ErrorMessageHolder.GetErrorMessag(ErrorType.NonFormat);
                }

                if (files != null)
                {
                    FilesEntety file = new FilesEntety();
                    file.PathArchiv = path;
                    file.PathFile = files;

                    ArchiveLoader ar = new ArchiveLoader();
                    dataResult = ar.DataResult(file);
                    LoaderEntyity load = dataResult.Data;
                  //  Files.filesStream = load.FilesData;

                    if (dataResult.Data == null)
                    {
                        message = dataResult.Message;
                        IsSettingPlay = false;
                    }
                    else
                    {
                        message = dataResult.Message;
                        IsSettingPlay = true;
                    }
                }

                //if (message.Equals(String.Empty))
                //{
                //    message =
                //    ErrorMessageHolder.GetErrorMessag(ErrorType.NonFormat);
                //}

            }).ContinueWith(result =>
            {
                _downLoad.textBlock.Text = message;
                _downLoad.ProgressBar.Visibility = Visibility.Hidden;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public List<string> Read(string location)
        {
            List<string> filesStream = null;

            using (Stream stream = File.OpenRead(location))
            {
                IReader reader = ReaderFactory.Open(stream);
                filesStream = new List<string>();

                while (reader.MoveToNextEntry())
                {
                    filesStream.Add(reader.Entry.FilePath);
                }
            }

            return filesStream;
        }

        public ICommand BackStartPage
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
            _codeBehind.LoadView(ViewType.Main);
        }

       // #region create and save command

       //public  RelayCommand _addCommand;
       // public RelayCommand _saveCommand;

       // private Phone selectedPhone;

       // public Phone SelectedPhone
       // {
       //     get {
       //         if (selectedPhone == null)
       //         {
       //             selectedPhone = new Phone();          

       //         }
       //         return selectedPhone;
       //     }
       //     set
       //     {
       //         Phone ph = new Phone();
       //         selectedPhone = ph;
       //         OnPropertyChanged("SelectedPhone");
       //     }
       // }

       // public static ObservableCollection<Phone> Phones { get;  } = 
       //     new ObservableCollection<Phone>();

       // public RelayCommand SaveCommand
       // {
       //     get
       //     {
       //         return _saveCommand ??
       //           (_saveCommand = new RelayCommand(obj =>
       //           {
       //               SaveStyle commands =
       //               new SaveStyle("Resourse\\Commands.txt");

       //               foreach (var item in Phones)
       //               {
       //                   commands.Write(item.ToString());
       //               }

       //               System.Windows.MessageBox.Show("Збереження пройшло успішно");
       //           },
       //           (obj) => Phones != null && Phones.Count == Phone.MaxCountCommand));

          
       //     }
       // }


       // //public ICommand AddCommand
       // //{
       // //    //get
       // //    //{
       // //    //    _startPlayCommand = new RelayCommand
       // //    //       (ExecuteAddCommandCommand, (obj) =>
       // //    //       Phones.Count <= Phone.MaxCountCommand &&
       // //    //      Phones.Count != Phone.MaxCountCommand);
       // //    //    return _startPlayCommand;


       // //          //  _addCommand ??
       // //          //(_addCommand = new RelayCommand(obj =>
       // //          //{
       // //          //    Phone phone = SelectedPhone;                      
       // //          //    Phones.Add(phone);
       // //          //    selectedPhone = null;
       // //          //    SelectedPhone = null;
       // //          //    //  SelectedPhone = phone;
       // //          //},
       // //          //(obj) => Phones.Count <= Phone.MaxCountCommand && 
       // //          //Phones.Count != Phone.MaxCountCommand));
       // //    }
       // //}
       // //private void ExecuteAddCommandCommand(object parameter)
       // //{
       // //    Phone phone = SelectedPhone;
       // //    Phones.Add(phone);
       // //    selectedPhone = null;
       // //    SelectedPhone = null;
       // //}



       // //public event PropertyChangedEventHandler PropertyChanged;

       // //public void OnPropertyChanged([CallerMemberName]string prop = "")
       // //{
       // //    if (PropertyChanged != null)
       // //        PropertyChanged(this, new PropertyChangedEventArgs(prop));
       // //}

       // #endregion


        #region Groups

        public List<TeamGroup> CommandsOne
        { get
            {
                if (createCommands == null)
                {
                    return new List<TeamGroup>();
                }
                return createCommands.CommandsOne;
            }
        }
        public List<TeamGroup> CommandsTwo
        {
            get
            {
                if (createCommands == null)
                {
                    return new List<TeamGroup>();
                }
                return createCommands.CommandsTwo;
            }
        }
        public List<TeamGroup> CommandsThree
        {
            get
            {
                if (createCommands == null)
                {
                    return new List<TeamGroup>();
                }
                return createCommands.CommandsThree;
            }
        }
        public List<TeamGroup> CommandsFour
        {
            get
            {
                if (createCommands == null)
                {
                    return new List<TeamGroup>();
                }
                return createCommands.CommandsFour;
            }
        }

        #endregion


        RandomCreateCommands createCommands = 
            new RandomCreateCommands(HolderGroup.Commands);
        public RelayCommand _viewCommand;

        public RelayCommand ViewCommand
        {
            get
            {
                return _viewCommand ??
                  (_viewCommand = new RelayCommand(obj =>
                  {
                    
                      RandomCommands command = new RandomCommands();
                      TempDir.TempGrops.groups2 = GetTeam(CommandsTwo);
                      TempDir.TempGrops.groups1 = GetTeam(CommandsOne);
                    
                      
                      TempDir.TempGrops.groups3 = GetTeam(CommandsThree);
                      TempDir.TempGrops.groups4 = GetTeam(CommandsFour);
                      //
                      Write(HolderGroup.Commands, PathType.AllCommands);
                      //
                      Write(TempDir.TempGrops.groups1, PathType.Groups1);
                      Write(TempDir.TempGrops.groups2, PathType.Groups2);
                      Write(TempDir.TempGrops.groups3, PathType.Groups3);
                      Write(TempDir.TempGrops.groups4, PathType.Groups4);

                      command.Show();
                      IsSettingCommand = true;
                  },
                  (obj) => HolderGroup.Commands != null && HolderGroup.Commands.Count == 16));
            }
        }

        private List<TeamGroup> GetTeam(List<TeamGroup> g)
        {
            List<TeamGroup> list = new List<TeamGroup>();

            foreach (var s in g)
            {
                list.Add(s);
            }

            return list;
        }

        private void Write(List<TeamGroup> data, PathType type)
        {
            Binary.Clear(type);
            Binary.Write(data, type);
        }
    }
}
