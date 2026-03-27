using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "O2TankSO", menuName = "Scriptable Objects/O2TankSO")]
public class O2TankSO : ScriptableObject
{
    [SerializeField] private float _O2MaxCapacity;
    [SerializeField] private float _O2CurrentCapacity;
    [SerializeField] private float _O2RegenRate;
    [SerializeField] private float _O2DecreaseRate;

    public void O2Regen()
    {
        if (_O2CurrentCapacity < _O2MaxCapacity)
        {

        }
    }

    public void O2Decrease()
    {
        if (_O2CurrentCapacity > 0)
        {

        }
    }
}
