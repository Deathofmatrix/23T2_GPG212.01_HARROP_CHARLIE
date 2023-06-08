using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HARROP_CHARLIE.RandomTheft
{
    public class SaveLoadSystem : MonoBehaviour
    {

        public static void Save()
        {
            PlayerPrefs.SetInt("Current Level", LevelManager.currentLevel - 1);
            PlayerPrefs.Save();
        }

        public static void Load()
        {
            LevelManager.currentLevel = PlayerPrefs.GetInt("Current Level");
        }

        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteKey("Current Level");
            LevelManager.currentLevel = 0;
        }
    }
}

