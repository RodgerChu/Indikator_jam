using Game.Configs;
using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameScore
{
    public enum AnswerAccuracy
    {
        Right, RightOnSecond, Wrong
    }

    public class PointsHolder : MonoBehaviour
    {
        [SerializeField] private PointsConfig _pointsConfig;
        [SerializeField] private PointsPresenter _pointsPresenter;

        private int _currentJusticePoints;
        private int _currentCorruptionPoints;

        private void Start()
        {
            _currentJusticePoints = _pointsConfig.StartingJusticePoints;
            _currentCorruptionPoints = _pointsConfig.StartingCorruptionPoints;

            _pointsPresenter.ShowPoints(_currentJusticePoints, _currentCorruptionPoints);
        }

        public bool HandleAnswer(AnswerAccuracy accuracy)
        {
            PointsOnAnswer points;
            if (accuracy == AnswerAccuracy.Right)
                points = _pointsConfig.OnRightAnswer;
            else if (accuracy == AnswerAccuracy.RightOnSecond)
                points = _pointsConfig.OnRightAnswerSecondChance;
            else
                points = _pointsConfig.OnWrongAnswer;

            _currentCorruptionPoints += points.CorruptionPoints;
            _currentJusticePoints += points.JusticePoints;

            _pointsPresenter.ShowPoints(_currentJusticePoints, _currentCorruptionPoints);

            return _currentJusticePoints > 0;
        }
    }
}
