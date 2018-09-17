using System;
using System.Collections.Generic;
using TummyTime.ViewModels.Base;

namespace TummyTime.ViewModels {
    public class ImageSoundViewModel : BaseViewModel {
        #region Variables
        private List<string> _AvailableImages;
        public List<string> AvailableImages {
            get {
                if (_AvailableImages == null) {
                    _AvailableImages = new List<string>();
                    for (int i = 0; i < 43; i++) {
                        _AvailableImages.Add($"bg-{i}");
                    }

                }
                return _AvailableImages;
            }

        }

        private List<string> _AvailableSounds;
        public List<string> AvailableSounds {
            get {
                if (_AvailableSounds == null) {
                    _AvailableSounds = new List<string>();
                    for (int i = 0; i < 43; i++) {
                        _AvailableSounds.Add($"sound-{i}");
                    }

                }
                return _AvailableSounds;
            }

        }
        #endregion

        #region Initialization

        #endregion

        #region Private API

        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion
        public ImageSoundViewModel() {
        }
    }
}
