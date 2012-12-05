using AppHero2.Common;
using System;

namespace AppHero2.Models
{
	public class RssItem : BindableBase
	{
		private string _title;

		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}
		

		private string _author;

		public string Author
		{
			get { return _author; }
			set { SetProperty(ref _author, value); }
		}

		private string _content;

		public string Content
		{
			get { return _content; }
			set { SetProperty(ref _content, value); }
		}

		private DateTime _pubDate;

		public DateTime PubDate
		{
			get { return _pubDate; }
			set { SetProperty(ref _pubDate, value); }
		}

		private string _link;

		public string Link
		{
			get { return _link; }
			set { SetProperty(ref _link, value); }
		}

		private string _imageUri;

		public string ImageUri
		{
			get { return _imageUri; }
			set { SetProperty(ref _imageUri, value); }
		}
	}
}
