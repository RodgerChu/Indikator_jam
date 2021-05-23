using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Game.Configs
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "SO/SoundConfig", order = 4)]
    public class SoundConfig : ScriptableObject
    {
        public float MusicVolume = 0.5f;
    }
}
