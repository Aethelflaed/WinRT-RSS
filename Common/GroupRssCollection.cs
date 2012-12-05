using AppHero2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHero2.Common
{
	public class GroupRssCollection : ObservableCollection<RssCollection>, IRssCollection
	{
		public string Title { get; set; }
	}
}
