using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Library.Framework.Print
{
    public class LPrinterCommands
    {
        static public string ESC()
        {
            return Convert.ToChar(27).ToString();
        }
        static public string GS()
        {
            return Convert.ToChar(29).ToString();
        }

        static public string CutPaper(int nParamCut)
        {
            // 0 = partial cut
            // 1 = full cut
            return GS() + "V" + Convert.ToChar(nParamCut).ToString();
        }
        static public string Font(int nParamFont)
        {
            return ESC() + "!" + Convert.ToChar(nParamFont).ToString();
        }
        static public string Color(int nParamColor)
        {
            return ESC() + "r" + Convert.ToChar(nParamColor).ToString();
        }
        static public string Justify(int nParamJustify)
        {
            return ESC() + "a" + Convert.ToChar(nParamJustify).ToString();
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(
        string lpFileName,
        uint dwDesiredAccess,
        uint dwShareMode,
        IntPtr lpSecurityAttributes,
        uint dwCreationDisposition,
        uint dwFlagsAndAttributes,
        IntPtr hTemplateFile);
        
        public static System.IO.StreamWriter GetStreamWriter(string sPort)
        {
            IntPtr hFich = CreateFile(sPort,
            0x40000000, 0, IntPtr.Zero, 3, 0, IntPtr.Zero);
            Microsoft.Win32.SafeHandles.SafeFileHandle sfh = new Microsoft.Win32.SafeHandles.SafeFileHandle(hFich, true);

            System.IO.FileStream stream = new System.IO.FileStream(sfh, System.IO.FileAccess.Write);
            System.IO.StreamWriter writer = new System.IO.StreamWriter(stream);
            return writer;
        }
        public static bool CajonMonedero(string sParamPrinter)
        {
            bool bOk = true;

            System.IO.StreamWriter fs2 = null;

            try
            {
                fs2 = GetStreamWriter(sParamPrinter);
                if (fs2 != null)
                {
                    fs2.WriteLine(Convert.ToChar(27).ToString() + Convert.ToChar(112).ToString() + Convert.ToChar(0).ToString() + Convert.ToChar(25).ToString() + Convert.ToChar(250).ToString());

                    //fs2.WriteLine(Convert.ToChar(27).ToString() + Convert.ToChar(112).ToString() + Convert.ToChar(0).ToString());
                    //fs2.WriteLine(Convert.ToChar(27).ToString() + Convert.ToChar(112).ToString() + Convert.ToChar(48).ToString() + Convert.ToChar(25).ToString() + Convert.ToChar(250).ToString());
                    //fs2.WriteLine(Convert.ToChar(27).ToString() + Convert.ToChar(25).ToString() + Convert.ToChar(250).ToString());

                    fs2.Close();
                }
            }
            catch (Exception ex)
            {
                bOk = false;
            }
            finally
            {
            }

            return bOk;
        }


        //////////////////

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
        public static void openCashDrawer(string paramPrinterName, byte[] paramCodes)
        {
            if (!string.IsNullOrWhiteSpace(paramPrinterName))
            {
                if (paramCodes.Length > 0)
                {
                    //byte[] codeOpenCashDrawer = new byte[] { 27, 112, 0, 25, 250 };
                    IntPtr pUnmanagedBytes = new IntPtr(0);
                    pUnmanagedBytes = Marshal.AllocCoTaskMem(5);
                    Marshal.Copy(paramCodes, 0, pUnmanagedBytes, 5);
                    SendBytesToPrinter(paramPrinterName, pUnmanagedBytes, 5);
                    Marshal.FreeCoTaskMem(pUnmanagedBytes);
                }
            }
        }
    }
}
