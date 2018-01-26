using System;
using System.Runtime.InteropServices;

namespace VideoGameMusicDownloader
{
    /// <summary>
    /// Static wrapper for some native taskbar functions allowing convenient usage of more advanced features.
    /// </summary>
    public static class TaskbarUtils
    {
        #region Initialization

        private static ITaskbarList3 TaskbarList;

        static TaskbarUtils()
        {
            // Window 7 identifies itself as 6.1
            var os = System.Environment.OSVersion;
            var isSupported = os.Version.Major > 6 || (os.Version.Major == 6 && os.Version.Minor >= 1);

            if ( isSupported )
            {
                try
                {
                    TaskbarList = (ITaskbarList3)new CTaskbarList();
                    TaskbarList.HrInit(); // This method must be called before any other methods
                }
                catch
                {
                    TaskbarList = null;
                }
            }
        }

        #endregion Initialization

        #region Public Interface

        /// <summary>
        /// Flags that control the current state of the progress button. Specify only one of the following flags; all states are mutually exclusive of all others.
        /// </summary>
        /// <seealso cref="https://msdn.microsoft.com/en-us/library/windows/desktop/dd391697(v=vs.85).aspx"/>
        public enum ProgressState
        {
            /// <summary>
            /// Stops displaying progress and returns the button to its normal state.
            /// Call this method with this flag to dismiss the progress bar when the operation is complete or canceled.
            /// </summary>
            NoProgress = 0x0,

            /// <summary>
            /// The progress indicator does not grow in size, but cycles repeatedly along the length of the taskbar button.
            /// This indicates activity without specifying what proportion of the progress is complete.
            /// Progress is taking place, but there is no prediction as to how long the operation will take.
            /// </summary>
            Indeterminate = 0x1,

            /// <summary>
            /// The progress indicator grows in size from left to right in proportion to the estimated amount of the operation completed.
            /// This is a determinate progress indicator; a prediction is being made as to the duration of the operation.
            /// </summary>
            Normal = 0x2,

            /// <summary>
            /// The progress indicator turns red to show that an error has occurred in one of the windows that is broadcasting progress.
            /// This is a determinate state. If the progress indicator is in the indeterminate state, it switches to a red determinate display of a generic percentage not indicative of actual progress.
            /// </summary>
            Error = 0x4,

            /// <summary>
            /// The progress indicator turns yellow to show that progress is currently stopped in one of the windows but can be resumed by the user
            /// No error condition exists and nothing is preventing the progress from continuing. This is a determinate state.
            /// If the progress indicator is in the indeterminate state, it switches to a yellow determinate display of a generic percentage not indicative of actual progress.
            /// </summary>
            Paused = 0x8
        }

        /// <summary>
        /// Sets the type and state of the progress indicator displayed on a taskbar button.
        /// </summary>
        /// <param name="windowHandle">The handle of the window in which the progress of an operation is being shown. This window's associated taskbar button will display the progress bar.</param>
        /// <param name="state">Flags that control the current state of the progress button.</param>
        public static void SetProgressState(IntPtr windowHandle, ProgressState state)
        {
            if ( TaskbarList != null )
                TaskbarList.SetProgressState(windowHandle, state);
        }

        /// <summary>
        /// Displays or updates a progress bar hosted in a taskbar button to show the specific percentage completed of the full operation.
        /// </summary>
        /// <param name="windowHandle">he handle of the window whose associated taskbar button is being used as a progress indicator.</param>
        /// <param name="current">An application-defined value that indicates the proportion of the operation that has been completed at the time the method is called.</param>
        /// <param name="maximum">An application-defined value that specifies the value current will have when the operation is complete.</param>
        public static void SetProgressValue(IntPtr windowHandle, ulong current, ulong maximum)
        {
            if ( TaskbarList != null )
                TaskbarList.SetProgressValue(windowHandle, current, maximum);
        }

        /// <summary>
        /// Flashes the taskbar button of the window with the provided window handle for the given amount of times, or until window becomes the foreground window.
        /// </summary>
        /// <param name="windowHandle">The handle of the main window the taskbar is associated with.</param>
        /// <param name="count">The amount of time the taskbar button of the window should blink. Use value 0 stop when window comes to the foreground.</param>
        public static void Flash(IntPtr windowHandle, uint count = 0)
        {
            FLASHWINFO fInfo = new FLASHWINFO()
            {
                cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO))),
                hwnd = windowHandle,
                dwFlags = (uint)(DWFLAGS.FLASHW_ALL | (count == 0 ? DWFLAGS.FLASHW_TIMERNOFG : 0)),
                uCount = count,
                dwTimeout = 0,
            };
            FlashWindowEx(ref fInfo);
        }

        #endregion Public Interface

        #region FlshWindowEx

        /// <summary>
        /// Flashes the specified window. It does not change the active state of the window.
        /// </summary>
        /// <seealso cref="https://msdn.microsoft.com/de-de/library/windows/desktop/ms679347(v=vs.85).aspx"/>
        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        /// <summary>
        /// Contains the flash status for a window and the number of times the system should flash the window.
        /// </summary>
        /// <seealso cref="https://msdn.microsoft.com/de-de/library/windows/desktop/ms679348(v=vs.85).aspx"/>
        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public UInt32 cbSize;   // The size of the structure, in bytes.
            public IntPtr hwnd;     // A handle to the window to be flashed. The window can be either opened or minimized.
            public UInt32 dwFlags;  // The flash status. See DWFLAGS enum below.
            public UInt32 uCount;   // The number of times to flash the window.
            public Int32 dwTimeout; // The rate at which the window is to be flashed, in milliseconds. If dwTimeout is zero, the function uses the default cursor blink rate.
        }

        /// <summary>
        /// The flash status. This parameter can be one or more of the following values. 
        /// </summary>
        /// <seealso cref="https://msdn.microsoft.com/de-de/library/windows/desktop/ms679348(v=vs.85).aspx"/>
        private enum DWFLAGS : uint
        {
            FLASHW_STOP = 0x0,      // Stop flashing. The system restores the window to its original state.
            FLASHW_CAPTION = 0x1,   // Flash the window caption.
            FLASHW_TRAY = 0x2,      // Flash the taskbar button.
            FLASHW_ALL = 0x3,       // Flash both the window caption and taskbar button. This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
            FLASHW_TIMER = 0x4,     // Flash continuously, until the FLASHW_STOP flag is set.
            FLASHW_TIMERNOFG = 0xc  // Flash continuously until the window comes to the foreground.
        }

        #endregion FlshWindowEx

        #region ITaskbarList3

        /// <summary>
        /// THUMBBUTTON mask.  THB_*
        /// </summary>
        [Flags]
        private enum THB : uint
        {
            BITMAP = 0x0001,
            ICON = 0x0002,
            TOOLTIP = 0x0004,
            FLAGS = 0x0008,
        }

        /// <summary>
        /// THUMBBUTTON flags.  THBF_*
        /// </summary>
        [Flags]
        private enum THBF : uint
        {
            ENABLED = 0x0000,
            DISABLED = 0x0001,
            DISMISSONCLICK = 0x0002,
            NOBACKGROUND = 0x0004,
            HIDDEN = 0x0008,
            // Added post-beta
            NONINTERACTIVE = 0x0010,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Unicode)]
        private struct THUMBBUTTON
        {
            /// <summary>
            /// WPARAM value for a THUMBBUTTON being clicked.
            /// </summary>
            public const int THBN_CLICKED = 0x1800;

            public THB dwMask;
            public uint iId;
            public uint iBitmap;
            public IntPtr hIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szTip;
            public THBF dwFlags;

        }

        [ComImportAttribute()]
        [GuidAttribute("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
        [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        private interface ITaskbarList3
        {
            #region ITaskbarList2 redeclaration

            #region ITaskbarList redeclaration
            void HrInit();
            void AddTab(IntPtr hwnd);
            void DeleteTab(IntPtr hwnd);
            void ActivateTab(IntPtr hwnd);
            void SetActiveAlt(IntPtr hwnd);
            #endregion

            void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

            #endregion

            [PreserveSig]
            void SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);

            [PreserveSig]
            void SetProgressState(IntPtr hwnd, ProgressState tbpFlags);

            [PreserveSig]
            void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);

            [PreserveSig]
            void UnregisterTab(IntPtr hwndTab);

            [PreserveSig]
            void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);

            [PreserveSig]
            void SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, uint dwReserved);

            [PreserveSig]
            void ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

            [PreserveSig]
            void ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] THUMBBUTTON[] pButtons);

            [PreserveSig]
            void ThumbBarSetImageList(IntPtr hwnd, [MarshalAs(UnmanagedType.IUnknown)] object himl);

            [PreserveSig]
            void SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);

            [PreserveSig]
            void SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);
        }

        [GuidAttribute("56FDF344-FD6D-11d0-958A-006097C9A090")]
        [ClassInterfaceAttribute(ClassInterfaceType.None)]
        [ComImportAttribute()]
        private class CTaskbarList { }

        #endregion ITaskbarList3
    }
}
