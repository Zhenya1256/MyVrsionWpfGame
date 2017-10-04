using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfGame.StageFour.ViewModel;
using WpfGame.Style;
using WpfGame.ViewModal;
using WpfGame.ViewModal.StaticClass;
using WpfGame.ViewModal.ViewModelStage;
using WpfGame.WorkWithCommad.Implement;
using WpfGme.UiEntites.GamePlay;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.StageFour.View
{
    /// <summary>
    /// Interaction logic for ViewThemsStageFour.xaml
    /// </summary>
    public partial class ViewThemsStageFour : UserControl
    {
        private ImageViewModel image;
        private string path;
        private List<ReaderEntety> list;
        private int _index = 0;
        StartCommandNow stn;

        public ViewThemsStageFour()
        {
            InitializeComponent();
            path = Binary.Read(PathType.PathFile);
            image = new ImageViewModel();
            ChangeThems.ThemeChange(); 
            this.Loaded += ViewThems_Loaded;
            string indexCommand = Binary.Read(PathType.IndexCommands);

            if(indexCommand != null)
            {
                IndexCommands.Index = int.Parse(indexCommand);

            }

            if (IndexCommands.Index == 4)
            {
                IndexCommands.Index = 0;
            }
      


        }

        private void ViewThems_Loaded(object sender, RoutedEventArgs e)
        {
            image = new ImageViewModel();
            list = image.GetThems(path);

            List<Image> images = GetImages();
            List<TextBlock> blocks = GetTextBolocks();

            for (int i = 0; i < 16; i++)
            {
               // blocks[i].FontWeight = Font.FontWeight;
                Volidate(images[i], blocks[i], list);
            }

            Exit();
           
        }


        private void Exit()
        {
            if (Result.ListResultDatas.Count == 16)
            {
                new ThemsViewModal();
            }
           else if(Result.ListResultDatas.Count == 0)
            {
                CommandsForStageFour stage = new CommandsForStageFour();
                stage.DataContext = new VMCommands();
                stage.Show();
            }
            else
            {
                stn = new StartCommandNow();
                stn.Show();
            }
        }

        private void StackDown(object sender, MouseEventArgs e)
        {
          
        }

        private void StackDown1(object sender, MouseEventArgs e)
        {
            Image panel1 = (Image)sender;
            Result.ImageResult = panel1.Name;

            if (stn != null)
            {
                stn.Close();
            }
        }
        private void StackDown2(object sender, MouseEventArgs e)
        {
            TextBlock panel1 = (TextBlock)sender;
            string name = panel1.Name;
            name = name.Replace("Text", "Image");
            Result.ImageResult = name;
        }

        private void SetImage(Image source,
        MemoryStream stream)
        {
            stream = new MemoryStream(stream.ToArray());
            stream = image.ChangeSize(stream);
            MemoryStream changeStream = new MemoryStream();

            if (Result.ListResultDatas.Count == 0)
            {
                Result.ListResultDatas =
                    Result.Read(PathType.ListResultDatas);
            }

            foreach (var s in Result.ListResultDatas)
            {
                if (source.Name.Equals(s.Name))
                {
                    changeStream =
                       image.AddImage(stream, s.Type);
                    if (changeStream != null)
                    {
                        stream = changeStream;
                    }
                    StackPanel panel = source.Parent as StackPanel;
                    panel.IsEnabled = false;

                    // changeStream.Dispose();
                    break;
                }
            }
            Binary.Clear(PathType.ListResultDatas);
            Result.BinaryWriter(Result.ListResultDatas, PathType.ListResultDatas);

            if (Result.ImageResult != null &&
                source.Name.Equals(Result.ImageResult))
            {
                changeStream =
                        image.AddImage(stream, Result.Type);
                if (changeStream != null)
                {
                    stream = changeStream;
                }
                StackPanel panel = source.Parent as StackPanel;
                panel.IsEnabled = false;
                // changeStream.Dispose();
                ResultDataThems res = new ResultDataThems();
                res.Name = source.Name;
                res.Type = Result.Type;
                res.Content = GetResult();
                Result.ListResultDatas.Add(res);
            }

            stream = ValuePicture(source, stream);
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.CacheOption = BitmapCacheOption.OnLoad;
            imageSource.StreamSource = stream;
            imageSource.EndInit();
            source.Source = imageSource;

            imageSource.StreamSource.Close();
            imageSource.StreamSource.Dispose();
            changeStream.Dispose();
            stream.Close();
            stream.Dispose();

        }

        private void SetText(TextBlock source,
        MemoryStream stream, bool isExisit)
        {
            //MemoryStream content
            if (isExisit)
            {
                source.Foreground = Brushes.White;
                string content = "";
                source.Text = content;
                ResultCommands(source);
            }
            else
            {
                ResultCommands(source);
                stream.Dispose();
            }
        }

        private void ResultCommands(TextBlock source)
        {
            foreach (var s in Result.ListResultDatas)
            {
                string sname = s.Name.Replace("Image", "Text");

                if (source.Name.Equals(sname))
                {
                    //Brush b = source.Background;
                    string name = s.Name;
                    Image imageCurrent = new Image();

                    foreach (var im in GetImages())
                    {
                        if (im.Name.Equals(name))
                        {
                            imageCurrent = im;
                            im.Opacity = 0.86;
                            break;
                        }
                    }
                    string nameCommand = s.Content.Split(' ')[0];
                    TeamGroup team = null;
                    if (HolderGroup.Commands.Count == 0)
                    {
                        HolderGroup.Commands =
                            Binary.ReadTeamGroup(PathType.AllCommands);
                    }

                    foreach (var com in HolderGroup.Commands)
                    {
                        if (nameCommand.Equals(com.Name))
                        {
                            team = com;
                            break;
                        }
                    }



                    if (team != null)
                    {
                        source.Foreground = 
                            ImageViewModel.GetColor(imageCurrent, team.colorCommand);
                        //  new SolidColorBrush(team.colorCommand);
                    }
                    else
                    {
                        // source.Foreground= ImageViewModel.GetColor(imageCurrent);
                    }

                    if (s.Content.Length >= 17 && s.Content.Length < 21)
                    {
                        source.FontSize = 16;
                    }
                    else if (s.Content.Length <= 6)
                    {
                        source.FontSize = 24;
                    }
                    else if (s.Content.Length > 6 && s.Content.Length <= 12)
                    {
                        source.FontSize = 24;
                    }
                    else if (s.Content.Length >= 13 && s.Content.Length <= 14)
                    {
                        source.FontSize = 20;
                    }
                    else if (s.Content.Length >= 15 && s.Content.Length <= 20)
                    {
                        source.FontSize = 16;
                    }
                    else
                    {
                        source.FontSize = 12;
                    }
                    source.Text = s.Content.ToUpper();
                    break;
                }
            }
        }

        private MemoryStream ValuePicture(Image source,
        MemoryStream stream)
        {
            MemoryStream memory = new MemoryStream();
            int nomer = GetNomer(source.Name);
 
            foreach(int s in LoadValuePicture.ValuePicture().Keys)
            {
                if (s == nomer)
                {
                    int value = LoadValuePicture.ValuePicture()[s];
                    string text = "X" + value;
                    memory = LoadValuePicture.AddText(stream, text);
                    break;
                }

            }

            return memory;
        }

        private int GetNomer(string name)
        {
            int[] nomer = new int[2];

            int i = 0;

            foreach (var s in name)
            {
                if (Char.IsDigit(s))
                {
                    nomer[i] = int.Parse(s.ToString());
                    i++;
                }
            }
            int result = 0;

            if (nomer[0] == 1)
            {
                result = nomer[1];
            }
            else if (nomer[0] == 2)
            {
                result = nomer[1] + 4;
            }
            else if (nomer[0] == 3)
            {
                result = nomer[1] + 8;
            }
            else if (nomer[0] == 4)
            {
                result = nomer[1] + 12;
            }


            return result;
        }

        private string GetResult()
        {
            TeamGroup listTeams = Group.ResulGroups;

            string content = "";

            if (listTeams != null && Result.Type != ViewINfoType.Error)
            {
                content = (listTeams.Name + " " + listTeams.Point + " ");
            }

            return content;
        }

        private List<Image> GetImages()
        {
            List<Image> list = new List<Image>();
            list.Add(Thame1Image1);
            list.Add(Thame1Image2);
            list.Add(Thame1Image3);
            list.Add(Thame1Image4);

            list.Add(Thame2Image1);
            list.Add(Thame2Image2);
            list.Add(Thame2Image3);
            list.Add(Thame2Image4);

            list.Add(Thame3Image1);
            list.Add(Thame3Image2);
            list.Add(Thame3Image3);
            list.Add(Thame3Image4);

            list.Add(Thame4Image1);
            list.Add(Thame4Image2);
            list.Add(Thame4Image3);
            list.Add(Thame4Image4);

            return list;

        }

        private List<TextBlock> GetTextBolocks()
        {
            List<TextBlock> list = new List<TextBlock>();

            list.Add(Thame1Text1);
            list.Add(Thame1Text2);
            list.Add(Thame1Text3);
            list.Add(Thame1Text4);
            //
            list.Add(Thame2Text1);
            list.Add(Thame2Text2);
            list.Add(Thame2Text3);
            list.Add(Thame2Text4);

            list.Add(Thame3Text1);
            list.Add(Thame3Text2);
            list.Add(Thame3Text3);
            list.Add(Thame3Text4);

            list.Add(Thame4Text1);
            list.Add(Thame4Text2);
            list.Add(Thame4Text3);
            list.Add(Thame4Text4);

            return list;
        }

        private void Volidate(Image source, TextBlock block, List<ReaderEntety> entets)
        {
            List<ReaderEntety> list1 = entets;
            if (!list1[_index].NameFile.Contains("txt"))
            {
                SetImage(source, list1[_index].ContenFiles);
                //  Thame1Text1.Text = "2345678i";
            }
            if (list1[_index + 1].NameFile.Contains("txt"))
            {
                SetText(block, list1[_index].ContenFiles, true);
                _index++;
            }
            else
            {
                SetText(block, list1[_index].ContenFiles, false);
            }

            _index++;
        }

        //#region modal
        //DispatcherTimer dt;
        //private int second = 7;

        //public void StartCommandNow()
        //{
        //    int index = IndexCommands.Index + 1;
        //    modal.Visibility = Visibility.Visible;
        //    if (Group.TeamGroups.Count == 0)
        //    {
        //        Group.TeamGroups =
        //            Binary.ReadTeamGroup(PathType.CurrentGroup);
        //    }

        //    TeamGroup team = Group.TeamGroups[index];
        //    textCommand.Foreground = new SolidColorBrush(team.colorCommand);
        //    textCommand.FontSize = 20;
        //    textCommand.Content += team.Name;
        //    Timer();
        //}
        //private void Timer()
        //{
        //    dt = new DispatcherTimer();
        //    dt.Interval = TimeSpan.FromSeconds(1);
        //    dt.Tick += dtTicker;
        //    dt.Start();
        //}

        //private void dtTicker(object sender, EventArgs e)
        //{
        //    if (second < 5)
        //    {
        //        modal.Visibility = Visibility.Hidden;
        //    }
        //    else
        //    {
        //        second--;
        //    }
        //}
        //#endregion

    }
}
