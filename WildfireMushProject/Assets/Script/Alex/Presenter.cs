using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{
    public OxygenTank oxygen;
    public void SetMaxO2(float health)
    {
        oxygen.SetMaxO2(health);
    }
    public void SetO2(float health)
    {
        oxygen.SetO2(health);
    }
}
