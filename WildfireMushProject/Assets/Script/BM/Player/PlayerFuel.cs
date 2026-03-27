using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    public float currentFuel = 100f;
    public float maxFuel = 100f;
    public float drainRate = 10f;

    public void ApplyFuelTank(FuelTankSO tank, bool refill = true)
    {
        if (tank == null) return;

        maxFuel = tank.maxFuel;
        drainRate = tank.drainRate;

        if (refill)
            currentFuel = maxFuel;

        if (currentFuel > maxFuel)
            currentFuel = maxFuel;
    }

    // add with fire gun: call ConsumeFuel(amount)
    public bool ConsumeFuel(float amount)
    {
        if (currentFuel <= 0f) return false;

        currentFuel -= amount;
        if (currentFuel < 0f) currentFuel = 0f;

        return true;
    }
}
