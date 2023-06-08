using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HARROP_CHARLIE.RandomTheft
{
    public class LevelManager : MonoBehaviour
    {
        public static int currentLevel = 0;

        public int itemsCollected;

        private void Start()
        {
            itemsCollected = 0;

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                currentLevel += 1;
            }
        }

        private void Update()
        {
            if (itemsCollected == currentLevel + 2)
            {
                SceneManager.LoadScene(1);
            }
        }

        public void CollectItem()
        {
            itemsCollected++;
        }

    }
}

