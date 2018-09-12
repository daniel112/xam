using System;
namespace TummyTime.Common.DependencyInterfaces {
    public interface IAudioDependencyInterface {
        void Play(string pathToAudioFile);
        void Play();
        void Pause();
        Action OnFinishedPlaying { get; set; }
    }
}
