using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OfficeCoreExer
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            this.BindingContext = App.container.Resolve(typeof(MainViewModel), "", new Unity.Resolution.ParameterOverride[0]);
		}
	}
}
