using Rox;
using Xamarin.Forms;

namespace Rox
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