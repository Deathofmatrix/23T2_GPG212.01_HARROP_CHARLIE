using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

namespace HARROP_CHARLIE.RandomTheft
{
    public class VictimController : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb2D;
        [SerializeField] private float rotationSpeed;

        [SerializeField] private GameObject imageOverlay;
        [SerializeField] private GameObject stealTriggerObject;

        [SerializeField] private Sprite image;

        public Item currentItem;

        private Camera mainCamera;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
            rotationSpeed = Random.Range(-80, -180);
            mainCamera = Camera.main;
        }

        private void Start()
        {
            Vector3 npcPosition = mainCamera.WorldToScreenPoint(stealTriggerObject.transform.position);
            imageOverlay.transform.position = npcPosition;

            image = currentItem.image;
            name = currentItem.itemName.ToString();
        }

        private void Update()
        {
            //Vector3 npcPosition = mainCamera.WorldToScreenPoint(stealTriggerObject.transform.position);
            //imageOverlay.transform.position = npcPosition;

            imageOverlay.GetComponent<Image>().sprite = image;
            //imageOverlay.transform.localPosition = stealTriggerObject.transform.position * 100f;
        }

        private void FixedUpdate()
        {
            rb2D.MoveRotation(rb2D.rotation + rotationSpeed * Time.deltaTime);
        }

        private void SetOverlayPosition()
        {

        }
    }
}