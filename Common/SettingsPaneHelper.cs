using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;

namespace AppHero2.Common
{
	public class SettingsPaneHelper
	{
		public static void OnSettingsPaneCommandRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
		{
			// Add the commands one by one to the settings panel
			if (args.Request.ApplicationCommands.Where((x) => { return x.Label == "Privacy Policy"; }).Count() < 1)
			{
				args.Request.ApplicationCommands.Add(new SettingsCommand("commandID", "Privacy Policy", DoOperation));
			}
		}

		public static async void DoOperation(IUICommand command)
		{
			Uri uri = new Uri("http://aethelflaed.github.com/PrivacyPolicy/");
			await Windows.System.Launcher.LaunchUriAsync(uri);
		}
	}
}
