using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FuelTankSO", menuName = "Scriptable Objects/FuelTankSO")]
public class FuelTankSO : ScriptableObject
{
    private static FuelTankSO instance;
    public static FuelTankSO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<FuelTankSO>("FuelTankSO");
            }
            return instance;
        }
    }
    [Header("ID / Name")]
    public string id = "fuel_01";
    public string displayName = "Fuel Tank 01";

    [Header("Stats")]
    public float maxFuel = 100f;
    public float drainRate = 10f;

    public void AddFuel(float amount)
    {
        // add fuel logic here, for example, you can have a currentFuel variable and add the amount to it, making sure it doesn't exceed maxFuel
      
    }

}
