using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Game.UI
{
    public class BlackScreenAnimation : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvas;
        [SerializeField] private float _animationDuration = 0.5f;

        public IEnumerator PlayAnimation(bool isBlack)
        {
            var alpha = isBlack ? 1 : 0;
            _canvas.DOFade(alpha, _animationDuration);
            yield return new WaitUntil(() => _canvas.alpha == alpha);
        }
    }
}
