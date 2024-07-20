# MAUI Lucky Cat Lotto Numbers

## What is this?

This was a port attempt of an Android app [LottoNumbers](https://github.com/reggieray/LottoNumbers) created with [Xamarin.Forms](https://dotnet.microsoft.com/en-us/apps/xamarin/xamarin-forms) in the aim to understand and compare dotnet [MAUI](https://dotnet.microsoft.com/en-us/apps/maui).

This port is also not complete as there are a few areas still missing such as styles.

## Xamarin.Forms Background 

The purpose of the app itself was to generate numbers for lottery games. You pick a game from the drop-down of games and click Generate Numbers. 

From a tech perspective this was a demo of Xamarin.Froms highlighting code you would use in a production application, including but not limited to: 

- MVVM
- Dependency Injection 
- Navigation
- Animation
- Firebase
- Custom controls
- OS specific features

It achieved most app structure related code through the use of [Prism](https://docs.prismlibrary.com/docs/) which is a popular framework for creating robust XAML applications.

## .NET MAUI

As part of this port it still touches areas highlighted above, but also makes the intentional move away from Prism.

Apart from .NET MAUI libraries it also makes use of:

- [MVVM toolkit](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)
- [AsyncAwaitBestPractices](https://github.com/brminnick/AsyncAwaitBestPractices)
- [Plugin.Firebase](https://github.com/TobiasBuchholz/Plugin.Firebase)
- [SkiaSharp](https://github.com/mono/SkiaSharp.Extended)
