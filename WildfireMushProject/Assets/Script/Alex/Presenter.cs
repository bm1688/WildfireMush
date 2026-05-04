using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{
    public float currentO2;
    public float maxO2;
    public OxygenTank oxygen;
    public void SetMaxO2(float health)
    {
        maxO2 = health;
        oxygen.SetMaxO2(maxO2);
        currentO2 = maxO2;
    }
    public void SetO2(float health)
    {
        currentO2 = health;
    }
    private void Update()
    {
        oxygen.SetO2(currentO2);
    }
}
