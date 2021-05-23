using Game.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Dialogs
{
    public class DialogBlameHolder : MonoBehaviour
    {
        [SerializeField] private DialogBlameConfirmButton[] _confirmButtons;
        [SerializeField] private DialogBlame _dialogBalmeHolderPrefab;
        [SerializeField] private Transform _blameItemsParent;

        private List<DialogBlame> _blameHolders = new List<DialogBlame>();

        public BlameReply SelectedBlameReply { get; private set; }
        public bool ConfirmedBlame { get; private set; }

        public IEnumerator ShowBlameMessages(BlameReply[] blameReplies)
        {
            var index = 0;
            foreach(var reply in blameReplies)
            {
                DialogBlame blame;
                if (index >= _blameHolders.Count)
                {
                    blame = Instantiate(_dialogBalmeHolderPrefab).GetComponent<DialogBlame>();
                    blame.transform.SetParent(_blameItemsParent);
                    _blameHolders.Add(blame);
                }
                else
                    blame = _blameHolders[index];

                blame.Show(reply);
                index++;
            }

            Func<bool> predicate = () => _blameHolders.Any(holder => holder.Selected);
            yield return new WaitUntil(() => predicate());
            SelectedBlameReply = _blameHolders.First(blame => blame.Selected).StoredBlameReply;

            foreach (var item in _blameHolders)
                item.Hide();
        }

        public IEnumerator ShowConfirmAction()
        {
            foreach (var button in _confirmButtons)
                button.Show();

            yield return new WaitUntil(() => _confirmButtons.Any(button => button.Selected));

            ConfirmedBlame = _confirmButtons.First(button => button.Selected).IsConfirmAction;
            foreach (var button in _confirmButtons)
                button.Hide();            
        }
    }
}
