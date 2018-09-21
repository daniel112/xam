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
                    };
                    _DismissButton.Clicked += DismissButton_Clicked;
                }
                return _DismissButton;
            }
        }

        private Image _ImageBow;
        private Image ImageBow {
            get {
                if (_ImageBow == null) {
                    _ImageBow = new Image {
                        Aspect = Aspect.AspectFit,
                        Source = "bow",
                        WidthRequest = 330,
                    };
                }
                return _ImageBow;
            }
            set {
                _ImageBow = value;
            }
        }

        private Label _LabelDisclaimer;
        private Label LabelDisclaimer {
            get {
                if (_LabelDisclaimer == null) {
                    _LabelDisclaimer = new Label {
                        Text = "The Tummy Time mobile app is not intended as a substitute for adult supervision.  Please never leave your baby alone during tummy time. ",
                        FontSize = 17,
                        FontFamily = "Cambria", // iOS only TODO: add android ttf
                        LineBreakMode = LineBreakMode.WordWrap,
                        HorizontalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Margin = new Thickness(30, 0, 30 , 0)
                    };
                }

                return _LabelDisclaimer;
            }
        }

        private Label _labelSite;
        private Label LabelSite {
            get {
                if (_labelSite == null) {
                    _labelSite = new Label {
                        Text = "TummyTimeApps.com",
                        FontSize = 20,
                        FontFamily = "Cambria", // iOS only TODO: add android ttf
                        LineBreakMode = LineBreakMode.WordWrap,
                        HorizontalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.Center,
                    };
                }

                return _labelSite;
            }
        }


        private StackLayout _StackDisclaimer;
        private StackLayout StackDisclaimer {
            get {
                if (_StackDisclaimer == null) {
                    _StackDisclaimer = new StackLayout();
                }
                return _StackDisclaimer;
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
            AbsoluteLayout layout = new AbsoluteLayout();


            this.StackDisclaimer.Children.Add(this.LabelDisclaimer);
            this.StackDisclaimer.Children.Add(this.ImageBow);
            this.StackDisclaimer.Children.Add(this.LabelSite);
            // center label
            AbsoluteLayout.SetLayoutFlags(this.StackDisclaimer, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(this.StackDisclaimer, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            layout.Children.Add(this.StackDisclaimer);


            // align to bottom button
            AbsoluteLayout.SetLayoutFlags(this.DismissButton, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
            AbsoluteLayout.SetLayoutBounds(this.DismissButton, new Rectangle(0, 1, 1, 60));
            layout.Children.Add(this.DismissButton);


            // update size based on device
            if (Device.Idiom == TargetIdiom.Tablet) {
                this.LabelDisclaimer.FontSize = 24;
                this.LabelSite.FontSize = 22;
            }

            if (Device.Idiom == TargetIdiom.Phone) {
                this.LabelDisclaimer.FontSize = 17;
                this.LabelSite.FontSize = 15;
            }

            Content = layout;
        }



        // UIResponder
        void DismissButton_Clicked(object sender, EventArgs e) {
            Application.Current.MainPage = new ImageSoundContentPage();
        }

        #endregion

    }
}
