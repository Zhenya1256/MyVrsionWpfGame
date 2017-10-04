using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfGame.Data;
using WpfGame.StageFour.ViewModel;
using WpfGame.Style;
using WpfGame.ViewModal;
using WpfGame.ViewModal.Stages;
using WpfGame.ViewModal.StaticClass;
using WpfGame.ViewModal.TempDir;
using WpfGame.ViewModal.ViewModelStage;
using WpfGame.WorkWithCommad.Implement;
using WpfGme.UiEntites.GamePlay;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.View
{
    /// <summary>
    /// Interaction logic for ViewPlay.xaml
    /// </summary>
    public partial class ViewPlay : UserControl
    {
        private DispatcherTimer dt;
        private string _command = null;
        private int selec;
        private List<TeamGroup> list;
        //    private TeamGroup _currentTeamGroup;
        private ImageViewModel modal;
        private bool _isPlayMusic = false;
        private double _second = 16.2;
        private int nomerQuation;
        ResultQuation _resultQut;
        TeamGroup currentTeamFourStage;
        private int index = 0;
        private bool isSpase = false;
        private Window window;

        public ViewPlay()
        {
            InitializeComponent();

            list = Binary.ReadTeamGroup(PathType.CurrentGroup);
            Timer();
            InstalResult();
            _resultQut = new ResultQuation();
            _resultQut.Right = true;
            modal = new ImageViewModel();
            Result.Type = ViewINfoType.Error;
            listBox.Items.Refresh();

            for (int i = 0; i < list.Count; i++)
            {
                list[i].Position = i + 1;
            }
            _command = null;
            listBox.ItemsSource = list;

            if (ComposedStage.Stage.Equals("4"))
            {

                IndexCommands.Index++;
                if (IndexCommands.Index >= 4)
                {
                    IndexCommands.Index = 0;
                }
                List<TeamGroup> list = Group.TeamGroups;
                currentTeamFourStage = Group.TeamGroups[IndexCommands.Index];
                listBox.Visibility = Visibility.Hidden;
                Binary.Clear(PathType.IndexCommands);
                Binary.Write(IndexCommands.Index.ToString(), PathType.IndexCommands);
            }


            ChangeThems.ThemeChange();
            AddQuation();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            window = Window.GetWindow(this);

            if (!ComposedStage.Stage.Equals("4")
                || ComposedStage.Stage.Equals("3")
                || ComposedStage.Stage.Equals("5"))
            {
                listBox.SelectedIndex = index;
            }
            //  this.KeyDown += HandleKeyPress;
            //window.KeyDown += HandleKeyPress;
        }


        public void HandleKeyPress(Key key)
        {
            switch (key)
            {
                case Key.Space:
                    {
                        dt.Stop();
                        if (!_resultQut.Right ||
                            !ComposedStage.Stage.Equals("4")
                            )
                        {
                            listBox.Visibility = Visibility.Visible;
                            listBox.SelectedIndex = index;
                        }

                        if (ComposedStage.Stage.Equals("3")
                            || ComposedStage.Stage.Equals("5"))
                        {
                            listBox.Visibility = Visibility.Hidden;
                            listBox.SelectedIndex = 1;
                        }
                        isSpase = true;

                        if (_isPlayMusic)
                        {
                            mediaElement.Stop();
                        }
                        break;
                    }
                case Key.A:

                    if (isSpase)
                    {
                        bool isRight = ActionRigth();

                        if (isRight)
                        {
                            new PlayViewModel();
                        }
                    }

                    break;
                case Key.Tab:

                    if (ComposedStage.Stage.Equals("4"))
                    {
                        if (isSpase)
                        {
                            bool isRight = AcrionErrorStageFour();
                            listBox.Visibility = Visibility.Hidden;

                            if (isRight)
                            {
                                new PlayViewModel();
                            }

                        }
                    }
                    else
                    {
                        if (isSpase)
                        {
                            bool isRight = ActionError();
                            listBox.Visibility = Visibility.Hidden;
                            if (isRight)
                            {
                                new PlayViewModel();
                            }
                        }
                    }
                    break;
                case Key.Up:

                    if (index != 0)
                    {
                        index--;
                    }
                    listBox.SelectedIndex = index;
                    break;
                case Key.Down:

                    if (index + 1 < listBox.Items.Count)
                    {
                        index++;
                    }
                    listBox.SelectedIndex = index;
                    break;
                case Key.Return:
                    break;
            }
        }

        private void AddImage(MemoryStream stream)
        {
            stream = modal.ChangeSize
                (stream,
                System.Windows.Forms.Screen.
                PrimaryScreen.WorkingArea.Width, 460);

            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.CacheOption = BitmapCacheOption.OnLoad;
            imageSource.StreamSource = stream;
            imageSource.EndInit();
            Quation.Source = imageSource;

            imageSource.StreamSource.Close();
            imageSource.StreamSource.Dispose();
            stream.Close();
            stream.Dispose();
        }

        private void AddQuation()
        {
            string name = Result.ImageResult;


            ImageViewModel image = new ImageViewModel();
            string path = Binary.Read(PathType.PathFile);

            if (name != null)
            {
                nomerQuation = GetNomer(name);
                ReaderEntety reader = image.GetQution(nomerQuation, path);

                if (reader.NameFile != null)
                {
                    if (!reader.NameFile.Contains(".mp3"))
                    {
                        Quation.Visibility = Visibility.Visible;
                        AddImage(reader.ContenFiles);
                        string text =
                            Encoding.Default.GetString
                            (reader.ContenFilesTxt.ToArray());

                        if (text != null)
                        {
                            textQuation.Text = text;
                        }

                    }
                    else
                    {

                        string text = null;
                        if (reader.ContenFilesTxt != null)
                        {
                            text =
                          Encoding.Default.GetString
                          (reader.ContenFilesTxt.ToArray());
                        }

                        if (text != null)
                        {
                            textQuation.Text = text;
                        }
                        try
                        {
                            //FileStream fs =
                            //    new FileStream("TempPLayer.mp3", FileMode.Create);
                            //MemoryStream stream = reader.ContenFiles;
                            //byte[] bytes = stream.ToArray();
                            //fs.Write(bytes, 0, bytes.Length);
                            //fs.Flush();
                            //fs.Close();
                            //mediaElement.Source =
                            //    new Uri("TempPLayer.mp3", UriKind.Relative);
                            //_isPlayMusic = true;
                            //mediaElement.LoadedBehavior = MediaState.Manual;
                            //mediaElement.Play();
                        }
                        catch { }
                    }
                }
            }
            else
            {
                System.Drawing.Image defoult =
                    System.Drawing.Image.FromFile(@"Resourse\AddQuation.jpg");
                MemoryStream stream = new MemoryStream();
                defoult.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                AddImage(stream);
                textQuation.Text = "Додаткове питання";
            }
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

        private void InstalResult()
        {
            Group.ResulGroups = Binary.CurrentTeam(PathType.OneCurrentGroup);

            if (Group.ResulGroups != null)
            {
                Group.ResulGroups.Point = 0;
            }
        }

        private void Error_Click(object sender, RoutedEventArgs e)
        {
            // ActionError();
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            //ActionRigth();
        }

        private bool ActionRigth()
        {
            if (_command != null || ComposedStage.Stage.Equals("4") 
                || ComposedStage.Stage.Equals("5"))
            {
                if (!ComposedStage.Stage.Equals("5"))
                {
                    Info(true);
                }
                listBox.Visibility = Visibility.Hidden;
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Position = i + 1;
                }
                if (File.Exists("TempPLayer.mp3"))
                {
                    try
                    {
                        File.Delete("TempPLayer.mp3");
                    }
                    catch (UnauthorizedAccessException)
                    {

                    }
                }

                Result.Type = ViewINfoType.Right;

                return true;

            }//UnouthAccess
            else
            {
                MessageBox.Show("Виберіть команду", "Виберіть команду",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return false;
        }

        private bool ActionError()
        {
            if (_command != null || ComposedStage.Stage.Equals("5"))
            {
                if (!ComposedStage.Stage.Equals("5"))
                {
                    Info(false);
                    dt.Start();
                }
                if (_isPlayMusic)
                {
                    mediaElement.Play();
                }

                if (_command != null)
                {
                    currentTeamFourStage = new TeamGroup(_command);
                }
                
                RemoveCuurentCommand();
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Position = i + 1;
                }
                if (list.Count == 0)
                {
                    dt.Stop();
                    Result.Type = ViewINfoType.Error;
                    return true;
                }


                Result.Type = ViewINfoType.Error;
                _command = null;
                return false;
            }
            else
            {
                MessageBox.Show("Виберіть команду", "Виберіть команду",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return false;
        }

        private bool AcrionErrorStageFour()
        {
            Info(false);
            if (_isPlayMusic)
            {
                mediaElement.Play();
            }

            if (_command != null)
            {
                currentTeamFourStage = new TeamGroup(_command);
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Position = i + 1;
            }
            RemoveCuurentCommand();
            if (list.Count == 0)
            {
                dt.Stop();
                Result.Type = ViewINfoType.Error;
                return true;
            }


            Result.Type = ViewINfoType.Error;

            return false;
        }

        private void RemoveCuurentCommand()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (currentTeamFourStage.Name.Equals(list[i].Name))
                {
                    list.Remove(list[i]);
                    break;
                }
            }

            listBox.ItemsSource = null;
            listBox.Items.Refresh();
            listBox.ItemsSource = list;
        }

        private void Timer()
        {
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(100);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private bool isForaFourSecond = true;

        private void dtTicker(object sender, EventArgs e)
        {
            if (_second > 0.1)
            {
                if (_second <= 4)
                {
                    FourSecond();
                }
                _second = _second - 0.1;

                string strSecond = _second.ToString();

                if (strSecond.Contains(","))
                {
                    int point = strSecond.IndexOf(",");
                    if (strSecond.Length > point + 2)
                    {
                        strSecond = strSecond.Remove(point + 2, strSecond.Length - 3);
                    }
                }
                else
                {
                    strSecond = strSecond + ",0";

                }

                if (_second < 10)
                {
                    labelTimer.Content = "0" + strSecond.Replace(",", ":");
                }
                else
                {
                    labelTimer.Content = strSecond.Replace(",", ":");
                }
            }
            if (_second <= 0.1 || _second == 4.0)
            {
                dt.Stop();
                File.Delete("TempPLayer.mp3");
                new PlayViewModel();

            }
            if (_second <= 12.1 && ComposedStage.Stage.Equals("4")
                && isForaFourSecond)
            {
                if (nomerQuation == 3 || nomerQuation == 7
                    || nomerQuation == 11 || nomerQuation == 15
                    || nomerQuation % 8 == 0)
                {

                    _resultQut =
                   ChangeStage.FoueStageINfo(nomerQuation,
                   currentTeamFourStage, _second, false);
                    RemoveCuurentCommand();
                    isForaFourSecond = false;
                }
            }


        }

        private void FourSecond()
        {
            string str = "1";
            if (_second.ToString().Contains(","))
            {
                str = _second.ToString().Split(',')[1];
            }
            char ch = str.ToCharArray()[0];

            int sec = int.Parse(ch.ToString());

            if (sec % 4 == 0)
            {
                labelTimer.FontSize = 116;
            }
            else if (sec % 3 == 0)
            {
                labelTimer.FontSize = 122;
            }
            else if (sec % 5 == 0)
            {
                labelTimer.FontSize = 116;// 130;
            }
            else if (sec % 2 == 0)
            {
                labelTimer.FontSize = 122;// 125;
            }
        }

        private bool Info(bool answer)
        {
            string str = ComposedStage.Stage;

            if (ComposedStage.Stage.Equals("3"))
            {
                ChangeStage.ThreeStageInfo
                    (answer, _command, (int)_second);
            }
            else if (ComposedStage.Stage.Equals("4"))
            {

                if (_command != null)
                {
                    currentTeamFourStage = new TeamGroup(_command);
                }
                _resultQut =
                    ChangeStage.FoueStageINfo(nomerQuation,
                    currentTeamFourStage, _second, answer);

                if (!_resultQut.Right)
                {
                    dt.Start();
                    isForaFourSecond = false;
                    return false;
                }
            }
            else
            {
                ChangeStage.ViewINfoTypeRight
                    (answer, _command, (int)_second);
              
            }

            return true;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string name = listBox.SelectedItem.ToString();
                selec = listBox.SelectedIndex;
                name = name.Split(' ')[0];
                _command = name;
            }
        }
    }
}
