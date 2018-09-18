using System;
using System.Timers;
using TummyTime.ViewModels;
using TummyTime.Views.Base;
using Xamarin.Forms;

namespace TummyTime.Views {
    public class SplashScreenContentPage : ContentPage {

        #region Variables
        private Timer timer;
        private Image _ImageLogo;
        private Image ImageLogo {
            get {
                if (_ImageLogo == null) {
                    _ImageLogo = new Image {
                        Aspect = Aspect.AspectFit,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        HeightRequest = 207,
                        WidthRequest = 276,
                        Source = "launchImage"
                    };
                }
                return _ImageLogo;
            }
            set {
                _ImageLogo = value;
            }
        }

        #endregion

        #region Initialization
        public SplashScreenContentPage() {
            this.Setup();
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            this.StartTimer();
        }
        #endregion

        #region Private API
        private void Setup() {
            this.BackgroundColor = Color.FromHex("fbfbfb");

            // center it to parent
            var mainLayout = new StackLayout {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ImageLogo
                }
            };

            Content = mainLayout;
        }

        private void StartTimer() {
            // 2 seconds
            timer = new Timer(1500);
            timer.Elapsed += new ElapsedEventHandler(Timer_ElapsedHandler);
            timer.Start();
        }

        private void Timer_ElapsedHandler(object source, ElapsedEventArgs e) {
            Device.BeginInvokeOnMainThread(() => {
                timer.Stop();
                Application.Current.MainPage = new DisclaimerContentPage();
            });

        }

        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion

    }
}
