using AppHero2.Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace AppHero2.ViewModel
{
	public class FeedsViewModel : ViewModelBase
	{
		private RssViewModelInfo _selectedFeed;
		
		public Boolean AreAllRssEnabled { get; set; }
		public String AllRssTitle { get; set; }

		public RssViewModelInfo SelectedFeed
		{
			get
			{
				return _selectedFeed;
			}
			set
			{
				Set("SelectedFeed", ref _selectedFeed, value);
			}
		}

		public RssCollection Feeds
		{
			get;
			set;
		}

		public GroupRssCollection RssCollections
		{
			get;
			set;
		}

		public IRssCollection Collection
		{
			get
			{
				if (this.Feeds != null)
				{
					return this.Feeds;
				}
				return this.RssCollections;
			}
		}

		public Boolean IsSourceGrouped
		{
			get
			{
				return this.Feeds == null;
			}
		}

		public FeedsViewModel()
		{
			ResourceDictionary res = Application.Current.Resources;
			this.AllRssTitle = res["AllRss_Title"] as String;
			var rssEnabled = res["AllRss_Enabled"];
			this.AreAllRssEnabled = (rssEnabled is Boolean) && (Boolean)rssEnabled == true;

			String allRssGroup = res["AllRss_Group"] as String;
			
			var collection = res["RssFeeds"];

			if (collection is RssCollection)
			{
				this.Feeds = collection as RssCollection;
				if (this.AreAllRssEnabled)
				{
					Feeds.Insert(0, new RssViewModelInfo()
					{
						Title = allRssGroup,
						_viewModel = null,
						ViewModel = getAllRssViewModel
					});
				}
			}
			else if (collection is GroupRssCollection)
			{
				this.RssCollections = collection as GroupRssCollection;
			}
		}

		private AllRssViewModel _viewModel = null;
		public AllRssViewModel getAllRssViewModel()
		{
			return _viewModel ?? (_viewModel = new AllRssViewModel(this.AllRssTitle));
		}
	}
}
