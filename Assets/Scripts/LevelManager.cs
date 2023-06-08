using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HARROP_CHARLIE.RandomTheft
{
    public class LevelManager : MonoBehaviour
    {
        public static int currentLevel = 0;
        public  int currentLevelPublic;

        public int itemsCollected;

        [SerializeField] private int currentItemStealing;

        private void Start()
        {
            itemsCollected = 0;

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                currentLevel += 1;
            }

            SaveLoadSystem.Save();
        }

        private void Update()
        {
            currentLevelPublic = currentLevel;

            if (itemsCollected == currentLevel + 2)
            {
                SceneManager.LoadScene(1);
            }
        }

        public void CollectItem(string itemName)
        {
            if (itemName == ItemChoiceManager.itemsToSteal[currentItemStealing].itemName)
            {
                itemsCollected++;
                currentItemStealing++;
            }
            else
            {
                SceneManager.LoadScene(0);
                Debug.Log("wrong item");
            }
        }
    }
}

