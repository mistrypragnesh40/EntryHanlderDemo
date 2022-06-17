using EntryHanlderDemo.Handlers;
using Microsoft.Maui.Platform;

namespace EntryHanlderDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        // Lets create handler for borderless entry

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });

        MainPage = new AppShell();
	}
}
