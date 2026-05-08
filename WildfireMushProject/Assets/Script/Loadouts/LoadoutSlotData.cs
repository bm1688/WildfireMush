using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LoadoutSlotData
{
    public string o2TankId;
    public string fuelTankId;
    public string shoeId;

    public LoadoutSlotData()
    {
        o2TankId = "";
        fuelTankId = "";
        shoeId = "";
    }

    public LoadoutSlotData(string o2Id, string fuelId, string shoeId)
    {
        o2TankId = o2Id;
        fuelTankId = fuelId;
        this.shoeId = shoeId;
    }

    public bool IsEmpty()
    {
        return string.IsNullOrEmpty(o2TankId) ||
               string.IsNullOrEmpty(fuelTankId) ||
               string.IsNullOrEmpty(shoeId);
    }
}
