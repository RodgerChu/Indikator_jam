using Game.Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Sound
{
    public class SoundVolumeController : MonoBehaviour
    {
        [SerializeField] private SoundConfig _soundConfig;
        [SerializeField] private Slider _volumeSlider;

        AudioSource[] _audioSources;

        private void Start()
        {
            _audioSources = FindObjectsOfType<AudioSource>();
            SetVolume();

            if (_volumeSlider != null)
            {
                _volumeSlider.value = _soundConfig.MusicVolume;
                _volumeSlider.onValueChanged.AddListener(OnSoundVolumeChange);
            }
        }

        private void OnSoundVolumeChange(float newValue)
        {
            _soundConfig.MusicVolume = newValue;
            SetVolume();
        }

        private void SetVolume()
        {
            foreach (var source in _audioSources)
                source.volume = _soundConfig.MusicVolume;
        }
    }
}
