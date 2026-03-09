using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenTank : MonoBehaviour
{
    public Slider slider;

    public void SetMaxO2(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetO2(float health)
    {
        slider.value = health;
    }
}
