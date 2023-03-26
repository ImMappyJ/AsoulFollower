/*
 * 
 *  Bitmap转化工具
 * 
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AsoulFollower.utils
{
    public class BitmapUtil
    {
        public static BitmapImage bitmap2bitmapImage(Bitmap b)
        {
            var stream = new MemoryStream();
            b.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
    }
}
