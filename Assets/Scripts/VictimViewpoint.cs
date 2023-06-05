using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HARROP_CHARLIE.RandomTheft
{
    public class VictimViewpoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("The player has been spotted by " + name);
            }
        }
    }
}