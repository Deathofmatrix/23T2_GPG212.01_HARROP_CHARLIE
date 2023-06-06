using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HARROP_CHARLIE.RandomTheft
{
    [CreateAssetMenu(fileName = "ItemList", menuName = "Custom/ItemList")]
    public class StealableItemList : ScriptableObject
    {
        public List<Item> items = new List<Item>();
    }
}