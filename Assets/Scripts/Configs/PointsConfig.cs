using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Configs
{
    [System.Serializable]
    public class PointsOnAnswer
    {
        public int JusticePoints;
        public int CorruptionPoints;
    }

    [CreateAssetMenu(fileName = "PointsConfig", menuName = "SO/PointsConfig", order = 1)]
    public class PointsConfig : ScriptableObject
    {
        public int StartingJusticePoints = 6;
        public int StartingCorruptionPoints = 6;

        public PointsOnAnswer OnRightAnswer;
        public PointsOnAnswer OnRightAnswerSecondChance;
        public PointsOnAnswer OnWrongAnswer;
    }
}
