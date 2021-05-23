using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Configs
{
    [System.Serializable]
    public class BlameReply
    {
        public string Judge;
        public string Defender;
        public BlameAccuracy Accuracy;
    }

    public enum BlameAccuracy
    {
        Right, Wrong
    }

    [CreateAssetMenu(fileName = "DialogConfig", menuName = "SO/DialogConfig", order = 0)]
    public class AccusedConfig : ScriptableObject
    {
        public string StartMessage;
        public string AccusedStartMessage;
        public BlameReply[] BlameReplies;
        public GameObject AccesedGOPrefab;
    }
}
