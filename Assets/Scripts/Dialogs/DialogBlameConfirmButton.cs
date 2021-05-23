using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.Dialogs
{
    public class DialogBlameConfirmButton : MonoBehaviour
    {
        [SerializeField] private Button _touchZone;
        public bool IsConfirmAction = true;

        public bool Selected { get; private set; }

        private void Start()
        {
            _touchZone.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Selected = true;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Selected = false;
        }

        public void Hide()
        {
            Selected = false;
            gameObject.SetActive(false);
        }
    }
}
