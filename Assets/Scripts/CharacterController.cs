using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HARROP_CHARLIE.RandomTheft
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private InputActionReference move;

        private Vector2 moveInput;
        [SerializeField] private float moveSpeed;

        private Rigidbody2D rb2D;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            moveInput = move.action.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            rb2D.MovePosition(rb2D.position + moveInput.normalized * moveSpeed * Time.deltaTime);
        }
    }
}
