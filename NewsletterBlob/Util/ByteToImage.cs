using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterBlob.Util
{
    public class ByteToImage
    {
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                ms.Seek(0, SeekOrigin.Begin);
                return Image.FromStream(ms);
            }
        }
    }
}
