using Xamarin.Forms;

namespace RoxSample
{
    public partial class VideoApplication
        : Application
    {
        public VideoApplication()
        {
            InitializeComponent();

            MainView mainView = new MainView();
            MainViewModel mainViewModel = new MainViewModel(mainView.GetVideoView());
            mainView.BindingContext = mainViewModel;

            MainPage = mainView;
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