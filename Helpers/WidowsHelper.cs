namespace HorizonHub.Helpers {

    public static class WidowsHelper {

        public static AppWindow? GetAppWindowFromWindow(WindowEx window) {
            if(window != null) {
                var hwnd = WindowNative.GetWindowHandle(window);
                var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
                return AppWindow.GetFromWindowId(windowId);
            }

            return null;
        }

        public static void ConfigureTitleBar(WindowEx window, string title) {

            if(window != null) {

                window.ExtendsContentIntoTitleBar = true;

                window.Title = title;

                window.SetIcon(Constants.appIconName);

                var titleBar = new CustomTitleBar(new CustomTitleBarViewModel() {
                    Title = title
                }) {
                    Height = 48,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Top,
                };

                var appWindow = GetAppWindowFromWindow(window);

                appWindow!.TitleBar.ButtonHoverForegroundColor = Colors.Transparent;
                appWindow!.TitleBar.PreferredHeightOption = TitleBarHeightOption.Tall;


                //var rootGrid = window.Content as Grid;

                //if(rootGrid != null) {
                //    rootGrid.Children.Insert(0, titleBar);
                //    window.SetTitleBar(titleBar);
                //}
            }
        }

        public static void CreateWindow(WindowEx window, string title) {

            window.IsResizable = false;
            ConfigureTitleBar(window, title);
            window.SystemBackdrop = new MicaBackdrop();
            window.Activate();
        }
    }
}
