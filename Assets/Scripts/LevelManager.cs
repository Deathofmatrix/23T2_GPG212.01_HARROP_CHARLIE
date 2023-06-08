using EasyAudioSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HARROP_CHARLIE.RandomTheft
{
    public class LevelManager : MonoBehaviour
    {
        public static int currentLevel = 0;
        public  int currentLevelPublic;

        public int itemsCollected;

        [SerializeField] private int currentItemStealingIndex;

        [SerializeField] private TextMeshProUGUI tmpUGUI;

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
                if (itemsCollected < 10)
                {
                    SceneManager.LoadScene(1);

                }
                else
                {
                    SceneManager.LoadScene(4);
                }
            }

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                DisplayItemsLeft();
            }
        }

        public void CollectItem(string itemName)
        {
            if (itemName == ItemChoiceManager.itemsToSteal[currentItemStealingIndex].itemName)
            {
                itemsCollected++;
                currentItemStealingIndex++;
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("LoseSound");
                SceneManager.LoadScene(0);
                SaveLoadSystem.ClearPrefs();
                Debug.Log("wrong item");
            }
        }

        public void DisplayItemsLeft()
        {
            int itemsLeft = (currentLevel + 2) - (itemsCollected);
            tmpUGUI.text = $"{itemsLeft} Items Left!";
        }
    }
}

