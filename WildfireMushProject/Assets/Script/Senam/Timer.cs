using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // control a sider bar timer: when the timer is full, the game is ended and call the ending scene

    [SerializeField] private float timerDuration = 10f; // duration of the timer in seconds
    private float timer; // current timer value
    [SerializeField] private Slider timeSlider;

    private void Start()
    {
        timer = 0f; // initialize timer
        timeSlider.maxValue = timerDuration; // set the slider's max value to the timer duration
    }

    private void Update()
    {
        timer += Time.deltaTime; // increment timer by the time elapsed since last frame
        timeSlider.value = timer; // update the slider value to reflect the current timer
        if (timer >= timerDuration)
        {
            Time.timeScale = 0f;// call the end game function when timer is full
        }
    }
}
