using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HARROP_CHARLIE.RandomTheft
{
    public class VictimController : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb2D;
        [SerializeField] private float rotationSpeed;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb2D.MoveRotation(rb2D.rotation + rotationSpeed * Time.deltaTime);
        }
    }
}