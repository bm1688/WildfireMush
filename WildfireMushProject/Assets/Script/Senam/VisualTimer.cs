using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualTimer : MonoBehaviour
{
    [SerializeField] private Slider timeSlider;
    [SerializeField] private Timer timerObject;

    private void Start()
    {
        timeSlider.maxValue = timerObject.TimerDuration;
    }

    private void Update()
    {
        timeSlider.value = timerObject.currentTime;

    }


}
