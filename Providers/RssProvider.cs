using AppHero2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Syndication;
using AppHero2.Extensions;

namespace AppHero2.Providers
{
	public class RssProvider
	{
		public async Task<RssFeed> GetFeedAsync(String feedUri)
		{
			SyndicationClient client = new SyndicationClient();
			Uri uri = new Uri(feedUri);

			SyndicationFeed syndicationFeed = await client.RetrieveFeedAsync(uri);

			RssFeed feed = new RssFeed();
			feed.ParseSyndicationFeed(syndicationFeed);

			return feed;
		}
	}
}
