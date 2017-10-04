using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfGame.Data;
using WpfGame.View;
using WpfGame.ViewModal.ViewModelStage;
using WpfGame.WorkWithCommad.Implement;
using WpfGme.UiEntites.GamePlay;
using WpfGame.WorkWithCommad.Abstract;
using WpgGame.SaveBinaryFormat;
using WpfGame.ViewModal.StaticClass;

namespace WpfGame.ViewModal
{
    public class ChooseStageViewModal : ViewModelBase
    {
        private static IMainWindowsCodeBehind _codeBehind;
        private RelayCommand _startPlayCommand;
        private ImageViewModel _imageModel;
        ReadStrategy read = new ReadStrategy();
        List<ReaderEntety> filesEntety = new List<ReaderEntety>();

        public ChooseStageViewModal(IMainWindowsCodeBehind codeBehind)
        {
            _codeBehind = codeBehind;
            // filesEntety = read.Read();
            _imageModel = new ImageViewModel();


                _codeBehind.LoadView(ViewType.Thems);
            ViewChooseStag.LoadThems += ViewChooseStag_LoadThems;      

        }

 

        private void ViewChooseStag_LoadThems()
        {

            _codeBehind.LoadView(ViewType.Thems);
        }

        public ChooseStageViewModal()
        {
            _codeBehind.LoadView(ViewType.Main);
        }

        ObservableCollection<TeamGroup> _group1;
        public ObservableCollection<TeamGroup> Group1
        {
          

            get
            {
                if (ComposedStage.Stage.Equals("5"))
                {
                    return new ObservableCollection<TeamGroup>();
                }
                if (_group1 == null)
                {
                    _group1 = new ObservableCollection<TeamGroup>();
                    int i = 0;

                    List<TeamGroup> dataTeam =
                        Binary.ReadTeamGroup(PathType.Groups1);

                    if (dataTeam.Count == 0)
                    {
                        dataTeam = TempDir.TempGrops.groups1;
                    }
                   
                    foreach (var s in dataTeam
                        .OrderByDescending((x) => x.Point))
                    {
                        if (i == 4)
                        {
                            break;
                        }

                        _group1.Add(s);
                        i++;
                    }

                    for(int j = 1; j < 5; j++)
                    {
                        _group1[j-1].Position = j;
                    }

                    Binary.Clear(PathType.Groups1);
                    Binary.Write(_group1.ToList(), PathType.Groups1);
                }

                return _group1;
            }

        }

        ObservableCollection<TeamGroup> _group2;
        public ObservableCollection<TeamGroup> Group2
        {
            get
            {
                if (ComposedStage.Stage.Equals("5"))
                {
                    return new ObservableCollection<TeamGroup>();
                }
                if (_group2 == null)
                {
                    _group2 = new ObservableCollection<TeamGroup>();
                    int i = 0;
                    List<TeamGroup> dataTeam =
                      Binary.ReadTeamGroup(PathType.Groups2);

                    if (dataTeam.Count == 0)
                    {
                        dataTeam = TempDir.TempGrops.groups2;
                    }
                  
                    foreach (var s in dataTeam
                        .OrderByDescending((x) => x.Point))
                    {
                        if (i == 4)
                        {
                            break;
                        }

                        _group2.Add(s);
                        i++;
                    }

                    for (int j = 1; j < 5; j++)
                    {
                       _group2[j - 1].Position = j;
                     //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    }

                    Binary.Clear(PathType.Groups2);
                    Binary.Write(_group2.ToList(), PathType.Groups2);
                }

                return _group2;
            }
        }

        ObservableCollection<TeamGroup> _group3;
        public ObservableCollection<TeamGroup> Group3
        {
            get
            {
                if (ComposedStage.Stage.Equals("5"))
                {
                    return new ObservableCollection<TeamGroup>();
                }
                    if (_group3 == null)
                    {
                        _group3 = new ObservableCollection<TeamGroup>();
                        int i = 0;
                        List<TeamGroup> dataTeam =
                       Binary.ReadTeamGroup(PathType.Groups3);

                        if (dataTeam.Count == 0)
                        {
                            dataTeam = TempDir.TempGrops.groups3;
                        }

                        foreach (var s in dataTeam
                            .OrderByDescending((x) => x.Point))
                        {
                            if (i == 4)
                            {
                                break;
                            }

                            _group3.Add(s);
                            i++;
                        }

                        if (_group3.Count != 0)
                        {
                            for (int j = 1; j < 5; j++)
                            {
                                _group3[j - 1].Position = j;
                            }
                        }

                        Binary.Clear(PathType.Groups3);
                        Binary.Write(_group3.ToList(), PathType.Groups3);
                    }
                
                return _group3;
            }
        }

        ObservableCollection<TeamGroup> _group4;
        public ObservableCollection<TeamGroup> Group4
        {
            get
            {
                if (ComposedStage.Stage.Equals("5"))
                {
                    return new ObservableCollection<TeamGroup>();
                }
                if (_group4 == null)
                {
                    _group4 = new ObservableCollection<TeamGroup>();
                    int i = 0;
                    List<TeamGroup> dataTeam =
               Binary.ReadTeamGroup(PathType.Groups4);

                    if (dataTeam.Count == 0)
                    {
                        dataTeam = TempDir.TempGrops.groups4;
                    }

                    foreach (var s in dataTeam
                        .OrderByDescending((x) => x.Point))
                    {
                        if (i == 4)
                        {
                            break;
                        }

                        _group4.Add(s);
                        i++;
                    }

                    if (_group4.Count != 0)
                    {
                        for (int j = 1; j < 5; j++)
                        {
                            _group4[j - 1].Position = j;
                        }
                    }

                    Binary.Clear(PathType.Groups4);
                    Binary.Write(_group4.ToList(), PathType.Groups4);
                }

                return _group4;
            }
        }

        public System.Windows.Input.ICommand NextThems
        {
            get
            {

                _startPlayCommand = new RelayCommand
                    (ExecuteStartPlyCommand, (p) => true);

                return _startPlayCommand;
            }
        }

        public void ExecuteStartPlyCommand(object parameter)
        {
            if (ComposedStage.Stage == "4")
            {
                _codeBehind.LoadView(ViewType.ThemsFour);
            }
            else
            {
                _codeBehind.LoadView(ViewType.Thems);
            }

        }
    }
}
