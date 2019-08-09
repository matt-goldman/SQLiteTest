using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteTest
{
    public partial class App : Application
    {

        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database();
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage(new MainPageViewModel());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
