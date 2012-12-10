WinRT-RSS
=========

A Visual Studio 2012 Windows Store Class Library project to easily generate RSS based applications.

This project enables you to create full-featured RSS application in a very simple way.

Requirements
------------

- Visual Studio 2012
- An internet connection
- Some very basic knowledge of XAML and C#

Usage
-----

- Create a new *Blank App (XAML)* in Visual Studio.
- Add WinRT-RSS (RssCodeBase) project to the solution.
- In your blank app, add the NuGet reference to MVVM Light
- Add the project reference to RssCodeBase
- Delete the folders `Common`, `ViewModel` and the file `MainPage.xaml` (with `MainPage.xaml.cs`) from the project.

You are now ready to create your first RSS app ! The only modification you have to do are in `App.xaml` and `App.xaml.cs.`

In `App.xaml` you need to update the xml namespace definition, replace `xmlns:vm="clr-namespace:Test.ViewModel"` by `xmlns:vm="using:AppHero2.ViewModel"`. This will fix MVVM Light bug with the new *using* syntax, and use WinRT-RSS ViewModels.
You also need to add the common namespace : `xmlns:common="using:AppHero2.Common"` just under the `xmlns:vm` line.

In the `ResourceDictionary.MergedDictionaries` part of the file, replace the Source attribute by `RssCodeBase/Common/StandardStyles.xaml` to link to the library styles definition.

Then add the following lines under `<vm:ViewModelLocator>` definition :

```xaml
  		<x:String x:Key="AppName">My awesome RSS App !</x:String>

			<common:BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter" />
			<common:BooleanNegationConverter x:Key="BooleanNegationConverter" />
			<common:BooleanToInvisibilityConverter x:Key="BooleanToInvisibilityConverter" />

			<x:String x:Key="AppTitleImageUri">/Assets/TitleLogo.png</x:String>
			<x:Boolean x:Key="IsAppTitleAnImage">False</x:Boolean>

			<x:String x:Key="AllRss_Title">My awesome RSS App !</x:String>
			<x:String x:Key="AllRss_Group">Tous</x:String>
			<x:Boolean x:Key="AllRss_Enabled">False</x:Boolean>
```

Want to build now ? We just have to fix the error in `App.xaml.cs`. As we deleted MainPage.xaml, we have to specify another start page, let's do it !

We replace :

```csharp
  if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
  {
    throw new Exception("Failed to create initial page");
  }
```

by

```csharp
  object parameter = new RssViewModelInfo()
  {
	  FeedUri = "http://myawesomefeed.com/rss"
	};
	if (!rootFrame.Navigate(typeof(FeedDetails), parameter))
	{
	  throw new Exception("Failed to create initial page");
	}
```

Without forgetting the `using AppHero2.ViewModel;` and `using AppHero2.Views;` lines at the begining of the file ;)

You can test, it should work with that ! Note that the styles are best suited for feeds with some text and at least an image in their content.