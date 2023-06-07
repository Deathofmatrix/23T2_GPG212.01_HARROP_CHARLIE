using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HARROP_CHARLIE.RandomTheft
{
    public class SceneManagement : MonoBehaviour
    {
        [SerializeField] private int sceneToLoad;
        public void StartGame()
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

