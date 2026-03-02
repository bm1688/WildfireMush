using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualTimer : MonoBehaviour
{
    [SerializeField] private Slider timeSlider;
    [SerializeField] private Timer timerScript;

    private void Start()
    {
        timeSlider.maxValue = timerScript.TimerDuration;
    }

    private void Update()
    {
        timeSlider.value = timerScript.currentTime;

    }


}
