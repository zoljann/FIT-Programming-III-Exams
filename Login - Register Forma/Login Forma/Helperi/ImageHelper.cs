using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Forma.Helperi
{
    internal class ImageHelper
    {
        public static byte[] FromImageToByte(Image image) //konvertujemo image u byte i vracamo ga da bi ga mogli pohraniti
        {
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public static Image FromByteToImage(byte[] image) //konvertujemo samo obrnuto
        {
            var ms = new MemoryStream(image);
            Image.FromStream(ms);
            return Image.FromStream(ms);
        }
    }
}
