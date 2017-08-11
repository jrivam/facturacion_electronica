using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Library.Framework.Print
{
    public class LPrinter
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }
        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

        private IntPtr HandlePrinter;
        private PrinterSettings ps;

        public LPrinter()
        {
            HandlePrinter = IntPtr.Zero;
            ps = new PrinterSettings();
        }
        public LPrinter(string sParamPrinterName)
            : this()
        {
            PrinterName = sParamPrinterName;
        }

        public string PrinterName
        {
            get
            {
                return ps.PrinterName;
            }
            set
            {
                ps.PrinterName = value;
            }
        }

        //public bool ChoosePrinter()
        //{
        //    PrintDialog pd = new PrintDialog();
        //    pd.PrinterSettings = ps;
        //    if (pd.ShowDialog() == DialogResult.OK)
        //    {
        //        ps = pd.PrinterSettings;
        //        return true;
        //    }
        //    else return false;
        //}

        public bool Open(string DocName)
        {
            // see if printer is already open
            if (HandlePrinter != IntPtr.Zero) return false;

            // opens the printer
            if (OpenPrinter(ps.PrinterName, out HandlePrinter, IntPtr.Zero))
            {
                // starts a print job
                DOCINFOA MyDocInfo = new DOCINFOA();
                MyDocInfo.pDocName = DocName;
                MyDocInfo.pOutputFile = null;
                MyDocInfo.pDataType = "RAW";

                if (StartDocPrinter(HandlePrinter, 1, MyDocInfo))
                {
                    if (StartPagePrinter(HandlePrinter)) //starts a page       
                        return true;
                    else
                        EndDocPrinter(HandlePrinter);
                }
                else
                {
                    ClosePrinter(HandlePrinter);
                }
            }

            return false;
        }
        public bool Close()
        {
            if (HandlePrinter == IntPtr.Zero) return false;
            if (!EndPagePrinter(HandlePrinter)) return false;
            if (!EndDocPrinter(HandlePrinter)) return false;
            if (!ClosePrinter(HandlePrinter)) return false;
            HandlePrinter = IntPtr.Zero;
            return true;
        }

        public bool Print(List<Raw> paramLines)
        {
            bool bOk = true;

            foreach (Raw ti in paramLines)
            {
                Print(ti.Text);
            }

            return bOk;
        }
        public bool Print(string outputstring)
        {
            if (HandlePrinter == IntPtr.Zero) return false;

            IntPtr buf = Marshal.StringToCoTaskMemAnsi(outputstring);

            Int32 done = 0;
            bool ok = WritePrinter(HandlePrinter, buf, outputstring.Length, out done);

            Marshal.FreeCoTaskMem(buf);

            if (!ok) return false;
            else return true;
        }
    }
}
