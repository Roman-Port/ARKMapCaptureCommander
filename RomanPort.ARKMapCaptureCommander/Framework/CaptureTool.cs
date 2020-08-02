using RomanPort.ARKMapCaptureCommander.Framework.Entities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RomanPort.ARKMapCaptureCommander.Framework
{
    public static class CaptureTool
    {
        //Much of the code in this class is thanks to https://stackoverflow.com/questions/891345/get-a-screenshot-of-a-specific-application

        private const int WINDOW_PADDING_SIZE = 9;
        private const int WINDOW_TOP_PADDING_SIZE = 32;

        private const int SEA_COLOR_REFERENCE_R = 48;
        private const int SEA_COLOR_REFERENCE_G = 115;
        private const int SEA_COLOR_REFERENCE_B = 183;

        public static Image<Rgba32> ConvertBitmapToImage(DirectBitmap bp, out int maxDiff)
        {
            //Create ImageSharp bitmap and copy
            Image<Rgba32> img = new Image<Rgba32>(bp.Width - (WINDOW_PADDING_SIZE * 2), bp.Height - WINDOW_PADDING_SIZE - WINDOW_TOP_PADDING_SIZE);
            System.Drawing.Color c;
            maxDiff = 0;
            for (int x = 0; x < img.Width; x++)
            {
                for (int y = 0; y < img.Height; y++)
                {
                    //Read
                    c = bp.GetPixel(x + WINDOW_PADDING_SIZE, y + WINDOW_TOP_PADDING_SIZE);

                    //Convert
                    img[x, y] = new Rgba32(c.R, c.G, c.B, c.A);

                    //Guess if this is just water
                    maxDiff = Math.Max(maxDiff, Math.Abs(c.R - SEA_COLOR_REFERENCE_R));
                    maxDiff = Math.Max(maxDiff, Math.Abs(c.G - SEA_COLOR_REFERENCE_G));
                    maxDiff = Math.Max(maxDiff, Math.Abs(c.B - SEA_COLOR_REFERENCE_B));
                }
            }
            return img;
        }

        public static DirectBitmap PrintWindow(Process p)
        {
            DirectBitmap bp = PrintWindow(p.MainWindowHandle);
            return bp;
        }
        
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        private static DirectBitmap PrintWindow(IntPtr hwnd)
        {
            //Get rect
            RECT rc;
            GetWindowRect(hwnd, out rc);

            DirectBitmap bmp = new DirectBitmap(rc.Width, rc.Height);
            Graphics gfxBmp = Graphics.FromImage(bmp.Bitmap);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            PrintWindow(hwnd, hdcBitmap, 0);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            return bmp;
        }

        /// <summary>
        /// Returns an empty bitmap in the size of a specified window
        /// </summary>
        /// <param name="hwnd"></param>
        public static DirectBitmap GetEmptyBitmapFromWindowRect(Process p)
        {
            //Get rect
            RECT rc;
            GetWindowRect(p.MainWindowHandle, out rc);

            //Create
            DirectBitmap bmp = new DirectBitmap(rc.Width, rc.Height);

            return bmp;
        }

        public static void PrintWindowToBitmap(Process p, DirectBitmap bmp)
        {
            //Get window rect
            RECT rc;
            GetWindowRect(p.MainWindowHandle, out rc);

            //Prepare
            Graphics gfxBmp = Graphics.FromImage(bmp.Bitmap);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            //Write
            PrintWindow(p.MainWindowHandle, hdcBitmap, 0);

            //Clean up
            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            private int _Left;
            private int _Top;
            private int _Right;
            private int _Bottom;

            public RECT(RECT Rectangle) : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
            {
            }
            public RECT(int Left, int Top, int Right, int Bottom)
            {
                _Left = Left;
                _Top = Top;
                _Right = Right;
                _Bottom = Bottom;
            }

            public int X
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Y
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Left
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Top
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Right
            {
                get { return _Right; }
                set { _Right = value; }
            }
            public int Bottom
            {
                get { return _Bottom; }
                set { _Bottom = value; }
            }
            public int Height
            {
                get { return _Bottom - _Top; }
                set { _Bottom = value + _Top; }
            }
            public int Width
            {
                get { return _Right - _Left; }
                set { _Right = value + _Left; }
            }
            public Point Location
            {
                get { return new Point(Left, Top); }
                set
                {
                    _Left = value.X;
                    _Top = value.Y;
                }
            }
            public Size Size
            {
                get { return new Size(Width, Height); }
                set
                {
                    _Right = value.Width + _Left;
                    _Bottom = value.Height + _Top;
                }
            }

            public static implicit operator Rectangle(RECT Rectangle)
            {
                return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
            }
            public static implicit operator RECT(Rectangle Rectangle)
            {
                return new RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
            }
            public static bool operator ==(RECT Rectangle1, RECT Rectangle2)
            {
                return Rectangle1.Equals(Rectangle2);
            }
            public static bool operator !=(RECT Rectangle1, RECT Rectangle2)
            {
                return !Rectangle1.Equals(Rectangle2);
            }

            public override string ToString()
            {
                return "{Left: " + _Left + "; " + "Top: " + _Top + "; Right: " + _Right + "; Bottom: " + _Bottom + "}";
            }

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            public bool Equals(RECT Rectangle)
            {
                return Rectangle.Left == _Left && Rectangle.Top == _Top && Rectangle.Right == _Right && Rectangle.Bottom == _Bottom;
            }

            public override bool Equals(object Object)
            {
                if (Object is RECT)
                {
                    return Equals((RECT)Object);
                }
                else if (Object is Rectangle)
                {
                    return Equals(new RECT((Rectangle)Object));
                }

                return false;
            }
        }
    }
}
