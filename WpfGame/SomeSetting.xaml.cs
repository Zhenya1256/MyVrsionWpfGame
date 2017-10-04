using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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
using System.Windows.Shapes;
using WpfGame.Style;
using WpfGame.ViewModal.ViewModelStage;

namespace WpfGame
{
    /// <summary>
    /// Interaction logic for SomeSetting.xaml
    /// </summary>
    public partial class SomeSetting : Window
    {
        System.Drawing.Image image;
        MemoryStream stream = new MemoryStream();

        public SomeSetting()
        {
            InitializeComponent();
            //ChangeThems.ThemeChange();

         //   WindowStartupLocation =WindowStartupLocation.CenterOwner;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            image =
                System.Drawing.Image.FromFile(@"Resourse\Right.png");
            image.Save(stream, ImageFormat.Png);
        }
        public void CommandImage()
        {
            CreatecommandImage = 
                ImageViewModel.AddControlImage(stream, CreatecommandImage);
            Createcommand.IsEnabled = false;
        }
        public void SettingImage()
        {
            Setting =
                ImageViewModel.AddControlImage(stream, Setting);
            buttonSetting.IsEnabled = false;
        }

        private void Createcommand_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
