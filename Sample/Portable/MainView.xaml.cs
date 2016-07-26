using Rox;
using Xamarin.Forms;

namespace RoxSample
{
    public partial class MainView
        : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        public VideoView GetVideoView()
        {
            return VideoView;
        }
    }
}