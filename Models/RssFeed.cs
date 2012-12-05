using AppHero2.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AppHero2.Models
{
	public class RssFeed : BindableBase
	{
		private string _title;

		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		private string _description;

		public string Description
		{
			get { return _description; }
			set { SetProperty(ref _description, value); }
		}

		private DateTime _pubDate;

		public DateTime PubDate
		{
			get { return _pubDate; }
			set { SetProperty(ref _pubDate, value); }
		}

		private ObservableCollection<RssItem> _items;

		public ObservableCollection<RssItem> Items
		{
			get { return _items; }
			set { SetProperty(ref _items, value); }
		}


	}
}
