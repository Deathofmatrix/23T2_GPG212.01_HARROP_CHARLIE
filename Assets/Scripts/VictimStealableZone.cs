using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HARROP_CHARLIE.RandomTheft
{
    public class VictimStealableZone : MonoBehaviour
    {
        [SerializeField] private InputActionReference steal;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (steal.action.ReadValue<float>() == 1)
                {
                    Debug.Log("Steal Item");
                }
            }
        }
    }
}