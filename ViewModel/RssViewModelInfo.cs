using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHero2.ViewModel
{
	public class RssViewModelInfo
	{
		private string _image;

		public string Image
		{
			get { return _image; }
			set { _image = value; }
		}


		public string Title { get; set; }
		public string FeedUri { get; set; }
		public Func<RssVMBase> ViewModel { get; set; }
		public RssVMBase _viewModel { get; set; }

		public RssViewModelInfo()
		{
			this.ViewModel = () => { return _viewModel ?? (_viewModel = new RssVMBase(FeedUri)); };
			this.Image = "/Assets/FeedItemIcon.png";
		}
	}
}
