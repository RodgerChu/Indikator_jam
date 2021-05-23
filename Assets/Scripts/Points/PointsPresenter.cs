using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.UI
{
    public class PointsPresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _justicePoints;
        [SerializeField] private TextMeshProUGUI _corruptionPoints;

        public void ShowPoints(int justice, int corruption)
        {
            _justicePoints.text = justice.ToString();
            _corruptionPoints.text = corruption.ToString();
        }
    }
}
