using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FuelTankSO", menuName = "Scriptable Objects/FuelTankSO")]
public class FuelTankSO : ScriptableObject
{
    [Header("ID / Name")]
    public string id = "fuel_01";
    public string displayName = "Fuel Tank 01";

    [Header("Stats")]
    public float maxFuel = 100f;
    public float drainRate = 10f;
}
