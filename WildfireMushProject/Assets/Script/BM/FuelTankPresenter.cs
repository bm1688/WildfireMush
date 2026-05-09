using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTankPresenter : MonoBehaviour
{
    [SerializeField] private Slider _fuelTankSlider;
    [SerializeField] private PlayerFuel _playerFuel;

    private void Start()
    {
        if (_playerFuel == null)
        {
            _playerFuel = FindObjectOfType<PlayerFuel>();
        }

        if (_playerFuel != null)
        {
            _playerFuel.OnFuelChanged += UpdateFuelUI;
            UpdateFuelUI(_playerFuel.currentFuel, _playerFuel.maxFuel);
        }
    }

    private void OnDestroy()
    {
        if (_playerFuel != null)
        {
            _playerFuel.OnFuelChanged -= UpdateFuelUI;
        }
    }

    private void UpdateFuelUI(float currentFuel, float maxFuel)
    {
        _fuelTankSlider.maxValue = maxFuel;
        _fuelTankSlider.value = currentFuel;
    }
}
