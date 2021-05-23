using Game.Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

namespace Game.UI
{
    public enum GameFinishState
    {
        Wictory, Lose
    }

    public class EndgameHolder : MonoBehaviour
    {
        [SerializeField] private EndgameMessageConfig _messageConfig;
        [SerializeField] private TextMeshProUGUI _endgameText;
        [SerializeField] private CanvasGroup _canvas;

        [SerializeField] private float _animationDuration = 2f;

        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _exit;

        private bool _playAgainSelected = false;

        private void Start()
        {
            _exit.onClick.AddListener(() => {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
            });
            _playAgainButton.onClick.AddListener(() => _playAgainSelected = true);
        }

        public IEnumerator ShowEndGameScreen(GameFinishState state)
        {
            _endgameText.text = state == GameFinishState.Wictory ? _messageConfig.OnWinMessage : _messageConfig.OnLoseMessage;

            _canvas.DOFade(1, _animationDuration);
            yield return new WaitUntil(() => _canvas.alpha == 1);
            _canvas.interactable = true;
            _canvas.blocksRaycasts = true;
            yield return new WaitUntil(() => _playAgainSelected);

            _playAgainSelected = false;

            _canvas.DOFade(0, _animationDuration);
            yield return new WaitUntil(() => _canvas.alpha == 0);

            _canvas.interactable = false;
            _canvas.blocksRaycasts = false;
        }
    }
}
