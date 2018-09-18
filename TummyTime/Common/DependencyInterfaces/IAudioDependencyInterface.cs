using System;
namespace TummyTime.Common.DependencyInterfaces {
    public interface IAudioDependencyInterface {
        void Play(string pathToAudioFile);
        void Play();
        void Pause();
        void FadeToMute();
        Action OnFinishedPlaying { get; set; }
    }
}
