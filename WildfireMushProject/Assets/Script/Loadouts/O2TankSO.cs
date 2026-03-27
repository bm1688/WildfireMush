using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "O2TankSO", menuName = "Scriptable Objects/O2TankSO")]
public class O2TankSO : ScriptableObject
{
    [Header("ID / Name")]
    public string id = "o2_01";
    public string displayName = "O2 Tank 01";

    [Header("Stats")]
    public float maxO2 = 100f;
    public float regenRate = 27f;
    public float decreaseRate = 10f;
}
