using System;
using System.Collections.Generic;
using System.IO;

using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Linq;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

using WpfGame.ViewModal;
using WpfGame.ViewModal.StaticClass;
using WpfGame.ViewModal.TempDir;
using WpfGame.ViewModal.ViewModelStage;
using WpfGame.WorkWithCommad.Abstract;
using WpfGame.WorkWithCommad.Implement;
using WpfGme.UiEntites.GamePlay;
using WpgGame.SaveBinaryFormat;
using WpfGame.Data;
using WpfGame.ViewModal.Stages;
using WpfGame.Style;
using WpfGame.StageFour.View;
using WpfGame.StaticClasses;

namespace WpfGame.View
{
    /// <summary>
    /// Interaction logic for ViewChooseStage.xaml
    /// </summary>
    /// private bool
    public partial class ViewChooseStag : UserControl
    {
        private bool _isClose;
        private ImageViewModel model;
        private List<ReaderEntety> list;
        private List<Image> _listImage;
        private static Image _imageSave;
        private List<ListBox> _listBox;
        private List<TextBlock> _listBlock;
        public static event Action LoadThems;
        public static bool _stagefour = false;

        public ViewChooseStag()
        {
            InitializeComponent();
            _listImage = new List<Image>();
            _listBox = new List<ListBox>();
            _listBlock = new List<TextBlock>();
            InstalList();
            model = new ImageViewModel();
            StackPanelIsEnabled.Panels.Clear();
            this.Loaded += ViewChooseStage_Loaded;
        }

        private void GetTeamGroups(int nomer)
        {
            if (nomer == 0)
            {
                Group.TeamGroups = Binary.ReadTeamGroup(PathType.Groups1);
            }
            if (nomer == 1)
            {
                Group.TeamGroups = Binary.ReadTeamGroup(PathType.Groups2);
            }
            if (nomer == 2)
            {
                Group.TeamGroups = Binary.ReadTeamGroup(PathType.Groups3);
            }
            if (nomer == 3)
            {
                Group.TeamGroups = Binary.ReadTeamGroup(PathType.Groups4);
            }
            Binary.Clear(PathType.CurrentGroup);
            Binary.Write(Group.TeamGroups, PathType.CurrentGroup);
        }

        private void Write(int nomer)
        {


            if (PathFile.files.Count == 0)
            {
                PathFile.files =
                    Binary.ReadListString(PathType.ImageOrList);
            }

            if (list.Count == 1)
            {
                nomer = 0;
            }

            PathFile.files.Add(list[nomer].NameFile);
            Binary.Clear(PathType.ImageOrList);
            Binary.Write(PathFile.files, PathType.ImageOrList);
            PathFile.Path = list[nomer].NameFile;
            Binary.Clear(PathType.PathFile);
            Binary.Write(PathFile.Path, PathType.PathFile);
        }

        private void LoadedStages(object sender)
        {
            string stage = ComposedStage.Stage;
            list =
              model.GetFiles(ComposedStage.Stage);

            if (sender is Image)
            {
                Image img = (Image)sender;
                _imageSave = img;
            }
            int nomer = 0;

            if (_imageSave != null)
            {
                foreach (var s in _imageSave.Name)
                {
                    if (Char.IsDigit(s))
                    {
                        nomer = int.Parse(s.ToString());
                        break;
                    }
                }

                GetTeamGroups(nomer);
                Write(nomer);
            }

            if (ComposedStage.Stage.Equals("3"))
            {
                string stageThree = Binary.Read(PathType.BoolStageTree);

                if (stageThree == null)
                {
                    Binary.Write("1", PathType.BoolStageTree);
                    LoadThems.Invoke();
                    LookTheeStage look = new LookTheeStage();
                    look.DataContext = new LookTreeViewModel();
                    look.ShowDialog();

                }
                else
                {
                    StanTextBlock.Index++;
                    Binary.Clear(PathType.CurrentStage);
                    Binary.Write(StanTextBlock.Index.ToString(), PathType.CurrentStage);
                    ChangeColorStage();
                }
            }

        }

        private void LeaveImage(object sender, MouseEventArgs e)
        {
            LoadedStages(sender);
        }
        private static List<Image> imageList = new List<Image>();
        private void GetStage(string stage)
        {
            ComposedStage.Stage = stage;
            List<ReaderEntety> lists =
             model.GetFiles(ComposedStage.Stage);
            List<string> data = Binary.ReadListString(PathType.ImageOrList);

            if (
                ComposedStage.Stage.Equals("5") && StageFife.Index == 6)
            {
                _listBox.Add(listBox4);
                _listBox.Add(listBox5);

            }


            for (int i = 0; i < lists.Count; i++)
            {
                if (!ComposedStage.Stage.Equals("5"))
                {
                    _listImage[i].Source = null;
                    _listBox[i].Width = 0;
                    _listBox[i].Height = 0;
                }
                else
                {
                    if(StageFife.Index == 6)
                    {
                        _listBox[i].Width = 0;
                        _listBox[i].Height = 0;
                    }
                    else
                    {
                        if (i == 4)
                        {
                            break;
                        }
                        _listBox[i].Width = 0;
                        _listBox[i].Height = 0;
                       
                    }
                }
                
            }



            for (int i = 0; i < lists.Count; i++)
            {

                if (data.Count != 0)
                {
                    bool isListGroup = true;

                    foreach (var s in data)
                    {
                        if (s.Equals(lists[i].NameFile))
                        {
                            isListGroup = false;
                            break;
                        }
                    }

                    if (isListGroup)
                    {
                        GetImage(_listImage[i], lists[i].ContenFiles);
                        StackPanel panel = _listImage[i].Parent as StackPanel;
                        panel.IsEnabled = true;

                    }
                    else
                    {
                       
                        //_listImage[i].Source=
                        if (ComposedStage.Stage.Equals("5"))
                        {
                            System.Drawing.Image defoult =
                       System.Drawing.Image.FromFile(@"Resourse\Right.png");
                            MemoryStream stream = new MemoryStream();
                            defoult.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                            GetImage(_listImage[i], stream);
                            // WinCommand win = new WinCommand();
                            //win.ShowDialog();
                            if (StageFife.Index == 6 )
                            {
                                int k = 0;
                                foreach (var s in _listImage)
                                {
                                    StackPanel panel1 = s.Parent as StackPanel;
                                    if (panel1.IsEnabled == false)
                                    {
                                        k++;

                                    }
                                }
                                if (k == 6)
                                {
                                    WinCommand win = new WinCommand();
                                    win.ShowDialog();
                                    break;
                                }
                            }
                            if (StageFife.Index == 4)
                            {
                                int k = 0;
                                foreach (var s in _listImage)
                                {
                                    StackPanel panel1 = s.Parent as StackPanel;
                                    if (panel1.IsEnabled == false)
                                    {
                                        k++;

                                    }
                                }
                                if (k == 4)
                                {
                                    WinCommand win = new WinCommand();
                                    win.ShowDialog();
                                    break;
                                }
                            }

                        }
                        else
                        {
                            _listBox[i].Width = 250;
                            _listBox[i].Height = 250;

                        }
                        StackPanel panel = _listImage[i].Parent as StackPanel;
                        panel.IsEnabled = false;
                    }
                }
                else
                {
                    GetImage(_listImage[i], lists[i].ContenFiles);
                }
            }
        }

        private void ViewChooseStage_Loaded(object sender, RoutedEventArgs e)
        {
            StackPanel stack5 = Sub5;
            StackPanel stack6 = Sub6;
            //if (StanTextBlock.Index < 4)
            //{
            Uniform.Children.Remove(Sub5);
            Uniform.Children.Remove(Sub6);

            bool isNext = true;
            Result.ListResultDatas.Clear();
            Result.Clear(PathType.ListResultDatas);
            Result.ImageResult = null;
            string nomerStage = Binary.Read(PathType.CurrentStage);

            if (nomerStage != null)
            {
                ComposedStage.Stage = nomerStage;

            }

            string stage = ComposedStage.Stage;
            Binary.Clear(PathType.CurrentStage);
            Binary.Write(ComposedStage.Stage.ToString(), PathType.CurrentStage);

            GetStage(stage);
            int indexStagfour = 0;

            StanTextBlock.Index = int.Parse(Binary.Read(PathType.CurrentStage));
            foreach (var s in _listBox)
            {
                if (s.Width == 0)
                {
                    if (indexStagfour == 2 && StanTextBlock.Index == 4)
                    {
                        break;
                    }

                    isNext = false;
                    break;
                }
                indexStagfour++;
            }

            if (isNext)
            {
                StanTextBlock.Index++;
                Binary.Clear(PathType.CurrentStage);
                Binary.Write(StanTextBlock.Index.ToString(), PathType.CurrentStage);
            }
            string index = Binary.Read(PathType.CurrentStage);
            if (index != null)
            {
                StanTextBlock.Index = int.Parse(index);
            }

            if (StanTextBlock.Index == 2)
            {
                ChangeStage.SecondStage();
            }
            if (StanTextBlock.Index == 3)
            {
                ComposedStage.Stage = "3";

                ChangeStage.ThridStage();
                LoadedStages(null);

                Group.TeamGroups = Binary.ReadTeamGroup(PathType.StageThree);
                Binary.Clear(PathType.CurrentGroup);
                Binary.Write(Group.TeamGroups, PathType.CurrentGroup);
                ChangeColorStage();
                // new ThemsViewModal();
            }
            if (StanTextBlock.Index == 4)
            {
                ComposedStage.Stage = "4";
                ChangeStage.FourStage();

                Sub3.Visibility = Visibility.Hidden;
                Sub4.Visibility = Visibility.Hidden;
                Sub1.Margin = new Thickness(30, 150, 30, 30);
                Sub2.Margin = new Thickness(30, 150, 30, 30);

                // Uniform.Children.Add(new ViewChooseSubFour());
            }
            if (StanTextBlock.Index == 5)
            {
                ComposedStage.Stage = "5";
                ChangeStage.FifeStage();
                if (StageFife.Index == 6)
                {
                    Uniform.Children.Add(stack5);
                    Uniform.Children.Add(stack6);
                    Sub1.Margin = new Thickness(15);
                    Sub2.Margin = new Thickness(15);
                    Sub3.Margin = new Thickness(15);
                    Sub4.Margin = new Thickness(15);
                    Sub5.Margin = new Thickness(15);
                    Sub6.Margin = new Thickness(15);
                }
                //  Sub1.Margin = new Thickness(300, 200, 0, 0);
                //  Sub1.VerticalAlignment = VerticalAlignment.Center;
                //   Sub1.HorizontalAlignment = HorizontalAlignment.Center;

                // ChangeColorStage();
            }

            ChangeColorStage();

            ChangeThems.ThemeChange();
        }

        private void ChangeColorStage()
        {
            for (int i = 0; i < _listBlock.Count; i++)
            {
                if (_listBlock[i].Name.Contains
                    (StanTextBlock.Index.ToString()))
                {
                    _listBlock[i].Background = textBlock2Hidden.Background;

                    GetStage(StanTextBlock.Index.ToString());
                    break;
                }
            }

        }

        private void GetImage(Image source,
            MemoryStream stream)
        {
            BitmapImage imageSource = new BitmapImage();

            //if (ComposedStage.Stage == "5")
            //{
            //    stream = new MemoryStream(stream.ToArray());
            //}
            imageSource.BeginInit();
            imageSource.CacheOption = BitmapCacheOption.OnLoad;
            imageSource.StreamSource = stream;

            imageSource.EndInit();
            source.Source = imageSource;

        }

        private void Label_MouseDown(object sender, RoutedEventArgs e)
        {
            if (!_isClose)
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 288;
                animation.To = 0;
                animation.Duration = TimeSpan.FromSeconds(0.3);
                dockPanel.BeginAnimation
                    (System.Windows.Shapes.Rectangle.WidthProperty, animation);
                label.Visibility = Visibility.Visible;
                _isClose = true;
            }
            else
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 0;
                animation.To = 288;
                animation.Duration = TimeSpan.FromSeconds(0.3);
                dockPanel.BeginAnimation
                    (System.Windows.Shapes.Rectangle.WidthProperty, animation);
                label.Visibility = Visibility.Hidden;
                _isClose = false;

            }
        }

        private void InstalList()
        {
            _listBlock.Add(textBlock1);
            _listBlock.Add(textBlock2);
            _listBlock.Add(textBlock3);
            _listBlock.Add(textBlock4);
            _listBlock.Add(textBlock5);


            _listBox.Add(listBox);
            _listBox.Add(listBox1);
            _listBox.Add(listBox2);
            _listBox.Add(listBox3);
            //



            _listImage.Add(PImage0);
            _listImage.Add(PImage1);
            _listImage.Add(PImage2);
            _listImage.Add(PImage3);
            //
            _listImage.Add(PImage4);
            _listImage.Add(PImage5);

        }
    }
}
