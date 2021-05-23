using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Game.Configs;

namespace Game.Dialogs
{
    public class DialogBlame : MonoBehaviour
    {
        [SerializeField] private Button _touchZone;
        [SerializeField] private TextMeshProUGUI _text;

        public bool Selected = false;

        public BlameReply StoredBlameReply;

        private void Start()
        {
            _touchZone.onClick.AddListener(OnClick);
        }

        public void Show(BlameReply reply)
        {
            _text.text = reply.Judge;
            StoredBlameReply = reply;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            Selected = false;
            gameObject.SetActive(false);
        }

        private void OnClick()
        {
            Selected = true;
        }
    }
}
