using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HARROP_CHARLIE.RandomTheft
{
    public class ItemChoiceManager : MonoBehaviour
    {
        public StealableItemList itemList;

        public static List<Item> itemsToSteal = new List<Item>();

        [SerializeField] private int numberOftemsToSteal;

        [SerializeField] private GameObject itemPanel;
        [SerializeField] private GameObject itemImagePrefab;

        private void Start()
        {
            itemsToSteal.Clear();
            PickRandomItems();
            foreach (Item item in itemsToSteal)
            {
                Debug.Log(item.itemName);
            }
            foreach (Item item in itemsToSteal)
            {
                GameObject currentItemImage = Instantiate(itemImagePrefab, itemPanel.transform);
                currentItemImage.GetComponent<Image>().sprite = item.image;
            }
        }

        private void PickRandomItems()
        {
            for (int i = 0; i < numberOftemsToSteal; i++)
            {
                itemsToSteal.Add(itemList.items[Random.Range(0, itemList.items.Count)]);
            }
        }
    }
}

