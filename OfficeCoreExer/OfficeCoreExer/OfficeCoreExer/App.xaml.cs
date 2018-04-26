using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;
using Unity.Lifetime;
using Xamarin.Forms;

namespace OfficeCoreExer
{
	public partial class App : Application
	{
        public static IUnityContainer container;

        public App ()
		{
            InitIoc();

            InitializeComponent();

			MainPage = new OfficeCoreExer.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}


        private void InitIoc()
        {
            container = new UnityContainer();
            container.RegisterType<ISongsFetchingService, ItunesService>();
        }

    }
}
