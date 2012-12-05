using AppHero2.Common;
using AppHero2.Models;
using AppHero2.Providers;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
	public class AllRssViewModel : RssVMBase
	{
		public new RssFeed Feed
		{
			get
			{
				return _feed;
			}
			private set
			{
				_feed = value;
			}
		}

		public AllRssViewModel(string title)
		{
			this.Feed = new RssFeed()
			{
				Title = title
			};

			FeedsViewModel feedsVM = ViewModelLocator.Main;

			int i = 0;
			foreach (RssViewModelInfo vmInfo in feedsVM.Feeds)
			{
				i++;
				if (i > 1)
				{
					if (vmInfo.ViewModel().Feed != null)
					{
						vmInfo.ViewModel().Feed.PropertyChanged += Feed_PropertyChanged;
					}
					else
					{
						vmInfo.ViewModel().PropertyChanged += VM_PropertyChanged;
					}
				}
			}
			GenerateItemsList();
		}

		private void GenerateItemsList()
		{
			ObservableCollection<RssItem> items = new ObservableCollection<RssItem>();
			int i = 0;
			foreach (RssViewModelInfo vmInfo in ViewModelLocator.Main.Feeds)
			{
				i++;
				if (i > 1)
				{
					if (vmInfo.ViewModel().Feed != null)
					{
						foreach (RssItem item in vmInfo.ViewModel().Feed.Items)
						{
							items.Add(item);
						}
					}
				}
			}
			this.Feed.Items = items;
		}

		private void Feed_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Items")
			{
				GenerateItemsList();
			}
		}

		private void VM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Feed" && (sender as RssVMBase).Feed != null)
			{
				(sender as RssVMBase).Feed.PropertyChanged += Feed_PropertyChanged;
				GenerateItemsList();
			}
		}
	}
}