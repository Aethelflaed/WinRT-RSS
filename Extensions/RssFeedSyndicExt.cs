using AppHero2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;
using AppHero2.Extensions;
using System.Collections.ObjectModel;

namespace AppHero2.Extensions
{
	public static class RssFeedSyndicExt
	{
		public static void ParseSyndicationFeed(this RssFeed feed, SyndicationFeed syndicFeed)
		{
			feed.Title = syndicFeed.Title.Text;
			if (syndicFeed.Subtitle != null && syndicFeed.Subtitle.Text != null)
			{
				feed.Description = syndicFeed.Subtitle.Text;
			}

			feed.PubDate = new DateTime();
			feed.Items = new ObservableCollection<RssItem>();
			RssItem item;

			bool dateSet = false;
			foreach (SyndicationItem syndicItem in syndicFeed.Items)
			{
				item = new RssItem();

				item.ParseSyndicationItem(syndicFeed, syndicItem);

				if (dateSet == false)
				{
					feed.PubDate = item.PubDate;
					dateSet = true;
				}
				feed.Items.Add(item);
			}
		}
	}
}
