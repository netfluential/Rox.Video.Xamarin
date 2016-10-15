using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Rox
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

        public bool AutoPlay
        {
            get { return _AutoPlay; }
            set
            {
                _AutoPlay = value;

                OnPropertyChanged(nameof(AutoPlay));
            }
        }

        private bool _FullScreen = false;

        public bool FullScreen
        {
            get { return _FullScreen; }
            set
            {
                _FullScreen = value;

                OnPropertyChanged(nameof(FullScreen));
            }
        }

        private double _Volume = 1;

        public double Volume
        {
            get { return _Volume; }
            set
            {
                _Volume = value;

                OnPropertyChanged(nameof(Volume));
                OnPropertyChanged(nameof(SliderVolume));
            }
        }

        public double SliderVolume
        {
            get { return _Volume*100; }
            set
            {
                try
                {
                    _Volume = value/100;
                }
                catch
                {
                    _Volume = 0;
                }

                OnPropertyChanged(nameof(Volume));
                OnPropertyChanged(nameof(SliderVolume));
            }
        }

        private bool _LoopPlay = false;

        public bool LoopPlay
        {
            get { return _LoopPlay; }
            set
            {
                _LoopPlay = value;

                OnPropertyChanged(nameof(LoopPlay));
            }
        }

        private bool _ShowController = false;

        public bool ShowController
        {
            get { return _ShowController; }
            set
            {
                _ShowController = value;

                OnPropertyChanged(nameof(ShowController));
            }
        }

        private bool _Muted = false;

        public bool Muted
        {
            get { return _Muted; }
            set
            {
                _Muted = value;

                OnPropertyChanged(nameof(Muted));
            }
        }

        private TimeSpan _Duration;

        public TimeSpan Duration
        {
            get { return _Duration; }
        }

        public double SliderDuration
        {
            get
            {
                double totalMilliseconds = _Duration.TotalMilliseconds;
                if (totalMilliseconds <= 0)
                {
                    totalMilliseconds = 1;
                }
                return totalMilliseconds;
            }
        }

        private string _LabelVideoStatus;

        public string LabelVideoStatus
        {
            get { return _LabelVideoStatus; }
        }

        private TimeSpan _Position;

        public TimeSpan Position
        {
            get { return _Position; }
            set
            {
                _Position = value;

                OnPropertyChanged(nameof(Position));
                OnPropertyChanged(nameof(SliderPosition));
            }
        }

        public double SliderPosition
        {
            get { return _Position.TotalMilliseconds; }
            set
            {
                try
                {
                    _Position = TimeSpan.FromMilliseconds(value);
                }
                catch
                {
                    _Position = TimeSpan.Zero;
                }

                OnPropertyChanged(nameof(Position));
                OnPropertyChanged(nameof(SliderPosition));
            }
        }

        private TimeSpan _PositionInterval = TimeSpan.FromMilliseconds(500);

        public TimeSpan PositionInterval
        {
            get { return _PositionInterval; }
            set
            {
                _PositionInterval = value;

                OnPropertyChanged(nameof(PositionInterval));
                OnPropertyChanged(nameof(EntryPositionInterval));
            }
        }

        public string EntryPositionInterval
        {
            get { return _PositionInterval.TotalMilliseconds.ToString(); }
            set
            {
                int positionIntervalMilliseconds;
                if (int.TryParse(value, out positionIntervalMilliseconds))
                {
                    _PositionInterval = TimeSpan.FromMilliseconds(positionIntervalMilliseconds);
                }
                else
                {
                    _PositionInterval = TimeSpan.Zero;
                }

                OnPropertyChanged(nameof(PositionInterval));
                OnPropertyChanged(nameof(EntryPositionInterval));
            }
        }

        public ICommand PropertyChangedCommand
        {
            get
            {
                return new Command<string>((propertyName) =>
                {
                    switch (propertyName)
                    {
                        case nameof(VideoView.VideoState):
                        {
                            _LabelVideoStatus = VideoView.VideoState.ToString();

                            OnPropertyChanged(nameof(LabelVideoStatus));
                            break;
                        }
                        case nameof(VideoView.Duration):
                            {
                                _Duration = VideoView.Duration;

                                OnPropertyChanged(nameof(Duration));
                                OnPropertyChanged(nameof(SliderDuration));
                                break;
                            }
                    }
                });
            }
        }

        private string _Source = "http://www.sample-videos.com/video/mp4/720/big_buck_bunny_720p_1mb.mp4";

        public string EntrySource
        {
            get { return _Source; }
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
                    videoSource = (ImageSource) imageSourceConverter.ConvertFromInvariantString(_Source);
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