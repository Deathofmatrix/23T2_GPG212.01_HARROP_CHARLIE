using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace HARROP_CHARLIE.RandomTheft
{
    public class VictimSpawn : MonoBehaviour
    {
        private Camera mainCamera;
        [SerializeField] private float screenWidth;
        [SerializeField] private float screenHeight;

        [SerializeField] private GameObject victim;

        [SerializeField] float minDistanceFromCenter;

        private void Start()
        {
            mainCamera = Camera.main;
            
            CalculateScreenSize();

            for (int i = 0; i < 10; i++)
            {
                SpawnVictim(RandomPosition());
            }
        }

        private void CalculateScreenSize()
        {
            float screenRatio = (float)Screen.width / Screen.height;
            float halfScreenWidth = mainCamera.orthographicSize * screenRatio;
            float halfScreenHeight = mainCamera.orthographicSize;

            screenWidth = halfScreenWidth * 2f;
            screenHeight = halfScreenHeight * 2f;
        }

        private Vector3 RandomPosition()
        {
            Vector2 position;
            do
            {
                float randomX = Random.Range(-screenWidth / 2f, screenWidth / 2f);
                float randomY = Random.Range(-screenHeight / 2f, screenHeight / 2f);

                position = new Vector2(randomX, randomY);
            } while (Vector2.Distance(position, new Vector2(0,0)) < minDistanceFromCenter);

            return position;
        }

        private void SpawnVictim(Vector3 randomSpawnPosition)
        {
            GameObject lastSpawnedVictim = Instantiate(victim, randomSpawnPosition, Quaternion.identity);
        }
    }
}