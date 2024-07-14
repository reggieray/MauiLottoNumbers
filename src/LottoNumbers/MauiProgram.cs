using LottoNumbers.Services;
using LottoNumbers.ViewModels;
using LottoNumbers.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Plugin.Firebase.RemoteConfig;
using Plugin.Firebase.Bundled.Shared;
using CommunityToolkit.Maui;


#if ANDROID
using Plugin.Firebase.Bundled.Platforms.Android;
#endif

namespace LottoNumbers;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .RegisterFirebaseServices()
            .UseSkiaSharp()
            .RegisterServices()
            .RegisterViewModels()
            .RegisterViews()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ILottoGameService, LottoGameService>();
        mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
        mauiAppBuilder.Services.AddTransient(x => Preferences.Default);

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();
        mauiAppBuilder.Services.AddSingleton<SettingsPageViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainPage>();
        mauiAppBuilder.Services.AddSingleton<SettingsPage>();

        return mauiAppBuilder;
    }

    private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events => {

            // Included as an example https://github.com/TobiasBuchholz/Plugin.Firebase
            //#if IOS
            //            events.AddiOS(iOS => iOS.WillFinishLaunching((_,__) => {
            //                CrossFirebase.Initialize();
            //                return false;
            //            }));


#if ANDROID
            events.AddAndroid(android => android.OnCreate((activity, _) => 
            {
                var settings = new CrossFirebaseSettings(isRemoteConfigEnabled: true);
                CrossFirebase.Initialize(activity, settings);
            }));
#endif
        });

        builder.Services.AddSingleton(_ => CrossFirebaseRemoteConfig.Current);
        builder.Services.AddSingleton<IRemoteConfigService, RemoteConfigService>();

        return builder;
    }
}
