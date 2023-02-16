namespace GameOverlay.Native;

internal static class Dwmapi
{
    public const string LibraryName = "dwmapi.dll";

    [DllImport(LibraryName)]
    internal static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);

    [StructLayout(LayoutKind.Sequential)]
    internal struct Margins
    {
        private readonly int left;
        private readonly int right;
        private readonly int top;
        private readonly int bottom;

        internal Margins(int l)
        {
            left = right = top = bottom = l;
        }

        internal Margins(int l, int r, int t, int b)
        {
            left = l;
            right = r;
            top = t;
            bottom = b;
        }
    }
}
