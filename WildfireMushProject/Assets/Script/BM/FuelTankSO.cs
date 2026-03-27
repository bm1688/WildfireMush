using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FuelTankSO", menuName = "Scriptable Objects/FuelTankSO")]
public class FuelTankSO : ScriptableObject
{
    [SerializeField] private float _fuelMaxCapacity;
    [SerializeField] private float _fuelCurrentCapacity;
    [SerializeField] private float _fuelDecreaseRate;

    public void FuelDecrease()
    {

    }

}
