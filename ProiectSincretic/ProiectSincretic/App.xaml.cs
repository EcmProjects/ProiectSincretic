using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectSincretic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           
            MainPage = new MainPage();
        }

    

        protected async override void OnStart()
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
