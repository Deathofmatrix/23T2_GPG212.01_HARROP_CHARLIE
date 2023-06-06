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

        [SerializeField] private float sideScreenBufferTop;
        [SerializeField] private float sideScreenBuffer;

        [SerializeField] private GameObject victim;

        [SerializeField] float minDistanceFromCenter;

        [SerializeField] private float collisionRadius;
        private Collider2D[] overlappingColliders;

        public StealableItemList itemList;

        [SerializeField] private int enemyToSpawn;

        private void Start()
        {
            mainCamera = Camera.main;
            
            CalculateScreenSize();

            for (int i = 0; i < enemyToSpawn; i++)
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

            bool isValidPosition = false;
            do
            {
                float randomX = Random.Range((-screenWidth / 2f) + sideScreenBuffer, (screenWidth / 2f) - sideScreenBuffer);
                float randomY = Random.Range((-screenHeight / 2f) + sideScreenBuffer, (screenHeight / 2f) - sideScreenBufferTop);

                position = new Vector2(randomX, randomY);

                isValidPosition = !CheckCollision(position);

            } while (Vector2.Distance(position, new Vector2(0,0)) < minDistanceFromCenter || !isValidPosition);

            return position;
        }

        private bool CheckCollision(Vector2 position)
        {
            overlappingColliders = Physics2D.OverlapCircleAll(position, collisionRadius);

            foreach (Collider2D collider in overlappingColliders)
            {
                if (collider.CompareTag("Victim"))
                {
                    return true;
                }
            }

            return false;
        }


        private void SpawnVictim(Vector3 randomSpawnPosition)
        {
            GameObject lastSpawnedVictim = Instantiate(victim, randomSpawnPosition, Quaternion.identity);
            lastSpawnedVictim.GetComponent<VictimController>().currentItem = itemList.items[Random.Range(0, itemList.items.Count)];
            
        }
    }
}