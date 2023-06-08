using EasyAudioSystem;
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
        [SerializeField] private AudioManager audioManager;
        private Slider slider;

        private void Awake()
        {
            slider = stealSlider.GetComponent<Slider>();
            levelManager = GameObject.Find("Game Manager").GetComponent<LevelManager>();
        }

        private void Start()
        {
            StartCoroutine(LateStart(1f));
        }

        IEnumerator LateStart(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            audioManager = FindObjectOfType<AudioManager>();
            audioManager.ResetPitch("Charge");
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (steal.action.ReadValue<float>() == 1 && slider.value != slider.maxValue)
                {
                    Debug.Log("Steal Item");
                    audioManager.Play("Charge");
                    audioManager.ChangePitchUp("Charge", 0.01f);
                    slider.value += 0.015f;
                }
            }
        }

        private void Update()
        {
            if (slider.value == slider.maxValue && fill.GetComponent<Image>().color != Color.green)
            {
                fill.GetComponent<Image>().color = Color.green;
                //figure out how to check collecting in order
                levelManager.CollectItem(transform.parent.name);
                audioManager.ResetPitch("Charge");
                audioManager.Play("Collect");
            }
        }
    }
}