using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Game.Dialogs
{
    public class DialogBuble : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _text;
        [SerializeField] private float _showDuration = 4f;

        public IEnumerator Show(string message)
        {
            gameObject.SetActive(true);
            _text.text = message;
            yield return new WaitForSeconds(_showDuration);
            gameObject.SetActive(false);
        }
    }
}
