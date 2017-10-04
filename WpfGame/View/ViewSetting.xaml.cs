using ClassLibrary1;
using ClassLibrary1.MessageCreateCommnds;
using System;
using System.Collections.Generic;
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
using WpfGame.Data;
using WpfGame.StaticClasses;
using WpfGame.ViewModal;
using WpfGame.ViewModal.StaticClass;
using WpfGame.ViewModal.TempDir;
using WpfGame.ViewModal.ViewModelStage;
using WpfGame.WorkWithCommad.Implement;
using WpfGme.UiEntites.GamePlay;
using WpgGame.SaveBinaryFormat;

namespace WpfGame.View
{
    /// <summary>
    /// Interaction logic for ViewSetting.xaml
    /// </summary>
    public partial class ViewSetting : UserControl
    {
        SaveStyle styleName = new SaveStyle("Resourse\\StyleName.txt");
        SaveStyle backgroundImageName = new SaveStyle("Resourse\\BackgroundImageName.txt");
        SaveStyle iconName = new SaveStyle("Resourse\\IconName.txt");
        private Random _random = new Random();
        private int _currentColor;
        private TextBlock _select;
        public static List<Color> MyColors = new List<Color>();

        public ViewSetting()
        {
            InitializeComponent();
            List<string> styles = 
                new List<string> { "Світлий", "Темний", "Без стилю" };

            styleBox.SelectionChanged += ThemeChange;
            icon1.Checked += icon1_Checked;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = styleName.GetStyleName();
            this.Loaded += ViewSetting_Loaded;
            ComboBocInstal();
            PhoneListColor.SelectedIndex = 0;
            _select = (TextBlock)PhoneListColor.Items[0];
            int k = 1;

            foreach(var s in HolderGroup.Commands)
            {
                ListNamesCommands.Items.Add(k + ". " + s.Name);
                k++;
            }

            Radiobutom1.Checked += Radiobutom1_Checked;
            Radiobutom2.Checked += Radiobutom2_Checked;

        }

        private void Radiobutom2_Checked(object sender, RoutedEventArgs e)
        {
            StageFife.Index = 4;
        }

        private void Radiobutom1_Checked(object sender, RoutedEventArgs e)
        {
            StageFife.Index = 6;
        }

    


        private void ViewSetting_Loaded(object sender, RoutedEventArgs e)
        {
            string tab = Binary.Read(PathType.TabSetting);

            if (tab != null)
            {
                int index = int.Parse(tab);
                Setting.SelectedIndex = index;
            }
            else
            {

                Setting.SelectedIndex = 1;
            }         
        }

        public void HandleKeyPress(Key key)
        {
            if (Setting.SelectedIndex == 3)
            {
                if (key == Key.Return)
                {
                    KeyAddCommand();
                }
            }
            if (key == Key.F2)
            {
                System.Windows.Forms.Help.ShowHelp(null, "Справка/СправкаГри.chm");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Help.ShowHelp(null, "Справка/СправкаГри.chm");
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            styleName.SaveStyleName(styleBox.SelectedValue.ToString());
            string style = styleName.GetStyleName();
            if (style != "Без стилю")
            {
                UpdateStyle.SetThemes(style);
            }
        }

        #region Tabs

        private void SettigGame_Click(object sender, RoutedEventArgs e)
        {
            
            Setting.SelectedIndex = 1;
            Binary.Clear(PathType.TabSetting);
            Binary.Write("1", PathType.TabSetting);
        }

        private void SettigButton_Click(object sender, RoutedEventArgs e)
        {
            Setting.SelectedIndex = 0;
            Binary.Clear(PathType.TabSetting);
            Binary.Write("0", PathType.TabSetting);
        }

        private void Style_Click(object sender, RoutedEventArgs e)
        {
            Setting.SelectedIndex = 2;
            Binary.Clear(PathType.TabSetting);
            Binary.Write("2", PathType.TabSetting);

        }

        private void Command_Click(object sender, RoutedEventArgs e)
        {
            Setting.SelectedIndex = 3;
            Binary.Clear(PathType.TabSetting);
            Binary.Write("3", PathType.TabSetting);

        }

        #endregion

        private void cat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            backgroundImageName.SaveStyleName("Image1Style");
            styleName.SaveStyleName("Без стилю");
            styleBox.SelectedItem = styleName.GetStyleName();
            UpdateStyle.SetThemes("Image1Style");
        }

        #region IMageThems

        private void image4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            backgroundImageName.SaveStyleName("Image2Style");
            styleName.SaveStyleName("Без стилю");
            styleBox.SelectedItem = styleName.GetStyleName();
            UpdateStyle.SetThemes("Image2Style");

        }
        private void image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            backgroundImageName.SaveStyleName("Image3Style");
            styleName.SaveStyleName("Без стилю");
            styleBox.SelectedItem = styleName.GetStyleName();
            UpdateStyle.SetThemes("Image3Style");

        }
        private void image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            backgroundImageName.SaveStyleName("Image4Style");
            styleName.SaveStyleName("Без стилю");
            styleBox.SelectedItem = styleName.GetStyleName();
            UpdateStyle.SetThemes("Image4Style");

        }

        #endregion

        private void ShooseIcon()
        {
        }

        #region Icon

        private void icon1_Checked(object sender, RoutedEventArgs e)
        {
            if (icon1.IsChecked == true)
            {
                iconName.SaveStyleName("Resourse/chat.ico");
                Uri iconUri = new Uri("Resourse/chat.ico", UriKind.RelativeOrAbsolute);
                (this.Parent as Window).Icon = BitmapFrame.Create(iconUri);
            }
        }

        private void icon2_Checked(object sender, RoutedEventArgs e)
        {
            iconName.SaveStyleName("Resourse/appstore.ico");
            if (icon2.IsChecked == true)
            {
                Uri iconUri = new Uri("Resourse/appstore.ico", UriKind.RelativeOrAbsolute);
                (this.Parent as Window).Icon = BitmapFrame.Create(iconUri);
            }

        }

        private void icon3_Checked(object sender, RoutedEventArgs e)
        {

            iconName.SaveStyleName("Resourse/browser.ico");
            if (icon3.IsChecked == true)
            {
                Uri iconUri = new Uri("Resourse/browser.ico", UriKind.RelativeOrAbsolute);
                (this.Parent as Window).Icon = BitmapFrame.Create(iconUri);
            }

        }

        #endregion

        private void ComboBocInstal()
        {
            foreach (var s in MyColorsForCommands.GetColors())
            {
                Brush brush = new SolidColorBrush(s);
                PhoneListColor.Items.Add(CreateBlock(brush));
                MyColors.Add(s);
            }   
        }

        private TextBlock CreateBlock(Brush brush)
        {
            TextBlock tb = new TextBlock();
            tb.Width = 40;
            tb.Height = 40;
            tb.Background = brush;
            tb.Cursor = TextBlockItemZero.Cursor;

            return tb;
        }

        private void Combobox_Selected(object sender,RoutedEventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            TextBlock block= (TextBlock)box.SelectedItem;
            int index = box.SelectedIndex;

            if (block != null )
            {
                _select = block;
                _currentColor = index;
            }     
        }

        int i = 1;
        
        private void KeyAddCommand()
        {            
            if (HolderGroup.Commands.Count != 16)
            {
                if (!NameCommand.Text.Contains(" "))
                {
                    if (NameCommand.Text != "")
                    {
                        TeamGroup group = new TeamGroup(NameCommand.Text);

                        group.colorCommand = MyColors[_currentColor];

                        if (Volidate((NameCommand.Text)))
                        {
                            HolderGroup.Commands.Add(group);

                            ListNamesCommands.ItemsSource = null;
                            ListNamesCommands.Items.Add(i + ". " + NameCommand.Text);
                            PhoneListColor.Items.Remove(_select);
                            NameCommand.Text = "";
                            MyColors.RemoveAt(_currentColor);
                            PhoneListColor.SelectedIndex = 0;
                            _select = (TextBlock)PhoneListColor.Items[0];
                            i++;
                        }
                        else
                        {
                            MessageBox.Show
                                (CommandMessge.GetErrorMessag(ErrorType.ExistCommand));
                        }
                    }
                    else
                    {
                        MessageBox.Show
                            (CommandMessge.GetErrorMessag(ErrorType.CreatName));
                    }
                }

                else
                {
                    MessageBox.Show(CommandMessge.GetErrorMessag(ErrorType.IsEmpty));
                }
            }

            else
            {
                MessageBox.Show
                    (CommandMessge.GetErrorMessag(ErrorType.AllCommands));
            }
        }

        private bool Volidate(string name)
        {
            foreach(var s in HolderGroup.Commands)
            {
                if (s.Name.Equals(name))
                {
                    return false;
                }
            }

            return true;
        }
       
        private void AddCommand(object sender, RoutedEventArgs e)
        {
            KeyAddCommand();

        }
      
 
    }
}
