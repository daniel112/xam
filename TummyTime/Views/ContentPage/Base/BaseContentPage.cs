using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace TummyTime.Views.Base {

    public abstract class BaseContentPage<TVieModel> : ContentPage where TVieModel : INotifyPropertyChanged, new() {

        #region Variables
        protected TVieModel ViewModel = new TVieModel();
        #endregion

        #region Abstract

        #endregion

        #region Initialization
        protected BaseContentPage() {
            BindingContext = ViewModel;
        }



        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);
        }


        #endregion


    }
}
