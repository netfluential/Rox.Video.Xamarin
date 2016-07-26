using Rox;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace RoxSample
{
    public class MainViewModel
        : INotifyPropertyChanged
    {
        private readonly VideoView VideoView;
        public MainViewModel(VideoView videoView)
        {
            VideoView = videoView;
        }

        private bool _AutoPlay = false;
        //public bool SwitchAutoPlay
        public bool AutoPlay
        {
            get
            {
                return _AutoPlay;
            }
            set
            {
                _AutoPlay = value;

                OnPropertyChanged(nameof(AutoPlay));

                //OnPropertyChanged(nameof(SwitchAutoPlay));
                //OnPropertyChanged(nameof(VideoAutoPlay));
            }
        }

        //public bool VideoAutoPlay
        //{
        //    get
        //    {
        //        return _AutoPlay;
        //    }
        //}

        private bool _LoopPlay = false;
        //public bool SwitchLoopPlay
        public bool LoopPlay
        {
            get
            {
                return _LoopPlay;
            }
            set
            {
                _LoopPlay = value;

                OnPropertyChanged(nameof(LoopPlay));

                //OnPropertyChanged(nameof(SwitchLoopPlay));
                //OnPropertyChanged(nameof(VideoLoopPlay));
            }
        }

        //public bool VideoLoopPlay
        //{
        //    get
        //    {
        //        return _LoopPlay;
        //    }
        //}

        private bool _ShowController = false;
        //public bool SwitchShowController
        public bool ShowController
        {
            get
            {
                return _ShowController;
            }
            set
            {
                _ShowController = value;

                OnPropertyChanged(nameof(ShowController));

                //OnPropertyChanged(nameof(SwitchShowController));
                //OnPropertyChanged(nameof(VideoShowController));
            }
        }

        //public bool VideoShowController
        //{
        //    get
        //    {
        //        return _ShowController;
        //    }
        //}

        private bool _Muted = false;
        //public bool SwitchMuted
        public bool Muted
        {
            get
            {
                return _Muted;
            }
            set
            {
                _Muted = value;

                OnPropertyChanged(nameof(Muted));

                //OnPropertyChanged(nameof(SwitchMuted));
                //OnPropertyChanged(nameof(VideoMuted));
            }
        }

        //public bool VideoMuted
        //{
        //    get
        //    {
        //        return _Muted;
        //    }
        //}

        private double _Volume = 1;
        //public double SliderVolume
        public double Volume
        {
            get
            {
                return _Volume * 100;
            }
            set
            {
                try
                {
                    _Volume = value / 100;
                }
                catch
                {
                    _Volume = 0;
                }

                OnPropertyChanged(nameof(Volume));

                //OnPropertyChanged(nameof(SliderVolume));
                //OnPropertyChanged(nameof(VideoVolume));
            }
        }

        //public double VideoVolume
        //{
        //    get
        //    {
        //        return _Volume;
        //    }
        //}

        private string _LabelVideoStatus;
        public string LabelVideoStatus
        {
            get
            {
                return _LabelVideoStatus;
            }
        }

        public ICommand VideoStateChangedCommand
        {
            get
            {
                return new Command(() =>
                {
                    _LabelVideoStatus = VideoView.VideoState.ToString();

                    OnPropertyChanged(nameof(LabelVideoStatus));
                });
            }
        }

        private string _Source = "http://www.sample-videos.com/video/mp4/720/big_buck_bunny_720p_1mb.mp4";
        public string EntrySource
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;

                OnPropertyChanged(nameof(EntrySource));
                OnPropertyChanged(nameof(VideoSource));
            }
        }

        public ImageSource VideoSource
        {
            get
            {
                ImageSource videoSource = null;
                try
                {
                    ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                    videoSource = (ImageSource)imageSourceConverter.ConvertFromInvariantString(_Source);
                }
                catch
                {
                }
                return videoSource;
            }
        }

        public ICommand PlayCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await VideoView.Start();
                });
            }
        }

        public ICommand PauseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await VideoView.Pause();
                });
            }
        }

        public ICommand StopCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await VideoView.Stop();
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventArgs eventArgs = new PropertyChangedEventArgs(propertyName);

            PropertyChanged?.Invoke(this, eventArgs);
        }
    }
}