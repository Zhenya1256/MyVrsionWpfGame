using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfGame.Data;


namespace WpfGame.ViewModal
{
   public class WindowChooseViewModal : ViewModelBase
    {
        ReadStrategy _read = new ReadStrategy();
        private List<Image> _images;

        public WindowChooseViewModal()
        {
            //_images = _read.GetImages;
            RelayCommand downLoadImage = new RelayCommand
                  (ExecuteDownLoadCommand, (parameter) => true);
        }

        public Image FirstImage
        {
            get
            {
                return _images[0];
            }
        }

        public MemoryStream MemoryFirstImage
        {
            get
            {
                return new MemoryStream();
            }
        }

        public string DisplayedImagePath
        {
            get
            {
                return @"E:\Iamge2.png";
            }
        }

        public List<Image> Images
        {
            get
            {
                return _images;
            }
        }

        public void ExecuteDownLoadCommand(object parameter)
        {
           
        }
    }
}
