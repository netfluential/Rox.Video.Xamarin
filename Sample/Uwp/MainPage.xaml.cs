namespace RoxSample
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new VideoApplication());
        }
    }
}