using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Helpers
{
    public class AlwaysLookAtCam : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private void Update()
        {
            gameObject.transform.LookAt(_camera.transform);
        }
    }
}
