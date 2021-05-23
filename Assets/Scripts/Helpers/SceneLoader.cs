using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.UI
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int sceneId)
        {
            SceneManager.LoadScene(sceneId);
        }
    }
}
