using AppHero2.Common;
using AppHero2.Models;
using AppHero2.Providers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using Windows.UI.Popups;

namespace AppHero2.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
	/// </para>
	/// <para>
	/// You can also use Blend to data bind with the tool's support.
	/// </para>
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class RssVMBase : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public RssVMBase(string feedUri)
		{
			getFeed(feedUri);
			init();
		}

		public RssVMBase()
		{
			init();
		}

		private void init()
		{
			this.GoToCommand = new RelayCommand(GoToLink, CanGoTo);
		}

		private async void GoToLink()
		{
			await Windows.System.Launcher.LaunchUriAsync(new Uri(SelectedItem.Link));
		}

		private bool CanGoTo()
		{
			return SelectedItem != null && string.IsNullOrEmpty(SelectedItem.Link) == false;
		}


		protected RssFeed _feed;

		public RssFeed Feed
		{
			get { return _feed; }
			set { Set("Feed", ref _feed, value); }
		}

		private RssItem _selectedItem;

		public RssItem SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				Set("SelectedItem", ref _selectedItem, value);
				GoToCommand.RaiseCanExecuteChanged();
			}
		}

		private RelayCommand _goToCommand;
		public RelayCommand GoToCommand
		{
			get
			{
				return _goToCommand;
			}
			set
			{
				Set("GoToCommand", ref _goToCommand, value);
			}
		}

		private async void getFeed(string feedUri)
		{
			RssProvider provider = new RssProvider();
			Feed = await provider.GetFeedAsync(feedUri);
		}
	}
}