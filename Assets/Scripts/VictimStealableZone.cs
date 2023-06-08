using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace HARROP_CHARLIE.RandomTheft
{
    public class VictimStealableZone : MonoBehaviour
    {
        [SerializeField] private InputActionReference steal;

        [SerializeField] private GameObject stealSlider;
        [SerializeField] private GameObject fill;
        [SerializeField] private LevelManager levelManager;
        private Slider slider;

        private void Awake()
        {
            slider = stealSlider.GetComponent<Slider>();
            levelManager = GameObject.Find("Game Manager").GetComponent<LevelManager>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (steal.action.ReadValue<float>() == 1)
                {
                    Debug.Log("Steal Item");
                    slider.value += 0.01f;
                }
            }
        }

        private void Update()
        {
            if (slider.value == slider.maxValue && fill.GetComponent<Image>().color != Color.green)
            {
                fill.GetComponent<Image>().color = Color.green;
                //figure out how to check collecting in order
                levelManager.CollectItem();
            }
        }
    }
}