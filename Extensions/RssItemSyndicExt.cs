using AppHero2.Models;
using AppHero2.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Data.Html;
using Windows.Web.Syndication;

namespace AppHero2.Extensions
{
	public static class RssItemSyndicExt
	{
		public static void ParseSyndicationItem(this RssItem item, SyndicationFeed syndicFeed, SyndicationItem syndicItem)
		{
			item.Title = syndicItem.Title.Text;
			item.PubDate = syndicItem.PublishedDate.DateTime;
			item.Author = syndicItem.Authors.Count > 0 ? syndicItem.Authors[0].Name.ToString() : "";
			if (syndicItem.Id.StartsWith("http"))
			{
				item.Link = syndicItem.Id;
			}
			else if (syndicItem.Links.Count > 0)
			{
				item.Link = syndicItem.Links[0].Uri.OriginalString;
			}

			item.ParseImage(syndicItem.NodeValue);

			if (syndicFeed.SourceFormat == SyndicationFormat.Atom10)
			{
				item.Content = HtmlUtilities.ConvertToText(syndicItem.Content.Text);
			}
			else if (syndicFeed.SourceFormat == SyndicationFormat.Rss20)
			{
				item.Content = HtmlUtilities.ConvertToText(syndicItem.Summary.Text);
			}
		}

		public static void ParseImage(this RssItem item, string nodeValue)
		{
			Match match = Regex.Match(nodeValue, @"(?<=<img\s+[^>]*?src=(?<q>['""]))(?<url>.+?)(?=\k<q>)", RegexOptions.IgnoreCase);
			var imageExtension = new[] { ".jpg", ".png", ".bmp", ".gif", ".jpeg", ".JPG", ".PNG", ".BMP", ".GIF", ".JPEG", ".tiff", ".TIFF" };

			string imageUri = string.Empty;
			if (match.Success)
			{
				imageUri = match.Groups[0].Value;
			}

			if (imageExtension.Any(str => { return imageUri.EndsWith(str) && imageUri.StartsWith("http"); }))
			{
				item.ImageUri = imageUri;
			}
			else
			{
				item.ImageUri = "/Assets/RssItemIcon.png";
			}
		}
	}
}
