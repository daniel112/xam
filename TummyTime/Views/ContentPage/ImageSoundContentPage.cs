using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Timers;
using TummyTime.Common.DependencyInterfaces;
using TummyTime.Extensions;
using TummyTime.ViewModels;
using TummyTime.Views.Base;
using Xamarin.Forms;

namespace TummyTime.Views {
    public class ImageSoundContentPage : BaseContentPage<ImageSoundViewModel> {



        #region Variables
        private const string AssemblyPrefix = "TummyTime.Common.EmbeddedResources.Images";
        private const string EmbeddedImageSuffix = "jpg";
        private const string AudioSourceSuffix = "mp3";
        private int counter;
        private Timer timer;
        private Timer SoundTimer;
        private Image _image;
        private Image image {
            get {
                if (_image == null) {
                    _image = new Image {
                        Aspect = Aspect.AspectFill,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                    };
                }
                return _image;
            }
            set {
                _image = value;
            }
        }
        private IAudioDependencyInterface AudioPlayer = DependencyService.Get<IAudioDependencyInterface>();
        #endregion

        #region Initialization
        public ImageSoundContentPage() {

        }

        protected override void OnAppearing() {
            base.OnAppearing();
            this.Setup();
            // data
            this.StartLoop();
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
        }

        #endregion

        #region Private API
        private void Setup() {

            this.ViewModel.AvailableImages.Shuffle(new Random());
            this.ViewModel.AvailableSounds.Shuffle(new Random());
            this.ViewModel.AvailableSounds.Shuffle(new Random());

            this.counter = 0;
            this.image.Source = $"Image-0";
            this.AudioPlayer.Play($"/Sound/{this.ViewModel.AvailableSounds[counter]}.{AudioSourceSuffix}");
            this.counter++;

            Content = new StackLayout {
                Children = {
                    this.image
                }
            };
        }

        private void StartLoop() {

            // image every 10 seconds
            timer = new Timer(10000);
            timer.Elapsed += new ElapsedEventHandler(Timer_ElapsedHandler);
            timer.Start();

            // sound play only the first 5 seconds
            SoundTimer = new Timer(5000);
            SoundTimer.Elapsed += SoundTimer_Elapsed;
            SoundTimer.Start();

        }

        void SoundTimer_Elapsed(object sender, ElapsedEventArgs e) {

            this.AudioPlayer.Pause();
            SoundTimer.Stop();
        }


        private void Timer_ElapsedHandler(object source, ElapsedEventArgs e) {

            // stop at 30
            if (counter >= 30) {
                Console.WriteLine("\n\nDONE");
                timer.Enabled = false;
                SoundTimer.Enabled = false;
                Device.BeginInvokeOnMainThread(() => {
                    Application.Current.MainPage = new EndContentPage();
                });

            } else {
                Console.WriteLine(counter);
                // start sound for 5 sec
                if (counter <= this.ViewModel.AvailableSounds.Count - 1) {
                    this.AudioPlayer.Play($"/Sound/{this.ViewModel.AvailableSounds[counter]}.{AudioSourceSuffix}");            
					this.SoundTimer.Start();
                    Device.BeginInvokeOnMainThread(() => {
                        this.image.Source = $"{this.ViewModel.AvailableImages[counter]}";
                        Console.WriteLine($"Image: {this.ViewModel.AvailableImages[counter]}");                                                             
                        this.counter++;
                    });

                }

                 


            }
        }

        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion

    }
}


