using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    [SerializeField] private float _currentFuel = 100f;
    public float currentFuel { get { return _currentFuel; } }

    [SerializeField] private float _maxFuel = 100f;
    public float maxFuel { get { return _maxFuel; } }

    [SerializeField] private float _refillAmount;

    public float drainRate = 10f;

    // This event tells UI when fuel value or max fuel changes.
    public event Action<float, float> OnFuelChanged;

    private void Start()
    {
        NotifyFuelChanged();
        _refillAmount = maxFuel;
    }

    private void Update()
    {
 
    }

    public void ApplyFuelTank(FuelTankSO tank, bool refill = true)
    {
        if (tank == null) return;

        _maxFuel = tank.maxFuel;
        drainRate = tank.drainRate;
        _refillAmount = maxFuel;


        if (_currentFuel > _maxFuel)
            _currentFuel = _maxFuel;

        Refill();

        NotifyFuelChanged();
    }

    public bool ConsumeFuel(float amount)
    {
        if (_currentFuel <= 0f) return false;

        _currentFuel -= amount;

        if (_currentFuel < 0f)
            _currentFuel = 0f;

        NotifyFuelChanged();

        return true;
    }

    private void NotifyFuelChanged()
    {
        OnFuelChanged?.Invoke(_currentFuel, _maxFuel);
    }

 public void Refill()
    {
        if (AudioManager.instance != null)
            AudioManager.instance.PlaySFX("addFuel");
        _currentFuel = _maxFuel;
        NotifyFuelChanged();
    }



}
