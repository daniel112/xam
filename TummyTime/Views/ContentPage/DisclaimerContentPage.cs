using System;
using TummyTime.ViewModels;
using TummyTime.Views.Base;
using Xamarin.Forms;

namespace TummyTime.Views {
    public class DisclaimerContentPage : BaseContentPage<DisclaimerViewModel> {

        #region Variables
        private Button _DismissButton;
        private Button DismissButton {
            get {
                if (_DismissButton == null) {
                    _DismissButton = new Button {
                        Text = "START",
                        TextColor = Color.White,
                        BackgroundColor = Color.FromHex("89211b"),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        CornerRadius = 0,
                        HeightRequest = 60
                    };
                    _DismissButton.Clicked += DismissButton_Clicked;
                }
                return _DismissButton;
            }
        }

        private Image _ImageDisclaimer;
        private Image ImageDisclaimer {
            get {
                if (_ImageDisclaimer == null) {
                    _ImageDisclaimer = new Image {
                        Aspect = Aspect.AspectFit,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Source = "disclaimer"
                    };
                }
                return _ImageDisclaimer;
            }
            set {
                _ImageDisclaimer = value;
            }
        }

        #endregion

        #region Initialization
        public DisclaimerContentPage() {
            this.Setup();
        }

        protected override void OnAppearing() {
            base.OnAppearing();

        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
        }

        #endregion

        #region Private API
        private void Setup() {
            this.BackgroundColor = Color.FromHex("fbfbfb");
            Content = new StackLayout {
                Children = {
                    this.ImageDisclaimer,
                    this.DismissButton
                }
            };
        }



        // UIResponder
        void DismissButton_Clicked(object sender, EventArgs e) {
            Console.WriteLine("PRESSED");
            Application.Current.MainPage = new ImageSoundContentPage();

        }

        #endregion

    }
}
