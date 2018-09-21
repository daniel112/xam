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
            //this.BackgroundColor = Color.FromHex("fbfbfb");

            AbsoluteLayout layout = new AbsoluteLayout();

           
            AbsoluteLayout.SetLayoutFlags(this.ImageBow, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(this.ImageBow, new Rectangle(.5, .5, 400, 362));
            layout.Children.Add(this.ImageBow);

            // align to bottom button
            AbsoluteLayout.SetLayoutFlags(this.DismissButton, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
            AbsoluteLayout.SetLayoutBounds(this.DismissButton, new Rectangle(0, 1, 1, 60));
            layout.Children.Add(this.DismissButton);
            Content = layout;
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
