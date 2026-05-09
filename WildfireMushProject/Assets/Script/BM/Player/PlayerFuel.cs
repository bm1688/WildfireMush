using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    [SerializeField] private float _currentFuel = 100f;
    public float currentFuel { get { return _currentFuel; } }
    [SerializeField] private float _maxFuel = 100f;
    public float maxFuel {  get { return _maxFuel; } } 
    public float drainRate = 10f;

    public void ApplyFuelTank(FuelTankSO tank, bool refill = true)
    {
        if (tank == null) return;

        _maxFuel = tank.maxFuel;
        drainRate = tank.drainRate;

        if (refill)
        {
            AudioManager.instance.PlaySFX("addFuel");
            _currentFuel = _maxFuel;
        }
            

        if (_currentFuel > _maxFuel)
            _currentFuel = _maxFuel;
    }

    // add with fire gun: call ConsumeFuel(amount)
    public bool ConsumeFuel(float amount)
    {
        if (_currentFuel <= 0f) return false;

        _currentFuel -= amount;
        if (_currentFuel < 0f) _currentFuel = 0f;

        return true;
    }
}
