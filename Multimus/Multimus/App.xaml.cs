using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using Multimus.Plugin;
using Multimus.Models;

namespace Multimus
{
    public partial class App : Application
    {
        public App()
        {
            var pluginList = new List<IPlayerPlugin>
            {
                new Multimus.Plugin.VLC.VLCPlugin()
            };
            PlayerChooser.Init(pluginList);
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
