using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfGame.Data;
using WpfGame.StageFour.View;
using WpfGame.UIHelper;
using WpfGame.View;
using WpfGame.ViewModal;
using WpgGame.SaveBinaryFormat;

namespace WpfGame
{ 
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    /// 
    public interface IMainWindowsCodeBehind
    {
        void LoadView(ViewType typeView);
    }

    public enum ViewType
    {
        Main,
        Setting,
        ChooseStage,
        Thems,
        PLay,
        ThemsFour
    }

    public partial class Main : Window, IMainWindowsCodeBehind
    {

        SaveStyle iconName = new SaveStyle("Resourse\\IconName.txt");
        public Main()
        {
            InitializeComponent();
            this.Loaded += Menu_Loaded;
            this.Closing += Main_Closing;
            this.KeyDown += Main_KeyDown;
        }

        private void Main_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var components = ComponentResolve.ResolveComponents<ViewPlay>(this);

            if (components != null && components.Any())
            {
                var component = components.FirstOrDefault();
                component.HandleKeyPress(e.Key);
            }

            var componentSetting = ComponentResolve.ResolveComponents<ViewSetting>(this);

            if (componentSetting != null && componentSetting.Any())
            {
                var component = componentSetting.FirstOrDefault();
                component.HandleKeyPress(e.Key);
            }
        }

        private void Main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //  MessageBox.Show("Ви дійсно хочете вийти?");
        DialogResult result = System.Windows.Forms.
                MessageBox.Show("Ви дійсно хочете покинути гру?",
                "Ви дійсно хочете покинути гру?", MessageBoxButtons.YesNo);
            // Binary.Clear(type);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #region 1709
        SaveStyle styleName = new SaveStyle("Resourse\\StyleName.txt");
        SaveStyle backgroundImageName = new SaveStyle("Resourse\\BackgroundImageName.txt");

        private void ThemeChange()
        {
            string style = styleName.GetStyleName();

            if (style != "Без стилю")
            {
                UpdateStyle.SetThemes(style);
            }
            else
            {
                style = backgroundImageName.GetStyleName();
                UpdateStyle.SetThemes(style);
            }
        }

        #endregion

        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {
            ThemeChange();
           string type =  Binary.Read(PathType.ViewType);
            if (type != null)
            {
                foreach (ViewType s in Enum.GetValues(typeof(ViewType)))
                {
                    if (s.ToString().Equals(type))
                    {
                        LoadView(s);
                        if (s.ToString().Equals(ViewType.Setting.ToString()))
                        {
                            Binary.Clear(PathType.AllCommands);
                        }
                        break;
                    }
                }
            }
            else
            {
                LoadView(ViewType.Main);
                Binary.Clear(PathType.AllCommands);
            }
            Uri iconUri = new Uri(iconName.GetStyleName().ToString(), 
                UriKind.RelativeOrAbsolute);
            MenuWindow.Icon = BitmapFrame.Create(iconUri);

        }

        public void LoadView(ViewType typeView)
        {
      
            switch (typeView)
            {
                case ViewType.Setting:
                    ViewSetting view = new ViewSetting();
                    SettingViewModel vm = new SettingViewModel(this);
                    view.DataContext = vm;
                    this.Content = view;
                    Binary.Clear(PathType.ViewType);
                    Binary.Write(ViewType.Setting.ToString(),PathType.ViewType);
                    break;

                case ViewType.Main:
                    ViewStartPage page = new ViewStartPage();
                    MainWindowViewModal modal = new MainWindowViewModal(this);
                    page.DataContext = modal;
                    this.Content = page;
                    Binary.Clear(PathType.ViewType);
                    Binary.Write(ViewType.Main.ToString(), PathType.ViewType);
                    break;
                case ViewType.ChooseStage:
                    ViewChooseStag choose = new ViewChooseStag();
                    ChooseStageViewModal modalch = new ChooseStageViewModal(this);
                    choose.DataContext = modalch;
                    this.Content = choose;
                    Binary.Clear(PathType.ViewType);
                    Binary.Write(ViewType.ChooseStage.ToString(), 
                        PathType.ViewType);
                    break;
                case ViewType.PLay:
                    //new ViewSetting();
                    ViewPlay play = new ViewPlay();
                 //   this.KeyDown += play.HandleKeyPress;
                    PlayViewModel modalpl = new PlayViewModel(this);
                    play.DataContext = modalpl;
                    this.Content = play;
                    
                   
                   // Binary.Clear(PathType.ViewType);
                   // Binary.Write(ViewType.PLay.ToString(), PathType.ViewType);
                    break;
                case ViewType.Thems:
     
                    ViewThems thems = new ViewThems();
                    ThemsViewModal modalth = new ThemsViewModal(this);
                    thems.DataContext = modalth;
                    this.Content = thems;
                    Binary.Clear(PathType.ViewType);
                    Binary.Write(ViewType.Thems.ToString(), 
                        PathType.ViewType);
                    break;
                case ViewType.ThemsFour:
                    ViewThemsStageFour themfours = new ViewThemsStageFour();
                    ThemsViewModal modalfour = new ThemsViewModal(this);
                    themfours.DataContext = modalfour;
                    this.Content = themfours;
                    Binary.Clear(PathType.ViewType);
                    Binary.Write(ViewType.ThemsFour.ToString(),
                        PathType.ViewType);
                    break;
            }
        }
    }
}
