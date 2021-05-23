using Game.Configs;
using Game.Dialogs;
using Game.GameScore;
using Game.UI;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class CoreGameplayManager : MonoBehaviour
    {
        [SerializeField] private DialogBuble _judgeReplyHolder;
        [SerializeField] private DialogBuble _defenderReplyHolder;
        [SerializeField] private DialogBuble _accusedReplyHolder;
        [SerializeField] private DialogBlameHolder _blameActionHolder;
        [SerializeField] private AccusedConfig[] _accusedConfig;
        [SerializeField] private Transform _accusedParent;
        [SerializeField] private BlackScreenAnimation _blackScreenAnimation;
        [SerializeField] private PointsHolder _pointsHolder;
        [SerializeField] private EndgameHolder _endgameHolder;

        private void Start()
        {
            StartProcess();
        }

        public void StartProcess()
        {
            StartCoroutine(ProcessCoroutine());
        }

        private IEnumerator ProcessCoroutine()
        {
            while(true)
            {
                var gameState = GameFinishState.Wictory;
                foreach (var config in _accusedConfig)
                {
                    var accused = Instantiate(config.AccesedGOPrefab, _accusedParent);

                    accused.transform.localPosition = Vector3.zero;
                    accused.transform.localRotation = Quaternion.identity;
                    yield return StartCoroutine(_blackScreenAnimation.PlayAnimation(false));
                    yield return StartCoroutine(_judgeReplyHolder.Show(config.StartMessage));
                    yield return StartCoroutine(_accusedReplyHolder.Show(config.AccusedStartMessage));

                    var choiceType = AnswerAccuracy.Right;
                    var decisionMade = false;
                    var firstTry = true;
                    while (!decisionMade)
                    {
                        yield return StartCoroutine(_blameActionHolder.ShowBlameMessages(config.BlameReplies));
                        if (firstTry)
                        {
                            firstTry = false;
                            yield return StartCoroutine(_defenderReplyHolder.Show(_blameActionHolder.SelectedBlameReply.Defender));
                            yield return StartCoroutine(_blameActionHolder.ShowConfirmAction());
                            decisionMade = _blameActionHolder.ConfirmedBlame;
                        }
                        else
                            decisionMade = true;                        

                        if (_blameActionHolder.SelectedBlameReply.Accuracy == BlameAccuracy.Wrong)
                            choiceType = AnswerAccuracy.Wrong;
                        else if (_blameActionHolder.SelectedBlameReply.Accuracy == BlameAccuracy.Right && choiceType == AnswerAccuracy.Wrong)
                            choiceType = AnswerAccuracy.RightOnSecond;
                    }

                    yield return StartCoroutine(_blackScreenAnimation.PlayAnimation(true));

                    Destroy(accused);
                    accused = null;

                    if (!_pointsHolder.HandleAnswer(choiceType))
                    {
                        gameState = GameFinishState.Lose;
                        break;
                    }
                }

                yield return StartCoroutine(_endgameHolder.ShowEndGameScreen(gameState));
            }


        }
    }
}
