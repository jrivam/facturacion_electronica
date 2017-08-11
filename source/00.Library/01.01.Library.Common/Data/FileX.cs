using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Library.Common.Data
{
    static public class FileX
    {
        static public byte[] GetBytesFromFileName(string paramFileName)
        {
            return GetBytesFromImage(Image.FromFile(paramFileName));
        }
        static public byte[] GetBytesFromImage(Image paramImage)
        {
            if (paramImage != null)
            {
                MemoryStream ms = new MemoryStream();
                paramImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
            return null;
        }

        static public Image GetImageFromBytes(byte[] paramBytes)
        {
            if (paramBytes != null)
                return Image.FromStream(new MemoryStream(paramBytes));

            return null;
        }
    }
}
