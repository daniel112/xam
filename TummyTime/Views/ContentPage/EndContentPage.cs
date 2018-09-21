using System;
using TummyTime.ViewModels;
using TummyTime.Views.Base;
using Xamarin.Forms;

namespace TummyTime.Views {
    public class EndContentPage : BaseContentPage<EndViewModel> {
        #region Variables
        private Image _ImageBow;
        private Image ImageBow {
            get {
                if (_ImageBow == null) {
                    _ImageBow = new Image {
                        Aspect = Aspect.AspectFit,
                        Source = "endLogo",
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                }
                return _ImageBow;
            }
            set {
                _ImageBow = value;
            }
        }

        private Button _DismissButton;
        private Button DismissButton {
            get {
                if (_DismissButton == null) {
                    _DismissButton = new Button {
                        Text = "REPLAY",
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
        #endregion

        #region Initialization
        public EndContentPage() {
            this.BackgroundColor = Color.FromHex("fbfbfb");
            Content = new StackLayout {
                Children = {
                    ImageBow,
                    DismissButton
                }
            };
        }
        #endregion

        #region Private API
        // UIResponder
        void DismissButton_Clicked(object sender, EventArgs e) {
            Application.Current.MainPage = new ImageSoundContentPage();
        }

        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion
    }
}
