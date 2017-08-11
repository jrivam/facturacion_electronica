using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;

namespace Library.Framework.Print
{
    public class Formatted : Raw
    {
        public int Width { get; set; }
        public int PosX { get; set; }

        public Font Font { get; set; }
        public SolidBrush Brush { get; set; }

        public StringFormat Format  { get; set; }

        public Formatted(string paramText, 
            int paramWidth, int paramPosX,
            Font paramFont, 
            SolidBrush paramBrush, 
            StringFormat paraFormat)
            : base(paramText)
        {
            Width = paramWidth;
            PosX = paramPosX;

            Font = paramFont;
            Brush = paramBrush;

            Format = paraFormat;
        }
        public Formatted(string paramText)
            : this(paramText,
            76, 0,
            new Font("System", 10, FontStyle.Regular), new SolidBrush(Color.Black),
            new StringFormat())
        {
        }
        public Formatted(string sParamText, StringAlignment pParamAlignment)
            : this(sParamText)
        {
            Format.Alignment = pParamAlignment;
        }
    }
}
