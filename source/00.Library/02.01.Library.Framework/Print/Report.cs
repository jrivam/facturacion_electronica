using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Library.Framework.Layers;
using Library.Framework.Print;
using System.Drawing.Printing;
using System.Drawing;

namespace Library.Framework.Print
{
    [Serializable]
    public abstract class Report
    {
        public Report()
        {
        }

        public virtual void Print(IPrintTemplate paramTemplate, List<Raw> paramLines)
        {
        }
    }

    public abstract class ReportRaw : Report
    {
        protected LPrinter Printer  { get; set; }
        protected int MaxColumns { get; set; }

        public ReportRaw(string paramPrinterName,
            int paramMaxColumns = 80)
            : base()
        {
            Printer = new LPrinter(paramPrinterName);
            MaxColumns = paramMaxColumns;
        }

        public override void Print(IPrintTemplate paramTemplate, List<Raw> paramLines)
        {
            if (!Printer.Open("RAW")) return;

            foreach (Raw i in paramTemplate.GetLines(paramLines))
                Printer.Print(i.Text);

            Printer.Close();
        }
    }

    //public abstract class ReportWindows : Report
    //{
    //    protected PrintDocument Document;

    //    float leftMargin = 0;
    //    float topMargin = 3;

    //    Graphics gfx = null;

    //    float count = 0;
    //    float size = 0;

    //    private float YPosition()
    //    {
    //        return topMargin + (count);
    //    }
    //    private float XPosition(int nParamPosX)
    //    {
    //        return leftMargin + (nParamPosX);
    //    }

    //    public ReportWindows(Template paramTemplate)
    //        : base(paramTemplate)
    //    {
    //        Document = new PrintDocument();
    //    }

    //    private void pr_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    //    {
    //        e.Graphics.PageUnit = GraphicsUnit.Millimeter;
    //        gfx = e.Graphics;

    //        size = 0;
    //        count = 0;

    //        foreach (Formatted i in _Template.GetLines(new List<Raw>()))
    //        {
    //            gfx.DrawString(i.Text, i.Font, i.Brush, new RectangleF(new PointF(XPosition(i.PosX), YPosition()), new SizeF(i.Width, i.Font.GetHeight(gfx))), i.Format);

    //            if (i.Font.GetHeight(gfx) > size)
    //                size = i.Font.GetHeight(gfx);
    //            if (i.Text == System.Environment.NewLine)
    //                count = count + size;
    //        }
    //    }
    //    public override void Print()
    //    {
    //        Document.PrintPage += new PrintPageEventHandler(pr_PrintPage);

    //        Document.Print();
    //    }
    //}
}
