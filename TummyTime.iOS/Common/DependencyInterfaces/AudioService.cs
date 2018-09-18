using System;
using System.IO;
using AudioToolbox;
using AVFoundation;
using Foundation;
using TummyTime.Common.DependencyInterfaces;
using TummyTime.iOS.Common.DependencyInterfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(AudioService))]
namespace TummyTime.iOS.Common.DependencyInterfaces {
    public class AudioService : IAudioDependencyInterface {

        private AVAudioPlayer _audioPlayer = null;

        public Action OnFinishedPlaying { get; set; }

        public void Pause() {
            _audioPlayer?.Pause();
        }

        public void Play(string pathToAudioFile) {
            // Check if _audioPlayer is currently playing  
            if (_audioPlayer != null) {
               // _audioPlayer.FinishedPlaying -= Player_FinishedPlaying;
                _audioPlayer.Stop();
            }

            String dir = Directory.GetCurrentDirectory();
            // check if file can be reached
            var mp3 = AudioToolbox.AudioFile.Open($"{dir}{pathToAudioFile}", AudioFilePermission.Read, AudioFileType.MP3);
            if (mp3 != null) {
                _audioPlayer = AVAudioPlayer.FromUrl(NSUrl.FromString($"{dir}{pathToAudioFile}"));
                _audioPlayer.FinishedPlaying += Player_FinishedPlaying;
                _audioPlayer.Play();
            }

        }

        public void Play() {
            _audioPlayer?.SetVolume(1, 0);
            _audioPlayer?.Play();
        }

        public void FadeToMute() {
            _audioPlayer?.SetVolume(0, 5);
        }

        private void Player_FinishedPlaying(object sender, AVStatusEventArgs e) {
            OnFinishedPlaying?.Invoke();
        }

    }
}
